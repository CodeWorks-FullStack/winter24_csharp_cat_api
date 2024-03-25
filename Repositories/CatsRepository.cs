
namespace csharp_cat_api.Repositories;


public class CatsRepository
{
  private readonly IDbConnection _db;

  public CatsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Cat> GetCats()
  {
    string sql = "SELECT * FROM cats;";

    List<Cat> cats = _db.Query<Cat>(sql).ToList();

    return cats;
  }
}