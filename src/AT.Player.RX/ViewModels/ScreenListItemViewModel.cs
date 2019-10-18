/// <summary>
///
/// </summary>
namespace AT.Player.RX.ViewModels
{
    using AT.Player.RX.Model.Configuration;
    using ReactiveUI;

    public class ScreenListItemViewModel : ReactiveObject
    {
        #region Public Fields

        public ObservableAsPropertyHelper<Location> _location;
        public ObservableAsPropertyHelper<Size> _size;

        #endregion Public Fields

        #region Private Fields

        private readonly Screen _screen;

        #endregion Private Fields

        #region Public Constructors

        public ScreenListItemViewModel(Screen screen)
        {
            _screen = screen;

            _size = this.WhenAnyValue(x => x._screen.Size)
                .ToProperty(this, x => x.Size);

            _location = this.WhenAnyValue(x => x._screen.Location)
                .ToProperty(this, x => x.Location);

            //this.WhenAnyValue(x => x._screen.Size.Width)
            //    .ToProperty(this, x => x.Size.Width);

            //this.WhenAnyValue(x => x._screen.Size.Height)
            //    .ToProperty(this, x => x.Size.Height);
        }

        #endregion Public Constructors

        #region Public Properties

        public Location Location => _location.Value;
        public Screen Screen => _screen;
        public Size Size { get { return _size.Value; } }

        #endregion Public Properties
    }
}