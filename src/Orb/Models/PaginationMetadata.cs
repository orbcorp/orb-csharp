using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<PaginationMetadata>))]
public sealed record class PaginationMetadata : ModelBase, IFromRaw<PaginationMetadata>
{
    public required bool HasMore
    {
        get
        {
            if (!this.Properties.TryGetValue("has_more", out JsonElement element))
                throw new ArgumentOutOfRangeException("has_more", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["has_more"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? NextCursor
    {
        get
        {
            if (!this.Properties.TryGetValue("next_cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["next_cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public PaginationMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginationMetadata(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PaginationMetadata FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
