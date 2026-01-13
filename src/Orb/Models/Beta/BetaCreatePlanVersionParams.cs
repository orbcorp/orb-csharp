using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Beta;

/// <summary>
/// This endpoint allows the creation of a new plan version for an existing plan.
/// </summary>
public sealed record class BetaCreatePlanVersionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PlanID { get; init; }

    /// <summary>
    /// New version number.
    /// </summary>
    public required long Version
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("version");
        }
        init { this._rawBodyData.Set("version", value); }
    }

    /// <summary>
    /// Additional adjustments to be added to the plan.
    /// </summary>
    public IReadOnlyList<AddAdjustment>? AddAdjustments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AddAdjustment>>(
                "add_adjustments"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AddAdjustment>?>(
                "add_adjustments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Additional prices to be added to the plan.
    /// </summary>
    public IReadOnlyList<AddPrice>? AddPrices
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<AddPrice>>("add_prices");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<AddPrice>?>(
                "add_prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Adjustments to be removed from the plan.
    /// </summary>
    public IReadOnlyList<RemoveAdjustment>? RemoveAdjustments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<RemoveAdjustment>>(
                "remove_adjustments"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<RemoveAdjustment>?>(
                "remove_adjustments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Prices to be removed from the plan.
    /// </summary>
    public IReadOnlyList<RemovePrice>? RemovePrices
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<RemovePrice>>(
                "remove_prices"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<RemovePrice>?>(
                "remove_prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Adjustments to be replaced with additional adjustments on the plan.
    /// </summary>
    public IReadOnlyList<ReplaceAdjustment>? ReplaceAdjustments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ReplaceAdjustment>>(
                "replace_adjustments"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ReplaceAdjustment>?>(
                "replace_adjustments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Prices to be replaced with additional prices on the plan.
    /// </summary>
    public IReadOnlyList<ReplacePrice>? ReplacePrices
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ReplacePrice>>(
                "replace_prices"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ReplacePrice>?>(
                "replace_prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Set this new plan version as the default
    /// </summary>
    public bool? SetAsDefault
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("set_as_default");
        }
        init { this._rawBodyData.Set("set_as_default", value); }
    }

    public BetaCreatePlanVersionParams() { }

    public BetaCreatePlanVersionParams(BetaCreatePlanVersionParams betaCreatePlanVersionParams)
        : base(betaCreatePlanVersionParams)
    {
        this.PlanID = betaCreatePlanVersionParams.PlanID;

        this._rawBodyData = new(betaCreatePlanVersionParams._rawBodyData);
    }

    public BetaCreatePlanVersionParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCreatePlanVersionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static BetaCreatePlanVersionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/plans/{0}/versions", this.PlanID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(JsonModelConverter<AddAdjustment, AddAdjustmentFromRaw>))]
public sealed record class AddAdjustment : JsonModel
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required global::Orb.Models.Beta.Adjustment Adjustment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Beta.Adjustment>("adjustment");
        }
        init { this._rawData.Set("adjustment", value); }
    }

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.PlanPhaseOrder;
    }

    public AddAdjustment() { }

    public AddAdjustment(AddAdjustment addAdjustment)
        : base(addAdjustment) { }

    public AddAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddAdjustmentFromRaw.FromRawUnchecked"/>
    public static AddAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddAdjustment(global::Orb.Models.Beta.Adjustment adjustment)
        : this()
    {
        this.Adjustment = adjustment;
    }
}

class AddAdjustmentFromRaw : IFromRawJson<AddAdjustment>
{
    /// <inheritdoc/>
    public AddAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.AdjustmentConverter))]
public record class Adjustment : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newPercentageDiscount: (x) => x.Currency,
                newUsageDiscount: (x) => x.Currency,
                newAmountDiscount: (x) => x.Currency,
                newMinimum: (x) => x.Currency,
                newMaximum: (x) => x.Currency
            );
        }
    }

    public bool? IsInvoiceLevel
    {
        get
        {
            return Match<bool?>(
                newPercentageDiscount: (x) => x.IsInvoiceLevel,
                newUsageDiscount: (x) => x.IsInvoiceLevel,
                newAmountDiscount: (x) => x.IsInvoiceLevel,
                newMinimum: (x) => x.IsInvoiceLevel,
                newMaximum: (x) => x.IsInvoiceLevel
            );
        }
    }

    public Adjustment(NewPercentageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(NewUsageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(NewAmountDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(NewMinimum value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(NewMaximum value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Adjustment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPercentageDiscount(out var value)) {
    ///     // `value` is of type `NewPercentageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = this.Value as NewPercentageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewUsageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewUsageDiscount(out var value)) {
    ///     // `value` is of type `NewUsageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = this.Value as NewUsageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewAmountDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewAmountDiscount(out var value)) {
    ///     // `value` is of type `NewAmountDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = this.Value as NewAmountDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewMinimum"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewMinimum(out var value)) {
    ///     // `value` is of type `NewMinimum`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = this.Value as NewMinimum;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewMaximum"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewMaximum(out var value)) {
    ///     // `value` is of type `NewMaximum`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = this.Value as NewMaximum;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (NewPercentageDiscount value) => {...},
    ///     (NewUsageDiscount value) => {...},
    ///     (NewAmountDiscount value) => {...},
    ///     (NewMinimum value) => {...},
    ///     (NewMaximum value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewPercentageDiscount> newPercentageDiscount,
        System::Action<NewUsageDiscount> newUsageDiscount,
        System::Action<NewAmountDiscount> newAmountDiscount,
        System::Action<NewMinimum> newMinimum,
        System::Action<NewMaximum> newMaximum
    )
    {
        switch (this.Value)
        {
            case NewPercentageDiscount value:
                newPercentageDiscount(value);
                break;
            case NewUsageDiscount value:
                newUsageDiscount(value);
                break;
            case NewAmountDiscount value:
                newAmountDiscount(value);
                break;
            case NewMinimum value:
                newMinimum(value);
                break;
            case NewMaximum value:
                newMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (NewPercentageDiscount value) => {...},
    ///     (NewUsageDiscount value) => {...},
    ///     (NewAmountDiscount value) => {...},
    ///     (NewMinimum value) => {...},
    ///     (NewMaximum value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewPercentageDiscount, T> newPercentageDiscount,
        System::Func<NewUsageDiscount, T> newUsageDiscount,
        System::Func<NewAmountDiscount, T> newAmountDiscount,
        System::Func<NewMinimum, T> newMinimum,
        System::Func<NewMaximum, T> newMaximum
    )
    {
        return this.Value switch
        {
            NewPercentageDiscount value => newPercentageDiscount(value),
            NewUsageDiscount value => newUsageDiscount(value),
            NewAmountDiscount value => newAmountDiscount(value),
            NewMinimum value => newMinimum(value),
            NewMaximum value => newMaximum(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment"),
        };
    }

    public static implicit operator global::Orb.Models.Beta.Adjustment(
        NewPercentageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Adjustment(NewUsageDiscount value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.Adjustment(NewAmountDiscount value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.Adjustment(NewMinimum value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.Adjustment(NewMaximum value) =>
        new(value);

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
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
        this.Switch(
            (newPercentageDiscount) => newPercentageDiscount.Validate(),
            (newUsageDiscount) => newUsageDiscount.Validate(),
            (newAmountDiscount) => newAmountDiscount.Validate(),
            (newMinimum) => newMinimum.Validate(),
            (newMaximum) => newMaximum.Validate()
        );
    }

    public virtual bool Equals(global::Orb.Models.Beta.Adjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class AdjustmentConverter : JsonConverter<global::Orb.Models.Beta.Adjustment>
{
    public override global::Orb.Models.Beta.Adjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = element.GetProperty("adjustment_type").GetString();
        }
        catch
        {
            adjustmentType = null;
        }

        switch (adjustmentType)
        {
            case "percentage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "usage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "amount_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "maximum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new global::Orb.Models.Beta.Adjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Adjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<AddPrice, AddPriceFromRaw>))]
public sealed record class AddPrice : JsonModel
{
    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewAllocationPrice>("allocation_price");
        }
        init { this._rawData.Set("allocation_price", value); }
    }

    /// <summary>
    /// The phase to add this price to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <summary>
    /// New plan price request body params.
    /// </summary>
    public global::Orb.Models.Beta.Price? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Orb.Models.Beta.Price>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public AddPrice() { }

    public AddPrice(AddPrice addPrice)
        : base(addPrice) { }

    public AddPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddPriceFromRaw.FromRawUnchecked"/>
    public static AddPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceFromRaw : IFromRawJson<AddPrice>
{
    /// <inheritdoc/>
    public AddPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// New plan price request body params.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.PriceConverter))]
public record class Price : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string ItemID
    {
        get
        {
            return Match(
                newPlanUnit: (x) => x.ItemID,
                newPlanTiered: (x) => x.ItemID,
                newPlanBulk: (x) => x.ItemID,
                bulkWithFilters: (x) => x.ItemID,
                newPlanPackage: (x) => x.ItemID,
                newPlanMatrix: (x) => x.ItemID,
                newPlanThresholdTotalAmount: (x) => x.ItemID,
                newPlanTieredPackage: (x) => x.ItemID,
                newPlanTieredWithMinimum: (x) => x.ItemID,
                newPlanGroupedTiered: (x) => x.ItemID,
                newPlanTieredPackageWithMinimum: (x) => x.ItemID,
                newPlanPackageWithAllocation: (x) => x.ItemID,
                newPlanUnitWithPercent: (x) => x.ItemID,
                newPlanMatrixWithAllocation: (x) => x.ItemID,
                tieredWithProration: (x) => x.ItemID,
                newPlanUnitWithProration: (x) => x.ItemID,
                newPlanGroupedAllocation: (x) => x.ItemID,
                newPlanBulkWithProration: (x) => x.ItemID,
                newPlanGroupedWithProratedMinimum: (x) => x.ItemID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ItemID,
                groupedWithMinMaxThresholds: (x) => x.ItemID,
                newPlanMatrixWithDisplayName: (x) => x.ItemID,
                newPlanGroupedTieredPackage: (x) => x.ItemID,
                newPlanMaxGroupTieredPackage: (x) => x.ItemID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ItemID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ItemID,
                newPlanCumulativeGroupedBulk: (x) => x.ItemID,
                cumulativeGroupedAllocation: (x) => x.ItemID,
                newPlanMinimumComposite: (x) => x.ItemID,
                percent: (x) => x.ItemID,
                eventOutput: (x) => x.ItemID
            );
        }
    }

    public string Name
    {
        get
        {
            return Match(
                newPlanUnit: (x) => x.Name,
                newPlanTiered: (x) => x.Name,
                newPlanBulk: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                newPlanPackage: (x) => x.Name,
                newPlanMatrix: (x) => x.Name,
                newPlanThresholdTotalAmount: (x) => x.Name,
                newPlanTieredPackage: (x) => x.Name,
                newPlanTieredWithMinimum: (x) => x.Name,
                newPlanGroupedTiered: (x) => x.Name,
                newPlanTieredPackageWithMinimum: (x) => x.Name,
                newPlanPackageWithAllocation: (x) => x.Name,
                newPlanUnitWithPercent: (x) => x.Name,
                newPlanMatrixWithAllocation: (x) => x.Name,
                tieredWithProration: (x) => x.Name,
                newPlanUnitWithProration: (x) => x.Name,
                newPlanGroupedAllocation: (x) => x.Name,
                newPlanBulkWithProration: (x) => x.Name,
                newPlanGroupedWithProratedMinimum: (x) => x.Name,
                newPlanGroupedWithMeteredMinimum: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                newPlanMatrixWithDisplayName: (x) => x.Name,
                newPlanGroupedTieredPackage: (x) => x.Name,
                newPlanMaxGroupTieredPackage: (x) => x.Name,
                newPlanScalableMatrixWithUnitPricing: (x) => x.Name,
                newPlanScalableMatrixWithTieredPricing: (x) => x.Name,
                newPlanCumulativeGroupedBulk: (x) => x.Name,
                cumulativeGroupedAllocation: (x) => x.Name,
                newPlanMinimumComposite: (x) => x.Name,
                percent: (x) => x.Name,
                eventOutput: (x) => x.Name
            );
        }
    }

    public string? BillableMetricID
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.BillableMetricID,
                newPlanTiered: (x) => x.BillableMetricID,
                newPlanBulk: (x) => x.BillableMetricID,
                bulkWithFilters: (x) => x.BillableMetricID,
                newPlanPackage: (x) => x.BillableMetricID,
                newPlanMatrix: (x) => x.BillableMetricID,
                newPlanThresholdTotalAmount: (x) => x.BillableMetricID,
                newPlanTieredPackage: (x) => x.BillableMetricID,
                newPlanTieredWithMinimum: (x) => x.BillableMetricID,
                newPlanGroupedTiered: (x) => x.BillableMetricID,
                newPlanTieredPackageWithMinimum: (x) => x.BillableMetricID,
                newPlanPackageWithAllocation: (x) => x.BillableMetricID,
                newPlanUnitWithPercent: (x) => x.BillableMetricID,
                newPlanMatrixWithAllocation: (x) => x.BillableMetricID,
                tieredWithProration: (x) => x.BillableMetricID,
                newPlanUnitWithProration: (x) => x.BillableMetricID,
                newPlanGroupedAllocation: (x) => x.BillableMetricID,
                newPlanBulkWithProration: (x) => x.BillableMetricID,
                newPlanGroupedWithProratedMinimum: (x) => x.BillableMetricID,
                newPlanGroupedWithMeteredMinimum: (x) => x.BillableMetricID,
                groupedWithMinMaxThresholds: (x) => x.BillableMetricID,
                newPlanMatrixWithDisplayName: (x) => x.BillableMetricID,
                newPlanGroupedTieredPackage: (x) => x.BillableMetricID,
                newPlanMaxGroupTieredPackage: (x) => x.BillableMetricID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BillableMetricID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BillableMetricID,
                newPlanCumulativeGroupedBulk: (x) => x.BillableMetricID,
                cumulativeGroupedAllocation: (x) => x.BillableMetricID,
                newPlanMinimumComposite: (x) => x.BillableMetricID,
                percent: (x) => x.BillableMetricID,
                eventOutput: (x) => x.BillableMetricID
            );
        }
    }

    public bool? BilledInAdvance
    {
        get
        {
            return Match<bool?>(
                newPlanUnit: (x) => x.BilledInAdvance,
                newPlanTiered: (x) => x.BilledInAdvance,
                newPlanBulk: (x) => x.BilledInAdvance,
                bulkWithFilters: (x) => x.BilledInAdvance,
                newPlanPackage: (x) => x.BilledInAdvance,
                newPlanMatrix: (x) => x.BilledInAdvance,
                newPlanThresholdTotalAmount: (x) => x.BilledInAdvance,
                newPlanTieredPackage: (x) => x.BilledInAdvance,
                newPlanTieredWithMinimum: (x) => x.BilledInAdvance,
                newPlanGroupedTiered: (x) => x.BilledInAdvance,
                newPlanTieredPackageWithMinimum: (x) => x.BilledInAdvance,
                newPlanPackageWithAllocation: (x) => x.BilledInAdvance,
                newPlanUnitWithPercent: (x) => x.BilledInAdvance,
                newPlanMatrixWithAllocation: (x) => x.BilledInAdvance,
                tieredWithProration: (x) => x.BilledInAdvance,
                newPlanUnitWithProration: (x) => x.BilledInAdvance,
                newPlanGroupedAllocation: (x) => x.BilledInAdvance,
                newPlanBulkWithProration: (x) => x.BilledInAdvance,
                newPlanGroupedWithProratedMinimum: (x) => x.BilledInAdvance,
                newPlanGroupedWithMeteredMinimum: (x) => x.BilledInAdvance,
                groupedWithMinMaxThresholds: (x) => x.BilledInAdvance,
                newPlanMatrixWithDisplayName: (x) => x.BilledInAdvance,
                newPlanGroupedTieredPackage: (x) => x.BilledInAdvance,
                newPlanMaxGroupTieredPackage: (x) => x.BilledInAdvance,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BilledInAdvance,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BilledInAdvance,
                newPlanCumulativeGroupedBulk: (x) => x.BilledInAdvance,
                cumulativeGroupedAllocation: (x) => x.BilledInAdvance,
                newPlanMinimumComposite: (x) => x.BilledInAdvance,
                percent: (x) => x.BilledInAdvance,
                eventOutput: (x) => x.BilledInAdvance
            );
        }
    }

    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return Match<NewBillingCycleConfiguration?>(
                newPlanUnit: (x) => x.BillingCycleConfiguration,
                newPlanTiered: (x) => x.BillingCycleConfiguration,
                newPlanBulk: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                newPlanPackage: (x) => x.BillingCycleConfiguration,
                newPlanMatrix: (x) => x.BillingCycleConfiguration,
                newPlanThresholdTotalAmount: (x) => x.BillingCycleConfiguration,
                newPlanTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanTieredWithMinimum: (x) => x.BillingCycleConfiguration,
                newPlanGroupedTiered: (x) => x.BillingCycleConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.BillingCycleConfiguration,
                newPlanPackageWithAllocation: (x) => x.BillingCycleConfiguration,
                newPlanUnitWithPercent: (x) => x.BillingCycleConfiguration,
                newPlanMatrixWithAllocation: (x) => x.BillingCycleConfiguration,
                tieredWithProration: (x) => x.BillingCycleConfiguration,
                newPlanUnitWithProration: (x) => x.BillingCycleConfiguration,
                newPlanGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newPlanBulkWithProration: (x) => x.BillingCycleConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.BillingCycleConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.BillingCycleConfiguration,
                newPlanGroupedTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BillingCycleConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BillingCycleConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.BillingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newPlanMinimumComposite: (x) => x.BillingCycleConfiguration,
                percent: (x) => x.BillingCycleConfiguration,
                eventOutput: (x) => x.BillingCycleConfiguration
            );
        }
    }

    public double? ConversionRate
    {
        get
        {
            return Match<double?>(
                newPlanUnit: (x) => x.ConversionRate,
                newPlanTiered: (x) => x.ConversionRate,
                newPlanBulk: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                newPlanPackage: (x) => x.ConversionRate,
                newPlanMatrix: (x) => x.ConversionRate,
                newPlanThresholdTotalAmount: (x) => x.ConversionRate,
                newPlanTieredPackage: (x) => x.ConversionRate,
                newPlanTieredWithMinimum: (x) => x.ConversionRate,
                newPlanGroupedTiered: (x) => x.ConversionRate,
                newPlanTieredPackageWithMinimum: (x) => x.ConversionRate,
                newPlanPackageWithAllocation: (x) => x.ConversionRate,
                newPlanUnitWithPercent: (x) => x.ConversionRate,
                newPlanMatrixWithAllocation: (x) => x.ConversionRate,
                tieredWithProration: (x) => x.ConversionRate,
                newPlanUnitWithProration: (x) => x.ConversionRate,
                newPlanGroupedAllocation: (x) => x.ConversionRate,
                newPlanBulkWithProration: (x) => x.ConversionRate,
                newPlanGroupedWithProratedMinimum: (x) => x.ConversionRate,
                newPlanGroupedWithMeteredMinimum: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                newPlanMatrixWithDisplayName: (x) => x.ConversionRate,
                newPlanGroupedTieredPackage: (x) => x.ConversionRate,
                newPlanMaxGroupTieredPackage: (x) => x.ConversionRate,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ConversionRate,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ConversionRate,
                newPlanCumulativeGroupedBulk: (x) => x.ConversionRate,
                cumulativeGroupedAllocation: (x) => x.ConversionRate,
                newPlanMinimumComposite: (x) => x.ConversionRate,
                percent: (x) => x.ConversionRate,
                eventOutput: (x) => x.ConversionRate
            );
        }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.Currency,
                newPlanTiered: (x) => x.Currency,
                newPlanBulk: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                newPlanPackage: (x) => x.Currency,
                newPlanMatrix: (x) => x.Currency,
                newPlanThresholdTotalAmount: (x) => x.Currency,
                newPlanTieredPackage: (x) => x.Currency,
                newPlanTieredWithMinimum: (x) => x.Currency,
                newPlanGroupedTiered: (x) => x.Currency,
                newPlanTieredPackageWithMinimum: (x) => x.Currency,
                newPlanPackageWithAllocation: (x) => x.Currency,
                newPlanUnitWithPercent: (x) => x.Currency,
                newPlanMatrixWithAllocation: (x) => x.Currency,
                tieredWithProration: (x) => x.Currency,
                newPlanUnitWithProration: (x) => x.Currency,
                newPlanGroupedAllocation: (x) => x.Currency,
                newPlanBulkWithProration: (x) => x.Currency,
                newPlanGroupedWithProratedMinimum: (x) => x.Currency,
                newPlanGroupedWithMeteredMinimum: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                newPlanMatrixWithDisplayName: (x) => x.Currency,
                newPlanGroupedTieredPackage: (x) => x.Currency,
                newPlanMaxGroupTieredPackage: (x) => x.Currency,
                newPlanScalableMatrixWithUnitPricing: (x) => x.Currency,
                newPlanScalableMatrixWithTieredPricing: (x) => x.Currency,
                newPlanCumulativeGroupedBulk: (x) => x.Currency,
                cumulativeGroupedAllocation: (x) => x.Currency,
                newPlanMinimumComposite: (x) => x.Currency,
                percent: (x) => x.Currency,
                eventOutput: (x) => x.Currency
            );
        }
    }

    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return Match<NewDimensionalPriceConfiguration?>(
                newPlanUnit: (x) => x.DimensionalPriceConfiguration,
                newPlanTiered: (x) => x.DimensionalPriceConfiguration,
                newPlanBulk: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                newPlanPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrix: (x) => x.DimensionalPriceConfiguration,
                newPlanThresholdTotalAmount: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedTiered: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanPackageWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newPlanUnitWithPercent: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrixWithAllocation: (x) => x.DimensionalPriceConfiguration,
                tieredWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanUnitWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newPlanBulkWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.DimensionalPriceConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.DimensionalPriceConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.DimensionalPriceConfiguration,
                cumulativeGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newPlanMinimumComposite: (x) => x.DimensionalPriceConfiguration,
                percent: (x) => x.DimensionalPriceConfiguration,
                eventOutput: (x) => x.DimensionalPriceConfiguration
            );
        }
    }

    public string? ExternalPriceID
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.ExternalPriceID,
                newPlanTiered: (x) => x.ExternalPriceID,
                newPlanBulk: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                newPlanPackage: (x) => x.ExternalPriceID,
                newPlanMatrix: (x) => x.ExternalPriceID,
                newPlanThresholdTotalAmount: (x) => x.ExternalPriceID,
                newPlanTieredPackage: (x) => x.ExternalPriceID,
                newPlanTieredWithMinimum: (x) => x.ExternalPriceID,
                newPlanGroupedTiered: (x) => x.ExternalPriceID,
                newPlanTieredPackageWithMinimum: (x) => x.ExternalPriceID,
                newPlanPackageWithAllocation: (x) => x.ExternalPriceID,
                newPlanUnitWithPercent: (x) => x.ExternalPriceID,
                newPlanMatrixWithAllocation: (x) => x.ExternalPriceID,
                tieredWithProration: (x) => x.ExternalPriceID,
                newPlanUnitWithProration: (x) => x.ExternalPriceID,
                newPlanGroupedAllocation: (x) => x.ExternalPriceID,
                newPlanBulkWithProration: (x) => x.ExternalPriceID,
                newPlanGroupedWithProratedMinimum: (x) => x.ExternalPriceID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                newPlanMatrixWithDisplayName: (x) => x.ExternalPriceID,
                newPlanGroupedTieredPackage: (x) => x.ExternalPriceID,
                newPlanMaxGroupTieredPackage: (x) => x.ExternalPriceID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ExternalPriceID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ExternalPriceID,
                newPlanCumulativeGroupedBulk: (x) => x.ExternalPriceID,
                cumulativeGroupedAllocation: (x) => x.ExternalPriceID,
                newPlanMinimumComposite: (x) => x.ExternalPriceID,
                percent: (x) => x.ExternalPriceID,
                eventOutput: (x) => x.ExternalPriceID
            );
        }
    }

    public double? FixedPriceQuantity
    {
        get
        {
            return Match<double?>(
                newPlanUnit: (x) => x.FixedPriceQuantity,
                newPlanTiered: (x) => x.FixedPriceQuantity,
                newPlanBulk: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                newPlanPackage: (x) => x.FixedPriceQuantity,
                newPlanMatrix: (x) => x.FixedPriceQuantity,
                newPlanThresholdTotalAmount: (x) => x.FixedPriceQuantity,
                newPlanTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanTieredWithMinimum: (x) => x.FixedPriceQuantity,
                newPlanGroupedTiered: (x) => x.FixedPriceQuantity,
                newPlanTieredPackageWithMinimum: (x) => x.FixedPriceQuantity,
                newPlanPackageWithAllocation: (x) => x.FixedPriceQuantity,
                newPlanUnitWithPercent: (x) => x.FixedPriceQuantity,
                newPlanMatrixWithAllocation: (x) => x.FixedPriceQuantity,
                tieredWithProration: (x) => x.FixedPriceQuantity,
                newPlanUnitWithProration: (x) => x.FixedPriceQuantity,
                newPlanGroupedAllocation: (x) => x.FixedPriceQuantity,
                newPlanBulkWithProration: (x) => x.FixedPriceQuantity,
                newPlanGroupedWithProratedMinimum: (x) => x.FixedPriceQuantity,
                newPlanGroupedWithMeteredMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                newPlanMatrixWithDisplayName: (x) => x.FixedPriceQuantity,
                newPlanGroupedTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanMaxGroupTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanScalableMatrixWithUnitPricing: (x) => x.FixedPriceQuantity,
                newPlanScalableMatrixWithTieredPricing: (x) => x.FixedPriceQuantity,
                newPlanCumulativeGroupedBulk: (x) => x.FixedPriceQuantity,
                cumulativeGroupedAllocation: (x) => x.FixedPriceQuantity,
                newPlanMinimumComposite: (x) => x.FixedPriceQuantity,
                percent: (x) => x.FixedPriceQuantity,
                eventOutput: (x) => x.FixedPriceQuantity
            );
        }
    }

    public string? InvoiceGroupingKey
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.InvoiceGroupingKey,
                newPlanTiered: (x) => x.InvoiceGroupingKey,
                newPlanBulk: (x) => x.InvoiceGroupingKey,
                bulkWithFilters: (x) => x.InvoiceGroupingKey,
                newPlanPackage: (x) => x.InvoiceGroupingKey,
                newPlanMatrix: (x) => x.InvoiceGroupingKey,
                newPlanThresholdTotalAmount: (x) => x.InvoiceGroupingKey,
                newPlanTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanTieredWithMinimum: (x) => x.InvoiceGroupingKey,
                newPlanGroupedTiered: (x) => x.InvoiceGroupingKey,
                newPlanTieredPackageWithMinimum: (x) => x.InvoiceGroupingKey,
                newPlanPackageWithAllocation: (x) => x.InvoiceGroupingKey,
                newPlanUnitWithPercent: (x) => x.InvoiceGroupingKey,
                newPlanMatrixWithAllocation: (x) => x.InvoiceGroupingKey,
                tieredWithProration: (x) => x.InvoiceGroupingKey,
                newPlanUnitWithProration: (x) => x.InvoiceGroupingKey,
                newPlanGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newPlanBulkWithProration: (x) => x.InvoiceGroupingKey,
                newPlanGroupedWithProratedMinimum: (x) => x.InvoiceGroupingKey,
                newPlanGroupedWithMeteredMinimum: (x) => x.InvoiceGroupingKey,
                groupedWithMinMaxThresholds: (x) => x.InvoiceGroupingKey,
                newPlanMatrixWithDisplayName: (x) => x.InvoiceGroupingKey,
                newPlanGroupedTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanMaxGroupTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanScalableMatrixWithUnitPricing: (x) => x.InvoiceGroupingKey,
                newPlanScalableMatrixWithTieredPricing: (x) => x.InvoiceGroupingKey,
                newPlanCumulativeGroupedBulk: (x) => x.InvoiceGroupingKey,
                cumulativeGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newPlanMinimumComposite: (x) => x.InvoiceGroupingKey,
                percent: (x) => x.InvoiceGroupingKey,
                eventOutput: (x) => x.InvoiceGroupingKey
            );
        }
    }

    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return Match<NewBillingCycleConfiguration?>(
                newPlanUnit: (x) => x.InvoicingCycleConfiguration,
                newPlanTiered: (x) => x.InvoicingCycleConfiguration,
                newPlanBulk: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                newPlanPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrix: (x) => x.InvoicingCycleConfiguration,
                newPlanThresholdTotalAmount: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedTiered: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanPackageWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newPlanUnitWithPercent: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrixWithAllocation: (x) => x.InvoicingCycleConfiguration,
                tieredWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanUnitWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newPlanBulkWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.InvoicingCycleConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.InvoicingCycleConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.InvoicingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newPlanMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public string? ReferenceID
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.ReferenceID,
                newPlanTiered: (x) => x.ReferenceID,
                newPlanBulk: (x) => x.ReferenceID,
                bulkWithFilters: (x) => x.ReferenceID,
                newPlanPackage: (x) => x.ReferenceID,
                newPlanMatrix: (x) => x.ReferenceID,
                newPlanThresholdTotalAmount: (x) => x.ReferenceID,
                newPlanTieredPackage: (x) => x.ReferenceID,
                newPlanTieredWithMinimum: (x) => x.ReferenceID,
                newPlanGroupedTiered: (x) => x.ReferenceID,
                newPlanTieredPackageWithMinimum: (x) => x.ReferenceID,
                newPlanPackageWithAllocation: (x) => x.ReferenceID,
                newPlanUnitWithPercent: (x) => x.ReferenceID,
                newPlanMatrixWithAllocation: (x) => x.ReferenceID,
                tieredWithProration: (x) => x.ReferenceID,
                newPlanUnitWithProration: (x) => x.ReferenceID,
                newPlanGroupedAllocation: (x) => x.ReferenceID,
                newPlanBulkWithProration: (x) => x.ReferenceID,
                newPlanGroupedWithProratedMinimum: (x) => x.ReferenceID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ReferenceID,
                groupedWithMinMaxThresholds: (x) => x.ReferenceID,
                newPlanMatrixWithDisplayName: (x) => x.ReferenceID,
                newPlanGroupedTieredPackage: (x) => x.ReferenceID,
                newPlanMaxGroupTieredPackage: (x) => x.ReferenceID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ReferenceID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ReferenceID,
                newPlanCumulativeGroupedBulk: (x) => x.ReferenceID,
                cumulativeGroupedAllocation: (x) => x.ReferenceID,
                newPlanMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public Price(NewPlanUnitPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(global::Orb.Models.Beta.BulkWithFilters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanMatrixPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanThresholdTotalAmountPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanTieredWithMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanGroupedTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanTieredPackageWithMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanPackageWithAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanUnitWithPercentPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanMatrixWithAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(global::Orb.Models.Beta.TieredWithProration value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanUnitWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanGroupedAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanBulkWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanGroupedWithProratedMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanGroupedWithMeteredMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(
        global::Orb.Models.Beta.GroupedWithMinMaxThresholds value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanMatrixWithDisplayNamePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanGroupedTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanMaxGroupTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanScalableMatrixWithUnitPricingPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanScalableMatrixWithTieredPricingPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanCumulativeGroupedBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(
        global::Orb.Models.Beta.CumulativeGroupedAllocation value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Price(NewPlanMinimumCompositePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(global::Orb.Models.Beta.Percent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(global::Orb.Models.Beta.EventOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Price(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanUnit(out var value)) {
    ///     // `value` is of type `NewPlanUnitPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanUnit([NotNullWhen(true)] out NewPlanUnitPrice? value)
    {
        value = this.Value as NewPlanUnitPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanTiered(out var value)) {
    ///     // `value` is of type `NewPlanTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanTiered([NotNullWhen(true)] out NewPlanTieredPrice? value)
    {
        value = this.Value as NewPlanTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanBulk(out var value)) {
    ///     // `value` is of type `NewPlanBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanBulk([NotNullWhen(true)] out NewPlanBulkPrice? value)
    {
        value = this.Value as NewPlanBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Beta.BulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Beta.BulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out global::Orb.Models.Beta.BulkWithFilters? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.BulkWithFilters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanPackage(out var value)) {
    ///     // `value` is of type `NewPlanPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanPackage([NotNullWhen(true)] out NewPlanPackagePrice? value)
    {
        value = this.Value as NewPlanPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMatrixPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMatrix(out var value)) {
    ///     // `value` is of type `NewPlanMatrixPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMatrix([NotNullWhen(true)] out NewPlanMatrixPrice? value)
    {
        value = this.Value as NewPlanMatrixPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanThresholdTotalAmountPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanThresholdTotalAmount(out var value)) {
    ///     // `value` is of type `NewPlanThresholdTotalAmountPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanThresholdTotalAmount(
        [NotNullWhen(true)] out NewPlanThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewPlanThresholdTotalAmountPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanTieredPackage(out var value)) {
    ///     // `value` is of type `NewPlanTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanTieredPackage(
        [NotNullWhen(true)] out NewPlanTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanTieredWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanTieredWithMinimum(out var value)) {
    ///     // `value` is of type `NewPlanTieredWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanTieredWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedTiered(out var value)) {
    ///     // `value` is of type `NewPlanGroupedTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedTiered(
        [NotNullWhen(true)] out NewPlanGroupedTieredPrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanTieredPackageWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanTieredPackageWithMinimum(out var value)) {
    ///     // `value` is of type `NewPlanTieredPackageWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredPackageWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanPackageWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanPackageWithAllocation(out var value)) {
    ///     // `value` is of type `NewPlanPackageWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanPackageWithAllocation(
        [NotNullWhen(true)] out NewPlanPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanPackageWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanUnitWithPercentPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanUnitWithPercent(out var value)) {
    ///     // `value` is of type `NewPlanUnitWithPercentPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanUnitWithPercent(
        [NotNullWhen(true)] out NewPlanUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithPercentPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMatrixWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMatrixWithAllocation(out var value)) {
    ///     // `value` is of type `NewPlanMatrixWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMatrixWithAllocation(
        [NotNullWhen(true)] out NewPlanMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Beta.TieredWithProration"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredWithProration(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Beta.TieredWithProration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out global::Orb.Models.Beta.TieredWithProration? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.TieredWithProration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanUnitWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanUnitWithProration(out var value)) {
    ///     // `value` is of type `NewPlanUnitWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanUnitWithProration(
        [NotNullWhen(true)] out NewPlanUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedAllocation(out var value)) {
    ///     // `value` is of type `NewPlanGroupedAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedAllocation(
        [NotNullWhen(true)] out NewPlanGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewPlanGroupedAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanBulkWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanBulkWithProration(out var value)) {
    ///     // `value` is of type `NewPlanBulkWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanBulkWithProration(
        [NotNullWhen(true)] out NewPlanBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanBulkWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedWithProratedMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedWithProratedMinimum(out var value)) {
    ///     // `value` is of type `NewPlanGroupedWithProratedMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithProratedMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedWithMeteredMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedWithMeteredMinimum(out var value)) {
    ///     // `value` is of type `NewPlanGroupedWithMeteredMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Beta.GroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Beta.GroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out global::Orb.Models.Beta.GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.GroupedWithMinMaxThresholds;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMatrixWithDisplayNamePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMatrixWithDisplayName(out var value)) {
    ///     // `value` is of type `NewPlanMatrixWithDisplayNamePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMatrixWithDisplayName(
        [NotNullWhen(true)] out NewPlanMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithDisplayNamePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedTieredPackage(out var value)) {
    ///     // `value` is of type `NewPlanGroupedTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedTieredPackage(
        [NotNullWhen(true)] out NewPlanGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMaxGroupTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMaxGroupTieredPackage(out var value)) {
    ///     // `value` is of type `NewPlanMaxGroupTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewPlanMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanMaxGroupTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanScalableMatrixWithUnitPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanScalableMatrixWithUnitPricing(out var value)) {
    ///     // `value` is of type `NewPlanScalableMatrixWithUnitPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanScalableMatrixWithTieredPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanScalableMatrixWithTieredPricing(out var value)) {
    ///     // `value` is of type `NewPlanScalableMatrixWithTieredPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanCumulativeGroupedBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanCumulativeGroupedBulk(out var value)) {
    ///     // `value` is of type `NewPlanCumulativeGroupedBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewPlanCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewPlanCumulativeGroupedBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Beta.CumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Beta.CumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out global::Orb.Models.Beta.CumulativeGroupedAllocation? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.CumulativeGroupedAllocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMinimumCompositePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMinimumComposite(out var value)) {
    ///     // `value` is of type `NewPlanMinimumCompositePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = this.Value as NewPlanMinimumCompositePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Beta.Percent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Beta.Percent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent([NotNullWhen(true)] out global::Orb.Models.Beta.Percent? value)
    {
        value = this.Value as global::Orb.Models.Beta.Percent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="global::Orb.Models.Beta.EventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `global::Orb.Models.Beta.EventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput(
        [NotNullWhen(true)] out global::Orb.Models.Beta.EventOutput? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.EventOutput;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (NewPlanUnitPrice value) => {...},
    ///     (NewPlanTieredPrice value) => {...},
    ///     (NewPlanBulkPrice value) => {...},
    ///     (global::Orb.Models.Beta.BulkWithFilters value) => {...},
    ///     (NewPlanPackagePrice value) => {...},
    ///     (NewPlanMatrixPrice value) => {...},
    ///     (NewPlanThresholdTotalAmountPrice value) => {...},
    ///     (NewPlanTieredPackagePrice value) => {...},
    ///     (NewPlanTieredWithMinimumPrice value) => {...},
    ///     (NewPlanGroupedTieredPrice value) => {...},
    ///     (NewPlanTieredPackageWithMinimumPrice value) => {...},
    ///     (NewPlanPackageWithAllocationPrice value) => {...},
    ///     (NewPlanUnitWithPercentPrice value) => {...},
    ///     (NewPlanMatrixWithAllocationPrice value) => {...},
    ///     (global::Orb.Models.Beta.TieredWithProration value) => {...},
    ///     (NewPlanUnitWithProrationPrice value) => {...},
    ///     (NewPlanGroupedAllocationPrice value) => {...},
    ///     (NewPlanBulkWithProrationPrice value) => {...},
    ///     (NewPlanGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewPlanGroupedWithMeteredMinimumPrice value) => {...},
    ///     (global::Orb.Models.Beta.GroupedWithMinMaxThresholds value) => {...},
    ///     (NewPlanMatrixWithDisplayNamePrice value) => {...},
    ///     (NewPlanGroupedTieredPackagePrice value) => {...},
    ///     (NewPlanMaxGroupTieredPackagePrice value) => {...},
    ///     (NewPlanScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewPlanScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewPlanCumulativeGroupedBulkPrice value) => {...},
    ///     (global::Orb.Models.Beta.CumulativeGroupedAllocation value) => {...},
    ///     (NewPlanMinimumCompositePrice value) => {...},
    ///     (global::Orb.Models.Beta.Percent value) => {...},
    ///     (global::Orb.Models.Beta.EventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewPlanUnitPrice> newPlanUnit,
        System::Action<NewPlanTieredPrice> newPlanTiered,
        System::Action<NewPlanBulkPrice> newPlanBulk,
        System::Action<global::Orb.Models.Beta.BulkWithFilters> bulkWithFilters,
        System::Action<NewPlanPackagePrice> newPlanPackage,
        System::Action<NewPlanMatrixPrice> newPlanMatrix,
        System::Action<NewPlanThresholdTotalAmountPrice> newPlanThresholdTotalAmount,
        System::Action<NewPlanTieredPackagePrice> newPlanTieredPackage,
        System::Action<NewPlanTieredWithMinimumPrice> newPlanTieredWithMinimum,
        System::Action<NewPlanGroupedTieredPrice> newPlanGroupedTiered,
        System::Action<NewPlanTieredPackageWithMinimumPrice> newPlanTieredPackageWithMinimum,
        System::Action<NewPlanPackageWithAllocationPrice> newPlanPackageWithAllocation,
        System::Action<NewPlanUnitWithPercentPrice> newPlanUnitWithPercent,
        System::Action<NewPlanMatrixWithAllocationPrice> newPlanMatrixWithAllocation,
        System::Action<global::Orb.Models.Beta.TieredWithProration> tieredWithProration,
        System::Action<NewPlanUnitWithProrationPrice> newPlanUnitWithProration,
        System::Action<NewPlanGroupedAllocationPrice> newPlanGroupedAllocation,
        System::Action<NewPlanBulkWithProrationPrice> newPlanBulkWithProration,
        System::Action<NewPlanGroupedWithProratedMinimumPrice> newPlanGroupedWithProratedMinimum,
        System::Action<NewPlanGroupedWithMeteredMinimumPrice> newPlanGroupedWithMeteredMinimum,
        System::Action<global::Orb.Models.Beta.GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewPlanMatrixWithDisplayNamePrice> newPlanMatrixWithDisplayName,
        System::Action<NewPlanGroupedTieredPackagePrice> newPlanGroupedTieredPackage,
        System::Action<NewPlanMaxGroupTieredPackagePrice> newPlanMaxGroupTieredPackage,
        System::Action<NewPlanScalableMatrixWithUnitPricingPrice> newPlanScalableMatrixWithUnitPricing,
        System::Action<NewPlanScalableMatrixWithTieredPricingPrice> newPlanScalableMatrixWithTieredPricing,
        System::Action<NewPlanCumulativeGroupedBulkPrice> newPlanCumulativeGroupedBulk,
        System::Action<global::Orb.Models.Beta.CumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewPlanMinimumCompositePrice> newPlanMinimumComposite,
        System::Action<global::Orb.Models.Beta.Percent> percent,
        System::Action<global::Orb.Models.Beta.EventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case NewPlanUnitPrice value:
                newPlanUnit(value);
                break;
            case NewPlanTieredPrice value:
                newPlanTiered(value);
                break;
            case NewPlanBulkPrice value:
                newPlanBulk(value);
                break;
            case global::Orb.Models.Beta.BulkWithFilters value:
                bulkWithFilters(value);
                break;
            case NewPlanPackagePrice value:
                newPlanPackage(value);
                break;
            case NewPlanMatrixPrice value:
                newPlanMatrix(value);
                break;
            case NewPlanThresholdTotalAmountPrice value:
                newPlanThresholdTotalAmount(value);
                break;
            case NewPlanTieredPackagePrice value:
                newPlanTieredPackage(value);
                break;
            case NewPlanTieredWithMinimumPrice value:
                newPlanTieredWithMinimum(value);
                break;
            case NewPlanGroupedTieredPrice value:
                newPlanGroupedTiered(value);
                break;
            case NewPlanTieredPackageWithMinimumPrice value:
                newPlanTieredPackageWithMinimum(value);
                break;
            case NewPlanPackageWithAllocationPrice value:
                newPlanPackageWithAllocation(value);
                break;
            case NewPlanUnitWithPercentPrice value:
                newPlanUnitWithPercent(value);
                break;
            case NewPlanMatrixWithAllocationPrice value:
                newPlanMatrixWithAllocation(value);
                break;
            case global::Orb.Models.Beta.TieredWithProration value:
                tieredWithProration(value);
                break;
            case NewPlanUnitWithProrationPrice value:
                newPlanUnitWithProration(value);
                break;
            case NewPlanGroupedAllocationPrice value:
                newPlanGroupedAllocation(value);
                break;
            case NewPlanBulkWithProrationPrice value:
                newPlanBulkWithProration(value);
                break;
            case NewPlanGroupedWithProratedMinimumPrice value:
                newPlanGroupedWithProratedMinimum(value);
                break;
            case NewPlanGroupedWithMeteredMinimumPrice value:
                newPlanGroupedWithMeteredMinimum(value);
                break;
            case global::Orb.Models.Beta.GroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case NewPlanMatrixWithDisplayNamePrice value:
                newPlanMatrixWithDisplayName(value);
                break;
            case NewPlanGroupedTieredPackagePrice value:
                newPlanGroupedTieredPackage(value);
                break;
            case NewPlanMaxGroupTieredPackagePrice value:
                newPlanMaxGroupTieredPackage(value);
                break;
            case NewPlanScalableMatrixWithUnitPricingPrice value:
                newPlanScalableMatrixWithUnitPricing(value);
                break;
            case NewPlanScalableMatrixWithTieredPricingPrice value:
                newPlanScalableMatrixWithTieredPricing(value);
                break;
            case NewPlanCumulativeGroupedBulkPrice value:
                newPlanCumulativeGroupedBulk(value);
                break;
            case global::Orb.Models.Beta.CumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewPlanMinimumCompositePrice value:
                newPlanMinimumComposite(value);
                break;
            case global::Orb.Models.Beta.Percent value:
                percent(value);
                break;
            case global::Orb.Models.Beta.EventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (NewPlanUnitPrice value) => {...},
    ///     (NewPlanTieredPrice value) => {...},
    ///     (NewPlanBulkPrice value) => {...},
    ///     (global::Orb.Models.Beta.BulkWithFilters value) => {...},
    ///     (NewPlanPackagePrice value) => {...},
    ///     (NewPlanMatrixPrice value) => {...},
    ///     (NewPlanThresholdTotalAmountPrice value) => {...},
    ///     (NewPlanTieredPackagePrice value) => {...},
    ///     (NewPlanTieredWithMinimumPrice value) => {...},
    ///     (NewPlanGroupedTieredPrice value) => {...},
    ///     (NewPlanTieredPackageWithMinimumPrice value) => {...},
    ///     (NewPlanPackageWithAllocationPrice value) => {...},
    ///     (NewPlanUnitWithPercentPrice value) => {...},
    ///     (NewPlanMatrixWithAllocationPrice value) => {...},
    ///     (global::Orb.Models.Beta.TieredWithProration value) => {...},
    ///     (NewPlanUnitWithProrationPrice value) => {...},
    ///     (NewPlanGroupedAllocationPrice value) => {...},
    ///     (NewPlanBulkWithProrationPrice value) => {...},
    ///     (NewPlanGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewPlanGroupedWithMeteredMinimumPrice value) => {...},
    ///     (global::Orb.Models.Beta.GroupedWithMinMaxThresholds value) => {...},
    ///     (NewPlanMatrixWithDisplayNamePrice value) => {...},
    ///     (NewPlanGroupedTieredPackagePrice value) => {...},
    ///     (NewPlanMaxGroupTieredPackagePrice value) => {...},
    ///     (NewPlanScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewPlanScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewPlanCumulativeGroupedBulkPrice value) => {...},
    ///     (global::Orb.Models.Beta.CumulativeGroupedAllocation value) => {...},
    ///     (NewPlanMinimumCompositePrice value) => {...},
    ///     (global::Orb.Models.Beta.Percent value) => {...},
    ///     (global::Orb.Models.Beta.EventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewPlanUnitPrice, T> newPlanUnit,
        System::Func<NewPlanTieredPrice, T> newPlanTiered,
        System::Func<NewPlanBulkPrice, T> newPlanBulk,
        System::Func<global::Orb.Models.Beta.BulkWithFilters, T> bulkWithFilters,
        System::Func<NewPlanPackagePrice, T> newPlanPackage,
        System::Func<NewPlanMatrixPrice, T> newPlanMatrix,
        System::Func<NewPlanThresholdTotalAmountPrice, T> newPlanThresholdTotalAmount,
        System::Func<NewPlanTieredPackagePrice, T> newPlanTieredPackage,
        System::Func<NewPlanTieredWithMinimumPrice, T> newPlanTieredWithMinimum,
        System::Func<NewPlanGroupedTieredPrice, T> newPlanGroupedTiered,
        System::Func<NewPlanTieredPackageWithMinimumPrice, T> newPlanTieredPackageWithMinimum,
        System::Func<NewPlanPackageWithAllocationPrice, T> newPlanPackageWithAllocation,
        System::Func<NewPlanUnitWithPercentPrice, T> newPlanUnitWithPercent,
        System::Func<NewPlanMatrixWithAllocationPrice, T> newPlanMatrixWithAllocation,
        System::Func<global::Orb.Models.Beta.TieredWithProration, T> tieredWithProration,
        System::Func<NewPlanUnitWithProrationPrice, T> newPlanUnitWithProration,
        System::Func<NewPlanGroupedAllocationPrice, T> newPlanGroupedAllocation,
        System::Func<NewPlanBulkWithProrationPrice, T> newPlanBulkWithProration,
        System::Func<NewPlanGroupedWithProratedMinimumPrice, T> newPlanGroupedWithProratedMinimum,
        System::Func<NewPlanGroupedWithMeteredMinimumPrice, T> newPlanGroupedWithMeteredMinimum,
        System::Func<
            global::Orb.Models.Beta.GroupedWithMinMaxThresholds,
            T
        > groupedWithMinMaxThresholds,
        System::Func<NewPlanMatrixWithDisplayNamePrice, T> newPlanMatrixWithDisplayName,
        System::Func<NewPlanGroupedTieredPackagePrice, T> newPlanGroupedTieredPackage,
        System::Func<NewPlanMaxGroupTieredPackagePrice, T> newPlanMaxGroupTieredPackage,
        System::Func<
            NewPlanScalableMatrixWithUnitPricingPrice,
            T
        > newPlanScalableMatrixWithUnitPricing,
        System::Func<
            NewPlanScalableMatrixWithTieredPricingPrice,
            T
        > newPlanScalableMatrixWithTieredPricing,
        System::Func<NewPlanCumulativeGroupedBulkPrice, T> newPlanCumulativeGroupedBulk,
        System::Func<
            global::Orb.Models.Beta.CumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewPlanMinimumCompositePrice, T> newPlanMinimumComposite,
        System::Func<global::Orb.Models.Beta.Percent, T> percent,
        System::Func<global::Orb.Models.Beta.EventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewPlanUnitPrice value => newPlanUnit(value),
            NewPlanTieredPrice value => newPlanTiered(value),
            NewPlanBulkPrice value => newPlanBulk(value),
            global::Orb.Models.Beta.BulkWithFilters value => bulkWithFilters(value),
            NewPlanPackagePrice value => newPlanPackage(value),
            NewPlanMatrixPrice value => newPlanMatrix(value),
            NewPlanThresholdTotalAmountPrice value => newPlanThresholdTotalAmount(value),
            NewPlanTieredPackagePrice value => newPlanTieredPackage(value),
            NewPlanTieredWithMinimumPrice value => newPlanTieredWithMinimum(value),
            NewPlanGroupedTieredPrice value => newPlanGroupedTiered(value),
            NewPlanTieredPackageWithMinimumPrice value => newPlanTieredPackageWithMinimum(value),
            NewPlanPackageWithAllocationPrice value => newPlanPackageWithAllocation(value),
            NewPlanUnitWithPercentPrice value => newPlanUnitWithPercent(value),
            NewPlanMatrixWithAllocationPrice value => newPlanMatrixWithAllocation(value),
            global::Orb.Models.Beta.TieredWithProration value => tieredWithProration(value),
            NewPlanUnitWithProrationPrice value => newPlanUnitWithProration(value),
            NewPlanGroupedAllocationPrice value => newPlanGroupedAllocation(value),
            NewPlanBulkWithProrationPrice value => newPlanBulkWithProration(value),
            NewPlanGroupedWithProratedMinimumPrice value => newPlanGroupedWithProratedMinimum(
                value
            ),
            NewPlanGroupedWithMeteredMinimumPrice value => newPlanGroupedWithMeteredMinimum(value),
            global::Orb.Models.Beta.GroupedWithMinMaxThresholds value =>
                groupedWithMinMaxThresholds(value),
            NewPlanMatrixWithDisplayNamePrice value => newPlanMatrixWithDisplayName(value),
            NewPlanGroupedTieredPackagePrice value => newPlanGroupedTieredPackage(value),
            NewPlanMaxGroupTieredPackagePrice value => newPlanMaxGroupTieredPackage(value),
            NewPlanScalableMatrixWithUnitPricingPrice value => newPlanScalableMatrixWithUnitPricing(
                value
            ),
            NewPlanScalableMatrixWithTieredPricingPrice value =>
                newPlanScalableMatrixWithTieredPricing(value),
            NewPlanCumulativeGroupedBulkPrice value => newPlanCumulativeGroupedBulk(value),
            global::Orb.Models.Beta.CumulativeGroupedAllocation value =>
                cumulativeGroupedAllocation(value),
            NewPlanMinimumCompositePrice value => newPlanMinimumComposite(value),
            global::Orb.Models.Beta.Percent value => percent(value),
            global::Orb.Models.Beta.EventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price"),
        };
    }

    public static implicit operator global::Orb.Models.Beta.Price(NewPlanUnitPrice value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.Price(NewPlanTieredPrice value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.Price(NewPlanBulkPrice value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        global::Orb.Models.Beta.BulkWithFilters value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(NewPlanPackagePrice value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.Price(NewPlanMatrixPrice value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanGroupedTieredPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanUnitWithPercentPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        global::Orb.Models.Beta.TieredWithProration value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        global::Orb.Models.Beta.GroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        global::Orb.Models.Beta.CumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        NewPlanMinimumCompositePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        global::Orb.Models.Beta.Percent value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.Price(
        global::Orb.Models.Beta.EventOutput value
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
            throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
        this.Switch(
            (newPlanUnit) => newPlanUnit.Validate(),
            (newPlanTiered) => newPlanTiered.Validate(),
            (newPlanBulk) => newPlanBulk.Validate(),
            (bulkWithFilters) => bulkWithFilters.Validate(),
            (newPlanPackage) => newPlanPackage.Validate(),
            (newPlanMatrix) => newPlanMatrix.Validate(),
            (newPlanThresholdTotalAmount) => newPlanThresholdTotalAmount.Validate(),
            (newPlanTieredPackage) => newPlanTieredPackage.Validate(),
            (newPlanTieredWithMinimum) => newPlanTieredWithMinimum.Validate(),
            (newPlanGroupedTiered) => newPlanGroupedTiered.Validate(),
            (newPlanTieredPackageWithMinimum) => newPlanTieredPackageWithMinimum.Validate(),
            (newPlanPackageWithAllocation) => newPlanPackageWithAllocation.Validate(),
            (newPlanUnitWithPercent) => newPlanUnitWithPercent.Validate(),
            (newPlanMatrixWithAllocation) => newPlanMatrixWithAllocation.Validate(),
            (tieredWithProration) => tieredWithProration.Validate(),
            (newPlanUnitWithProration) => newPlanUnitWithProration.Validate(),
            (newPlanGroupedAllocation) => newPlanGroupedAllocation.Validate(),
            (newPlanBulkWithProration) => newPlanBulkWithProration.Validate(),
            (newPlanGroupedWithProratedMinimum) => newPlanGroupedWithProratedMinimum.Validate(),
            (newPlanGroupedWithMeteredMinimum) => newPlanGroupedWithMeteredMinimum.Validate(),
            (groupedWithMinMaxThresholds) => groupedWithMinMaxThresholds.Validate(),
            (newPlanMatrixWithDisplayName) => newPlanMatrixWithDisplayName.Validate(),
            (newPlanGroupedTieredPackage) => newPlanGroupedTieredPackage.Validate(),
            (newPlanMaxGroupTieredPackage) => newPlanMaxGroupTieredPackage.Validate(),
            (newPlanScalableMatrixWithUnitPricing) =>
                newPlanScalableMatrixWithUnitPricing.Validate(),
            (newPlanScalableMatrixWithTieredPricing) =>
                newPlanScalableMatrixWithTieredPricing.Validate(),
            (newPlanCumulativeGroupedBulk) => newPlanCumulativeGroupedBulk.Validate(),
            (cumulativeGroupedAllocation) => cumulativeGroupedAllocation.Validate(),
            (newPlanMinimumComposite) => newPlanMinimumComposite.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
    }

    public virtual bool Equals(global::Orb.Models.Beta.Price? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class PriceConverter : JsonConverter<global::Orb.Models.Beta.Price?>
{
    public override global::Orb.Models.Beta.Price? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = element.GetProperty("model_type").GetString();
        }
        catch
        {
            modelType = null;
        }

        switch (modelType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.BulkWithFilters>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanPackagePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPackagePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredWithMinimumPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanTieredPackageWithMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanPackageWithAllocationPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "unit_with_percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithPercentPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixWithAllocationPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.TieredWithProration>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "unit_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithProrationPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedAllocationPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkWithProrationPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanGroupedWithProratedMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanGroupedWithMeteredMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.GroupedWithMinMaxThresholds>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanMatrixWithDisplayNamePrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPackagePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanMaxGroupTieredPackagePrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithTieredPricingPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanCumulativeGroupedBulkPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.CumulativeGroupedAllocation>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMinimumCompositePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<global::Orb.Models.Beta.Percent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "event_output":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.EventOutput>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new global::Orb.Models.Beta.Price(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Price? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.BulkWithFilters,
        global::Orb.Models.Beta.BulkWithFiltersFromRaw
    >)
)]
public sealed record class BulkWithFilters : JsonModel
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required global::Orb.Models.Beta.BulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Beta.BulkWithFiltersConfig>(
                "bulk_with_filters_config"
            );
        }
        init { this._rawData.Set("bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Orb.Models.Beta.Cadence>>(
                "cadence"
            );
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Orb.Models.Beta.ConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("bulk_with_filters")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public BulkWithFilters()
    {
        this.ModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
    }

    public BulkWithFilters(global::Orb.Models.Beta.BulkWithFilters bulkWithFilters)
        : base(bulkWithFilters) { }

    public BulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.BulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.BulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkWithFiltersFromRaw : IFromRawJson<global::Orb.Models.Beta.BulkWithFilters>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.BulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.BulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.BulkWithFiltersConfig,
        global::Orb.Models.Beta.BulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class BulkWithFiltersConfig : JsonModel
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.Filter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<global::Orb.Models.Beta.Filter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::Orb.Models.Beta.Filter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.Tier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<global::Orb.Models.Beta.Tier>>(
                "tiers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::Orb.Models.Beta.Tier>>(
                "tiers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public BulkWithFiltersConfig() { }

    public BulkWithFiltersConfig(
        global::Orb.Models.Beta.BulkWithFiltersConfig bulkWithFiltersConfig
    )
        : base(bulkWithFiltersConfig) { }

    public BulkWithFiltersConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.BulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkWithFiltersConfigFromRaw : IFromRawJson<global::Orb.Models.Beta.BulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.BulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.Filter,
        global::Orb.Models.Beta.FilterFromRaw
    >)
)]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_key");
        }
        init { this._rawData.Set("property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_value");
        }
        init { this._rawData.Set("property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public Filter() { }

    public Filter(global::Orb.Models.Beta.Filter filter)
        : base(filter) { }

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.FilterFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRawJson<global::Orb.Models.Beta.Filter>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<global::Orb.Models.Beta.Tier, global::Orb.Models.Beta.TierFromRaw>)
)]
public sealed record class Tier : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier() { }

    public Tier(global::Orb.Models.Beta.Tier tier)
        : base(tier) { }

    public Tier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.TierFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.Tier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class TierFromRaw : IFromRawJson<global::Orb.Models.Beta.Tier>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.Tier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.Tier.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.CadenceConverter))]
public enum Cadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CadenceConverter : JsonConverter<global::Orb.Models.Beta.Cadence>
{
    public override global::Orb.Models.Beta.Cadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence.Custom,
            _ => (global::Orb.Models.Beta.Cadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence.Annual => "annual",
                global::Orb.Models.Beta.Cadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfigConverter))]
public record class ConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ConversionRateConfig(SharedUnitConversionRateConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ConversionRateConfig(SharedTieredConversionRateConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of ConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(global::Orb.Models.Beta.ConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig>
{
    public override global::Orb.Models.Beta.ConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new global::Orb.Models.Beta.ConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.TieredWithProration,
        global::Orb.Models.Beta.TieredWithProrationFromRaw
    >)
)]
public sealed record class TieredWithProration : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.TieredWithProrationCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.TieredWithProrationCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required global::Orb.Models.Beta.TieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Beta.TieredWithProrationConfig>(
                "tiered_with_proration_config"
            );
        }
        init { this._rawData.Set("tiered_with_proration_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.TieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Orb.Models.Beta.TieredWithProrationConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("tiered_with_proration")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        this.TieredWithProrationConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public TieredWithProration()
    {
        this.ModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
    }

    public TieredWithProration(global::Orb.Models.Beta.TieredWithProration tieredWithProration)
        : base(tieredWithProration) { }

    public TieredWithProration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.TieredWithProrationFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.TieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredWithProrationFromRaw : IFromRawJson<global::Orb.Models.Beta.TieredWithProration>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.TieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.TieredWithProration.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.TieredWithProrationCadenceConverter))]
public enum TieredWithProrationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class TieredWithProrationCadenceConverter
    : JsonConverter<global::Orb.Models.Beta.TieredWithProrationCadence>
{
    public override global::Orb.Models.Beta.TieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.TieredWithProrationCadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.TieredWithProrationCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.TieredWithProrationCadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.TieredWithProrationCadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.TieredWithProrationCadence.OneTime,
            "custom" => global::Orb.Models.Beta.TieredWithProrationCadence.Custom,
            _ => (global::Orb.Models.Beta.TieredWithProrationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.TieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.TieredWithProrationCadence.Annual => "annual",
                global::Orb.Models.Beta.TieredWithProrationCadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.TieredWithProrationCadence.Monthly => "monthly",
                global::Orb.Models.Beta.TieredWithProrationCadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.TieredWithProrationCadence.OneTime => "one_time",
                global::Orb.Models.Beta.TieredWithProrationCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.TieredWithProrationConfig,
        global::Orb.Models.Beta.TieredWithProrationConfigFromRaw
    >)
)]
public sealed record class TieredWithProrationConfig : JsonModel
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.TieredWithProrationConfigTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::Orb.Models.Beta.TieredWithProrationConfigTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<global::Orb.Models.Beta.TieredWithProrationConfigTier>
            >("tiers", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public TieredWithProrationConfig() { }

    public TieredWithProrationConfig(
        global::Orb.Models.Beta.TieredWithProrationConfig tieredWithProrationConfig
    )
        : base(tieredWithProrationConfig) { }

    public TieredWithProrationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.TieredWithProrationConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.TieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TieredWithProrationConfig(
        List<global::Orb.Models.Beta.TieredWithProrationConfigTier> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class TieredWithProrationConfigFromRaw
    : IFromRawJson<global::Orb.Models.Beta.TieredWithProrationConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.TieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.TieredWithProrationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.TieredWithProrationConfigTier,
        global::Orb.Models.Beta.TieredWithProrationConfigTierFromRaw
    >)
)]
public sealed record class TieredWithProrationConfigTier : JsonModel
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public TieredWithProrationConfigTier() { }

    public TieredWithProrationConfigTier(
        global::Orb.Models.Beta.TieredWithProrationConfigTier tieredWithProrationConfigTier
    )
        : base(tieredWithProrationConfigTier) { }

    public TieredWithProrationConfigTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfigTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.TieredWithProrationConfigTierFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.TieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredWithProrationConfigTierFromRaw
    : IFromRawJson<global::Orb.Models.Beta.TieredWithProrationConfigTier>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.TieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.TieredWithProrationConfigTier.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Beta.TieredWithProrationConversionRateConfigConverter))]
public record class TieredWithProrationConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public TieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TieredWithProrationConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of TieredWithProrationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of TieredWithProrationConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.TieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.TieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of TieredWithProrationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        global::Orb.Models.Beta.TieredWithProrationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class TieredWithProrationConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.TieredWithProrationConversionRateConfig>
{
    public override global::Orb.Models.Beta.TieredWithProrationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new global::Orb.Models.Beta.TieredWithProrationConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.TieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.GroupedWithMinMaxThresholds,
        global::Orb.Models.Beta.GroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class GroupedWithMinMaxThresholds : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig>(
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { this._rawData.Set("grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public GroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds");
    }

    public GroupedWithMinMaxThresholds(
        global::Orb.Models.Beta.GroupedWithMinMaxThresholds groupedWithMinMaxThresholds
    )
        : base(groupedWithMinMaxThresholds) { }

    public GroupedWithMinMaxThresholds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.GroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMinMaxThresholdsFromRaw
    : IFromRawJson<global::Orb.Models.Beta.GroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.GroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadenceConverter))]
public enum GroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class GroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence>
{
    public override global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.Custom,
            _ => (global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.Annual => "annual",
                global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.SemiAnnual =>
                    "semi_annual",
                global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_with_min_max_thresholds pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig,
        global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class GroupedWithMinMaxThresholdsConfig : JsonModel
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("maximum_charge");
        }
        init { this._rawData.Set("maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("minimum_charge");
        }
        init { this._rawData.Set("minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("per_unit_rate");
        }
        init { this._rawData.Set("per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public GroupedWithMinMaxThresholdsConfig() { }

    public GroupedWithMinMaxThresholdsConfig(
        global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig groupedWithMinMaxThresholdsConfig
    )
        : base(groupedWithMinMaxThresholdsConfig) { }

    public GroupedWithMinMaxThresholdsConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRawJson<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
public record class GroupedWithMinMaxThresholdsConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class GroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.CumulativeGroupedAllocation,
        global::Orb.Models.Beta.CumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class CumulativeGroupedAllocation : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.CumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.CumulativeGroupedAllocationCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required global::Orb.Models.Beta.CumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Beta.CumulativeGroupedAllocationConfig>(
                "cumulative_grouped_allocation_config"
            );
        }
        init { this._rawData.Set("cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("cumulative_grouped_allocation")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public CumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.SerializeToElement("cumulative_grouped_allocation");
    }

    public CumulativeGroupedAllocation(
        global::Orb.Models.Beta.CumulativeGroupedAllocation cumulativeGroupedAllocation
    )
        : base(cumulativeGroupedAllocation) { }

    public CumulativeGroupedAllocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("cumulative_grouped_allocation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.CumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedAllocationFromRaw
    : IFromRawJson<global::Orb.Models.Beta.CumulativeGroupedAllocation>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.CumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.CumulativeGroupedAllocationCadenceConverter))]
public enum CumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CumulativeGroupedAllocationCadenceConverter
    : JsonConverter<global::Orb.Models.Beta.CumulativeGroupedAllocationCadence>
{
    public override global::Orb.Models.Beta.CumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.OneTime,
            "custom" => global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.Custom,
            _ => (global::Orb.Models.Beta.CumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.CumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.Annual => "annual",
                global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.SemiAnnual =>
                    "semi_annual",
                global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.Monthly => "monthly",
                global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.OneTime => "one_time",
                global::Orb.Models.Beta.CumulativeGroupedAllocationCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for cumulative_grouped_allocation pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.CumulativeGroupedAllocationConfig,
        global::Orb.Models.Beta.CumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class CumulativeGroupedAllocationConfig : JsonModel
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cumulative_allocation");
        }
        init { this._rawData.Set("cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_allocation");
        }
        init { this._rawData.Set("group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public CumulativeGroupedAllocationConfig() { }

    public CumulativeGroupedAllocationConfig(
        global::Orb.Models.Beta.CumulativeGroupedAllocationConfig cumulativeGroupedAllocationConfig
    )
        : base(cumulativeGroupedAllocationConfig) { }

    public CumulativeGroupedAllocationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.CumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedAllocationConfigFromRaw
    : IFromRawJson<global::Orb.Models.Beta.CumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.CumulativeGroupedAllocationConfig.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfigConverter)
)]
public record class CumulativeGroupedAllocationConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public CumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CumulativeGroupedAllocationConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class CumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig>
{
    public override global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.Percent,
        global::Orb.Models.Beta.PercentFromRaw
    >)
)]
public sealed record class Percent : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.PercentCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.PercentCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required global::Orb.Models.Beta.PercentConfig PercentConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Beta.PercentConfig>(
                "percent_config"
            );
        }
        init { this._rawData.Set("percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.PercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Orb.Models.Beta.PercentConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (!JsonElement.DeepEquals(this.ModelType, JsonSerializer.SerializeToElement("percent")))
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        this.PercentConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public Percent()
    {
        this.ModelType = JsonSerializer.SerializeToElement("percent");
    }

    public Percent(global::Orb.Models.Beta.Percent percent)
        : base(percent) { }

    public Percent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("percent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.PercentFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.Percent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentFromRaw : IFromRawJson<global::Orb.Models.Beta.Percent>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.Percent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.Percent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.PercentCadenceConverter))]
public enum PercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PercentCadenceConverter : JsonConverter<global::Orb.Models.Beta.PercentCadence>
{
    public override global::Orb.Models.Beta.PercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.PercentCadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.PercentCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.PercentCadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.PercentCadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.PercentCadence.OneTime,
            "custom" => global::Orb.Models.Beta.PercentCadence.Custom,
            _ => (global::Orb.Models.Beta.PercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.PercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.PercentCadence.Annual => "annual",
                global::Orb.Models.Beta.PercentCadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.PercentCadence.Monthly => "monthly",
                global::Orb.Models.Beta.PercentCadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.PercentCadence.OneTime => "one_time",
                global::Orb.Models.Beta.PercentCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.PercentConfig,
        global::Orb.Models.Beta.PercentConfigFromRaw
    >)
)]
public sealed record class PercentConfig : JsonModel
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
    }

    public PercentConfig() { }

    public PercentConfig(global::Orb.Models.Beta.PercentConfig percentConfig)
        : base(percentConfig) { }

    public PercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.PercentConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.PercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class PercentConfigFromRaw : IFromRawJson<global::Orb.Models.Beta.PercentConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.PercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.PercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Beta.PercentConversionRateConfigConverter))]
public record class PercentConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PercentConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of PercentConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of PercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.PercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.PercentConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of PercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(global::Orb.Models.Beta.PercentConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class PercentConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.PercentConversionRateConfig>
{
    public override global::Orb.Models.Beta.PercentConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new global::Orb.Models.Beta.PercentConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.PercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.EventOutput,
        global::Orb.Models.Beta.EventOutputFromRaw
    >)
)]
public sealed record class EventOutput : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.EventOutputCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.EventOutputCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required global::Orb.Models.Beta.EventOutputConfig EventOutputConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::Orb.Models.Beta.EventOutputConfig>(
                "event_output_config"
            );
        }
        init { this._rawData.Set("event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.EventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Orb.Models.Beta.EventOutputConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("event_output")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public EventOutput()
    {
        this.ModelType = JsonSerializer.SerializeToElement("event_output");
    }

    public EventOutput(global::Orb.Models.Beta.EventOutput eventOutput)
        : base(eventOutput) { }

    public EventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("event_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.EventOutputFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.EventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventOutputFromRaw : IFromRawJson<global::Orb.Models.Beta.EventOutput>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.EventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.EventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.EventOutputCadenceConverter))]
public enum EventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class EventOutputCadenceConverter : JsonConverter<global::Orb.Models.Beta.EventOutputCadence>
{
    public override global::Orb.Models.Beta.EventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.EventOutputCadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.EventOutputCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.EventOutputCadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.EventOutputCadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.EventOutputCadence.OneTime,
            "custom" => global::Orb.Models.Beta.EventOutputCadence.Custom,
            _ => (global::Orb.Models.Beta.EventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.EventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.EventOutputCadence.Annual => "annual",
                global::Orb.Models.Beta.EventOutputCadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.EventOutputCadence.Monthly => "monthly",
                global::Orb.Models.Beta.EventOutputCadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.EventOutputCadence.OneTime => "one_time",
                global::Orb.Models.Beta.EventOutputCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for event_output pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Beta.EventOutputConfig,
        global::Orb.Models.Beta.EventOutputConfigFromRaw
    >)
)]
public sealed record class EventOutputConfig : JsonModel
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_rating_key");
        }
        init { this._rawData.Set("unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("default_unit_rate");
        }
        init { this._rawData.Set("default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public EventOutputConfig() { }

    public EventOutputConfig(global::Orb.Models.Beta.EventOutputConfig eventOutputConfig)
        : base(eventOutputConfig) { }

    public EventOutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Beta.EventOutputConfigFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Beta.EventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class EventOutputConfigFromRaw : IFromRawJson<global::Orb.Models.Beta.EventOutputConfig>
{
    /// <inheritdoc/>
    public global::Orb.Models.Beta.EventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.EventOutputConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Beta.EventOutputConversionRateConfigConverter))]
public record class EventOutputConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EventOutputConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of EventOutputConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of EventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.EventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.EventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of EventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(global::Orb.Models.Beta.EventOutputConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class EventOutputConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.EventOutputConversionRateConfig>
{
    public override global::Orb.Models.Beta.EventOutputConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new global::Orb.Models.Beta.EventOutputConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.EventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<RemoveAdjustment, RemoveAdjustmentFromRaw>))]
public sealed record class RemoveAdjustment : JsonModel
{
    /// <summary>
    /// The id of the adjustment to remove from on the plan.
    /// </summary>
    public required string AdjustmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("adjustment_id");
        }
        init { this._rawData.Set("adjustment_id", value); }
    }

    /// <summary>
    /// The phase to remove this adjustment from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdjustmentID;
        _ = this.PlanPhaseOrder;
    }

    public RemoveAdjustment() { }

    public RemoveAdjustment(RemoveAdjustment removeAdjustment)
        : base(removeAdjustment) { }

    public RemoveAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RemoveAdjustmentFromRaw.FromRawUnchecked"/>
    public static RemoveAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RemoveAdjustment(string adjustmentID)
        : this()
    {
        this.AdjustmentID = adjustmentID;
    }
}

class RemoveAdjustmentFromRaw : IFromRawJson<RemoveAdjustment>
{
    /// <inheritdoc/>
    public RemoveAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RemoveAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RemovePrice, RemovePriceFromRaw>))]
public sealed record class RemovePrice : JsonModel
{
    /// <summary>
    /// The id of the price to remove from the plan.
    /// </summary>
    public required string PriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("price_id");
        }
        init { this._rawData.Set("price_id", value); }
    }

    /// <summary>
    /// The phase to remove this price from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PriceID;
        _ = this.PlanPhaseOrder;
    }

    public RemovePrice() { }

    public RemovePrice(RemovePrice removePrice)
        : base(removePrice) { }

    public RemovePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemovePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RemovePriceFromRaw.FromRawUnchecked"/>
    public static RemovePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RemovePrice(string priceID)
        : this()
    {
        this.PriceID = priceID;
    }
}

class RemovePriceFromRaw : IFromRawJson<RemovePrice>
{
    /// <inheritdoc/>
    public RemovePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RemovePrice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ReplaceAdjustment, ReplaceAdjustmentFromRaw>))]
public sealed record class ReplaceAdjustment : JsonModel
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required ReplaceAdjustmentAdjustment Adjustment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplaceAdjustmentAdjustment>("adjustment");
        }
        init { this._rawData.Set("adjustment", value); }
    }

    /// <summary>
    /// The id of the adjustment on the plan to replace in the plan.
    /// </summary>
    public required string ReplacesAdjustmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("replaces_adjustment_id");
        }
        init { this._rawData.Set("replaces_adjustment_id", value); }
    }

    /// <summary>
    /// The phase to replace this adjustment from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.ReplacesAdjustmentID;
        _ = this.PlanPhaseOrder;
    }

    public ReplaceAdjustment() { }

    public ReplaceAdjustment(ReplaceAdjustment replaceAdjustment)
        : base(replaceAdjustment) { }

    public ReplaceAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplaceAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplaceAdjustmentFromRaw.FromRawUnchecked"/>
    public static ReplaceAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplaceAdjustmentFromRaw : IFromRawJson<ReplaceAdjustment>
{
    /// <inheritdoc/>
    public ReplaceAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReplaceAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(ReplaceAdjustmentAdjustmentConverter))]
public record class ReplaceAdjustmentAdjustment : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newPercentageDiscount: (x) => x.Currency,
                newUsageDiscount: (x) => x.Currency,
                newAmountDiscount: (x) => x.Currency,
                newMinimum: (x) => x.Currency,
                newMaximum: (x) => x.Currency
            );
        }
    }

    public bool? IsInvoiceLevel
    {
        get
        {
            return Match<bool?>(
                newPercentageDiscount: (x) => x.IsInvoiceLevel,
                newUsageDiscount: (x) => x.IsInvoiceLevel,
                newAmountDiscount: (x) => x.IsInvoiceLevel,
                newMinimum: (x) => x.IsInvoiceLevel,
                newMaximum: (x) => x.IsInvoiceLevel
            );
        }
    }

    public ReplaceAdjustmentAdjustment(NewPercentageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(NewUsageDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(NewAmountDiscount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(NewMinimum value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(NewMaximum value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplaceAdjustmentAdjustment(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPercentageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPercentageDiscount(out var value)) {
    ///     // `value` is of type `NewPercentageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = this.Value as NewPercentageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewUsageDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewUsageDiscount(out var value)) {
    ///     // `value` is of type `NewUsageDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = this.Value as NewUsageDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewAmountDiscount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewAmountDiscount(out var value)) {
    ///     // `value` is of type `NewAmountDiscount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = this.Value as NewAmountDiscount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewMinimum"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewMinimum(out var value)) {
    ///     // `value` is of type `NewMinimum`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = this.Value as NewMinimum;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewMaximum"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewMaximum(out var value)) {
    ///     // `value` is of type `NewMaximum`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = this.Value as NewMaximum;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (NewPercentageDiscount value) => {...},
    ///     (NewUsageDiscount value) => {...},
    ///     (NewAmountDiscount value) => {...},
    ///     (NewMinimum value) => {...},
    ///     (NewMaximum value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewPercentageDiscount> newPercentageDiscount,
        System::Action<NewUsageDiscount> newUsageDiscount,
        System::Action<NewAmountDiscount> newAmountDiscount,
        System::Action<NewMinimum> newMinimum,
        System::Action<NewMaximum> newMaximum
    )
    {
        switch (this.Value)
        {
            case NewPercentageDiscount value:
                newPercentageDiscount(value);
                break;
            case NewUsageDiscount value:
                newUsageDiscount(value);
                break;
            case NewAmountDiscount value:
                newAmountDiscount(value);
                break;
            case NewMinimum value:
                newMinimum(value);
                break;
            case NewMaximum value:
                newMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplaceAdjustmentAdjustment"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (NewPercentageDiscount value) => {...},
    ///     (NewUsageDiscount value) => {...},
    ///     (NewAmountDiscount value) => {...},
    ///     (NewMinimum value) => {...},
    ///     (NewMaximum value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewPercentageDiscount, T> newPercentageDiscount,
        System::Func<NewUsageDiscount, T> newUsageDiscount,
        System::Func<NewAmountDiscount, T> newAmountDiscount,
        System::Func<NewMinimum, T> newMinimum,
        System::Func<NewMaximum, T> newMaximum
    )
    {
        return this.Value switch
        {
            NewPercentageDiscount value => newPercentageDiscount(value),
            NewUsageDiscount value => newUsageDiscount(value),
            NewAmountDiscount value => newAmountDiscount(value),
            NewMinimum value => newMinimum(value),
            NewMaximum value => newMaximum(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplaceAdjustmentAdjustment"
            ),
        };
    }

    public static implicit operator ReplaceAdjustmentAdjustment(NewPercentageDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentAdjustment(NewUsageDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentAdjustment(NewAmountDiscount value) =>
        new(value);

    public static implicit operator ReplaceAdjustmentAdjustment(NewMinimum value) => new(value);

    public static implicit operator ReplaceAdjustmentAdjustment(NewMaximum value) => new(value);

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
                "Data did not match any variant of ReplaceAdjustmentAdjustment"
            );
        }
        this.Switch(
            (newPercentageDiscount) => newPercentageDiscount.Validate(),
            (newUsageDiscount) => newUsageDiscount.Validate(),
            (newAmountDiscount) => newAmountDiscount.Validate(),
            (newMinimum) => newMinimum.Validate(),
            (newMaximum) => newMaximum.Validate()
        );
    }

    public virtual bool Equals(ReplaceAdjustmentAdjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ReplaceAdjustmentAdjustmentConverter : JsonConverter<ReplaceAdjustmentAdjustment>
{
    public override ReplaceAdjustmentAdjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = element.GetProperty("adjustment_type").GetString();
        }
        catch
        {
            adjustmentType = null;
        }

        switch (adjustmentType)
        {
            case "percentage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "usage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "amount_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "maximum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplaceAdjustmentAdjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplaceAdjustmentAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ReplacePrice, ReplacePriceFromRaw>))]
public sealed record class ReplacePrice : JsonModel
{
    /// <summary>
    /// The id of the price on the plan to replace in the plan.
    /// </summary>
    public required string ReplacesPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("replaces_price_id");
        }
        init { this._rawData.Set("replaces_price_id", value); }
    }

    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewAllocationPrice>("allocation_price");
        }
        init { this._rawData.Set("allocation_price", value); }
    }

    /// <summary>
    /// The phase to replace this price from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plan_phase_order");
        }
        init { this._rawData.Set("plan_phase_order", value); }
    }

    /// <summary>
    /// New plan price request body params.
    /// </summary>
    public ReplacePricePrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePrice>("price");
        }
        init { this._rawData.Set("price", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReplacesPriceID;
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public ReplacePrice() { }

    public ReplacePrice(ReplacePrice replacePrice)
        : base(replacePrice) { }

    public ReplacePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePriceFromRaw.FromRawUnchecked"/>
    public static ReplacePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePrice(string replacesPriceID)
        : this()
    {
        this.ReplacesPriceID = replacesPriceID;
    }
}

class ReplacePriceFromRaw : IFromRawJson<ReplacePrice>
{
    /// <inheritdoc/>
    public ReplacePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReplacePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// New plan price request body params.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceConverter))]
public record class ReplacePricePrice : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string ItemID
    {
        get
        {
            return Match(
                newPlanUnit: (x) => x.ItemID,
                newPlanTiered: (x) => x.ItemID,
                newPlanBulk: (x) => x.ItemID,
                bulkWithFilters: (x) => x.ItemID,
                newPlanPackage: (x) => x.ItemID,
                newPlanMatrix: (x) => x.ItemID,
                newPlanThresholdTotalAmount: (x) => x.ItemID,
                newPlanTieredPackage: (x) => x.ItemID,
                newPlanTieredWithMinimum: (x) => x.ItemID,
                newPlanGroupedTiered: (x) => x.ItemID,
                newPlanTieredPackageWithMinimum: (x) => x.ItemID,
                newPlanPackageWithAllocation: (x) => x.ItemID,
                newPlanUnitWithPercent: (x) => x.ItemID,
                newPlanMatrixWithAllocation: (x) => x.ItemID,
                tieredWithProration: (x) => x.ItemID,
                newPlanUnitWithProration: (x) => x.ItemID,
                newPlanGroupedAllocation: (x) => x.ItemID,
                newPlanBulkWithProration: (x) => x.ItemID,
                newPlanGroupedWithProratedMinimum: (x) => x.ItemID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ItemID,
                groupedWithMinMaxThresholds: (x) => x.ItemID,
                newPlanMatrixWithDisplayName: (x) => x.ItemID,
                newPlanGroupedTieredPackage: (x) => x.ItemID,
                newPlanMaxGroupTieredPackage: (x) => x.ItemID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ItemID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ItemID,
                newPlanCumulativeGroupedBulk: (x) => x.ItemID,
                cumulativeGroupedAllocation: (x) => x.ItemID,
                newPlanMinimumComposite: (x) => x.ItemID,
                percent: (x) => x.ItemID,
                eventOutput: (x) => x.ItemID
            );
        }
    }

    public string Name
    {
        get
        {
            return Match(
                newPlanUnit: (x) => x.Name,
                newPlanTiered: (x) => x.Name,
                newPlanBulk: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                newPlanPackage: (x) => x.Name,
                newPlanMatrix: (x) => x.Name,
                newPlanThresholdTotalAmount: (x) => x.Name,
                newPlanTieredPackage: (x) => x.Name,
                newPlanTieredWithMinimum: (x) => x.Name,
                newPlanGroupedTiered: (x) => x.Name,
                newPlanTieredPackageWithMinimum: (x) => x.Name,
                newPlanPackageWithAllocation: (x) => x.Name,
                newPlanUnitWithPercent: (x) => x.Name,
                newPlanMatrixWithAllocation: (x) => x.Name,
                tieredWithProration: (x) => x.Name,
                newPlanUnitWithProration: (x) => x.Name,
                newPlanGroupedAllocation: (x) => x.Name,
                newPlanBulkWithProration: (x) => x.Name,
                newPlanGroupedWithProratedMinimum: (x) => x.Name,
                newPlanGroupedWithMeteredMinimum: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                newPlanMatrixWithDisplayName: (x) => x.Name,
                newPlanGroupedTieredPackage: (x) => x.Name,
                newPlanMaxGroupTieredPackage: (x) => x.Name,
                newPlanScalableMatrixWithUnitPricing: (x) => x.Name,
                newPlanScalableMatrixWithTieredPricing: (x) => x.Name,
                newPlanCumulativeGroupedBulk: (x) => x.Name,
                cumulativeGroupedAllocation: (x) => x.Name,
                newPlanMinimumComposite: (x) => x.Name,
                percent: (x) => x.Name,
                eventOutput: (x) => x.Name
            );
        }
    }

    public string? BillableMetricID
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.BillableMetricID,
                newPlanTiered: (x) => x.BillableMetricID,
                newPlanBulk: (x) => x.BillableMetricID,
                bulkWithFilters: (x) => x.BillableMetricID,
                newPlanPackage: (x) => x.BillableMetricID,
                newPlanMatrix: (x) => x.BillableMetricID,
                newPlanThresholdTotalAmount: (x) => x.BillableMetricID,
                newPlanTieredPackage: (x) => x.BillableMetricID,
                newPlanTieredWithMinimum: (x) => x.BillableMetricID,
                newPlanGroupedTiered: (x) => x.BillableMetricID,
                newPlanTieredPackageWithMinimum: (x) => x.BillableMetricID,
                newPlanPackageWithAllocation: (x) => x.BillableMetricID,
                newPlanUnitWithPercent: (x) => x.BillableMetricID,
                newPlanMatrixWithAllocation: (x) => x.BillableMetricID,
                tieredWithProration: (x) => x.BillableMetricID,
                newPlanUnitWithProration: (x) => x.BillableMetricID,
                newPlanGroupedAllocation: (x) => x.BillableMetricID,
                newPlanBulkWithProration: (x) => x.BillableMetricID,
                newPlanGroupedWithProratedMinimum: (x) => x.BillableMetricID,
                newPlanGroupedWithMeteredMinimum: (x) => x.BillableMetricID,
                groupedWithMinMaxThresholds: (x) => x.BillableMetricID,
                newPlanMatrixWithDisplayName: (x) => x.BillableMetricID,
                newPlanGroupedTieredPackage: (x) => x.BillableMetricID,
                newPlanMaxGroupTieredPackage: (x) => x.BillableMetricID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BillableMetricID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BillableMetricID,
                newPlanCumulativeGroupedBulk: (x) => x.BillableMetricID,
                cumulativeGroupedAllocation: (x) => x.BillableMetricID,
                newPlanMinimumComposite: (x) => x.BillableMetricID,
                percent: (x) => x.BillableMetricID,
                eventOutput: (x) => x.BillableMetricID
            );
        }
    }

    public bool? BilledInAdvance
    {
        get
        {
            return Match<bool?>(
                newPlanUnit: (x) => x.BilledInAdvance,
                newPlanTiered: (x) => x.BilledInAdvance,
                newPlanBulk: (x) => x.BilledInAdvance,
                bulkWithFilters: (x) => x.BilledInAdvance,
                newPlanPackage: (x) => x.BilledInAdvance,
                newPlanMatrix: (x) => x.BilledInAdvance,
                newPlanThresholdTotalAmount: (x) => x.BilledInAdvance,
                newPlanTieredPackage: (x) => x.BilledInAdvance,
                newPlanTieredWithMinimum: (x) => x.BilledInAdvance,
                newPlanGroupedTiered: (x) => x.BilledInAdvance,
                newPlanTieredPackageWithMinimum: (x) => x.BilledInAdvance,
                newPlanPackageWithAllocation: (x) => x.BilledInAdvance,
                newPlanUnitWithPercent: (x) => x.BilledInAdvance,
                newPlanMatrixWithAllocation: (x) => x.BilledInAdvance,
                tieredWithProration: (x) => x.BilledInAdvance,
                newPlanUnitWithProration: (x) => x.BilledInAdvance,
                newPlanGroupedAllocation: (x) => x.BilledInAdvance,
                newPlanBulkWithProration: (x) => x.BilledInAdvance,
                newPlanGroupedWithProratedMinimum: (x) => x.BilledInAdvance,
                newPlanGroupedWithMeteredMinimum: (x) => x.BilledInAdvance,
                groupedWithMinMaxThresholds: (x) => x.BilledInAdvance,
                newPlanMatrixWithDisplayName: (x) => x.BilledInAdvance,
                newPlanGroupedTieredPackage: (x) => x.BilledInAdvance,
                newPlanMaxGroupTieredPackage: (x) => x.BilledInAdvance,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BilledInAdvance,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BilledInAdvance,
                newPlanCumulativeGroupedBulk: (x) => x.BilledInAdvance,
                cumulativeGroupedAllocation: (x) => x.BilledInAdvance,
                newPlanMinimumComposite: (x) => x.BilledInAdvance,
                percent: (x) => x.BilledInAdvance,
                eventOutput: (x) => x.BilledInAdvance
            );
        }
    }

    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return Match<NewBillingCycleConfiguration?>(
                newPlanUnit: (x) => x.BillingCycleConfiguration,
                newPlanTiered: (x) => x.BillingCycleConfiguration,
                newPlanBulk: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                newPlanPackage: (x) => x.BillingCycleConfiguration,
                newPlanMatrix: (x) => x.BillingCycleConfiguration,
                newPlanThresholdTotalAmount: (x) => x.BillingCycleConfiguration,
                newPlanTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanTieredWithMinimum: (x) => x.BillingCycleConfiguration,
                newPlanGroupedTiered: (x) => x.BillingCycleConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.BillingCycleConfiguration,
                newPlanPackageWithAllocation: (x) => x.BillingCycleConfiguration,
                newPlanUnitWithPercent: (x) => x.BillingCycleConfiguration,
                newPlanMatrixWithAllocation: (x) => x.BillingCycleConfiguration,
                tieredWithProration: (x) => x.BillingCycleConfiguration,
                newPlanUnitWithProration: (x) => x.BillingCycleConfiguration,
                newPlanGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newPlanBulkWithProration: (x) => x.BillingCycleConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.BillingCycleConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.BillingCycleConfiguration,
                newPlanGroupedTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.BillingCycleConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.BillingCycleConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.BillingCycleConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.BillingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newPlanMinimumComposite: (x) => x.BillingCycleConfiguration,
                percent: (x) => x.BillingCycleConfiguration,
                eventOutput: (x) => x.BillingCycleConfiguration
            );
        }
    }

    public double? ConversionRate
    {
        get
        {
            return Match<double?>(
                newPlanUnit: (x) => x.ConversionRate,
                newPlanTiered: (x) => x.ConversionRate,
                newPlanBulk: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                newPlanPackage: (x) => x.ConversionRate,
                newPlanMatrix: (x) => x.ConversionRate,
                newPlanThresholdTotalAmount: (x) => x.ConversionRate,
                newPlanTieredPackage: (x) => x.ConversionRate,
                newPlanTieredWithMinimum: (x) => x.ConversionRate,
                newPlanGroupedTiered: (x) => x.ConversionRate,
                newPlanTieredPackageWithMinimum: (x) => x.ConversionRate,
                newPlanPackageWithAllocation: (x) => x.ConversionRate,
                newPlanUnitWithPercent: (x) => x.ConversionRate,
                newPlanMatrixWithAllocation: (x) => x.ConversionRate,
                tieredWithProration: (x) => x.ConversionRate,
                newPlanUnitWithProration: (x) => x.ConversionRate,
                newPlanGroupedAllocation: (x) => x.ConversionRate,
                newPlanBulkWithProration: (x) => x.ConversionRate,
                newPlanGroupedWithProratedMinimum: (x) => x.ConversionRate,
                newPlanGroupedWithMeteredMinimum: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                newPlanMatrixWithDisplayName: (x) => x.ConversionRate,
                newPlanGroupedTieredPackage: (x) => x.ConversionRate,
                newPlanMaxGroupTieredPackage: (x) => x.ConversionRate,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ConversionRate,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ConversionRate,
                newPlanCumulativeGroupedBulk: (x) => x.ConversionRate,
                cumulativeGroupedAllocation: (x) => x.ConversionRate,
                newPlanMinimumComposite: (x) => x.ConversionRate,
                percent: (x) => x.ConversionRate,
                eventOutput: (x) => x.ConversionRate
            );
        }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.Currency,
                newPlanTiered: (x) => x.Currency,
                newPlanBulk: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                newPlanPackage: (x) => x.Currency,
                newPlanMatrix: (x) => x.Currency,
                newPlanThresholdTotalAmount: (x) => x.Currency,
                newPlanTieredPackage: (x) => x.Currency,
                newPlanTieredWithMinimum: (x) => x.Currency,
                newPlanGroupedTiered: (x) => x.Currency,
                newPlanTieredPackageWithMinimum: (x) => x.Currency,
                newPlanPackageWithAllocation: (x) => x.Currency,
                newPlanUnitWithPercent: (x) => x.Currency,
                newPlanMatrixWithAllocation: (x) => x.Currency,
                tieredWithProration: (x) => x.Currency,
                newPlanUnitWithProration: (x) => x.Currency,
                newPlanGroupedAllocation: (x) => x.Currency,
                newPlanBulkWithProration: (x) => x.Currency,
                newPlanGroupedWithProratedMinimum: (x) => x.Currency,
                newPlanGroupedWithMeteredMinimum: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                newPlanMatrixWithDisplayName: (x) => x.Currency,
                newPlanGroupedTieredPackage: (x) => x.Currency,
                newPlanMaxGroupTieredPackage: (x) => x.Currency,
                newPlanScalableMatrixWithUnitPricing: (x) => x.Currency,
                newPlanScalableMatrixWithTieredPricing: (x) => x.Currency,
                newPlanCumulativeGroupedBulk: (x) => x.Currency,
                cumulativeGroupedAllocation: (x) => x.Currency,
                newPlanMinimumComposite: (x) => x.Currency,
                percent: (x) => x.Currency,
                eventOutput: (x) => x.Currency
            );
        }
    }

    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return Match<NewDimensionalPriceConfiguration?>(
                newPlanUnit: (x) => x.DimensionalPriceConfiguration,
                newPlanTiered: (x) => x.DimensionalPriceConfiguration,
                newPlanBulk: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                newPlanPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrix: (x) => x.DimensionalPriceConfiguration,
                newPlanThresholdTotalAmount: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedTiered: (x) => x.DimensionalPriceConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanPackageWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newPlanUnitWithPercent: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrixWithAllocation: (x) => x.DimensionalPriceConfiguration,
                tieredWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanUnitWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newPlanBulkWithProration: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.DimensionalPriceConfiguration,
                newPlanGroupedTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.DimensionalPriceConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.DimensionalPriceConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.DimensionalPriceConfiguration,
                cumulativeGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newPlanMinimumComposite: (x) => x.DimensionalPriceConfiguration,
                percent: (x) => x.DimensionalPriceConfiguration,
                eventOutput: (x) => x.DimensionalPriceConfiguration
            );
        }
    }

    public string? ExternalPriceID
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.ExternalPriceID,
                newPlanTiered: (x) => x.ExternalPriceID,
                newPlanBulk: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                newPlanPackage: (x) => x.ExternalPriceID,
                newPlanMatrix: (x) => x.ExternalPriceID,
                newPlanThresholdTotalAmount: (x) => x.ExternalPriceID,
                newPlanTieredPackage: (x) => x.ExternalPriceID,
                newPlanTieredWithMinimum: (x) => x.ExternalPriceID,
                newPlanGroupedTiered: (x) => x.ExternalPriceID,
                newPlanTieredPackageWithMinimum: (x) => x.ExternalPriceID,
                newPlanPackageWithAllocation: (x) => x.ExternalPriceID,
                newPlanUnitWithPercent: (x) => x.ExternalPriceID,
                newPlanMatrixWithAllocation: (x) => x.ExternalPriceID,
                tieredWithProration: (x) => x.ExternalPriceID,
                newPlanUnitWithProration: (x) => x.ExternalPriceID,
                newPlanGroupedAllocation: (x) => x.ExternalPriceID,
                newPlanBulkWithProration: (x) => x.ExternalPriceID,
                newPlanGroupedWithProratedMinimum: (x) => x.ExternalPriceID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                newPlanMatrixWithDisplayName: (x) => x.ExternalPriceID,
                newPlanGroupedTieredPackage: (x) => x.ExternalPriceID,
                newPlanMaxGroupTieredPackage: (x) => x.ExternalPriceID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ExternalPriceID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ExternalPriceID,
                newPlanCumulativeGroupedBulk: (x) => x.ExternalPriceID,
                cumulativeGroupedAllocation: (x) => x.ExternalPriceID,
                newPlanMinimumComposite: (x) => x.ExternalPriceID,
                percent: (x) => x.ExternalPriceID,
                eventOutput: (x) => x.ExternalPriceID
            );
        }
    }

    public double? FixedPriceQuantity
    {
        get
        {
            return Match<double?>(
                newPlanUnit: (x) => x.FixedPriceQuantity,
                newPlanTiered: (x) => x.FixedPriceQuantity,
                newPlanBulk: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                newPlanPackage: (x) => x.FixedPriceQuantity,
                newPlanMatrix: (x) => x.FixedPriceQuantity,
                newPlanThresholdTotalAmount: (x) => x.FixedPriceQuantity,
                newPlanTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanTieredWithMinimum: (x) => x.FixedPriceQuantity,
                newPlanGroupedTiered: (x) => x.FixedPriceQuantity,
                newPlanTieredPackageWithMinimum: (x) => x.FixedPriceQuantity,
                newPlanPackageWithAllocation: (x) => x.FixedPriceQuantity,
                newPlanUnitWithPercent: (x) => x.FixedPriceQuantity,
                newPlanMatrixWithAllocation: (x) => x.FixedPriceQuantity,
                tieredWithProration: (x) => x.FixedPriceQuantity,
                newPlanUnitWithProration: (x) => x.FixedPriceQuantity,
                newPlanGroupedAllocation: (x) => x.FixedPriceQuantity,
                newPlanBulkWithProration: (x) => x.FixedPriceQuantity,
                newPlanGroupedWithProratedMinimum: (x) => x.FixedPriceQuantity,
                newPlanGroupedWithMeteredMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                newPlanMatrixWithDisplayName: (x) => x.FixedPriceQuantity,
                newPlanGroupedTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanMaxGroupTieredPackage: (x) => x.FixedPriceQuantity,
                newPlanScalableMatrixWithUnitPricing: (x) => x.FixedPriceQuantity,
                newPlanScalableMatrixWithTieredPricing: (x) => x.FixedPriceQuantity,
                newPlanCumulativeGroupedBulk: (x) => x.FixedPriceQuantity,
                cumulativeGroupedAllocation: (x) => x.FixedPriceQuantity,
                newPlanMinimumComposite: (x) => x.FixedPriceQuantity,
                percent: (x) => x.FixedPriceQuantity,
                eventOutput: (x) => x.FixedPriceQuantity
            );
        }
    }

    public string? InvoiceGroupingKey
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.InvoiceGroupingKey,
                newPlanTiered: (x) => x.InvoiceGroupingKey,
                newPlanBulk: (x) => x.InvoiceGroupingKey,
                bulkWithFilters: (x) => x.InvoiceGroupingKey,
                newPlanPackage: (x) => x.InvoiceGroupingKey,
                newPlanMatrix: (x) => x.InvoiceGroupingKey,
                newPlanThresholdTotalAmount: (x) => x.InvoiceGroupingKey,
                newPlanTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanTieredWithMinimum: (x) => x.InvoiceGroupingKey,
                newPlanGroupedTiered: (x) => x.InvoiceGroupingKey,
                newPlanTieredPackageWithMinimum: (x) => x.InvoiceGroupingKey,
                newPlanPackageWithAllocation: (x) => x.InvoiceGroupingKey,
                newPlanUnitWithPercent: (x) => x.InvoiceGroupingKey,
                newPlanMatrixWithAllocation: (x) => x.InvoiceGroupingKey,
                tieredWithProration: (x) => x.InvoiceGroupingKey,
                newPlanUnitWithProration: (x) => x.InvoiceGroupingKey,
                newPlanGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newPlanBulkWithProration: (x) => x.InvoiceGroupingKey,
                newPlanGroupedWithProratedMinimum: (x) => x.InvoiceGroupingKey,
                newPlanGroupedWithMeteredMinimum: (x) => x.InvoiceGroupingKey,
                groupedWithMinMaxThresholds: (x) => x.InvoiceGroupingKey,
                newPlanMatrixWithDisplayName: (x) => x.InvoiceGroupingKey,
                newPlanGroupedTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanMaxGroupTieredPackage: (x) => x.InvoiceGroupingKey,
                newPlanScalableMatrixWithUnitPricing: (x) => x.InvoiceGroupingKey,
                newPlanScalableMatrixWithTieredPricing: (x) => x.InvoiceGroupingKey,
                newPlanCumulativeGroupedBulk: (x) => x.InvoiceGroupingKey,
                cumulativeGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newPlanMinimumComposite: (x) => x.InvoiceGroupingKey,
                percent: (x) => x.InvoiceGroupingKey,
                eventOutput: (x) => x.InvoiceGroupingKey
            );
        }
    }

    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return Match<NewBillingCycleConfiguration?>(
                newPlanUnit: (x) => x.InvoicingCycleConfiguration,
                newPlanTiered: (x) => x.InvoicingCycleConfiguration,
                newPlanBulk: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                newPlanPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrix: (x) => x.InvoicingCycleConfiguration,
                newPlanThresholdTotalAmount: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedTiered: (x) => x.InvoicingCycleConfiguration,
                newPlanTieredPackageWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanPackageWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newPlanUnitWithPercent: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrixWithAllocation: (x) => x.InvoicingCycleConfiguration,
                tieredWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanUnitWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newPlanBulkWithProration: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedWithProratedMinimum: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedWithMeteredMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                newPlanMatrixWithDisplayName: (x) => x.InvoicingCycleConfiguration,
                newPlanGroupedTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanMaxGroupTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newPlanScalableMatrixWithUnitPricing: (x) => x.InvoicingCycleConfiguration,
                newPlanScalableMatrixWithTieredPricing: (x) => x.InvoicingCycleConfiguration,
                newPlanCumulativeGroupedBulk: (x) => x.InvoicingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newPlanMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public string? ReferenceID
    {
        get
        {
            return Match<string?>(
                newPlanUnit: (x) => x.ReferenceID,
                newPlanTiered: (x) => x.ReferenceID,
                newPlanBulk: (x) => x.ReferenceID,
                bulkWithFilters: (x) => x.ReferenceID,
                newPlanPackage: (x) => x.ReferenceID,
                newPlanMatrix: (x) => x.ReferenceID,
                newPlanThresholdTotalAmount: (x) => x.ReferenceID,
                newPlanTieredPackage: (x) => x.ReferenceID,
                newPlanTieredWithMinimum: (x) => x.ReferenceID,
                newPlanGroupedTiered: (x) => x.ReferenceID,
                newPlanTieredPackageWithMinimum: (x) => x.ReferenceID,
                newPlanPackageWithAllocation: (x) => x.ReferenceID,
                newPlanUnitWithPercent: (x) => x.ReferenceID,
                newPlanMatrixWithAllocation: (x) => x.ReferenceID,
                tieredWithProration: (x) => x.ReferenceID,
                newPlanUnitWithProration: (x) => x.ReferenceID,
                newPlanGroupedAllocation: (x) => x.ReferenceID,
                newPlanBulkWithProration: (x) => x.ReferenceID,
                newPlanGroupedWithProratedMinimum: (x) => x.ReferenceID,
                newPlanGroupedWithMeteredMinimum: (x) => x.ReferenceID,
                groupedWithMinMaxThresholds: (x) => x.ReferenceID,
                newPlanMatrixWithDisplayName: (x) => x.ReferenceID,
                newPlanGroupedTieredPackage: (x) => x.ReferenceID,
                newPlanMaxGroupTieredPackage: (x) => x.ReferenceID,
                newPlanScalableMatrixWithUnitPricing: (x) => x.ReferenceID,
                newPlanScalableMatrixWithTieredPricing: (x) => x.ReferenceID,
                newPlanCumulativeGroupedBulk: (x) => x.ReferenceID,
                cumulativeGroupedAllocation: (x) => x.ReferenceID,
                newPlanMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public ReplacePricePrice(NewPlanUnitPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(ReplacePricePriceBulkWithFilters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanMatrixPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanThresholdTotalAmountPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanTieredWithMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanGroupedTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewPlanTieredPackageWithMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanPackageWithAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanUnitWithPercentPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanMatrixWithAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        ReplacePricePriceTieredWithProration value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanUnitWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanGroupedAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanBulkWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewPlanGroupedWithProratedMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewPlanGroupedWithMeteredMinimumPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        ReplacePricePriceGroupedWithMinMaxThresholds value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanMatrixWithDisplayNamePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanGroupedTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanMaxGroupTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewPlanScalableMatrixWithUnitPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        NewPlanScalableMatrixWithTieredPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanCumulativeGroupedBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(
        ReplacePricePriceCumulativeGroupedAllocation value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(NewPlanMinimumCompositePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(ReplacePricePricePercent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(ReplacePricePriceEventOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePrice(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanUnit(out var value)) {
    ///     // `value` is of type `NewPlanUnitPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanUnit([NotNullWhen(true)] out NewPlanUnitPrice? value)
    {
        value = this.Value as NewPlanUnitPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanTiered(out var value)) {
    ///     // `value` is of type `NewPlanTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanTiered([NotNullWhen(true)] out NewPlanTieredPrice? value)
    {
        value = this.Value as NewPlanTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanBulk(out var value)) {
    ///     // `value` is of type `NewPlanBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanBulk([NotNullWhen(true)] out NewPlanBulkPrice? value)
    {
        value = this.Value as NewPlanBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceBulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `ReplacePricePriceBulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out ReplacePricePriceBulkWithFilters? value
    )
    {
        value = this.Value as ReplacePricePriceBulkWithFilters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanPackage(out var value)) {
    ///     // `value` is of type `NewPlanPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanPackage([NotNullWhen(true)] out NewPlanPackagePrice? value)
    {
        value = this.Value as NewPlanPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMatrixPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMatrix(out var value)) {
    ///     // `value` is of type `NewPlanMatrixPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMatrix([NotNullWhen(true)] out NewPlanMatrixPrice? value)
    {
        value = this.Value as NewPlanMatrixPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanThresholdTotalAmountPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanThresholdTotalAmount(out var value)) {
    ///     // `value` is of type `NewPlanThresholdTotalAmountPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanThresholdTotalAmount(
        [NotNullWhen(true)] out NewPlanThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewPlanThresholdTotalAmountPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanTieredPackage(out var value)) {
    ///     // `value` is of type `NewPlanTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanTieredPackage(
        [NotNullWhen(true)] out NewPlanTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanTieredWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanTieredWithMinimum(out var value)) {
    ///     // `value` is of type `NewPlanTieredWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanTieredWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedTiered(out var value)) {
    ///     // `value` is of type `NewPlanGroupedTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedTiered(
        [NotNullWhen(true)] out NewPlanGroupedTieredPrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanTieredPackageWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanTieredPackageWithMinimum(out var value)) {
    ///     // `value` is of type `NewPlanTieredPackageWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredPackageWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanPackageWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanPackageWithAllocation(out var value)) {
    ///     // `value` is of type `NewPlanPackageWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanPackageWithAllocation(
        [NotNullWhen(true)] out NewPlanPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanPackageWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanUnitWithPercentPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanUnitWithPercent(out var value)) {
    ///     // `value` is of type `NewPlanUnitWithPercentPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanUnitWithPercent(
        [NotNullWhen(true)] out NewPlanUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithPercentPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMatrixWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMatrixWithAllocation(out var value)) {
    ///     // `value` is of type `NewPlanMatrixWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMatrixWithAllocation(
        [NotNullWhen(true)] out NewPlanMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceTieredWithProration"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTieredWithProration(out var value)) {
    ///     // `value` is of type `ReplacePricePriceTieredWithProration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out ReplacePricePriceTieredWithProration? value
    )
    {
        value = this.Value as ReplacePricePriceTieredWithProration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanUnitWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanUnitWithProration(out var value)) {
    ///     // `value` is of type `NewPlanUnitWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanUnitWithProration(
        [NotNullWhen(true)] out NewPlanUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedAllocation(out var value)) {
    ///     // `value` is of type `NewPlanGroupedAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedAllocation(
        [NotNullWhen(true)] out NewPlanGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewPlanGroupedAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanBulkWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanBulkWithProration(out var value)) {
    ///     // `value` is of type `NewPlanBulkWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanBulkWithProration(
        [NotNullWhen(true)] out NewPlanBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanBulkWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedWithProratedMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedWithProratedMinimum(out var value)) {
    ///     // `value` is of type `NewPlanGroupedWithProratedMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithProratedMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedWithMeteredMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedWithMeteredMinimum(out var value)) {
    ///     // `value` is of type `NewPlanGroupedWithMeteredMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceGroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `ReplacePricePriceGroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out ReplacePricePriceGroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as ReplacePricePriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMatrixWithDisplayNamePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMatrixWithDisplayName(out var value)) {
    ///     // `value` is of type `NewPlanMatrixWithDisplayNamePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMatrixWithDisplayName(
        [NotNullWhen(true)] out NewPlanMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithDisplayNamePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanGroupedTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanGroupedTieredPackage(out var value)) {
    ///     // `value` is of type `NewPlanGroupedTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanGroupedTieredPackage(
        [NotNullWhen(true)] out NewPlanGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMaxGroupTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMaxGroupTieredPackage(out var value)) {
    ///     // `value` is of type `NewPlanMaxGroupTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewPlanMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanMaxGroupTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanScalableMatrixWithUnitPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanScalableMatrixWithUnitPricing(out var value)) {
    ///     // `value` is of type `NewPlanScalableMatrixWithUnitPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanScalableMatrixWithTieredPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanScalableMatrixWithTieredPricing(out var value)) {
    ///     // `value` is of type `NewPlanScalableMatrixWithTieredPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanCumulativeGroupedBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanCumulativeGroupedBulk(out var value)) {
    ///     // `value` is of type `NewPlanCumulativeGroupedBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewPlanCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewPlanCumulativeGroupedBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceCumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `ReplacePricePriceCumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out ReplacePricePriceCumulativeGroupedAllocation? value
    )
    {
        value = this.Value as ReplacePricePriceCumulativeGroupedAllocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewPlanMinimumCompositePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewPlanMinimumComposite(out var value)) {
    ///     // `value` is of type `NewPlanMinimumCompositePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = this.Value as NewPlanMinimumCompositePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePricePercent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `ReplacePricePricePercent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent([NotNullWhen(true)] out ReplacePricePricePercent? value)
    {
        value = this.Value as ReplacePricePricePercent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ReplacePricePriceEventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `ReplacePricePriceEventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput([NotNullWhen(true)] out ReplacePricePriceEventOutput? value)
    {
        value = this.Value as ReplacePricePriceEventOutput;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (NewPlanUnitPrice value) => {...},
    ///     (NewPlanTieredPrice value) => {...},
    ///     (NewPlanBulkPrice value) => {...},
    ///     (ReplacePricePriceBulkWithFilters value) => {...},
    ///     (NewPlanPackagePrice value) => {...},
    ///     (NewPlanMatrixPrice value) => {...},
    ///     (NewPlanThresholdTotalAmountPrice value) => {...},
    ///     (NewPlanTieredPackagePrice value) => {...},
    ///     (NewPlanTieredWithMinimumPrice value) => {...},
    ///     (NewPlanGroupedTieredPrice value) => {...},
    ///     (NewPlanTieredPackageWithMinimumPrice value) => {...},
    ///     (NewPlanPackageWithAllocationPrice value) => {...},
    ///     (NewPlanUnitWithPercentPrice value) => {...},
    ///     (NewPlanMatrixWithAllocationPrice value) => {...},
    ///     (ReplacePricePriceTieredWithProration value) => {...},
    ///     (NewPlanUnitWithProrationPrice value) => {...},
    ///     (NewPlanGroupedAllocationPrice value) => {...},
    ///     (NewPlanBulkWithProrationPrice value) => {...},
    ///     (NewPlanGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewPlanGroupedWithMeteredMinimumPrice value) => {...},
    ///     (ReplacePricePriceGroupedWithMinMaxThresholds value) => {...},
    ///     (NewPlanMatrixWithDisplayNamePrice value) => {...},
    ///     (NewPlanGroupedTieredPackagePrice value) => {...},
    ///     (NewPlanMaxGroupTieredPackagePrice value) => {...},
    ///     (NewPlanScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewPlanScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewPlanCumulativeGroupedBulkPrice value) => {...},
    ///     (ReplacePricePriceCumulativeGroupedAllocation value) => {...},
    ///     (NewPlanMinimumCompositePrice value) => {...},
    ///     (ReplacePricePricePercent value) => {...},
    ///     (ReplacePricePriceEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewPlanUnitPrice> newPlanUnit,
        System::Action<NewPlanTieredPrice> newPlanTiered,
        System::Action<NewPlanBulkPrice> newPlanBulk,
        System::Action<ReplacePricePriceBulkWithFilters> bulkWithFilters,
        System::Action<NewPlanPackagePrice> newPlanPackage,
        System::Action<NewPlanMatrixPrice> newPlanMatrix,
        System::Action<NewPlanThresholdTotalAmountPrice> newPlanThresholdTotalAmount,
        System::Action<NewPlanTieredPackagePrice> newPlanTieredPackage,
        System::Action<NewPlanTieredWithMinimumPrice> newPlanTieredWithMinimum,
        System::Action<NewPlanGroupedTieredPrice> newPlanGroupedTiered,
        System::Action<NewPlanTieredPackageWithMinimumPrice> newPlanTieredPackageWithMinimum,
        System::Action<NewPlanPackageWithAllocationPrice> newPlanPackageWithAllocation,
        System::Action<NewPlanUnitWithPercentPrice> newPlanUnitWithPercent,
        System::Action<NewPlanMatrixWithAllocationPrice> newPlanMatrixWithAllocation,
        System::Action<ReplacePricePriceTieredWithProration> tieredWithProration,
        System::Action<NewPlanUnitWithProrationPrice> newPlanUnitWithProration,
        System::Action<NewPlanGroupedAllocationPrice> newPlanGroupedAllocation,
        System::Action<NewPlanBulkWithProrationPrice> newPlanBulkWithProration,
        System::Action<NewPlanGroupedWithProratedMinimumPrice> newPlanGroupedWithProratedMinimum,
        System::Action<NewPlanGroupedWithMeteredMinimumPrice> newPlanGroupedWithMeteredMinimum,
        System::Action<ReplacePricePriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewPlanMatrixWithDisplayNamePrice> newPlanMatrixWithDisplayName,
        System::Action<NewPlanGroupedTieredPackagePrice> newPlanGroupedTieredPackage,
        System::Action<NewPlanMaxGroupTieredPackagePrice> newPlanMaxGroupTieredPackage,
        System::Action<NewPlanScalableMatrixWithUnitPricingPrice> newPlanScalableMatrixWithUnitPricing,
        System::Action<NewPlanScalableMatrixWithTieredPricingPrice> newPlanScalableMatrixWithTieredPricing,
        System::Action<NewPlanCumulativeGroupedBulkPrice> newPlanCumulativeGroupedBulk,
        System::Action<ReplacePricePriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewPlanMinimumCompositePrice> newPlanMinimumComposite,
        System::Action<ReplacePricePricePercent> percent,
        System::Action<ReplacePricePriceEventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case NewPlanUnitPrice value:
                newPlanUnit(value);
                break;
            case NewPlanTieredPrice value:
                newPlanTiered(value);
                break;
            case NewPlanBulkPrice value:
                newPlanBulk(value);
                break;
            case ReplacePricePriceBulkWithFilters value:
                bulkWithFilters(value);
                break;
            case NewPlanPackagePrice value:
                newPlanPackage(value);
                break;
            case NewPlanMatrixPrice value:
                newPlanMatrix(value);
                break;
            case NewPlanThresholdTotalAmountPrice value:
                newPlanThresholdTotalAmount(value);
                break;
            case NewPlanTieredPackagePrice value:
                newPlanTieredPackage(value);
                break;
            case NewPlanTieredWithMinimumPrice value:
                newPlanTieredWithMinimum(value);
                break;
            case NewPlanGroupedTieredPrice value:
                newPlanGroupedTiered(value);
                break;
            case NewPlanTieredPackageWithMinimumPrice value:
                newPlanTieredPackageWithMinimum(value);
                break;
            case NewPlanPackageWithAllocationPrice value:
                newPlanPackageWithAllocation(value);
                break;
            case NewPlanUnitWithPercentPrice value:
                newPlanUnitWithPercent(value);
                break;
            case NewPlanMatrixWithAllocationPrice value:
                newPlanMatrixWithAllocation(value);
                break;
            case ReplacePricePriceTieredWithProration value:
                tieredWithProration(value);
                break;
            case NewPlanUnitWithProrationPrice value:
                newPlanUnitWithProration(value);
                break;
            case NewPlanGroupedAllocationPrice value:
                newPlanGroupedAllocation(value);
                break;
            case NewPlanBulkWithProrationPrice value:
                newPlanBulkWithProration(value);
                break;
            case NewPlanGroupedWithProratedMinimumPrice value:
                newPlanGroupedWithProratedMinimum(value);
                break;
            case NewPlanGroupedWithMeteredMinimumPrice value:
                newPlanGroupedWithMeteredMinimum(value);
                break;
            case ReplacePricePriceGroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case NewPlanMatrixWithDisplayNamePrice value:
                newPlanMatrixWithDisplayName(value);
                break;
            case NewPlanGroupedTieredPackagePrice value:
                newPlanGroupedTieredPackage(value);
                break;
            case NewPlanMaxGroupTieredPackagePrice value:
                newPlanMaxGroupTieredPackage(value);
                break;
            case NewPlanScalableMatrixWithUnitPricingPrice value:
                newPlanScalableMatrixWithUnitPricing(value);
                break;
            case NewPlanScalableMatrixWithTieredPricingPrice value:
                newPlanScalableMatrixWithTieredPricing(value);
                break;
            case NewPlanCumulativeGroupedBulkPrice value:
                newPlanCumulativeGroupedBulk(value);
                break;
            case ReplacePricePriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewPlanMinimumCompositePrice value:
                newPlanMinimumComposite(value);
                break;
            case ReplacePricePricePercent value:
                percent(value);
                break;
            case ReplacePricePriceEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePricePrice"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (NewPlanUnitPrice value) => {...},
    ///     (NewPlanTieredPrice value) => {...},
    ///     (NewPlanBulkPrice value) => {...},
    ///     (ReplacePricePriceBulkWithFilters value) => {...},
    ///     (NewPlanPackagePrice value) => {...},
    ///     (NewPlanMatrixPrice value) => {...},
    ///     (NewPlanThresholdTotalAmountPrice value) => {...},
    ///     (NewPlanTieredPackagePrice value) => {...},
    ///     (NewPlanTieredWithMinimumPrice value) => {...},
    ///     (NewPlanGroupedTieredPrice value) => {...},
    ///     (NewPlanTieredPackageWithMinimumPrice value) => {...},
    ///     (NewPlanPackageWithAllocationPrice value) => {...},
    ///     (NewPlanUnitWithPercentPrice value) => {...},
    ///     (NewPlanMatrixWithAllocationPrice value) => {...},
    ///     (ReplacePricePriceTieredWithProration value) => {...},
    ///     (NewPlanUnitWithProrationPrice value) => {...},
    ///     (NewPlanGroupedAllocationPrice value) => {...},
    ///     (NewPlanBulkWithProrationPrice value) => {...},
    ///     (NewPlanGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewPlanGroupedWithMeteredMinimumPrice value) => {...},
    ///     (ReplacePricePriceGroupedWithMinMaxThresholds value) => {...},
    ///     (NewPlanMatrixWithDisplayNamePrice value) => {...},
    ///     (NewPlanGroupedTieredPackagePrice value) => {...},
    ///     (NewPlanMaxGroupTieredPackagePrice value) => {...},
    ///     (NewPlanScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewPlanScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewPlanCumulativeGroupedBulkPrice value) => {...},
    ///     (ReplacePricePriceCumulativeGroupedAllocation value) => {...},
    ///     (NewPlanMinimumCompositePrice value) => {...},
    ///     (ReplacePricePricePercent value) => {...},
    ///     (ReplacePricePriceEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewPlanUnitPrice, T> newPlanUnit,
        System::Func<NewPlanTieredPrice, T> newPlanTiered,
        System::Func<NewPlanBulkPrice, T> newPlanBulk,
        System::Func<ReplacePricePriceBulkWithFilters, T> bulkWithFilters,
        System::Func<NewPlanPackagePrice, T> newPlanPackage,
        System::Func<NewPlanMatrixPrice, T> newPlanMatrix,
        System::Func<NewPlanThresholdTotalAmountPrice, T> newPlanThresholdTotalAmount,
        System::Func<NewPlanTieredPackagePrice, T> newPlanTieredPackage,
        System::Func<NewPlanTieredWithMinimumPrice, T> newPlanTieredWithMinimum,
        System::Func<NewPlanGroupedTieredPrice, T> newPlanGroupedTiered,
        System::Func<NewPlanTieredPackageWithMinimumPrice, T> newPlanTieredPackageWithMinimum,
        System::Func<NewPlanPackageWithAllocationPrice, T> newPlanPackageWithAllocation,
        System::Func<NewPlanUnitWithPercentPrice, T> newPlanUnitWithPercent,
        System::Func<NewPlanMatrixWithAllocationPrice, T> newPlanMatrixWithAllocation,
        System::Func<ReplacePricePriceTieredWithProration, T> tieredWithProration,
        System::Func<NewPlanUnitWithProrationPrice, T> newPlanUnitWithProration,
        System::Func<NewPlanGroupedAllocationPrice, T> newPlanGroupedAllocation,
        System::Func<NewPlanBulkWithProrationPrice, T> newPlanBulkWithProration,
        System::Func<NewPlanGroupedWithProratedMinimumPrice, T> newPlanGroupedWithProratedMinimum,
        System::Func<NewPlanGroupedWithMeteredMinimumPrice, T> newPlanGroupedWithMeteredMinimum,
        System::Func<ReplacePricePriceGroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        System::Func<NewPlanMatrixWithDisplayNamePrice, T> newPlanMatrixWithDisplayName,
        System::Func<NewPlanGroupedTieredPackagePrice, T> newPlanGroupedTieredPackage,
        System::Func<NewPlanMaxGroupTieredPackagePrice, T> newPlanMaxGroupTieredPackage,
        System::Func<
            NewPlanScalableMatrixWithUnitPricingPrice,
            T
        > newPlanScalableMatrixWithUnitPricing,
        System::Func<
            NewPlanScalableMatrixWithTieredPricingPrice,
            T
        > newPlanScalableMatrixWithTieredPricing,
        System::Func<NewPlanCumulativeGroupedBulkPrice, T> newPlanCumulativeGroupedBulk,
        System::Func<ReplacePricePriceCumulativeGroupedAllocation, T> cumulativeGroupedAllocation,
        System::Func<NewPlanMinimumCompositePrice, T> newPlanMinimumComposite,
        System::Func<ReplacePricePricePercent, T> percent,
        System::Func<ReplacePricePriceEventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewPlanUnitPrice value => newPlanUnit(value),
            NewPlanTieredPrice value => newPlanTiered(value),
            NewPlanBulkPrice value => newPlanBulk(value),
            ReplacePricePriceBulkWithFilters value => bulkWithFilters(value),
            NewPlanPackagePrice value => newPlanPackage(value),
            NewPlanMatrixPrice value => newPlanMatrix(value),
            NewPlanThresholdTotalAmountPrice value => newPlanThresholdTotalAmount(value),
            NewPlanTieredPackagePrice value => newPlanTieredPackage(value),
            NewPlanTieredWithMinimumPrice value => newPlanTieredWithMinimum(value),
            NewPlanGroupedTieredPrice value => newPlanGroupedTiered(value),
            NewPlanTieredPackageWithMinimumPrice value => newPlanTieredPackageWithMinimum(value),
            NewPlanPackageWithAllocationPrice value => newPlanPackageWithAllocation(value),
            NewPlanUnitWithPercentPrice value => newPlanUnitWithPercent(value),
            NewPlanMatrixWithAllocationPrice value => newPlanMatrixWithAllocation(value),
            ReplacePricePriceTieredWithProration value => tieredWithProration(value),
            NewPlanUnitWithProrationPrice value => newPlanUnitWithProration(value),
            NewPlanGroupedAllocationPrice value => newPlanGroupedAllocation(value),
            NewPlanBulkWithProrationPrice value => newPlanBulkWithProration(value),
            NewPlanGroupedWithProratedMinimumPrice value => newPlanGroupedWithProratedMinimum(
                value
            ),
            NewPlanGroupedWithMeteredMinimumPrice value => newPlanGroupedWithMeteredMinimum(value),
            ReplacePricePriceGroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(
                value
            ),
            NewPlanMatrixWithDisplayNamePrice value => newPlanMatrixWithDisplayName(value),
            NewPlanGroupedTieredPackagePrice value => newPlanGroupedTieredPackage(value),
            NewPlanMaxGroupTieredPackagePrice value => newPlanMaxGroupTieredPackage(value),
            NewPlanScalableMatrixWithUnitPricingPrice value => newPlanScalableMatrixWithUnitPricing(
                value
            ),
            NewPlanScalableMatrixWithTieredPricingPrice value =>
                newPlanScalableMatrixWithTieredPricing(value),
            NewPlanCumulativeGroupedBulkPrice value => newPlanCumulativeGroupedBulk(value),
            ReplacePricePriceCumulativeGroupedAllocation value => cumulativeGroupedAllocation(
                value
            ),
            NewPlanMinimumCompositePrice value => newPlanMinimumComposite(value),
            ReplacePricePricePercent value => percent(value),
            ReplacePricePriceEventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePrice"
            ),
        };
    }

    public static implicit operator ReplacePricePrice(NewPlanUnitPrice value) => new(value);

    public static implicit operator ReplacePricePrice(NewPlanTieredPrice value) => new(value);

    public static implicit operator ReplacePricePrice(NewPlanBulkPrice value) => new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePriceBulkWithFilters value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanPackagePrice value) => new(value);

    public static implicit operator ReplacePricePrice(NewPlanMatrixPrice value) => new(value);

    public static implicit operator ReplacePricePrice(NewPlanThresholdTotalAmountPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanTieredPackagePrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanTieredWithMinimumPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanGroupedTieredPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanTieredPackageWithMinimumPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanPackageWithAllocationPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanUnitWithPercentPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanMatrixWithAllocationPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePriceTieredWithProration value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanUnitWithProrationPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanGroupedAllocationPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanBulkWithProrationPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(
        NewPlanGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewPlanGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        ReplacePricePriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator ReplacePricePrice(NewPlanMatrixWithDisplayNamePrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanGroupedTieredPackagePrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(NewPlanMaxGroupTieredPackagePrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(
        NewPlanScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(
        NewPlanScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator ReplacePricePrice(NewPlanCumulativeGroupedBulkPrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(
        ReplacePricePriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator ReplacePricePrice(NewPlanMinimumCompositePrice value) =>
        new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePricePercent value) => new(value);

    public static implicit operator ReplacePricePrice(ReplacePricePriceEventOutput value) =>
        new(value);

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
                "Data did not match any variant of ReplacePricePrice"
            );
        }
        this.Switch(
            (newPlanUnit) => newPlanUnit.Validate(),
            (newPlanTiered) => newPlanTiered.Validate(),
            (newPlanBulk) => newPlanBulk.Validate(),
            (bulkWithFilters) => bulkWithFilters.Validate(),
            (newPlanPackage) => newPlanPackage.Validate(),
            (newPlanMatrix) => newPlanMatrix.Validate(),
            (newPlanThresholdTotalAmount) => newPlanThresholdTotalAmount.Validate(),
            (newPlanTieredPackage) => newPlanTieredPackage.Validate(),
            (newPlanTieredWithMinimum) => newPlanTieredWithMinimum.Validate(),
            (newPlanGroupedTiered) => newPlanGroupedTiered.Validate(),
            (newPlanTieredPackageWithMinimum) => newPlanTieredPackageWithMinimum.Validate(),
            (newPlanPackageWithAllocation) => newPlanPackageWithAllocation.Validate(),
            (newPlanUnitWithPercent) => newPlanUnitWithPercent.Validate(),
            (newPlanMatrixWithAllocation) => newPlanMatrixWithAllocation.Validate(),
            (tieredWithProration) => tieredWithProration.Validate(),
            (newPlanUnitWithProration) => newPlanUnitWithProration.Validate(),
            (newPlanGroupedAllocation) => newPlanGroupedAllocation.Validate(),
            (newPlanBulkWithProration) => newPlanBulkWithProration.Validate(),
            (newPlanGroupedWithProratedMinimum) => newPlanGroupedWithProratedMinimum.Validate(),
            (newPlanGroupedWithMeteredMinimum) => newPlanGroupedWithMeteredMinimum.Validate(),
            (groupedWithMinMaxThresholds) => groupedWithMinMaxThresholds.Validate(),
            (newPlanMatrixWithDisplayName) => newPlanMatrixWithDisplayName.Validate(),
            (newPlanGroupedTieredPackage) => newPlanGroupedTieredPackage.Validate(),
            (newPlanMaxGroupTieredPackage) => newPlanMaxGroupTieredPackage.Validate(),
            (newPlanScalableMatrixWithUnitPricing) =>
                newPlanScalableMatrixWithUnitPricing.Validate(),
            (newPlanScalableMatrixWithTieredPricing) =>
                newPlanScalableMatrixWithTieredPricing.Validate(),
            (newPlanCumulativeGroupedBulk) => newPlanCumulativeGroupedBulk.Validate(),
            (cumulativeGroupedAllocation) => cumulativeGroupedAllocation.Validate(),
            (newPlanMinimumComposite) => newPlanMinimumComposite.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
    }

    public virtual bool Equals(ReplacePricePrice? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ReplacePricePriceConverter : JsonConverter<ReplacePricePrice?>
{
    public override ReplacePricePrice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = element.GetProperty("model_type").GetString();
        }
        catch
        {
            modelType = null;
        }

        switch (modelType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePriceBulkWithFilters>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanPackagePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPackagePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredWithMinimumPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanTieredPackageWithMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanPackageWithAllocationPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "unit_with_percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithPercentPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixWithAllocationPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceTieredWithProration>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "unit_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithProrationPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedAllocationPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkWithProrationPrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanGroupedWithProratedMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanGroupedWithMeteredMinimumPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholds>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanMatrixWithDisplayNamePrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPackagePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanMaxGroupTieredPackagePrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithTieredPricingPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanCumulativeGroupedBulkPrice>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocation>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMinimumCompositePrice>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "event_output":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePriceEventOutput>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePrice(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceBulkWithFilters,
        ReplacePricePriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFilters : JsonModel
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                "bulk_with_filters_config"
            );
        }
        init { this._rawData.Set("bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceBulkWithFiltersConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("bulk_with_filters")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceBulkWithFilters()
    {
        this.ModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
    }

    public ReplacePricePriceBulkWithFilters(
        ReplacePricePriceBulkWithFilters replacePricePriceBulkWithFilters
    )
        : base(replacePricePriceBulkWithFilters) { }

    public ReplacePricePriceBulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("bulk_with_filters");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceBulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceBulkWithFiltersFromRaw : IFromRawJson<ReplacePricePriceBulkWithFilters>
{
    /// <inheritdoc/>
    public ReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceBulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig,
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig : JsonModel
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
            >("filters", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>
            >("tiers", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig() { }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig replacePricePriceBulkWithFiltersBulkWithFiltersConfig
    )
        : base(replacePricePriceBulkWithFiltersBulkWithFiltersConfig) { }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRawJson<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter,
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter : JsonModel
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_key");
        }
        init { this._rawData.Set("property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_value");
        }
        init { this._rawData.Set("property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter() { }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter replacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter
    )
        : base(replacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter) { }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    : IFromRawJson<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter>
{
    /// <inheritdoc/>
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier,
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier() { }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier replacePricePriceBulkWithFiltersBulkWithFiltersConfigTier
    )
        : base(replacePricePriceBulkWithFiltersBulkWithFiltersConfigTier) { }

    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    : IFromRawJson<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier>
{
    /// <inheritdoc/>
    public ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigTier.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceBulkWithFiltersCadenceConverter))]
public enum ReplacePricePriceBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceBulkWithFiltersCadenceConverter
    : JsonConverter<ReplacePricePriceBulkWithFiltersCadence>
{
    public override ReplacePricePriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceBulkWithFiltersCadence.Annual,
            "semi_annual" => ReplacePricePriceBulkWithFiltersCadence.SemiAnnual,
            "monthly" => ReplacePricePriceBulkWithFiltersCadence.Monthly,
            "quarterly" => ReplacePricePriceBulkWithFiltersCadence.Quarterly,
            "one_time" => ReplacePricePriceBulkWithFiltersCadence.OneTime,
            "custom" => ReplacePricePriceBulkWithFiltersCadence.Custom,
            _ => (ReplacePricePriceBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceBulkWithFiltersCadence.Annual => "annual",
                ReplacePricePriceBulkWithFiltersCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceBulkWithFiltersCadence.Monthly => "monthly",
                ReplacePricePriceBulkWithFiltersCadence.Quarterly => "quarterly",
                ReplacePricePriceBulkWithFiltersCadence.OneTime => "one_time",
                ReplacePricePriceBulkWithFiltersCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ReplacePricePriceBulkWithFiltersConversionRateConfigConverter))]
public record class ReplacePricePriceBulkWithFiltersConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePricePriceBulkWithFiltersConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of ReplacePricePriceBulkWithFiltersConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePriceBulkWithFiltersConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ReplacePricePriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceBulkWithFiltersConversionRateConfig>
{
    public override ReplacePricePriceBulkWithFiltersConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceBulkWithFiltersConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceTieredWithProration,
        ReplacePricePriceTieredWithProrationFromRaw
    >)
)]
public sealed record class ReplacePricePriceTieredWithProration : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceTieredWithProrationCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceTieredWithProrationCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required ReplacePricePriceTieredWithProrationTieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                "tiered_with_proration_config"
            );
        }
        init { this._rawData.Set("tiered_with_proration_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceTieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceTieredWithProrationConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("tiered_with_proration")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        this.TieredWithProrationConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceTieredWithProration()
    {
        this.ModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
    }

    public ReplacePricePriceTieredWithProration(
        ReplacePricePriceTieredWithProration replacePricePriceTieredWithProration
    )
        : base(replacePricePriceTieredWithProration) { }

    public ReplacePricePriceTieredWithProration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("tiered_with_proration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceTieredWithProrationFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceTieredWithProrationFromRaw
    : IFromRawJson<ReplacePricePriceTieredWithProration>
{
    /// <inheritdoc/>
    public ReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceTieredWithProration.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceTieredWithProrationCadenceConverter))]
public enum ReplacePricePriceTieredWithProrationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceTieredWithProrationCadenceConverter
    : JsonConverter<ReplacePricePriceTieredWithProrationCadence>
{
    public override ReplacePricePriceTieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceTieredWithProrationCadence.Annual,
            "semi_annual" => ReplacePricePriceTieredWithProrationCadence.SemiAnnual,
            "monthly" => ReplacePricePriceTieredWithProrationCadence.Monthly,
            "quarterly" => ReplacePricePriceTieredWithProrationCadence.Quarterly,
            "one_time" => ReplacePricePriceTieredWithProrationCadence.OneTime,
            "custom" => ReplacePricePriceTieredWithProrationCadence.Custom,
            _ => (ReplacePricePriceTieredWithProrationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceTieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceTieredWithProrationCadence.Annual => "annual",
                ReplacePricePriceTieredWithProrationCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceTieredWithProrationCadence.Monthly => "monthly",
                ReplacePricePriceTieredWithProrationCadence.Quarterly => "quarterly",
                ReplacePricePriceTieredWithProrationCadence.OneTime => "one_time",
                ReplacePricePriceTieredWithProrationCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceTieredWithProrationTieredWithProrationConfig,
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceTieredWithProrationTieredWithProrationConfig : JsonModel
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>
            >("tiers");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>
            >("tiers", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig() { }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        ReplacePricePriceTieredWithProrationTieredWithProrationConfig replacePricePriceTieredWithProrationTieredWithProrationConfig
    )
        : base(replacePricePriceTieredWithProrationTieredWithProrationConfig) { }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        List<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class ReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    : IFromRawJson<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceTieredWithProrationTieredWithProrationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier,
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw
    >)
)]
public sealed record class ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier
    : JsonModel
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tier_lower_bound");
        }
        init { this._rawData.Set("tier_lower_bound", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier() { }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier replacePricePriceTieredWithProrationTieredWithProrationConfigTier
    )
        : base(replacePricePriceTieredWithProrationTieredWithProrationConfigTier) { }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceTieredWithProrationTieredWithProrationConfigTierFromRaw
    : IFromRawJson<ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier>
{
    /// <inheritdoc/>
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceTieredWithProrationTieredWithProrationConfigTier.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePricePriceTieredWithProrationConversionRateConfigConverter))]
public record class ReplacePricePriceTieredWithProrationConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePricePriceTieredWithProrationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceTieredWithProrationConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of ReplacePricePriceTieredWithProrationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePriceTieredWithProrationConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ReplacePricePriceTieredWithProrationConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceTieredWithProrationConversionRateConfig>
{
    public override ReplacePricePriceTieredWithProrationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceTieredWithProrationConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceTieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceGroupedWithMinMaxThresholds,
        ReplacePricePriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class ReplacePricePriceGroupedWithMinMaxThresholds : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { this._rawData.Set("grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds");
    }

    public ReplacePricePriceGroupedWithMinMaxThresholds(
        ReplacePricePriceGroupedWithMinMaxThresholds replacePricePriceGroupedWithMinMaxThresholds
    )
        : base(replacePricePriceGroupedWithMinMaxThresholds) { }

    public ReplacePricePriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("grouped_with_min_max_thresholds");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceGroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceGroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRawJson<ReplacePricePriceGroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
    public ReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceGroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceGroupedWithMinMaxThresholdsCadenceConverter))]
public enum ReplacePricePriceGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
{
    public override ReplacePricePriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom,
            _ => (ReplacePricePriceGroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Annual => "annual",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Quarterly => "quarterly",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                ReplacePricePriceGroupedWithMinMaxThresholdsCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for grouped_with_min_max_thresholds pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : JsonModel
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("maximum_charge");
        }
        init { this._rawData.Set("maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("minimum_charge");
        }
        init { this._rawData.Set("minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("per_unit_rate");
        }
        init { this._rawData.Set("per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig() { }

    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig replacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    )
        : base(replacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig) { }

    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRawJson<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter))]
public record class ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceCumulativeGroupedAllocation,
        ReplacePricePriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class ReplacePricePriceCumulativeGroupedAllocation : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                "cumulative_grouped_allocation_config"
            );
        }
        init { this._rawData.Set("cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("cumulative_grouped_allocation")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceCumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.SerializeToElement("cumulative_grouped_allocation");
    }

    public ReplacePricePriceCumulativeGroupedAllocation(
        ReplacePricePriceCumulativeGroupedAllocation replacePricePriceCumulativeGroupedAllocation
    )
        : base(replacePricePriceCumulativeGroupedAllocation) { }

    public ReplacePricePriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("cumulative_grouped_allocation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceCumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceCumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceCumulativeGroupedAllocationFromRaw
    : IFromRawJson<ReplacePricePriceCumulativeGroupedAllocation>
{
    /// <inheritdoc/>
    public ReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceCumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceCumulativeGroupedAllocationCadenceConverter))]
public enum ReplacePricePriceCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<ReplacePricePriceCumulativeGroupedAllocationCadence>
{
    public override ReplacePricePriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => ReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" => ReplacePricePriceCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => ReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => ReplacePricePriceCumulativeGroupedAllocationCadence.OneTime,
            "custom" => ReplacePricePriceCumulativeGroupedAllocationCadence.Custom,
            _ => (ReplacePricePriceCumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceCumulativeGroupedAllocationCadence.Annual => "annual",
                ReplacePricePriceCumulativeGroupedAllocationCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceCumulativeGroupedAllocationCadence.Monthly => "monthly",
                ReplacePricePriceCumulativeGroupedAllocationCadence.Quarterly => "quarterly",
                ReplacePricePriceCumulativeGroupedAllocationCadence.OneTime => "one_time",
                ReplacePricePriceCumulativeGroupedAllocationCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for cumulative_grouped_allocation pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : JsonModel
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cumulative_allocation");
        }
        init { this._rawData.Set("cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_allocation");
        }
        init { this._rawData.Set("group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig() { }

    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig replacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    )
        : base(replacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig) { }

    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRawJson<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(ReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter))]
public record class ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
                    element
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ReplacePricePricePercent, ReplacePricePricePercentFromRaw>)
)]
public sealed record class ReplacePricePricePercent : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePricePercentCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReplacePricePricePercentCadence>>(
                "cadence"
            );
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required ReplacePricePricePercentPercentConfig PercentConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePricePercentPercentConfig>(
                "percent_config"
            );
        }
        init { this._rawData.Set("percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePricePercentConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        if (!JsonElement.DeepEquals(this.ModelType, JsonSerializer.SerializeToElement("percent")))
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        this.PercentConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePricePercent()
    {
        this.ModelType = JsonSerializer.SerializeToElement("percent");
    }

    public ReplacePricePricePercent(ReplacePricePricePercent replacePricePricePercent)
        : base(replacePricePricePercent) { }

    public ReplacePricePricePercent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("percent");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePricePercent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePricePercentFromRaw.FromRawUnchecked"/>
    public static ReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePricePercentFromRaw : IFromRawJson<ReplacePricePricePercent>
{
    /// <inheritdoc/>
    public ReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePricePercentCadenceConverter))]
public enum ReplacePricePricePercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePricePercentCadenceConverter
    : JsonConverter<ReplacePricePricePercentCadence>
{
    public override ReplacePricePricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePricePercentCadence.Annual,
            "semi_annual" => ReplacePricePricePercentCadence.SemiAnnual,
            "monthly" => ReplacePricePricePercentCadence.Monthly,
            "quarterly" => ReplacePricePricePercentCadence.Quarterly,
            "one_time" => ReplacePricePricePercentCadence.OneTime,
            "custom" => ReplacePricePricePercentCadence.Custom,
            _ => (ReplacePricePricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePricePercentCadence.Annual => "annual",
                ReplacePricePricePercentCadence.SemiAnnual => "semi_annual",
                ReplacePricePricePercentCadence.Monthly => "monthly",
                ReplacePricePricePercentCadence.Quarterly => "quarterly",
                ReplacePricePricePercentCadence.OneTime => "one_time",
                ReplacePricePricePercentCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePricePercentPercentConfig,
        ReplacePricePricePercentPercentConfigFromRaw
    >)
)]
public sealed record class ReplacePricePricePercentPercentConfig : JsonModel
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
    }

    public ReplacePricePricePercentPercentConfig() { }

    public ReplacePricePricePercentPercentConfig(
        ReplacePricePricePercentPercentConfig replacePricePricePercentPercentConfig
    )
        : base(replacePricePricePercentPercentConfig) { }

    public ReplacePricePricePercentPercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePricePercentPercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePricePercentPercentConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class ReplacePricePricePercentPercentConfigFromRaw
    : IFromRawJson<ReplacePricePricePercentPercentConfig>
{
    /// <inheritdoc/>
    public ReplacePricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePricePercentPercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePricePricePercentConversionRateConfigConverter))]
public record class ReplacePricePricePercentConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePricePercentConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePricePricePercentConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePricePercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of ReplacePricePricePercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePricePercentConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ReplacePricePricePercentConversionRateConfigConverter
    : JsonConverter<ReplacePricePricePercentConversionRateConfig>
{
    public override ReplacePricePricePercentConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePricePercentConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ReplacePricePriceEventOutput, ReplacePricePriceEventOutputFromRaw>)
)]
public sealed record class ReplacePricePriceEventOutput : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceEventOutputCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ReplacePricePriceEventOutputCadence>
            >("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required ReplacePricePriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReplacePricePriceEventOutputEventOutputConfig>(
                "event_output_config"
            );
        }
        init { this._rawData.Set("event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("model_type");
        }
        init { this._rawData.Set("model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billable_metric_id");
        }
        init { this._rawData.Set("billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("billed_in_advance");
        }
        init { this._rawData.Set("billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "billing_cycle_configuration"
            );
        }
        init { this._rawData.Set("billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("conversion_rate");
        }
        init { this._rawData.Set("conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReplacePricePriceEventOutputConversionRateConfig>(
                "conversion_rate_config"
            );
        }
        init { this._rawData.Set("conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewDimensionalPriceConfiguration>(
                "dimensional_price_configuration"
            );
        }
        init { this._rawData.Set("dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_price_id");
        }
        init { this._rawData.Set("external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fixed_price_quantity");
        }
        init { this._rawData.Set("fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_grouping_key");
        }
        init { this._rawData.Set("invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NewBillingCycleConfiguration>(
                "invoicing_cycle_configuration"
            );
        }
        init { this._rawData.Set("invoicing_cycle_configuration", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference_id");
        }
        init { this._rawData.Set("reference_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.SerializeToElement("event_output")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        _ = this.Currency;
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
        _ = this.ReferenceID;
    }

    public ReplacePricePriceEventOutput()
    {
        this.ModelType = JsonSerializer.SerializeToElement("event_output");
    }

    public ReplacePricePriceEventOutput(ReplacePricePriceEventOutput replacePricePriceEventOutput)
        : base(replacePricePriceEventOutput) { }

    public ReplacePricePriceEventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ModelType = JsonSerializer.SerializeToElement("event_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceEventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceEventOutputFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceEventOutputFromRaw : IFromRawJson<ReplacePricePriceEventOutput>
{
    /// <inheritdoc/>
    public ReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceEventOutputCadenceConverter))]
public enum ReplacePricePriceEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class ReplacePricePriceEventOutputCadenceConverter
    : JsonConverter<ReplacePricePriceEventOutputCadence>
{
    public override ReplacePricePriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => ReplacePricePriceEventOutputCadence.Annual,
            "semi_annual" => ReplacePricePriceEventOutputCadence.SemiAnnual,
            "monthly" => ReplacePricePriceEventOutputCadence.Monthly,
            "quarterly" => ReplacePricePriceEventOutputCadence.Quarterly,
            "one_time" => ReplacePricePriceEventOutputCadence.OneTime,
            "custom" => ReplacePricePriceEventOutputCadence.Custom,
            _ => (ReplacePricePriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReplacePricePriceEventOutputCadence.Annual => "annual",
                ReplacePricePriceEventOutputCadence.SemiAnnual => "semi_annual",
                ReplacePricePriceEventOutputCadence.Monthly => "monthly",
                ReplacePricePriceEventOutputCadence.Quarterly => "quarterly",
                ReplacePricePriceEventOutputCadence.OneTime => "one_time",
                ReplacePricePriceEventOutputCadence.Custom => "custom",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for event_output pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReplacePricePriceEventOutputEventOutputConfig,
        ReplacePricePriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceEventOutputEventOutputConfig : JsonModel
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_rating_key");
        }
        init { this._rawData.Set("unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("default_unit_rate");
        }
        init { this._rawData.Set("default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public ReplacePricePriceEventOutputEventOutputConfig() { }

    public ReplacePricePriceEventOutputEventOutputConfig(
        ReplacePricePriceEventOutputEventOutputConfig replacePricePriceEventOutputEventOutputConfig
    )
        : base(replacePricePriceEventOutputEventOutputConfig) { }

    public ReplacePricePriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceEventOutputEventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReplacePricePriceEventOutputEventOutputConfigFromRaw.FromRawUnchecked"/>
    public static ReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceEventOutputEventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class ReplacePricePriceEventOutputEventOutputConfigFromRaw
    : IFromRawJson<ReplacePricePriceEventOutputEventOutputConfig>
{
    /// <inheritdoc/>
    public ReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReplacePricePriceEventOutputEventOutputConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReplacePricePriceEventOutputConversionRateConfigConverter))]
public record class ReplacePricePriceEventOutputConversionRateConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ReplacePricePriceEventOutputConversionRateConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedUnitConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnit(out var value)) {
    ///     // `value` is of type `SharedUnitConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharedTieredConversionRateConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTiered(out var value)) {
    ///     // `value` is of type `SharedTieredConversionRateConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SharedUnitConversionRateConfig> unit,
        System::Action<SharedTieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case SharedUnitConversionRateConfig value:
                unit(value);
                break;
            case SharedTieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ReplacePricePriceEventOutputConversionRateConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (SharedUnitConversionRateConfig value) => {...},
    ///     (SharedTieredConversionRateConfig value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SharedUnitConversionRateConfig, T> unit,
        System::Func<SharedTieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            SharedUnitConversionRateConfig value => unit(value),
            SharedTieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator ReplacePricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator ReplacePricePriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value
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
                "Data did not match any variant of ReplacePricePriceEventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
    }

    public virtual bool Equals(ReplacePricePriceEventOutputConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ReplacePricePriceEventOutputConversionRateConfigConverter
    : JsonConverter<ReplacePricePriceEventOutputConversionRateConfig>
{
    public override ReplacePricePriceEventOutputConversionRateConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = element.GetProperty("conversion_rate_type").GetString();
        }
        catch
        {
            conversionRateType = null;
        }

        switch (conversionRateType)
        {
            case "unit":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedUnitConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ReplacePricePriceEventOutputConversionRateConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReplacePricePriceEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
