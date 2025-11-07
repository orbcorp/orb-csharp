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

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/plans/{0}/versions", this.PlanID)
        )
        {
            Query = this.QueryString(client),
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
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
    public required global::Orb.Models.Beta.Adjustment Adjustment
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.Adjustment>(
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
    public AddAdjustment(global::Orb.Models.Beta.Adjustment adjustment)
        : this()
    {
        this.Adjustment = adjustment;
    }
}

/// <summary>
/// The definition of a new adjustment to create and add to the plan.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.AdjustmentConverter))]
public record class Adjustment
{
    public object Value { get; private init; }

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

    public Adjustment(NewPercentageDiscount value)
    {
        Value = value;
    }

    public Adjustment(NewUsageDiscount value)
    {
        Value = value;
    }

    public Adjustment(NewAmountDiscount value)
    {
        Value = value;
    }

    public Adjustment(NewMinimum value)
    {
        Value = value;
    }

    public Adjustment(NewMaximum value)
    {
        Value = value;
    }

    Adjustment(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.Adjustment CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class AdjustmentConverter : JsonConverter<global::Orb.Models.Beta.Adjustment>
{
    public override global::Orb.Models.Beta.Adjustment? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPercentageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "usage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewUsageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "amount_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewAmountDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewMinimum'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "maximum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewMaximum'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Adjustment value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
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
    public object Value { get; private init; }

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
                newPlanMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public Price(NewPlanUnitPrice value)
    {
        Value = value;
    }

    public Price(NewPlanTieredPrice value)
    {
        Value = value;
    }

    public Price(NewPlanBulkPrice value)
    {
        Value = value;
    }

    public Price(global::Orb.Models.Beta.BulkWithFilters value)
    {
        Value = value;
    }

    public Price(NewPlanPackagePrice value)
    {
        Value = value;
    }

    public Price(NewPlanMatrixPrice value)
    {
        Value = value;
    }

    public Price(NewPlanThresholdTotalAmountPrice value)
    {
        Value = value;
    }

    public Price(NewPlanTieredPackagePrice value)
    {
        Value = value;
    }

    public Price(NewPlanTieredWithMinimumPrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedTieredPrice value)
    {
        Value = value;
    }

    public Price(NewPlanTieredPackageWithMinimumPrice value)
    {
        Value = value;
    }

    public Price(NewPlanPackageWithAllocationPrice value)
    {
        Value = value;
    }

    public Price(NewPlanUnitWithPercentPrice value)
    {
        Value = value;
    }

    public Price(NewPlanMatrixWithAllocationPrice value)
    {
        Value = value;
    }

    public Price(global::Orb.Models.Beta.TieredWithProration value)
    {
        Value = value;
    }

    public Price(NewPlanUnitWithProrationPrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedAllocationPrice value)
    {
        Value = value;
    }

    public Price(NewPlanBulkWithProrationPrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedWithProratedMinimumPrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedWithMeteredMinimumPrice value)
    {
        Value = value;
    }

    public Price(global::Orb.Models.Beta.GroupedWithMinMaxThresholds value)
    {
        Value = value;
    }

    public Price(NewPlanMatrixWithDisplayNamePrice value)
    {
        Value = value;
    }

    public Price(NewPlanGroupedTieredPackagePrice value)
    {
        Value = value;
    }

    public Price(NewPlanMaxGroupTieredPackagePrice value)
    {
        Value = value;
    }

    public Price(NewPlanScalableMatrixWithUnitPricingPrice value)
    {
        Value = value;
    }

    public Price(NewPlanScalableMatrixWithTieredPricingPrice value)
    {
        Value = value;
    }

    public Price(NewPlanCumulativeGroupedBulkPrice value)
    {
        Value = value;
    }

    public Price(NewPlanMinimumCompositePrice value)
    {
        Value = value;
    }

    public Price(global::Orb.Models.Beta.Percent value)
    {
        Value = value;
    }

    public Price(global::Orb.Models.Beta.EventOutput value)
    {
        Value = value;
    }

    Price(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.Price CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Price");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_filters":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Beta.BulkWithFilters'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "threshold_total_amount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanThresholdTotalAmountPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredWithMinimumPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPackageWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanPackageWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitWithPercentPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixWithAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Beta.TieredWithProration'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanBulkWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_prorated_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedWithProratedMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_metered_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedWithMeteredMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_min_max_thresholds":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Beta.GroupedWithMinMaxThresholds'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_display_name":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixWithDisplayNamePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "max_group_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMaxGroupTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanScalableMatrixWithUnitPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanScalableMatrixWithTieredPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "cumulative_grouped_bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanCumulativeGroupedBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMinimumCompositePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<global::Orb.Models.Beta.Percent>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Beta.Percent'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "event_output":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new global::Orb.Models.Beta.Price(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'global::Orb.Models.Beta.EventOutput'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Price? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType'"
            );
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
    public object Value { get; private init; }

    public ConversionRateConfig(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
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
    public required ApiEnum<string, global::Orb.Models.Beta.CadenceModel> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Beta.CadenceModel>
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
    public global::Orb.Models.Beta.ModelTypeModel ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelTypeModel>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfigModel? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfigModel?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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
[JsonConverter(typeof(global::Orb.Models.Beta.CadenceModelConverter))]
public enum CadenceModel
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class CadenceModelConverter : JsonConverter<global::Orb.Models.Beta.CadenceModel>
{
    public override global::Orb.Models.Beta.CadenceModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.CadenceModel.Annual,
            "semi_annual" => global::Orb.Models.Beta.CadenceModel.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.CadenceModel.Monthly,
            "quarterly" => global::Orb.Models.Beta.CadenceModel.Quarterly,
            "one_time" => global::Orb.Models.Beta.CadenceModel.OneTime,
            "custom" => global::Orb.Models.Beta.CadenceModel.Custom,
            _ => (global::Orb.Models.Beta.CadenceModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.CadenceModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.CadenceModel.Annual => "annual",
                global::Orb.Models.Beta.CadenceModel.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.CadenceModel.Monthly => "monthly",
                global::Orb.Models.Beta.CadenceModel.Quarterly => "quarterly",
                global::Orb.Models.Beta.CadenceModel.OneTime => "one_time",
                global::Orb.Models.Beta.CadenceModel.Custom => "custom",
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
public class ModelTypeModel
{
    public JsonElement Json { get; private init; }

    public ModelTypeModel()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    ModelTypeModel(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelTypeModel().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelTypeModel'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelTypeModel>
    {
        public override global::Orb.Models.Beta.ModelTypeModel? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelTypeModel value,
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
    /// Tiers for rating based on total usage quantities into the specified tier with proration
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

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfigModelConverter))]
public record class ConversionRateConfigModel
{
    public object Value { get; private init; }

    public ConversionRateConfigModel(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfigModel(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfigModel(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfigModel CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfigModel"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfigModel"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfigModel(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfigModel(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfigModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfigModelConverter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfigModel>
{
    public override global::Orb.Models.Beta.ConversionRateConfigModel? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfigModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfigModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfigModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
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
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence1> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence1>>(
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
    public global::Orb.Models.Beta.ModelType1 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType1>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfig1? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig1?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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
[JsonConverter(typeof(global::Orb.Models.Beta.Cadence1Converter))]
public enum Cadence1
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence1Converter : JsonConverter<global::Orb.Models.Beta.Cadence1>
{
    public override global::Orb.Models.Beta.Cadence1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence1.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence1.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence1.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence1.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence1.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence1.Custom,
            _ => (global::Orb.Models.Beta.Cadence1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence1.Annual => "annual",
                global::Orb.Models.Beta.Cadence1.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence1.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence1.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence1.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence1.Custom => "custom",
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
public class ModelType1
{
    public JsonElement Json { get; private init; }

    public ModelType1()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    ModelType1(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType1().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType1'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType1>
    {
        public override global::Orb.Models.Beta.ModelType1? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType1 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfig1Converter))]
public record class ConversionRateConfig1
{
    public object Value { get; private init; }

    public ConversionRateConfig1(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig1(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig1(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig1 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig1"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig1"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig1(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig1(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig1"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig1Converter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig1>
{
    public override global::Orb.Models.Beta.ConversionRateConfig1? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig1 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.Percent>))]
public sealed record class Percent : ModelBase, IFromRaw<global::Orb.Models.Beta.Percent>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence2> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence2>>(
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
    public global::Orb.Models.Beta.ModelType2 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType2>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfig2? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig2?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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
[JsonConverter(typeof(global::Orb.Models.Beta.Cadence2Converter))]
public enum Cadence2
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence2Converter : JsonConverter<global::Orb.Models.Beta.Cadence2>
{
    public override global::Orb.Models.Beta.Cadence2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence2.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence2.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence2.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence2.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence2.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence2.Custom,
            _ => (global::Orb.Models.Beta.Cadence2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence2.Annual => "annual",
                global::Orb.Models.Beta.Cadence2.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence2.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence2.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence2.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence2.Custom => "custom",
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
public class ModelType2
{
    public JsonElement Json { get; private init; }

    public ModelType2()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    ModelType2(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType2().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType2'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType2>
    {
        public override global::Orb.Models.Beta.ModelType2? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType2 value,
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

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfig2Converter))]
public record class ConversionRateConfig2
{
    public object Value { get; private init; }

    public ConversionRateConfig2(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig2(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig2(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig2 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig2"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig2"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig2(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig2(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig2"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig2Converter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig2>
{
    public override global::Orb.Models.Beta.ConversionRateConfig2? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig2(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig2 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.EventOutput>))]
public sealed record class EventOutput : ModelBase, IFromRaw<global::Orb.Models.Beta.EventOutput>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence3> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence3>>(
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
    public global::Orb.Models.Beta.ModelType3 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType3>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfig3? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig3?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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
[JsonConverter(typeof(global::Orb.Models.Beta.Cadence3Converter))]
public enum Cadence3
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence3Converter : JsonConverter<global::Orb.Models.Beta.Cadence3>
{
    public override global::Orb.Models.Beta.Cadence3 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence3.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence3.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence3.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence3.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence3.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence3.Custom,
            _ => (global::Orb.Models.Beta.Cadence3)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence3 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence3.Annual => "annual",
                global::Orb.Models.Beta.Cadence3.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence3.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence3.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence3.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence3.Custom => "custom",
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
public class ModelType3
{
    public JsonElement Json { get; private init; }

    public ModelType3()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    ModelType3(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType3().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType3'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType3>
    {
        public override global::Orb.Models.Beta.ModelType3? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType3 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfig3Converter))]
public record class ConversionRateConfig3
{
    public object Value { get; private init; }

    public ConversionRateConfig3(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig3(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig3(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig3 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig3"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig3"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig3(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig3(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig3"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig3Converter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig3>
{
    public override global::Orb.Models.Beta.ConversionRateConfig3? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig3(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig3 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
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
    public required global::Orb.Models.Beta.AdjustmentModel Adjustment
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.AdjustmentModel>(
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
[JsonConverter(typeof(global::Orb.Models.Beta.AdjustmentModelConverter))]
public record class AdjustmentModel
{
    public object Value { get; private init; }

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

    public AdjustmentModel(NewPercentageDiscount value)
    {
        Value = value;
    }

    public AdjustmentModel(NewUsageDiscount value)
    {
        Value = value;
    }

    public AdjustmentModel(NewAmountDiscount value)
    {
        Value = value;
    }

    public AdjustmentModel(NewMinimum value)
    {
        Value = value;
    }

    public AdjustmentModel(NewMaximum value)
    {
        Value = value;
    }

    AdjustmentModel(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.AdjustmentModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
                    "Data did not match any variant of AdjustmentModel"
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
                "Data did not match any variant of AdjustmentModel"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.AdjustmentModel(
        NewPercentageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.AdjustmentModel(
        NewUsageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.AdjustmentModel(
        NewAmountDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.AdjustmentModel(NewMinimum value) =>
        new(value);

    public static implicit operator global::Orb.Models.Beta.AdjustmentModel(NewMaximum value) =>
        new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of AdjustmentModel");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class AdjustmentModelConverter : JsonConverter<global::Orb.Models.Beta.AdjustmentModel>
{
    public override global::Orb.Models.Beta.AdjustmentModel? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.AdjustmentModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPercentageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "usage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.AdjustmentModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewUsageDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "amount_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.AdjustmentModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewAmountDiscount'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMinimum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.AdjustmentModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewMinimum'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "maximum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewMaximum>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.AdjustmentModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewMaximum'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.AdjustmentModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
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
    public PriceModel? Price
    {
        get
        {
            if (!this._properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceModel?>(element, ModelBase.SerializerOptions);
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
[JsonConverter(typeof(PriceModelConverter))]
public record class PriceModel
{
    public object Value { get; private init; }

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
                newPlanMinimumComposite: (x) => x.ReferenceID,
                percent: (x) => x.ReferenceID,
                eventOutput: (x) => x.ReferenceID
            );
        }
    }

    public PriceModel(NewPlanUnitPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanTieredPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanBulkPrice value)
    {
        Value = value;
    }

    public PriceModel(BulkWithFiltersModel value)
    {
        Value = value;
    }

    public PriceModel(NewPlanPackagePrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanMatrixPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanThresholdTotalAmountPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanTieredPackagePrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanTieredWithMinimumPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanGroupedTieredPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanTieredPackageWithMinimumPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanPackageWithAllocationPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanUnitWithPercentPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanMatrixWithAllocationPrice value)
    {
        Value = value;
    }

    public PriceModel(TieredWithProrationModel value)
    {
        Value = value;
    }

    public PriceModel(NewPlanUnitWithProrationPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanGroupedAllocationPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanBulkWithProrationPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanGroupedWithProratedMinimumPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanGroupedWithMeteredMinimumPrice value)
    {
        Value = value;
    }

    public PriceModel(GroupedWithMinMaxThresholdsModel value)
    {
        Value = value;
    }

    public PriceModel(NewPlanMatrixWithDisplayNamePrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanGroupedTieredPackagePrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanMaxGroupTieredPackagePrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanScalableMatrixWithUnitPricingPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanScalableMatrixWithTieredPricingPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanCumulativeGroupedBulkPrice value)
    {
        Value = value;
    }

    public PriceModel(NewPlanMinimumCompositePrice value)
    {
        Value = value;
    }

    public PriceModel(PercentModel value)
    {
        Value = value;
    }

    public PriceModel(EventOutputModel value)
    {
        Value = value;
    }

    PriceModel(UnknownVariant value)
    {
        Value = value;
    }

    public static PriceModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public bool TryPickBulkWithFilters([NotNullWhen(true)] out BulkWithFiltersModel? value)
    {
        value = this.Value as BulkWithFiltersModel;
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

    public bool TryPickTieredWithProration([NotNullWhen(true)] out TieredWithProrationModel? value)
    {
        value = this.Value as TieredWithProrationModel;
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
        [NotNullWhen(true)] out GroupedWithMinMaxThresholdsModel? value
    )
    {
        value = this.Value as GroupedWithMinMaxThresholdsModel;
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

    public bool TryPickNewPlanMinimumComposite(
        [NotNullWhen(true)] out NewPlanMinimumCompositePrice? value
    )
    {
        value = this.Value as NewPlanMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out PercentModel? value)
    {
        value = this.Value as PercentModel;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out EventOutputModel? value)
    {
        value = this.Value as EventOutputModel;
        return value != null;
    }

    public void Switch(
        System::Action<NewPlanUnitPrice> newPlanUnit,
        System::Action<NewPlanTieredPrice> newPlanTiered,
        System::Action<NewPlanBulkPrice> newPlanBulk,
        System::Action<BulkWithFiltersModel> bulkWithFilters,
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
        System::Action<TieredWithProrationModel> tieredWithProration,
        System::Action<NewPlanUnitWithProrationPrice> newPlanUnitWithProration,
        System::Action<NewPlanGroupedAllocationPrice> newPlanGroupedAllocation,
        System::Action<NewPlanBulkWithProrationPrice> newPlanBulkWithProration,
        System::Action<NewPlanGroupedWithProratedMinimumPrice> newPlanGroupedWithProratedMinimum,
        System::Action<NewPlanGroupedWithMeteredMinimumPrice> newPlanGroupedWithMeteredMinimum,
        System::Action<GroupedWithMinMaxThresholdsModel> groupedWithMinMaxThresholds,
        System::Action<NewPlanMatrixWithDisplayNamePrice> newPlanMatrixWithDisplayName,
        System::Action<NewPlanGroupedTieredPackagePrice> newPlanGroupedTieredPackage,
        System::Action<NewPlanMaxGroupTieredPackagePrice> newPlanMaxGroupTieredPackage,
        System::Action<NewPlanScalableMatrixWithUnitPricingPrice> newPlanScalableMatrixWithUnitPricing,
        System::Action<NewPlanScalableMatrixWithTieredPricingPrice> newPlanScalableMatrixWithTieredPricing,
        System::Action<NewPlanCumulativeGroupedBulkPrice> newPlanCumulativeGroupedBulk,
        System::Action<NewPlanMinimumCompositePrice> newPlanMinimumComposite,
        System::Action<PercentModel> percent,
        System::Action<EventOutputModel> eventOutput
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
            case BulkWithFiltersModel value:
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
            case TieredWithProrationModel value:
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
            case GroupedWithMinMaxThresholdsModel value:
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
            case NewPlanMinimumCompositePrice value:
                newPlanMinimumComposite(value);
                break;
            case PercentModel value:
                percent(value);
                break;
            case EventOutputModel value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of PriceModel");
        }
    }

    public T Match<T>(
        System::Func<NewPlanUnitPrice, T> newPlanUnit,
        System::Func<NewPlanTieredPrice, T> newPlanTiered,
        System::Func<NewPlanBulkPrice, T> newPlanBulk,
        System::Func<BulkWithFiltersModel, T> bulkWithFilters,
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
        System::Func<TieredWithProrationModel, T> tieredWithProration,
        System::Func<NewPlanUnitWithProrationPrice, T> newPlanUnitWithProration,
        System::Func<NewPlanGroupedAllocationPrice, T> newPlanGroupedAllocation,
        System::Func<NewPlanBulkWithProrationPrice, T> newPlanBulkWithProration,
        System::Func<NewPlanGroupedWithProratedMinimumPrice, T> newPlanGroupedWithProratedMinimum,
        System::Func<NewPlanGroupedWithMeteredMinimumPrice, T> newPlanGroupedWithMeteredMinimum,
        System::Func<GroupedWithMinMaxThresholdsModel, T> groupedWithMinMaxThresholds,
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
        System::Func<NewPlanMinimumCompositePrice, T> newPlanMinimumComposite,
        System::Func<PercentModel, T> percent,
        System::Func<EventOutputModel, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewPlanUnitPrice value => newPlanUnit(value),
            NewPlanTieredPrice value => newPlanTiered(value),
            NewPlanBulkPrice value => newPlanBulk(value),
            BulkWithFiltersModel value => bulkWithFilters(value),
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
            TieredWithProrationModel value => tieredWithProration(value),
            NewPlanUnitWithProrationPrice value => newPlanUnitWithProration(value),
            NewPlanGroupedAllocationPrice value => newPlanGroupedAllocation(value),
            NewPlanBulkWithProrationPrice value => newPlanBulkWithProration(value),
            NewPlanGroupedWithProratedMinimumPrice value => newPlanGroupedWithProratedMinimum(
                value
            ),
            NewPlanGroupedWithMeteredMinimumPrice value => newPlanGroupedWithMeteredMinimum(value),
            GroupedWithMinMaxThresholdsModel value => groupedWithMinMaxThresholds(value),
            NewPlanMatrixWithDisplayNamePrice value => newPlanMatrixWithDisplayName(value),
            NewPlanGroupedTieredPackagePrice value => newPlanGroupedTieredPackage(value),
            NewPlanMaxGroupTieredPackagePrice value => newPlanMaxGroupTieredPackage(value),
            NewPlanScalableMatrixWithUnitPricingPrice value => newPlanScalableMatrixWithUnitPricing(
                value
            ),
            NewPlanScalableMatrixWithTieredPricingPrice value =>
                newPlanScalableMatrixWithTieredPricing(value),
            NewPlanCumulativeGroupedBulkPrice value => newPlanCumulativeGroupedBulk(value),
            NewPlanMinimumCompositePrice value => newPlanMinimumComposite(value),
            PercentModel value => percent(value),
            EventOutputModel value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of PriceModel"),
        };
    }

    public static implicit operator PriceModel(NewPlanUnitPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanTieredPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanBulkPrice value) => new(value);

    public static implicit operator PriceModel(BulkWithFiltersModel value) => new(value);

    public static implicit operator PriceModel(NewPlanPackagePrice value) => new(value);

    public static implicit operator PriceModel(NewPlanMatrixPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanThresholdTotalAmountPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanTieredPackagePrice value) => new(value);

    public static implicit operator PriceModel(NewPlanTieredWithMinimumPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanGroupedTieredPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanTieredPackageWithMinimumPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanPackageWithAllocationPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanUnitWithPercentPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanMatrixWithAllocationPrice value) =>
        new(value);

    public static implicit operator PriceModel(TieredWithProrationModel value) => new(value);

    public static implicit operator PriceModel(NewPlanUnitWithProrationPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanGroupedAllocationPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanBulkWithProrationPrice value) => new(value);

    public static implicit operator PriceModel(NewPlanGroupedWithProratedMinimumPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanGroupedWithMeteredMinimumPrice value) =>
        new(value);

    public static implicit operator PriceModel(GroupedWithMinMaxThresholdsModel value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanMatrixWithDisplayNamePrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanGroupedTieredPackagePrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanMaxGroupTieredPackagePrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanScalableMatrixWithUnitPricingPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanScalableMatrixWithTieredPricingPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanCumulativeGroupedBulkPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewPlanMinimumCompositePrice value) => new(value);

    public static implicit operator PriceModel(PercentModel value) => new(value);

    public static implicit operator PriceModel(EventOutputModel value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of PriceModel");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class PriceModelConverter : JsonConverter<PriceModel?>
{
    public override PriceModel? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkPrice>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_filters":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BulkWithFiltersModel>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BulkWithFiltersModel'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "threshold_total_amount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanThresholdTotalAmountPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanThresholdTotalAmountPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanTieredWithMinimumPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedTieredPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_package_with_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanTieredPackageWithMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "package_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanPackageWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitWithPercentPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMatrixWithAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixWithAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredWithProrationModel>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredWithProrationModel'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "unit_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanUnitWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanUnitWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_allocation":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedAllocationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedAllocationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "bulk_with_proration":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanBulkWithProrationPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanBulkWithProrationPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_prorated_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedWithProratedMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_metered_minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedWithMeteredMinimumPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_with_min_max_thresholds":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsModel>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'GroupedWithMinMaxThresholdsModel'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "matrix_with_display_name":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMatrixWithDisplayNamePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "grouped_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanGroupedTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanGroupedTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "max_group_tiered_package":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMaxGroupTieredPackagePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_unit_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanScalableMatrixWithUnitPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "scalable_matrix_with_tiered_pricing":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanScalableMatrixWithTieredPricingPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "cumulative_grouped_bulk":
            {
                List<OrbInvalidDataException> exceptions = [];

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
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanCumulativeGroupedBulkPrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewPlanMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewPlanMinimumCompositePrice'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percent":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentModel>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'PercentModel'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "event_output":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<EventOutputModel>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new PriceModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'EventOutputModel'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModel? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<BulkWithFiltersModel>))]
public sealed record class BulkWithFiltersModel : ModelBase, IFromRaw<BulkWithFiltersModel>
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required BulkWithFiltersConfigModel BulkWithFiltersConfig
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

            return JsonSerializer.Deserialize<BulkWithFiltersConfigModel>(
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
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence4> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence4>>(
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
    public global::Orb.Models.Beta.ModelType4 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType4>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfig4? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig4?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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

    public BulkWithFiltersModel()
    {
        this.ModelType = new();
    }

    public BulkWithFiltersModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkWithFiltersModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<BulkWithFiltersConfigModel>))]
public sealed record class BulkWithFiltersConfigModel
    : ModelBase,
        IFromRaw<BulkWithFiltersConfigModel>
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

    public BulkWithFiltersConfigModel() { }

    public BulkWithFiltersConfigModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfigModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkWithFiltersConfigModel FromRawUnchecked(
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
[JsonConverter(typeof(global::Orb.Models.Beta.Cadence4Converter))]
public enum Cadence4
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence4Converter : JsonConverter<global::Orb.Models.Beta.Cadence4>
{
    public override global::Orb.Models.Beta.Cadence4 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence4.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence4.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence4.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence4.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence4.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence4.Custom,
            _ => (global::Orb.Models.Beta.Cadence4)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence4 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence4.Annual => "annual",
                global::Orb.Models.Beta.Cadence4.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence4.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence4.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence4.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence4.Custom => "custom",
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
public class ModelType4
{
    public JsonElement Json { get; private init; }

    public ModelType4()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ModelType4(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType4().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType4'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType4>
    {
        public override global::Orb.Models.Beta.ModelType4? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType4 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfig4Converter))]
public record class ConversionRateConfig4
{
    public object Value { get; private init; }

    public ConversionRateConfig4(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig4(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig4(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig4 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig4"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig4"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig4(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig4(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig4"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig4Converter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig4>
{
    public override global::Orb.Models.Beta.ConversionRateConfig4? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig4(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig4(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig4 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<TieredWithProrationModel>))]
public sealed record class TieredWithProrationModel : ModelBase, IFromRaw<TieredWithProrationModel>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence5> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence5>>(
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
    public global::Orb.Models.Beta.ModelType5 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType5>(
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
    public required global::Orb.Models.Beta.TieredWithProrationConfigModel TieredWithProrationConfig
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.TieredWithProrationConfigModel>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfig5? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig5?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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

    public TieredWithProrationModel()
    {
        this.ModelType = new();
    }

    public TieredWithProrationModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TieredWithProrationModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.Cadence5Converter))]
public enum Cadence5
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence5Converter : JsonConverter<global::Orb.Models.Beta.Cadence5>
{
    public override global::Orb.Models.Beta.Cadence5 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence5.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence5.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence5.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence5.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence5.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence5.Custom,
            _ => (global::Orb.Models.Beta.Cadence5)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence5 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence5.Annual => "annual",
                global::Orb.Models.Beta.Cadence5.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence5.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence5.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence5.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence5.Custom => "custom",
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
public class ModelType5
{
    public JsonElement Json { get; private init; }

    public ModelType5()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"tiered_with_proration\"");
    }

    ModelType5(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType5().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType5'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType5>
    {
        public override global::Orb.Models.Beta.ModelType5? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType5 value,
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
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Beta.TieredWithProrationConfigModel>))]
public sealed record class TieredWithProrationConfigModel
    : ModelBase,
        IFromRaw<global::Orb.Models.Beta.TieredWithProrationConfigModel>
{
    /// <summary>
    /// Tiers for rating based on total usage quantities into the specified tier with proration
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

    public TieredWithProrationConfigModel() { }

    public TieredWithProrationConfigModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredWithProrationConfigModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Beta.TieredWithProrationConfigModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TieredWithProrationConfigModel(List<global::Orb.Models.Beta.Tier2> tiers)
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

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfig5Converter))]
public record class ConversionRateConfig5
{
    public object Value { get; private init; }

    public ConversionRateConfig5(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig5(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig5(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig5 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig5"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig5"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig5(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig5(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig5"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig5Converter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig5>
{
    public override global::Orb.Models.Beta.ConversionRateConfig5? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig5(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig5(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig5 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholdsModel>))]
public sealed record class GroupedWithMinMaxThresholdsModel
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholdsModel>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence6> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence6>>(
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
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required GroupedWithMinMaxThresholdsConfigModel GroupedWithMinMaxThresholdsConfig
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

            return JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsConfigModel>(
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
    public global::Orb.Models.Beta.ModelType6 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType6>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfig6? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig6?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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

    public GroupedWithMinMaxThresholdsModel()
    {
        this.ModelType = new();
    }

    public GroupedWithMinMaxThresholdsModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholdsModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.Cadence6Converter))]
public enum Cadence6
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence6Converter : JsonConverter<global::Orb.Models.Beta.Cadence6>
{
    public override global::Orb.Models.Beta.Cadence6 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence6.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence6.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence6.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence6.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence6.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence6.Custom,
            _ => (global::Orb.Models.Beta.Cadence6)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence6 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence6.Annual => "annual",
                global::Orb.Models.Beta.Cadence6.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence6.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence6.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence6.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence6.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholdsConfigModel>))]
public sealed record class GroupedWithMinMaxThresholdsConfigModel
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholdsConfigModel>
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

    public GroupedWithMinMaxThresholdsConfigModel() { }

    public GroupedWithMinMaxThresholdsConfigModel(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfigModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholdsConfigModel FromRawUnchecked(
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
public class ModelType6
{
    public JsonElement Json { get; private init; }

    public ModelType6()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    ModelType6(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType6().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType6'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType6>
    {
        public override global::Orb.Models.Beta.ModelType6? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType6 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfig6Converter))]
public record class ConversionRateConfig6
{
    public object Value { get; private init; }

    public ConversionRateConfig6(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig6(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig6(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig6 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig6"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig6"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig6(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig6(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig6"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig6Converter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig6>
{
    public override global::Orb.Models.Beta.ConversionRateConfig6? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig6(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig6(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig6 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<PercentModel>))]
public sealed record class PercentModel : ModelBase, IFromRaw<PercentModel>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence7> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence7>>(
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
    public global::Orb.Models.Beta.ModelType7 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType7>(
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
    public required PercentConfigModel PercentConfig
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

            return JsonSerializer.Deserialize<PercentConfigModel>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfig7? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig7?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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

    public PercentModel()
    {
        this.ModelType = new();
    }

    public PercentModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PercentModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.Cadence7Converter))]
public enum Cadence7
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence7Converter : JsonConverter<global::Orb.Models.Beta.Cadence7>
{
    public override global::Orb.Models.Beta.Cadence7 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence7.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence7.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence7.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence7.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence7.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence7.Custom,
            _ => (global::Orb.Models.Beta.Cadence7)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence7 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence7.Annual => "annual",
                global::Orb.Models.Beta.Cadence7.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence7.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence7.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence7.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence7.Custom => "custom",
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
public class ModelType7
{
    public JsonElement Json { get; private init; }

    public ModelType7()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    ModelType7(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType7().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType7'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType7>
    {
        public override global::Orb.Models.Beta.ModelType7? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType7 value,
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
[JsonConverter(typeof(ModelConverter<PercentConfigModel>))]
public sealed record class PercentConfigModel : ModelBase, IFromRaw<PercentConfigModel>
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

    public PercentConfigModel() { }

    public PercentConfigModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfigModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PercentConfigModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public PercentConfigModel(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfig7Converter))]
public record class ConversionRateConfig7
{
    public object Value { get; private init; }

    public ConversionRateConfig7(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig7(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig7(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig7 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig7"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig7"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig7(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig7(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig7"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig7Converter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig7>
{
    public override global::Orb.Models.Beta.ConversionRateConfig7? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig7(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig7(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig7 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<EventOutputModel>))]
public sealed record class EventOutputModel : ModelBase, IFromRaw<EventOutputModel>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Beta.Cadence8> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Beta.Cadence8>>(
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
    public required EventOutputConfigModel EventOutputConfig
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

            return JsonSerializer.Deserialize<EventOutputConfigModel>(
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
    public global::Orb.Models.Beta.ModelType8 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ModelType8>(
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
    /// For custom cadence: specifies the duration of the billing period in days or months.
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
    public global::Orb.Models.Beta.ConversionRateConfig8? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Beta.ConversionRateConfig8?>(
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
    /// An ISO 4217 currency string, or custom pricing unit identifier, in which this
    /// price is billed.
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

    public EventOutputModel()
    {
        this.ModelType = new();
    }

    public EventOutputModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EventOutputModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Beta.Cadence8Converter))]
public enum Cadence8
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence8Converter : JsonConverter<global::Orb.Models.Beta.Cadence8>
{
    public override global::Orb.Models.Beta.Cadence8 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Beta.Cadence8.Annual,
            "semi_annual" => global::Orb.Models.Beta.Cadence8.SemiAnnual,
            "monthly" => global::Orb.Models.Beta.Cadence8.Monthly,
            "quarterly" => global::Orb.Models.Beta.Cadence8.Quarterly,
            "one_time" => global::Orb.Models.Beta.Cadence8.OneTime,
            "custom" => global::Orb.Models.Beta.Cadence8.Custom,
            _ => (global::Orb.Models.Beta.Cadence8)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.Cadence8 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.Cadence8.Annual => "annual",
                global::Orb.Models.Beta.Cadence8.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.Cadence8.Monthly => "monthly",
                global::Orb.Models.Beta.Cadence8.Quarterly => "quarterly",
                global::Orb.Models.Beta.Cadence8.OneTime => "one_time",
                global::Orb.Models.Beta.Cadence8.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<EventOutputConfigModel>))]
public sealed record class EventOutputConfigModel : ModelBase, IFromRaw<EventOutputConfigModel>
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

    public EventOutputConfigModel() { }

    public EventOutputConfigModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfigModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EventOutputConfigModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public EventOutputConfigModel(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType8
{
    public JsonElement Json { get; private init; }

    public ModelType8()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    ModelType8(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new global::Orb.Models.Beta.ModelType8().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid constant given for 'global::Orb.Models.Beta.ModelType8'"
            );
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Beta.ModelType8>
    {
        public override global::Orb.Models.Beta.ModelType8? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Beta.ModelType8 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Beta.ConversionRateConfig8Converter))]
public record class ConversionRateConfig8
{
    public object Value { get; private init; }

    public ConversionRateConfig8(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig8(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig8(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Beta.ConversionRateConfig8 CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUnit([NotNullWhen(true)] out UnitConversionRateConfig? value)
    {
        value = this.Value as UnitConversionRateConfig;
        return value != null;
    }

    public bool TryPickTiered([NotNullWhen(true)] out TieredConversionRateConfig? value)
    {
        value = this.Value as TieredConversionRateConfig;
        return value != null;
    }

    public void Switch(
        System::Action<UnitConversionRateConfig> unit,
        System::Action<TieredConversionRateConfig> tiered
    )
    {
        switch (this.Value)
        {
            case UnitConversionRateConfig value:
                unit(value);
                break;
            case TieredConversionRateConfig value:
                tiered(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of ConversionRateConfig8"
                );
        }
    }

    public T Match<T>(
        System::Func<UnitConversionRateConfig, T> unit,
        System::Func<TieredConversionRateConfig, T> tiered
    )
    {
        return this.Value switch
        {
            UnitConversionRateConfig value => unit(value),
            TieredConversionRateConfig value => tiered(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig8"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig8(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Beta.ConversionRateConfig8(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig8"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig8Converter
    : JsonConverter<global::Orb.Models.Beta.ConversionRateConfig8>
{
    public override global::Orb.Models.Beta.ConversionRateConfig8? Read(
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UnitConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig8(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'UnitConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tiered":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TieredConversionRateConfig>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Beta.ConversionRateConfig8(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TieredConversionRateConfig'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.ConversionRateConfig8 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
