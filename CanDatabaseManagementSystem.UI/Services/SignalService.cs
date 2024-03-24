using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.UI.IServices;
using System.Net.Http;

namespace CanDatabaseManagementSystem.UI.Services
{
    public class SignalService : ISignalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public SignalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<List<SignalDto>> GetSignals(int messageId)
        {
            return await _httpClient.GetFromJsonAsync<List<SignalDto>>($"{_configuration["Endpoints:GetSignals"]}/{messageId}");
        }
    }
}
