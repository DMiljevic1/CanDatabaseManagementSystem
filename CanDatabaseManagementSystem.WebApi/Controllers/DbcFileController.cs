using CanDatabaseManagementSystem.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanDatabaseManagementSystem.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DbcFileController : ControllerBase
	{
		private readonly IDbcFileService _dbcFileService;
		public DbcFileController(IDbcFileService dbcFileService)
		{
			_dbcFileService = dbcFileService;
		}
		[HttpGet]
		public async Task<IActionResult> GetDbcFiles(CancellationToken cancellationToken)
		{
			try
			{
				return Ok(await _dbcFileService.GetDbcFiles(cancellationToken));
			}
			catch (Exception e)
			{
                Console.WriteLine("error: " + e);
                throw;
			}
		}
	}
}
