namespace AT.Player.RX
{
    using ReactiveUI;
    using System.Reactive.Disposables;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : ReactiveWindow<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();

            ViewModel = new MainViewModel();
            this.WhenActivated(disposables =>
            {
                // Bind the view model router to RoutedViewHost.Router property.
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoImage, x => x.GoImageButton)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoVideo, x => x.GoVideoButton)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoNuget, x => x.GoNugetButton)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.GoBack, x => x.GoBackButton)
                    .DisposeWith(disposables);

                this.WhenAnyValue(x => x.GoBackButton.IsMouseOver, x => x.ViewModel.SomeBoolValue,
                      (isMouseOver, boolValue) =>
                      {
                          if (isMouseOver)
                              return boolValue ? Brushes.Gray : Brushes.Blue;
                          else
                              return boolValue ? Brushes.Red : Brushes.Green;
                      })
                      .BindTo(this, view => view.GoBackButton.Background)
                      .DisposeWith(disposables);
            });
        }
    }
}