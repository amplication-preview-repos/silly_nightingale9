using CryptoMonitorService_1.APIs.Dtos;
using CryptoMonitorService_1.Infrastructure.Models;

namespace CryptoMonitorService_1.APIs.Extensions;

public static class AdditionalDetailsItemsExtensions
{
    public static AdditionalDetails ToDto(this AdditionalDetailsDbModel model)
    {
        return new AdditionalDetails
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AdditionalDetailsDbModel ToModel(
        this AdditionalDetailsUpdateInput updateDto,
        AdditionalDetailsWhereUniqueInput uniqueId
    )
    {
        var additionalDetails = new AdditionalDetailsDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            additionalDetails.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            additionalDetails.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return additionalDetails;
    }
}
