using CryptoMonitorService_1.Infrastructure;

namespace CryptoMonitorService_1.APIs;

public class AdditionalDetailsItemsService : AdditionalDetailsItemsServiceBase
{
    public AdditionalDetailsItemsService(CryptoMonitorService_1DbContext context)
        : base(context) { }
}
