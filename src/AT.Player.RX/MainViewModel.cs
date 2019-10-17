namespace AT.Player.RX
{
    using AT.Player.RX.Model.Configuration;
    using AT.Player.RX.ViewModels;
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    using Splat;
    using System.Collections.Generic;
    using System.Reactive;
    using System.Reactive.Linq;

    public class MainViewModel : ReactiveObject, IScreen
    {
        private static readonly ILogger logger = Locator.Current.GetService(typeof(Serilog.ILogger)) as ILogger;

        private readonly ObservableAsPropertyHelper<IEnumerable<ScreenListItemViewModel>> _screens;

        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router { get; }

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoImage { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoVideo { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoNuget { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, Unit> GoBack { get; }

        [Reactive]
        public bool SomeBoolValue { get; internal set; }

        [Reactive]
        public Configuration Configuration { get; internal set; }

        public IEnumerable<ScreenListItemViewModel> Screens => _screens.Value;

        public MainViewModel()
        {
            // Initialize the Router.
            Router = new RoutingState();

            //
            GoImage = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new ImageViewModel()));

            GoVideo = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new VideoViewModel()));

            GoNuget = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new NugetViewModel()));

            // You can also ask the router to go back.
            GoBack = Router.NavigateBack;

            Router.Navigate.Execute(new ImageViewModel());

            SomeBoolValue = false;

            Configuration = Locator.Current.GetService(typeof(Configuration)) as Configuration;

            //ObservableAsPropertyHelper<ScreenListItemViewModel>.
            //_searchResults = this
            //   .WhenAnyValue(x => x.Configuration.Screens.To())
            //   .Select(x => new ScreenListItemViewModel(x.First()))
            //    .ToProperty(this, x => x.);
            //;
            //;
        }
    }
}