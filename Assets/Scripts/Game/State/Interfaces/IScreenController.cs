using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public interface IScreenController
    {
        void Setup();
        void Cleanup();

        IRequest Show();
        IRequest Hide();
    }

    public interface IScreenModelFactory
    {
        IViewModel Create();
    }
}