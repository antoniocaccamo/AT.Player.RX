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

    public class ImageViewModel : ReactiveObject, IRoutableViewModel
    {
        private static readonly Serilog.ILogger logger = Locator.Current.GetService(typeof(Serilog.ILogger)) as Serilog.ILogger;

        public string UrlPathSegment => "image";

        public IScreen HostScreen { get; }

        [Reactive]
        public Uri IconUrl { get; internal set; }

        public ImageViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            string imageUri = Locator.Current.GetService(typeof(ImageView)) as string;

            logger.Warning("image uri : {imageUri}", imageUri);

            IconUrl = new Uri(imageUri);

            this.WhenAnyValue(x => x.IconUrl)
                .Subscribe(x => logger.Information("IconUrl changed image : {x}", x))
            ;
        }
    }
}