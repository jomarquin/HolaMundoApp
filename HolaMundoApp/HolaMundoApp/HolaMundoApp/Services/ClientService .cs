using HolaMundoApp.Services;
using HolaMundoApp.Data.API;
using HolaMundoApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaMundoApp.Data.Dto;

namespace HolaMundoApp.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientApi  _clientApi;

        public ClientService(IClientApi clientApi)
        {
            _clientApi = clientApi;
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            var clients = new List<Client>();

            try
            {
                var response = await _clientApi.GetClientsAsync();
                clients = response.ToList();
                return clients;

            }
            catch (Exception ex)
            {

                var error = ex.Message;
            }
            return clients;
        }

        public async Task<ClientDetailDto> GetClient(long clientId)
        {
            var client = new ClientDetailDto();

            try
            {
                client = await _clientApi.GetClient(clientId);
                return client;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return client;
        }

    }
}
