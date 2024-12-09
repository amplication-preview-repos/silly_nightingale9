using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.Infrastructure.Models;

namespace CryptoMonitorService_1.APIs.Extensions;

public static class ChartDataItemsExtensions
{
    public static ChartData ToDto(this ChartDataDbModel model)
    {
        return new ChartData
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ChartDataDbModel ToModel(
        this ChartDataUpdateInput updateDto,
        ChartDataWhereUniqueInput uniqueId
    )
    {
        var chartData = new ChartDataDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            chartData.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            chartData.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return chartData;
    }
}
