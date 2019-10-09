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
    using System.Windows.Controls;

    public class VideoViewModel : ReactiveObject, IRoutableViewModel, IEnableLogger
    {
        #region Public Constructors

        public VideoViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            string videoUri = Locator.Current.GetService(typeof(VideoView)) as string;

            this.Log().Warn($"video uri : {videoUri}");

            VideoSource = new Uri(videoUri);

            //CommandPlay = ReactiveCommand.CreateFromTask(
            //    () => new Task<bool>(
            //                () =>
            //                {
            //                    MediaElement.Play();
            //                    return true;
            //                }
            //          )
            //);
            this.WhenAnyValue(x => x.MediaElement)
                .Subscribe(x => this.Log().Info($"x.Source : {x.Source}"));

            this.WhenAnyValue(x => x.VideoSource)
                .Subscribe(x => MediaElement.Source = x);

            //CommandPlay
            //    .ThrownExceptions.Subscribe(error => this.Log().Error($"error : {error}"))
            //    ;

            HandleMediaElement();
        }

        #endregion Public Constructors

        #region Public Properties

        //public ReactiveCommand<Unit, bool> CommandPlay { get; }
        public IScreen HostScreen { get; }

        [Reactive]
        public MediaElement MediaElement { get; set; }

        public string UrlPathSegment => "video";

        //public ReactiveCommand<Unit, IRoutableViewModel> CommandPlay { get; }
        [Reactive]
        public Uri VideoSource { get; internal set; }

        #endregion Public Properties

        #region Public Methods

        public void HandleMediaElement()
        {
            MediaElement.MediaOpened += (sdr, evt) => { this.Log().Info($"MediaOpened {evt}"); };
            MediaElement.BufferingStarted += (sdr, evt) => { this.Log().Info($"BufferingStarted"); };
            MediaElement.BufferingEnded += (sdr, evt) => { this.Log().Info($"BufferingEnded"); };
            MediaElement.MediaEnded += (sdr, evt) => { this.Log().Info($"MediaEnded"); };
            //MediaElement.  += (sdr, evt) => { this.Log().Info($"PositionChanged {evt.Position}"); };
            MediaElement.MediaFailed += (sdr, evt) => { this.Log().Info($"MediaFailed"); };
        }

        #endregion Public Methods
    }
}