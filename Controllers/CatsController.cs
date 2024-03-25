namespace csharp_cat_api.Controllers;

[ApiController]
[Route("api/[controller]")]
// [Route("api/cats")]
public class CatsController : ControllerBase
{

  [HttpGet("test")]
  public ActionResult<string> TestApi()
  {
    try
    {
      return Ok("API IS UP, BABY");
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}