using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<FixedFeeQuantityTransition, FixedFeeQuantityTransitionFromRaw>)
)]
public sealed record class FixedFeeQuantityTransition : ModelBase
{
    public required DateTimeOffset EffectiveDate
    {
        get
        {
            if (!this._rawData.TryGetValue("effective_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'effective_date' cannot be null",
                    new ArgumentOutOfRangeException("effective_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["effective_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string PriceID
    {
        get
        {
            if (!this._rawData.TryGetValue("price_id", out JsonElement element))
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
            this._rawData["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Quantity
    {
        get
        {
            if (!this._rawData.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["quantity"] = JsonSerializer.SerializeToElement(
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

    public FixedFeeQuantityTransition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FixedFeeQuantityTransitionFromRaw : IFromRaw<FixedFeeQuantityTransition>
{
    public FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FixedFeeQuantityTransition.FromRawUnchecked(rawData);
}
