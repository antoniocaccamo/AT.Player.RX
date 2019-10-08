namespace AT.Player.RX.Views
{
    using AT.Player.RX.ViewModels;
    using ReactiveUI;
    using System.Reactive.Disposables;

    /// <summary>
    /// Interaction logic for Video.xaml
    /// </summary>

    public partial class VideoView : BaseVideoView
    {
        #region Public Constructors

        public VideoView()
        {
            InitializeComponent();

            ViewModel = ViewModel ?? new VideoViewModel();

            this.WhenActivated(disposableRegistration =>
            {
                this.Bind(ViewModel,
                       viewModel => viewModel.VideoSource,
                       view => view.mediaElement.Source)
                   .DisposeWith(disposableRegistration);

                //this.Bind(ViewModel,
                //       viewModel => viewModel.MediaElement,
                //       view => view.mediaElement)
                //   .DisposeWith(disposableRegistration);

                this.BindCommand(ViewModel,
                        viewModel => viewModel.CommandPlay,
                        view => view.PlayButton
                ).DisposeWith(disposableRegistration);
            });
            ViewModel.MediaElement = mediaElement;
            ViewModel.handleMediaElement();
        }

        #endregion Public Constructors
    }
}