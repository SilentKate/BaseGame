namespace SilentPartyGames.Game.State
{
    public interface IGameFlowContainer
    {
        GameFlowState CurrentState { get; set; } 
        GameFlowState NextState { get; }
    }
}


