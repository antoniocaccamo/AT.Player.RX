using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Player.RX.Model.Configuration
{
    public class Configuration : ReactiveObject
    {
        #region Public Properties

        [Reactive]
        public string Computer { get; set; }

        [Reactive]
        public Size Size { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $" computer : [{Computer}] size [{Size}]";
        }

        #endregion Public Methods
    }
}