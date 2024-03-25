
namespace csharp_cat_api.Services;
public class CatsService
{

  private readonly CatsRepository _repository;
  // NOTE dependency injection 💉
  public CatsService(CatsRepository repository)
  {
    _repository = repository;
  }

  public List<Cat> GetCats()
  {
    List<Cat> cats = _repository.GetCats();
    return cats;
  }

  public Cat CreateCat(Cat catData)
  {
    Cat cat = _repository.CreateCat(catData);
    return cat;
  }
}