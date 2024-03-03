using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.UI.IServices;

namespace CanDatabaseManagementSystem.UI.Services
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public MessageService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<List<MessageDto>> GetMessages(int dbcFileId)
        {
            return await _httpClient.GetFromJsonAsync<List<MessageDto>>($"{_configuration["Endpoints:GetMessages"]}/{dbcFileId}");
        }
    }
}
