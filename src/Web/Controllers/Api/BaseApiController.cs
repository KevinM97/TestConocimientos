using Microsoft.AspNetCore.Mvc;

namespace Microsoft.eShopWeb.Web.Controllers.Api;

// No longer used - shown for reference only if using full controllers instead of Endpoints for APIs
[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    [HttpGet]
    public IActionResult hello()
    {
        return Ok();
    }
}
