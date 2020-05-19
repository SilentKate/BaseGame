using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public interface IGameStateHandler
    {
        IRequest Handle();
    }
}
