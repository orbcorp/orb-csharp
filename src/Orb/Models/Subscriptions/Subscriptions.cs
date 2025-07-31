using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Models = Orb.Models;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<Subscriptions>))]
public sealed record class Subscriptions : ModelBase, IFromRaw<Subscriptions>
{
    public required List<Subscription> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<Subscription>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("data");
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

    public Subscriptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscriptions(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Subscriptions FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
