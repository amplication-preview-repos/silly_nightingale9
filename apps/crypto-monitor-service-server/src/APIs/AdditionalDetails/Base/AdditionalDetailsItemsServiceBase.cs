using CryptoMonitorService_1.APIs;
using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.APIs.Errors;
using CryptoMonitorService_1.APIs.Extensions;
using CryptoMonitorService_1.Infrastructure;
using CryptoMonitorService_1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoMonitorService_1.APIs;

public abstract class AdditionalDetailsItemsServiceBase : IAdditionalDetailsItemsService
{
    protected readonly CryptoMonitorService_1DbContext _context;

    public AdditionalDetailsItemsServiceBase(CryptoMonitorService_1DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one AdditionalDetails
    /// </summary>
    public async Task<AdditionalDetails> CreateAdditionalDetails(
        AdditionalDetailsCreateInput createDto
    )
    {
        var additionalDetails = new AdditionalDetailsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            additionalDetails.Id = createDto.Id;
        }

        _context.AdditionalDetailsItems.Add(additionalDetails);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AdditionalDetailsDbModel>(additionalDetails.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one AdditionalDetails
    /// </summary>
    public async Task DeleteAdditionalDetails(AdditionalDetailsWhereUniqueInput uniqueId)
    {
        var additionalDetails = await _context.AdditionalDetailsItems.FindAsync(uniqueId.Id);
        if (additionalDetails == null)
        {
            throw new NotFoundException();
        }

        _context.AdditionalDetailsItems.Remove(additionalDetails);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AdditionalDetailsItems
    /// </summary>
    public async Task<List<AdditionalDetails>> AdditionalDetailsItems(
        AdditionalDetailsFindManyArgs findManyArgs
    )
    {
        var additionalDetailsItems = await _context
            .AdditionalDetailsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return additionalDetailsItems.ConvertAll(additionalDetails => additionalDetails.ToDto());
    }

    /// <summary>
    /// Meta data about AdditionalDetails records
    /// </summary>
    public async Task<MetadataDto> AdditionalDetailsItemsMeta(
        AdditionalDetailsFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .AdditionalDetailsItems.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one AdditionalDetails
    /// </summary>
    public async Task<AdditionalDetails> AdditionalDetails(
        AdditionalDetailsWhereUniqueInput uniqueId
    )
    {
        var additionalDetailsItems = await this.AdditionalDetailsItems(
            new AdditionalDetailsFindManyArgs
            {
                Where = new AdditionalDetailsWhereInput { Id = uniqueId.Id }
            }
        );
        var additionalDetails = additionalDetailsItems.FirstOrDefault();
        if (additionalDetails == null)
        {
            throw new NotFoundException();
        }

        return additionalDetails;
    }

    /// <summary>
    /// Update one AdditionalDetails
    /// </summary>
    public async Task UpdateAdditionalDetails(
        AdditionalDetailsWhereUniqueInput uniqueId,
        AdditionalDetailsUpdateInput updateDto
    )
    {
        var additionalDetails = updateDto.ToModel(uniqueId);

        _context.Entry(additionalDetails).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AdditionalDetailsItems.Any(e => e.Id == additionalDetails.Id))
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
