using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public class AlwaysSuccessStateHandler : IGameStateHandler
    {
        public IRequest Handle()
        {
            return new AlwaysSuccessRequest();
        }
    }
}
