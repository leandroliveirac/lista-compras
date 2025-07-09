using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace ListaCompras.API.Controllers
{
    [ApiController]
    [Route("api/dominio")]
    [Produces(MediaTypeNames.Application.Json)]
    public class DominioController : ControllerBase
    {
        
      [HttpGet("time-zone")]
      public IActionResult GetTimeZone()
      {
        var timeZone = TimeZoneInfo.Local.Id;
        var currentTime = DateTime.Now;
        return Ok(new { timeZone, currentTime });
      }
    }
}