namespace SilentPartyGames.Game.State
{
    public class LevelScreenController : ScreenController
    {
        public LevelScreenController(
            IScreenModelFactory screenModelFactory, 
            IScreenView screenView) : base(screenModelFactory, screenView)
        {
        }
    }
}