using System;
using JetBrains.Annotations;
using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public class EnterMenuHandler : IGameStateHandler
    {
        private readonly IScreenController _screenController;

        public EnterMenuHandler([NotNull] IScreenController screenController)
        {
            _screenController = screenController ?? throw new ArgumentNullException(nameof(screenController));
        }

        public IRequest Handle()
        {
            return new SimpleRequestChain()
                .Add(_screenController.Show());
        }
    }
}