using AT.Player.RX.Views;
using ReactiveUI;
using Serilog;
using Splat;
using System;
using System.Reflection;
using System.Windows;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AT.Player.RX
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // A helper method that will register all classes that derive off IViewFor into our
            // dependency injection container. ReactiveUI uses Splat for it's dependency injection by
            // default, but you can override this if you like.
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

            // Register the SimpleViewLocator.
            Locator.CurrentMutable.RegisterLazySingleton(() => new SimpleViewLocator(), typeof(IViewLocator));

            // I only want to hear about errors
            var logger = //new DebugLogger() { Level = LogLevel.Error }
                new LoggerConfiguration()
                    // .Enrich.With(new ThreadIdEnricher())
                    .WriteTo.Console(
                        outputTemplate: "{Timestamp:HH:mm} [{Level}]  {Message}{NewLine}{Exception}")
                    .CreateLogger();
            ;
            Locator.CurrentMutable.RegisterConstant(logger, typeof(Serilog.ILogger));

            Locator.CurrentMutable.RegisterConstant(
                //"file:///E:/workspaces/antoniocaccamo/2019-06-10-FuoriCinema%20(Vigan%C3%B2).mp4",
                "C:\\Program Files\\WindowsApps\\Microsoft.Windows.Photos_2019.19071.17920.0_x64__8wekyb3d8bbwe\\AppCS\\Assets\\NewsControl_WhatsNewMedia\\620x252_favorites.mp4",
                typeof(VideoView)
            );

            Locator.CurrentMutable.RegisterConstant(
               // "file:///E:/workspaces/antoniocaccamo/at-adv/html/weather/images/artlogo.png",
               "C:\\Windows\\Web\\Wallpaper\\HP\\green_leaves.jpg",
                 typeof(ImageView)
            );

            Unosquare.FFME.Library.FFmpegDirectory = @"ffmpeg";

            var deserializer = new DeserializerBuilder()
                                        .WithNamingConvention(new CamelCaseNamingConvention())
                                        .IgnoreUnmatchedProperties()
                                        .Build();
            var configuration = deserializer.Deserialize<Model.Configuration.Configuration>(System.IO.File.ReadAllText(@"prefs.yml"));

            Console.WriteLine($"configuration : ${configuration}");

            Locator.CurrentMutable.RegisterConstant(configuration, typeof(Model.Configuration.Configuration));
        }
    }
}