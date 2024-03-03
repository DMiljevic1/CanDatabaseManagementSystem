using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.UI.IServices;

namespace CanDatabaseManagementSystem.UI.Services
{
	public class DbcFileService : IDbcFileService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;
		public DbcFileService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}
		public async Task<List<DbcFileDto>> GetDbcFiles()
		{
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            return await client.GetFromJsonAsync<List<DbcFileDto>>($"{_configuration["Endpoints:GetDbcFiles"]}");
        }
	}
}
