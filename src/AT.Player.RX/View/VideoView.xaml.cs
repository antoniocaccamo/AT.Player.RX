namespace AT.Player.RX.View
{
    using AT.Player.RX.ViewModel;
    using ReactiveUI;
    using System;
    using System.Reactive.Disposables;

    /// <summary>
    /// Interaction logic for Video.xaml
    /// </summary>
    public partial class VideoView : ReactiveUserControl<VideoViewModel>
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
                //       viewModel => viewModel.mediaElement,
                //       view => view.mediaElement)
                //   .DisposeWith(disposableRegistration);

                //this.BindCommand(ViewModel,
                //        viewModel => viewModel.CommandPlay,
                //        view => view.PlayButton
                //).DisposeWith(disposableRegistration);
            });
        }

        #endregion Public Constructors
    }
}