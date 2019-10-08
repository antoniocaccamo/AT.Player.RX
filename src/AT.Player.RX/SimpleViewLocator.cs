using AT.Player.RX.View;
using AT.Player.RX.ViewModel;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Player.RX
{
    internal class SimpleViewLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T vm, string contract = null) where T : class
        {
            if (vm is ImageViewModel)
                return new ImageView { ViewModel = vm as ImageViewModel };

            if (vm is VideoViewModel)
                return new VideoView { ViewModel = vm as VideoViewModel };

            throw new Exception($"Could not find the view for view model {typeof(T).Name}.");
        }
    }
}