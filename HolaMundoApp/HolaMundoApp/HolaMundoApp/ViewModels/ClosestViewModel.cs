using HolaMundoApp.Data.Models;
using HolaMundoApp.Resx;
using HolaMundoApp.Services;
using HolaMundoApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HolaMundoApp.ViewModels
{
    public class ClosestViewModel : BaseViewModel
    {
        private readonly IClosestService _closestService;
        private Office _office;
        
        public Office LugarMasCercano { get => _office; set => SetProperty(ref _office, value); }

        public ClosestViewModel(IClosestService closestService)
        {
            _closestService = closestService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            OfficeClosestCommand = new Command(OnOfficeClosestClicked);
            CnbClosestCommand = new Command(OnCnbClosestClicked);
        }

        #region Properties
        public ObservableRangeCollection<Office> Lugares { get; set; } = new ObservableRangeCollection<Office>();

        public Command CnbClosestCommand { get; }
        public Command OfficeClosestCommand { get; }
        public ICommand AppearingCommand { get; set; }
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
                var offices = await _closestService.GetOfficesAsync();
                if (offices.Count > 0)
                {
                    Lugares.ReplaceRange(offices);
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

        private async void OnCnbClosestClicked(object obj)
        {
            if (Lugares == null || Lugares.Count == 0)
            {
                LugarMasCercano = null;
                return;
            }

            var LugaresOf = Lugares.Where(x => x.OfficeType == "CNB");

            Location miLocation = await Geolocation.GetLastKnownLocationAsync();
            var miUbicacion = new Position(miLocation.Latitude, miLocation.Longitude); // Reemplaza con tus coordenadas actuales

            var lugarCercano = LugaresOf
                .Select(l => new
                {
                    Office = l,
                    Distancia = Xamarin.Essentials.Location.CalculateDistance(
                        miUbicacion.Latitude, miUbicacion.Longitude,
                        l.Latitude, l.Longitude, DistanceUnits.Kilometers)
                })
                .OrderBy(l => l.Distancia)
                .FirstOrDefault();

            LugarMasCercano = lugarCercano?.Office;
        }

        private async void OnOfficeClosestClicked(object obj)
        {
            if (Lugares == null || Lugares.Count == 0)
            {
                LugarMasCercano = null;
                return;
            }

            var LugaresOf = Lugares.Where(x => x.OfficeType == "OFICINA");

            Location miLocation = await Geolocation.GetLastKnownLocationAsync();
            var miUbicacion = new Position(miLocation.Latitude, miLocation.Longitude); // Reemplaza con tus coordenadas actuales

            var lugarCercano = LugaresOf
                .Select(l => new
                {
                    Office = l,
                    Distancia = Xamarin.Essentials.Location.CalculateDistance(
                        miUbicacion.Latitude, miUbicacion.Longitude,
                        l.Latitude, l.Longitude, DistanceUnits.Kilometers)
                })
                .OrderBy(l => l.Distancia)
                .FirstOrDefault();

            LugarMasCercano = lugarCercano?.Office;
        }

    }
}
