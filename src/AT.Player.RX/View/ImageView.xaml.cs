namespace AT.Player.RX.View
{
    using AT.Player.RX.ViewModel;
    using ReactiveUI;
    using System.Reactive.Disposables;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for ImageView.xaml
    /// </summary>
    public partial class ImageView : ReactiveUserControl<ImageViewModel>
    {
        public ImageView()
        {
            InitializeComponent();
            ViewModel = ViewModel ?? new ImageViewModel();

            this.WhenActivated(disposableRegistration =>

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.IconUrl,
                    view => view.image.Source,
                    url => url == null ? null : new BitmapImage(url))
                .DisposeWith(disposableRegistration)
            );
        }
    }
}