using System;
using JetBrains.Annotations;
using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public class PrepareLevelHandler : IGameStateHandler
    {
        private readonly IScreenController _screenController;
        private readonly IRoundController _roundController;

        public PrepareLevelHandler(
            [NotNull] IScreenController screenController,
            [NotNull] IRoundController roundController)
        {
            _screenController = screenController ?? throw new ArgumentNullException(nameof(screenController));
            _roundController = roundController ?? throw new ArgumentNullException(nameof(roundController));
        }
        
        public IRequest Handle()
        {
            return new SimpleRequestChain()
                .Add(new LoadSceneRequest(2))
                .Add(new ConditionalChainElement(() =>
                {
                    _screenController.Setup();
                    _roundController.Setup();
                    return true;
                }));
        }
    }
}
