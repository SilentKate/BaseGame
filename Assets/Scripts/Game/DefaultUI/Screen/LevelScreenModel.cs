using SilentPartyGames.Game.State;

namespace SilentPartyGames.Game.UI
{
    public class LevelScreenModel : IScreenViewModel
    {
        private readonly IGameStateChanger _stateChanger;

        public LevelScreenModel(IGameStateChanger stateChanger)
        {
            _stateChanger = stateChanger;
        }

        public void Deinit()
        {
        }
        
        public void Init()
        {
        }

        public void ChangeState()
        {
            _stateChanger?.ChangeState();
        }
    }
}