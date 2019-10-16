﻿using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Player.RX.Model.Configuration
{
    public class Size : ReactiveObject, IEnableLogger
    {
        public Size()
        {
            this.WhenAnyValue(x => x.Width)
                .Subscribe(l => this.Log().Info($"Width changed : {l}"))
              ;

            this.WhenAnyValue(x => x.Height)
                .Subscribe(l => this.Log().Info($"Height changed : {l}"))
              ;
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