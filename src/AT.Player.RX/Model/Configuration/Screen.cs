namespace AT.Player.RX.Model.Configuration
{
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    using Splat;
    using System;

    public class Screen : ReactiveObject
    {
        private static readonly Serilog.ILogger logger = Locator.Current.GetService(typeof(Serilog.ILogger)) as Serilog.ILogger;

        public Screen()
        {
            this.WhenAnyValue(x => x.Size)
                .Subscribe(l => logger.Information("Size changed : {l}", l))
              ;

            this.WhenAnyValue(x => x.Location)
                .Subscribe(l => logger.Information("Location changed : {l}", l))
              ;
        }

        #region Public Properties

        [Reactive]
        public Size Size { get; set; }

        public Location Location { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $"size [{Size}] location [{Location}]";
        }

        #endregion Public Methods
    }
}