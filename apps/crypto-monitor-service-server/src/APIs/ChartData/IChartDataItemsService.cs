using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;

namespace CryptoMonitorService_1.APIs;

public interface IChartDataItemsService
{
    /// <summary>
    /// Create one ChartData
    /// </summary>
    public Task<ChartData> CreateChartData(ChartDataCreateInput chartdata);

    /// <summary>
    /// Delete one ChartData
    /// </summary>
    public Task DeleteChartData(ChartDataWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ChartDataItems
    /// </summary>
    public Task<List<ChartData>> ChartDataItems(ChartDataFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ChartData records
    /// </summary>
    public Task<MetadataDto> ChartDataItemsMeta(ChartDataFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ChartData
    /// </summary>
    public Task<ChartData> ChartData(ChartDataWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ChartData
    /// </summary>
    public Task UpdateChartData(ChartDataWhereUniqueInput uniqueId, ChartDataUpdateInput updateDto);
}
