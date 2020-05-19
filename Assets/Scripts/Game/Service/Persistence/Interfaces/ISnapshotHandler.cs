namespace SilentPartyGames.Game.Service
{
    public interface ISnapshotHandler
    {
        void ApplySnapshot(string value);
        string TakeSnapshot();
    }
}
