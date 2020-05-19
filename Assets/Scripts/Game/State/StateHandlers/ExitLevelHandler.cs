using System;
using JetBrains.Annotations;
using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public class ExitLevelHandler : IGameStateHandler
    {
        private readonly IScreenController _screenController;
        private readonly IRoundController _roundController;

        public ExitLevelHandler(
            [NotNull] IScreenController screenController,
            [NotNull] IRoundController roundController)
        {
            _screenController = screenController ?? throw new ArgumentNullException(nameof(screenController));
            _roundController = roundController ?? throw new ArgumentNullException(nameof(roundController));
        }
    
        public IRequest Handle()
        {
            return new SimpleRequestChain()
                .Add(_screenController.Hide())
                .Add(new ConditionalChainElement(() =>
                {
                    _roundController.Cleanup();
                    _screenController.Cleanup(); 
                    return true;
                }));
        }
    }
}