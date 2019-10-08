using ReactiveUI;
using Serilog;
using Splat;
using Splat.Serilog;
using System.Reflection;
using System.Windows;

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
            var logger = new DebugLogger() { Level = LogLevel.Error };
            Locator.CurrentMutable.RegisterConstant(logger, typeof(Serilog.ILogger));

            Unosquare.FFME.Library.FFmpegDirectory = @"ffmpeg";
        }
    }
}