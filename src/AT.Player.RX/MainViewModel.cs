using AT.Player.RX.ViewModel;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AT.Player.RX
{
    public class MainViewModel : ReactiveObject, IScreen
    {
        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router { get; }

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoImage { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoVideo { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoNuget { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, Unit> GoBack { get; }

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
        }
    }
}