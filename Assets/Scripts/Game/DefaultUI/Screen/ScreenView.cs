using SilentPartyGames.Game.DefaultUI.ContextView;
using SilentPartyGames.Game.State;
using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.UI
{
    public abstract class ScreenView<T> : MonoBehaviourContextView<T>, IScreenView where T : class, IScreenViewModel
    {
        protected override void OnContextDetached(T context)
        {
            DeinitScreen(context);
        }

        protected override void OnContextAttached(T context)
        {
            InitScreen(context);
        }

        protected abstract void DeinitScreen(T context);
        protected abstract void InitScreen(T context);
        
        public IRequest Show()
        {
            return new CanvasSetupRequest(gameObject, false);
        }

        public IRequest Hide()
        {
            return new CanvasSetupRequest(gameObject, true);
        }
    }
}