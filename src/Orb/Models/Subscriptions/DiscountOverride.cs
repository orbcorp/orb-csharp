using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(ModelConverter<DiscountOverride, DiscountOverrideFromRaw>))]
public sealed record class DiscountOverride : ModelBase
{
    public required ApiEnum<string, DiscountOverrideDiscountType> DiscountType
    {
        get
        {
            if (!this._rawData.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DiscountOverrideDiscountType>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentNullException("discount_type")
                );
        }
        init
        {
            this._rawData["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public string? AmountDiscount
    {
        get
        {
            if (!this._rawData.TryGetValue("amount_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public double? PercentageDiscount
    {
        get
        {
            if (!this._rawData.TryGetValue("percentage_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public double? UsageDiscount
    {
        get
        {
            if (!this._rawData.TryGetValue("usage_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["usage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.AmountDiscount;
        _ = this.PercentageDiscount;
        _ = this.UsageDiscount;
    }

    public DiscountOverride() { }

    public DiscountOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DiscountOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DiscountOverride(ApiEnum<string, DiscountOverrideDiscountType> discountType)
        : this()
    {
        this.DiscountType = discountType;
    }
}

class DiscountOverrideFromRaw : IFromRaw<DiscountOverride>
{
    public DiscountOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DiscountOverride.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DiscountOverrideDiscountTypeConverter))]
public enum DiscountOverrideDiscountType
{
    Percentage,
    Usage,
    Amount,
}

sealed class DiscountOverrideDiscountTypeConverter : JsonConverter<DiscountOverrideDiscountType>
{
    public override DiscountOverrideDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => DiscountOverrideDiscountType.Percentage,
            "usage" => DiscountOverrideDiscountType.Usage,
            "amount" => DiscountOverrideDiscountType.Amount,
            _ => (DiscountOverrideDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountOverrideDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountOverrideDiscountType.Percentage => "percentage",
                DiscountOverrideDiscountType.Usage => "usage",
                DiscountOverrideDiscountType.Amount => "amount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
