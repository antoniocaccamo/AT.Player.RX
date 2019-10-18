namespace AT.Player.RX.Views
{
    using AT.Player.RX.ViewModels;
    using ReactiveUI;
    using System.Reactive.Disposables;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for ScreenListItemView.xaml
    /// </summary>
    public partial class ScreenListItemView : BaseScreenListView
    {
        public ScreenListItemView()
        {
            InitializeComponent();

            this.WhenActivated(disposableRegistration =>
            {
                // Our 4th parameter we convert from Url into a BitmapImage. This is an easy way of
                // doing value conversion using ReactiveUI binding.
                this.OneWayBind(ViewModel,
                    viewModel => viewModel.Size,
                    view => view.Size.Text
                )
                    .DisposeWith(disposableRegistration);
                this.OneWayBind(ViewModel,
                    viewModel => viewModel.Location,
                    view => view.Location.Text
                )
                    .DisposeWith(disposableRegistration);
            });
        }
    }
}