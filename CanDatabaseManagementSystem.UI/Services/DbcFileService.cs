using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.UI.IServices;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

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

        public async Task DeleteDbcFile(int dbcFileId)
        {
            var httpDeleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"{_configuration["Endpoints:DeleteDbcFile"]}/{dbcFileId}");
            await _httpClient.SendAsync(httpDeleteRequest);
        }

        public async Task<List<DbcFileDto>> GetDbcFiles()
		{
            return await _httpClient.GetFromJsonAsync<List<DbcFileDto>>($"{_configuration["Endpoints:GetDbcFiles"]}");
        }

        public async Task UploadDbcFile(DbcFileData dbcFileData)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["Endpoints:UploadDbcFile"]}");
            httpPostRequest.Content = new StringContent(JsonSerializer.Serialize(dbcFileData), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPostRequest);
        }
    }
}
