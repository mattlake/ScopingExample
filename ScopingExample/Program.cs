using DbContext.Context;
using ScopingExample;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDatabaseContext();
        
        // services.AddHostedService<BrokenWorker>();
        services.AddHostedService<WorkingWorker>();
    })
    .Build();

await host.RunAsync();