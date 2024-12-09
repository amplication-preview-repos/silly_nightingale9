using CryptoMonitorService_1.APIs;
using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitorService_1.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CryptoPairsControllerBase : ControllerBase
{
    protected readonly ICryptoPairsService _service;

    public CryptoPairsControllerBase(ICryptoPairsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one CryptoPair
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<CryptoPair>> CreateCryptoPair(CryptoPairCreateInput input)
    {
        var cryptoPair = await _service.CreateCryptoPair(input);

        return CreatedAtAction(nameof(CryptoPair), new { id = cryptoPair.Id }, cryptoPair);
    }

    /// <summary>
    /// Delete one CryptoPair
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCryptoPair(
        [FromRoute()] CryptoPairWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCryptoPair(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many CryptoPairs
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<CryptoPair>>> CryptoPairs(
        [FromQuery()] CryptoPairFindManyArgs filter
    )
    {
        return Ok(await _service.CryptoPairs(filter));
    }

    /// <summary>
    /// Meta data about CryptoPair records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CryptoPairsMeta(
        [FromQuery()] CryptoPairFindManyArgs filter
    )
    {
        return Ok(await _service.CryptoPairsMeta(filter));
    }

    /// <summary>
    /// Get one CryptoPair
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<CryptoPair>> CryptoPair(
        [FromRoute()] CryptoPairWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.CryptoPair(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one CryptoPair
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCryptoPair(
        [FromRoute()] CryptoPairWhereUniqueInput uniqueId,
        [FromQuery()] CryptoPairUpdateInput cryptoPairUpdateDto
    )
    {
        try
        {
            await _service.UpdateCryptoPair(uniqueId, cryptoPairUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
