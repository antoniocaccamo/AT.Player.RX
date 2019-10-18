namespace AT.Player.RX.Views
{
    using AT.Player.RX.ViewModels;
    using ReactiveUI;
    using Splat;
    using System;
    using System.Reactive.Disposables;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for Video.xaml
    /// </summary>

    public partial class VideoView : BaseVideoView, IEnableLogger
    {
        #region Public Constructors

        public VideoView()
        {
            InitializeComponent();

            ViewModel = ViewModel ?? new VideoViewModel();

            ViewModel.MediaElement = me;

            ViewModel.HandleMediaElement();

            this.WhenActivated(disposableRegistration =>
            {
                this.Bind(ViewModel,
                       viewModel => viewModel.VideoSource,
                       view => view.me.Source)
                   .DisposeWith(disposableRegistration);
            });
        }

        #endregion Public Constructors

        //private async System.Threading.Tasks.Task PlayButton_ClickAsync(object sender, RoutedEventArgs e)
        //{
        //    this.Log().Info("PlayButton_ClickAsync...");
        //     me.Play();
        //}

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Log().Info("PlayButton_Click...");

            new Task(() => me.Play()).Start();
        }
    }
}