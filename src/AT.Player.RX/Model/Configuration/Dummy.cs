using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Player.RX.Model.Configuration
{
    public class Dummy
    {
        #region Public Properties

        public string Image { get; set; }

        public string Video { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $"Image [{Image}] Video [{Video}]";
        }

        #endregion Public Methods
    }
}