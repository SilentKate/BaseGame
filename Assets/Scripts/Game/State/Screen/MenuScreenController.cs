namespace SilentPartyGames.Game.State
{
    public class MenuScreenController : ScreenController
    {
        public MenuScreenController(
            IScreenModelFactory screenModelFactory, 
            IScreenView screenView) : base(screenModelFactory, screenView)
        {
        }
    }
}
