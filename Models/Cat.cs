namespace csharp_cat_api.Models; // NOTE namespace creates a bundle of our code that is easily brought into other modules

public class Cat
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int NumberOfLegs { get; set; }
  public string Color { get; set; }
  public bool LikesCheese { get; set; }
  public bool HasTail { get; set; }

  // NOTE no constructor needed for models that we will be using with our database
}