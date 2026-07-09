using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(InvoiceLevelDiscountConverter))]
public record class InvoiceLevelDiscount : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                percentage: (x) => x.Reason,
                amount: (x) => x.Reason,
                trial: (x) => x.Reason,
                tieredPercentage: (x) => x.Reason
            );
        }
    }

    public InvoiceLevelDiscount(PercentageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InvoiceLevelDiscount(AmountDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InvoiceLevelDiscount(TrialDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InvoiceLevelDiscount(
        InvoiceLevelDiscountTieredPercentage value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InvoiceLevelDiscount(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercentage(out var value)) {
    ///     // `value` is of type `PercentageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = this.Value as PercentageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AmountDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAmount(out var value)) {
    ///     // `value` is of type `AmountDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = this.Value as AmountDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TrialDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTrial(out var value)) {
    ///     // `value` is of type `TrialDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTrial([NotNullWhen(true)] out TrialDiscount? value)
    {
        value = this.Value as TrialDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvoiceLevelDiscountTieredPercentage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredPercentage(out var value)) {
    ///     // `value` is of type `InvoiceLevelDiscountTieredPercentage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredPercentage(
        [NotNullWhen(true)] out InvoiceLevelDiscountTieredPercentage? value
    )
    {
        value = this.Value as InvoiceLevelDiscountTieredPercentage;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (PercentageDiscount value) =&gt; {...},
    ///     (AmountDiscount value) =&gt; {...},
    ///     (TrialDiscount value) =&gt; {...},
    ///     (InvoiceLevelDiscountTieredPercentage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<PercentageDiscount> percentage,
        System::Action<AmountDiscount> amount,
        System::Action<TrialDiscount> trial,
        System::Action<InvoiceLevelDiscountTieredPercentage> tieredPercentage
    )
    {
        switch (this.Value)
        {
            case PercentageDiscount value:
                percentage(value);
                break;
            case AmountDiscount value:
                amount(value);
                break;
            case TrialDiscount value:
                trial(value);
                break;
            case InvoiceLevelDiscountTieredPercentage value:
                tieredPercentage(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of InvoiceLevelDiscount"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (PercentageDiscount value) =&gt; {...},
    ///     (AmountDiscount value) =&gt; {...},
    ///     (TrialDiscount value) =&gt; {...},
    ///     (InvoiceLevelDiscountTieredPercentage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<PercentageDiscount, T> percentage,
        System::Func<AmountDiscount, T> amount,
        System::Func<TrialDiscount, T> trial,
        System::Func<InvoiceLevelDiscountTieredPercentage, T> tieredPercentage
    )
    {
        return this.Value switch
        {
            PercentageDiscount value => percentage(value),
            AmountDiscount value => amount(value),
            TrialDiscount value => trial(value),
            InvoiceLevelDiscountTieredPercentage value => tieredPercentage(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of InvoiceLevelDiscount"
            ),
        };
    }

    public static implicit operator InvoiceLevelDiscount(PercentageDiscount value) => new(value);

    public static implicit operator InvoiceLevelDiscount(AmountDiscount value) => new(value);

    public static implicit operator InvoiceLevelDiscount(TrialDiscount value) => new(value);

    public static implicit operator InvoiceLevelDiscount(
        InvoiceLevelDiscountTieredPercentage value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of InvoiceLevelDiscount"
            );
        }
        this.Switch(
            (percentage) => percentage.Validate(),
            (amount) => amount.Validate(),
            (trial) => trial.Validate(),
            (tieredPercentage) => tieredPercentage.Validate()
        );
    }

    public virtual bool Equals(InvoiceLevelDiscount? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            PercentageDiscount _ => 0,
            AmountDiscount _ => 1,
            TrialDiscount _ => 2,
            InvoiceLevelDiscountTieredPercentage _ => 3,
            _ => -1,
        };
    }
}

sealed class InvoiceLevelDiscountConverter : JsonConverter<InvoiceLevelDiscount>
{
    public override InvoiceLevelDiscount? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? discountType;
        try
        {
            discountType = element.GetProperty("discount_type").GetString();
        }
        catch
        {
            discountType = null;
        }

        switch (discountType)
        {
            case "percentage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscount>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscount>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "trial":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TrialDiscount>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_percentage":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<InvoiceLevelDiscountTieredPercentage>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new InvoiceLevelDiscount(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceLevelDiscount value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceLevelDiscountTieredPercentage,
        InvoiceLevelDiscountTieredPercentageFromRaw
    >)
)]
public sealed record class InvoiceLevelDiscountTieredPercentage : JsonModel
{
    public JsonElement DiscountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("discount_type");
        }
        init { this._rawData.Set("discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `tiered_percentage`. The ordered, contiguous
    /// bands of cumulative eligible spend, each discounted at its own percentage
    /// (progressive fill-a-tier).
    /// </summary>
    public required IReadOnlyList<InvoiceLevelDiscountTieredPercentageTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<InvoiceLevelDiscountTieredPercentageTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvoiceLevelDiscountTieredPercentageTier>>(
                "tiers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("applies_to_price_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "applies_to_price_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public IReadOnlyList<InvoiceLevelDiscountTieredPercentageFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<InvoiceLevelDiscountTieredPercentageFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvoiceLevelDiscountTieredPercentageFilter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.DiscountType,
                JsonSerializer.SerializeToElement("tiered_percentage")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public InvoiceLevelDiscountTieredPercentage()
    {
        this.DiscountType = JsonSerializer.SerializeToElement("tiered_percentage");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceLevelDiscountTieredPercentage(
        InvoiceLevelDiscountTieredPercentage invoiceLevelDiscountTieredPercentage
    )
        : base(invoiceLevelDiscountTieredPercentage) { }
#pragma warning restore CS8618

    public InvoiceLevelDiscountTieredPercentage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.DiscountType = JsonSerializer.SerializeToElement("tiered_percentage");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceLevelDiscountTieredPercentage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceLevelDiscountTieredPercentageFromRaw.FromRawUnchecked"/>
    public static InvoiceLevelDiscountTieredPercentage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoiceLevelDiscountTieredPercentage(
        IReadOnlyList<InvoiceLevelDiscountTieredPercentageTier> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class InvoiceLevelDiscountTieredPercentageFromRaw
    : IFromRawJson<InvoiceLevelDiscountTieredPercentage>
{
    /// <inheritdoc/>
    public InvoiceLevelDiscountTieredPercentage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceLevelDiscountTieredPercentage.FromRawUnchecked(rawData);
}

/// <summary>
/// One band of a tiered percentage discount. Bounds are denominated in the discount's
/// currency. `lower_bound` is the exclusive start of the band and `upper_bound`
/// is the inclusive end; `upper_bound` is null only for the open-ended final tier.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceLevelDiscountTieredPercentageTier,
        InvoiceLevelDiscountTieredPercentageTierFromRaw
    >)
)]
public sealed record class InvoiceLevelDiscountTieredPercentageTier : JsonModel
{
    /// <summary>
    /// Exclusive lower bound of cumulative spend for this tier.
    /// </summary>
    public required double LowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("lower_bound");
        }
        init { this._rawData.Set("lower_bound", value); }
    }

    /// <summary>
    /// The percentage (between 0 and 1) discounted from spend that falls within
    /// this tier.
    /// </summary>
    public required double Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentage");
        }
        init { this._rawData.Set("percentage", value); }
    }

    /// <summary>
    /// Inclusive upper bound of cumulative spend for this tier; null for the final
    /// open-ended tier.
    /// </summary>
    public double? UpperBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upper_bound");
        }
        init { this._rawData.Set("upper_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LowerBound;
        _ = this.Percentage;
        _ = this.UpperBound;
    }

    public InvoiceLevelDiscountTieredPercentageTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceLevelDiscountTieredPercentageTier(
        InvoiceLevelDiscountTieredPercentageTier invoiceLevelDiscountTieredPercentageTier
    )
        : base(invoiceLevelDiscountTieredPercentageTier) { }
#pragma warning restore CS8618

    public InvoiceLevelDiscountTieredPercentageTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceLevelDiscountTieredPercentageTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceLevelDiscountTieredPercentageTierFromRaw.FromRawUnchecked"/>
    public static InvoiceLevelDiscountTieredPercentageTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceLevelDiscountTieredPercentageTierFromRaw
    : IFromRawJson<InvoiceLevelDiscountTieredPercentageTier>
{
    /// <inheritdoc/>
    public InvoiceLevelDiscountTieredPercentageTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceLevelDiscountTieredPercentageTier.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceLevelDiscountTieredPercentageFilter,
        InvoiceLevelDiscountTieredPercentageFilterFromRaw
    >)
)]
public sealed record class InvoiceLevelDiscountTieredPercentageFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvoiceLevelDiscountTieredPercentageFilterOperator>
            >("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public InvoiceLevelDiscountTieredPercentageFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceLevelDiscountTieredPercentageFilter(
        InvoiceLevelDiscountTieredPercentageFilter invoiceLevelDiscountTieredPercentageFilter
    )
        : base(invoiceLevelDiscountTieredPercentageFilter) { }
#pragma warning restore CS8618

    public InvoiceLevelDiscountTieredPercentageFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceLevelDiscountTieredPercentageFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceLevelDiscountTieredPercentageFilterFromRaw.FromRawUnchecked"/>
    public static InvoiceLevelDiscountTieredPercentageFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceLevelDiscountTieredPercentageFilterFromRaw
    : IFromRawJson<InvoiceLevelDiscountTieredPercentageFilter>
{
    /// <inheritdoc/>
    public InvoiceLevelDiscountTieredPercentageFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceLevelDiscountTieredPercentageFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(InvoiceLevelDiscountTieredPercentageFilterFieldConverter))]
public enum InvoiceLevelDiscountTieredPercentageFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class InvoiceLevelDiscountTieredPercentageFilterFieldConverter
    : JsonConverter<InvoiceLevelDiscountTieredPercentageFilterField>
{
    public override InvoiceLevelDiscountTieredPercentageFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => InvoiceLevelDiscountTieredPercentageFilterField.PriceID,
            "item_id" => InvoiceLevelDiscountTieredPercentageFilterField.ItemID,
            "price_type" => InvoiceLevelDiscountTieredPercentageFilterField.PriceType,
            "currency" => InvoiceLevelDiscountTieredPercentageFilterField.Currency,
            "pricing_unit_id" => InvoiceLevelDiscountTieredPercentageFilterField.PricingUnitID,
            _ => (InvoiceLevelDiscountTieredPercentageFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceLevelDiscountTieredPercentageFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceLevelDiscountTieredPercentageFilterField.PriceID => "price_id",
                InvoiceLevelDiscountTieredPercentageFilterField.ItemID => "item_id",
                InvoiceLevelDiscountTieredPercentageFilterField.PriceType => "price_type",
                InvoiceLevelDiscountTieredPercentageFilterField.Currency => "currency",
                InvoiceLevelDiscountTieredPercentageFilterField.PricingUnitID => "pricing_unit_id",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(InvoiceLevelDiscountTieredPercentageFilterOperatorConverter))]
public enum InvoiceLevelDiscountTieredPercentageFilterOperator
{
    Includes,
    Excludes,
}

sealed class InvoiceLevelDiscountTieredPercentageFilterOperatorConverter
    : JsonConverter<InvoiceLevelDiscountTieredPercentageFilterOperator>
{
    public override InvoiceLevelDiscountTieredPercentageFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => InvoiceLevelDiscountTieredPercentageFilterOperator.Includes,
            "excludes" => InvoiceLevelDiscountTieredPercentageFilterOperator.Excludes,
            _ => (InvoiceLevelDiscountTieredPercentageFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceLevelDiscountTieredPercentageFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceLevelDiscountTieredPercentageFilterOperator.Includes => "includes",
                InvoiceLevelDiscountTieredPercentageFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
