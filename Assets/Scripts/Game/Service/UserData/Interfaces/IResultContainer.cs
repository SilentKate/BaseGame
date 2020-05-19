using System.Collections.Generic;

namespace SilentPartyGames.Game.Service
{
     public interface IResultContainer
     {
          void AddResult(Result result);
          IEnumerable<Result> GetResults();
     }
}
