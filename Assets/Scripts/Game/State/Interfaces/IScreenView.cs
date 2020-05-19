using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public interface IScreenView : IView
    {
        IRequest Show();
        IRequest Hide();
    }
    
    public interface IScreenViewModel : IViewModel, IGameStateChanger
    {
    }
}
