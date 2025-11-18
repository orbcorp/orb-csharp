using System.Collections.Frozen;
using System.Collections.Generic;
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
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string PlanID { get; init; }

    /// <summary>
    /// New version number.
    /// </summary>
    public required long Version
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("version", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'version' cannot be null",
                    new System::ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional adjustments to be added to the plan.
    /// </summary>
    public List<AddAdjustment>? AddAdjustments
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("add_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddAdjustment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["add_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional prices to be added to the plan.
    /// </summary>
    public List<AddPrice>? AddPrices
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("add_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddPrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["add_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Adjustments to be removed from the plan.
    /// </summary>
    public List<RemoveAdjustment>? RemoveAdjustments
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("remove_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RemoveAdjustment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["remove_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Prices to be removed from the plan.
    /// </summary>
    public List<RemovePrice>? RemovePrices
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("remove_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<RemovePrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["remove_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Adjustments to be replaced with additional adjustments on the plan.
    /// </summary>
    public List<ReplaceAdjustment>? ReplaceAdjustments
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("replace_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ReplaceAdjustment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["replace_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Prices to be replaced with additional prices on the plan.
    /// </summary>
    public List<ReplacePrice>? ReplacePrices
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("replace_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ReplacePrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["replace_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._bodyProperties.TryGetValue("set_as_default", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["set_as_default"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BetaCreatePlanVersionParams() { }

    public BetaCreatePlanVersionParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCreatePlanVersionParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static BetaCreatePlanVersionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
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

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<AddAdjustment>))]
public sealed record class AddAdjustment : ModelBase, IFromRaw<AddAdjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required AddAdjustmentAdjustment Adjustment
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AddAdjustmentAdjustment>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentNullException("adjustment")
                );
        }
        init
        {
            this._properties["adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.PlanPhaseOrder;
    }

    public AddAdjustment() { }

    public AddAdjustment(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustment(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AddAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public AddAdjustment(AddAdjustmentAdjustment adjustment)
        : this()
    {
        this.Adjustment = adjustment;
    }
}

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(AddAdjustmentAdjustmentConverter))]
public record class AddAdjustmentAdjustment
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public AddAdjustmentAdjustment(NewPercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentAdjustment(NewUsageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentAdjustment(NewAmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentAdjustment(NewMinimum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentAdjustment(NewMaximum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentAdjustment(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = this.Value as NewPercentageDiscount;
        return value != null;
    }

    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = this.Value as NewUsageDiscount;
        return value != null;
    }

    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = this.Value as NewAmountDiscount;
        return value != null;
    }

    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = this.Value as NewMinimum;
        return value != null;
    }

    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = this.Value as NewMaximum;
        return value != null;
    }

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
                    "Data did not match any variant of AddAdjustmentAdjustment"
                );
        }
    }

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
                "Data did not match any variant of AddAdjustmentAdjustment"
            ),
        };
    }

    public static implicit operator AddAdjustmentAdjustment(NewPercentageDiscount value) =>
        new(value);

    public static implicit operator AddAdjustmentAdjustment(NewUsageDiscount value) => new(value);

    public static implicit operator AddAdjustmentAdjustment(NewAmountDiscount value) => new(value);

    public static implicit operator AddAdjustmentAdjustment(NewMinimum value) => new(value);

    public static implicit operator AddAdjustmentAdjustment(NewMaximum value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddAdjustmentAdjustment"
            );
        }
    }
}

sealed class AddAdjustmentAdjustmentConverter : JsonConverter<AddAdjustmentAdjustment>
{
    public override AddAdjustmentAdjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = json.GetProperty("adjustment_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "usage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "amount_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "maximum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new AddAdjustmentAdjustment(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddAdjustmentAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<AddPrice>))]
public sealed record class AddPrice : ModelBase, IFromRaw<AddPrice>
{
    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this._properties.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewAllocationPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["allocation_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The phase to add this price to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New plan price request body params.
    /// </summary>
    public global::Orb.Models.Beta.Price? Price
    {
        get
        {
            if (!this._properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.Price?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public AddPrice() { }

    public AddPrice(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPrice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AddPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// New plan price request body params.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.PriceConverter))]
public record class Price
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public Price(NewPlanUnitPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(global::Orb.Models.Beta.BulkWithFilters value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanMatrixPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanThresholdTotalAmountPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanTieredWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanGroupedTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanTieredPackageWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanPackageWithAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanUnitWithPercentPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanMatrixWithAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(global::Orb.Models.Beta.TieredWithProration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanUnitWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanGroupedAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanBulkWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanGroupedWithProratedMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanGroupedWithMeteredMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(
        global::Orb.Models.Beta.GroupedWithMinMaxThresholds value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanMatrixWithDisplayNamePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanGroupedTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanMaxGroupTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanScalableMatrixWithUnitPricingPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanScalableMatrixWithTieredPricingPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanCumulativeGroupedBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(
        global::Orb.Models.Beta.CumulativeGroupedAllocation value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public Price(NewPlanMinimumCompositePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(global::Orb.Models.Beta.Percent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(global::Orb.Models.Beta.EventOutput value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewPlanUnit([NotNullWhen(true)] out NewPlanUnitPrice? value)
    {
        value = this.Value as NewPlanUnitPrice;
        return value != null;
    }

    public bool TryPickNewPlanTiered([NotNullWhen(true)] out NewPlanTieredPrice? value)
    {
        value = this.Value as NewPlanTieredPrice;
        return value != null;
    }

    public bool TryPickNewPlanBulk([NotNullWhen(true)] out NewPlanBulkPrice? value)
    {
        value = this.Value as NewPlanBulkPrice;
        return value != null;
    }

    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out global::Orb.Models.Beta.BulkWithFilters? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.BulkWithFilters;
        return value != null;
    }

    public bool TryPickNewPlanPackage([NotNullWhen(true)] out NewPlanPackagePrice? value)
    {
        value = this.Value as NewPlanPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanMatrix([NotNullWhen(true)] out NewPlanMatrixPrice? value)
    {
        value = this.Value as NewPlanMatrixPrice;
        return value != null;
    }

    public bool TryPickNewPlanThresholdTotalAmount(
        [NotNullWhen(true)] out NewPlanThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewPlanThresholdTotalAmountPrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackage(
        [NotNullWhen(true)] out NewPlanTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTiered(
        [NotNullWhen(true)] out NewPlanGroupedTieredPrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredPackageWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanPackageWithAllocation(
        [NotNullWhen(true)] out NewPlanPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanPackageWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithPercent(
        [NotNullWhen(true)] out NewPlanUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithPercentPrice;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithAllocation(
        [NotNullWhen(true)] out NewPlanMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithAllocationPrice;
        return value != null;
    }

    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out global::Orb.Models.Beta.TieredWithProration? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.TieredWithProration;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithProration(
        [NotNullWhen(true)] out NewPlanUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedAllocation(
        [NotNullWhen(true)] out NewPlanGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewPlanGroupedAllocationPrice;
        return value != null;
    }

    public bool TryPickNewPlanBulkWithProration(
        [NotNullWhen(true)] out NewPlanBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanBulkWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithProratedMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out global::Orb.Models.Beta.GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.GroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithDisplayName(
        [NotNullWhen(true)] out NewPlanMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithDisplayNamePrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTieredPackage(
        [NotNullWhen(true)] out NewPlanGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewPlanMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanMaxGroupTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    public bool TryPickNewPlanCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewPlanCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewPlanCumulativeGroupedBulkPrice;
        return value != null;
    }

    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out global::Orb.Models.Beta.CumulativeGroupedAllocation? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.CumulativeGroupedAllocation;
        return value != null;
    }

    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = this.Value as NewPlanMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out global::Orb.Models.Beta.Percent? value)
    {
        value = this.Value as global::Orb.Models.Beta.Percent;
        return value != null;
    }

    public bool TryPickEventOutput(
        [NotNullWhen(true)] out global::Orb.Models.Beta.EventOutput? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.EventOutput;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }
}

sealed class PriceConverter : JsonConverter<global::Orb.Models.Beta.Price?>
{
    public override global::Orb.Models.Beta.Price? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = json.GetProperty("model_type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.BulkWithFilters>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredWithMinimumPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "unit_with_percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixWithAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.TieredWithProration>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "unit_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.GroupedWithMinMaxThresholds>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.CumulativeGroupedAllocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<global::Orb.Models.Beta.Percent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "event_output":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.EventOutput>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new global::Orb.Models.Beta.Price(json);
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

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.BulkWithFilters>))]
public sealed record class BulkWithFilters
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.BulkWithFilters>
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required global::Orb.Models.Beta.BulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            if (!this._properties.TryGetValue("bulk_with_filters_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "bulk_with_filters_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.BulkWithFiltersConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentNullException("bulk_with_filters_config")
                );
        }
        init
        {
            this._properties["bulk_with_filters_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public BulkWithFilters(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.BulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.BulkWithFiltersConfig>))]
public sealed record class BulkWithFiltersConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.BulkWithFiltersConfig>
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required List<global::Orb.Models.Beta.Filter> Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Beta.Filter>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        init
        {
            this._properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required List<global::Orb.Models.Beta.Tier> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Beta.Tier>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public BulkWithFiltersConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.Filter>))]
public sealed record class Filter : ModelBase, IFromRaw<global::Orb.Models.Beta.Filter>
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            if (!this._properties.TryGetValue("property_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentNullException("property_key")
                );
        }
        init
        {
            this._properties["property_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            if (!this._properties.TryGetValue("property_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentNullException("property_value")
                );
        }
        init
        {
            this._properties["property_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public Filter() { }

    public Filter(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.Tier>))]
public sealed record class Tier : ModelBase, IFromRaw<global::Orb.Models.Beta.Tier>
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier() { }

    public Tier(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.Tier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Tier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
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

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType
{
    public JsonElement Json { get; private init; }

    public ModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType().Json))
        {
            throw new OrbInvalidDataException("Invalid value given for 'ModelType'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType>
    {
        public override global::Orb.Models.Beta.ModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfigConverter))]
public record class ConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ConversionRateConfig(SharedUnitConversionRateConfig value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ConversionRateConfig(SharedTieredConversionRateConfig value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new global::Orb.Models.Beta.ConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.TieredWithProration>))]
public sealed record class TieredWithProration
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.TieredWithProration>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.TieredWithProrationCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Beta.TieredWithProrationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.TieredWithProrationModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.TieredWithProrationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required global::Orb.Models.Beta.TieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "tiered_with_proration_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tiered_with_proration_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.TieredWithProrationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentNullException("tiered_with_proration_config")
                );
        }
        init
        {
            this._properties["tiered_with_proration_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.TieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.TieredWithProrationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public TieredWithProration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.TieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class TieredWithProrationModelType
{
    public JsonElement Json { get; private init; }

    public TieredWithProrationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    TieredWithProrationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.TieredWithProrationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'TieredWithProrationModelType'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.TieredWithProrationModelType>
    {
        public override global::Orb.Models.Beta.TieredWithProrationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.TieredWithProrationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.TieredWithProrationConfig>))]
public sealed record class TieredWithProrationConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.TieredWithProrationConfig>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required List<global::Orb.Models.Beta.TierModel> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Beta.TierModel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public TieredWithProrationConfig() { }

    public TieredWithProrationConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.TieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TieredWithProrationConfig(List<global::Orb.Models.Beta.TierModel> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.TierModel>))]
public sealed record class TierModel : ModelBase, IFromRaw<global::Orb.Models.Beta.TierModel>
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tier_lower_bound",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentNullException("tier_lower_bound")
                );
        }
        init
        {
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public TierModel() { }

    public TierModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TierModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.TierModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.TieredWithProrationConversionRateConfigConverter))]
public record class TieredWithProrationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public TieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public TieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public TieredWithProrationConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of TieredWithProrationConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new global::Orb.Models.Beta.TieredWithProrationConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.GroupedWithMinMaxThresholds>))]
public sealed record class GroupedWithMinMaxThresholds
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.GroupedWithMinMaxThresholds>
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
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Beta.GroupedWithMinMaxThresholdsCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "grouped_with_min_max_thresholds_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouped_with_min_max_thresholds_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentNullException("grouped_with_min_max_thresholds_config")
                );
        }
        init
        {
            this._properties["grouped_with_min_max_thresholds_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.GroupedWithMinMaxThresholdsModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public GroupedWithMinMaxThresholds(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig>))]
public sealed record class GroupedWithMinMaxThresholdsConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig>
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            if (!this._properties.TryGetValue("maximum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "maximum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentNullException("maximum_charge")
                );
        }
        init
        {
            this._properties["maximum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            if (!this._properties.TryGetValue("minimum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentNullException("minimum_charge")
                );
        }
        init
        {
            this._properties["minimum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            if (!this._properties.TryGetValue("per_unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "per_unit_rate",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentNullException("per_unit_rate")
                );
        }
        init
        {
            this._properties["per_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public GroupedWithMinMaxThresholdsConfig() { }

    public GroupedWithMinMaxThresholdsConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class GroupedWithMinMaxThresholdsModelType
{
    public JsonElement Json { get; private init; }

    public GroupedWithMinMaxThresholdsModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    GroupedWithMinMaxThresholdsModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.GroupedWithMinMaxThresholdsModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'GroupedWithMinMaxThresholdsModelType'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.GroupedWithMinMaxThresholdsModelType>
    {
        public override global::Orb.Models.Beta.GroupedWithMinMaxThresholdsModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.GroupedWithMinMaxThresholdsModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
public record class GroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public GroupedWithMinMaxThresholdsConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of GroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new global::Orb.Models.Beta.GroupedWithMinMaxThresholdsConversionRateConfig(
                    json
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

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.CumulativeGroupedAllocation>))]
public sealed record class CumulativeGroupedAllocation
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.CumulativeGroupedAllocation>
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
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Beta.CumulativeGroupedAllocationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required global::Orb.Models.Beta.CumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "cumulative_grouped_allocation_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_grouped_allocation_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.CumulativeGroupedAllocationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentNullException("cumulative_grouped_allocation_config")
                );
        }
        init
        {
            this._properties["cumulative_grouped_allocation_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.CumulativeGroupedAllocationModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.CumulativeGroupedAllocationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public CumulativeGroupedAllocation(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.CumulativeGroupedAllocationConfig>))]
public sealed record class CumulativeGroupedAllocationConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.CumulativeGroupedAllocationConfig>
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            if (!this._properties.TryGetValue("cumulative_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentNullException("cumulative_allocation")
                );
        }
        init
        {
            this._properties["cumulative_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            if (!this._properties.TryGetValue("group_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "group_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentNullException("group_allocation")
                );
        }
        init
        {
            this._properties["group_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public CumulativeGroupedAllocationConfig() { }

    public CumulativeGroupedAllocationConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocationConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class CumulativeGroupedAllocationModelType
{
    public JsonElement Json { get; private init; }

    public CumulativeGroupedAllocationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"");
    }

    CumulativeGroupedAllocationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.CumulativeGroupedAllocationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'CumulativeGroupedAllocationModelType'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.CumulativeGroupedAllocationModelType>
    {
        public override global::Orb.Models.Beta.CumulativeGroupedAllocationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.CumulativeGroupedAllocationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfigConverter)
)]
public record class CumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public CumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public CumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public CumulativeGroupedAllocationConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of CumulativeGroupedAllocationConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new global::Orb.Models.Beta.CumulativeGroupedAllocationConversionRateConfig(
                    json
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

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.Percent>))]
public sealed record class Percent : ModelBase, IFromRaw<global::Orb.Models.Beta.Percent>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.PercentCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Beta.PercentCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.PercentModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.PercentModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required global::Orb.Models.Beta.PercentConfig PercentConfig
    {
        get
        {
            if (!this._properties.TryGetValue("percent_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percent_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.PercentConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentNullException("percent_config")
                );
        }
        init
        {
            this._properties["percent_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.PercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.PercentConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public Percent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.Percent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PercentModelType
{
    public JsonElement Json { get; private init; }

    public PercentModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    PercentModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.PercentModelType().Json))
        {
            throw new OrbInvalidDataException("Invalid value given for 'PercentModelType'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.PercentModelType>
    {
        public override global::Orb.Models.Beta.PercentModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.PercentModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.PercentConfig>))]
public sealed record class PercentConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.PercentConfig>
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            if (!this._properties.TryGetValue("percent", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent' cannot be null",
                    new System::ArgumentOutOfRangeException("percent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public PercentConfig() { }

    public PercentConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.PercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public PercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.PercentConversionRateConfigConverter))]
public record class PercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PercentConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PercentConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new global::Orb.Models.Beta.PercentConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.EventOutput>))]
public sealed record class EventOutput : ModelBase, IFromRaw<global::Orb.Models.Beta.EventOutput>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.EventOutputCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Beta.EventOutputCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required global::Orb.Models.Beta.EventOutputConfig EventOutputConfig
    {
        get
        {
            if (!this._properties.TryGetValue("event_output_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_output_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.EventOutputConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentNullException("event_output_config")
                );
        }
        init
        {
            this._properties["event_output_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.EventOutputModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.EventOutputModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.EventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.EventOutputConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public EventOutput(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.EventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.EventOutputConfig>))]
public sealed record class EventOutputConfig
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.EventOutputConfig>
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this._properties.TryGetValue("unit_rating_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_rating_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentNullException("unit_rating_key")
                );
        }
        init
        {
            this._properties["unit_rating_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._properties.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["default_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public EventOutputConfig() { }

    public EventOutputConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.EventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public EventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class EventOutputModelType
{
    public JsonElement Json { get; private init; }

    public EventOutputModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    EventOutputModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.EventOutputModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'EventOutputModelType'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.EventOutputModelType>
    {
        public override global::Orb.Models.Beta.EventOutputModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.EventOutputModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.EventOutputConversionRateConfigConverter))]
public record class EventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public EventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public EventOutputConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of EventOutputConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new global::Orb.Models.Beta.EventOutputConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<RemoveAdjustment>))]
public sealed record class RemoveAdjustment : ModelBase, IFromRaw<RemoveAdjustment>
{
    /// <summary>
    /// The id of the adjustment to remove from on the plan.
    /// </summary>
    public required string AdjustmentID
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment_id' cannot be null",
                    new System::ArgumentNullException("adjustment_id")
                );
        }
        init
        {
            this._properties["adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The phase to remove this adjustment from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AdjustmentID;
        _ = this.PlanPhaseOrder;
    }

    public RemoveAdjustment() { }

    public RemoveAdjustment(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveAdjustment(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RemoveAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public RemoveAdjustment(string adjustmentID)
        : this()
    {
        this.AdjustmentID = adjustmentID;
    }
}

[JsonConverter(typeof(ModelConverter<RemovePrice>))]
public sealed record class RemovePrice : ModelBase, IFromRaw<RemovePrice>
{
    /// <summary>
    /// The id of the price to remove from the plan.
    /// </summary>
    public required string PriceID
    {
        get
        {
            if (!this._properties.TryGetValue("price_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price_id' cannot be null",
                    new System::ArgumentOutOfRangeException("price_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'price_id' cannot be null",
                    new System::ArgumentNullException("price_id")
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

    /// <summary>
    /// The phase to remove this price from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PriceID;
        _ = this.PlanPhaseOrder;
    }

    public RemovePrice() { }

    public RemovePrice(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemovePrice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RemovePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public RemovePrice(string priceID)
        : this()
    {
        this.PriceID = priceID;
    }
}

[JsonConverter(typeof(ModelConverter<ReplaceAdjustment>))]
public sealed record class ReplaceAdjustment : ModelBase, IFromRaw<ReplaceAdjustment>
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required ReplaceAdjustmentAdjustment Adjustment
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplaceAdjustmentAdjustment>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new System::ArgumentNullException("adjustment")
                );
        }
        init
        {
            this._properties["adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the adjustment on the plan to replace in the plan.
    /// </summary>
    public required string ReplacesAdjustmentID
    {
        get
        {
            if (!this._properties.TryGetValue("replaces_adjustment_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'replaces_adjustment_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "replaces_adjustment_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'replaces_adjustment_id' cannot be null",
                    new System::ArgumentNullException("replaces_adjustment_id")
                );
        }
        init
        {
            this._properties["replaces_adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The phase to replace this adjustment from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.ReplacesAdjustmentID;
        _ = this.PlanPhaseOrder;
    }

    public ReplaceAdjustment() { }

    public ReplaceAdjustment(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplaceAdjustment(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplaceAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(ReplaceAdjustmentAdjustmentConverter))]
public record class ReplaceAdjustmentAdjustment
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public ReplaceAdjustmentAdjustment(NewPercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentAdjustment(NewUsageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentAdjustment(NewAmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentAdjustment(NewMinimum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentAdjustment(NewMaximum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplaceAdjustmentAdjustment(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewPercentageDiscount([NotNullWhen(true)] out NewPercentageDiscount? value)
    {
        value = this.Value as NewPercentageDiscount;
        return value != null;
    }

    public bool TryPickNewUsageDiscount([NotNullWhen(true)] out NewUsageDiscount? value)
    {
        value = this.Value as NewUsageDiscount;
        return value != null;
    }

    public bool TryPickNewAmountDiscount([NotNullWhen(true)] out NewAmountDiscount? value)
    {
        value = this.Value as NewAmountDiscount;
        return value != null;
    }

    public bool TryPickNewMinimum([NotNullWhen(true)] out NewMinimum? value)
    {
        value = this.Value as NewMinimum;
        return value != null;
    }

    public bool TryPickNewMaximum([NotNullWhen(true)] out NewMaximum? value)
    {
        value = this.Value as NewMaximum;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplaceAdjustmentAdjustment"
            );
        }
    }
}

sealed class ReplaceAdjustmentAdjustmentConverter : JsonConverter<ReplaceAdjustmentAdjustment>
{
    public override ReplaceAdjustmentAdjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = json.GetProperty("adjustment_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "usage_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "amount_discount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "maximum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ReplaceAdjustmentAdjustment(json);
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

[JsonConverter(typeof(ModelConverter<ReplacePrice>))]
public sealed record class ReplacePrice : ModelBase, IFromRaw<ReplacePrice>
{
    /// <summary>
    /// The id of the price on the plan to replace in the plan.
    /// </summary>
    public required string ReplacesPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("replaces_price_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'replaces_price_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "replaces_price_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'replaces_price_id' cannot be null",
                    new System::ArgumentNullException("replaces_price_id")
                );
        }
        init
        {
            this._properties["replaces_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this._properties.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewAllocationPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["allocation_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The phase to replace this price from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this._properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New plan price request body params.
    /// </summary>
    public ReplacePricePrice? Price
    {
        get
        {
            if (!this._properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePricePrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ReplacesPriceID;
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public ReplacePrice() { }

    public ReplacePrice(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePrice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ReplacePrice(string replacesPriceID)
        : this()
    {
        this.ReplacesPriceID = replacesPriceID;
    }
}

/// <summary>
/// New plan price request body params.
/// </summary>
[JsonConverter(typeof(ReplacePricePriceConverter))]
public record class ReplacePricePrice
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public ReplacePricePrice(NewPlanUnitPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(ReplacePricePriceBulkWithFilters value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanMatrixPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanThresholdTotalAmountPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanTieredWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanGroupedTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanTieredPackageWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanPackageWithAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanUnitWithPercentPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanMatrixWithAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(ReplacePricePriceTieredWithProration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanUnitWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanGroupedAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanBulkWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanGroupedWithProratedMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanGroupedWithMeteredMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(
        ReplacePricePriceGroupedWithMinMaxThresholds value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanMatrixWithDisplayNamePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanGroupedTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanMaxGroupTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(
        NewPlanScalableMatrixWithUnitPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(
        NewPlanScalableMatrixWithTieredPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanCumulativeGroupedBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(
        ReplacePricePriceCumulativeGroupedAllocation value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(NewPlanMinimumCompositePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(ReplacePricePricePercent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(ReplacePricePriceEventOutput value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewPlanUnit([NotNullWhen(true)] out NewPlanUnitPrice? value)
    {
        value = this.Value as NewPlanUnitPrice;
        return value != null;
    }

    public bool TryPickNewPlanTiered([NotNullWhen(true)] out NewPlanTieredPrice? value)
    {
        value = this.Value as NewPlanTieredPrice;
        return value != null;
    }

    public bool TryPickNewPlanBulk([NotNullWhen(true)] out NewPlanBulkPrice? value)
    {
        value = this.Value as NewPlanBulkPrice;
        return value != null;
    }

    public bool TryPickBulkWithFilters(
        [NotNullWhen(true)] out ReplacePricePriceBulkWithFilters? value
    )
    {
        value = this.Value as ReplacePricePriceBulkWithFilters;
        return value != null;
    }

    public bool TryPickNewPlanPackage([NotNullWhen(true)] out NewPlanPackagePrice? value)
    {
        value = this.Value as NewPlanPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanMatrix([NotNullWhen(true)] out NewPlanMatrixPrice? value)
    {
        value = this.Value as NewPlanMatrixPrice;
        return value != null;
    }

    public bool TryPickNewPlanThresholdTotalAmount(
        [NotNullWhen(true)] out NewPlanThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewPlanThresholdTotalAmountPrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackage(
        [NotNullWhen(true)] out NewPlanTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTiered(
        [NotNullWhen(true)] out NewPlanGroupedTieredPrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPrice;
        return value != null;
    }

    public bool TryPickNewPlanTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewPlanTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewPlanTieredPackageWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanPackageWithAllocation(
        [NotNullWhen(true)] out NewPlanPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanPackageWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithPercent(
        [NotNullWhen(true)] out NewPlanUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithPercentPrice;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithAllocation(
        [NotNullWhen(true)] out NewPlanMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithAllocationPrice;
        return value != null;
    }

    public bool TryPickTieredWithProration(
        [NotNullWhen(true)] out ReplacePricePriceTieredWithProration? value
    )
    {
        value = this.Value as ReplacePricePriceTieredWithProration;
        return value != null;
    }

    public bool TryPickNewPlanUnitWithProration(
        [NotNullWhen(true)] out NewPlanUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanUnitWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedAllocation(
        [NotNullWhen(true)] out NewPlanGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewPlanGroupedAllocationPrice;
        return value != null;
    }

    public bool TryPickNewPlanBulkWithProration(
        [NotNullWhen(true)] out NewPlanBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewPlanBulkWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithProratedMinimumPrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewPlanGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewPlanGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out ReplacePricePriceGroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as ReplacePricePriceGroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickNewPlanMatrixWithDisplayName(
        [NotNullWhen(true)] out NewPlanMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewPlanMatrixWithDisplayNamePrice;
        return value != null;
    }

    public bool TryPickNewPlanGroupedTieredPackage(
        [NotNullWhen(true)] out NewPlanGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanGroupedTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewPlanMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewPlanMaxGroupTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    public bool TryPickNewPlanScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewPlanScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewPlanScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    public bool TryPickNewPlanCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewPlanCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewPlanCumulativeGroupedBulkPrice;
        return value != null;
    }

    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out ReplacePricePriceCumulativeGroupedAllocation? value
    )
    {
        value = this.Value as ReplacePricePriceCumulativeGroupedAllocation;
        return value != null;
    }

    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = this.Value as NewPlanMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out ReplacePricePricePercent? value)
    {
        value = this.Value as ReplacePricePricePercent;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out ReplacePricePriceEventOutput? value)
    {
        value = this.Value as ReplacePricePriceEventOutput;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePrice"
            );
        }
    }
}

sealed class ReplacePricePriceConverter : JsonConverter<ReplacePricePrice?>
{
    public override ReplacePricePrice? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? modelType;
        try
        {
            modelType = json.GetProperty("model_type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePriceBulkWithFilters>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "threshold_total_amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_with_minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredWithMinimumPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_package_with_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "package_with_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "unit_with_percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix_with_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixWithAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered_with_proration":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceTieredWithProration>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "unit_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_allocation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bulk_with_proration":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_prorated_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_metered_minimum":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_with_min_max_thresholds":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholds>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "matrix_with_display_name":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "grouped_tiered_package":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "max_group_tiered_package":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "cumulative_grouped_bulk":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<NewPlanCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "cumulative_grouped_allocation":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "minimum":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "percent":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePricePercent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "event_output":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ReplacePricePriceEventOutput>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ReplacePricePrice(json);
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

[JsonConverter(typeof(ModelConverter<ReplacePricePriceBulkWithFilters>))]
public sealed record class ReplacePricePriceBulkWithFilters
    : ModelBase,
        IFromRaw<ReplacePricePriceBulkWithFilters>
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            if (!this._properties.TryGetValue("bulk_with_filters_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "bulk_with_filters_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'bulk_with_filters_config' cannot be null",
                    new System::ArgumentNullException("bulk_with_filters_config")
                );
        }
        init
        {
            this._properties["bulk_with_filters_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePricePriceBulkWithFiltersCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePricePriceBulkWithFiltersModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePricePriceBulkWithFiltersConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public ReplacePricePriceBulkWithFilters(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFilters(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>))]
public sealed record class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig
    : ModelBase,
        IFromRaw<ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required List<global::Orb.Models.Beta.FilterModel> Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Beta.FilterModel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        init
        {
            this._properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required List<global::Orb.Models.Beta.Tier1> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Beta.Tier1>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.FilterModel>))]
public sealed record class FilterModel : ModelBase, IFromRaw<global::Orb.Models.Beta.FilterModel>
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get
        {
            if (!this._properties.TryGetValue("property_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_key' cannot be null",
                    new System::ArgumentNullException("property_key")
                );
        }
        init
        {
            this._properties["property_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get
        {
            if (!this._properties.TryGetValue("property_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "property_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'property_value' cannot be null",
                    new System::ArgumentNullException("property_value")
                );
        }
        init
        {
            this._properties["property_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public FilterModel() { }

    public FilterModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.FilterModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.Tier1>))]
public sealed record class Tier1 : ModelBase, IFromRaw<global::Orb.Models.Beta.Tier1>
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get
        {
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier1() { }

    public Tier1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.Tier1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Tier1(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
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

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePricePriceBulkWithFiltersModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePricePriceBulkWithFiltersModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ReplacePricePriceBulkWithFiltersModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new ReplacePricePriceBulkWithFiltersModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceBulkWithFiltersModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePricePriceBulkWithFiltersModelType>
    {
        public override ReplacePricePriceBulkWithFiltersModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePricePriceBulkWithFiltersModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ReplacePricePriceBulkWithFiltersConversionRateConfigConverter))]
public record class ReplacePricePriceBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceBulkWithFiltersConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceBulkWithFiltersConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ReplacePricePriceBulkWithFiltersConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<ReplacePricePriceTieredWithProration>))]
public sealed record class ReplacePricePriceTieredWithProration
    : ModelBase,
        IFromRaw<ReplacePricePriceTieredWithProration>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceTieredWithProrationCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePricePriceTieredWithProrationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePricePriceTieredWithProrationModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required ReplacePricePriceTieredWithProrationTieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "tiered_with_proration_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tiered_with_proration_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiered_with_proration_config' cannot be null",
                    new System::ArgumentNullException("tiered_with_proration_config")
                );
        }
        init
        {
            this._properties["tiered_with_proration_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceTieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePricePriceTieredWithProrationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public ReplacePricePriceTieredWithProration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePricePriceTieredWithProrationModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePricePriceTieredWithProrationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    ReplacePricePriceTieredWithProrationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new ReplacePricePriceTieredWithProrationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceTieredWithProrationModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePricePriceTieredWithProrationModelType>
    {
        public override ReplacePricePriceTieredWithProrationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePricePriceTieredWithProrationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for tiered_with_proration pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>)
)]
public sealed record class ReplacePricePriceTieredWithProrationTieredWithProrationConfig
    : ModelBase,
        IFromRaw<ReplacePricePriceTieredWithProrationTieredWithProrationConfig>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required List<global::Orb.Models.Beta.Tier2> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Beta.Tier2>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentNullException("tiers")
                );
        }
        init
        {
            this._properties["tiers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig() { }

    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        List<global::Orb.Models.Beta.Tier2> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.Tier2>))]
public sealed record class Tier2 : ModelBase, IFromRaw<global::Orb.Models.Beta.Tier2>
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get
        {
            if (!this._properties.TryGetValue("tier_lower_bound", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tier_lower_bound",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tier_lower_bound' cannot be null",
                    new System::ArgumentNullException("tier_lower_bound")
                );
        }
        init
        {
            this._properties["tier_lower_bound"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public Tier2() { }

    public Tier2(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier2(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.Tier2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ReplacePricePriceTieredWithProrationConversionRateConfigConverter))]
public record class ReplacePricePriceTieredWithProrationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceTieredWithProrationConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceTieredWithProrationConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ReplacePricePriceTieredWithProrationConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<ReplacePricePriceGroupedWithMinMaxThresholds>))]
public sealed record class ReplacePricePriceGroupedWithMinMaxThresholds
    : ModelBase,
        IFromRaw<ReplacePricePriceGroupedWithMinMaxThresholds>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "grouped_with_min_max_thresholds_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouped_with_min_max_thresholds_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouped_with_min_max_thresholds_config' cannot be null",
                    new System::ArgumentNullException("grouped_with_min_max_thresholds_config")
                );
        }
        init
        {
            this._properties["grouped_with_min_max_thresholds_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePricePriceGroupedWithMinMaxThresholdsModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholdsModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public ReplacePricePriceGroupedWithMinMaxThresholds(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceGroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
    typeof(ModelConverter<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>)
)]
public sealed record class ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : ModelBase,
        IFromRaw<ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get
        {
            if (!this._properties.TryGetValue("maximum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "maximum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_charge' cannot be null",
                    new System::ArgumentNullException("maximum_charge")
                );
        }
        init
        {
            this._properties["maximum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get
        {
            if (!this._properties.TryGetValue("minimum_charge", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_charge",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'minimum_charge' cannot be null",
                    new System::ArgumentNullException("minimum_charge")
                );
        }
        init
        {
            this._properties["minimum_charge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get
        {
            if (!this._properties.TryGetValue("per_unit_rate", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "per_unit_rate",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'per_unit_rate' cannot be null",
                    new System::ArgumentNullException("per_unit_rate")
                );
        }
        init
        {
            this._properties["per_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig() { }

    public ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePricePriceGroupedWithMinMaxThresholdsModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePricePriceGroupedWithMinMaxThresholdsModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    ReplacePricePriceGroupedWithMinMaxThresholdsModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new ReplacePricePriceGroupedWithMinMaxThresholdsModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceGroupedWithMinMaxThresholdsModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePricePriceGroupedWithMinMaxThresholdsModelType>
    {
        public override ReplacePricePriceGroupedWithMinMaxThresholdsModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePricePriceGroupedWithMinMaxThresholdsModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter))]
public record class ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<ReplacePricePriceCumulativeGroupedAllocation>))]
public sealed record class ReplacePricePriceCumulativeGroupedAllocation
    : ModelBase,
        IFromRaw<ReplacePricePriceCumulativeGroupedAllocation>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, ReplacePricePriceCumulativeGroupedAllocationCadence>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "cumulative_grouped_allocation_config",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_grouped_allocation_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'cumulative_grouped_allocation_config' cannot be null",
                    new System::ArgumentNullException("cumulative_grouped_allocation_config")
                );
        }
        init
        {
            this._properties["cumulative_grouped_allocation_config"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePricePriceCumulativeGroupedAllocationModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocationModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public ReplacePricePriceCumulativeGroupedAllocation(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceCumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
    typeof(ModelConverter<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>)
)]
public sealed record class ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : ModelBase,
        IFromRaw<ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get
        {
            if (!this._properties.TryGetValue("cumulative_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "cumulative_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'cumulative_allocation' cannot be null",
                    new System::ArgumentNullException("cumulative_allocation")
                );
        }
        init
        {
            this._properties["cumulative_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get
        {
            if (!this._properties.TryGetValue("group_allocation", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "group_allocation",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'group_allocation' cannot be null",
                    new System::ArgumentNullException("group_allocation")
                );
        }
        init
        {
            this._properties["group_allocation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'grouping_key' cannot be null",
                    new System::ArgumentNullException("grouping_key")
                );
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this._properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        init
        {
            this._properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig() { }

    public ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePricePriceCumulativeGroupedAllocationModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePricePriceCumulativeGroupedAllocationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"");
    }

    ReplacePricePriceCumulativeGroupedAllocationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new ReplacePricePriceCumulativeGroupedAllocationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceCumulativeGroupedAllocationModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePricePriceCumulativeGroupedAllocationModelType>
    {
        public override ReplacePricePriceCumulativeGroupedAllocationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePricePriceCumulativeGroupedAllocationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter))]
public record class ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<ReplacePricePricePercent>))]
public sealed record class ReplacePricePricePercent : ModelBase, IFromRaw<ReplacePricePricePercent>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePricePercentCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ReplacePricePricePercentCadence>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePricePricePercentModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePricePercentModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required ReplacePricePricePercentPercentConfig PercentConfig
    {
        get
        {
            if (!this._properties.TryGetValue("percent_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percent_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePricePercentPercentConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'percent_config' cannot be null",
                    new System::ArgumentNullException("percent_config")
                );
        }
        init
        {
            this._properties["percent_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePricePricePercentConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public ReplacePricePricePercent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePricePercent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePricePricePercentModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePricePricePercentModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    ReplacePricePricePercentModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new ReplacePricePricePercentModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePricePercentModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePricePricePercentModelType>
    {
        public override ReplacePricePricePercentModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePricePricePercentModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Configuration for percent pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<ReplacePricePricePercentPercentConfig>))]
public sealed record class ReplacePricePricePercentPercentConfig
    : ModelBase,
        IFromRaw<ReplacePricePricePercentPercentConfig>
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get
        {
            if (!this._properties.TryGetValue("percent", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percent' cannot be null",
                    new System::ArgumentOutOfRangeException("percent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["percent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public ReplacePricePricePercentPercentConfig() { }

    public ReplacePricePricePercentPercentConfig(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePricePercentPercentConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ReplacePricePricePercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

[JsonConverter(typeof(ReplacePricePricePercentConversionRateConfigConverter))]
public record class ReplacePricePricePercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePricePercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePricePercentConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePricePercentConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ReplacePricePricePercentConversionRateConfig(json);
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

[JsonConverter(typeof(ModelConverter<ReplacePricePriceEventOutput>))]
public sealed record class ReplacePricePriceEventOutput
    : ModelBase,
        IFromRaw<ReplacePricePriceEventOutput>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, ReplacePricePriceEventOutputCadence> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ReplacePricePriceEventOutputCadence>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required ReplacePricePriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            if (!this._properties.TryGetValue("event_output_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "event_output_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceEventOutputEventOutputConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'event_output_config' cannot be null",
                    new System::ArgumentNullException("event_output_config")
                );
        }
        init
        {
            this._properties["event_output_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public ReplacePricePriceEventOutputModelType ModelType
    {
        get
        {
            if (!this._properties.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ReplacePricePriceEventOutputModelType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentNullException("model_type")
                );
        }
        init
        {
            this._properties["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get
        {
            if (!this._properties.TryGetValue("billable_metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billable_metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get
        {
            if (!this._properties.TryGetValue("billed_in_advance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billed_in_advance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "billing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["billing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["conversion_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public ReplacePricePriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReplacePricePriceEventOutputConversionRateConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["conversion_rate_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "dimensional_price_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewDimensionalPriceConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["dimensional_price_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get
        {
            if (!this._properties.TryGetValue("fixed_price_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fixed_price_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "invoicing_cycle_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewBillingCycleConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoicing_cycle_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("reference_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["reference_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Cadence.Validate();
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
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
        this.ModelType = new();
    }

    public ReplacePricePriceEventOutput(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceEventOutput(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
[JsonConverter(typeof(ModelConverter<ReplacePricePriceEventOutputEventOutputConfig>))]
public sealed record class ReplacePricePriceEventOutputEventOutputConfig
    : ModelBase,
        IFromRaw<ReplacePricePriceEventOutputEventOutputConfig>
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get
        {
            if (!this._properties.TryGetValue("unit_rating_key", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_rating_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_rating_key' cannot be null",
                    new System::ArgumentNullException("unit_rating_key")
                );
        }
        init
        {
            this._properties["unit_rating_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._properties.TryGetValue("default_unit_rate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["default_unit_rate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["grouping_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public ReplacePricePriceEventOutputEventOutputConfig() { }

    public ReplacePricePriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceEventOutputEventOutputConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceEventOutputEventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ReplacePricePriceEventOutputModelType
{
    public JsonElement Json { get; private init; }

    public ReplacePricePriceEventOutputModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    ReplacePricePriceEventOutputModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new ReplacePricePriceEventOutputModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceEventOutputModelType'"
            );
        }
    }

    class Converter : JsonConverter<ReplacePricePriceEventOutputModelType>
    {
        public override ReplacePricePriceEventOutputModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReplacePricePriceEventOutputModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ReplacePricePriceEventOutputConversionRateConfigConverter))]
public record class ReplacePricePriceEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ReplacePricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePriceEventOutputConversionRateConfig(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickUnit([NotNullWhen(true)] out SharedUnitConversionRateConfig? value)
    {
        value = this.Value as SharedUnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out SharedTieredConversionRateConfig? value)
    {
        value = this.Value as SharedTieredConversionRateConfig;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePriceEventOutputConversionRateConfig"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? conversionRateType;
        try
        {
            conversionRateType = json.GetProperty("conversion_rate_type").GetString();
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
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tiered":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SharedTieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ReplacePricePriceEventOutputConversionRateConfig(json);
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
