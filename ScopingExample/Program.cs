using DbContext.Context;
using ScopingExample;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDatabaseContext();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();