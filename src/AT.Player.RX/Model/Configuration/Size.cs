/// <summary>
///
/// </summary>
namespace AT.Player.RX.Model.Configuration
{
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    using Splat;
    using System;

    public class Size : ReactiveObject
    {
        private static readonly Serilog.ILogger logger = Locator.Current.GetService(typeof(Serilog.ILogger)) as Serilog.ILogger;

        public Size()
        {
            this.WhenAnyValue(x => x.Width)
                .Subscribe(l => logger.Information("Width changed : {l}", l))
              ;

            this.WhenAnyValue(x => x.Height)
                .Subscribe(l => logger.Information("Height changed : {l}", l))
              ; ;
        }

        public Size(System.Windows.Size _size) : base()
        {
            Width = _size.Width;
            Height = _size.Height;
        }

        //public Size(double w, double h)
        //{
        //    Width = w;
        //    Height = h;
        //}

        #region Public Properties

        [Reactive]
        public double Width { get; set; }

        [Reactive]
        public double Height { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $"Width [{Width}] Height [{Height}]";
        }

        #endregion Public Methods
    }
}