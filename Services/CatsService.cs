namespace csharp_cat_api.Services;
public class CatsService
{

  private readonly CatsRepository _repository;

  public CatsService(CatsRepository repository)
  {
    _repository = repository;
  }

  public List<Cat> GetCats()
  {
    List<Cat> cats = _repository.GetCats();
    return cats;
  }
}