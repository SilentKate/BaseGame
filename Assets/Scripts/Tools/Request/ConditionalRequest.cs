using System;

namespace SilentPartyGames.Tools.Request
{
    public class ConditionalRequest : Request
    {
        private readonly Func<bool> _predicate;

        public ConditionalRequest(Func<bool> predicate)
        {
            _predicate = predicate;
        }
        
        protected override void CompleteInternal()
        {
        }

        protected override void StartInternal()
        {
            Complete(_predicate.Invoke());
        }
    }
}