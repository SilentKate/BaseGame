namespace SilentPartyGames.Game.State
{
    public interface IRoundController
    {
        void Setup();
        void Cleanup();
        void StartRound();
    }

    public class DummyRoundController : IRoundController
    {
        public void Setup()
        {
        }

        public void Cleanup()
        {
        }

        public void StartRound()
        {
        }
    }
}
