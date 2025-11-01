class User
{
  public string Name { get; set; }
  public int Age { get; set; }
}

class UserBuilder
{
  private string name;
  private int age;

  public UserBuilder WithName(string name)
  {
    this.name = name;
    return this;
  }

  public UserBuilder WithAge(int age)
  {
    this.age = age;
    return this;
  }

  public virtual Task<User> CreateAsync()
  {
    if (string.IsNullOrEmpty(name))
    {
      throw new InvalidOperationException("Name must be provided");
    }

    return Task.FromResult(new User
    {
      Name = name,
      Age = age
    });
  }
}

class TestUserBuilder : UserBuilder
{
  private bool shouldEmailBeValidated = false;

  public TestUserBuilder()
  {
    WithName(Guid.NewGuid().ToString());
    WithAge(30);
  }

  public TestUserBuilder WithValidatedEmail()
  {
    shouldEmailBeValidated = true;
    return this;
  }

  public override async Task<User> CreateAsync()
  {
    if (shouldEmailBeValidated)
    {
      //TODO: create the necessary entities to simulate that the email activation link has been pressed
    }

    return await base.CreateAsync();
  }
}

class Program2
{
  static async Task Main(string[] args)
  {
    User user = await new TestUserBuilder()
      .WithValidatedEmail()
      .Age(23)
      .CreateAsync();

    Console.WriteLine($"Created user: {user.Name}, Age: {user.Age}");
  }
}
