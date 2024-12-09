using CryptoMonitorService_1.APIs;
using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.APIs.Errors;
using CryptoMonitorService_1.APIs.Extensions;
using CryptoMonitorService_1.Infrastructure;
using CryptoMonitorService_1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoMonitorService_1.APIs;

public abstract class CryptoPairsServiceBase : ICryptoPairsService
{
    protected readonly CryptoMonitorService_1DbContext _context;

    public CryptoPairsServiceBase(CryptoMonitorService_1DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one CryptoPair
    /// </summary>
    public async Task<CryptoPair> CreateCryptoPair(CryptoPairCreateInput createDto)
    {
        var cryptoPair = new CryptoPairDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            cryptoPair.Id = createDto.Id;
        }

        _context.CryptoPairs.Add(cryptoPair);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CryptoPairDbModel>(cryptoPair.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one CryptoPair
    /// </summary>
    public async Task DeleteCryptoPair(CryptoPairWhereUniqueInput uniqueId)
    {
        var cryptoPair = await _context.CryptoPairs.FindAsync(uniqueId.Id);
        if (cryptoPair == null)
        {
            throw new NotFoundException();
        }

        _context.CryptoPairs.Remove(cryptoPair);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many CryptoPairs
    /// </summary>
    public async Task<List<CryptoPair>> CryptoPairs(CryptoPairFindManyArgs findManyArgs)
    {
        var cryptoPairs = await _context
            .CryptoPairs.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return cryptoPairs.ConvertAll(cryptoPair => cryptoPair.ToDto());
    }

    /// <summary>
    /// Meta data about CryptoPair records
    /// </summary>
    public async Task<MetadataDto> CryptoPairsMeta(CryptoPairFindManyArgs findManyArgs)
    {
        var count = await _context.CryptoPairs.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one CryptoPair
    /// </summary>
    public async Task<CryptoPair> CryptoPair(CryptoPairWhereUniqueInput uniqueId)
    {
        var cryptoPairs = await this.CryptoPairs(
            new CryptoPairFindManyArgs { Where = new CryptoPairWhereInput { Id = uniqueId.Id } }
        );
        var cryptoPair = cryptoPairs.FirstOrDefault();
        if (cryptoPair == null)
        {
            throw new NotFoundException();
        }

        return cryptoPair;
    }

    /// <summary>
    /// Update one CryptoPair
    /// </summary>
    public async Task UpdateCryptoPair(
        CryptoPairWhereUniqueInput uniqueId,
        CryptoPairUpdateInput updateDto
    )
    {
        var cryptoPair = updateDto.ToModel(uniqueId);

        _context.Entry(cryptoPair).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CryptoPairs.Any(e => e.Id == cryptoPair.Id))
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
