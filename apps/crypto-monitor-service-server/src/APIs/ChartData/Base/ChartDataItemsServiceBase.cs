using CryptoMonitorService_1.APIs;
using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.APIs.Errors;
using CryptoMonitorService_1.APIs.Extensions;
using CryptoMonitorService_1.Infrastructure;
using CryptoMonitorService_1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoMonitorService_1.APIs;

public abstract class ChartDataItemsServiceBase : IChartDataItemsService
{
    protected readonly CryptoMonitorService_1DbContext _context;

    public ChartDataItemsServiceBase(CryptoMonitorService_1DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ChartData
    /// </summary>
    public async Task<ChartData> CreateChartData(ChartDataCreateInput createDto)
    {
        var chartData = new ChartDataDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            chartData.Id = createDto.Id;
        }

        _context.ChartDataItems.Add(chartData);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ChartDataDbModel>(chartData.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ChartData
    /// </summary>
    public async Task DeleteChartData(ChartDataWhereUniqueInput uniqueId)
    {
        var chartData = await _context.ChartDataItems.FindAsync(uniqueId.Id);
        if (chartData == null)
        {
            throw new NotFoundException();
        }

        _context.ChartDataItems.Remove(chartData);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ChartDataItems
    /// </summary>
    public async Task<List<ChartData>> ChartDataItems(ChartDataFindManyArgs findManyArgs)
    {
        var chartDataItems = await _context
            .ChartDataItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return chartDataItems.ConvertAll(chartData => chartData.ToDto());
    }

    /// <summary>
    /// Meta data about ChartData records
    /// </summary>
    public async Task<MetadataDto> ChartDataItemsMeta(ChartDataFindManyArgs findManyArgs)
    {
        var count = await _context.ChartDataItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ChartData
    /// </summary>
    public async Task<ChartData> ChartData(ChartDataWhereUniqueInput uniqueId)
    {
        var chartDataItems = await this.ChartDataItems(
            new ChartDataFindManyArgs { Where = new ChartDataWhereInput { Id = uniqueId.Id } }
        );
        var chartData = chartDataItems.FirstOrDefault();
        if (chartData == null)
        {
            throw new NotFoundException();
        }

        return chartData;
    }

    /// <summary>
    /// Update one ChartData
    /// </summary>
    public async Task UpdateChartData(
        ChartDataWhereUniqueInput uniqueId,
        ChartDataUpdateInput updateDto
    )
    {
        var chartData = updateDto.ToModel(uniqueId);

        _context.Entry(chartData).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ChartDataItems.Any(e => e.Id == chartData.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
