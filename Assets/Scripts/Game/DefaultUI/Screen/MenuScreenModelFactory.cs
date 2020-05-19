using SilentPartyGames.Game.State;

namespace SilentPartyGames.Game.UI
{
    public class MenuScreenModelFactory : IScreenModelFactory
    {
        private readonly IGameStateChanger _stateChanger;

        public MenuScreenModelFactory(IGameStateChanger stateChanger)
        {
            _stateChanger = stateChanger;
        }
        
        public IViewModel Create()
        {
            return new MenuScreenModel(_stateChanger);
        }
    }
}