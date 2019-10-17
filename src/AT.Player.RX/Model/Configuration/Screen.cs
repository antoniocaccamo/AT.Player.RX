using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Player.RX.Model.Configuration
{
    public class Screen : ReactiveObject
    {
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