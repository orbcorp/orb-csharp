using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.AllocationProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<Allocation>))]
public sealed record class Allocation : ModelBase, IFromRaw<Allocation>
{
    public required bool AllowsRollover
    {
        get
        {
            if (!this.Properties.TryGetValue("allows_rollover", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'allows_rollover' cannot be null",
                    new ArgumentOutOfRangeException("allows_rollover", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["allows_rollover"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentNullException("currency")
                );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CustomExpiration? CustomExpiration
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_expiration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomExpiration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["custom_expiration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<Filter>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AllowsRollover;
        _ = this.Currency;
        this.CustomExpiration?.Validate();
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
    }

    public Allocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Allocation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Allocation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
