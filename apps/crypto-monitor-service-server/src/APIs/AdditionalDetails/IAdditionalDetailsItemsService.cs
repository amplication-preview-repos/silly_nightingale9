using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.APIs.Dtos;

namespace CryptoMonitorService_1.APIs;

public interface IAdditionalDetailsItemsService
{
    /// <summary>
    /// Create one AdditionalDetails
    /// </summary>
    public Task<AdditionalDetails> CreateAdditionalDetails(
        AdditionalDetailsCreateInput additionaldetails
    );

    /// <summary>
    /// Delete one AdditionalDetails
    /// </summary>
    public Task DeleteAdditionalDetails(AdditionalDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AdditionalDetailsItems
    /// </summary>
    public Task<List<AdditionalDetails>> AdditionalDetailsItems(
        AdditionalDetailsFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about AdditionalDetails records
    /// </summary>
    public Task<MetadataDto> AdditionalDetailsItemsMeta(AdditionalDetailsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one AdditionalDetails
    /// </summary>
    public Task<AdditionalDetails> AdditionalDetails(AdditionalDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one AdditionalDetails
    /// </summary>
    public Task UpdateAdditionalDetails(
        AdditionalDetailsWhereUniqueInput uniqueId,
        AdditionalDetailsUpdateInput updateDto
    );
}
