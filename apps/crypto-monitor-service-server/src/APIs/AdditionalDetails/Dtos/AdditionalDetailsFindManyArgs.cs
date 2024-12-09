using CryptoMonitorService_1.APIs.Common;
using CryptoMonitorService_1.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitorService_1.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class AdditionalDetailsFindManyArgs
    : FindManyInput<AdditionalDetails, AdditionalDetailsWhereInput> { }
