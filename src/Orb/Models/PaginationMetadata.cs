using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<PaginationMetadata>))]
public sealed record class PaginationMetadata : Orb::ModelBase, Orb::IFromRaw<PaginationMetadata>
{
    public required bool HasMore
    {
        get
        {
            if (!this.Properties.TryGetValue("has_more", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "has_more",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["has_more"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? NextCursor
    {
        get
        {
            if (!this.Properties.TryGetValue("next_cursor", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "next_cursor",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["next_cursor"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public PaginationMetadata() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    PaginationMetadata(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PaginationMetadata FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
