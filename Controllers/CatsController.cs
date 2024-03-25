namespace csharp_cat_api.Controllers;

[ApiController]
[Route("api/[controller]")] // NOTE node equivalent: `super('api/cats')`
// [Route("api/cats")] this also works
public class CatsController : ControllerBase //NOTE node equivalent: `class CatsController extends BaseController`
{

  private readonly CatsService _catsService;

  // NOTE dependency injection 💉
  // Our Startup.cs is responsible for creating services and handing them out to other classes as needed. Services are passed through the constructor of the class that needs them
  public CatsController(CatsService catsService)
  {
    _catsService = catsService;
  }

  [HttpGet("test")] // GET request to https://localhost:7045/api/test will trigger this method
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
  // NOTE ActionResult is an HTTP response type
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

  [HttpPost]
  public ActionResult<Cat> CreateCat([FromBody] Cat catData) // NOTE const catData = request.body
  {
    try
    {
      Cat cat = _catsService.CreateCat(catData);
      return Ok(cat);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}