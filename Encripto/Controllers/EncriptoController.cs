using Encripto.Interfaces;
using Encripto.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Encripto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EncriptoController : ControllerBase
    {
        private readonly IEncripto _encripto;

        public EncriptoController(IEncripto encripto)
        {
            _encripto = encripto;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Encode(string inputString)
        {
            var result = await _encripto.Encode(inputString);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Decode(string inputString)
        {
            var result = await _encripto.Decode(inputString);
            return Ok(result);
        }
    }
}
