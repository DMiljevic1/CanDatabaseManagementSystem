using CanDatabaseManagementSystem.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CanDatabaseManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalController : ControllerBase
    {
        private readonly ISignalService _signalService;
        public SignalController(ISignalService signalService)
        {
            _signalService = signalService;
        }
        [HttpGet("{messageId:int}")]
        public async Task<IActionResult> GetSignals(int messageId, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _signalService.GetSignals(messageId, cancellationToken));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
