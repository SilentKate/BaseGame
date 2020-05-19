using UnityEngine.Events;
using UnityEngine.UI;

namespace Tools.MonoBehaviourExt
{
    public static class UIMonoBehaviourExt
    {
        public static void SafeAddListener(this Button button, UnityAction call)
        {
            if (button != null) button.onClick.AddListener(call);
        }
        
        public static void SafeRemoveListener(this Button button, UnityAction call)
        {
            if (button != null) button.onClick.RemoveListener(call);
        }
    }
}