using CryptoMonitorService_1.APIs;
using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitorService_1.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ChartDataItemsControllerBase : ControllerBase
{
    protected readonly IChartDataItemsService _service;

    public ChartDataItemsControllerBase(IChartDataItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ChartData
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ChartData>> CreateChartData(ChartDataCreateInput input)
    {
        var chartData = await _service.CreateChartData(input);

        return CreatedAtAction(nameof(ChartData), new { id = chartData.Id }, chartData);
    }

    /// <summary>
    /// Delete one ChartData
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteChartData(
        [FromRoute()] ChartDataWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteChartData(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ChartDataItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ChartData>>> ChartDataItems(
        [FromQuery()] ChartDataFindManyArgs filter
    )
    {
        return Ok(await _service.ChartDataItems(filter));
    }

    /// <summary>
    /// Meta data about ChartData records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ChartDataItemsMeta(
        [FromQuery()] ChartDataFindManyArgs filter
    )
    {
        return Ok(await _service.ChartDataItemsMeta(filter));
    }

    /// <summary>
    /// Get one ChartData
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ChartData>> ChartData(
        [FromRoute()] ChartDataWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ChartData(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ChartData
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateChartData(
        [FromRoute()] ChartDataWhereUniqueInput uniqueId,
        [FromQuery()] ChartDataUpdateInput chartDataUpdateDto
    )
    {
        try
        {
            await _service.UpdateChartData(uniqueId, chartDataUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
