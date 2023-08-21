using HolaMundoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}