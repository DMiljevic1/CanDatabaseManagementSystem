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
            return await _httpClient.GetFromJsonAsync<List<DbcFileDto>>($"{_configuration["Endpoints:GetDbcFiles"]}");
        }
	}
}
