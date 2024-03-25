

namespace csharp_cat_api.Repositories;


public class CatsRepository
{
  // NOTE _db is our active connection to our database, and it allows us to access methods from our new ORM called dapper
  private readonly IDbConnection _db;

  // NOTE dependency injection 💉
  public CatsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Cat> GetCats()
  {
    string sql = "SELECT * FROM cats;";

    // Query<Cat> tells dapper that it is running a query, and it will convert each row into a Cat class object
    // we pass our sql query to dapper, and it runs the query against our sql database
    // Query returns an IEnumerable, and we convert to a List by calling ToList
    List<Cat> cats = _db.Query<Cat>(sql).ToList();

    return cats;
  }

  internal Cat CreateCat(Cat catData)
  {
    // NOTE opens up our database for sql injection attacks
    string badSqlThatWillGetYouInBigTrouble = @$"
    INSERT INTO 
    cats(numberOfLegs, hasTail, color, likesCheese, name)
    VALUES({catData.NumberOfLegs}, {catData.HasTail}, '{catData.Color}', {catData.LikesCheese}, '{catData.Name}');
    
    SELECT * FROM cats WHERE id = LAST_INSERT_ID()
    ";


    // NOTE we use the @sign to denote that dapper is going to look through an object for these specific values, and parameterize and sanitize them for us
    string goodSql = @"
    INSERT INTO 
    cats(numberOfLegs, hasTail, color, likesCheese, name)
    VALUES(@NumberOfLegs, @HasTail, @Color, @LikesCheese, @Name);
    
    SELECT * FROM cats WHERE id = LAST_INSERT_ID()
    ";

    // NOTE  second argument passed to dapper is the object that we want it to parameterize for us
    // FirstOrDefault will return the first row that it finds, or default to null if no rows are returned
    Cat cat = _db.Query<Cat>(goodSql, catData).FirstOrDefault();
    return cat;
  }
}