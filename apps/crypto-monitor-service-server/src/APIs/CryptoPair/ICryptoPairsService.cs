using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;

namespace CryptoMonitorService_1.APIs;

public interface ICryptoPairsService
{
    /// <summary>
    /// Create one CryptoPair
    /// </summary>
    public Task<CryptoPair> CreateCryptoPair(CryptoPairCreateInput cryptopair);

    /// <summary>
    /// Delete one CryptoPair
    /// </summary>
    public Task DeleteCryptoPair(CryptoPairWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CryptoPairs
    /// </summary>
    public Task<List<CryptoPair>> CryptoPairs(CryptoPairFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about CryptoPair records
    /// </summary>
    public Task<MetadataDto> CryptoPairsMeta(CryptoPairFindManyArgs findManyArgs);

    /// <summary>
    /// Get one CryptoPair
    /// </summary>
    public Task<CryptoPair> CryptoPair(CryptoPairWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one CryptoPair
    /// </summary>
    public Task UpdateCryptoPair(
        CryptoPairWhereUniqueInput uniqueId,
        CryptoPairUpdateInput updateDto
    );
}
