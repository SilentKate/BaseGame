using SilentPartyGames.Tools.Request;
using UnityEngine;

namespace SilentPartyGames.Game.UI
{
    public class CanvasSetupRequest :ConditionalRequest
    {
        public CanvasSetupRequest(GameObject target, bool hidden) : base(() => Setup(target, hidden))
        {
        }

        private static bool Setup(GameObject target, bool hidden)
        {
            var canvasGroup = target.GetComponent<CanvasGroup>();
            if (canvasGroup == null) return true;
            if (hidden)
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
            else
            {
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }

            return true;
        }
    }
}