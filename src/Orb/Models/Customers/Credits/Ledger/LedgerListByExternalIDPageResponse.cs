using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LedgerListByExternalIDPageResponseProperties = Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDPageResponseProperties;
using Models = Orb.Models;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(ModelConverter<LedgerListByExternalIDPageResponse>))]
public sealed record class LedgerListByExternalIDPageResponse
    : ModelBase,
        IFromRaw<LedgerListByExternalIDPageResponse>
{
    public required List<LedgerListByExternalIDPageResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<
                    List<LedgerListByExternalIDPageResponseProperties::Data>
                >(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::PaginationMetadata PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "pagination_metadata",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Models::PaginationMetadata>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("pagination_metadata");
        }
        set { this.Properties["pagination_metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public LedgerListByExternalIDPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerListByExternalIDPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LedgerListByExternalIDPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
