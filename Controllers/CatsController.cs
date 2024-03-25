namespace csharp_cat_api.Controllers;

[ApiController]
[Route("api/[controller]")] // [Route("api/cats")]
public class CatsController : ControllerBase
{

  private readonly CatsService _catsService;

  public CatsController(CatsService catsService)
  {
    _catsService = catsService;
  }

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

  [HttpGet]
  public ActionResult<List<Cat>> GetCats()
  {
    try
    {
      List<Cat> cats = _catsService.GetCats();
      return Ok(cats); // NOTE response.send(cats)
    }
    catch (Exception error)
    {
      return BadRequest(error.Message); // NOTE next(error)
    }
  }
}