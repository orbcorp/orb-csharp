using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<FixedFeeQuantityTransition>))]
public sealed record class FixedFeeQuantityTransition
    : ModelBase,
        IFromRaw<FixedFeeQuantityTransition>
{
    public required DateTime EffectiveDate
    {
        get
        {
            if (!this._properties.TryGetValue("effective_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'effective_date' cannot be null",
                    new ArgumentOutOfRangeException("effective_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["effective_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string PriceID
    {
        get
        {
            if (!this._properties.TryGetValue("price_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price_id' cannot be null",
                    new ArgumentOutOfRangeException("price_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'price_id' cannot be null",
                    new ArgumentNullException("price_id")
                );
        }
        init
        {
            this._properties["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Quantity
    {
        get
        {
            if (!this._properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.PriceID;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition() { }

    public FixedFeeQuantityTransition(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransition(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
