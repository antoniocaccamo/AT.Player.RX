namespace AT.Player.RX
{
    using AT.Player.RX.Views;
    using AT.Player.RX.ViewModels;
    using ReactiveUI;
    using System;

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