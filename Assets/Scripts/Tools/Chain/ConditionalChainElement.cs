using System;

public class ConditionalChainElement: ChainElement
{
    private readonly Func<bool> _predicate;

    public ConditionalChainElement(
        Func<bool> predicate)
    {
        _predicate = predicate;
    }

    public override void Handle(object context = null)
    {
        if (_predicate == null)
        {
            HandleInterrupted();
            return;
        }

        if (_predicate.Invoke()) HandleNext();
        else HandleInterrupted();
    }
}