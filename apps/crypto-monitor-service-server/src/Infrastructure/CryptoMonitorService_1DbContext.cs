using CryptoMonitorService_1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoMonitorService_1.Infrastructure;

public class CryptoMonitorService_1DbContext : DbContext
{
    public CryptoMonitorService_1DbContext(
        DbContextOptions<CryptoMonitorService_1DbContext> options
    )
        : base(options) { }

    public DbSet<ChartDataDbModel> ChartDataItems { get; set; }

    public DbSet<CryptoPairDbModel> CryptoPairs { get; set; }

    public DbSet<AdditionalDetailsDbModel> AdditionalDetailsItems { get; set; }
}
