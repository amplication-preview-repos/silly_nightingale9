using CryptoMonitorService_1.Infrastructure;

namespace CryptoMonitorService_1.APIs;

public class CryptoPairsService : CryptoPairsServiceBase
{
    public CryptoPairsService(CryptoMonitorService_1DbContext context)
        : base(context) { }
}
