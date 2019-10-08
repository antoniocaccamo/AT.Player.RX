namespace AT.Player.RX.ViewModel
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
        //public MediaElement mediaElement { get; set; }

        public ReactiveCommand<Unit, bool> CommandPlay { get; }

        [Reactive]
        public Uri VideoSource { get; internal set; }

        public VideoViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            this.Log().Warn("Something bad happened");

            VideoSource = new Uri("file:///E:/workspaces/antoniocaccamo/2019-06-10-FuoriCinema%20(Vigan%C3%B2).mp4");

            //CommandPlay = ReactiveCommand.CreateFromTask<bool>(async () => await mediaElement.Play());

            //mediaElement.MediaOpened += (sdr, evt) => { Console.WriteLine($"MediaOpened {evt.Info.Duration}"); };
            //mediaElement.BufferingStarted += (sdr, evt) => { Console.WriteLine($"BufferingStarted"); };
            //mediaElement.BufferingEnded += (sdr, evt) => { Console.WriteLine($"BufferingEnded"); };
            //mediaElement.MediaEnded += (sdr, evt) => { Console.WriteLine($"MediaEnded"); };
            //mediaElement.PositionChanged += (sdr, evt) => { Console.WriteLine($"PositionChanged {evt.Position}"); };
            //mediaElement.MediaFailed += (sdr, evt) => { Console.WriteLine($"MediaFailed"); };
        }
    }
}