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

        //[Reactive]
        public MediaElement MediaElement { get; set; }

        public ReactiveCommand<Unit, bool> CommandPlay { get; }

        [Reactive]
        public Uri VideoSource { get; internal set; }

        public VideoViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            this.Log().Warn("Something bad happened");

            VideoSource = new Uri("file:///E:/workspaces/antoniocaccamo/2019-06-10-FuoriCinema%20(Vigan%C3%B2).mp4");

            CommandPlay = ReactiveCommand.CreateFromTask<bool>(async () => await MediaElement.Play());
            CommandPlay.WhenAnyValue(x => x).Subscribe(x => Console.WriteLine($"x : {x}"));

            CommandPlay
                .ThrownExceptions.Subscribe(error => Console.Error.WriteLine($"error : {error}"))
                ;
        }

        public void handleMediaElement()
        {
            // MediaElement..MediaOpened += (sdr, evt) => { Console.WriteLine($"MediaOpened {evt.Info.Duration}"); };
            MediaElement.BufferingStarted += (sdr, evt) => { Console.WriteLine($"BufferingStarted"); };
            MediaElement.BufferingEnded += (sdr, evt) => { Console.WriteLine($"BufferingEnded"); };
            MediaElement.MediaEnded += (sdr, evt) => { Console.WriteLine($"MediaEnded"); };
            MediaElement.PositionChanged += (sdr, evt) => { Console.WriteLine($"PositionChanged {evt.Position}"); };
            MediaElement.MediaFailed += (sdr, evt) => { Console.WriteLine($"MediaFailed"); };
        }
    }
}