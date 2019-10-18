using AT.Player.RX.Model.Configuration;
using AT.Player.RX.Views;
using ReactiveUI;
using Serilog;
using Splat;
using Splat.Serilog;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AT.Player.RX
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IEnableLogger
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
                    .Enrich.WithThreadName()
                    .Enrich.WithThreadId()
                    .Enrich.FromLogContext()
                    .WriteTo.Console(
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]  {Properties} - {Message:lj} {NewLine}{Exception}"
                    )
                    .CreateLogger();
            ;

            Locator.CurrentMutable.UseSerilogFullLogger();
            Locator.CurrentMutable.RegisterConstant(logger, typeof(Serilog.ILogger));

            var deserializer = new DeserializerBuilder()
                                        .WithNamingConvention(new CamelCaseNamingConvention())
                                        .IgnoreUnmatchedProperties()
                                        .Build();
            string yaml = System.IO.File.ReadAllText(@"prefs.yml");
            logger.Information($"yaml : ${yaml}");
            var configuration = deserializer.Deserialize<Configuration>(yaml);

            logger.Information($"configuration : ${configuration}");

            Unosquare.FFME.Library.FFmpegDirectory = configuration.Ffmpeg.Path;
            Unosquare.FFME.Library.EnableWpfMultiThreadedVideo = true;

            logger.Information("Unosquare.FFME.Library.FFmpegDirectory : {0}", Unosquare.FFME.Library.FFmpegDirectory);

            Locator.CurrentMutable.RegisterConstant(configuration, typeof(Model.Configuration.Configuration));

            Locator.CurrentMutable.RegisterConstant(
                configuration.Dummy.Video,
                typeof(VideoView)
            );

            Locator.CurrentMutable.RegisterConstant(
               configuration.Dummy.Image,
                 typeof(ImageView)
            );
        }
    }
}