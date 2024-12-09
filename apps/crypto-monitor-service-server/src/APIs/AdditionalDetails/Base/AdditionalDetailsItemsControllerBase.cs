using CryptoMonitorService_1.APIs;
using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitorService_1.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AdditionalDetailsItemsControllerBase : ControllerBase
{
    protected readonly IAdditionalDetailsItemsService _service;

    public AdditionalDetailsItemsControllerBase(IAdditionalDetailsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one AdditionalDetails
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<AdditionalDetails>> CreateAdditionalDetails(
        AdditionalDetailsCreateInput input
    )
    {
        var additionalDetails = await _service.CreateAdditionalDetails(input);

        return CreatedAtAction(
            nameof(AdditionalDetails),
            new { id = additionalDetails.Id },
            additionalDetails
        );
    }

    /// <summary>
    /// Delete one AdditionalDetails
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAdditionalDetails(
        [FromRoute()] AdditionalDetailsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAdditionalDetails(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AdditionalDetailsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<AdditionalDetails>>> AdditionalDetailsItems(
        [FromQuery()] AdditionalDetailsFindManyArgs filter
    )
    {
        return Ok(await _service.AdditionalDetailsItems(filter));
    }

    /// <summary>
    /// Meta data about AdditionalDetails records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AdditionalDetailsItemsMeta(
        [FromQuery()] AdditionalDetailsFindManyArgs filter
    )
    {
        return Ok(await _service.AdditionalDetailsItemsMeta(filter));
    }

    /// <summary>
    /// Get one AdditionalDetails
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<AdditionalDetails>> AdditionalDetails(
        [FromRoute()] AdditionalDetailsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.AdditionalDetails(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one AdditionalDetails
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAdditionalDetails(
        [FromRoute()] AdditionalDetailsWhereUniqueInput uniqueId,
        [FromQuery()] AdditionalDetailsUpdateInput additionalDetailsUpdateDto
    )
    {
        try
        {
            await _service.UpdateAdditionalDetails(uniqueId, additionalDetailsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
