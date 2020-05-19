using SilentPartyGames.Game.State;

namespace SilentPartyGames.Game.UI
{
    public class LevelScreenModelFactory : IScreenModelFactory
    {
        private readonly IGameStateChanger _stateChanger;

        public LevelScreenModelFactory(IGameStateChanger stateChanger)
        {
            _stateChanger = stateChanger;
        }
        
        public IViewModel Create()
        {
            return new LevelScreenModel(_stateChanger);
        }
    }
}