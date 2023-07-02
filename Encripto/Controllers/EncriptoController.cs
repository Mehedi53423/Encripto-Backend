using Encripto.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Encripto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EncriptoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(Response<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(string inputString)
        {
            var result = EncoderAndDecoder.Encode(inputString);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string inputString)
        {
            var result = EncoderAndDecoder.Decode(inputString);
            return Ok(result);
        }
    }
}
