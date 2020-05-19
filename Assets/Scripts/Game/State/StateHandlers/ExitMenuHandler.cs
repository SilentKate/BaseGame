using System;
using JetBrains.Annotations;
using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public class ExitMenuHandler : IGameStateHandler
    {
        private readonly IScreenController _screenController;

        public ExitMenuHandler([NotNull] IScreenController screenController)
        {
            _screenController = screenController ?? throw new ArgumentNullException(nameof(screenController));
        }

        public IRequest Handle()
        {
            return new SimpleRequestChain()
                .Add(_screenController.Hide())
                .Add(new ConditionalChainElement(() =>
                {
                    _screenController.Cleanup(); 
                    return true;
                }));
        }
    }
} 