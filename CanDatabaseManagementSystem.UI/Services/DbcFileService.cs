namespace CanDatabaseManagementSystem.UI.Services
{
	public class DbcFileService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;
		public DbcFileService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}
	}
}
