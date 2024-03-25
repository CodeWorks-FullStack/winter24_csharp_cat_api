namespace csharp_cat_api.Models;

public class Cat
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int NumberOfLegs { get; set; }
  public string Color { get; set; }
  public bool LikesCheese { get; set; }
  public bool HasTail { get; set; }
}