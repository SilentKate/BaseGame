using SilentPartyGames.Game.State;

namespace SilentPartyGames.Game.UI
{
    public class MenuScreenModel : IScreenViewModel
    {
        private readonly IGameStateChanger _stateChanger;

        public MenuScreenModel(IGameStateChanger stateChanger)
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