namespace SilentPartyGames.Game.State
{
    public interface IView
    {
        object Context { get; set; }
    }
    
    public interface IView<T> : IView where T : class, IViewModel
    {
        T TypedContext { get; }
    }
}