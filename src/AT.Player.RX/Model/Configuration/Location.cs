using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Player.RX.Model.Configuration
{
    public class Location : ReactiveObject, IEnableLogger
    {
        public Location()
        {
            this.WhenAnyValue(x => x.Left)
                .Subscribe(l => this.Log().Info($"Left changed : {l}"))
              ;

            this.WhenAnyValue(x => x.Top)
                .Subscribe(l => this.Log().Info($"Top changed : {l}"))
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