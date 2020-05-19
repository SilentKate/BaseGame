using SilentPartyGames.Tools.Request;

namespace SilentPartyGames.Game.State
{
    public abstract class ScreenController : IScreenController
    {
        private readonly IScreenView _screenView;
        private readonly IScreenModelFactory _screenModelFactory;

        protected ScreenController(
            IScreenModelFactory screenModelFactory, 
            IScreenView screenView)
        {
            _screenModelFactory = screenModelFactory;
            _screenView = screenView;
        }
        
        public void Setup()
        {
            var model = _screenModelFactory.Create();
            _screenView.Context = model;
        }

        public void Cleanup()
        {
            _screenView.Context = null;
        }

        public virtual IRequest Show()
        {
            return _screenView.Show();
        }

        public virtual IRequest Hide()
        {
            return _screenView.Hide();
        }
    }
}