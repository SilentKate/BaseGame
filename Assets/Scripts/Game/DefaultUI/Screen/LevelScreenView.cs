using Tools.MonoBehaviourExt;
using UnityEngine;
using UnityEngine.UI;

namespace SilentPartyGames.Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LevelScreenView : ScreenView<LevelScreenModel>
    {
        [SerializeField] private Button _exitButton;

        protected override void DeinitScreen(LevelScreenModel context)
        {
            _exitButton.SafeRemoveListener(OnExitClicked);
        }

        protected override void InitScreen(LevelScreenModel context)
        {
            _exitButton.SafeAddListener(OnExitClicked);
        }

        private void OnExitClicked()
        {
            TypedContext.ChangeState();
        }
    }
}