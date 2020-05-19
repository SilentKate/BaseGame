using System;
using System.Collections.Generic;
using System.Linq;
using SilentPartyGames.Tools.Request;

public class SimpleRequestChain : Request
{
    private readonly List<ChainElement> _elements = new List<ChainElement>();

    public SimpleRequestChain Add(IRequest request)
    {
        var chainElement = new RequestChainElement(request);
        return Add(chainElement);
    }
    
    public SimpleRequestChain Add(ChainElement chainElement)
    {
        var last = _elements.LastOrDefault();
        if (last != null)
        {
            last.NextElement = chainElement;
        }
        chainElement.OnInterrupted += FailCompletionHandler;
        _elements.Add(chainElement);
        return this;
    }

    private void SuccessCompletionHandler()
    {
        Complete(true);
    }
    
    private void FailCompletionHandler()
    {
        Complete(false);
    }

    protected override void CompleteInternal()
    {
        _elements.Clear();
    }

    protected override void StartInternal()
    {
        Process();
    }
 
    private void Process()
    {
        var last = _elements.LastOrDefault();
        if (last == null)
        {
            throw new InvalidOperationException("SimpleChain :: Process : Try to process empty chain");
        }

        last.OnFinished += SuccessCompletionHandler;
        
        var first = _elements.FirstOrDefault();
        if (first == null)
        {
            throw new InvalidOperationException("SimpleChain :: Process : Try to process empty chain");
        }
        
        first.Handle();
    }
    
    private class RequestChainElement: ChainElement
    {
        private readonly IRequest _request;

        public RequestChainElement(IRequest request)
        {
            _request = request;
        }

        public override void Handle(object context = null)
        {
            _request.Subscribe(
                success =>
                {
                    if (success) HandleNext(context);
                    else HandleInterrupted();
                });
        }
    }
}