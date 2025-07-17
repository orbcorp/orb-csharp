using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using TopUpListPageResponseProperties = Orb.Models.Customers.Credits.TopUps.TopUpListPageResponseProperties;

namespace Orb.Models.Customers.Credits.TopUps;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TopUpListPageResponse>))]
public sealed record class TopUpListPageResponse
    : Orb::ModelBase,
        Orb::IFromRaw<TopUpListPageResponse>
{
    public required Generic::List<TopUpListPageResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<TopUpListPageResponseProperties::Data>>(
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

    public TopUpListPageResponse() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TopUpListPageResponse(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TopUpListPageResponse FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
