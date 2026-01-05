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
        get { return JsonModel.GetNullableClass<List<Add>>(this.RawBodyData, "add"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "add", value);
        }
    }

    /// <summary>
    /// A list of adjustments to add to the subscription.
    /// </summary>
    public IReadOnlyList<SubscriptionPriceIntervalsParamsAddAdjustment>? AddAdjustments
    {
        get
        {
            return JsonModel.GetNullableClass<List<SubscriptionPriceIntervalsParamsAddAdjustment>>(
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

            JsonModel.Set(this._rawBodyData, "add_adjustments", value);
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
            return JsonModel.GetNullableStruct<bool>(
                this.RawBodyData,
                "allow_invoice_credit_or_void"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "allow_invoice_credit_or_void", value); }
    }

    /// <summary>
    /// If set, the default value to use for added/edited price intervals with an
    /// end_date set.
    /// </summary>
    public bool? CanDeferBilling
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "can_defer_billing"); }
        init { JsonModel.Set(this._rawBodyData, "can_defer_billing", value); }
    }

    /// <summary>
    /// A list of price intervals to edit on the subscription.
    /// </summary>
    public IReadOnlyList<Edit>? Edit
    {
        get { return JsonModel.GetNullableClass<List<Edit>>(this.RawBodyData, "edit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "edit", value);
        }
    }

    /// <summary>
    /// A list of adjustments to edit on the subscription.
    /// </summary>
    public IReadOnlyList<EditAdjustment>? EditAdjustments
    {
        get
        {
            return JsonModel.GetNullableClass<List<EditAdjustment>>(
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

            JsonModel.Set(this._rawBodyData, "edit_adjustments", value);
        }
    }

    public SubscriptionPriceIntervalsParams() { }

    public SubscriptionPriceIntervalsParams(
        SubscriptionPriceIntervalsParams subscriptionPriceIntervalsParams
    )
        : base(subscriptionPriceIntervalsParams)
    {
        this._rawBodyData = [.. subscriptionPriceIntervalsParams._rawBodyData];
    }

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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
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

[JsonConverter(typeof(JsonModelConverter<Add, AddFromRaw>))]
public sealed record class Add : JsonModel
{
    /// <summary>
    /// The start date of the price interval. This is the date that the price will
    /// start billing on the subscription.
    /// </summary>
    public required StartDate StartDate
    {
        get { return JsonModel.GetNotNullClass<StartDate>(this.RawData, "start_date"); }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            return JsonModel.GetNullableClass<NewAllocationPrice>(this.RawData, "allocation_price");
        }
        init { JsonModel.Set(this._rawData, "allocation_price", value); }
    }

    /// <summary>
    /// If true, an in-arrears price interval ending mid-cycle will defer billing
    /// the final line item until the next scheduled invoice. If false, it will be
    /// billed on its end date.
    /// </summary>
    public bool? CanDeferBilling
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "can_defer_billing"); }
        init { JsonModel.Set(this._rawData, "can_defer_billing", value); }
    }

    /// <summary>
    /// A list of discounts to initialize on the price interval.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Subscriptions.Discount>? Discounts
    {
        get
        {
            return JsonModel.GetNullableClass<List<global::Orb.Models.Subscriptions.Discount>>(
                this.RawData,
                "discounts"
            );
        }
        init { JsonModel.Set(this._rawData, "discounts", value); }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that the price will stop
    /// billing on the subscription.
    /// </summary>
    public EndDate? EndDate
    {
        get { return JsonModel.GetNullableClass<EndDate>(this.RawData, "end_date"); }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "filter"); }
        init { JsonModel.Set(this._rawData, "filter", value); }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to initialize on the price interval.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            return JsonModel.GetNullableClass<
                List<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>
            >(this.RawData, "fixed_fee_quantity_transitions");
        }
        init { JsonModel.Set(this._rawData, "fixed_fee_quantity_transitions", value); }
    }

    /// <summary>
    /// The maximum amount that will be billed for this price interval for a given
    /// billing period.
    /// </summary>
    public double? MaximumAmount
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "maximum_amount"); }
        init { JsonModel.Set(this._rawData, "maximum_amount", value); }
    }

    /// <summary>
    /// The minimum amount that will be billed for this price interval for a given
    /// billing period.
    /// </summary>
    public double? MinimumAmount
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "minimum_amount"); }
        init { JsonModel.Set(this._rawData, "minimum_amount", value); }
    }

    /// <summary>
    /// New floating price request body params.
    /// </summary>
    public PriceModel? Price
    {
        get { return JsonModel.GetNullableClass<PriceModel>(this.RawData, "price"); }
        init { JsonModel.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "price_id"); }
        init { JsonModel.Set(this._rawData, "price_id", value); }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this subscription. By default, a subscription only considers usage events
    /// associated with its attached customer's customer_id. When usage_customer_ids
    /// is provided, the subscription includes usage events from the specified customers
    /// only. Provided usage_customer_ids must be either the customer for this subscription
    /// itself, or any of that customer's children.
    /// </summary>
    public IReadOnlyList<string>? UsageCustomerIds
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "usage_customer_ids"); }
        init { JsonModel.Set(this._rawData, "usage_customer_ids", value); }
    }

    /// <inheritdoc/>
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
        _ = this.UsageCustomerIds;
    }

    public Add() { }

    public Add(Add add)
        : base(add) { }

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

    /// <inheritdoc cref="AddFromRaw.FromRawUnchecked"/>
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

class AddFromRaw : IFromRawJson<Add>
{
    /// <inheritdoc/>
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

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public StartDate(System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StartDate(ApiEnum<string, BillingCycleRelativeDate> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StartDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, BillingCycleRelativeDate>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingCycleRelative(out var value)) {
    ///     // `value` is of type `ApiEnum<string, BillingCycleRelativeDate>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of StartDate");
        }
        this.Switch((_) => { }, (billingCycleRelative) => billingCycleRelative.Validate());
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
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

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement DiscountType
    {
        get
        {
            return Match(
                amount: (x) => x.DiscountType,
                percentage: (x) => x.DiscountType,
                usage: (x) => x.DiscountType
            );
        }
    }

    public Discount(Amount value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Discount(Percentage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Discount(Usage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Discount(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Amount"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAmount(out var value)) {
    ///     // `value` is of type `Amount`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAmount([NotNullWhen(true)] out Amount? value)
    {
        value = this.Value as Amount;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Percentage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercentage(out var value)) {
    ///     // `value` is of type `Percentage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercentage([NotNullWhen(true)] out Percentage? value)
    {
        value = this.Value as Percentage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Usage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUsage(out var value)) {
    ///     // `value` is of type `Usage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUsage([NotNullWhen(true)] out Usage? value)
    {
        value = this.Value as Usage;
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
    ///     (Amount value) => {...},
    ///     (Percentage value) => {...},
    ///     (Usage value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Amount> amount,
        System::Action<Percentage> percentage,
        System::Action<Usage> usage
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
            case Usage value:
                usage(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Discount");
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
    ///     (Amount value) => {...},
    ///     (Percentage value) => {...},
    ///     (Usage value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Amount, T> amount,
        System::Func<Percentage, T> percentage,
        System::Func<Usage, T> usage
    )
    {
        return this.Value switch
        {
            Amount value => amount(value),
            Percentage value => percentage(value),
            Usage value => usage(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Discount"),
        };
    }

    public static implicit operator global::Orb.Models.Subscriptions.Discount(Amount value) =>
        new(value);

    public static implicit operator global::Orb.Models.Subscriptions.Discount(Percentage value) =>
        new(value);

    public static implicit operator global::Orb.Models.Subscriptions.Discount(Usage value) =>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
        this.Switch(
            (amount) => amount.Validate(),
            (percentage) => percentage.Validate(),
            (usage) => usage.Validate()
        );
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
            case "amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Amount>(element, options);
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
            case "percentage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Percentage>(element, options);
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
            case "usage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Usage>(element, options);
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
                return new global::Orb.Models.Subscriptions.Discount(element);
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

[JsonConverter(typeof(JsonModelConverter<Amount, AmountFromRaw>))]
public sealed record class Amount : JsonModel
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required double AmountDiscount
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "amount_discount"); }
        init { JsonModel.Set(this._rawData, "amount_discount", value); }
    }

    public JsonElement DiscountType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "discount_type"); }
        init { JsonModel.Set(this._rawData, "discount_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AmountDiscount;
        if (
            !JsonElement.DeepEquals(
                this.DiscountType,
                JsonSerializer.Deserialize<JsonElement>("\"amount\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
    }

    public Amount()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\"");
    }

    public Amount(Amount amount)
        : base(amount) { }

    public Amount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"amount\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Amount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmountFromRaw.FromRawUnchecked"/>
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

class AmountFromRaw : IFromRawJson<Amount>
{
    /// <inheritdoc/>
    public Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Amount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Percentage, PercentageFromRaw>))]
public sealed record class Percentage : JsonModel
{
    public JsonElement DiscountType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "discount_type"); }
        init { JsonModel.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscount
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { JsonModel.Set(this._rawData, "percentage_discount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.DiscountType,
                JsonSerializer.Deserialize<JsonElement>("\"percentage\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.PercentageDiscount;
    }

    public Percentage()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
    }

    public Percentage(Percentage percentage)
        : base(percentage) { }

    public Percentage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percentage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PercentageFromRaw.FromRawUnchecked"/>
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

class PercentageFromRaw : IFromRawJson<Percentage>
{
    /// <inheritdoc/>
    public Percentage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Percentage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    public JsonElement DiscountType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "discount_type"); }
        init { JsonModel.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for.
    /// </summary>
    public required double UsageDiscount
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "usage_discount"); }
        init { JsonModel.Set(this._rawData, "usage_discount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.DiscountType,
                JsonSerializer.Deserialize<JsonElement>("\"usage\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.UsageDiscount;
    }

    public Usage()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"usage\"");
    }

    public Usage(Usage usage)
        : base(usage) { }

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"usage\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Usage(double usageDiscount)
        : this()
    {
        this.UsageDiscount = usageDiscount;
    }
}

class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}

/// <summary>
/// The end date of the price interval. This is the date that the price will stop
/// billing on the subscription.
/// </summary>
[JsonConverter(typeof(EndDateConverter))]
public record class EndDate
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EndDate(System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EndDate(ApiEnum<string, BillingCycleRelativeDate> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EndDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, BillingCycleRelativeDate>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingCycleRelative(out var value)) {
    ///     // `value` is of type `ApiEnum<string, BillingCycleRelativeDate>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EndDate");
        }
        this.Switch((_) => { }, (billingCycleRelative) => billingCycleRelative.Validate());
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, EndDate? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Subscriptions.FixedFeeQuantityTransition,
        global::Orb.Models.Subscriptions.FixedFeeQuantityTransitionFromRaw
    >)
)]
public sealed record class FixedFeeQuantityTransition : JsonModel
{
    /// <summary>
    /// The date that the fixed fee quantity transition should take effect.
    /// </summary>
    public required System::DateTimeOffset EffectiveDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "effective_date"
            );
        }
        init { JsonModel.Set(this._rawData, "effective_date", value); }
    }

    /// <summary>
    /// The quantity of the fixed fee quantity transition.
    /// </summary>
    public required long Quantity
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition() { }

    public FixedFeeQuantityTransition(
        global::Orb.Models.Subscriptions.FixedFeeQuantityTransition fixedFeeQuantityTransition
    )
        : base(fixedFeeQuantityTransition) { }

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

    /// <inheritdoc cref="global::Orb.Models.Subscriptions.FixedFeeQuantityTransitionFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Subscriptions.FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FixedFeeQuantityTransitionFromRaw
    : IFromRawJson<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>
{
    /// <inheritdoc/>
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

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public PriceModel(NewFloatingUnitPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(PriceModelBulkWithFilters value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingMatrixPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingThresholdTotalAmountPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingTieredWithMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingGroupedTieredPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingTieredPackageWithMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingPackageWithAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingUnitWithPercentPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingMatrixWithAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingTieredWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingUnitWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingGroupedAllocationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingBulkWithProrationPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingGroupedWithProratedMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingGroupedWithMeteredMinimumPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(PriceModelGroupedWithMinMaxThresholds value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingMatrixWithDisplayNamePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingGroupedTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingMaxGroupTieredPackagePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(
        NewFloatingScalableMatrixWithUnitPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(
        NewFloatingScalableMatrixWithTieredPricingPrice value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingCumulativeGroupedBulkPrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(PriceModelCumulativeGroupedAllocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(NewFloatingMinimumCompositePrice value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(PriceModelPercent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(PriceModelEventOutput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModel(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingUnitPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingUnit(out var value)) {
    ///     // `value` is of type `NewFloatingUnitPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnit([NotNullWhen(true)] out NewFloatingUnitPrice? value)
    {
        value = this.Value as NewFloatingUnitPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTiered(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTiered([NotNullWhen(true)] out NewFloatingTieredPrice? value)
    {
        value = this.Value as NewFloatingTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingBulk(out var value)) {
    ///     // `value` is of type `NewFloatingBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingBulk([NotNullWhen(true)] out NewFloatingBulkPrice? value)
    {
        value = this.Value as NewFloatingBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceModelBulkWithFilters"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBulkWithFilters(out var value)) {
    ///     // `value` is of type `PriceModelBulkWithFilters`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBulkWithFilters([NotNullWhen(true)] out PriceModelBulkWithFilters? value)
    {
        value = this.Value as PriceModelBulkWithFilters;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingPackage(out var value)) {
    ///     // `value` is of type `NewFloatingPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingPackage([NotNullWhen(true)] out NewFloatingPackagePrice? value)
    {
        value = this.Value as NewFloatingPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMatrixPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMatrix(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrix([NotNullWhen(true)] out NewFloatingMatrixPrice? value)
    {
        value = this.Value as NewFloatingMatrixPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingThresholdTotalAmountPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingThresholdTotalAmount(out var value)) {
    ///     // `value` is of type `NewFloatingThresholdTotalAmountPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingThresholdTotalAmount(
        [NotNullWhen(true)] out NewFloatingThresholdTotalAmountPrice? value
    )
    {
        value = this.Value as NewFloatingThresholdTotalAmountPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTieredPackage(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredPackage(
        [NotNullWhen(true)] out NewFloatingTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTieredWithMinimum(out var value)) {
    ///     // `value` is of type `NewFloatingTieredWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredWithMinimum(
        [NotNullWhen(true)] out NewFloatingTieredWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedTieredPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedTiered(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedTieredPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedTiered(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredPackageWithMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTieredPackageWithMinimum(out var value)) {
    ///     // `value` is of type `NewFloatingTieredPackageWithMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredPackageWithMinimum(
        [NotNullWhen(true)] out NewFloatingTieredPackageWithMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingTieredPackageWithMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingPackageWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingPackageWithAllocation(out var value)) {
    ///     // `value` is of type `NewFloatingPackageWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingPackageWithAllocation(
        [NotNullWhen(true)] out NewFloatingPackageWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingPackageWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingUnitWithPercentPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingUnitWithPercent(out var value)) {
    ///     // `value` is of type `NewFloatingUnitWithPercentPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnitWithPercent(
        [NotNullWhen(true)] out NewFloatingUnitWithPercentPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithPercentPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMatrixWithAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMatrixWithAllocation(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixWithAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrixWithAllocation(
        [NotNullWhen(true)] out NewFloatingMatrixWithAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingTieredWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingTieredWithProration(out var value)) {
    ///     // `value` is of type `NewFloatingTieredWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingTieredWithProration(
        [NotNullWhen(true)] out NewFloatingTieredWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingTieredWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingUnitWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingUnitWithProration(out var value)) {
    ///     // `value` is of type `NewFloatingUnitWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingUnitWithProration(
        [NotNullWhen(true)] out NewFloatingUnitWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingUnitWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedAllocationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedAllocation(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedAllocationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedAllocation(
        [NotNullWhen(true)] out NewFloatingGroupedAllocationPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedAllocationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingBulkWithProrationPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingBulkWithProration(out var value)) {
    ///     // `value` is of type `NewFloatingBulkWithProrationPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingBulkWithProration(
        [NotNullWhen(true)] out NewFloatingBulkWithProrationPrice? value
    )
    {
        value = this.Value as NewFloatingBulkWithProrationPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedWithProratedMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedWithProratedMinimum(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedWithProratedMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedWithProratedMinimum(
        [NotNullWhen(true)] out NewFloatingGroupedWithProratedMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithProratedMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedWithMeteredMinimumPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedWithMeteredMinimum(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedWithMeteredMinimumPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedWithMeteredMinimum(
        [NotNullWhen(true)] out NewFloatingGroupedWithMeteredMinimumPrice? value
    )
    {
        value = this.Value as NewFloatingGroupedWithMeteredMinimumPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceModelGroupedWithMinMaxThresholds"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGroupedWithMinMaxThresholds(out var value)) {
    ///     // `value` is of type `PriceModelGroupedWithMinMaxThresholds`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGroupedWithMinMaxThresholds(
        [NotNullWhen(true)] out PriceModelGroupedWithMinMaxThresholds? value
    )
    {
        value = this.Value as PriceModelGroupedWithMinMaxThresholds;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMatrixWithDisplayNamePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMatrixWithDisplayName(out var value)) {
    ///     // `value` is of type `NewFloatingMatrixWithDisplayNamePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMatrixWithDisplayName(
        [NotNullWhen(true)] out NewFloatingMatrixWithDisplayNamePrice? value
    )
    {
        value = this.Value as NewFloatingMatrixWithDisplayNamePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingGroupedTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingGroupedTieredPackage(out var value)) {
    ///     // `value` is of type `NewFloatingGroupedTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingGroupedTieredPackage(
        [NotNullWhen(true)] out NewFloatingGroupedTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingGroupedTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMaxGroupTieredPackagePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMaxGroupTieredPackage(out var value)) {
    ///     // `value` is of type `NewFloatingMaxGroupTieredPackagePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMaxGroupTieredPackage(
        [NotNullWhen(true)] out NewFloatingMaxGroupTieredPackagePrice? value
    )
    {
        value = this.Value as NewFloatingMaxGroupTieredPackagePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingScalableMatrixWithUnitPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingScalableMatrixWithUnitPricing(out var value)) {
    ///     // `value` is of type `NewFloatingScalableMatrixWithUnitPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingScalableMatrixWithUnitPricing(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithUnitPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithUnitPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingScalableMatrixWithTieredPricingPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingScalableMatrixWithTieredPricing(out var value)) {
    ///     // `value` is of type `NewFloatingScalableMatrixWithTieredPricingPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingScalableMatrixWithTieredPricing(
        [NotNullWhen(true)] out NewFloatingScalableMatrixWithTieredPricingPrice? value
    )
    {
        value = this.Value as NewFloatingScalableMatrixWithTieredPricingPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingCumulativeGroupedBulkPrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingCumulativeGroupedBulk(out var value)) {
    ///     // `value` is of type `NewFloatingCumulativeGroupedBulkPrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingCumulativeGroupedBulk(
        [NotNullWhen(true)] out NewFloatingCumulativeGroupedBulkPrice? value
    )
    {
        value = this.Value as NewFloatingCumulativeGroupedBulkPrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceModelCumulativeGroupedAllocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCumulativeGroupedAllocation(out var value)) {
    ///     // `value` is of type `PriceModelCumulativeGroupedAllocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCumulativeGroupedAllocation(
        [NotNullWhen(true)] out PriceModelCumulativeGroupedAllocation? value
    )
    {
        value = this.Value as PriceModelCumulativeGroupedAllocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewFloatingMinimumCompositePrice"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewFloatingMinimumComposite(out var value)) {
    ///     // `value` is of type `NewFloatingMinimumCompositePrice`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewFloatingMinimumComposite(
        [NotNullWhen(true)] out NewFloatingMinimumCompositePrice? value
    )
    {
        value = this.Value as NewFloatingMinimumCompositePrice;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceModelPercent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPercent(out var value)) {
    ///     // `value` is of type `PriceModelPercent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPercent([NotNullWhen(true)] out PriceModelPercent? value)
    {
        value = this.Value as PriceModelPercent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PriceModelEventOutput"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEventOutput(out var value)) {
    ///     // `value` is of type `PriceModelEventOutput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEventOutput([NotNullWhen(true)] out PriceModelEventOutput? value)
    {
        value = this.Value as PriceModelEventOutput;
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
    ///     (NewFloatingUnitPrice value) => {...},
    ///     (NewFloatingTieredPrice value) => {...},
    ///     (NewFloatingBulkPrice value) => {...},
    ///     (PriceModelBulkWithFilters value) => {...},
    ///     (NewFloatingPackagePrice value) => {...},
    ///     (NewFloatingMatrixPrice value) => {...},
    ///     (NewFloatingThresholdTotalAmountPrice value) => {...},
    ///     (NewFloatingTieredPackagePrice value) => {...},
    ///     (NewFloatingTieredWithMinimumPrice value) => {...},
    ///     (NewFloatingGroupedTieredPrice value) => {...},
    ///     (NewFloatingTieredPackageWithMinimumPrice value) => {...},
    ///     (NewFloatingPackageWithAllocationPrice value) => {...},
    ///     (NewFloatingUnitWithPercentPrice value) => {...},
    ///     (NewFloatingMatrixWithAllocationPrice value) => {...},
    ///     (NewFloatingTieredWithProrationPrice value) => {...},
    ///     (NewFloatingUnitWithProrationPrice value) => {...},
    ///     (NewFloatingGroupedAllocationPrice value) => {...},
    ///     (NewFloatingBulkWithProrationPrice value) => {...},
    ///     (NewFloatingGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewFloatingGroupedWithMeteredMinimumPrice value) => {...},
    ///     (PriceModelGroupedWithMinMaxThresholds value) => {...},
    ///     (NewFloatingMatrixWithDisplayNamePrice value) => {...},
    ///     (NewFloatingGroupedTieredPackagePrice value) => {...},
    ///     (NewFloatingMaxGroupTieredPackagePrice value) => {...},
    ///     (NewFloatingScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewFloatingScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewFloatingCumulativeGroupedBulkPrice value) => {...},
    ///     (PriceModelCumulativeGroupedAllocation value) => {...},
    ///     (NewFloatingMinimumCompositePrice value) => {...},
    ///     (PriceModelPercent value) => {...},
    ///     (PriceModelEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (NewFloatingUnitPrice value) => {...},
    ///     (NewFloatingTieredPrice value) => {...},
    ///     (NewFloatingBulkPrice value) => {...},
    ///     (PriceModelBulkWithFilters value) => {...},
    ///     (NewFloatingPackagePrice value) => {...},
    ///     (NewFloatingMatrixPrice value) => {...},
    ///     (NewFloatingThresholdTotalAmountPrice value) => {...},
    ///     (NewFloatingTieredPackagePrice value) => {...},
    ///     (NewFloatingTieredWithMinimumPrice value) => {...},
    ///     (NewFloatingGroupedTieredPrice value) => {...},
    ///     (NewFloatingTieredPackageWithMinimumPrice value) => {...},
    ///     (NewFloatingPackageWithAllocationPrice value) => {...},
    ///     (NewFloatingUnitWithPercentPrice value) => {...},
    ///     (NewFloatingMatrixWithAllocationPrice value) => {...},
    ///     (NewFloatingTieredWithProrationPrice value) => {...},
    ///     (NewFloatingUnitWithProrationPrice value) => {...},
    ///     (NewFloatingGroupedAllocationPrice value) => {...},
    ///     (NewFloatingBulkWithProrationPrice value) => {...},
    ///     (NewFloatingGroupedWithProratedMinimumPrice value) => {...},
    ///     (NewFloatingGroupedWithMeteredMinimumPrice value) => {...},
    ///     (PriceModelGroupedWithMinMaxThresholds value) => {...},
    ///     (NewFloatingMatrixWithDisplayNamePrice value) => {...},
    ///     (NewFloatingGroupedTieredPackagePrice value) => {...},
    ///     (NewFloatingMaxGroupTieredPackagePrice value) => {...},
    ///     (NewFloatingScalableMatrixWithUnitPricingPrice value) => {...},
    ///     (NewFloatingScalableMatrixWithTieredPricingPrice value) => {...},
    ///     (NewFloatingCumulativeGroupedBulkPrice value) => {...},
    ///     (PriceModelCumulativeGroupedAllocation value) => {...},
    ///     (NewFloatingMinimumCompositePrice value) => {...},
    ///     (PriceModelPercent value) => {...},
    ///     (PriceModelEventOutput value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of PriceModel");
        }
        this.Switch(
            (newFloatingUnit) => newFloatingUnit.Validate(),
            (newFloatingTiered) => newFloatingTiered.Validate(),
            (newFloatingBulk) => newFloatingBulk.Validate(),
            (bulkWithFilters) => bulkWithFilters.Validate(),
            (newFloatingPackage) => newFloatingPackage.Validate(),
            (newFloatingMatrix) => newFloatingMatrix.Validate(),
            (newFloatingThresholdTotalAmount) => newFloatingThresholdTotalAmount.Validate(),
            (newFloatingTieredPackage) => newFloatingTieredPackage.Validate(),
            (newFloatingTieredWithMinimum) => newFloatingTieredWithMinimum.Validate(),
            (newFloatingGroupedTiered) => newFloatingGroupedTiered.Validate(),
            (newFloatingTieredPackageWithMinimum) => newFloatingTieredPackageWithMinimum.Validate(),
            (newFloatingPackageWithAllocation) => newFloatingPackageWithAllocation.Validate(),
            (newFloatingUnitWithPercent) => newFloatingUnitWithPercent.Validate(),
            (newFloatingMatrixWithAllocation) => newFloatingMatrixWithAllocation.Validate(),
            (newFloatingTieredWithProration) => newFloatingTieredWithProration.Validate(),
            (newFloatingUnitWithProration) => newFloatingUnitWithProration.Validate(),
            (newFloatingGroupedAllocation) => newFloatingGroupedAllocation.Validate(),
            (newFloatingBulkWithProration) => newFloatingBulkWithProration.Validate(),
            (newFloatingGroupedWithProratedMinimum) =>
                newFloatingGroupedWithProratedMinimum.Validate(),
            (newFloatingGroupedWithMeteredMinimum) =>
                newFloatingGroupedWithMeteredMinimum.Validate(),
            (groupedWithMinMaxThresholds) => groupedWithMinMaxThresholds.Validate(),
            (newFloatingMatrixWithDisplayName) => newFloatingMatrixWithDisplayName.Validate(),
            (newFloatingGroupedTieredPackage) => newFloatingGroupedTieredPackage.Validate(),
            (newFloatingMaxGroupTieredPackage) => newFloatingMaxGroupTieredPackage.Validate(),
            (newFloatingScalableMatrixWithUnitPricing) =>
                newFloatingScalableMatrixWithUnitPricing.Validate(),
            (newFloatingScalableMatrixWithTieredPricing) =>
                newFloatingScalableMatrixWithTieredPricing.Validate(),
            (newFloatingCumulativeGroupedBulk) => newFloatingCumulativeGroupedBulk.Validate(),
            (cumulativeGroupedAllocation) => cumulativeGroupedAllocation.Validate(),
            (newFloatingMinimumComposite) => newFloatingMinimumComposite.Validate(),
            (percent) => percent.Validate(),
            (eventOutput) => eventOutput.Validate()
        );
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingBulkPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<PriceModelBulkWithFilters>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingPackagePrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMatrixPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingThresholdTotalAmountPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackagePrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedTieredPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPrice>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitWithPercentPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingMatrixWithAllocationPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingTieredWithProrationPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingUnitWithProrationPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedAllocationPrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingBulkWithProrationPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPrice>(
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
                        JsonSerializer.Deserialize<PriceModelGroupedWithMinMaxThresholds>(
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
                        JsonSerializer.Deserialize<NewFloatingMatrixWithDisplayNamePrice>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedTieredPackagePrice>(
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
                        JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePrice>(
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithUnitPricingPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithTieredPricingPrice>(
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
                        JsonSerializer.Deserialize<NewFloatingCumulativeGroupedBulkPrice>(
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
                        JsonSerializer.Deserialize<PriceModelCumulativeGroupedAllocation>(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMinimumCompositePrice>(
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
                    var deserialized = JsonSerializer.Deserialize<PriceModelPercent>(
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
                    var deserialized = JsonSerializer.Deserialize<PriceModelEventOutput>(
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
                return new PriceModel(element);
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

[JsonConverter(
    typeof(JsonModelConverter<PriceModelBulkWithFilters, PriceModelBulkWithFiltersFromRaw>)
)]
public sealed record class PriceModelBulkWithFilters : JsonModel
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required PriceModelBulkWithFiltersBulkWithFiltersConfig BulkWithFiltersConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceModelBulkWithFiltersBulkWithFiltersConfig>(
                this.RawData,
                "bulk_with_filters_config"
            );
        }
        init { JsonModel.Set(this._rawData, "bulk_with_filters_config", value); }
    }

    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelBulkWithFiltersCadence> Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, PriceModelBulkWithFiltersCadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceModelBulkWithFiltersConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceModelBulkWithFiltersConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BulkWithFiltersConfig.Validate();
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"")
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelBulkWithFilters()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    public PriceModelBulkWithFilters(PriceModelBulkWithFilters priceModelBulkWithFilters)
        : base(priceModelBulkWithFilters) { }

    public PriceModelBulkWithFilters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelBulkWithFilters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceModelBulkWithFiltersFromRaw.FromRawUnchecked"/>
    public static PriceModelBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelBulkWithFiltersFromRaw : IFromRawJson<PriceModelBulkWithFilters>
{
    /// <inheritdoc/>
    public PriceModelBulkWithFilters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelBulkWithFilters.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PriceModelBulkWithFiltersBulkWithFiltersConfig,
        PriceModelBulkWithFiltersBulkWithFiltersConfigFromRaw
    >)
)]
public sealed record class PriceModelBulkWithFiltersBulkWithFiltersConfig : JsonModel
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required IReadOnlyList<PriceModelBulkWithFiltersBulkWithFiltersConfigFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<PriceModelBulkWithFiltersBulkWithFiltersConfigFilter>
            >(this.RawData, "filters");
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Bulk tiers for rating based on total usage volume
    /// </summary>
    public required IReadOnlyList<PriceModelBulkWithFiltersBulkWithFiltersConfigTier> Tiers
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<PriceModelBulkWithFiltersBulkWithFiltersConfigTier>
            >(this.RawData, "tiers");
        }
        init { JsonModel.Set(this._rawData, "tiers", value); }
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

    public PriceModelBulkWithFiltersBulkWithFiltersConfig() { }

    public PriceModelBulkWithFiltersBulkWithFiltersConfig(
        PriceModelBulkWithFiltersBulkWithFiltersConfig priceModelBulkWithFiltersBulkWithFiltersConfig
    )
        : base(priceModelBulkWithFiltersBulkWithFiltersConfig) { }

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

    /// <inheritdoc cref="PriceModelBulkWithFiltersBulkWithFiltersConfigFromRaw.FromRawUnchecked"/>
    public static PriceModelBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelBulkWithFiltersBulkWithFiltersConfigFromRaw
    : IFromRawJson<PriceModelBulkWithFiltersBulkWithFiltersConfig>
{
    /// <inheritdoc/>
    public PriceModelBulkWithFiltersBulkWithFiltersConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelBulkWithFiltersBulkWithFiltersConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PriceModelBulkWithFiltersBulkWithFiltersConfigFilter,
        PriceModelBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    >)
)]
public sealed record class PriceModelBulkWithFiltersBulkWithFiltersConfigFilter : JsonModel
{
    /// <summary>
    /// Event property key to filter on
    /// </summary>
    public required string PropertyKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "property_key"); }
        init { JsonModel.Set(this._rawData, "property_key", value); }
    }

    /// <summary>
    /// Event property value to match
    /// </summary>
    public required string PropertyValue
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "property_value"); }
        init { JsonModel.Set(this._rawData, "property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public PriceModelBulkWithFiltersBulkWithFiltersConfigFilter() { }

    public PriceModelBulkWithFiltersBulkWithFiltersConfigFilter(
        PriceModelBulkWithFiltersBulkWithFiltersConfigFilter priceModelBulkWithFiltersBulkWithFiltersConfigFilter
    )
        : base(priceModelBulkWithFiltersBulkWithFiltersConfigFilter) { }

    public PriceModelBulkWithFiltersBulkWithFiltersConfigFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelBulkWithFiltersBulkWithFiltersConfigFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceModelBulkWithFiltersBulkWithFiltersConfigFilterFromRaw.FromRawUnchecked"/>
    public static PriceModelBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelBulkWithFiltersBulkWithFiltersConfigFilterFromRaw
    : IFromRawJson<PriceModelBulkWithFiltersBulkWithFiltersConfigFilter>
{
    /// <inheritdoc/>
    public PriceModelBulkWithFiltersBulkWithFiltersConfigFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelBulkWithFiltersBulkWithFiltersConfigFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PriceModelBulkWithFiltersBulkWithFiltersConfigTier,
        PriceModelBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    >)
)]
public sealed record class PriceModelBulkWithFiltersBulkWithFiltersConfigTier : JsonModel
{
    /// <summary>
    /// Amount per unit
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <summary>
    /// The lower bound for this tier
    /// </summary>
    public string? TierLowerBound
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "tier_lower_bound"); }
        init { JsonModel.Set(this._rawData, "tier_lower_bound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitAmount;
        _ = this.TierLowerBound;
    }

    public PriceModelBulkWithFiltersBulkWithFiltersConfigTier() { }

    public PriceModelBulkWithFiltersBulkWithFiltersConfigTier(
        PriceModelBulkWithFiltersBulkWithFiltersConfigTier priceModelBulkWithFiltersBulkWithFiltersConfigTier
    )
        : base(priceModelBulkWithFiltersBulkWithFiltersConfigTier) { }

    public PriceModelBulkWithFiltersBulkWithFiltersConfigTier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelBulkWithFiltersBulkWithFiltersConfigTier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceModelBulkWithFiltersBulkWithFiltersConfigTierFromRaw.FromRawUnchecked"/>
    public static PriceModelBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PriceModelBulkWithFiltersBulkWithFiltersConfigTier(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

class PriceModelBulkWithFiltersBulkWithFiltersConfigTierFromRaw
    : IFromRawJson<PriceModelBulkWithFiltersBulkWithFiltersConfigTier>
{
    /// <inheritdoc/>
    public PriceModelBulkWithFiltersBulkWithFiltersConfigTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelBulkWithFiltersBulkWithFiltersConfigTier.FromRawUnchecked(rawData);
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

[JsonConverter(typeof(PriceModelBulkWithFiltersConversionRateConfigConverter))]
public record class PriceModelBulkWithFiltersConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelBulkWithFiltersConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelBulkWithFiltersConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelBulkWithFiltersConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of PriceModelBulkWithFiltersConversionRateConfig"
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelBulkWithFiltersConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
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
                return new PriceModelBulkWithFiltersConversionRateConfig(element);
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
    typeof(JsonModelConverter<
        PriceModelGroupedWithMinMaxThresholds,
        PriceModelGroupedWithMinMaxThresholdsFromRaw
    >)
)]
public sealed record class PriceModelGroupedWithMinMaxThresholds : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelGroupedWithMinMaxThresholdsCadence> Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PriceModelGroupedWithMinMaxThresholdsCadence>
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig GroupedWithMinMaxThresholdsConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>(
                this.RawData,
                "grouped_with_min_max_thresholds_config"
            );
        }
        init { JsonModel.Set(this._rawData, "grouped_with_min_max_thresholds_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceModelGroupedWithMinMaxThresholdsConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceModelGroupedWithMinMaxThresholdsConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.GroupedWithMinMaxThresholdsConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"")
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelGroupedWithMinMaxThresholds()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

    public PriceModelGroupedWithMinMaxThresholds(
        PriceModelGroupedWithMinMaxThresholds priceModelGroupedWithMinMaxThresholds
    )
        : base(priceModelGroupedWithMinMaxThresholds) { }

    public PriceModelGroupedWithMinMaxThresholds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"grouped_with_min_max_thresholds\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelGroupedWithMinMaxThresholds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceModelGroupedWithMinMaxThresholdsFromRaw.FromRawUnchecked"/>
    public static PriceModelGroupedWithMinMaxThresholds FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelGroupedWithMinMaxThresholdsFromRaw
    : IFromRawJson<PriceModelGroupedWithMinMaxThresholds>
{
    /// <inheritdoc/>
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
    typeof(JsonModelConverter<
        PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig,
        PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    >)
)]
public sealed record class PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    : JsonModel
{
    /// <summary>
    /// The event property used to group before applying thresholds
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The maximum amount to charge each group
    /// </summary>
    public required string MaximumCharge
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "maximum_charge"); }
        init { JsonModel.Set(this._rawData, "maximum_charge", value); }
    }

    /// <summary>
    /// The minimum amount to charge each group, regardless of usage
    /// </summary>
    public required string MinimumCharge
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "minimum_charge"); }
        init { JsonModel.Set(this._rawData, "minimum_charge", value); }
    }

    /// <summary>
    /// The base price charged per group
    /// </summary>
    public required string PerUnitRate
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "per_unit_rate"); }
        init { JsonModel.Set(this._rawData, "per_unit_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupingKey;
        _ = this.MaximumCharge;
        _ = this.MinimumCharge;
        _ = this.PerUnitRate;
    }

    public PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig() { }

    public PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig(
        PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig priceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig
    )
        : base(priceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig) { }

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

    /// <inheritdoc cref="PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw.FromRawUnchecked"/>
    public static PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfigFromRaw
    : IFromRawJson<PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig>
{
    /// <inheritdoc/>
    public PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceModelGroupedWithMinMaxThresholdsGroupedWithMinMaxThresholdsConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(PriceModelGroupedWithMinMaxThresholdsConversionRateConfigConverter))]
public record class PriceModelGroupedWithMinMaxThresholdsConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of PriceModelGroupedWithMinMaxThresholdsConversionRateConfig"
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelGroupedWithMinMaxThresholdsConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
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
                return new PriceModelGroupedWithMinMaxThresholdsConversionRateConfig(element);
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
    typeof(JsonModelConverter<
        PriceModelCumulativeGroupedAllocation,
        PriceModelCumulativeGroupedAllocationFromRaw
    >)
)]
public sealed record class PriceModelCumulativeGroupedAllocation : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelCumulativeGroupedAllocationCadence> Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, PriceModelCumulativeGroupedAllocationCadence>
            >(this.RawData, "cadence");
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// Configuration for cumulative_grouped_allocation pricing
    /// </summary>
    public required PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig CumulativeGroupedAllocationConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>(
                this.RawData,
                "cumulative_grouped_allocation_config"
            );
        }
        init { JsonModel.Set(this._rawData, "cumulative_grouped_allocation_config", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceModelCumulativeGroupedAllocationConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceModelCumulativeGroupedAllocationConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        this.CumulativeGroupedAllocationConfig.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"cumulative_grouped_allocation\"")
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelCumulativeGroupedAllocation()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

    public PriceModelCumulativeGroupedAllocation(
        PriceModelCumulativeGroupedAllocation priceModelCumulativeGroupedAllocation
    )
        : base(priceModelCumulativeGroupedAllocation) { }

    public PriceModelCumulativeGroupedAllocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>(
            "\"cumulative_grouped_allocation\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelCumulativeGroupedAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceModelCumulativeGroupedAllocationFromRaw.FromRawUnchecked"/>
    public static PriceModelCumulativeGroupedAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelCumulativeGroupedAllocationFromRaw
    : IFromRawJson<PriceModelCumulativeGroupedAllocation>
{
    /// <inheritdoc/>
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
    typeof(JsonModelConverter<
        PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig,
        PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    >)
)]
public sealed record class PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    : JsonModel
{
    /// <summary>
    /// The overall allocation across all groups
    /// </summary>
    public required string CumulativeAllocation
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "cumulative_allocation"); }
        init { JsonModel.Set(this._rawData, "cumulative_allocation", value); }
    }

    /// <summary>
    /// The allocation per individual group
    /// </summary>
    public required string GroupAllocation
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "group_allocation"); }
        init { JsonModel.Set(this._rawData, "group_allocation", value); }
    }

    /// <summary>
    /// The event property used to group usage before applying allocations
    /// </summary>
    public required string GroupingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <summary>
    /// The amount to charge for each unit outside of the allocation
    /// </summary>
    public required string UnitAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { JsonModel.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CumulativeAllocation;
        _ = this.GroupAllocation;
        _ = this.GroupingKey;
        _ = this.UnitAmount;
    }

    public PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig() { }

    public PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig(
        PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig priceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig
    )
        : base(priceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig) { }

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

    /// <inheritdoc cref="PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw.FromRawUnchecked"/>
    public static PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfigFromRaw
    : IFromRawJson<PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig>
{
    /// <inheritdoc/>
    public PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        PriceModelCumulativeGroupedAllocationCumulativeGroupedAllocationConfig.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(typeof(PriceModelCumulativeGroupedAllocationConversionRateConfigConverter))]
public record class PriceModelCumulativeGroupedAllocationConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelCumulativeGroupedAllocationConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelCumulativeGroupedAllocationConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelCumulativeGroupedAllocationConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of PriceModelCumulativeGroupedAllocationConversionRateConfig"
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelCumulativeGroupedAllocationConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
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
                return new PriceModelCumulativeGroupedAllocationConversionRateConfig(element);
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

[JsonConverter(typeof(JsonModelConverter<PriceModelPercent, PriceModelPercentFromRaw>))]
public sealed record class PriceModelPercent : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelPercentCadence> Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, PriceModelPercentCadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Configuration for percent pricing
    /// </summary>
    public required PriceModelPercentPercentConfig PercentConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceModelPercentPercentConfig>(
                this.RawData,
                "percent_config"
            );
        }
        init { JsonModel.Set(this._rawData, "percent_config", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceModelPercentConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceModelPercentConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"percent\"")
            )
        )
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelPercent()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    public PriceModelPercent(PriceModelPercent priceModelPercent)
        : base(priceModelPercent) { }

    public PriceModelPercent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelPercent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceModelPercentFromRaw.FromRawUnchecked"/>
    public static PriceModelPercent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelPercentFromRaw : IFromRawJson<PriceModelPercent>
{
    /// <inheritdoc/>
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
/// Configuration for percent pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PriceModelPercentPercentConfig,
        PriceModelPercentPercentConfigFromRaw
    >)
)]
public sealed record class PriceModelPercentPercentConfig : JsonModel
{
    /// <summary>
    /// What percent of the component subtotals to charge
    /// </summary>
    public required double Percent
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "percent"); }
        init { JsonModel.Set(this._rawData, "percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
    }

    public PriceModelPercentPercentConfig() { }

    public PriceModelPercentPercentConfig(
        PriceModelPercentPercentConfig priceModelPercentPercentConfig
    )
        : base(priceModelPercentPercentConfig) { }

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

    /// <inheritdoc cref="PriceModelPercentPercentConfigFromRaw.FromRawUnchecked"/>
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

class PriceModelPercentPercentConfigFromRaw : IFromRawJson<PriceModelPercentPercentConfig>
{
    /// <inheritdoc/>
    public PriceModelPercentPercentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelPercentPercentConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PriceModelPercentConversionRateConfigConverter))]
public record class PriceModelPercentConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelPercentConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelPercentConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelPercentConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of PriceModelPercentConversionRateConfig"
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelPercentConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
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
                return new PriceModelPercentConversionRateConfig(element);
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

[JsonConverter(typeof(JsonModelConverter<PriceModelEventOutput, PriceModelEventOutputFromRaw>))]
public sealed record class PriceModelEventOutput : JsonModel
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, PriceModelEventOutputCadence> Cadence
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, PriceModelEventOutputCadence>>(
                this.RawData,
                "cadence"
            );
        }
        init { JsonModel.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Configuration for event_output pricing
    /// </summary>
    public required PriceModelEventOutputEventOutputConfig EventOutputConfig
    {
        get
        {
            return JsonModel.GetNotNullClass<PriceModelEventOutputEventOutputConfig>(
                this.RawData,
                "event_output_config"
            );
        }
        init { JsonModel.Set(this._rawData, "event_output_config", value); }
    }

    /// <summary>
    /// The id of the item the price will be associated with.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The pricing model type
    /// </summary>
    public JsonElement ModelType
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "model_type"); }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the price.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The id of the billable metric for the price. Only needed if the price is usage-based.
    /// </summary>
    public string? BillableMetricID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "billable_metric_id"); }
        init { JsonModel.Set(this._rawData, "billable_metric_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, the price will be billed in-advance
    /// if this is true, and in-arrears if this is false.
    /// </summary>
    public bool? BilledInAdvance
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "billed_in_advance"); }
        init { JsonModel.Set(this._rawData, "billed_in_advance", value); }
    }

    /// <summary>
    /// For custom cadence: specifies the duration of the billing period in days
    /// or months.
    /// </summary>
    public NewBillingCycleConfiguration? BillingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "billing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "billing_cycle_configuration", value); }
    }

    /// <summary>
    /// The per unit conversion rate of the price currency to the invoicing currency.
    /// </summary>
    public double? ConversionRate
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "conversion_rate"); }
        init { JsonModel.Set(this._rawData, "conversion_rate", value); }
    }

    /// <summary>
    /// The configuration for the rate of the price currency to the invoicing currency.
    /// </summary>
    public PriceModelEventOutputConversionRateConfig? ConversionRateConfig
    {
        get
        {
            return JsonModel.GetNullableClass<PriceModelEventOutputConversionRateConfig>(
                this.RawData,
                "conversion_rate_config"
            );
        }
        init { JsonModel.Set(this._rawData, "conversion_rate_config", value); }
    }

    /// <summary>
    /// For dimensional price: specifies a price group and dimension values
    /// </summary>
    public NewDimensionalPriceConfiguration? DimensionalPriceConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewDimensionalPriceConfiguration>(
                this.RawData,
                "dimensional_price_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_configuration", value); }
    }

    /// <summary>
    /// An alias for the price.
    /// </summary>
    public string? ExternalPriceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_price_id"); }
        init { JsonModel.Set(this._rawData, "external_price_id", value); }
    }

    /// <summary>
    /// If the Price represents a fixed cost, this represents the quantity of units applied.
    /// </summary>
    public double? FixedPriceQuantity
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "fixed_price_quantity"); }
        init { JsonModel.Set(this._rawData, "fixed_price_quantity", value); }
    }

    /// <summary>
    /// The property used to group this price on an invoice
    /// </summary>
    public string? InvoiceGroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_grouping_key"); }
        init { JsonModel.Set(this._rawData, "invoice_grouping_key", value); }
    }

    /// <summary>
    /// Within each billing cycle, specifies the cadence at which invoices are produced.
    /// If unspecified, a single invoice is produced per billing cycle.
    /// </summary>
    public NewBillingCycleConfiguration? InvoicingCycleConfiguration
    {
        get
        {
            return JsonModel.GetNullableClass<NewBillingCycleConfiguration>(
                this.RawData,
                "invoicing_cycle_configuration"
            );
        }
        init { JsonModel.Set(this._rawData, "invoicing_cycle_configuration", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cadence.Validate();
        _ = this.Currency;
        this.EventOutputConfig.Validate();
        _ = this.ItemID;
        if (
            !JsonElement.DeepEquals(
                this.ModelType,
                JsonSerializer.Deserialize<JsonElement>("\"event_output\"")
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
        this.DimensionalPriceConfiguration?.Validate();
        _ = this.ExternalPriceID;
        _ = this.FixedPriceQuantity;
        _ = this.InvoiceGroupingKey;
        this.InvoicingCycleConfiguration?.Validate();
        _ = this.Metadata;
    }

    public PriceModelEventOutput()
    {
        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    public PriceModelEventOutput(PriceModelEventOutput priceModelEventOutput)
        : base(priceModelEventOutput) { }

    public PriceModelEventOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.ModelType = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceModelEventOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceModelEventOutputFromRaw.FromRawUnchecked"/>
    public static PriceModelEventOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceModelEventOutputFromRaw : IFromRawJson<PriceModelEventOutput>
{
    /// <inheritdoc/>
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
    typeof(JsonModelConverter<
        PriceModelEventOutputEventOutputConfig,
        PriceModelEventOutputEventOutputConfigFromRaw
    >)
)]
public sealed record class PriceModelEventOutputEventOutputConfig : JsonModel
{
    /// <summary>
    /// The key in the event data to extract the unit rate from.
    /// </summary>
    public required string UnitRatingKey
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "unit_rating_key"); }
        init { JsonModel.Set(this._rawData, "unit_rating_key", value); }
    }

    /// <summary>
    /// If provided, this amount will be used as the unit rate when an event does
    /// not have a value for the `unit_rating_key`. If not provided, events missing
    /// a unit rate will be ignored.
    /// </summary>
    public string? DefaultUnitRate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "default_unit_rate"); }
        init { JsonModel.Set(this._rawData, "default_unit_rate", value); }
    }

    /// <summary>
    /// An optional key in the event data to group by (e.g., event ID). All events
    /// will also be grouped by their unit rate.
    /// </summary>
    public string? GroupingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "grouping_key"); }
        init { JsonModel.Set(this._rawData, "grouping_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UnitRatingKey;
        _ = this.DefaultUnitRate;
        _ = this.GroupingKey;
    }

    public PriceModelEventOutputEventOutputConfig() { }

    public PriceModelEventOutputEventOutputConfig(
        PriceModelEventOutputEventOutputConfig priceModelEventOutputEventOutputConfig
    )
        : base(priceModelEventOutputEventOutputConfig) { }

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

    /// <inheritdoc cref="PriceModelEventOutputEventOutputConfigFromRaw.FromRawUnchecked"/>
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
    : IFromRawJson<PriceModelEventOutputEventOutputConfig>
{
    /// <inheritdoc/>
    public PriceModelEventOutputEventOutputConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PriceModelEventOutputEventOutputConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PriceModelEventOutputConversionRateConfigConverter))]
public record class PriceModelEventOutputConversionRateConfig
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public PriceModelEventOutputConversionRateConfig(
        SharedUnitConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelEventOutputConversionRateConfig(
        SharedTieredConversionRateConfig value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public PriceModelEventOutputConversionRateConfig(JsonElement element)
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
                    "Data did not match any variant of PriceModelEventOutputConversionRateConfig"
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of PriceModelEventOutputConversionRateConfig"
            );
        }
        this.Switch((unit) => unit.Validate(), (tiered) => tiered.Validate());
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
                return new PriceModelEventOutputConversionRateConfig(element);
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

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionPriceIntervalsParamsAddAdjustment,
        SubscriptionPriceIntervalsParamsAddAdjustmentFromRaw
    >)
)]
public sealed record class SubscriptionPriceIntervalsParamsAddAdjustment : JsonModel
{
    /// <summary>
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `start_date`. This `start_date` is
    /// treated as inclusive for in-advance prices, and exclusive for in-arrears prices.
    /// </summary>
    public required SubscriptionPriceIntervalsParamsAddAdjustmentStartDate StartDate
    {
        get
        {
            return JsonModel.GetNotNullClass<SubscriptionPriceIntervalsParamsAddAdjustmentStartDate>(
                this.RawData,
                "start_date"
            );
        }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment? Adjustment
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment>(
                this.RawData,
                "adjustment"
            );
        }
        init { JsonModel.Set(this._rawData, "adjustment", value); }
    }

    /// <summary>
    /// The ID of the adjustment to add to the subscription. Adjustment IDs can be
    /// re-used from existing subscriptions or plans, but adjustments associated with
    /// coupon redemptions cannot be re-used.
    /// </summary>
    public string? AdjustmentID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "adjustment_id"); }
        init { JsonModel.Set(this._rawData, "adjustment_id", value); }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `end_date`.This `end_date` is treated
    /// as exclusive for in-advance prices, and inclusive for in-arrears prices.
    /// </summary>
    public SubscriptionPriceIntervalsParamsAddAdjustmentEndDate? EndDate
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionPriceIntervalsParamsAddAdjustmentEndDate>(
                this.RawData,
                "end_date"
            );
        }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.StartDate.Validate();
        this.Adjustment?.Validate();
        _ = this.AdjustmentID;
        this.EndDate?.Validate();
    }

    public SubscriptionPriceIntervalsParamsAddAdjustment() { }

    public SubscriptionPriceIntervalsParamsAddAdjustment(
        SubscriptionPriceIntervalsParamsAddAdjustment subscriptionPriceIntervalsParamsAddAdjustment
    )
        : base(subscriptionPriceIntervalsParamsAddAdjustment) { }

    public SubscriptionPriceIntervalsParamsAddAdjustment(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionPriceIntervalsParamsAddAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionPriceIntervalsParamsAddAdjustmentFromRaw.FromRawUnchecked"/>
    public static SubscriptionPriceIntervalsParamsAddAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionPriceIntervalsParamsAddAdjustment(
        SubscriptionPriceIntervalsParamsAddAdjustmentStartDate startDate
    )
        : this()
    {
        this.StartDate = startDate;
    }
}

class SubscriptionPriceIntervalsParamsAddAdjustmentFromRaw
    : IFromRawJson<SubscriptionPriceIntervalsParamsAddAdjustment>
{
    /// <inheritdoc/>
    public SubscriptionPriceIntervalsParamsAddAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionPriceIntervalsParamsAddAdjustment.FromRawUnchecked(rawData);
}

/// <summary>
/// The start date of the adjustment interval. This is the date that the adjustment
/// will start affecting prices on the subscription. The adjustment will apply to
/// invoice dates that overlap with this `start_date`. This `start_date` is treated
/// as inclusive for in-advance prices, and exclusive for in-arrears prices.
/// </summary>
[JsonConverter(typeof(SubscriptionPriceIntervalsParamsAddAdjustmentStartDateConverter))]
public record class SubscriptionPriceIntervalsParamsAddAdjustmentStartDate
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentStartDate(
        System::DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentStartDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, BillingCycleRelativeDate>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingCycleRelative(out var value)) {
    ///     // `value` is of type `ApiEnum<string, BillingCycleRelativeDate>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentStartDate"
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentStartDate"
            ),
        };
    }

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentStartDate(
        System::DateTimeOffset value
    ) => new(value);

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value
    ) => new(value);

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentStartDate(
        BillingCycleRelativeDate value
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentStartDate"
            );
        }
        this.Switch((_) => { }, (billingCycleRelative) => billingCycleRelative.Validate());
    }

    public virtual bool Equals(SubscriptionPriceIntervalsParamsAddAdjustmentStartDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionPriceIntervalsParamsAddAdjustmentStartDateConverter
    : JsonConverter<SubscriptionPriceIntervalsParamsAddAdjustmentStartDate>
{
    public override SubscriptionPriceIntervalsParamsAddAdjustmentStartDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPriceIntervalsParamsAddAdjustmentStartDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(SubscriptionPriceIntervalsParamsAddAdjustmentAdjustmentConverter))]
public record class SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment
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

    public SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewPercentageDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewUsageDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewAmountDiscount value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewMinimum value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewMaximum value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(JsonElement element)
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
                    "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment"
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
                "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment"
            ),
        };
    }

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewPercentageDiscount value
    ) => new(value);

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewUsageDiscount value
    ) => new(value);

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewAmountDiscount value
    ) => new(value);

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewMinimum value
    ) => new(value);

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(
        NewMaximum value
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment"
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

    public virtual bool Equals(SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionPriceIntervalsParamsAddAdjustmentAdjustmentConverter
    : JsonConverter<SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment?>
{
    public override SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment? Read(
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
                return new SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPriceIntervalsParamsAddAdjustmentAdjustment? value,
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
[JsonConverter(typeof(SubscriptionPriceIntervalsParamsAddAdjustmentEndDateConverter))]
public record class SubscriptionPriceIntervalsParamsAddAdjustmentEndDate
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentEndDate(
        System::DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentEndDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionPriceIntervalsParamsAddAdjustmentEndDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, BillingCycleRelativeDate>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingCycleRelative(out var value)) {
    ///     // `value` is of type `ApiEnum<string, BillingCycleRelativeDate>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentEndDate"
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentEndDate"
            ),
        };
    }

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentEndDate(
        System::DateTimeOffset value
    ) => new(value);

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentEndDate(
        ApiEnum<string, BillingCycleRelativeDate> value
    ) => new(value);

    public static implicit operator SubscriptionPriceIntervalsParamsAddAdjustmentEndDate(
        BillingCycleRelativeDate value
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionPriceIntervalsParamsAddAdjustmentEndDate"
            );
        }
        this.Switch((_) => { }, (billingCycleRelative) => billingCycleRelative.Validate());
    }

    public virtual bool Equals(SubscriptionPriceIntervalsParamsAddAdjustmentEndDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SubscriptionPriceIntervalsParamsAddAdjustmentEndDateConverter
    : JsonConverter<SubscriptionPriceIntervalsParamsAddAdjustmentEndDate?>
{
    public override SubscriptionPriceIntervalsParamsAddAdjustmentEndDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionPriceIntervalsParamsAddAdjustmentEndDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Edit, EditFromRaw>))]
public sealed record class Edit : JsonModel
{
    /// <summary>
    /// The id of the price interval to edit.
    /// </summary>
    public required string PriceIntervalID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "price_interval_id"); }
        init { JsonModel.Set(this._rawData, "price_interval_id", value); }
    }

    /// <summary>
    /// The updated billing cycle day for this price interval. If not specified,
    /// the billing cycle day will not be updated. Note that overlapping price intervals
    /// must have the same billing cycle day.
    /// </summary>
    public long? BillingCycleDay
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "billing_cycle_day"); }
        init { JsonModel.Set(this._rawData, "billing_cycle_day", value); }
    }

    /// <summary>
    /// If true, an in-arrears price interval ending mid-cycle will defer billing
    /// the final line item until the next scheduled invoice. If false, it will be
    /// billed on its end date.
    /// </summary>
    public bool? CanDeferBilling
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "can_defer_billing"); }
        init { JsonModel.Set(this._rawData, "can_defer_billing", value); }
    }

    /// <summary>
    /// The updated end date of this price interval. If not specified, the end date
    /// will not be updated.
    /// </summary>
    public EditEndDate? EndDate
    {
        get { return JsonModel.GetNullableClass<EditEndDate>(this.RawData, "end_date"); }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "filter"); }
        init { JsonModel.Set(this._rawData, "filter", value); }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to use for this price interval. Note
    /// that this list will overwrite all existing fixed fee quantity transitions
    /// on the price interval.
    /// </summary>
    public IReadOnlyList<EditFixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            return JsonModel.GetNullableClass<List<EditFixedFeeQuantityTransition>>(
                this.RawData,
                "fixed_fee_quantity_transitions"
            );
        }
        init { JsonModel.Set(this._rawData, "fixed_fee_quantity_transitions", value); }
    }

    /// <summary>
    /// The updated start date of this price interval. If not specified, the start
    /// date will not be updated.
    /// </summary>
    public EditStartDate? StartDate
    {
        get { return JsonModel.GetNullableClass<EditStartDate>(this.RawData, "start_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "start_date", value);
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
    public IReadOnlyList<string>? UsageCustomerIds
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "usage_customer_ids"); }
        init { JsonModel.Set(this._rawData, "usage_customer_ids", value); }
    }

    /// <inheritdoc/>
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
        _ = this.UsageCustomerIds;
    }

    public Edit() { }

    public Edit(Edit edit)
        : base(edit) { }

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

    /// <inheritdoc cref="EditFromRaw.FromRawUnchecked"/>
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

class EditFromRaw : IFromRawJson<Edit>
{
    /// <inheritdoc/>
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

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EditEndDate(System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EditEndDate(ApiEnum<string, BillingCycleRelativeDate> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EditEndDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, BillingCycleRelativeDate>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingCycleRelative(out var value)) {
    ///     // `value` is of type `ApiEnum<string, BillingCycleRelativeDate>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EditEndDate");
        }
        this.Switch((_) => { }, (billingCycleRelative) => billingCycleRelative.Validate());
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
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
    typeof(JsonModelConverter<
        EditFixedFeeQuantityTransition,
        EditFixedFeeQuantityTransitionFromRaw
    >)
)]
public sealed record class EditFixedFeeQuantityTransition : JsonModel
{
    /// <summary>
    /// The date that the fixed fee quantity transition should take effect.
    /// </summary>
    public required System::DateTimeOffset EffectiveDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "effective_date"
            );
        }
        init { JsonModel.Set(this._rawData, "effective_date", value); }
    }

    /// <summary>
    /// The quantity of the fixed fee quantity transition.
    /// </summary>
    public required long Quantity
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.Quantity;
    }

    public EditFixedFeeQuantityTransition() { }

    public EditFixedFeeQuantityTransition(
        EditFixedFeeQuantityTransition editFixedFeeQuantityTransition
    )
        : base(editFixedFeeQuantityTransition) { }

    public EditFixedFeeQuantityTransition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EditFixedFeeQuantityTransition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EditFixedFeeQuantityTransitionFromRaw.FromRawUnchecked"/>
    public static EditFixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EditFixedFeeQuantityTransitionFromRaw : IFromRawJson<EditFixedFeeQuantityTransition>
{
    /// <inheritdoc/>
    public EditFixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EditFixedFeeQuantityTransition.FromRawUnchecked(rawData);
}

/// <summary>
/// The updated start date of this price interval. If not specified, the start date
/// will not be updated.
/// </summary>
[JsonConverter(typeof(EditStartDateConverter))]
public record class EditStartDate
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EditStartDate(System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EditStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EditStartDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, BillingCycleRelativeDate>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingCycleRelative(out var value)) {
    ///     // `value` is of type `ApiEnum<string, BillingCycleRelativeDate>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EditStartDate");
        }
        this.Switch((_) => { }, (billingCycleRelative) => billingCycleRelative.Validate());
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
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

[JsonConverter(typeof(JsonModelConverter<EditAdjustment, EditAdjustmentFromRaw>))]
public sealed record class EditAdjustment : JsonModel
{
    /// <summary>
    /// The id of the adjustment interval to edit.
    /// </summary>
    public required string AdjustmentIntervalID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "adjustment_interval_id"); }
        init { JsonModel.Set(this._rawData, "adjustment_interval_id", value); }
    }

    /// <summary>
    /// The updated end date of this adjustment interval. If not specified, the end
    /// date will not be updated.
    /// </summary>
    public EditAdjustmentEndDate? EndDate
    {
        get { return JsonModel.GetNullableClass<EditAdjustmentEndDate>(this.RawData, "end_date"); }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The updated start date of this adjustment interval. If not specified, the
    /// start date will not be updated.
    /// </summary>
    public EditAdjustmentStartDate? StartDate
    {
        get
        {
            return JsonModel.GetNullableClass<EditAdjustmentStartDate>(this.RawData, "start_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "start_date", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdjustmentIntervalID;
        this.EndDate?.Validate();
        this.StartDate?.Validate();
    }

    public EditAdjustment() { }

    public EditAdjustment(EditAdjustment editAdjustment)
        : base(editAdjustment) { }

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

    /// <inheritdoc cref="EditAdjustmentFromRaw.FromRawUnchecked"/>
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

class EditAdjustmentFromRaw : IFromRawJson<EditAdjustment>
{
    /// <inheritdoc/>
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

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EditAdjustmentEndDate(System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EditAdjustmentEndDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EditAdjustmentEndDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, BillingCycleRelativeDate>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingCycleRelative(out var value)) {
    ///     // `value` is of type `ApiEnum<string, BillingCycleRelativeDate>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of EditAdjustmentEndDate"
            );
        }
        this.Switch((_) => { }, (billingCycleRelative) => billingCycleRelative.Validate());
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
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

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public EditAdjustmentStartDate(System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EditAdjustmentStartDate(
        ApiEnum<string, BillingCycleRelativeDate> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EditAdjustmentStartDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, BillingCycleRelativeDate>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingCycleRelative(out var value)) {
    ///     // `value` is of type `ApiEnum<string, BillingCycleRelativeDate>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingCycleRelative(
        [NotNullWhen(true)] out ApiEnum<string, BillingCycleRelativeDate>? value
    )
    {
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>;
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, BillingCycleRelativeDate> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of EditAdjustmentStartDate"
            );
        }
        this.Switch((_) => { }, (billingCycleRelative) => billingCycleRelative.Validate());
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BillingCycleRelativeDate>
            >(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
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
