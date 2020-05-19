using Tools.MonoBehaviourExt;
using UnityEngine;
using UnityEngine.UI;

namespace SilentPartyGames.Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class MenuScreenView : ScreenView<MenuScreenModel>
    {
        [SerializeField] private Button _levelButton;
        
        protected override void DeinitScreen(MenuScreenModel context)
        {
            _levelButton.SafeRemoveListener(OnExitClicked);
        }

        protected override void InitScreen(MenuScreenModel context)
        {
            _levelButton.SafeAddListener(OnExitClicked);
        }

        private void OnExitClicked()
        {
            TypedContext.ChangeState();
        }
    }
}