using HolaMundoApp.Data.Dto;
using HolaMundoApp.Data.Models;
using HolaMundoApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    [QueryProperty(nameof(OfficeId), nameof(OfficeId))]
    public class OfficeViewModel : BaseViewModel
    {
        private readonly IOfficeService _officeService;

        private Office _office;
        private long _officeId;

        public OfficeViewModel(IOfficeService officeService)
        {
            _officeService = officeService;

            AppearingCommand = new AsyncCommand(async () => await Appearing());
        }

        public Office Office { get => _office; set => SetProperty(ref _office, value); }
        public long OfficeId { get => _officeId; set => SetProperty(ref _officeId, value); }

        public ICommand AppearingCommand { get; set; }


        private async Task Appearing()
        {
            await LoadOffice();
        }

        private async Task LoadOffice()
        {
            if (OfficeId < 0)
            {
                return;
            }

            IsBusy = true;
            try
            {
                Office = await _officeService.GetOffice(OfficeId);
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
    }
}
