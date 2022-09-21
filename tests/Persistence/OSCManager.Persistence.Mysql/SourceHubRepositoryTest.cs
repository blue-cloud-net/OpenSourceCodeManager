namespace OSCManager.Persistence.Mysql;

public class Tests
{
    private readonly ISourceHubRepository _sourceHubRepository;

    [SetUp]
    public void Setup()
    {

    }

    [OneTimeSetUp]
    public void OneSetup()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddMySqlDatabase();

        var serviceProvider = services.BuildServiceProvider();

        serviceProvider.GetService<ISourceHubRepository>();
    }

    [Test]
    public void MySql_SourceHub_Add_Test()
    {
        //_sourceHubRepository.AddAsync();

        Assert.Pass();
    }
}