using System;
using UnityEngine;

public abstract class ChainElement
{
    public ChainElement NextElement { get; set; }
    public Action OnInterrupted { get; set; }
    public Action OnFinished { get; set; }

    public abstract void Handle(object context = null);

    protected void HandleNext(object context = null)
    {
        if (NextElement != null)
        {
            NextElement.Handle(context);
        }
        else
        {
            HandleFinished();
        }
    }

    protected void HandleInterrupted()
    {
        OnInterrupted?.Invoke();
    }

    private void HandleFinished()
    {
        if (OnFinished == null)
        {
            Debug.LogError("ChainElement :: HandleFinished : endless chain!");
        }
        OnFinished?.Invoke();
    }
}