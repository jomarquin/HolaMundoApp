using HolaMundoApp.Data.API;
using HolaMundoApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public class OfficeService : IOfficeApi
    {
        private readonly IOfficeApi _officeApi;

        public OfficeService(IOfficeApi officeApi)
        {
            _officeApi = officeApi;
        }

        public async Task<List<Office>> GetOfficesAsync()
        {
            var offices = new List<Office>();

            try
            {
                var response = await _officeApi.GetOfficesAsync();
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
