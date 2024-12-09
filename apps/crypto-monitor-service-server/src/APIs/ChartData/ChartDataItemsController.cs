using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitorService_1.APIs;

[ApiController()]
public class ChartDataItemsController : ChartDataItemsControllerBase
{
    public ChartDataItemsController(IChartDataItemsService service)
        : base(service) { }
}
