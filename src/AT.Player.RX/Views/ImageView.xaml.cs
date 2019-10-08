namespace AT.Player.RX.Views
{
    using AT.Player.RX.ViewModels;
    using ReactiveUI;
    using System.Reactive.Disposables;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for ImageView.xaml
    /// </summary>
    public partial class ImageView : BaseImageView
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