/// <summary>
///
/// </summary>
namespace AT.Player.RX.ViewModels
{
    using AT.Player.RX.Views;
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    using Splat;
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Windows;

    //using System.Windows.Controls;

    using Unosquare.FFME;

    public class VideoViewModel : ReactiveObject, IRoutableViewModel, IEnableLogger
    {
        private static readonly Serilog.ILogger logger = Locator.Current.GetService(typeof(Serilog.ILogger)) as Serilog.ILogger;

        #region Public Constructors

        public VideoViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            string videoUri = Locator.Current.GetService(typeof(VideoView)) as string;
            bool exists = System.IO.File.Exists(videoUri);
            logger.Information("video uri : {videoUri} exists : {exists}", videoUri, exists);

            VideoSource = new Uri(videoUri);
        }

        #endregion Public Constructors

        #region Public Properties

        public IScreen HostScreen { get; }

        //[Reactive]
        public MediaElement MediaElement { get; set; }

        public string UrlPathSegment => "video";

        [Reactive]
        public Uri VideoSource { get; internal set; }

        #endregion Public Properties

        #region Public Methods

        public void HandleMediaElement()
        {
            MediaElement.BufferingStarted += (sdr, evt) => { logger.Information($"BufferingStarted"); };
            MediaElement.BufferingEnded += (sdr, evt) => { logger.Information($"BufferingEnded"); };

            MediaElement.MediaOpened += (sdr, evt) => logger.Information($"MediaOpened - Duration : {evt.Info.Duration}");

            MediaElement.MediaEnded += async (sdr, evt) => { logger.Information($"MediaEnded"); await MediaElement.Stop(); };
            MediaElement.MediaFailed += (sdr, evt) =>
            {
                logger.Information("MediaFailed : {0}",
MessageBox.Show(
evt.ErrorException.Message));
            };

            MediaElement.Loaded += (sdr, evt) => { logger.Information($"Loaded  {evt}"); };
            MediaElement.PositionChanged += (sdr, evt) => { logger.Information($"PositionChanged {evt.Position}"); };
        }

        #endregion Public Methods
    }
}