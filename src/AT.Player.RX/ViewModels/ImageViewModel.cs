namespace AT.Player.RX.ViewModels
{
    using AT.Player.RX.Views;
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

            string imageUri = Locator.Current.GetService(typeof(ImageView)) as string;

            this.Log().Warn($"image uri : {imageUri}");

            IconUrl = new Uri(//"file:///E:/workspaces/antoniocaccamo/at-adv/html/weather/images/artlogo.png"
                    imageUri
                );

            this.WhenAnyValue(x => x.IconUrl)
                .Subscribe(x => this.Log().Info($"loaded image : {x}"))
            ;
        }
    }
}