using HolaMundoApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public interface IOfficeService
    {
        Task<List<Office>> GetOfficesAsync();
    }
}
