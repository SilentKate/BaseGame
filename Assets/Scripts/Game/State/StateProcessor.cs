using System;

namespace SilentPartyGames.Game.State
{
    public class StateProcessor : ChainElement
    {
        private readonly Func<IGameStateHandler> _factory;

        public StateProcessor(Func<IGameStateHandler> factory)
        {
            _factory = factory;
        }
        
        public override void Handle(object context = null)
        {
            var handler = _factory?.Invoke();
            if (handler == null)
            {
                HandleInterrupted();
                return;
            }
            
            handler.Handle().Subscribe(
                success =>
                {
                    if (success) HandleNext();
                    else HandleInterrupted();
                });
        }
    }
}
