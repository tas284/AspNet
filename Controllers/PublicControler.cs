using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicController : ControllerBase
{
    [HttpGet("version")]
    public ActionResult<string> Version()
    {
        return Ok("1.0");
    }
}