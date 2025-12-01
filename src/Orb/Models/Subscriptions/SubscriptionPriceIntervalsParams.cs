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

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint is used to add and edit subscription [price intervals](/api-reference/price-interval/add-or-edit-price-intervals).
/// By making modifications to a subscription’s price intervals, you can [flexibly
/// and atomically control the billing behavior of a subscription](/product-catalog/modifying-subscriptions).
///
/// <para>## Adding price intervals</para>
///
/// <para>Prices can be added as price intervals to a subscription by specifying
/// them in the `add` array. A `price_id` or `external_price_id` from an add-on price
/// or previously removed plan price can be specified to reuse an existing price
/// definition (however, please note that prices from other plans cannot be added
/// to the subscription). Additionally, a new price can be specified using the `price`
/// field — this price will be created automatically.</para>
///
/// <para>A `start_date` must be specified for the price interval. This is the date
/// when the price will start billing on the subscription, so this will notably result
/// in an immediate charge at this time for any billed in advance fixed fees. The
/// `end_date` will default to null, resulting in a price interval that will bill
/// on a continually recurring basis. Both of these dates can be set in the past
/// or the future and Orb will generate or modify invoices to ensure the subscription’s
/// invoicing behavior is correct.</para>
///
/// <para>Additionally, a discount, minimum, or maximum can be specified on the price
/// interval. This will only apply to this price interval, not any other price intervals
/// on the subscription.</para>
///
/// <para>## Adjustment intervals</para>
///
/// <para>An adjustment interval represents the time period that a particular adjustment
/// (a discount, minimum, or maximum) applies to the prices on a subscription. Adjustment
/// intervals can be added to a subscription by specifying them in the `add_adjustments`
/// array, or modified via the `edit_adjustments` array. When creating an adjustment
/// interval, you'll need to provide the definition of the new adjustment (the type
/// of adjustment, and which prices it applies to), as well as the start and end
/// dates for the adjustment interval. The start and end dates of an existing adjustment
/// interval can be edited via the `edit_adjustments` field (just like price intervals).
/// (To "change" the amount of a discount, minimum, or maximum, then, you'll need
/// to end the existing interval, and create a new adjustment interval with the new
/// amount and a start date that matches the end date of the previous interval.)</para>
///
/// <para>## Editing price intervals</para>
///
/// <para>Price intervals can be adjusted by specifying edits to make in the `edit`
/// array. A `price_interval_id` to edit must be specified — this can be retrieved
/// from the `price_intervals` field on the subscription.</para>
///
/// <para>A new `start_date` or `end_date` can be specified to change the range of
/// the price interval, which will modify past or future invoices to ensure correctness.
/// If either of these dates are unspecified, they will default to the existing date
/// on the price interval. To remove a price interval entirely from a subscription,
/// set the `end_date` to be equivalent to the `start_date`.</para>
///
/// <para>## Fixed fee quantity transitions The fixed fee quantity transitions for
/// a fixed fee price interval can also be specified when adding or editing by passing
/// an array for `fixed_fee_quantity_transitions`. A fixed fee quantity transition
/// must have a `quantity` and an `effective_date`, which is the date after which
/// the new quantity will be used for billing. If a fixed fee quantity transition
/// is scheduled at a billing period boundary, the full quantity will be billed on
/// an invoice with the other prices on the subscription. If the fixed fee quantity
/// transition is scheduled mid-billing period, the difference between the existing
/// quantity and quantity specified in the transition will be prorated for the rest
/// of the billing period and billed immediately, which will generate a new invoice.</para>
///
/// <para>Notably, the list of fixed fee quantity transitions passed will overwrite
/// the existing fixed fee quantity transitions on the price interval, so the entire
/// list of transitions must be specified to add additional transitions. The existing
/// list of transitions can be retrieved using the `fixed_fee_quantity_transitions`
/// property on a subscription’s serialized price intervals.</para>
/// </summary>
public sealed record class SubscriptionPriceIntervalsParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// A list of price intervals to add to the subscription.
    /// </summary>
    public IReadOnlyList<Add>? Add
    {
        get { return ModelBase.GetNullableClass<List<Add>>(this.RawBodyData, "add"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "add", value);
        }
    }

    /// <summary>
    /// A list of adjustments to add to the subscription.
    /// </summary>
    public IReadOnlyList<AddAdjustmentModel>? AddAdjustments
    {
        get
        {
            return ModelBase.GetNullableClass<List<AddAdjustmentModel>>(
                this.RawBodyData,
                "add_adjustments"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "add_adjustments", value);
        }
    }

    /// <summary>
    /// If false, this request will fail if it would void an issued invoice or create
    /// a credit note. Consider using this as a safety mechanism if you do not expect
    /// existing invoices to be changed.
    /// </summary>
    public bool? AllowInvoiceCreditOrVoid
    {
        get
        {
            return ModelBase.GetNullableStruct<bool>(
                this.RawBodyData,
                "allow_invoice_credit_or_void"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "allow_invoice_credit_or_void", value); }
    }

    /// <summary>
    /// If set, the default value to use for added/edited price intervals with an
    /// end_date set.
    /// </summary>
    public bool? CanDeferBilling
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "can_defer_billing"); }
        init { ModelBase.Set(this._rawBodyData, "can_defer_billing", value); }
    }

    /// <summary>
    /// A list of price intervals to edit on the subscription.
    /// </summary>
    public IReadOnlyList<Edit>? Edit
    {
        get { return ModelBase.GetNullableClass<List<Edit>>(this.RawBodyData, "edit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "edit", value);
        }
    }

    /// <summary>
    /// A list of adjustments to edit on the subscription.
    /// </summary>
    public IReadOnlyList<EditAdjustment>? EditAdjustments
    {
        get
        {
            return ModelBase.GetNullableClass<List<EditAdjustment>>(
                this.RawBodyData,
                "edit_adjustments"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "edit_adjustments", value);
        }
    }

    public SubscriptionPriceIntervalsParams() { }

    public SubscriptionPriceIntervalsParams(
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
    SubscriptionPriceIntervalsParams(
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

    public static SubscriptionPriceIntervalsParams FromRawUnchecked(
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
                + string.Format("/subscriptions/{0}/price_intervals", this.SubscriptionID)
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

[JsonConverter(typeof(ModelConverter<Add, AddFromRaw>))]
public sealed record class Add : ModelBase
{
    /// <summary>
    /// The start date of the price interval. This is the date that the price will
    /// start billing on the subscription.
    /// </summary>
    public required StartDate StartDate
    {
        get { return ModelBase.GetNotNullClass<StartDate>(this.RawData, "start_date"); }
        init { ModelBase.Set(this._rawData, "start_date", value); }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
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
    /// If true, an in-arrears price interval ending mid-cycle will defer billing
    /// the final line item until the next scheduled invoice. If false, it will be
    /// billed on its end date.
    /// </summary>
    public bool? CanDeferBilling
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "can_defer_billing"); }
        init { ModelBase.Set(this._rawData, "can_defer_billing", value); }
    }

    /// <summary>
    /// A list of discounts to initialize on the price interval.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Subscriptions.Discount>? Discounts
    {
        get
        {
            return ModelBase.GetNullableClass<List<global::Orb.Models.Subscriptions.Discount>>(
                this.RawData,
                "discounts"
            );
        }
        init { ModelBase.Set(this._rawData, "discounts", value); }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that the price will stop
    /// billing on the subscription.
    /// </summary>
    public EndDate? EndDate
    {
        get { return ModelBase.GetNullableClass<EndDate>(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { ModelBase.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "filter"); }
        init { ModelBase.Set(this._rawData, "filter", value); }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to initialize on the price interval.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>
            >(this.RawData, "fixed_fee_quantity_transitions");
        }
        init { ModelBase.Set(this._rawData, "fixed_fee_quantity_transitions", value); }
    }

    /// <summary>
    /// The maximum amount that will be billed for this price interval for a given
    /// billing period.
    /// </summary>
    public double? MaximumAmount
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "maximum_amount"); }
        init { ModelBase.Set(this._rawData, "maximum_amount", value); }
    }

    /// <summary>
    /// The minimum amount that will be billed for this price interval for a given
    /// billing period.
    /// </summary>
    public double? MinimumAmount
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "minimum_amount"); }
        init { ModelBase.Set(this._rawData, "minimum_amount", value); }
    }

    /// <summary>
    /// New floating price request body params.
    /// </summary>
    public PriceModel? Price
    {
        get { return ModelBase.GetNullableClass<PriceModel>(this.RawData, "price"); }
        init { ModelBase.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "price_id"); }
        init { ModelBase.Set(this._rawData, "price_id", value); }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this subscription. By default, a subscription only considers usage events
    /// associated with its attached customer's customer_id. When usage_customer_ids
    /// is provided, the subscription includes usage events from the specified customers
    /// only. Provided usage_customer_ids must be either the customer for this subscription
    /// itself, or any of that customer's children.
    /// </summary>
    public IReadOnlyList<string>? UsageCustomerIDs
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "usage_customer_ids"); }
        init { ModelBase.Set(this._rawData, "usage_customer_ids", value); }
    }

    public override void Validate()
    {
        this.StartDate.Validate();
        this.AllocationPrice?.Validate();
        _ = this.CanDeferBilling;
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        this.EndDate?.Validate();
        _ = this.ExternalPriceID;
        _ = this.Filter;
        foreach (var item in this.FixedFeeQuantityTransitions ?? [])
        {
            item.Validate();
        }
        _ = this.MaximumAmount;
        _ = this.MinimumAmount;
        this.Price?.Validate();
        _ = this.PriceID;
        _ = this.UsageCustomerIDs;
    }

    public Add() { }

    public Add(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Add(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Add FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Add(StartDate startDate)
        : this()
    {
        this.StartDate = startDate;
    }
}

class AddFromRaw : IFromRaw<Add>
{
    public Add FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Add.FromRawUnchecked(rawData);
}

/// <summary>
/// The start date of the price interval. This is the date that the price will start
/// billing on the subscription.
/// </summary>
[JsonConverter(typeof(StartDateConverter))]
public record class StartDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public StartDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public StartDate(ApiEnum<string, BillingCycleRelativeDate> value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public StartDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTime,
        System::Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of StartDate");
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTime,
        System::Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of StartDate"),
        };
    }

    public static implicit operator StartDate(System::DateTimeOffset value) => new(value);

    public static implicit operator StartDate(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new(value);

    public static implicit operator StartDate(BillingCycleRelativeDate value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of StartDate");
        }
    }

    public virtual bool Equals(StartDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class StartDateConverter : JsonConverter<StartDate>
{
    public override StartDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        StartDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(DiscountConverter))]
public record class Discount
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Discount(Amount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Discount(Percentage value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Discount(DiscountUsage value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Discount(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickAmount([NotNullWhen(true)] out Amount? value)
    {
        value = this.Value as Amount;
        return value != null;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out Percentage? value)
    {
        value = this.Value as Percentage;
        return value != null;
    }

    public bool TryPickUsage([NotNullWhen(true)] out DiscountUsage? value)
    {
        value = this.Value as DiscountUsage;
        return value != null;
    }

    public void Switch(
        System::Action<Amount> amount,
        System::Action<Percentage> percentage,
        System::Action<DiscountUsage> usage
    )
    {
        switch (this.Value)
        {
            case Amount value:
                amount(value);
                break;
            case Percentage value:
                percentage(value);
                break;
            case DiscountUsage value:
                usage(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
    }

    public T Match<T>(
        System::Func<Amount, T> amount,
        System::Func<Percentage, T> percentage,
        System::Func<DiscountUsage, T> usage
    )
    {
        return this.Value switch
        {
            Amount value => amount(value),
            Percentage value => percentage(value),
            DiscountUsage value => usage(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Discount"),
        };
    }

    public static implicit operator global::Orb.Models.Subscriptions.Discount(Amount value) =>
        new(value);

    public static implicit operator global::Orb.Models.Subscriptions.Discount(Percentage value) =>
        new(value);

    public static implicit operator global::Orb.Models.Subscriptions.Discount(
        DiscountUsage value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
    }

    public virtual bool Equals(global::Orb.Models.Subscriptions.Discount? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class DiscountConverter : JsonConverter<global::Orb.Models.Subscriptions.Discount>
{
    public override global::Orb.Models.Subscriptions.Discount? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? discountType;
        try
        {
            discountType = json.GetProperty("discount_type").GetString();
        }
        catch
        {
            discountType = null;
        }

        switch (discountType)
        {
            case "amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Amount>(json, options);
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
            case "percentage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Percentage>(json, options);
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
            case "usage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DiscountUsage>(json, options);
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
                return new global::Orb.Models.Subscriptions.Discount(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Discount value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Amount, AmountFromRaw>))]
public sealed record class Amount : ModelBase
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required double AmountDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "amount_discount"); }
        init { ModelBase.Set(this._rawData, "amount_discount", value); }
    }

    public global::Orb.Models.Subscriptions.DiscountType DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<global::Orb.Models.Subscriptions.DiscountType>(
                this.RawData,
                "discount_type"
            );
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    public override void Validate()
    {
        _ = this.AmountDiscount;
        this.DiscountType.Validate();
    }

    public Amount()
    {
        this.DiscountType = new();
    }

    public Amount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.DiscountType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Amount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Amount(double amountDiscount)
        : this()
    {
        this.AmountDiscount = amountDiscount;
    }
}

class AmountFromRaw : IFromRaw<Amount>
{
    public Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Amount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(Converter))]
public class DiscountType
{
    public JsonElement Json { get; private init; }

    public DiscountType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"amount\"");
    }

    DiscountType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.DiscountType().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'DiscountType'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.DiscountType>
    {
        public override global::Orb.Models.Subscriptions.DiscountType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.DiscountType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Percentage, PercentageFromRaw>))]
public sealed record class Percentage : ModelBase
{
    public PercentageDiscountType DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<PercentageDiscountType>(this.RawData, "discount_type");
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { ModelBase.Set(this._rawData, "percentage_discount", value); }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
    }

    public Percentage()
    {
        this.DiscountType = new();
    }

    public Percentage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.DiscountType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percentage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Percentage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Percentage(double percentageDiscount)
        : this()
    {
        this.PercentageDiscount = percentageDiscount;
    }
}

class PercentageFromRaw : IFromRaw<Percentage>
{
    public Percentage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Percentage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(Converter))]
public class PercentageDiscountType
{
    public JsonElement Json { get; private init; }

    public PercentageDiscountType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
    }

    PercentageDiscountType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new PercentageDiscountType().Json))
        {
            throw new OrbInvalidDataException("Invalid value given for 'PercentageDiscountType'");
        }
    }

    class Converter : JsonConverter<PercentageDiscountType>
    {
        public override PercentageDiscountType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PercentageDiscountType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<DiscountUsage, DiscountUsageFromRaw>))]
public sealed record class DiscountUsage : ModelBase
{
    public DiscountUsageDiscountType DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<DiscountUsageDiscountType>(
                this.RawData,
                "discount_type"
            );
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for.
    /// </summary>
    public required double UsageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "usage_discount"); }
        init { ModelBase.Set(this._rawData, "usage_discount", value); }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.UsageDiscount;
    }

    public DiscountUsage()
    {
        this.DiscountType = new();
    }

    public DiscountUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.DiscountType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DiscountUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DiscountUsage(double usageDiscount)
        : this()
    {
        this.UsageDiscount = usageDiscount;
    }
}

class DiscountUsageFromRaw : IFromRaw<DiscountUsage>
{
    public DiscountUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DiscountUsage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(Converter))]
public class DiscountUsageDiscountType
{
    public JsonElement Json { get; private init; }

    public DiscountUsageDiscountType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"usage\"");
    }

    DiscountUsageDiscountType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new DiscountUsageDiscountType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'DiscountUsageDiscountType'"
            );
        }
    }

    class Converter : JsonConverter<DiscountUsageDiscountType>
    {
        public override DiscountUsageDiscountType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            DiscountUsageDiscountType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// The end date of the price interval. This is the date that the price will stop
/// billing on the subscription.
/// </summary>
[JsonConverter(typeof(EndDateConverter))]
public record class EndDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EndDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public EndDate(ApiEnum<string, BillingCycleRelativeDate> value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public EndDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTime,
        System::Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of EndDate");
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTime,
        System::Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of EndDate"),
        };
    }

    public static implicit operator EndDate(System::DateTimeOffset value) => new(value);

    public static implicit operator EndDate(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new(value);

    public static implicit operator EndDate(BillingCycleRelativeDate value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EndDate");
        }
    }

    public virtual bool Equals(EndDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class EndDateConverter : JsonConverter<EndDate?>
{
    public override EndDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, EndDate? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.FixedFeeQuantityTransition,
        global::Orb.Models.Subscriptions.FixedFeeQuantityTransitionFromRaw
    >)
)]
public sealed record class FixedFeeQuantityTransition : ModelBase
{
    /// <summary>
    /// The date that the fixed fee quantity transition should take effect.
    /// </summary>
    public required System::DateTimeOffset EffectiveDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "effective_date"
            );
        }
        init { ModelBase.Set(this._rawData, "effective_date", value); }
    }

    /// <summary>
    /// The quantity of the fixed fee quantity transition.
    /// </summary>
    public required long Quantity
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
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

    public static global::Orb.Models.Subscriptions.FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FixedFeeQuantityTransitionFromRaw
    : IFromRaw<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>
{
    public global::Orb.Models.Subscriptions.FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.FixedFeeQuantityTransition.FromRawUnchecked(rawData);
}

/// <summary>
/// New floating price request body params.
/// </summary>
[JsonConverter(typeof(PriceModelConverter))]
public record class PriceModel
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string Currency
    {
        get
        {
            return Match(
                newFloatingUnit: (x) => x.Currency,
                newFloatingTiered: (x) => x.Currency,
                newFloatingBulk: (x) => x.Currency,
                bulkWithFilters: (x) => x.Currency,
                newFloatingPackage: (x) => x.Currency,
                newFloatingMatrix: (x) => x.Currency,
                newFloatingThresholdTotalAmount: (x) => x.Currency,
                newFloatingTieredPackage: (x) => x.Currency,
                newFloatingTieredWithMinimum: (x) => x.Currency,
                newFloatingGroupedTiered: (x) => x.Currency,
                newFloatingTieredPackageWithMinimum: (x) => x.Currency,
                newFloatingPackageWithAllocation: (x) => x.Currency,
                newFloatingUnitWithPercent: (x) => x.Currency,
                newFloatingMatrixWithAllocation: (x) => x.Currency,
                newFloatingTieredWithProration: (x) => x.Currency,
                newFloatingUnitWithProration: (x) => x.Currency,
                newFloatingGroupedAllocation: (x) => x.Currency,
                newFloatingBulkWithProration: (x) => x.Currency,
                newFloatingGroupedWithProratedMinimum: (x) => x.Currency,
                newFloatingGroupedWithMeteredMinimum: (x) => x.Currency,
                groupedWithMinMaxThresholds: (x) => x.Currency,
                newFloatingMatrixWithDisplayName: (x) => x.Currency,
                newFloatingGroupedTieredPackage: (x) => x.Currency,
                newFloatingMaxGroupTieredPackage: (x) => x.Currency,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.Currency,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.Currency,
                newFloatingCumulativeGroupedBulk: (x) => x.Currency,
                cumulativeGroupedAllocation: (x) => x.Currency,
                newFloatingMinimumComposite: (x) => x.Currency,
                percent: (x) => x.Currency,
                eventOutput: (x) => x.Currency
            );
        }
    }

    public string ItemID
    {
        get
        {
            return Match(
                newFloatingUnit: (x) => x.ItemID,
                newFloatingTiered: (x) => x.ItemID,
                newFloatingBulk: (x) => x.ItemID,
                bulkWithFilters: (x) => x.ItemID,
                newFloatingPackage: (x) => x.ItemID,
                newFloatingMatrix: (x) => x.ItemID,
                newFloatingThresholdTotalAmount: (x) => x.ItemID,
                newFloatingTieredPackage: (x) => x.ItemID,
                newFloatingTieredWithMinimum: (x) => x.ItemID,
                newFloatingGroupedTiered: (x) => x.ItemID,
                newFloatingTieredPackageWithMinimum: (x) => x.ItemID,
                newFloatingPackageWithAllocation: (x) => x.ItemID,
                newFloatingUnitWithPercent: (x) => x.ItemID,
                newFloatingMatrixWithAllocation: (x) => x.ItemID,
                newFloatingTieredWithProration: (x) => x.ItemID,
                newFloatingUnitWithProration: (x) => x.ItemID,
                newFloatingGroupedAllocation: (x) => x.ItemID,
                newFloatingBulkWithProration: (x) => x.ItemID,
                newFloatingGroupedWithProratedMinimum: (x) => x.ItemID,
                newFloatingGroupedWithMeteredMinimum: (x) => x.ItemID,
                groupedWithMinMaxThresholds: (x) => x.ItemID,
                newFloatingMatrixWithDisplayName: (x) => x.ItemID,
                newFloatingGroupedTieredPackage: (x) => x.ItemID,
                newFloatingMaxGroupTieredPackage: (x) => x.ItemID,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.ItemID,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.ItemID,
                newFloatingCumulativeGroupedBulk: (x) => x.ItemID,
                cumulativeGroupedAllocation: (x) => x.ItemID,
                newFloatingMinimumComposite: (x) => x.ItemID,
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
                newFloatingUnit: (x) => x.Name,
                newFloatingTiered: (x) => x.Name,
                newFloatingBulk: (x) => x.Name,
                bulkWithFilters: (x) => x.Name,
                newFloatingPackage: (x) => x.Name,
                newFloatingMatrix: (x) => x.Name,
                newFloatingThresholdTotalAmount: (x) => x.Name,
                newFloatingTieredPackage: (x) => x.Name,
                newFloatingTieredWithMinimum: (x) => x.Name,
                newFloatingGroupedTiered: (x) => x.Name,
                newFloatingTieredPackageWithMinimum: (x) => x.Name,
                newFloatingPackageWithAllocation: (x) => x.Name,
                newFloatingUnitWithPercent: (x) => x.Name,
                newFloatingMatrixWithAllocation: (x) => x.Name,
                newFloatingTieredWithProration: (x) => x.Name,
                newFloatingUnitWithProration: (x) => x.Name,
                newFloatingGroupedAllocation: (x) => x.Name,
                newFloatingBulkWithProration: (x) => x.Name,
                newFloatingGroupedWithProratedMinimum: (x) => x.Name,
                newFloatingGroupedWithMeteredMinimum: (x) => x.Name,
                groupedWithMinMaxThresholds: (x) => x.Name,
                newFloatingMatrixWithDisplayName: (x) => x.Name,
                newFloatingGroupedTieredPackage: (x) => x.Name,
                newFloatingMaxGroupTieredPackage: (x) => x.Name,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.Name,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.Name,
                newFloatingCumulativeGroupedBulk: (x) => x.Name,
                cumulativeGroupedAllocation: (x) => x.Name,
                newFloatingMinimumComposite: (x) => x.Name,
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
                newFloatingUnit: (x) => x.BillableMetricID,
                newFloatingTiered: (x) => x.BillableMetricID,
                newFloatingBulk: (x) => x.BillableMetricID,
                bulkWithFilters: (x) => x.BillableMetricID,
                newFloatingPackage: (x) => x.BillableMetricID,
                newFloatingMatrix: (x) => x.BillableMetricID,
                newFloatingThresholdTotalAmount: (x) => x.BillableMetricID,
                newFloatingTieredPackage: (x) => x.BillableMetricID,
                newFloatingTieredWithMinimum: (x) => x.BillableMetricID,
                newFloatingGroupedTiered: (x) => x.BillableMetricID,
                newFloatingTieredPackageWithMinimum: (x) => x.BillableMetricID,
                newFloatingPackageWithAllocation: (x) => x.BillableMetricID,
                newFloatingUnitWithPercent: (x) => x.BillableMetricID,
                newFloatingMatrixWithAllocation: (x) => x.BillableMetricID,
                newFloatingTieredWithProration: (x) => x.BillableMetricID,
                newFloatingUnitWithProration: (x) => x.BillableMetricID,
                newFloatingGroupedAllocation: (x) => x.BillableMetricID,
                newFloatingBulkWithProration: (x) => x.BillableMetricID,
                newFloatingGroupedWithProratedMinimum: (x) => x.BillableMetricID,
                newFloatingGroupedWithMeteredMinimum: (x) => x.BillableMetricID,
                groupedWithMinMaxThresholds: (x) => x.BillableMetricID,
                newFloatingMatrixWithDisplayName: (x) => x.BillableMetricID,
                newFloatingGroupedTieredPackage: (x) => x.BillableMetricID,
                newFloatingMaxGroupTieredPackage: (x) => x.BillableMetricID,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.BillableMetricID,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.BillableMetricID,
                newFloatingCumulativeGroupedBulk: (x) => x.BillableMetricID,
                cumulativeGroupedAllocation: (x) => x.BillableMetricID,
                newFloatingMinimumComposite: (x) => x.BillableMetricID,
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
                newFloatingUnit: (x) => x.BilledInAdvance,
                newFloatingTiered: (x) => x.BilledInAdvance,
                newFloatingBulk: (x) => x.BilledInAdvance,
                bulkWithFilters: (x) => x.BilledInAdvance,
                newFloatingPackage: (x) => x.BilledInAdvance,
                newFloatingMatrix: (x) => x.BilledInAdvance,
                newFloatingThresholdTotalAmount: (x) => x.BilledInAdvance,
                newFloatingTieredPackage: (x) => x.BilledInAdvance,
                newFloatingTieredWithMinimum: (x) => x.BilledInAdvance,
                newFloatingGroupedTiered: (x) => x.BilledInAdvance,
                newFloatingTieredPackageWithMinimum: (x) => x.BilledInAdvance,
                newFloatingPackageWithAllocation: (x) => x.BilledInAdvance,
                newFloatingUnitWithPercent: (x) => x.BilledInAdvance,
                newFloatingMatrixWithAllocation: (x) => x.BilledInAdvance,
                newFloatingTieredWithProration: (x) => x.BilledInAdvance,
                newFloatingUnitWithProration: (x) => x.BilledInAdvance,
                newFloatingGroupedAllocation: (x) => x.BilledInAdvance,
                newFloatingBulkWithProration: (x) => x.BilledInAdvance,
                newFloatingGroupedWithProratedMinimum: (x) => x.BilledInAdvance,
                newFloatingGroupedWithMeteredMinimum: (x) => x.BilledInAdvance,
                groupedWithMinMaxThresholds: (x) => x.BilledInAdvance,
                newFloatingMatrixWithDisplayName: (x) => x.BilledInAdvance,
                newFloatingGroupedTieredPackage: (x) => x.BilledInAdvance,
                newFloatingMaxGroupTieredPackage: (x) => x.BilledInAdvance,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.BilledInAdvance,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.BilledInAdvance,
                newFloatingCumulativeGroupedBulk: (x) => x.BilledInAdvance,
                cumulativeGroupedAllocation: (x) => x.BilledInAdvance,
                newFloatingMinimumComposite: (x) => x.BilledInAdvance,
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
                newFloatingUnit: (x) => x.BillingCycleConfiguration,
                newFloatingTiered: (x) => x.BillingCycleConfiguration,
                newFloatingBulk: (x) => x.BillingCycleConfiguration,
                bulkWithFilters: (x) => x.BillingCycleConfiguration,
                newFloatingPackage: (x) => x.BillingCycleConfiguration,
                newFloatingMatrix: (x) => x.BillingCycleConfiguration,
                newFloatingThresholdTotalAmount: (x) => x.BillingCycleConfiguration,
                newFloatingTieredPackage: (x) => x.BillingCycleConfiguration,
                newFloatingTieredWithMinimum: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedTiered: (x) => x.BillingCycleConfiguration,
                newFloatingTieredPackageWithMinimum: (x) => x.BillingCycleConfiguration,
                newFloatingPackageWithAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingUnitWithPercent: (x) => x.BillingCycleConfiguration,
                newFloatingMatrixWithAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingTieredWithProration: (x) => x.BillingCycleConfiguration,
                newFloatingUnitWithProration: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingBulkWithProration: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedWithProratedMinimum: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedWithMeteredMinimum: (x) => x.BillingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.BillingCycleConfiguration,
                newFloatingMatrixWithDisplayName: (x) => x.BillingCycleConfiguration,
                newFloatingGroupedTieredPackage: (x) => x.BillingCycleConfiguration,
                newFloatingMaxGroupTieredPackage: (x) => x.BillingCycleConfiguration,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.BillingCycleConfiguration,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.BillingCycleConfiguration,
                newFloatingCumulativeGroupedBulk: (x) => x.BillingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.BillingCycleConfiguration,
                newFloatingMinimumComposite: (x) => x.BillingCycleConfiguration,
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
                newFloatingUnit: (x) => x.ConversionRate,
                newFloatingTiered: (x) => x.ConversionRate,
                newFloatingBulk: (x) => x.ConversionRate,
                bulkWithFilters: (x) => x.ConversionRate,
                newFloatingPackage: (x) => x.ConversionRate,
                newFloatingMatrix: (x) => x.ConversionRate,
                newFloatingThresholdTotalAmount: (x) => x.ConversionRate,
                newFloatingTieredPackage: (x) => x.ConversionRate,
                newFloatingTieredWithMinimum: (x) => x.ConversionRate,
                newFloatingGroupedTiered: (x) => x.ConversionRate,
                newFloatingTieredPackageWithMinimum: (x) => x.ConversionRate,
                newFloatingPackageWithAllocation: (x) => x.ConversionRate,
                newFloatingUnitWithPercent: (x) => x.ConversionRate,
                newFloatingMatrixWithAllocation: (x) => x.ConversionRate,
                newFloatingTieredWithProration: (x) => x.ConversionRate,
                newFloatingUnitWithProration: (x) => x.ConversionRate,
                newFloatingGroupedAllocation: (x) => x.ConversionRate,
                newFloatingBulkWithProration: (x) => x.ConversionRate,
                newFloatingGroupedWithProratedMinimum: (x) => x.ConversionRate,
                newFloatingGroupedWithMeteredMinimum: (x) => x.ConversionRate,
                groupedWithMinMaxThresholds: (x) => x.ConversionRate,
                newFloatingMatrixWithDisplayName: (x) => x.ConversionRate,
                newFloatingGroupedTieredPackage: (x) => x.ConversionRate,
                newFloatingMaxGroupTieredPackage: (x) => x.ConversionRate,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.ConversionRate,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.ConversionRate,
                newFloatingCumulativeGroupedBulk: (x) => x.ConversionRate,
                cumulativeGroupedAllocation: (x) => x.ConversionRate,
                newFloatingMinimumComposite: (x) => x.ConversionRate,
                percent: (x) => x.ConversionRate,
                eventOutput: (x) => x.ConversionRate
            );
        }
    }

    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return Match<NewDimensionalPriceConfiguration?>(
                newFloatingUnit: (x) => x.DimensionalPriceConfiguration,
                newFloatingTiered: (x) => x.DimensionalPriceConfiguration,
                newFloatingBulk: (x) => x.DimensionalPriceConfiguration,
                bulkWithFilters: (x) => x.DimensionalPriceConfiguration,
                newFloatingPackage: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrix: (x) => x.DimensionalPriceConfiguration,
                newFloatingThresholdTotalAmount: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedTiered: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredPackageWithMinimum: (x) => x.DimensionalPriceConfiguration,
                newFloatingPackageWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingUnitWithPercent: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrixWithAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingTieredWithProration: (x) => x.DimensionalPriceConfiguration,
                newFloatingUnitWithProration: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingBulkWithProration: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedWithProratedMinimum: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedWithMeteredMinimum: (x) => x.DimensionalPriceConfiguration,
                groupedWithMinMaxThresholds: (x) => x.DimensionalPriceConfiguration,
                newFloatingMatrixWithDisplayName: (x) => x.DimensionalPriceConfiguration,
                newFloatingGroupedTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newFloatingMaxGroupTieredPackage: (x) => x.DimensionalPriceConfiguration,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.DimensionalPriceConfiguration,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.DimensionalPriceConfiguration,
                newFloatingCumulativeGroupedBulk: (x) => x.DimensionalPriceConfiguration,
                cumulativeGroupedAllocation: (x) => x.DimensionalPriceConfiguration,
                newFloatingMinimumComposite: (x) => x.DimensionalPriceConfiguration,
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
                newFloatingUnit: (x) => x.ExternalPriceID,
                newFloatingTiered: (x) => x.ExternalPriceID,
                newFloatingBulk: (x) => x.ExternalPriceID,
                bulkWithFilters: (x) => x.ExternalPriceID,
                newFloatingPackage: (x) => x.ExternalPriceID,
                newFloatingMatrix: (x) => x.ExternalPriceID,
                newFloatingThresholdTotalAmount: (x) => x.ExternalPriceID,
                newFloatingTieredPackage: (x) => x.ExternalPriceID,
                newFloatingTieredWithMinimum: (x) => x.ExternalPriceID,
                newFloatingGroupedTiered: (x) => x.ExternalPriceID,
                newFloatingTieredPackageWithMinimum: (x) => x.ExternalPriceID,
                newFloatingPackageWithAllocation: (x) => x.ExternalPriceID,
                newFloatingUnitWithPercent: (x) => x.ExternalPriceID,
                newFloatingMatrixWithAllocation: (x) => x.ExternalPriceID,
                newFloatingTieredWithProration: (x) => x.ExternalPriceID,
                newFloatingUnitWithProration: (x) => x.ExternalPriceID,
                newFloatingGroupedAllocation: (x) => x.ExternalPriceID,
                newFloatingBulkWithProration: (x) => x.ExternalPriceID,
                newFloatingGroupedWithProratedMinimum: (x) => x.ExternalPriceID,
                newFloatingGroupedWithMeteredMinimum: (x) => x.ExternalPriceID,
                groupedWithMinMaxThresholds: (x) => x.ExternalPriceID,
                newFloatingMatrixWithDisplayName: (x) => x.ExternalPriceID,
                newFloatingGroupedTieredPackage: (x) => x.ExternalPriceID,
                newFloatingMaxGroupTieredPackage: (x) => x.ExternalPriceID,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.ExternalPriceID,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.ExternalPriceID,
                newFloatingCumulativeGroupedBulk: (x) => x.ExternalPriceID,
                cumulativeGroupedAllocation: (x) => x.ExternalPriceID,
                newFloatingMinimumComposite: (x) => x.ExternalPriceID,
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
                newFloatingUnit: (x) => x.FixedPriceQuantity,
                newFloatingTiered: (x) => x.FixedPriceQuantity,
                newFloatingBulk: (x) => x.FixedPriceQuantity,
                bulkWithFilters: (x) => x.FixedPriceQuantity,
                newFloatingPackage: (x) => x.FixedPriceQuantity,
                newFloatingMatrix: (x) => x.FixedPriceQuantity,
                newFloatingThresholdTotalAmount: (x) => x.FixedPriceQuantity,
                newFloatingTieredPackage: (x) => x.FixedPriceQuantity,
                newFloatingTieredWithMinimum: (x) => x.FixedPriceQuantity,
                newFloatingGroupedTiered: (x) => x.FixedPriceQuantity,
                newFloatingTieredPackageWithMinimum: (x) => x.FixedPriceQuantity,
                newFloatingPackageWithAllocation: (x) => x.FixedPriceQuantity,
                newFloatingUnitWithPercent: (x) => x.FixedPriceQuantity,
                newFloatingMatrixWithAllocation: (x) => x.FixedPriceQuantity,
                newFloatingTieredWithProration: (x) => x.FixedPriceQuantity,
                newFloatingUnitWithProration: (x) => x.FixedPriceQuantity,
                newFloatingGroupedAllocation: (x) => x.FixedPriceQuantity,
                newFloatingBulkWithProration: (x) => x.FixedPriceQuantity,
                newFloatingGroupedWithProratedMinimum: (x) => x.FixedPriceQuantity,
                newFloatingGroupedWithMeteredMinimum: (x) => x.FixedPriceQuantity,
                groupedWithMinMaxThresholds: (x) => x.FixedPriceQuantity,
                newFloatingMatrixWithDisplayName: (x) => x.FixedPriceQuantity,
                newFloatingGroupedTieredPackage: (x) => x.FixedPriceQuantity,
                newFloatingMaxGroupTieredPackage: (x) => x.FixedPriceQuantity,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.FixedPriceQuantity,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.FixedPriceQuantity,
                newFloatingCumulativeGroupedBulk: (x) => x.FixedPriceQuantity,
                cumulativeGroupedAllocation: (x) => x.FixedPriceQuantity,
                newFloatingMinimumComposite: (x) => x.FixedPriceQuantity,
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
                newFloatingUnit: (x) => x.InvoiceGroupingKey,
                newFloatingTiered: (x) => x.InvoiceGroupingKey,
                newFloatingBulk: (x) => x.InvoiceGroupingKey,
                bulkWithFilters: (x) => x.InvoiceGroupingKey,
                newFloatingPackage: (x) => x.InvoiceGroupingKey,
                newFloatingMatrix: (x) => x.InvoiceGroupingKey,
                newFloatingThresholdTotalAmount: (x) => x.InvoiceGroupingKey,
                newFloatingTieredPackage: (x) => x.InvoiceGroupingKey,
                newFloatingTieredWithMinimum: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedTiered: (x) => x.InvoiceGroupingKey,
                newFloatingTieredPackageWithMinimum: (x) => x.InvoiceGroupingKey,
                newFloatingPackageWithAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingUnitWithPercent: (x) => x.InvoiceGroupingKey,
                newFloatingMatrixWithAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingTieredWithProration: (x) => x.InvoiceGroupingKey,
                newFloatingUnitWithProration: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingBulkWithProration: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedWithProratedMinimum: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedWithMeteredMinimum: (x) => x.InvoiceGroupingKey,
                groupedWithMinMaxThresholds: (x) => x.InvoiceGroupingKey,
                newFloatingMatrixWithDisplayName: (x) => x.InvoiceGroupingKey,
                newFloatingGroupedTieredPackage: (x) => x.InvoiceGroupingKey,
                newFloatingMaxGroupTieredPackage: (x) => x.InvoiceGroupingKey,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.InvoiceGroupingKey,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.InvoiceGroupingKey,
                newFloatingCumulativeGroupedBulk: (x) => x.InvoiceGroupingKey,
                cumulativeGroupedAllocation: (x) => x.InvoiceGroupingKey,
                newFloatingMinimumComposite: (x) => x.InvoiceGroupingKey,
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
                newFloatingUnit: (x) => x.InvoicingCycleConfiguration,
                newFloatingTiered: (x) => x.InvoicingCycleConfiguration,
                newFloatingBulk: (x) => x.InvoicingCycleConfiguration,
                bulkWithFilters: (x) => x.InvoicingCycleConfiguration,
                newFloatingPackage: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrix: (x) => x.InvoicingCycleConfiguration,
                newFloatingThresholdTotalAmount: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedTiered: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredPackageWithMinimum: (x) => x.InvoicingCycleConfiguration,
                newFloatingPackageWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingUnitWithPercent: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrixWithAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingTieredWithProration: (x) => x.InvoicingCycleConfiguration,
                newFloatingUnitWithProration: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingBulkWithProration: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedWithProratedMinimum: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedWithMeteredMinimum: (x) => x.InvoicingCycleConfiguration,
                groupedWithMinMaxThresholds: (x) => x.InvoicingCycleConfiguration,
                newFloatingMatrixWithDisplayName: (x) => x.InvoicingCycleConfiguration,
                newFloatingGroupedTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newFloatingMaxGroupTieredPackage: (x) => x.InvoicingCycleConfiguration,
                newFloatingScalableMatrixWithUnitPricing: (x) => x.InvoicingCycleConfiguration,
                newFloatingScalableMatrixWithTieredPricing: (x) => x.InvoicingCycleConfiguration,
                newFloatingCumulativeGroupedBulk: (x) => x.InvoicingCycleConfiguration,
                cumulativeGroupedAllocation: (x) => x.InvoicingCycleConfiguration,
                newFloatingMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public PriceModel(NewFloatingUnitPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(PriceModelBulkWithFilters value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingMatrixPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingThresholdTotalAmountPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingTieredWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingGroupedTieredPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingTieredPackageWithMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingPackageWithAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingUnitWithPercentPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingMatrixWithAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingTieredWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingUnitWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingGroupedAllocationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingBulkWithProrationPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingGroupedWithProratedMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingGroupedWithMeteredMinimumPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(PriceModelGroupedWithMinMaxThresholds value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingMatrixWithDisplayNamePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingGroupedTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingMaxGroupTieredPackagePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingScalableMatrixWithUnitPricingPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(
        NewFloatingScalableMatrixWithTieredPricingPrice value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingCumulativeGroupedBulkPrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(PriceModelCumulativeGroupedAllocation value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(NewFloatingMinimumCompositePrice value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(PriceModelPercent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(PriceModelEventOutput value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModel(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewFloatingUnit([NotNullWhen(true)] out NewFloatingUnitPrice? value)
    {
        value = this.Value as NewFloatingUnitPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTiered([NotNullWhen(true)] out NewFloatingTieredPrice? value)
    {
        value = this.Value as NewFloatingTieredPrice;
        return value != null;
    }

    public bool TryPickNewFloatingBulk([NotNullWhen(true)] out NewFloatingBulkPrice? value)
    {
        value = this.Value as NewFloatingBulkPrice;
        return value != null;
    }

    public bool TryPickBulkWithFilters([NotNullWhen(true)] out PriceModelBulkWithFilters? value)
    {
        value = this.Value as PriceModelBulkWithFilters;
        return value != null;
    }

    public bool TryPickNewFloatingPackage([NotNullWhen(true)] out NewFloatingPackagePrice? value)
    {
        value = this.Value as NewFloatingPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingMatrix([NotNullWhen(true)] out NewFloatingMatrixPrice? value)
    {
        value = this.Value as NewFloatingMatrixPrice;
        return value != null;
    }

    public bool TryPickNewFloatingThresholdTotalAmount(
        [NotNullWhen(true)] out NewFloatingThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewFloatingThresholdTotalAmountPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackage(
        [NotNullWhen(true)] out NewFloatingTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithMinimum(
        [NotNullWhen(true)] out NewFloatingTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTiered(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewFloatingTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackageWithMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingPackageWithAllocation(
        [NotNullWhen(true)] out NewFloatingPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingPackageWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithPercent(
        [NotNullWhen(true)] out NewFloatingUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithPercentPrice;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithAllocation(
        [NotNullWhen(true)] out NewFloatingMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingTieredWithProration(
        [NotNullWhen(true)] out NewFloatingTieredWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingUnitWithProration(
        [NotNullWhen(true)] out NewFloatingUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedAllocation(
        [NotNullWhen(true)] out NewFloatingGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedAllocationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingBulkWithProration(
        [NotNullWhen(true)] out NewFloatingBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingBulkWithProrationPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewFloatingGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithProratedMinimumPrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewFloatingGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out PriceModelGroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as PriceModelGroupedWithMinMaxThresholds;
        return value != null;
    }

    public bool TryPickNewFloatingMatrixWithDisplayName(
        [NotNullWhen(true)] out NewFloatingMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithDisplayNamePrice;
        return value != null;
    }

    public bool TryPickNewFloatingGroupedTieredPackage(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewFloatingMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingMaxGroupTieredPackagePrice;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    public bool TryPickNewFloatingScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    public bool TryPickNewFloatingCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewFloatingCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewFloatingCumulativeGroupedBulkPrice;
        return value != null;
    }

    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out PriceModelCumulativeGroupedAllocation? value
    )
    {
        value = this.Value as PriceModelCumulativeGroupedAllocation;
        return value != null;
    }

    public bool TryPickNewFloatingMinimumComposite(
        [NotNullWhen(true)] out NewFloatingMinimumCompositePrice? value
    )
    {
        value = this.Value as NewFloatingMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out PriceModelPercent? value)
    {
        value = this.Value as PriceModelPercent;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out PriceModelEventOutput? value)
    {
        value = this.Value as PriceModelEventOutput;
        return value != null;
    }

    public void Switch(
        System::Action<NewFloatingUnitPrice> newFloatingUnit,
        System::Action<NewFloatingTieredPrice> newFloatingTiered,
        System::Action<NewFloatingBulkPrice> newFloatingBulk,
        System::Action<PriceModelBulkWithFilters> bulkWithFilters,
        System::Action<NewFloatingPackagePrice> newFloatingPackage,
        System::Action<NewFloatingMatrixPrice> newFloatingMatrix,
        System::Action<NewFloatingThresholdTotalAmountPrice> newFloatingThresholdTotalAmount,
        System::Action<NewFloatingTieredPackagePrice> newFloatingTieredPackage,
        System::Action<NewFloatingTieredWithMinimumPrice> newFloatingTieredWithMinimum,
        System::Action<NewFloatingGroupedTieredPrice> newFloatingGroupedTiered,
        System::Action<NewFloatingTieredPackageWithMinimumPrice> newFloatingTieredPackageWithMinimum,
        System::Action<NewFloatingPackageWithAllocationPrice> newFloatingPackageWithAllocation,
        System::Action<NewFloatingUnitWithPercentPrice> newFloatingUnitWithPercent,
        System::Action<NewFloatingMatrixWithAllocationPrice> newFloatingMatrixWithAllocation,
        System::Action<NewFloatingTieredWithProrationPrice> newFloatingTieredWithProration,
        System::Action<NewFloatingUnitWithProrationPrice> newFloatingUnitWithProration,
        System::Action<NewFloatingGroupedAllocationPrice> newFloatingGroupedAllocation,
        System::Action<NewFloatingBulkWithProrationPrice> newFloatingBulkWithProration,
        System::Action<NewFloatingGroupedWithProratedMinimumPrice> newFloatingGroupedWithProratedMinimum,
        System::Action<NewFloatingGroupedWithMeteredMinimumPrice> newFloatingGroupedWithMeteredMinimum,
        System::Action<PriceModelGroupedWithMinMaxThresholds> groupedWithMinMaxThresholds,
        System::Action<NewFloatingMatrixWithDisplayNamePrice> newFloatingMatrixWithDisplayName,
        System::Action<NewFloatingGroupedTieredPackagePrice> newFloatingGroupedTieredPackage,
        System::Action<NewFloatingMaxGroupTieredPackagePrice> newFloatingMaxGroupTieredPackage,
        System::Action<NewFloatingScalableMatrixWithUnitPricingPrice> newFloatingScalableMatrixWithUnitPricing,
        System::Action<NewFloatingScalableMatrixWithTieredPricingPrice> newFloatingScalableMatrixWithTieredPricing,
        System::Action<NewFloatingCumulativeGroupedBulkPrice> newFloatingCumulativeGroupedBulk,
        System::Action<PriceModelCumulativeGroupedAllocation> cumulativeGroupedAllocation,
        System::Action<NewFloatingMinimumCompositePrice> newFloatingMinimumComposite,
        System::Action<PriceModelPercent> percent,
        System::Action<PriceModelEventOutput> eventOutput
    )
    {
        switch (this.Value)
        {
            case NewFloatingUnitPrice value:
                newFloatingUnit(value);
                break;
            case NewFloatingTieredPrice value:
                newFloatingTiered(value);
                break;
            case NewFloatingBulkPrice value:
                newFloatingBulk(value);
                break;
            case PriceModelBulkWithFilters value:
                bulkWithFilters(value);
                break;
            case NewFloatingPackagePrice value:
                newFloatingPackage(value);
                break;
            case NewFloatingMatrixPrice value:
                newFloatingMatrix(value);
                break;
            case NewFloatingThresholdTotalAmountPrice value:
                newFloatingThresholdTotalAmount(value);
                break;
            case NewFloatingTieredPackagePrice value:
                newFloatingTieredPackage(value);
                break;
            case NewFloatingTieredWithMinimumPrice value:
                newFloatingTieredWithMinimum(value);
                break;
            case NewFloatingGroupedTieredPrice value:
                newFloatingGroupedTiered(value);
                break;
            case NewFloatingTieredPackageWithMinimumPrice value:
                newFloatingTieredPackageWithMinimum(value);
                break;
            case NewFloatingPackageWithAllocationPrice value:
                newFloatingPackageWithAllocation(value);
                break;
            case NewFloatingUnitWithPercentPrice value:
                newFloatingUnitWithPercent(value);
                break;
            case NewFloatingMatrixWithAllocationPrice value:
                newFloatingMatrixWithAllocation(value);
                break;
            case NewFloatingTieredWithProrationPrice value:
                newFloatingTieredWithProration(value);
                break;
            case NewFloatingUnitWithProrationPrice value:
                newFloatingUnitWithProration(value);
                break;
            case NewFloatingGroupedAllocationPrice value:
                newFloatingGroupedAllocation(value);
                break;
            case NewFloatingBulkWithProrationPrice value:
                newFloatingBulkWithProration(value);
                break;
            case NewFloatingGroupedWithProratedMinimumPrice value:
                newFloatingGroupedWithProratedMinimum(value);
                break;
            case NewFloatingGroupedWithMeteredMinimumPrice value:
                newFloatingGroupedWithMeteredMinimum(value);
                break;
            case PriceModelGroupedWithMinMaxThresholds value:
                groupedWithMinMaxThresholds(value);
                break;
            case NewFloatingMatrixWithDisplayNamePrice value:
                newFloatingMatrixWithDisplayName(value);
                break;
            case NewFloatingGroupedTieredPackagePrice value:
                newFloatingGroupedTieredPackage(value);
                break;
            case NewFloatingMaxGroupTieredPackagePrice value:
                newFloatingMaxGroupTieredPackage(value);
                break;
            case NewFloatingScalableMatrixWithUnitPricingPrice value:
                newFloatingScalableMatrixWithUnitPricing(value);
                break;
            case NewFloatingScalableMatrixWithTieredPricingPrice value:
                newFloatingScalableMatrixWithTieredPricing(value);
                break;
            case NewFloatingCumulativeGroupedBulkPrice value:
                newFloatingCumulativeGroupedBulk(value);
                break;
            case PriceModelCumulativeGroupedAllocation value:
                cumulativeGroupedAllocation(value);
                break;
            case NewFloatingMinimumCompositePrice value:
                newFloatingMinimumComposite(value);
                break;
            case PriceModelPercent value:
                percent(value);
                break;
            case PriceModelEventOutput value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of PriceModel");
        }
    }

    public T Match<T>(
        System::Func<NewFloatingUnitPrice, T> newFloatingUnit,
        System::Func<NewFloatingTieredPrice, T> newFloatingTiered,
        System::Func<NewFloatingBulkPrice, T> newFloatingBulk,
        System::Func<PriceModelBulkWithFilters, T> bulkWithFilters,
        System::Func<NewFloatingPackagePrice, T> newFloatingPackage,
        System::Func<NewFloatingMatrixPrice, T> newFloatingMatrix,
        System::Func<NewFloatingThresholdTotalAmountPrice, T> newFloatingThresholdTotalAmount,
        System::Func<NewFloatingTieredPackagePrice, T> newFloatingTieredPackage,
        System::Func<NewFloatingTieredWithMinimumPrice, T> newFloatingTieredWithMinimum,
        System::Func<NewFloatingGroupedTieredPrice, T> newFloatingGroupedTiered,
        System::Func<
            NewFloatingTieredPackageWithMinimumPrice,
            T
        > newFloatingTieredPackageWithMinimum,
        System::Func<NewFloatingPackageWithAllocationPrice, T> newFloatingPackageWithAllocation,
        System::Func<NewFloatingUnitWithPercentPrice, T> newFloatingUnitWithPercent,
        System::Func<NewFloatingMatrixWithAllocationPrice, T> newFloatingMatrixWithAllocation,
        System::Func<NewFloatingTieredWithProrationPrice, T> newFloatingTieredWithProration,
        System::Func<NewFloatingUnitWithProrationPrice, T> newFloatingUnitWithProration,
        System::Func<NewFloatingGroupedAllocationPrice, T> newFloatingGroupedAllocation,
        System::Func<NewFloatingBulkWithProrationPrice, T> newFloatingBulkWithProration,
        System::Func<
            NewFloatingGroupedWithProratedMinimumPrice,
            T
        > newFloatingGroupedWithProratedMinimum,
        System::Func<
            NewFloatingGroupedWithMeteredMinimumPrice,
            T
        > newFloatingGroupedWithMeteredMinimum,
        System::Func<PriceModelGroupedWithMinMaxThresholds, T> groupedWithMinMaxThresholds,
        System::Func<NewFloatingMatrixWithDisplayNamePrice, T> newFloatingMatrixWithDisplayName,
        System::Func<NewFloatingGroupedTieredPackagePrice, T> newFloatingGroupedTieredPackage,
        System::Func<NewFloatingMaxGroupTieredPackagePrice, T> newFloatingMaxGroupTieredPackage,
        System::Func<
            NewFloatingScalableMatrixWithUnitPricingPrice,
            T
        > newFloatingScalableMatrixWithUnitPricing,
        System::Func<
            NewFloatingScalableMatrixWithTieredPricingPrice,
            T
        > newFloatingScalableMatrixWithTieredPricing,
        System::Func<NewFloatingCumulativeGroupedBulkPrice, T> newFloatingCumulativeGroupedBulk,
        System::Func<PriceModelCumulativeGroupedAllocation, T> cumulativeGroupedAllocation,
        System::Func<NewFloatingMinimumCompositePrice, T> newFloatingMinimumComposite,
        System::Func<PriceModelPercent, T> percent,
        System::Func<PriceModelEventOutput, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewFloatingUnitPrice value => newFloatingUnit(value),
            NewFloatingTieredPrice value => newFloatingTiered(value),
            NewFloatingBulkPrice value => newFloatingBulk(value),
            PriceModelBulkWithFilters value => bulkWithFilters(value),
            NewFloatingPackagePrice value => newFloatingPackage(value),
            NewFloatingMatrixPrice value => newFloatingMatrix(value),
            NewFloatingThresholdTotalAmountPrice value => newFloatingThresholdTotalAmount(value),
            NewFloatingTieredPackagePrice value => newFloatingTieredPackage(value),
            NewFloatingTieredWithMinimumPrice value => newFloatingTieredWithMinimum(value),
            NewFloatingGroupedTieredPrice value => newFloatingGroupedTiered(value),
            NewFloatingTieredPackageWithMinimumPrice value => newFloatingTieredPackageWithMinimum(
                value
            ),
            NewFloatingPackageWithAllocationPrice value => newFloatingPackageWithAllocation(value),
            NewFloatingUnitWithPercentPrice value => newFloatingUnitWithPercent(value),
            NewFloatingMatrixWithAllocationPrice value => newFloatingMatrixWithAllocation(value),
            NewFloatingTieredWithProrationPrice value => newFloatingTieredWithProration(value),
            NewFloatingUnitWithProrationPrice value => newFloatingUnitWithProration(value),
            NewFloatingGroupedAllocationPrice value => newFloatingGroupedAllocation(value),
            NewFloatingBulkWithProrationPrice value => newFloatingBulkWithProration(value),
            NewFloatingGroupedWithProratedMinimumPrice value =>
                newFloatingGroupedWithProratedMinimum(value),
            NewFloatingGroupedWithMeteredMinimumPrice value => newFloatingGroupedWithMeteredMinimum(
                value
            ),
            PriceModelGroupedWithMinMaxThresholds value => groupedWithMinMaxThresholds(value),
            NewFloatingMatrixWithDisplayNamePrice value => newFloatingMatrixWithDisplayName(value),
            NewFloatingGroupedTieredPackagePrice value => newFloatingGroupedTieredPackage(value),
            NewFloatingMaxGroupTieredPackagePrice value => newFloatingMaxGroupTieredPackage(value),
            NewFloatingScalableMatrixWithUnitPricingPrice value =>
                newFloatingScalableMatrixWithUnitPricing(value),
            NewFloatingScalableMatrixWithTieredPricingPrice value =>
                newFloatingScalableMatrixWithTieredPricing(value),
            NewFloatingCumulativeGroupedBulkPrice value => newFloatingCumulativeGroupedBulk(value),
            PriceModelCumulativeGroupedAllocation value => cumulativeGroupedAllocation(value),
            NewFloatingMinimumCompositePrice value => newFloatingMinimumComposite(value),
            PriceModelPercent value => percent(value),
            PriceModelEventOutput value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of PriceModel"),
        };
    }

    public static implicit operator PriceModel(NewFloatingUnitPrice value) => new(value);

    public static implicit operator PriceModel(NewFloatingTieredPrice value) => new(value);

    public static implicit operator PriceModel(NewFloatingBulkPrice value) => new(value);

    public static implicit operator PriceModel(PriceModelBulkWithFilters value) => new(value);

    public static implicit operator PriceModel(NewFloatingPackagePrice value) => new(value);

    public static implicit operator PriceModel(NewFloatingMatrixPrice value) => new(value);

    public static implicit operator PriceModel(NewFloatingThresholdTotalAmountPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingTieredPackagePrice value) => new(value);

    public static implicit operator PriceModel(NewFloatingTieredWithMinimumPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingGroupedTieredPrice value) => new(value);

    public static implicit operator PriceModel(NewFloatingTieredPackageWithMinimumPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingPackageWithAllocationPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingUnitWithPercentPrice value) => new(value);

    public static implicit operator PriceModel(NewFloatingMatrixWithAllocationPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingTieredWithProrationPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingUnitWithProrationPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingGroupedAllocationPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingBulkWithProrationPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingGroupedWithProratedMinimumPrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingGroupedWithMeteredMinimumPrice value) =>
        new(value);

    public static implicit operator PriceModel(PriceModelGroupedWithMinMaxThresholds value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingMatrixWithDisplayNamePrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingGroupedTieredPackagePrice value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingMaxGroupTieredPackagePrice value) =>
        new(value);

    public static implicit operator PriceModel(
        NewFloatingScalableMatrixWithUnitPricingPrice value
    ) => new(value);

    public static implicit operator PriceModel(
        NewFloatingScalableMatrixWithTieredPricingPrice value
    ) => new(value);

    public static implicit operator PriceModel(NewFloatingCumulativeGroupedBulkPrice value) =>
        new(value);

    public static implicit operator PriceModel(PriceModelCumulativeGroupedAllocation value) =>
        new(value);

    public static implicit operator PriceModel(NewFloatingMinimumCompositePrice value) =>
        new(value);

    public static implicit operator PriceModel(PriceModelPercent value) => new(value);

    public static implicit operator PriceModel(PriceModelEventOutput value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of PriceModel");
        }
    }

    public virtual bool Equals(PriceModel? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingBulkPrice>(
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
            case "bulk_with_filters":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PriceModelBulkWithFilters>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingPackagePrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMatrixPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingThresholdTotalAmountPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackagePrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedTieredPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitWithPercentPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingMatrixWithAllocationPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingTieredWithProrationPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingUnitWithProrationPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedAllocationPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingBulkWithProrationPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPrice>(
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
                        JsonSerializer.Deserialize<PriceModelGroupedWithMinMaxThresholds>(
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
                        JsonSerializer.Deserialize<NewFloatingMatrixWithDisplayNamePrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedTieredPackagePrice>(
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
                        JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePrice>(
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithUnitPricingPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithTieredPricingPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingCumulativeGroupedBulkPrice>(
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
                        JsonSerializer.Deserialize<PriceModelCumulativeGroupedAllocation>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMinimumCompositePrice>(
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
                    var deserialized = JsonSerializer.Deserialize<PriceModelPercent>(json, options);
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
                    var deserialized = JsonSerializer.Deserialize<PriceModelEventOutput>(
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
                return new PriceModel(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModel? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<PriceModelBulkWithFilters, PriceModelBulkWithFiltersFromRaw>))]
public sealed record class PriceModelBulkWithFilters : ModelBase
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required PriceModelBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelBulkWithFiltersBulkWithFiltersConfig>(
                this.RawData,
                "bulk_with_filters_config"
            );
        }
        init { ModelBase.Set(this._rawData, "bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelBulkWithFiltersCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, PriceModelBulkWithFiltersCadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
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
    public PriceModelBulkWithFiltersModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelBulkWithFiltersModelType>(
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
    public PriceModelBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<PriceModelBulkWithFiltersConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
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

    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelBulkWithFilters()
    {
        this.ModelType = new();
    }

    public PriceModelBulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelBulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelBulkWithFiltersFromRaw : IFromRaw<PriceModelBulkWithFilters>
{
    public PriceModelBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelBulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        PriceModelBulkWithFiltersBulkWithFiltersConfig,
        PriceModelBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class PriceModelBulkWithFiltersBulkWithFiltersConfig : ModelBase
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.Filter1> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Subscriptions.Filter1>>(
                this.RawData,
                "filters"
            );
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<global::Orb.Models.Subscriptions.Tier3> Tiers
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.Subscriptions.Tier3>>(
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

    public PriceModelBulkWithFiltersBulkWithFiltersConfig() { }

    public PriceModelBulkWithFiltersBulkWithFiltersConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelBulkWithFiltersBulkWithFiltersConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRaw<PriceModelBulkWithFiltersBulkWithFiltersConfig>
{
    public PriceModelBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Filter1,
        global::Orb.Models.Subscriptions.Filter1FromRaw
    >)
)]
public sealed record class Filter1 : ModelBase
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

    public Filter1() { }

    public Filter1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Filter1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter1FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Filter1>
{
    public global::Orb.Models.Subscriptions.Filter1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Filter1.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Subscriptions.Tier3,
        global::Orb.Models.Subscriptions.Tier3FromRaw
    >)
)]
public sealed record class Tier3 : ModelBase
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

    public Tier3() { }

    public Tier3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Tier3(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class Tier3FromRaw : IFromRaw<global::Orb.Models.Subscriptions.Tier3>
{
    public global::Orb.Models.Subscriptions.Tier3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Subscriptions.Tier3.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceModelBulkWithFiltersCadenceConverter))]
public enum PriceModelBulkWithFiltersCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceModelBulkWithFiltersCadenceConverter
    : JsonConverter<PriceModelBulkWithFiltersCadence>
{
    public override PriceModelBulkWithFiltersCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceModelBulkWithFiltersCadence.Annual,
            "semi_annual" => PriceModelBulkWithFiltersCadence.SemiAnnual,
            "monthly" => PriceModelBulkWithFiltersCadence.Monthly,
            "quarterly" => PriceModelBulkWithFiltersCadence.Quarterly,
            "one_time" => PriceModelBulkWithFiltersCadence.OneTime,
            "custom" => PriceModelBulkWithFiltersCadence.Custom,
            _ => (PriceModelBulkWithFiltersCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelBulkWithFiltersCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceModelBulkWithFiltersCadence.Annual => "annual",
                PriceModelBulkWithFiltersCadence.SemiAnnual => "semi_annual",
                PriceModelBulkWithFiltersCadence.Monthly => "monthly",
                PriceModelBulkWithFiltersCadence.Quarterly => "quarterly",
                PriceModelBulkWithFiltersCadence.OneTime => "one_time",
                PriceModelBulkWithFiltersCadence.Custom => "custom",
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
public class PriceModelBulkWithFiltersModelType
{
    public JsonElement Json { get; private init; }

    public PriceModelBulkWithFiltersModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    PriceModelBulkWithFiltersModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new PriceModelBulkWithFiltersModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceModelBulkWithFiltersModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceModelBulkWithFiltersModelType>
    {
        public override PriceModelBulkWithFiltersModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceModelBulkWithFiltersModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(PriceModelBulkWithFiltersConversionRateConfigConverter))]
public record class PriceModelBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelBulkWithFiltersConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of PriceModelBulkWithFiltersConversionRateConfig"
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
                "Data did not match any variant of PriceModelBulkWithFiltersConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceModelBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceModelBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelBulkWithFiltersConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(PriceModelBulkWithFiltersConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceModelBulkWithFiltersConversionRateConfigConverter
    : JsonConverter<PriceModelBulkWithFiltersConversionRateConfig>
{
    public override PriceModelBulkWithFiltersConversionRateConfig? Read(
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
                return new PriceModelBulkWithFiltersConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelBulkWithFiltersConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        PriceModelGroupedWithMinMaxThresholds,
        PriceModelGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class PriceModelGroupedWithMinMaxThresholds : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelGroupedWithMinMaxThresholdsCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PriceModelGroupedWithMinMaxThresholdsCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
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
    public PriceModelGroupedWithMinMaxThresholdsModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelGroupedWithMinMaxThresholdsModelType>(
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
    public PriceModelGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<PriceModelGroupedWithMinMaxThresholdsConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
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

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelGroupedWithMinMaxThresholds()
    {
        this.ModelType = new();
    }

    public PriceModelGroupedWithMinMaxThresholds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelGroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelGroupedWithMinMaxThresholdsFromRaw : IFromRaw<PriceModelGroupedWithMinMaxThresholds>
{
    public PriceModelGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelGroupedWithMinMaxThresholds.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceModelGroupedWithMinMaxThresholdsCadenceConverter))]
public enum PriceModelGroupedWithMinMaxThresholdsCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceModelGroupedWithMinMaxThresholdsCadenceConverter
    : JsonConverter<PriceModelGroupedWithMinMaxThresholdsCadence>
{
    public override PriceModelGroupedWithMinMaxThresholdsCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceModelGroupedWithMinMaxThresholdsCadence.Annual,
            "semi_annual" => PriceModelGroupedWithMinMaxThresholdsCadence.SemiAnnual,
            "monthly" => PriceModelGroupedWithMinMaxThresholdsCadence.Monthly,
            "quarterly" => PriceModelGroupedWithMinMaxThresholdsCadence.Quarterly,
            "one_time" => PriceModelGroupedWithMinMaxThresholdsCadence.OneTime,
            "custom" => PriceModelGroupedWithMinMaxThresholdsCadence.Custom,
            _ => (PriceModelGroupedWithMinMaxThresholdsCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelGroupedWithMinMaxThresholdsCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceModelGroupedWithMinMaxThresholdsCadence.Annual => "annual",
                PriceModelGroupedWithMinMaxThresholdsCadence.SemiAnnual => "semi_annual",
                PriceModelGroupedWithMinMaxThresholdsCadence.Monthly => "monthly",
                PriceModelGroupedWithMinMaxThresholdsCadence.Quarterly => "quarterly",
                PriceModelGroupedWithMinMaxThresholdsCadence.OneTime => "one_time",
                PriceModelGroupedWithMinMaxThresholdsCadence.Custom => "custom",
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
        PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
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

    public PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig() { }

    public PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRaw<PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    public PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PriceModelGroupedWithMinMaxThresholdsModelType
{
    public JsonElement Json { get; private init; }

    public PriceModelGroupedWithMinMaxThresholdsModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    PriceModelGroupedWithMinMaxThresholdsModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new PriceModelGroupedWithMinMaxThresholdsModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceModelGroupedWithMinMaxThresholdsModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceModelGroupedWithMinMaxThresholdsModelType>
    {
        public override PriceModelGroupedWithMinMaxThresholdsModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceModelGroupedWithMinMaxThresholdsModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(PriceModelGroupedWithMinMaxThresholdsConversionRateConfigConverter))]
public record class PriceModelGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of PriceModelGroupedWithMinMaxThresholdsConversionRateConfig"
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
                "Data did not match any variant of PriceModelGroupedWithMinMaxThresholdsConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(PriceModelGroupedWithMinMaxThresholdsConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceModelGroupedWithMinMaxThresholdsConversionRateConfigConverter
    : JsonConverter<PriceModelGroupedWithMinMaxThresholdsConversionRateConfig>
{
    public override PriceModelGroupedWithMinMaxThresholdsConversionRateConfig? Read(
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
                return new PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelGroupedWithMinMaxThresholdsConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        PriceModelCumulativeGroupedAllocation,
        PriceModelCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class PriceModelCumulativeGroupedAllocation : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelCumulativeGroupedAllocationCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, PriceModelCumulativeGroupedAllocationCadence>
            >(this.RawData, "cadence");
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                this.RawData,
                "cumulative_grouped_allocation_config"
            );
        }
        init { ModelBase.Set(this._rawData, "cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
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
    public PriceModelCumulativeGroupedAllocationModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelCumulativeGroupedAllocationModelType>(
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
    public PriceModelCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<PriceModelCumulativeGroupedAllocationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
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

    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelCumulativeGroupedAllocation()
    {
        this.ModelType = new();
    }

    public PriceModelCumulativeGroupedAllocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelCumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelCumulativeGroupedAllocationFromRaw : IFromRaw<PriceModelCumulativeGroupedAllocation>
{
    public PriceModelCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelCumulativeGroupedAllocation.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceModelCumulativeGroupedAllocationCadenceConverter))]
public enum PriceModelCumulativeGroupedAllocationCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceModelCumulativeGroupedAllocationCadenceConverter
    : JsonConverter<PriceModelCumulativeGroupedAllocationCadence>
{
    public override PriceModelCumulativeGroupedAllocationCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceModelCumulativeGroupedAllocationCadence.Annual,
            "semi_annual" => PriceModelCumulativeGroupedAllocationCadence.SemiAnnual,
            "monthly" => PriceModelCumulativeGroupedAllocationCadence.Monthly,
            "quarterly" => PriceModelCumulativeGroupedAllocationCadence.Quarterly,
            "one_time" => PriceModelCumulativeGroupedAllocationCadence.OneTime,
            "custom" => PriceModelCumulativeGroupedAllocationCadence.Custom,
            _ => (PriceModelCumulativeGroupedAllocationCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelCumulativeGroupedAllocationCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceModelCumulativeGroupedAllocationCadence.Annual => "annual",
                PriceModelCumulativeGroupedAllocationCadence.SemiAnnual => "semi_annual",
                PriceModelCumulativeGroupedAllocationCadence.Monthly => "monthly",
                PriceModelCumulativeGroupedAllocationCadence.Quarterly => "quarterly",
                PriceModelCumulativeGroupedAllocationCadence.OneTime => "one_time",
                PriceModelCumulativeGroupedAllocationCadence.Custom => "custom",
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
        PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
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

    public PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig() { }

    public PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRaw<PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    public PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PriceModelCumulativeGroupedAllocationModelType
{
    public JsonElement Json { get; private init; }

    public PriceModelCumulativeGroupedAllocationModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"");
    }

    PriceModelCumulativeGroupedAllocationModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new PriceModelCumulativeGroupedAllocationModelType().Json
            )
        )
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceModelCumulativeGroupedAllocationModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceModelCumulativeGroupedAllocationModelType>
    {
        public override PriceModelCumulativeGroupedAllocationModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceModelCumulativeGroupedAllocationModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(PriceModelCumulativeGroupedAllocationConversionRateConfigConverter))]
public record class PriceModelCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelCumulativeGroupedAllocationConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of PriceModelCumulativeGroupedAllocationConversionRateConfig"
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
                "Data did not match any variant of PriceModelCumulativeGroupedAllocationConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceModelCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceModelCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelCumulativeGroupedAllocationConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(PriceModelCumulativeGroupedAllocationConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceModelCumulativeGroupedAllocationConversionRateConfigConverter
    : JsonConverter<PriceModelCumulativeGroupedAllocationConversionRateConfig>
{
    public override PriceModelCumulativeGroupedAllocationConversionRateConfig? Read(
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
                return new PriceModelCumulativeGroupedAllocationConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelCumulativeGroupedAllocationConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<PriceModelPercent, PriceModelPercentFromRaw>))]
public sealed record class PriceModelPercent : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelPercentCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, PriceModelPercentCadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
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
    public PriceModelPercentModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelPercentModelType>(
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
    public required PriceModelPercentPercentConfig PercentConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelPercentPercentConfig>(
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
    public PriceModelPercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<PriceModelPercentConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
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

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        this.PercentConfig.Validate();
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelPercent()
    {
        this.ModelType = new();
    }

    public PriceModelPercent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelPercent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelPercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelPercentFromRaw : IFromRaw<PriceModelPercent>
{
    public PriceModelPercent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PriceModelPercent.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceModelPercentCadenceConverter))]
public enum PriceModelPercentCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceModelPercentCadenceConverter : JsonConverter<PriceModelPercentCadence>
{
    public override PriceModelPercentCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceModelPercentCadence.Annual,
            "semi_annual" => PriceModelPercentCadence.SemiAnnual,
            "monthly" => PriceModelPercentCadence.Monthly,
            "quarterly" => PriceModelPercentCadence.Quarterly,
            "one_time" => PriceModelPercentCadence.OneTime,
            "custom" => PriceModelPercentCadence.Custom,
            _ => (PriceModelPercentCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelPercentCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceModelPercentCadence.Annual => "annual",
                PriceModelPercentCadence.SemiAnnual => "semi_annual",
                PriceModelPercentCadence.Monthly => "monthly",
                PriceModelPercentCadence.Quarterly => "quarterly",
                PriceModelPercentCadence.OneTime => "one_time",
                PriceModelPercentCadence.Custom => "custom",
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
public class PriceModelPercentModelType
{
    public JsonElement Json { get; private init; }

    public PriceModelPercentModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    PriceModelPercentModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new PriceModelPercentModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceModelPercentModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceModelPercentModelType>
    {
        public override PriceModelPercentModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceModelPercentModelType value,
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
    typeof(ModelConverter<PriceModelPercentPercentConfig, PriceModelPercentPercentConfigFromRaw>)
)]
public sealed record class PriceModelPercentPercentConfig : ModelBase
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

    public PriceModelPercentPercentConfig() { }

    public PriceModelPercentPercentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelPercentPercentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelPercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceModelPercentPercentConfig(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

class PriceModelPercentPercentConfigFromRaw : IFromRaw<PriceModelPercentPercentConfig>
{
    public PriceModelPercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelPercentPercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PriceModelPercentConversionRateConfigConverter))]
public record class PriceModelPercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelPercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelPercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelPercentConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of PriceModelPercentConversionRateConfig"
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
                "Data did not match any variant of PriceModelPercentConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceModelPercentConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceModelPercentConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelPercentConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(PriceModelPercentConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceModelPercentConversionRateConfigConverter
    : JsonConverter<PriceModelPercentConversionRateConfig>
{
    public override PriceModelPercentConversionRateConfig? Read(
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
                return new PriceModelPercentConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelPercentConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<PriceModelEventOutput, PriceModelEventOutputFromRaw>))]
public sealed record class PriceModelEventOutput : ModelBase
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelEventOutputCadence> Cadence
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, PriceModelEventOutputCadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required PriceModelEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelEventOutputEventOutputConfig>(
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
    public PriceModelEventOutputModelType ModelType
    {
        get
        {
            return ModelBase.GetNotNullClass<PriceModelEventOutputModelType>(
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
    public PriceModelEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return ModelBase.GetNullableClass<PriceModelEventOutputConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { ModelBase.Set(this._rawData, "conversion_rate_config", value); }
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

    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.BillableMetricID;
        _ = this.BilledInAdvance;
        this.BillingCycleConfiguration?.Validate();
        _ = this.ConversionRate;
        this.ConversionRateConfig?.Validate();
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelEventOutput()
    {
        this.ModelType = new();
    }

    public PriceModelEventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelEventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelEventOutputFromRaw : IFromRaw<PriceModelEventOutput>
{
    public PriceModelEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelEventOutput.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(PriceModelEventOutputCadenceConverter))]
public enum PriceModelEventOutputCadence
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class PriceModelEventOutputCadenceConverter : JsonConverter<PriceModelEventOutputCadence>
{
    public override PriceModelEventOutputCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => PriceModelEventOutputCadence.Annual,
            "semi_annual" => PriceModelEventOutputCadence.SemiAnnual,
            "monthly" => PriceModelEventOutputCadence.Monthly,
            "quarterly" => PriceModelEventOutputCadence.Quarterly,
            "one_time" => PriceModelEventOutputCadence.OneTime,
            "custom" => PriceModelEventOutputCadence.Custom,
            _ => (PriceModelEventOutputCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelEventOutputCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceModelEventOutputCadence.Annual => "annual",
                PriceModelEventOutputCadence.SemiAnnual => "semi_annual",
                PriceModelEventOutputCadence.Monthly => "monthly",
                PriceModelEventOutputCadence.Quarterly => "quarterly",
                PriceModelEventOutputCadence.OneTime => "one_time",
                PriceModelEventOutputCadence.Custom => "custom",
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
        PriceModelEventOutputEventOutputConfig,
        PriceModelEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class PriceModelEventOutputEventOutputConfig : ModelBase
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

    public PriceModelEventOutputEventOutputConfig() { }

    public PriceModelEventOutputEventOutputConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelEventOutputEventOutputConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PriceModelEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceModelEventOutputEventOutputConfig(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

class PriceModelEventOutputEventOutputConfigFromRaw
    : IFromRaw<PriceModelEventOutputEventOutputConfig>
{
    public PriceModelEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelEventOutputEventOutputConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class PriceModelEventOutputModelType
{
    public JsonElement Json { get; private init; }

    public PriceModelEventOutputModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    PriceModelEventOutputModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new PriceModelEventOutputModelType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'PriceModelEventOutputModelType'"
            );
        }
    }

    class Converter : JsonConverter<PriceModelEventOutputModelType>
    {
        public override PriceModelEventOutputModelType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            PriceModelEventOutputModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(PriceModelEventOutputConversionRateConfigConverter))]
public record class PriceModelEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public PriceModelEventOutputConversionRateConfig(JsonElement json)
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
                    "Data did not match any variant of PriceModelEventOutputConversionRateConfig"
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
                "Data did not match any variant of PriceModelEventOutputConversionRateConfig"
            ),
        };
    }

    public static implicit operator PriceModelEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value
    ) => new(value);

    public static implicit operator PriceModelEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelEventOutputConversionRateConfig"
            );
        }
    }

    public virtual bool Equals(PriceModelEventOutputConversionRateConfig? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PriceModelEventOutputConversionRateConfigConverter
    : JsonConverter<PriceModelEventOutputConversionRateConfig>
{
    public override PriceModelEventOutputConversionRateConfig? Read(
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
                return new PriceModelEventOutputConversionRateConfig(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceModelEventOutputConversionRateConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<AddAdjustmentModel, AddAdjustmentModelFromRaw>))]
public sealed record class AddAdjustmentModel : ModelBase
{
    /// <summary>
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `start_date`. This `start_date` is
    /// treated as inclusive for in-advance prices, and exclusive for in-arrears prices.
    /// </summary>
    public required AddAdjustmentModelStartDate StartDate
    {
        get
        {
            return ModelBase.GetNotNullClass<AddAdjustmentModelStartDate>(
                this.RawData,
                "start_date"
            );
        }
        init { ModelBase.Set(this._rawData, "start_date", value); }
    }

    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public AddAdjustmentModelAdjustment? Adjustment
    {
        get
        {
            return ModelBase.GetNullableClass<AddAdjustmentModelAdjustment>(
                this.RawData,
                "adjustment"
            );
        }
        init { ModelBase.Set(this._rawData, "adjustment", value); }
    }

    /// <summary>
    /// The ID of the adjustment to add to the subscription. Adjustment IDs can be
    /// re-used from existing subscriptions or plans, but adjustments associated with
    /// coupon redemptions cannot be re-used.
    /// </summary>
    public string? AdjustmentID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "adjustment_id"); }
        init { ModelBase.Set(this._rawData, "adjustment_id", value); }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `end_date`.This `end_date` is treated
    /// as exclusive for in-advance prices, and inclusive for in-arrears prices.
    /// </summary>
    public AddAdjustmentModelEndDate? EndDate
    {
        get
        {
            return ModelBase.GetNullableClass<AddAdjustmentModelEndDate>(this.RawData, "end_date");
        }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    public override void Validate()
    {
        this.StartDate.Validate();
        this.Adjustment?.Validate();
        _ = this.AdjustmentID;
        this.EndDate?.Validate();
    }

    public AddAdjustmentModel() { }

    public AddAdjustmentModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustmentModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AddAdjustmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddAdjustmentModel(AddAdjustmentModelStartDate startDate)
        : this()
    {
        this.StartDate = startDate;
    }
}

class AddAdjustmentModelFromRaw : IFromRaw<AddAdjustmentModel>
{
    public AddAdjustmentModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddAdjustmentModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The start date of the adjustment interval. This is the date that the adjustment
/// will start affecting prices on the subscription. The adjustment will apply to
/// invoice dates that overlap with this `start_date`. This `start_date` is treated
/// as inclusive for in-advance prices, and exclusive for in-arrears prices.
/// </summary>
[JsonConverter(typeof(AddAdjustmentModelStartDateConverter))]
public record class AddAdjustmentModelStartDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AddAdjustmentModelStartDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelStartDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTime,
        System::Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddAdjustmentModelStartDate"
                );
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTime,
        System::Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddAdjustmentModelStartDate"
            ),
        };
    }

    public static implicit operator AddAdjustmentModelStartDate(System::DateTimeOffset value) =>
        new(value);

    public static implicit operator AddAdjustmentModelStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value
    ) => new(value);

    public static implicit operator AddAdjustmentModelStartDate(BillingCycleRelativeDate value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddAdjustmentModelStartDate"
            );
        }
    }

    public virtual bool Equals(AddAdjustmentModelStartDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class AddAdjustmentModelStartDateConverter : JsonConverter<AddAdjustmentModelStartDate>
{
    public override AddAdjustmentModelStartDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddAdjustmentModelStartDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(AddAdjustmentModelAdjustmentConverter))]
public record class AddAdjustmentModelAdjustment
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

    public AddAdjustmentModelAdjustment(NewPercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelAdjustment(NewUsageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelAdjustment(NewAmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelAdjustment(NewMinimum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelAdjustment(NewMaximum value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelAdjustment(JsonElement json)
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
                    "Data did not match any variant of AddAdjustmentModelAdjustment"
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
                "Data did not match any variant of AddAdjustmentModelAdjustment"
            ),
        };
    }

    public static implicit operator AddAdjustmentModelAdjustment(NewPercentageDiscount value) =>
        new(value);

    public static implicit operator AddAdjustmentModelAdjustment(NewUsageDiscount value) =>
        new(value);

    public static implicit operator AddAdjustmentModelAdjustment(NewAmountDiscount value) =>
        new(value);

    public static implicit operator AddAdjustmentModelAdjustment(NewMinimum value) => new(value);

    public static implicit operator AddAdjustmentModelAdjustment(NewMaximum value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddAdjustmentModelAdjustment"
            );
        }
    }

    public virtual bool Equals(AddAdjustmentModelAdjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class AddAdjustmentModelAdjustmentConverter : JsonConverter<AddAdjustmentModelAdjustment?>
{
    public override AddAdjustmentModelAdjustment? Read(
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
                return new AddAdjustmentModelAdjustment(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddAdjustmentModelAdjustment? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// The end date of the adjustment interval. This is the date that the adjustment
/// will stop affecting prices on the subscription. The adjustment will apply to
/// invoice dates that overlap with this `end_date`.This `end_date` is treated as
/// exclusive for in-advance prices, and inclusive for in-arrears prices.
/// </summary>
[JsonConverter(typeof(AddAdjustmentModelEndDateConverter))]
public record class AddAdjustmentModelEndDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public AddAdjustmentModelEndDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelEndDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public AddAdjustmentModelEndDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTime,
        System::Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of AddAdjustmentModelEndDate"
                );
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTime,
        System::Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of AddAdjustmentModelEndDate"
            ),
        };
    }

    public static implicit operator AddAdjustmentModelEndDate(System::DateTimeOffset value) =>
        new(value);

    public static implicit operator AddAdjustmentModelEndDate(
        ApiEnum<string, BillingCycleRelativeDate> value
    ) => new(value);

    public static implicit operator AddAdjustmentModelEndDate(BillingCycleRelativeDate value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of AddAdjustmentModelEndDate"
            );
        }
    }

    public virtual bool Equals(AddAdjustmentModelEndDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class AddAdjustmentModelEndDateConverter : JsonConverter<AddAdjustmentModelEndDate?>
{
    public override AddAdjustmentModelEndDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddAdjustmentModelEndDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Edit, EditFromRaw>))]
public sealed record class Edit : ModelBase
{
    /// <summary>
    /// The id of the price interval to edit.
    /// </summary>
    public required string PriceIntervalID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "price_interval_id"); }
        init { ModelBase.Set(this._rawData, "price_interval_id", value); }
    }

    /// <summary>
    /// The updated billing cycle day for this price interval. If not specified,
    /// the billing cycle day will not be updated. Note that overlapping price intervals
    /// must have the same billing cycle day.
    /// </summary>
    public long? BillingCycleDay
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "billing_cycle_day"); }
        init { ModelBase.Set(this._rawData, "billing_cycle_day", value); }
    }

    /// <summary>
    /// If true, an in-arrears price interval ending mid-cycle will defer billing
    /// the final line item until the next scheduled invoice. If false, it will be
    /// billed on its end date.
    /// </summary>
    public bool? CanDeferBilling
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "can_defer_billing"); }
        init { ModelBase.Set(this._rawData, "can_defer_billing", value); }
    }

    /// <summary>
    /// The updated end date of this price interval. If not specified, the end date
    /// will not be updated.
    /// </summary>
    public EditEndDate? EndDate
    {
        get { return ModelBase.GetNullableClass<EditEndDate>(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "filter"); }
        init { ModelBase.Set(this._rawData, "filter", value); }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to use for this price interval. Note
    /// that this list will overwrite all existing fixed fee quantity transitions
    /// on the price interval.
    /// </summary>
    public IReadOnlyList<FixedFeeQuantityTransitionModel>? FixedFeeQuantityTransitions
    {
        get
        {
            return ModelBase.GetNullableClass<List<FixedFeeQuantityTransitionModel>>(
                this.RawData,
                "fixed_fee_quantity_transitions"
            );
        }
        init { ModelBase.Set(this._rawData, "fixed_fee_quantity_transitions", value); }
    }

    /// <summary>
    /// The updated start date of this price interval. If not specified, the start
    /// date will not be updated.
    /// </summary>
    public EditStartDate? StartDate
    {
        get { return ModelBase.GetNullableClass<EditStartDate>(this.RawData, "start_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "start_date", value);
        }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this subscription. By default, a subscription only considers usage events
    /// associated with its attached customer's customer_id. When usage_customer_ids
    /// is provided, the subscription includes usage events from the specified customers
    /// only. Provided usage_customer_ids must be either the customer for this subscription
    /// itself, or any of that customer's children.
    /// </summary>
    public IReadOnlyList<string>? UsageCustomerIDs
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "usage_customer_ids"); }
        init { ModelBase.Set(this._rawData, "usage_customer_ids", value); }
    }

    public override void Validate()
    {
        _ = this.PriceIntervalID;
        _ = this.BillingCycleDay;
        _ = this.CanDeferBilling;
        this.EndDate?.Validate();
        _ = this.Filter;
        foreach (var item in this.FixedFeeQuantityTransitions ?? [])
        {
            item.Validate();
        }
        this.StartDate?.Validate();
        _ = this.UsageCustomerIDs;
    }

    public Edit() { }

    public Edit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Edit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Edit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Edit(string priceIntervalID)
        : this()
    {
        this.PriceIntervalID = priceIntervalID;
    }
}

class EditFromRaw : IFromRaw<Edit>
{
    public Edit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Edit.FromRawUnchecked(rawData);
}

/// <summary>
/// The updated end date of this price interval. If not specified, the end date will
/// not be updated.
/// </summary>
[JsonConverter(typeof(EditEndDateConverter))]
public record class EditEndDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EditEndDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public EditEndDate(ApiEnum<string, BillingCycleRelativeDate> value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public EditEndDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTime,
        System::Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of EditEndDate");
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTime,
        System::Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of EditEndDate"),
        };
    }

    public static implicit operator EditEndDate(System::DateTimeOffset value) => new(value);

    public static implicit operator EditEndDate(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new(value);

    public static implicit operator EditEndDate(BillingCycleRelativeDate value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EditEndDate");
        }
    }

    public virtual bool Equals(EditEndDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class EditEndDateConverter : JsonConverter<EditEndDate?>
{
    public override EditEndDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EditEndDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<FixedFeeQuantityTransitionModel, FixedFeeQuantityTransitionModelFromRaw>)
)]
public sealed record class FixedFeeQuantityTransitionModel : ModelBase
{
    /// <summary>
    /// The date that the fixed fee quantity transition should take effect.
    /// </summary>
    public required System::DateTimeOffset EffectiveDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "effective_date"
            );
        }
        init { ModelBase.Set(this._rawData, "effective_date", value); }
    }

    /// <summary>
    /// The quantity of the fixed fee quantity transition.
    /// </summary>
    public required long Quantity
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransitionModel() { }

    public FixedFeeQuantityTransitionModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransitionModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static FixedFeeQuantityTransitionModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FixedFeeQuantityTransitionModelFromRaw : IFromRaw<FixedFeeQuantityTransitionModel>
{
    public FixedFeeQuantityTransitionModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FixedFeeQuantityTransitionModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The updated start date of this price interval. If not specified, the start date
/// will not be updated.
/// </summary>
[JsonConverter(typeof(EditStartDateConverter))]
public record class EditStartDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EditStartDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public EditStartDate(ApiEnum<string, BillingCycleRelativeDate> value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public EditStartDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTime,
        System::Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of EditStartDate"
                );
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTime,
        System::Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of EditStartDate"
            ),
        };
    }

    public static implicit operator EditStartDate(System::DateTimeOffset value) => new(value);

    public static implicit operator EditStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value
    ) => new(value);

    public static implicit operator EditStartDate(BillingCycleRelativeDate value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EditStartDate");
        }
    }

    public virtual bool Equals(EditStartDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class EditStartDateConverter : JsonConverter<EditStartDate>
{
    public override EditStartDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EditStartDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<EditAdjustment, EditAdjustmentFromRaw>))]
public sealed record class EditAdjustment : ModelBase
{
    /// <summary>
    /// The id of the adjustment interval to edit.
    /// </summary>
    public required string AdjustmentIntervalID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "adjustment_interval_id"); }
        init { ModelBase.Set(this._rawData, "adjustment_interval_id", value); }
    }

    /// <summary>
    /// The updated end date of this adjustment interval. If not specified, the end
    /// date will not be updated.
    /// </summary>
    public EditAdjustmentEndDate? EndDate
    {
        get { return ModelBase.GetNullableClass<EditAdjustmentEndDate>(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The updated start date of this adjustment interval. If not specified, the
    /// start date will not be updated.
    /// </summary>
    public EditAdjustmentStartDate? StartDate
    {
        get
        {
            return ModelBase.GetNullableClass<EditAdjustmentStartDate>(this.RawData, "start_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "start_date", value);
        }
    }

    public override void Validate()
    {
        _ = this.AdjustmentIntervalID;
        this.EndDate?.Validate();
        this.StartDate?.Validate();
    }

    public EditAdjustment() { }

    public EditAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EditAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static EditAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EditAdjustment(string adjustmentIntervalID)
        : this()
    {
        this.AdjustmentIntervalID = adjustmentIntervalID;
    }
}

class EditAdjustmentFromRaw : IFromRaw<EditAdjustment>
{
    public EditAdjustment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EditAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The updated end date of this adjustment interval. If not specified, the end date
/// will not be updated.
/// </summary>
[JsonConverter(typeof(EditAdjustmentEndDateConverter))]
public record class EditAdjustmentEndDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EditAdjustmentEndDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public EditAdjustmentEndDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public EditAdjustmentEndDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTime,
        System::Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of EditAdjustmentEndDate"
                );
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTime,
        System::Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of EditAdjustmentEndDate"
            ),
        };
    }

    public static implicit operator EditAdjustmentEndDate(System::DateTimeOffset value) =>
        new(value);

    public static implicit operator EditAdjustmentEndDate(
        ApiEnum<string, BillingCycleRelativeDate> value
    ) => new(value);

    public static implicit operator EditAdjustmentEndDate(BillingCycleRelativeDate value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of EditAdjustmentEndDate"
            );
        }
    }

    public virtual bool Equals(EditAdjustmentEndDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class EditAdjustmentEndDateConverter : JsonConverter<EditAdjustmentEndDate?>
{
    public override EditAdjustmentEndDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EditAdjustmentEndDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// The updated start date of this adjustment interval. If not specified, the start
/// date will not be updated.
/// </summary>
[JsonConverter(typeof(EditAdjustmentStartDateConverter))]
public record class EditAdjustmentStartDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EditAdjustmentStartDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public EditAdjustmentStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public EditAdjustmentStartDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateTimeOffset> @dateTime,
        System::Action<ApiEnum<string, BillingCycleRelativeDate>> billingCycleRelative
    )
    {
        switch (this.Value)
        {
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            case ApiEnum<string, BillingCycleRelativeDate> value:
                billingCycleRelative(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of EditAdjustmentStartDate"
                );
        }
    }

    public T Match<T>(
        System::Func<System::DateTimeOffset, T> @dateTime,
        System::Func<ApiEnum<string, BillingCycleRelativeDate>, T> billingCycleRelative
    )
    {
        return this.Value switch
        {
            System::DateTimeOffset value => @dateTime(value),
            ApiEnum<string, BillingCycleRelativeDate> value => billingCycleRelative(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of EditAdjustmentStartDate"
            ),
        };
    }

    public static implicit operator EditAdjustmentStartDate(System::DateTimeOffset value) =>
        new(value);

    public static implicit operator EditAdjustmentStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value
    ) => new(value);

    public static implicit operator EditAdjustmentStartDate(BillingCycleRelativeDate value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of EditAdjustmentStartDate"
            );
        }
    }

    public virtual bool Equals(EditAdjustmentStartDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class EditAdjustmentStartDateConverter : JsonConverter<EditAdjustmentStartDate>
{
    public override EditAdjustmentStartDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EditAdjustmentStartDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
