using HolaMundoApp.ViewModels;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HolaMundoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfficePage : ContentPage
    {
        private readonly OfficeViewModel _viewModel;
        public OfficePage()
        {
            InitializeComponent();
            _viewModel = Startup.Resolve<OfficeViewModel>();
            BindingContext = _viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }
        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OfficeViewModel.Office) &&
                _viewModel.Office.Latitude != default &&
                _viewModel.Office.Longitude != default &&
                !string.IsNullOrEmpty(_viewModel.Office.NameOffice))
            {
                var position = new Position(_viewModel.Office.Latitude, _viewModel.Office.Longitude);
                OfficeLocationMap.MoveToRegion(new MapSpan(position, 0.05, 0.05));
                OfficeLocationMap.Pins.Add(new Pin
                {
                    Label = _viewModel.Office.NameOffice,
                    Position = position
                });

            }

        }
    }

}