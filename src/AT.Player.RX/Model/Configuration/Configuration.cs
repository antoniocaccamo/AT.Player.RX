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

        public Location Location { get; set; }

        public Dummy Dummy { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $"dummy : [{Dummy}]\n" +
                $"\tcomputer : [{Computer}]\n" +
                $"\tsize [{Size}]\n" +
                $"\tlocation [{Location}]\n";
        }

        #endregion Public Methods
    }
}