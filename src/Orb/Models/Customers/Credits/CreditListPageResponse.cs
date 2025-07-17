using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using CreditListPageResponseProperties = Orb.Models.Customers.Credits.CreditListPageResponseProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<CreditListPageResponse>))]
public sealed record class CreditListPageResponse
    : Orb::ModelBase,
        Orb::IFromRaw<CreditListPageResponse>
{
    public required Generic::List<CreditListPageResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<CreditListPageResponseProperties::Data>>(
                    element
                ) ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::PaginationMetadata PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "pagination_metadata",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::PaginationMetadata>(element)
                ?? throw new System::ArgumentNullException("pagination_metadata");
        }
        set
        {
            this.Properties["pagination_metadata"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public CreditListPageResponse() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    CreditListPageResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CreditListPageResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
