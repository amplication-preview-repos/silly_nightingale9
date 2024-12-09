using CryptoMonitorService_1.APIs;

namespace CryptoMonitorService_1;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAdditionalDetailsService, AdditionalDetailsService>();
        services.AddScoped<IChartDataService, ChartDataService>();
        services.AddScoped<ICryptoPairsService, CryptoPairsService>();
    }
}
