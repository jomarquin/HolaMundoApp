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
    public partial class ClientPage : ContentPage
    {
        private readonly ClientViewModel _viewModel;
        public ClientPage()
        {
            InitializeComponent();
            _viewModel = Startup.Resolve<ClientViewModel>();
            BindingContext = _viewModel;
            //_viewModel.PropertyChanged += _viewModel_PropertyChanged;

        }


    }
}