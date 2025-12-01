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

namespace Orb.Models.Beta.ExternalPlanID;

/// <summary>
/// This endpoint allows the creation of a new plan version for an existing plan.
/// </summary>
public sealed record class ExternalPlanIDCreatePlanVersionParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ExternalPlanID { get; init; }

    /// <summary>
    /// New version number.
    /// </summary>
    public required long Version
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawBodyData, "version"); }
        init { ModelBase.Set(this._rawBodyData, "version", value); }
    }

    /// <summary>
    /// Additional adjustments to be added to the plan.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.AddAdjustment>? AddAdjustments
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<global::Orb.Models.Beta.ExternalPlanID.AddAdjustment>
            >(this.RawBodyData, "add_adjustments");
        }
        init { ModelBase.Set(this._rawBodyData, "add_adjustments", value); }
    }

    /// <summary>
    /// Additional prices to be added to the plan.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.AddPrice>? AddPrices
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<global::Orb.Models.Beta.ExternalPlanID.AddPrice>
            >(this.RawBodyData, "add_prices");
        }
        init { ModelBase.Set(this._rawBodyData, "add_prices", value); }
    }

    /// <summary>
    /// Adjustments to be removed from the plan.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.RemoveAdjustment>? RemoveAdjustments
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<global::Orb.Models.Beta.ExternalPlanID.RemoveAdjustment>
            >(this.RawBodyData, "remove_adjustments");
        }
        init { ModelBase.Set(this._rawBodyData, "remove_adjustments", value); }
    }

    /// <summary>
    /// Prices to be removed from the plan.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.RemovePrice>? RemovePrices
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<global::Orb.Models.Beta.ExternalPlanID.RemovePrice>
            >(this.RawBodyData, "remove_prices");
        }
        init { ModelBase.Set(this._rawBodyData, "remove_prices", value); }
    }

    /// <summary>
    /// Adjustments to be replaced with additional adjustments on the plan.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustment>? ReplaceAdjustments
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustment>
            >(this.RawBodyData, "replace_adjustments");
        }
        init { ModelBase.Set(this._rawBodyData, "replace_adjustments", value); }
    }

    /// <summary>
    /// Prices to be replaced with additional prices on the plan.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.ReplacePrice>? ReplacePrices
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<global::Orb.Models.Beta.ExternalPlanID.ReplacePrice>
            >(this.RawBodyData, "replace_prices");
        }
        init { ModelBase.Set(this._rawBodyData, "replace_prices", value); }
    }

    /// <summary>
    /// Set this new plan version as the default
    /// </summary>
    public bool? SetAsDefault
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "set_as_default"); }
        init { ModelBase.Set(this._rawBodyData, "set_as_default", value); }
    }

    public ExternalPlanIDCreatePlanVersionParams() { }

    public ExternalPlanIDCreatePlanVersionParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalPlanIDCreatePlanVersionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static ExternalPlanIDCreatePlanVersionParams FromRawUnchecked(
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
                + string.Format("/plans/external_plan_id/{0}/versions", this.ExternalPlanID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.AddAdjustment,
        global::Orb.Models.Beta.ExternalPlanID.AddAdjustmentFromRaw
    >)
)]
public sealed record class AddAdjustment : ModelBase
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.Adjustment Adjustment
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.Adjustment>(
                this.RawData,
                "adjustment"
            );
        }
        init { ModelBase.Set(this._rawData, "adjustment", value); }
    }

    /// <summary>
    /// The phase to add this adjustment to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { ModelBase.Set(this._rawData, "plan_phase_order", value); }
    }

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.PlanPhaseOrder;
    }

    public AddAdjustment() { }

    public AddAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.AddAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddAdjustment(global::Orb.Models.Beta.ExternalPlanID.Adjustment adjustment)
        : this()
    {
        this.Adjustment = adjustment;
    }
}

class AddAdjustmentFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.AddAdjustment>
{
    public global::Orb.Models.Beta.ExternalPlanID.AddAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.AddAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.AdjustmentConverter))]
public record class Adjustment
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

    public Adjustment(NewPercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Adjustment(NewUsageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Adjustment(NewAmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Adjustment(NewMinimum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Adjustment(NewMaximum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Adjustment(JsonElement json)
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
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment"),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Adjustment(
        NewPercentageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Adjustment(
        NewUsageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Adjustment(
        NewAmountDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Adjustment(
        NewMinimum value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Adjustment(
        NewMaximum value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    public virtual bool Equals(global::Orb.Models.Beta.ExternalPlanID.Adjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class AdjustmentConverter : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.Adjustment>
{
    public override global::Orb.Models.Beta.ExternalPlanID.Adjustment? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.Adjustment(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.Adjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.AddPrice,
        global::Orb.Models.Beta.ExternalPlanID.AddPriceFromRaw
    >)
)]
public sealed record class AddPrice : ModelBase
{
    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            return ModelBase.GetNullableClass<NewAllocationPrice>(this.RawData, "allocation_price");
        }
        init { ModelBase.Set(this._rawData, "allocation_price", value); }
    }

    /// <summary>
    /// The phase to add this price to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { ModelBase.Set(this._rawData, "plan_phase_order", value); }
    }

    /// <summary>
    /// New plan price request body params.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.Price? Price
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.Price>(
                this.RawData,
                "price"
            );
        }
        init { ModelBase.Set(this._rawData, "price", value); }
    }

    public override void Validate()
    {
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public AddPrice() { }

    public AddPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.AddPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddPriceFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.AddPrice>
{
    public global::Orb.Models.Beta.ExternalPlanID.AddPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.AddPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// New plan price request body params.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.PriceConverter))]
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

    public Price(
        global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters value,
        JsonElement? json = null
    )
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

    public Price(
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProration value,
        JsonElement? json = null
    )
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
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds value,
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
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation value,
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

    public Price(global::Orb.Models.Beta.ExternalPlanID.Percent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Price(global::Orb.Models.Beta.ExternalPlanID.EventOutput value, JsonElement? json = null)
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
        [NotNullWhen(true)] out global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters;
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
        [NotNullWhen(true)] out global::Orb.Models.Beta.ExternalPlanID.TieredWithProration? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.ExternalPlanID.TieredWithProration;
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
        [NotNullWhen(true)]
            out global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds;
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
        [NotNullWhen(true)]
            out global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation;
        return value != null;
    }

    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = this.Value as NewPlanMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent(
        [NotNullWhen(true)] out global::Orb.Models.Beta.ExternalPlanID.Percent? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.ExternalPlanID.Percent;
        return value != null;
    }

    public bool TryPickEventOutput(
        [NotNullWhen(true)] out global::Orb.Models.Beta.ExternalPlanID.EventOutput? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.ExternalPlanID.EventOutput;
        return value != null;
    }

    public void Switch(
        System::Action<NewPlanUnitPrice> newPlanUnit,
        System::Action<NewPlanTieredPrice> newPlanTiered,
        System::Action<NewPlanBulkPrice> newPlanBulk,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters> bulkWithFilters,
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
        System::Action<global::Orb.Models.Beta.ExternalPlanID.TieredWithProration> tieredWithProration,
        System::Action<NewPlanUnitWithProrationPrice> newPlanUnitWithProration,
        System::Action<NewPlanGroupedAllocationPrice> newPlanGroupedAllocation,
        System::Action<NewPlanBulkWithProrationPrice> newPlanBulkWithProration,
        System::Action<NewPlanGroupedWithProratedMinimumPrice> newPlanGroupedWithProratedMinimum,
        System::Action<NewPlanGroupedWithMeteredMinimumPrice> newPlanGroupedWithMeteredMinimum,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewPlanMatrixWithDisplayNamePrice> newPlanMatrixWithDisplayName,
        System::Action<NewPlanGroupedTieredPackagePrice> newPlanGroupedTieredPackage,
        System::Action<NewPlanMaxGroupTieredPackagePrice> newPlanMaxGroupTieredPackage,
        System::Action<NewPlanScalableMatrixWithUnitPricingPrice> newPlanScalableMatrixWithUnitPricing,
        System::Action<NewPlanScalableMatrixWithTieredPricingPrice> newPlanScalableMatrixWithTieredPricing,
        System::Action<NewPlanCumulativeGroupedBulkPrice> newPlanCumulativeGroupedBulk,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewPlanMinimumCompositePrice> newPlanMinimumComposite,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.Percent> percent,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.EventOutput> eventOutput
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
            case global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters value:
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
            case global::Orb.Models.Beta.ExternalPlanID.TieredWithProration value:
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
            case global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds value:
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
            case global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewPlanMinimumCompositePrice value:
                newPlanMinimumComposite(value);
                break;
            case global::Orb.Models.Beta.ExternalPlanID.Percent value:
                percent(value);
                break;
            case global::Orb.Models.Beta.ExternalPlanID.EventOutput value:
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
        System::Func<global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters, T> bulkWithFilters,
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
        System::Func<
            global::Orb.Models.Beta.ExternalPlanID.TieredWithProration,
            T
        > tieredWithProration,
        System::Func<NewPlanUnitWithProrationPrice, T> newPlanUnitWithProration,
        System::Func<NewPlanGroupedAllocationPrice, T> newPlanGroupedAllocation,
        System::Func<NewPlanBulkWithProrationPrice, T> newPlanBulkWithProration,
        System::Func<NewPlanGroupedWithProratedMinimumPrice, T> newPlanGroupedWithProratedMinimum,
        System::Func<NewPlanGroupedWithMeteredMinimumPrice, T> newPlanGroupedWithMeteredMinimum,
        System::Func<
            global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds,
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
            global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewPlanMinimumCompositePrice, T> newPlanMinimumComposite,
        System::Func<global::Orb.Models.Beta.ExternalPlanID.Percent, T> percent,
        System::Func<global::Orb.Models.Beta.ExternalPlanID.EventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewPlanUnitPrice value => newPlanUnit(value),
            NewPlanTieredPrice value => newPlanTiered(value),
            NewPlanBulkPrice value => newPlanBulk(value),
            global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters value => bulkWithFilters(value),
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
            global::Orb.Models.Beta.ExternalPlanID.TieredWithProration value => tieredWithProration(
                value
            ),
            NewPlanUnitWithProrationPrice value => newPlanUnitWithProration(value),
            NewPlanGroupedAllocationPrice value => newPlanGroupedAllocation(value),
            NewPlanBulkWithProrationPrice value => newPlanBulkWithProration(value),
            NewPlanGroupedWithProratedMinimumPrice value => newPlanGroupedWithProratedMinimum(
                value
            ),
            NewPlanGroupedWithMeteredMinimumPrice value => newPlanGroupedWithMeteredMinimum(value),
            global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds value =>
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
            global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation value =>
                cumulativeGroupedAllocation(value),
            NewPlanMinimumCompositePrice value => newPlanMinimumComposite(value),
            global::Orb.Models.Beta.ExternalPlanID.Percent value => percent(value),
            global::Orb.Models.Beta.ExternalPlanID.EventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price"),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanUnitPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanTieredPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanBulkPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanMatrixPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanGroupedTieredPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanUnitWithPercentPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProration value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        NewPlanMinimumCompositePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        global::Orb.Models.Beta.ExternalPlanID.Percent value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.Price(
        global::Orb.Models.Beta.ExternalPlanID.EventOutput value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    public virtual bool Equals(global::Orb.Models.Beta.ExternalPlanID.Price? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceConverter : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.Price?>
{
    public override global::Orb.Models.Beta.ExternalPlanID.Price? Read(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.TieredWithProration>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.Percent>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.EventOutput>(
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
                return new global::Orb.Models.Beta.ExternalPlanID.Price(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.Price? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters,
        global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersFromRaw
    >)
)]
public sealed record class BulkWithFilters : ModelBase
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersConfig>(
                this.RawData,
                "bulk_with_filters_config"
            );
        }
        init { ModelBase.Set(this._rawData, "bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.ExternalPlanID.Cadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.ExternalPlanID.Cadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public BulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkWithFiltersFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters>
{
    public global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.BulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersConfig,
        global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class BulkWithFiltersConfig : ModelBase
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.Filter> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Beta.ExternalPlanID.Filter>>(
                this.RawData,
                "filters"
            );
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.Tier> Tiers
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Beta.ExternalPlanID.Tier>>(
                this.RawData,
                "tiers"
            );
        }
        init { ModelBase.Set(this._rawData, "tiers", value); }
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

    public BulkWithFiltersConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkWithFiltersConfigFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.BulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.Filter,
        global::Orb.Models.Beta.ExternalPlanID.FilterFromRaw
    >)
)]
public sealed record class Filter : ModelBase
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "property_key"); }
        init { ModelBase.Set(this._rawData, "property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "property_value"); }
        init { ModelBase.Set(this._rawData, "property_value", value); }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public Filter() { }

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.Filter>
{
    public global::Orb.Models.Beta.ExternalPlanID.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.Tier,
        global::Orb.Models.Beta.ExternalPlanID.TierFromRaw
    >)
)]
public sealed record class Tier : ModelBase
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tier_lower_bound"); }
        init { ModelBase.Set(this._rawData, "tier_lower_bound", value); }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier() { }

    public Tier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.Tier FromRawUnchecked(
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

class TierFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.Tier>
{
    public global::Orb.Models.Beta.ExternalPlanID.Tier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.Tier.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.CadenceConverter))]
public enum Cadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CadenceConverter : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.Cadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.Cadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.ExternalPlanID.Cadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.ExternalPlanID.Cadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.ExternalPlanID.Cadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.ExternalPlanID.Cadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.ExternalPlanID.Cadence.OneTime,
            "custom" => global::Orb.Models.Beta.ExternalPlanID.Cadence.Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.Cadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.Cadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.ExternalPlanID.Cadence.Annual => "annual",
                global::Orb.Models.Beta.ExternalPlanID.Cadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.ExternalPlanID.Cadence.Monthly => "monthly",
                global::Orb.Models.Beta.ExternalPlanID.Cadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.ExternalPlanID.Cadence.OneTime => "one_time",
                global::Orb.Models.Beta.ExternalPlanID.Cadence.Custom => "custom",
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
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.ExternalPlanID.ModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'ModelType'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.ModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.ModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfigConverter))]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig(
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

    public virtual bool Equals(global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProration,
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationFromRaw
    >)
)]
public sealed record class TieredWithProration : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConfig>(
                this.RawData,
                "tiered_with_proration_config"
            );
        }
        init { ModelBase.Set(this._rawData, "tiered_with_proration_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public TieredWithProration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.TieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TieredWithProrationFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.TieredWithProration>
{
    public global::Orb.Models.Beta.ExternalPlanID.TieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.TieredWithProration.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadenceConverter))]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .TieredWithProrationCadence
                .SemiAnnual,
            "monthly" => global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .TieredWithProrationCadence
                .Quarterly,
            "one_time" => global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.OneTime,
            "custom" => global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.Annual =>
                    "annual",
                global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.SemiAnnual =>
                    "semi_annual",
                global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.Monthly =>
                    "monthly",
                global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.Quarterly =>
                    "quarterly",
                global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.OneTime =>
                    "one_time",
                global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationCadence.Custom =>
                    "custom",
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
                new global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'TieredWithProrationModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationModelType value,
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
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConfig,
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConfigFromRaw
    >)
)]
public sealed record class TieredWithProrationConfig : ModelBase
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.TierModel> Tiers
    {
        get
        {
            return ModelBase.GetNotNullClass<
                List<global::Orb.Models.Beta.ExternalPlanID.TierModel>
            >(this.RawData, "tiers");
        }
        init { ModelBase.Set(this._rawData, "tiers", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Tiers)
        {
            item.Validate();
        }
    }

    public TieredWithProrationConfig() { }

    public TieredWithProrationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TieredWithProrationConfig(List<global::Orb.Models.Beta.ExternalPlanID.TierModel> tiers)
        : this()
    {
        this.Tiers = tiers;
    }
}

class TieredWithProrationConfigFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.TierModel,
        global::Orb.Models.Beta.ExternalPlanID.TierModelFromRaw
    >)
)]
public sealed record class TierModel : ModelBase
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tier_lower_bound"); }
        init { ModelBase.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public TierModel() { }

    public TierModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TierModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.TierModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TierModelFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.TierModel>
{
    public global::Orb.Models.Beta.ExternalPlanID.TierModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.TierModel.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfigConverter)
)]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class TieredWithProrationConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.TieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds,
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class GroupedWithMinMaxThresholds : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence
                >
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConfig>(
                this.RawData,
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { ModelBase.Set(this._rawData, "grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public GroupedWithMinMaxThresholds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMinMaxThresholdsFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds>
{
    public global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholds.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadenceConverter)
)]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .GroupedWithMinMaxThresholdsCadence
                .Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .GroupedWithMinMaxThresholdsCadence
                .SemiAnnual,
            "monthly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .GroupedWithMinMaxThresholdsCadence
                .Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .GroupedWithMinMaxThresholdsCadence
                .Quarterly,
            "one_time" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .GroupedWithMinMaxThresholdsCadence
                .OneTime,
            "custom" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .GroupedWithMinMaxThresholdsCadence
                .Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence.Annual =>
                    "annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .GroupedWithMinMaxThresholdsCadence
                    .SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence.Monthly =>
                    "monthly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .GroupedWithMinMaxThresholdsCadence
                    .Quarterly => "quarterly",
                global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence.OneTime =>
                    "one_time",
                global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsCadence.Custom =>
                    "custom",
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
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConfig,
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class GroupedWithMinMaxThresholdsConfig : ModelBase
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "maximum_charge"); }
        init { ModelBase.Set(this._rawData, "maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "minimum_charge"); }
        init { ModelBase.Set(this._rawData, "minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "per_unit_rate"); }
        init { ModelBase.Set(this._rawData, "per_unit_rate", value); }
    }

    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public GroupedWithMinMaxThresholdsConfig() { }

    public GroupedWithMinMaxThresholdsConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
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
                new global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'GroupedWithMinMaxThresholdsModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfigConverter)
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class GroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.GroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation,
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class CumulativeGroupedAllocation : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence
                >
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConfig>(
                this.RawData,
                "cumulative_grouped_allocation_config"
            );
        }
        init { ModelBase.Set(this._rawData, "cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public CumulativeGroupedAllocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedAllocationFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation>
{
    public global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadenceConverter)
)]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .CumulativeGroupedAllocationCadence
                .Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .CumulativeGroupedAllocationCadence
                .SemiAnnual,
            "monthly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .CumulativeGroupedAllocationCadence
                .Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .CumulativeGroupedAllocationCadence
                .Quarterly,
            "one_time" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .CumulativeGroupedAllocationCadence
                .OneTime,
            "custom" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .CumulativeGroupedAllocationCadence
                .Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence.Annual =>
                    "annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .CumulativeGroupedAllocationCadence
                    .SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence.Monthly =>
                    "monthly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .CumulativeGroupedAllocationCadence
                    .Quarterly => "quarterly",
                global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence.OneTime =>
                    "one_time",
                global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationCadence.Custom =>
                    "custom",
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
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConfig,
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class CumulativeGroupedAllocationConfig : ModelBase
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "cumulative_allocation"); }
        init { ModelBase.Set(this._rawData, "cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "group_allocation"); }
        init { ModelBase.Set(this._rawData, "group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public CumulativeGroupedAllocationConfig() { }

    public CumulativeGroupedAllocationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CumulativeGroupedAllocationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CumulativeGroupedAllocationConfigFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
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
                new global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'CumulativeGroupedAllocationModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfigConverter)
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class CumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.CumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.Percent,
        global::Orb.Models.Beta.ExternalPlanID.PercentFromRaw
    >)
)]
public sealed record class Percent : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.ExternalPlanID.PercentCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.ExternalPlanID.PercentCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.PercentModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.PercentModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.PercentConfig PercentConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.PercentConfig>(
                this.RawData,
                "percent_config"
            );
        }
        init { ModelBase.Set(this._rawData, "percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public Percent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.Percent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PercentFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.Percent>
{
    public global::Orb.Models.Beta.ExternalPlanID.Percent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.Percent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.PercentCadenceConverter))]
public enum PercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PercentCadenceConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.PercentCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.PercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.ExternalPlanID.PercentCadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.ExternalPlanID.PercentCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.ExternalPlanID.PercentCadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.ExternalPlanID.PercentCadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.ExternalPlanID.PercentCadence.OneTime,
            "custom" => global::Orb.Models.Beta.ExternalPlanID.PercentCadence.Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.PercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.PercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.ExternalPlanID.PercentCadence.Annual => "annual",
                global::Orb.Models.Beta.ExternalPlanID.PercentCadence.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.ExternalPlanID.PercentCadence.Monthly => "monthly",
                global::Orb.Models.Beta.ExternalPlanID.PercentCadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.ExternalPlanID.PercentCadence.OneTime => "one_time",
                global::Orb.Models.Beta.ExternalPlanID.PercentCadence.Custom => "custom",
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
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.ExternalPlanID.PercentModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'PercentModelType'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.PercentModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.PercentModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.PercentModelType value,
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
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.PercentConfig,
        global::Orb.Models.Beta.ExternalPlanID.PercentConfigFromRaw
    >)
)]
public sealed record class PercentConfig : ModelBase
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percent"); }
        init { ModelBase.Set(this._rawData, "percent", value); }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public PercentConfig() { }

    public PercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.PercentConfig FromRawUnchecked(
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

class PercentConfigFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.PercentConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.PercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.PercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfigConverter))]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PercentConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.PercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.EventOutput,
        global::Orb.Models.Beta.ExternalPlanID.EventOutputFromRaw
    >)
)]
public sealed record class EventOutput : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.EventOutputConfig EventOutputConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.EventOutputConfig>(
                this.RawData,
                "event_output_config"
            );
        }
        init { ModelBase.Set(this._rawData, "event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.EventOutputModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.EventOutputModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public EventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.EventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventOutputFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.EventOutput>
{
    public global::Orb.Models.Beta.ExternalPlanID.EventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.EventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.EventOutputCadenceConverter))]
public enum EventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class EventOutputCadenceConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.Annual,
            "semi_annual" => global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.Monthly,
            "quarterly" => global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.Quarterly,
            "one_time" => global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.OneTime,
            "custom" => global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.Annual => "annual",
                global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.SemiAnnual =>
                    "semi_annual",
                global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.Monthly => "monthly",
                global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.Quarterly => "quarterly",
                global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.OneTime => "one_time",
                global::Orb.Models.Beta.ExternalPlanID.EventOutputCadence.Custom => "custom",
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
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.EventOutputConfig,
        global::Orb.Models.Beta.ExternalPlanID.EventOutputConfigFromRaw
    >)
)]
public sealed record class EventOutputConfig : ModelBase
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_rating_key"); }
        init { ModelBase.Set(this._rawData, "unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "default_unit_rate"); }
        init { ModelBase.Set(this._rawData, "default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public EventOutputConfig() { }

    public EventOutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.EventOutputConfig FromRawUnchecked(
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

class EventOutputConfigFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.EventOutputConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.EventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.EventOutputConfig.FromRawUnchecked(rawData);
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
                new global::Orb.Models.Beta.ExternalPlanID.EventOutputModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'EventOutputModelType'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.EventOutputModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.EventOutputModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.EventOutputModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfigConverter)
)]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class EventOutputConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.EventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.RemoveAdjustment,
        global::Orb.Models.Beta.ExternalPlanID.RemoveAdjustmentFromRaw
    >)
)]
public sealed record class RemoveAdjustment : ModelBase
{
    /// <summary>
    /// The id of the adjustment to remove from on the plan.
    /// </summary>
    public required string AdjustmentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "adjustment_id"); }
        init { ModelBase.Set(this._rawData, "adjustment_id", value); }
    }

    /// <summary>
    /// The phase to remove this adjustment from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { ModelBase.Set(this._rawData, "plan_phase_order", value); }
    }

    public override void Validate()
    {
        _ = this.AdjustmentID;
        _ = this.PlanPhaseOrder;
    }

    public RemoveAdjustment() { }

    public RemoveAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.RemoveAdjustment FromRawUnchecked(
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

class RemoveAdjustmentFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.RemoveAdjustment>
{
    public global::Orb.Models.Beta.ExternalPlanID.RemoveAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.RemoveAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.RemovePrice,
        global::Orb.Models.Beta.ExternalPlanID.RemovePriceFromRaw
    >)
)]
public sealed record class RemovePrice : ModelBase
{
    /// <summary>
    /// The id of the price to remove from the plan.
    /// </summary>
    public required string PriceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "price_id"); }
        init { ModelBase.Set(this._rawData, "price_id", value); }
    }

    /// <summary>
    /// The phase to remove this price from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { ModelBase.Set(this._rawData, "plan_phase_order", value); }
    }

    public override void Validate()
    {
        _ = this.PriceID;
        _ = this.PlanPhaseOrder;
    }

    public RemovePrice() { }

    public RemovePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemovePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.RemovePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
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

class RemovePriceFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.RemovePrice>
{
    public global::Orb.Models.Beta.ExternalPlanID.RemovePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.RemovePrice.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustment,
        global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentFromRaw
    >)
)]
public sealed record class ReplaceAdjustment : ModelBase
{
    /// <summary>
    /// The definition of a new adjustment to create and add to the plan.
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment Adjustment
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment>(
                this.RawData,
                "adjustment"
            );
        }
        init { ModelBase.Set(this._rawData, "adjustment", value); }
    }

    /// <summary>
    /// The id of the adjustment on the plan to replace in the plan.
    /// </summary>
    public required string ReplacesAdjustmentID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "replaces_adjustment_id"); }
        init { ModelBase.Set(this._rawData, "replaces_adjustment_id", value); }
    }

    /// <summary>
    /// The phase to replace this adjustment from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { ModelBase.Set(this._rawData, "plan_phase_order", value); }
    }

    public override void Validate()
    {
        this.Adjustment.Validate();
        _ = this.ReplacesAdjustmentID;
        _ = this.PlanPhaseOrder;
    }

    public ReplaceAdjustment() { }

    public ReplaceAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplaceAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplaceAdjustmentFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustment>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustmentConverter))]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment(
        NewPercentageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment(
        NewUsageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment(
        NewAmountDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment(
        NewMinimum value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment(
        NewMaximum value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplaceAdjustmentAdjustment"
            );
        }
    }

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ReplaceAdjustmentAdjustmentConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplaceAdjustmentAdjustment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePrice,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePriceFromRaw
    >)
)]
public sealed record class ReplacePrice : ModelBase
{
    /// <summary>
    /// The id of the price on the plan to replace in the plan.
    /// </summary>
    public required string ReplacesPriceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "replaces_price_id"); }
        init { ModelBase.Set(this._rawData, "replaces_price_id", value); }
    }

    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            return ModelBase.GetNullableClass<NewAllocationPrice>(this.RawData, "allocation_price");
        }
        init { ModelBase.Set(this._rawData, "allocation_price", value); }
    }

    /// <summary>
    /// The phase to replace this price from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "plan_phase_order"); }
        init { ModelBase.Set(this._rawData, "plan_phase_order", value); }
    }

    /// <summary>
    /// New plan price request body params.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice? Price
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice>(
                this.RawData,
                "price"
            );
        }
        init { ModelBase.Set(this._rawData, "price", value); }
    }

    public override void Validate()
    {
        _ = this.ReplacesPriceID;
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public ReplacePrice() { }

    public ReplacePrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
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

class ReplacePriceFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePrice>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.ReplacePrice.FromRawUnchecked(rawData);
}

/// <summary>
/// New plan price request body params.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceConverter))]
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

    public ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters value,
        JsonElement? json = null
    )
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

    public ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration value,
        JsonElement? json = null
    )
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
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds value,
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
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation value,
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

    public ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput value,
        JsonElement? json = null
    )
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
        [NotNullWhen(true)]
            out global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters? value
    )
    {
        value =
            this.Value as global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters;
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
        [NotNullWhen(true)]
            out global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration? value
    )
    {
        value =
            this.Value
            as global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration;
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
        [NotNullWhen(true)]
            out global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds? value
    )
    {
        value =
            this.Value
            as global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds;
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
        [NotNullWhen(true)]
            out global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation? value
    )
    {
        value =
            this.Value
            as global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation;
        return value != null;
    }

    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = this.Value as NewPlanMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent(
        [NotNullWhen(true)]
            out global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent;
        return value != null;
    }

    public bool TryPickEventOutput(
        [NotNullWhen(true)]
            out global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput? value
    )
    {
        value = this.Value as global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput;
        return value != null;
    }

    public void Switch(
        System::Action<NewPlanUnitPrice> newPlanUnit,
        System::Action<NewPlanTieredPrice> newPlanTiered,
        System::Action<NewPlanBulkPrice> newPlanBulk,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters> bulkWithFilters,
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
        System::Action<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration> tieredWithProration,
        System::Action<NewPlanUnitWithProrationPrice> newPlanUnitWithProration,
        System::Action<NewPlanGroupedAllocationPrice> newPlanGroupedAllocation,
        System::Action<NewPlanBulkWithProrationPrice> newPlanBulkWithProration,
        System::Action<NewPlanGroupedWithProratedMinimumPrice> newPlanGroupedWithProratedMinimum,
        System::Action<NewPlanGroupedWithMeteredMinimumPrice> newPlanGroupedWithMeteredMinimum,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewPlanMatrixWithDisplayNamePrice> newPlanMatrixWithDisplayName,
        System::Action<NewPlanGroupedTieredPackagePrice> newPlanGroupedTieredPackage,
        System::Action<NewPlanMaxGroupTieredPackagePrice> newPlanMaxGroupTieredPackage,
        System::Action<NewPlanScalableMatrixWithUnitPricingPrice> newPlanScalableMatrixWithUnitPricing,
        System::Action<NewPlanScalableMatrixWithTieredPricingPrice> newPlanScalableMatrixWithTieredPricing,
        System::Action<NewPlanCumulativeGroupedBulkPrice> newPlanCumulativeGroupedBulk,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewPlanMinimumCompositePrice> newPlanMinimumComposite,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent> percent,
        System::Action<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput> eventOutput
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
            case global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters value:
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
            case global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration value:
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
            case global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds value:
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
            case global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewPlanMinimumCompositePrice value:
                newPlanMinimumComposite(value);
                break;
            case global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent value:
                percent(value);
                break;
            case global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput value:
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
        System::Func<
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters,
            T
        > bulkWithFilters,
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
        System::Func<
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration,
            T
        > tieredWithProration,
        System::Func<NewPlanUnitWithProrationPrice, T> newPlanUnitWithProration,
        System::Func<NewPlanGroupedAllocationPrice, T> newPlanGroupedAllocation,
        System::Func<NewPlanBulkWithProrationPrice, T> newPlanBulkWithProration,
        System::Func<NewPlanGroupedWithProratedMinimumPrice, T> newPlanGroupedWithProratedMinimum,
        System::Func<NewPlanGroupedWithMeteredMinimumPrice, T> newPlanGroupedWithMeteredMinimum,
        System::Func<
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds,
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
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation,
            T
        > cumulativeGroupedAllocation,
        System::Func<NewPlanMinimumCompositePrice, T> newPlanMinimumComposite,
        System::Func<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent, T> percent,
        System::Func<
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput,
            T
        > eventOutput
    )
    {
        return this.Value switch
        {
            NewPlanUnitPrice value => newPlanUnit(value),
            NewPlanTieredPrice value => newPlanTiered(value),
            NewPlanBulkPrice value => newPlanBulk(value),
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters value =>
                bulkWithFilters(value),
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
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration value =>
                tieredWithProration(value),
            NewPlanUnitWithProrationPrice value => newPlanUnitWithProration(value),
            NewPlanGroupedAllocationPrice value => newPlanGroupedAllocation(value),
            NewPlanBulkWithProrationPrice value => newPlanBulkWithProration(value),
            NewPlanGroupedWithProratedMinimumPrice value => newPlanGroupedWithProratedMinimum(
                value
            ),
            NewPlanGroupedWithMeteredMinimumPrice value => newPlanGroupedWithMeteredMinimum(value),
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds value =>
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
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation value =>
                cumulativeGroupedAllocation(value),
            NewPlanMinimumCompositePrice value => newPlanMinimumComposite(value),
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent value => percent(value),
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput value =>
                eventOutput(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePrice"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanUnitPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanTieredPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanBulkPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanMatrixPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanThresholdTotalAmountPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanTieredWithMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanGroupedTieredPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanTieredPackageWithMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanPackageWithAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanUnitWithPercentPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanMatrixWithAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanUnitWithProrationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanGroupedAllocationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanBulkWithProrationPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanGroupedWithProratedMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanGroupedWithMeteredMinimumPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanMatrixWithDisplayNamePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanGroupedTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanMaxGroupTieredPackagePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanCumulativeGroupedBulkPrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        NewPlanMinimumCompositePrice value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ReplacePricePrice"
            );
        }
    }

    public virtual bool Equals(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ReplacePricePriceConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice?>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice? Read(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent>(
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
                        JsonSerializer.Deserialize<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput>(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePrice? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFilters : ModelBase
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>(
                this.RawData,
                "bulk_with_filters_config"
            );
        }
        init { ModelBase.Set(this._rawData, "bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersCadence
                >
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public ReplacePricePriceBulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceBulkWithFiltersFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFilters.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig : ModelBase
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.FilterModel> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<
                List<global::Orb.Models.Beta.ExternalPlanID.FilterModel>
            >(this.RawData, "filters");
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.Tier1> Tiers
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Beta.ExternalPlanID.Tier1>>(
                this.RawData,
                "tiers"
            );
        }
        init { ModelBase.Set(this._rawData, "tiers", value); }
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.FilterModel,
        global::Orb.Models.Beta.ExternalPlanID.FilterModelFromRaw
    >)
)]
public sealed record class FilterModel : ModelBase
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "property_key"); }
        init { ModelBase.Set(this._rawData, "property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "property_value"); }
        init { ModelBase.Set(this._rawData, "property_value", value); }
    }

    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public FilterModel() { }

    public FilterModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.FilterModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterModelFromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.FilterModel>
{
    public global::Orb.Models.Beta.ExternalPlanID.FilterModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.FilterModel.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.Tier1,
        global::Orb.Models.Beta.ExternalPlanID.Tier1FromRaw
    >)
)]
public sealed record class Tier1 : ModelBase
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tier_lower_bound"); }
        init { ModelBase.Set(this._rawData, "tier_lower_bound", value); }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public Tier1() { }

    public Tier1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.Tier1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tier1(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class Tier1FromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.Tier1>
{
    public global::Orb.Models.Beta.ExternalPlanID.Tier1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.Tier1.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersCadenceConverter)
)]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceBulkWithFiltersCadence
                .Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceBulkWithFiltersCadence
                .SemiAnnual,
            "monthly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceBulkWithFiltersCadence
                .Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceBulkWithFiltersCadence
                .Quarterly,
            "one_time" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceBulkWithFiltersCadence
                .OneTime,
            "custom" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceBulkWithFiltersCadence
                .Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersCadence)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceBulkWithFiltersCadence
                    .Annual => "annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceBulkWithFiltersCadence
                    .SemiAnnual => "semi_annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceBulkWithFiltersCadence
                    .Monthly => "monthly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceBulkWithFiltersCadence
                    .Quarterly => "quarterly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceBulkWithFiltersCadence
                    .OneTime => "one_time",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceBulkWithFiltersCadence
                    .Custom => "custom",
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
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceBulkWithFiltersModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfigConverter)
)]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ReplacePricePriceBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationFromRaw
    >)
)]
public sealed record class ReplacePricePriceTieredWithProration : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationCadence
                >
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for tiered_with_proration pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationTieredWithProrationConfig TieredWithProrationConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationTieredWithProrationConfig>(
                this.RawData,
                "tiered_with_proration_config"
            );
        }
        init { ModelBase.Set(this._rawData, "tiered_with_proration_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public ReplacePricePriceTieredWithProration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceTieredWithProrationFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProration.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationCadenceConverter)
)]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceTieredWithProrationCadence
                .Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceTieredWithProrationCadence
                .SemiAnnual,
            "monthly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceTieredWithProrationCadence
                .Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceTieredWithProrationCadence
                .Quarterly,
            "one_time" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceTieredWithProrationCadence
                .OneTime,
            "custom" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceTieredWithProrationCadence
                .Custom,
            _ =>
                (global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceTieredWithProrationCadence
                    .Annual => "annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceTieredWithProrationCadence
                    .SemiAnnual => "semi_annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceTieredWithProrationCadence
                    .Monthly => "monthly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceTieredWithProrationCadence
                    .Quarterly => "quarterly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceTieredWithProrationCadence
                    .OneTime => "one_time",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceTieredWithProrationCadence
                    .Custom => "custom",
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
                new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceTieredWithProrationModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationModelType value,
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
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationTieredWithProrationConfig,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceTieredWithProrationTieredWithProrationConfig : ModelBase
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier
    /// with proration
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Beta.ExternalPlanID.Tier2> Tiers
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Beta.ExternalPlanID.Tier2>>(
                this.RawData,
                "tiers"
            );
        }
        init { ModelBase.Set(this._rawData, "tiers", value); }
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReplacePricePriceTieredWithProrationTieredWithProrationConfig(
        List<global::Orb.Models.Beta.ExternalPlanID.Tier2> tiers
    )
        : this()
    {
        this.Tiers = tiers;
    }
}

class ReplacePricePriceTieredWithProrationTieredWithProrationConfigFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationTieredWithProrationConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationTieredWithProrationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationTieredWithProrationConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Configuration for a single tiered with proration tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.Tier2,
        global::Orb.Models.Beta.ExternalPlanID.Tier2FromRaw
    >)
)]
public sealed record class Tier2 : ModelBase
{
    /// <summary>
    /// Inclusive tier starting value
    /// </summary>
    public required string TierLowerBound
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tier_lower_bound"); }
        init { ModelBase.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    public override void Validate()
    {
        _ = this.TierLowerBound;
        _ = this.UnitAmount;
    }

    public Tier2() { }

    public Tier2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.Tier2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Tier2FromRaw : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.Tier2>
{
    public global::Orb.Models.Beta.ExternalPlanID.Tier2 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.Tier2.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfigConverter)
)]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ReplacePricePriceTieredWithProrationConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceTieredWithProrationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class ReplacePricePriceGroupedWithMinMaxThresholds : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                >
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                this.RawData,
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { ModelBase.Set(this._rawData, "grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceGroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceGroupedWithMinMaxThresholdsFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholds.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsCadenceConverter)
)]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                .Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                .SemiAnnual,
            "monthly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                .Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                .Quarterly,
            "one_time" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                .OneTime,
            "custom" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                .Custom,
            _ =>
                (global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                    .Annual => "annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                    .SemiAnnual => "semi_annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                    .Monthly => "monthly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                    .Quarterly => "quarterly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                    .OneTime => "one_time",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceGroupedWithMinMaxThresholdsCadence
                    .Custom => "custom",
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
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : ModelBase
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "maximum_charge"); }
        init { ModelBase.Set(this._rawData, "maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "minimum_charge"); }
        init { ModelBase.Set(this._rawData, "minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "per_unit_rate"); }
        init { ModelBase.Set(this._rawData, "per_unit_rate", value); }
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
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
                new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceGroupedWithMinMaxThresholdsModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter)
)]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class ReplacePricePriceCumulativeGroupedAllocation : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCadence
                >
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                this.RawData,
                "cumulative_grouped_allocation_config"
            );
        }
        init { ModelBase.Set(this._rawData, "cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceCumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceCumulativeGroupedAllocationFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCadenceConverter)
)]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceCumulativeGroupedAllocationCadence
                .Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceCumulativeGroupedAllocationCadence
                .SemiAnnual,
            "monthly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceCumulativeGroupedAllocationCadence
                .Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceCumulativeGroupedAllocationCadence
                .Quarterly,
            "one_time" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceCumulativeGroupedAllocationCadence
                .OneTime,
            "custom" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceCumulativeGroupedAllocationCadence
                .Custom,
            _ =>
                (global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCadence)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceCumulativeGroupedAllocationCadence
                    .Annual => "annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceCumulativeGroupedAllocationCadence
                    .SemiAnnual => "semi_annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceCumulativeGroupedAllocationCadence
                    .Monthly => "monthly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceCumulativeGroupedAllocationCadence
                    .Quarterly => "quarterly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceCumulativeGroupedAllocationCadence
                    .OneTime => "one_time",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceCumulativeGroupedAllocationCadence
                    .Custom => "custom",
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
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : ModelBase
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "cumulative_allocation"); }
        init { ModelBase.Set(this._rawData, "cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "group_allocation"); }
        init { ModelBase.Set(this._rawData, "group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
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
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
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
                new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceCumulativeGroupedAllocationModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter)
)]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ReplacePricePriceCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentFromRaw
    >)
)]
public sealed record class ReplacePricePricePercent : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence
                >
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentPercentConfig PercentConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentPercentConfig>(
                this.RawData,
                "percent_config"
            );
        }
        init { ModelBase.Set(this._rawData, "percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public ReplacePricePricePercent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePricePercent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePricePercentFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadenceConverter)
)]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePricePercentCadence
                .Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePricePercentCadence
                .SemiAnnual,
            "monthly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePricePercentCadence
                .Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePricePercentCadence
                .Quarterly,
            "one_time" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePricePercentCadence
                .OneTime,
            "custom" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePricePercentCadence
                .Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence.Annual =>
                    "annual",
                global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence.SemiAnnual =>
                    "semi_annual",
                global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence.Monthly =>
                    "monthly",
                global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence.Quarterly =>
                    "quarterly",
                global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence.OneTime =>
                    "one_time",
                global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentCadence.Custom =>
                    "custom",
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
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePricePercentModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentModelType value,
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
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentPercentConfig,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentPercentConfigFromRaw
    >)
)]
public sealed record class ReplacePricePricePercentPercentConfig : ModelBase
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percent"); }
        init { ModelBase.Set(this._rawData, "percent", value); }
    }

    public override void Validate()
    {
        _ = this.Percent;
    }

    public ReplacePricePricePercentPercentConfig() { }

    public ReplacePricePricePercentPercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePricePercentPercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentPercentConfig FromRawUnchecked(
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
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentPercentConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentPercentConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfigConverter)
)]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ReplacePricePricePercentConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePricePercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputFromRaw
    >)
)]
public sealed record class ReplacePricePriceEventOutput : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadence
    > Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<
                    string,
                    global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadence
                >
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputEventOutputConfig>(
                this.RawData,
                "event_output_config"
            );
        }
        init { ModelBase.Set(this._rawData, "event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputModelType>(
                this.RawData,
                "model_type"
            );
        }
        init { ModelBase.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { ModelBase.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { ModelBase.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { ModelBase.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which
    /// this price is billed.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { ModelBase.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { ModelBase.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// A transient ID that can be used to reference this price when adding adjustments
    /// in the same API call.
    /// </summary>
    public string? ReferenceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reference_id"); }
        init { ModelBase.Set(this._rawData, "reference_id", value); }
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

    public ReplacePricePriceEventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceEventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReplacePricePriceEventOutputFromRaw
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutput.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadenceConverter)
)]
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
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadence>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceEventOutputCadence
                .Annual,
            "semi_annual" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceEventOutputCadence
                .SemiAnnual,
            "monthly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceEventOutputCadence
                .Monthly,
            "quarterly" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceEventOutputCadence
                .Quarterly,
            "one_time" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceEventOutputCadence
                .OneTime,
            "custom" => global::Orb
                .Models
                .Beta
                .ExternalPlanID
                .ReplacePricePriceEventOutputCadence
                .Custom,
            _ => (global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadence.Annual =>
                    "annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceEventOutputCadence
                    .SemiAnnual => "semi_annual",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceEventOutputCadence
                    .Monthly => "monthly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceEventOutputCadence
                    .Quarterly => "quarterly",
                global::Orb
                    .Models
                    .Beta
                    .ExternalPlanID
                    .ReplacePricePriceEventOutputCadence
                    .OneTime => "one_time",
                global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputCadence.Custom =>
                    "custom",
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
    typeof(ModelConverter<
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputEventOutputConfig,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class ReplacePricePriceEventOutputEventOutputConfig : ModelBase
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_rating_key"); }
        init { ModelBase.Set(this._rawData, "unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "default_unit_rate"); }
        init { ModelBase.Set(this._rawData, "default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "grouping_key"); }
        init { ModelBase.Set(this._rawData, "grouping_key", value); }
    }

    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public ReplacePricePriceEventOutputEventOutputConfig() { }

    public ReplacePricePriceEventOutputEventOutputConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplacePricePriceEventOutputEventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
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
    : IFromRaw<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputEventOutputConfig>
{
    public global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputEventOutputConfig.FromRawUnchecked(
            rawData
        );
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
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ReplacePricePriceEventOutputModelType'"
            );
        }
    }

    class Converter
        : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputModelType>
    {
        public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(
    typeof(global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfigConverter)
)]
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

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig(
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

    public virtual bool Equals(
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ReplacePricePriceEventOutputConversionRateConfigConverter
    : JsonConverter<global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig>
{
    public override global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig? Read(
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
                return new global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig(
                    json
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ExternalPlanID.ReplacePricePriceEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
