using HolaMundoApp.ViewModels;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System;
using Xamarin.Essentials;

namespace HolaMundoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClosestPage : ContentPage
	{
        private readonly ClosestViewModel _viewModel;

        public ClosestPage ()
		{
			InitializeComponent ();
            _viewModel = Startup.Resolve<ClosestViewModel>();
            BindingContext = _viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private async void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ClosestViewModel.LugarMasCercano) &&
                _viewModel.LugarMasCercano.Latitude != default &&
                _viewModel.LugarMasCercano.Longitude != default &&
                !string.IsNullOrEmpty(_viewModel.LugarMasCercano.NameOffice))
            {
                var position = new Position(_viewModel.LugarMasCercano.Latitude, _viewModel.LugarMasCercano.Longitude);
                MapClosest.MoveToRegion(new MapSpan(position, 0.05, 0.05));
                MapClosest.Pins.Add(new Pin
                {
                    Label = _viewModel.LugarMasCercano.NameOffice,
                    Position = position
                });

            }
            else
            {
                Location miLocation = await Geolocation.GetLastKnownLocationAsync();
                var miUbicacion = new Position(miLocation.Latitude, miLocation.Longitude);
                MapClosest.MoveToRegion(new MapSpan(miUbicacion, 0.05, 0.05));
                MapClosest.Pins.Add(new Pin
                {
                    Label = "Mi ubicación",
                    Position = miUbicacion
                });
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}