using CryptoMonitorService_1.Infrastructure;

namespace CryptoMonitorService_1.APIs;

public class ChartDataItemsService : ChartDataItemsServiceBase
{
    public ChartDataItemsService(CryptoMonitorService_1DbContext context)
        : base(context) { }
}
