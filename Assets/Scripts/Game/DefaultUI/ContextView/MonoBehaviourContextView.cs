using SilentPartyGames.Game.State;
using UnityEngine;

namespace SilentPartyGames.Game.DefaultUI.ContextView
{
    public abstract class MonoBehaviourContextView<T> : MonoBehaviour, IView<T> where T : class, IViewModel
    {
        public object Context
        {
            get => TypedContext;
            set
            {
                if (TypedContext != null)
                {
                    OnContextDetached(TypedContext);
                    TypedContext.Deinit();
                }
                TypedContext = value as T;

                if (TypedContext != null)
                {
                    
                    TypedContext.Init();
                    OnContextAttached(TypedContext);
                }
            }
        }
        
        
        public T TypedContext { get; private set; }

        protected abstract void OnContextDetached(T context);
        protected abstract void OnContextAttached(T context);
    }
}