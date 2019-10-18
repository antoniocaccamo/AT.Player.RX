namespace AT.Player.RX
{
    using AT.Player.RX.Model.Configuration;
    using ReactiveUI;
    using Splat;
    using System;
    using System.Reactive.Disposables;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : ReactiveWindow<MainViewModel>
    {
        private static readonly Serilog.ILogger logger = Locator.Current.GetService(typeof(Serilog.ILogger)) as Serilog.ILogger;

        #region Public Constructors

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

                this.Bind(
                    ViewModel,
                    vm => vm.Configuration.Size.Width,
                    v => v.Width
                ).DisposeWith(disposables);

                this.Bind(
                    ViewModel,
                    vm => vm.Configuration.Size.Height,
                    v => v.Height
                ).DisposeWith(disposables);

                this.Bind(
                    ViewModel,
                    vm => vm.Configuration.Location.Top,
                    v => v.Top
                ).DisposeWith(disposables);

                this.Bind(
                    ViewModel,
                    vm => vm.Configuration.Location.Left,
                    v => v.Left
                ).DisposeWith(disposables);

                this.OneWayBind(
                    ViewModel,
                    vm => vm.Screens,
                    v => v.lv.ItemsSource
                ).DisposeWith(disposables);

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

                this.Events()
                    .SizeChanged
                    .Subscribe(evt =>
                        {
                            logger.Warning("SizeChanged : old {0}, new {1}", evt.PreviousSize, evt.NewSize);
                            // ViewModel.Configuration.Size = new Model.Configuration.Size(evt.NewSize);
                        }
                    );
                this.Events()
                    .LocationChanged
                    .Subscribe(evt =>
                    {
                        logger.Warning("LocationChanged : evt {0}", evt);
                        // ViewModel.Configuration.Size = new Model.Configuration.Size(evt.NewSize);
                    }
                    );
            });
        }

        #endregion Public Constructors
    }
}