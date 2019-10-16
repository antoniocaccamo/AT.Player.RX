namespace AT.Player.RX.Views
{
    using AT.Player.RX.ViewModels;
    using ReactiveUI;
    using Splat;
    using System;
    using System.Reactive.Disposables;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for Video.xaml
    /// </summary>

    public partial class VideoView : BaseVideoView, IEnableLogger
    {
        #region Public Constructors

        public VideoView()
        {
            InitializeComponent();

            ViewModel = ViewModel ?? new VideoViewModel();

            ViewModel.MediaElement = me;

            ViewModel.HandleMediaElement();

            this.WhenActivated(disposableRegistration =>
            {
                this.Bind(ViewModel,
                       viewModel => viewModel.VideoSource,
                       view => view.me.Source)
                   .DisposeWith(disposableRegistration);

                //this.OneWayBind(ViewModel,
                //       viewModel => viewModel.MediaElement,
                //       view => view.grid,
                //       grid.Children.Add(ViewModel.MediaElement)
                //   )
                //   .DisposeWith(disposableRegistration);

                //this.BindCommand(ViewModel,
                //        viewModel => viewModel.CommandPlay,
                //        view => view.PlayButton
                //).DisposeWith(disposableRegistration);

                //this.PlayButton.Events()
                //    .MouseDoubleClick
                //    .Subscribe(
                //          evt => me.Play()
                //        , ex => System.Console.WriteLine($"exception :{ex}")
                //        , () => System.Console.WriteLine($"done")
                //    );

                //this.me.Events()
                //    .MediaOpened
                //    .Subscribe( //new CountingButtonObserver()
                //        evt =>
                //        {
                //            System.Console.WriteLine($"event MediaOpened :{evt}, me.Source : {me.Source}");
                //            //me.Play();
                //        },
                //        ex => System.Console.WriteLine($"exception :{ex}"),
                //        () => System.Console.WriteLine($"done")
                //    )
                //    .DisposeWith(disposableRegistration);

                //this.me.Events()
                //   .MediaEnded
                //   .Subscribe( //new CountingButtonObserver()
                //       evt => System.Console.WriteLine($"event MediaEnded :{evt}, me.Source : {me.Source}"),
                //       ex => System.Console.WriteLine($"exception :{ex}"),
                //       () => System.Console.WriteLine($"done")
                //   )
                //   .DisposeWith(disposableRegistration);

                //this.me.Events()
                //   .MediaFailed
                //   .Subscribe( //new CountingButtonObserver()
                //       evt =>
                //       {
                //           System.Console.WriteLine($"event MediaFailed:{evt}, me.Source : {me.Source}");
                //           //      PlayButton.IsEnabled = false;
                //       },
                //       ex => System.Console.WriteLine($"exception :{ex}"),
                //       () => System.Console.WriteLine($"done")
                //   )
                //   .DisposeWith(disposableRegistration);
            });
        }

        #endregion Public Constructors

        private async System.Threading.Tasks.Task PlayButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            this.Log().Info("PlayButton_ClickAsync...");
            await me.Play();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Log().Info("PlayButton_Click...");
            // me.Position = TimeSpan.Zero;
            me.Play();
            //_ = new Action(() => PlayButton_ClickAsync(sender, e));
        }
    }

    //public class CountingButtonObserver : IObserver<RoutedEventArgs>
    //{
    //    private int _count = 0;
    //    public Button Button { get; set; }

    //    public void OnNext(RoutedEventArgs value)
    //    {
    //        System.Console.WriteLine($"event :{value}");
    //    }

    //    public void OnError(Exception exception)
    //    {
    //    }

    //    public void OnCompleted()
    //    {
    //    }
    //}
}