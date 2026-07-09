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

[JsonConverter(typeof(SharedDiscountConverter))]
public record class SharedDiscount : ModelBase
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
                trial: (x) => x.Reason,
                usage: (x) => x.Reason,
                amount: (x) => x.Reason,
                tieredPercentage: (x) => x.Reason
            );
        }
    }

    public SharedDiscount(PercentageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SharedDiscount(TrialDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SharedDiscount(UsageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SharedDiscount(AmountDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SharedDiscount(TieredPercentage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SharedDiscount(JsonElement element)
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
    /// type <see cref="UsageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUsage(out var value)) {
    ///     // `value` is of type `UsageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUsage([NotNullWhen(true)] out UsageDiscount? value)
    {
        value = this.Value as UsageDiscount;
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
    /// type <see cref="TieredPercentage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredPercentage(out var value)) {
    ///     // `value` is of type `TieredPercentage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredPercentage([NotNullWhen(true)] out TieredPercentage? value)
    {
        value = this.Value as TieredPercentage;
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
    ///     (TrialDiscount value) =&gt; {...},
    ///     (UsageDiscount value) =&gt; {...},
    ///     (AmountDiscount value) =&gt; {...},
    ///     (TieredPercentage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<PercentageDiscount> percentage,
        System::Action<TrialDiscount> trial,
        System::Action<UsageDiscount> usage,
        System::Action<AmountDiscount> amount,
        System::Action<TieredPercentage> tieredPercentage
    )
    {
        switch (this.Value)
        {
            case PercentageDiscount value:
                percentage(value);
                break;
            case TrialDiscount value:
                trial(value);
                break;
            case UsageDiscount value:
                usage(value);
                break;
            case AmountDiscount value:
                amount(value);
                break;
            case TieredPercentage value:
                tieredPercentage(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of SharedDiscount"
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
    ///     (TrialDiscount value) =&gt; {...},
    ///     (UsageDiscount value) =&gt; {...},
    ///     (AmountDiscount value) =&gt; {...},
    ///     (TieredPercentage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<PercentageDiscount, T> percentage,
        System::Func<TrialDiscount, T> trial,
        System::Func<UsageDiscount, T> usage,
        System::Func<AmountDiscount, T> amount,
        System::Func<TieredPercentage, T> tieredPercentage
    )
    {
        return this.Value switch
        {
            PercentageDiscount value => percentage(value),
            TrialDiscount value => trial(value),
            UsageDiscount value => usage(value),
            AmountDiscount value => amount(value),
            TieredPercentage value => tieredPercentage(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of SharedDiscount"
            ),
        };
    }

    public static implicit operator SharedDiscount(PercentageDiscount value) => new(value);

    public static implicit operator SharedDiscount(TrialDiscount value) => new(value);

    public static implicit operator SharedDiscount(UsageDiscount value) => new(value);

    public static implicit operator SharedDiscount(AmountDiscount value) => new(value);

    public static implicit operator SharedDiscount(TieredPercentage value) => new(value);

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
            throw new OrbInvalidDataException("Data did not match any variant of SharedDiscount");
        }
        this.Switch(
            (percentage) => percentage.Validate(),
            (trial) => trial.Validate(),
            (usage) => usage.Validate(),
            (amount) => amount.Validate(),
            (tieredPercentage) => tieredPercentage.Validate()
        );
    }

    public virtual bool Equals(SharedDiscount? other) =>
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
            TrialDiscount _ => 1,
            UsageDiscount _ => 2,
            AmountDiscount _ => 3,
            TieredPercentage _ => 4,
            _ => -1,
        };
    }
}

sealed class SharedDiscountConverter : JsonConverter<SharedDiscount>
{
    public override SharedDiscount? Read(
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
            case "usage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UsageDiscount>(element, options);
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
            case "tiered_percentage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredPercentage>(
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
                return new SharedDiscount(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SharedDiscount value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<TieredPercentage, TieredPercentageFromRaw>))]
public sealed record class TieredPercentage : JsonModel
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
    public required IReadOnlyList<TieredPercentageTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TieredPercentageTier>>("tiers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TieredPercentageTier>>(
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
    public IReadOnlyList<TieredPercentageFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TieredPercentageFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TieredPercentageFilter>?>(
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

    public TieredPercentage()
    {
        this.DiscountType = JsonSerializer.SerializeToElement("tiered_percentage");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TieredPercentage(TieredPercentage tieredPercentage)
        : base(tieredPercentage) { }
#pragma warning restore CS8618

    public TieredPercentage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.DiscountType = JsonSerializer.SerializeToElement("tiered_percentage");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredPercentage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TieredPercentageFromRaw.FromRawUnchecked"/>
    public static TieredPercentage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TieredPercentage(IReadOnlyList<TieredPercentageTier> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

class TieredPercentageFromRaw : IFromRawJson<TieredPercentage>
{
    /// <inheritdoc/>
    public TieredPercentage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TieredPercentage.FromRawUnchecked(rawData);
}

/// <summary>
/// One band of a tiered percentage discount. Bounds are denominated in the discount's
/// currency. `lower_bound` is the exclusive start of the band and `upper_bound`
/// is the inclusive end; `upper_bound` is null only for the open-ended final tier.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TieredPercentageTier, TieredPercentageTierFromRaw>))]
public sealed record class TieredPercentageTier : JsonModel
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

    public TieredPercentageTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TieredPercentageTier(TieredPercentageTier tieredPercentageTier)
        : base(tieredPercentageTier) { }
#pragma warning restore CS8618

    public TieredPercentageTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredPercentageTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TieredPercentageTierFromRaw.FromRawUnchecked"/>
    public static TieredPercentageTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredPercentageTierFromRaw : IFromRawJson<TieredPercentageTier>
{
    /// <inheritdoc/>
    public TieredPercentageTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TieredPercentageTier.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TieredPercentageFilter, TieredPercentageFilterFromRaw>))]
public sealed record class TieredPercentageFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, TieredPercentageFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TieredPercentageFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, TieredPercentageFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TieredPercentageFilterOperator>>(
                "operator"
            );
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

    public TieredPercentageFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TieredPercentageFilter(TieredPercentageFilter tieredPercentageFilter)
        : base(tieredPercentageFilter) { }
#pragma warning restore CS8618

    public TieredPercentageFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredPercentageFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TieredPercentageFilterFromRaw.FromRawUnchecked"/>
    public static TieredPercentageFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredPercentageFilterFromRaw : IFromRawJson<TieredPercentageFilter>
{
    /// <inheritdoc/>
    public TieredPercentageFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TieredPercentageFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(TieredPercentageFilterFieldConverter))]
public enum TieredPercentageFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class TieredPercentageFilterFieldConverter : JsonConverter<TieredPercentageFilterField>
{
    public override TieredPercentageFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => TieredPercentageFilterField.PriceID,
            "item_id" => TieredPercentageFilterField.ItemID,
            "price_type" => TieredPercentageFilterField.PriceType,
            "currency" => TieredPercentageFilterField.Currency,
            "pricing_unit_id" => TieredPercentageFilterField.PricingUnitID,
            _ => (TieredPercentageFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TieredPercentageFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TieredPercentageFilterField.PriceID => "price_id",
                TieredPercentageFilterField.ItemID => "item_id",
                TieredPercentageFilterField.PriceType => "price_type",
                TieredPercentageFilterField.Currency => "currency",
                TieredPercentageFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(TieredPercentageFilterOperatorConverter))]
public enum TieredPercentageFilterOperator
{
    Includes,
    Excludes,
}

sealed class TieredPercentageFilterOperatorConverter : JsonConverter<TieredPercentageFilterOperator>
{
    public override TieredPercentageFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => TieredPercentageFilterOperator.Includes,
            "excludes" => TieredPercentageFilterOperator.Excludes,
            _ => (TieredPercentageFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TieredPercentageFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TieredPercentageFilterOperator.Includes => "includes",
                TieredPercentageFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
