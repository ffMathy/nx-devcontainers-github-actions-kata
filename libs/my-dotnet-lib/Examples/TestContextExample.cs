class FrontendTestContext : IAsyncDisposable
{
  public UniooBankApiTestContext BankApi { get; }

  public async Task Initialize()
  {
    await BankApi.Initialize();
    //TODO: run "yarn start" for frontend
    //TODO: spin up Playwright browser
  }

  public async ValueTask DisposeAsync()
  {
    await BankApi.DisposeAsync();
    //TODO: kill angular
    //TODO: kill Playwright browser
  }

  public async Task<FrontendFrontPageTestContext> NavigateToFrontPage()
  {
    //TODO: navigate to front page
    return new FrontendFrontPageTestContext();
  }

  public async Task<FrontendSearchPageTestContext> NavigateToSearchPage()
  {
    //TODO: navigate to search page
    return new FrontendSearchPageTestContext();
  }
}

class UniooBankApiTestContext : IAsyncDisposable
{
  public DatabaseTestContext Database { get; }
  public WebhookTestContext Webhooks { get; }

  public async Task Initialize()
  {
    await Database.Initialize();
    await Webhooks.Initialize();
  }

  public async ValueTask DisposeAsync()
  {
    await Database.DisposeAsync();
    await Webhooks.DisposeAsync();
  }

  public async Task MockAuthenticationForUserAsync(User user)
  {
    //TODO: mock the authentication system to simulate that the given user is logged in
  }
}

class DatabaseTestContext : IAsyncDisposable
{
  public TestUserBuilder UserBuilder { get; set; }

  public async Task Initialize()
  {
  }

  public async ValueTask DisposeAsync()
  {
  }
}

class WebhookTestContext : IAsyncDisposable
{
  public async Task Initialize()
  {
  }

  public async ValueTask DisposeAsync()
  {
  }
}

class FrontendSearchPageTestContext
{
  public async Task PerformSearch(string query)
  {
    //TODO: write in search field and hit enter
  }
}

class FrontendFrontPageTestContext
{
}

class Program1
{
  static async Task Main(string[] args)
  {
    await using var testContext = new FrontendTestContext();
    await testContext.Initialize();

    var someUser = await testContext.BankApi.Database.UserBuilder
      .WithAge(24)
      .CreateAsync();

    await testContext.BankApi.MockAuthenticationForUserAsync(someUser);

    var frontPage = await testContext.NavigateToFrontPage();

    var searchPage = await testContext.NavigateToSearchPage();
    await searchPage.PerformSearch("test query");
  }
}
