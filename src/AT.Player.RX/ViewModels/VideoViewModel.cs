namespace AT.Player.RX.ViewModels
{
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    using Splat;
    using System;
    using System.Reactive;
    using Unosquare.FFME;

    public class VideoViewModel : ReactiveObject, IRoutableViewModel, IEnableLogger
    {
        public string UrlPathSegment => "video";

        public IScreen HostScreen { get; }

        //public ReactiveCommand<Unit, IRoutableViewModel> CommandPlay { get; }

        [Reactive]
        public MediaElement MediaElement { get; set; }

        public ReactiveCommand<Unit, bool> CommandPlay { get; }

        [Reactive]
        public Uri VideoSource { get; internal set; }

        public VideoViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            this.Log().Warn("Something bad happened");

            MediaElement = new MediaElement();

            VideoSource = new Uri(Locator.Current -);

            CommandPlay = ReactiveCommand.CreateFromTask(async () => await MediaElement.Play());
            this.WhenAnyValue(x => x.MediaElement)
                .Subscribe(x => this.Log().Info($"x.Source : {x.Source}"));

            this.WhenAnyValue(x => x.VideoSource)
                .Subscribe(x => MediaElement.Source = x);

            CommandPlay
                .ThrownExceptions.Subscribe(error => this.Log().Error($"error : {error}"))
                ;

            handleMediaElement();
        }

        public void handleMediaElement()
        {
            MediaElement.MediaOpened += (sdr, evt) => { this.Log().Info($"MediaOpened {evt.Info.Duration}"); };
            MediaElement.BufferingStarted += (sdr, evt) => { this.Log().Info($"BufferingStarted"); };
            MediaElement.BufferingEnded += (sdr, evt) => { this.Log().Info($"BufferingEnded"); };
            MediaElement.MediaEnded += (sdr, evt) => { this.Log().Info($"MediaEnded"); };
            MediaElement.PositionChanged += (sdr, evt) => { this.Log().Info($"PositionChanged {evt.Position}"); };
            MediaElement.MediaFailed += (sdr, evt) => { this.Log().Info($"MediaFailed"); };
        }
    }
}