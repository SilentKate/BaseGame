using System;
using System.Collections.Generic;

namespace SilentPartyGames.Tools.Request
{
    public delegate void RequestHandlerDelegate(bool success);
    
    public interface IRequest
    {
        void Subscribe(RequestHandlerDelegate handler);
        void Unsubscribe(RequestHandlerDelegate handler);
    }
    
    public abstract class Request : IRequest
    {
        private readonly List<RequestHandlerDelegate> _handlers = new List<RequestHandlerDelegate>();
        private bool _succeed;
        private bool _completed;

        private Action _delegates;
        
        public void Unsubscribe(RequestHandlerDelegate handler)
        {
            if (_handlers.Contains(handler)) _handlers.Remove(handler);
        }
        
        public void Subscribe(RequestHandlerDelegate handler)
        {
            if (_completed)
            {
                handler?.Invoke(_succeed);
                return;
            }
            _handlers.Add(handler);
            StartInternal();
        }

        protected void Complete(bool success)
        {
            _completed = true;
            _succeed = success;
            CompleteInternal();
            foreach (var handler in _handlers)
            {
                handler?.Invoke(_succeed);
            }
        }

        protected abstract void CompleteInternal();
        protected abstract void StartInternal();
    }
}