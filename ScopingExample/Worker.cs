using DbContext.Context;
using DbContext.Models;

namespace ScopingExample;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly DataContext _context;

    public Worker(ILogger<Worker> logger, DataContext dataContext)
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