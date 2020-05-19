using System;
using System.Collections.Generic;
using System.Linq;

public class SimpleChain
{
    public event Action<bool> Done;
    private readonly List<ChainElement> _elements = new List<ChainElement>();
    
    public void Add(ChainElement chainElement)
    {
        if (_elements.Contains(chainElement)) return;
        var last = _elements.LastOrDefault();
        if (last != null)
        {
            last.NextElement = chainElement;
        }

        chainElement.OnInterrupted += FailCompletionHandler;
        _elements.Add(chainElement);    
    }

    public void Process()
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

    private void SuccessCompletionHandler()
    {
        Done?.Invoke(true);
    }
    
    private void FailCompletionHandler()
    {
        Done?.Invoke(false);
    }
}