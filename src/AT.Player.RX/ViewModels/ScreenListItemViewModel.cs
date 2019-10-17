/// <summary>
///
/// </summary>
namespace AT.Player.RX.ViewModels
{
    using ReactiveUI;

    public class ScreenListItemViewModel : ReactiveObject
    {
        private readonly Model.Configuration.Screen _screen;

        public ScreenListItemViewModel(Model.Configuration.Screen screen)
        {
            _screen = screen;
        }

        public Model.Configuration.Size Size => _screen.Size;

        public Model.Configuration.Location Location => _screen.Location;
    }
}