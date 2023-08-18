using HolaMundoApp.Data.Models;
using HolaMundoApp.Services;
using HolaMundoApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class OfficesViewModel : BaseViewModel
    {
        private readonly IOfficeService _officeService;

        public OfficesViewModel(IOfficeService officeService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            ClientTappedCommand = new AsyncCommand<Office>(OnClientTapped);
            Title = "Offices";
            _officeService = officeService;
        }

        #region Properties
        public ObservableRangeCollection<Office> Offices { get; set; } = new ObservableRangeCollection<Office>();

        public ICommand AppearingCommand { get; set; }
        public ICommand ClientTappedCommand { get; set; }
        #endregion

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var offices = await _officeService.GetOfficesAsync();
                if (offices.Count > 0)
                {
                    Offices.ReplaceRange(offices);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Task OnClientTapped(Office office)
        {
            if (office == null)
            {
                return Task.CompletedTask;
            }

            return Shell.Current.GoToAsync($"{nameof(ClientPage)}?{nameof(ClientViewModel.ClientId)}={office.Id}");
        }
    }
}
