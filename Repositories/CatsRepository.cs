

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

  internal Cat CreateCat(Cat catData)
  {
    string badSqlThatWillGetYouInBigTrouble = @$"
    INSERT INTO 
    cats(numberOfLegs, hasTail, color, likesCheese, name)
    VALUES({catData.NumberOfLegs}, {catData.HasTail}, '{catData.Color}', {catData.LikesCheese}, '{catData.Name}');
    
    SELECT * FROM cats WHERE id = LAST_INSERT_ID()
    ";


    string goodSql = @"
    INSERT INTO 
    cats(numberOfLegs, hasTail, color, likesCheese, name)
    VALUES(@NumberOfLegs, @HasTail, @Color, @LikesCheese, @Name);
    
    SELECT * FROM cats WHERE id = LAST_INSERT_ID()
    ";

    Cat cat = _db.Query<Cat>(goodSql, catData).FirstOrDefault();
    return cat;
  }
}