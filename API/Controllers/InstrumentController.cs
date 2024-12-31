using API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class InstrumentController : BaseApiController
    {
          [HttpPost]
        public IActionResult CreateInstrument([FromBody] InstrumentDto instrumentDto)
        {
            if (instrumentDto == null)
            {
                return BadRequest("Instrument data is null.");
            }

            // Add logic to save the instrument to the database

            return Ok(instrumentDto);
        }
    }
}
