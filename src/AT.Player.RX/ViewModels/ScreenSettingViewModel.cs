namespace AT.Player.RX.ViewModels
{
    using AT.Player.RX.Model.Configuration;
    using ReactiveUI;
    using Splat;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ScreenSettingViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Public Fields

        public ObservableAsPropertyHelper<Location> _location;
        public ObservableAsPropertyHelper<Size> _size;

        #endregion Public Fields

        #region Private Fields

        private readonly Screen _screen;

        #endregion Private Fields

        #region Public Constructors

        public ScreenSettingViewModel(Screen _screen, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            this._screen = _screen;

            _size = this.WhenAnyValue(x => x._screen.Size)
                .ToProperty(this, x => x.Size);

            _location = this.WhenAnyValue(x => x._screen.Location)
                .ToProperty(this, x => x.Location);
        }

        #endregion Public Constructors

        #region Public Properties

        public IScreen HostScreen { get; }
        public Location Location => _location.Value;
        public Screen Screen => _screen;
        public Size Size { get { return _size.Value; } }
        public string UrlPathSegment => "screenSetting";

        #endregion Public Properties
    }
}