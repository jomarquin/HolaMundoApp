using HolaMundoApp.Data.Dto;
using HolaMundoApp.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoApp.Data.API
{
    public interface IOfficeApi
    {
        [Get("/Offices")]
        Task<List<Office>> GetOfficesAsync();

        [Get("/Offices/{id}")]
        Task<Office> GetOffice(long id);
    }
}
