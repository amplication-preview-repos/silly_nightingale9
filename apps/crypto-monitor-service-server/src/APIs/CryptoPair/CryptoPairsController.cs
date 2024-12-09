using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitorService_1.APIs;

[ApiController()]
public class CryptoPairsController : CryptoPairsControllerBase
{
    public CryptoPairsController(ICryptoPairsService service)
        : base(service) { }
}
