/*
 * This is the example of code that will throw an invalid operation exception
 * System.InvalidOperationException: Error while validating the service descriptor 'ServiceType: Microsoft.Extensions.Hosting.IHostedService Lifetime: Singleton ImplementationType: ScopingExample.Worker': Cannot consume scoped service 'DbContext.Context.DataContext' from singleton 'Microsoft.Extensions.Hosting.IHostedService'
 */

using DbContext.Context;
using DbContext.Models;

namespace ScopingExample;

public class BrokenWorker : BackgroundService
{
    private readonly ILogger<BrokenWorker> _logger;
    private readonly DataContext _context;

    public BrokenWorker(ILogger<BrokenWorker> logger, DataContext dataContext)
    {
        _logger = logger;
        _context = dataContext;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            User user = _context.Users.FirstOrDefault();

            _logger.LogInformation($"Id: {user.UserId}, username: {user.UserName}");

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}