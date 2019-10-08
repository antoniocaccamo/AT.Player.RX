namespace AT.Player.RX.ViewModel
{
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    using Splat;
    using System;

    public class ImageViewModel : ReactiveObject, IRoutableViewModel, IEnableLogger
    {
        public string UrlPathSegment => "image";

        public IScreen HostScreen { get; }

        [Reactive]
        public Uri IconUrl { get; internal set; }

        public ImageViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            this.Log().Warn("Something bad happened");

            IconUrl = new Uri("file:///E:/workspaces/antoniocaccamo/at-adv/html/weather/images/artlogo.png");

            this.WhenAnyValue(x => x.IconUrl)
                .Subscribe(x => Console.WriteLine(x))
            ;
        }
    }
}