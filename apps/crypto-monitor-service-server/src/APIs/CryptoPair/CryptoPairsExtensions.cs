using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.Infrastructure.Models;

namespace CryptoMonitorService_1.APIs.Extensions;

public static class CryptoPairsExtensions
{
    public static CryptoPair ToDto(this CryptoPairDbModel model)
    {
        return new CryptoPair
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CryptoPairDbModel ToModel(
        this CryptoPairUpdateInput updateDto,
        CryptoPairWhereUniqueInput uniqueId
    )
    {
        var cryptoPair = new CryptoPairDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            cryptoPair.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            cryptoPair.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return cryptoPair;
    }
}
