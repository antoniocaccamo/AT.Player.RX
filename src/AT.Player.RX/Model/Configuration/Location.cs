using ReactiveUI;

/// <summary>
///
/// </summary>
namespace AT.Player.RX.Model.Configuration
{
    using ReactiveUI.Fody.Helpers;
    using Splat;
    using System;

    public class Location : ReactiveObject
    {
        private static Serilog.ILogger logger = Locator.Current.GetService(typeof(Serilog.ILogger)) as Serilog.ILogger;

        public Location()
        {
            this.WhenAnyValue(x => x.Left)
                .Subscribe(l => logger.Information("Left changed : {l}", l))
              ;

            this.WhenAnyValue(x => x.Top)
                .Subscribe(l => logger.Information("Top changed : {l}", l))
              ;
        }

        //public Location(double l, double t)
        //{
        //    Left = l;
        //    Top = t;
        //}

        #region Public Properties

        [Reactive]
        public double Top { get; set; }

        [Reactive]
        public double Left { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $"Top [{Top}] Left [{Left}]";
        }

        #endregion Public Methods
    }
}