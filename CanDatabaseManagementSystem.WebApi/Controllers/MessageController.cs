using CanDatabaseManagementSystem.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CanDatabaseManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages(int dbcFileId, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _messageService.GetMessages(dbcFileId, cancellationToken));
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e);
                throw;
            }
        }
    }
}
