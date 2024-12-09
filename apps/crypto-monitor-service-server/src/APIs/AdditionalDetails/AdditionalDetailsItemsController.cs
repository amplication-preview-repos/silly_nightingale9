using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitorService_1.APIs;

[ApiController()]
public class AdditionalDetailsItemsController : AdditionalDetailsItemsControllerBase
{
    public AdditionalDetailsItemsController(IAdditionalDetailsItemsService service)
        : base(service) { }
}
