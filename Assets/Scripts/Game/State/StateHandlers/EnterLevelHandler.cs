using System;
using JetBrains.Annotations;
using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public class EnterLevelHandler : IGameStateHandler
    {
        private readonly IScreenController _screenController;
        private readonly IRoundController _roundController;

        public EnterLevelHandler(
            [NotNull] IScreenController screenController,
            [NotNull] IRoundController roundController)
        {
            _screenController = screenController ?? throw new ArgumentNullException(nameof(screenController));
            _roundController = roundController ?? throw new ArgumentNullException(nameof(roundController));
        }

        public IRequest Handle()
        {
            return new SimpleRequestChain()
                .Add(_screenController.Show())
                .Add(new ConditionalChainElement(
                    () =>
                    {
                        _roundController.StartRound();
                        return true;
                    }));
        }
    }
}
