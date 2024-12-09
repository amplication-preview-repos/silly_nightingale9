using Microsoft.EntityFrameworkCore;

namespace CryptoMonitorService.Infrastructure;

public class CryptoMonitorServiceDbContext : DbContext
{
    public CryptoMonitorServiceDbContext(DbContextOptions<CryptoMonitorServiceDbContext> options)
        : base(options) { }
}
