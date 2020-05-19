namespace SilentPartyGames.Tools.Request
{
    public class AlwaysSuccessRequest : Request
    {
        protected override void CompleteInternal()
        {
        }

        protected override void StartInternal()
        {
            Complete(true);
        }
    }
}