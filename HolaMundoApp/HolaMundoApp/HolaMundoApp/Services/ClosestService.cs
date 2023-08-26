using HolaMundoApp.Data.API;
using HolaMundoApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public class ClosestService : IClosestService
    {
        private readonly IOfficeApi _closestService;

        public ClosestService(IOfficeApi closestService)
        {
            _closestService = closestService;
        }

        public async Task<List<Office>> GetOfficesAsync()
        {
            var offices = new List<Office>();

            try
            {
                var response = await _closestService.GetOfficesAsync();
                offices = response.ToList();    
                return offices;

            }
            catch (Exception ex)
            {

                var error = ex.Message;
            }
            return offices;
        }
    }
}
