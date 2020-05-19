using System;
using JetBrains.Annotations;
using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public class PrepareMenuHandler : IGameStateHandler
    {
        private readonly IScreenController _screenController;

        public PrepareMenuHandler([NotNull] IScreenController screenController)
        {
            _screenController = screenController ?? throw new ArgumentNullException(nameof(screenController));
        }
       
        public IRequest Handle()
        {
            return new SimpleRequestChain()
                .Add(new LoadSceneRequest(1))
                .Add(new ConditionalChainElement(() =>
                {
                    _screenController.Setup(); 
                    return true;
                }));
        }
    }
}
