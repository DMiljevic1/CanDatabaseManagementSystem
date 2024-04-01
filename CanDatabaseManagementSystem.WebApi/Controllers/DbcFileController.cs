using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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

		[HttpPost("UploadDbcFile")]
		public async Task<IActionResult> UploadDbcFile([FromBody] DbcFileData dbcFileData, CancellationToken cancellationToken)
		{
            try
            {
				await _dbcFileService.UploadDbcFile(dbcFileData, cancellationToken);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e);
                throw;
            }
        }

        [HttpDelete("DeleteDbcFile/{dbcFileId:int}")]
        public async Task<IActionResult> DeleteDbcFile(int dbcFileId, CancellationToken cancellationToken)
		{
            try
            {
                await _dbcFileService.DeleteDbcFile(dbcFileId, cancellationToken);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e);
                throw;
            }
        }
	}
}
