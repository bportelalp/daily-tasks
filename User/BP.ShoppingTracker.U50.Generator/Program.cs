using BP.ShoppingTracker.IoC.Generator;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BP.ShoppingTracker.D20.Adapters;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets(System.Reflection.Assembly.GetExecutingAssembly())
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        services.ConfigureIoC(configuration);

    })
    .Build();

IConfiguration configuration = host.Services.GetService<IConfiguration>();


var generator = host.Services.GetService<IGenerator>();

var path = configuration.GetSection("PathConfigurationFile").Value;
path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), path);
await generator.GenerateInitialRows(path);

