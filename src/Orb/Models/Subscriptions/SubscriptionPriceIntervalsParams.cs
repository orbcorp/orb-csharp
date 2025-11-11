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
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string SubscriptionID { get; init; }

    /// <summary>
    /// A list of price intervals to add to the subscription.
    /// </summary>
    public List<Add>? Add
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("add", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Add>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["add"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of adjustments to add to the subscription.
    /// </summary>
    public List<AddAdjustmentModel>? AddAdjustments
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("add_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AddAdjustmentModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["add_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (
                !this._bodyProperties.TryGetValue(
                    "allow_invoice_credit_or_void",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["allow_invoice_credit_or_void"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// If true, ending an in-arrears price interval mid-cycle will defer billing
    /// the final line itemuntil the next scheduled invoice. If false, it will be
    /// billed on its end date. If not provided, behaviorwill follow account default.
    /// </summary>
    public bool? CanDeferBilling
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("can_defer_billing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["can_defer_billing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of price intervals to edit on the subscription.
    /// </summary>
    public List<Edit>? Edit
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("edit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Edit>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["edit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of adjustments to edit on the subscription.
    /// </summary>
    public List<EditAdjustment>? EditAdjustments
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("edit_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<EditAdjustment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["edit_adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionPriceIntervalsParams() { }

    public SubscriptionPriceIntervalsParams(
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
    SubscriptionPriceIntervalsParams(
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

    public static SubscriptionPriceIntervalsParams FromRawUnchecked(
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
                + string.Format("/subscriptions/{0}/price_intervals", this.SubscriptionID)
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

[JsonConverter(typeof(ModelConverter<Add>))]
public sealed record class Add : ModelBase, IFromRaw<Add>
{
    /// <summary>
    /// The start date of the price interval. This is the date that the price will
    /// start billing on the subscription.
    /// </summary>
    public required StartDate StartDate
    {
        get
        {
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "start_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<StartDate>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentNullException("start_date")
                );
        }
        init
        {
            this._properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
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
    /// A list of discounts to initialize on the price interval.
    /// </summary>
    public List<global::Orb.Models.Subscriptions.Discount>? Discounts
    {
        get
        {
            if (!this._properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Discount>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["discounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that the price will stop
    /// billing on the subscription.
    /// </summary>
    public EndDate? EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EndDate?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
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
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get
        {
            if (!this._properties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to initialize on the price interval.
    /// </summary>
    public List<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "fixed_fee_quantity_transitions",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["fixed_fee_quantity_transitions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum amount that will be billed for this price interval for a given
    /// billing period.
    /// </summary>
    public double? MaximumAmount
    {
        get
        {
            if (!this._properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The minimum amount that will be billed for this price interval for a given
    /// billing period.
    /// </summary>
    public double? MinimumAmount
    {
        get
        {
            if (!this._properties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New floating price request body params.
    /// </summary>
    public Price1? Price
    {
        get
        {
            if (!this._properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Price1?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this._properties.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this subscription. By default, a subscription only considers usage events
    /// associated with its attached customer's customer_id. When usage_customer_ids
    /// is provided, the subscription includes usage events from the specified customers
    /// only. Provided usage_customer_ids must be either the customer for this subscription
    /// itself, or any of that customer's children.
    /// </summary>
    public List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this._properties.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.StartDate.Validate();
        this.AllocationPrice?.Validate();
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

    public Add(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Add(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Add FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Add(StartDate startDate)
        : this()
    {
        this.StartDate = startDate;
    }
}

/// <summary>
/// The start date of the price interval. This is the date that the price will start
/// billing on the subscription.
/// </summary>
[JsonConverter(typeof(StartDateConverter))]
public record class StartDate
{
    public object Value { get; private init; }

    public StartDate(System::DateTimeOffset value)
    {
        Value = value;
    }

    public StartDate(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    StartDate(UnknownVariant value)
    {
        Value = value;
    }

    public static StartDate CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of StartDate");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class StartDateConverter : JsonConverter<StartDate>
{
    public override StartDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new StartDate(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new StartDate(
                JsonSerializer.Deserialize<System::DateTimeOffset>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTimeOffset'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        StartDate value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(DiscountConverter))]
public record class Discount
{
    public object Value { get; private init; }

    public Discount(Amount value)
    {
        Value = value;
    }

    public Discount(Percentage value)
    {
        Value = value;
    }

    public Discount(Usage value)
    {
        Value = value;
    }

    Discount(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.Discount CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public bool TryPickUsage([NotNullWhen(true)] out Usage? value)
    {
        value = this.Value as Usage;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Discount");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Amount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.Discount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException("Data does not match union variant 'Amount'", e)
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percentage":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Percentage>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.Discount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'Percentage'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "usage":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Usage>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.Subscriptions.Discount(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException("Data does not match union variant 'Usage'", e)
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
        global::Orb.Models.Subscriptions.Discount value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<Amount>))]
public sealed record class Amount : ModelBase, IFromRaw<Amount>
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required double AmountDiscount
    {
        get
        {
            if (!this._properties.TryGetValue("amount_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "amount_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public global::Orb.Models.Subscriptions.DiscountType DiscountType
    {
        get
        {
            if (!this._properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.DiscountType>(
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
            this._properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public Amount(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.DiscountType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Amount(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Amount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Amount(double amountDiscount)
        : this()
    {
        this.AmountDiscount = amountDiscount;
    }
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

[JsonConverter(typeof(ModelConverter<Percentage>))]
public sealed record class Percentage : ModelBase, IFromRaw<Percentage>
{
    public global::Orb.Models.Subscriptions.DiscountTypeModel DiscountType
    {
        get
        {
            if (!this._properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.DiscountTypeModel>(
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
            this._properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`. This is a number between
    /// 0 and 1.
    /// </summary>
    public required double PercentageDiscount
    {
        get
        {
            if (!this._properties.TryGetValue("percentage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percentage_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percentage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public Percentage(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.DiscountType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percentage(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Percentage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Percentage(double percentageDiscount)
        : this()
    {
        this.PercentageDiscount = percentageDiscount;
    }
}

[JsonConverter(typeof(Converter))]
public class DiscountTypeModel
{
    public JsonElement Json { get; private init; }

    public DiscountTypeModel()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percentage\"");
    }

    DiscountTypeModel(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.DiscountTypeModel().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'DiscountTypeModel'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.DiscountTypeModel>
    {
        public override global::Orb.Models.Subscriptions.DiscountTypeModel? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.DiscountTypeModel value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Usage>))]
public sealed record class Usage : ModelBase, IFromRaw<Usage>
{
    public global::Orb.Models.Subscriptions.DiscountType1 DiscountType
    {
        get
        {
            if (!this._properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.DiscountType1>(
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
            this._properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for.
    /// </summary>
    public required double UsageDiscount
    {
        get
        {
            if (!this._properties.TryGetValue("usage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'usage_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "usage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["usage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.UsageDiscount;
    }

    public Usage()
    {
        this.DiscountType = new();
    }

    public Usage(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.DiscountType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Usage(double usageDiscount)
        : this()
    {
        this.UsageDiscount = usageDiscount;
    }
}

[JsonConverter(typeof(Converter))]
public class DiscountType1
{
    public JsonElement Json { get; private init; }

    public DiscountType1()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"usage\"");
    }

    DiscountType1(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.DiscountType1().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'DiscountType1'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.DiscountType1>
    {
        public override global::Orb.Models.Subscriptions.DiscountType1? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.DiscountType1 value,
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
    public object Value { get; private init; }

    public EndDate(System::DateTimeOffset value)
    {
        Value = value;
    }

    public EndDate(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    EndDate(UnknownVariant value)
    {
        Value = value;
    }

    public static EndDate CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EndDate");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class EndDateConverter : JsonConverter<EndDate?>
{
    public override EndDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new EndDate(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new EndDate(
                JsonSerializer.Deserialize<System::DateTimeOffset>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTimeOffset'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, EndDate? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>))]
public sealed record class FixedFeeQuantityTransition
    : ModelBase,
        IFromRaw<global::Orb.Models.Subscriptions.FixedFeeQuantityTransition>
{
    /// <summary>
    /// The date that the fixed fee quantity transition should take effect.
    /// </summary>
    public required System::DateTimeOffset EffectiveDate
    {
        get
        {
            if (!this._properties.TryGetValue("effective_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'effective_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "effective_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["effective_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The quantity of the fixed fee quantity transition.
    /// </summary>
    public required long Quantity
    {
        get
        {
            if (!this._properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition() { }

    public FixedFeeQuantityTransition(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransition(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.FixedFeeQuantityTransition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// New floating price request body params.
/// </summary>
[JsonConverter(typeof(Price1Converter))]
public record class Price1
{
    public object Value { get; private init; }

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
                newFloatingMinimumComposite: (x) => x.InvoicingCycleConfiguration,
                percent: (x) => x.InvoicingCycleConfiguration,
                eventOutput: (x) => x.InvoicingCycleConfiguration
            );
        }
    }

    public Price1(NewFloatingUnitPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingTieredPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingBulkPrice value)
    {
        Value = value;
    }

    public Price1(BulkWithFilters1 value)
    {
        Value = value;
    }

    public Price1(NewFloatingPackagePrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingMatrixPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingThresholdTotalAmountPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingTieredPackagePrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingTieredWithMinimumPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingGroupedTieredPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingTieredPackageWithMinimumPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingPackageWithAllocationPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingUnitWithPercentPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingMatrixWithAllocationPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingTieredWithProrationPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingUnitWithProrationPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingGroupedAllocationPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingBulkWithProrationPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingGroupedWithProratedMinimumPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingGroupedWithMeteredMinimumPrice value)
    {
        Value = value;
    }

    public Price1(GroupedWithMinMaxThresholds1 value)
    {
        Value = value;
    }

    public Price1(NewFloatingMatrixWithDisplayNamePrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingGroupedTieredPackagePrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingMaxGroupTieredPackagePrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingScalableMatrixWithUnitPricingPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingScalableMatrixWithTieredPricingPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingCumulativeGroupedBulkPrice value)
    {
        Value = value;
    }

    public Price1(NewFloatingMinimumCompositePrice value)
    {
        Value = value;
    }

    public Price1(Percent1 value)
    {
        Value = value;
    }

    public Price1(EventOutput1 value)
    {
        Value = value;
    }

    Price1(UnknownVariant value)
    {
        Value = value;
    }

    public static Price1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public bool TryPickBulkWithFilters([NotNullWhen(true)] out BulkWithFilters1? value)
    {
        value = this.Value as BulkWithFilters1;
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
        [NotNullWhen(true)] out GroupedWithMinMaxThresholds1? value
    )
    {
        value = this.Value as GroupedWithMinMaxThresholds1;
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

    public bool TryPickNewFloatingMinimumComposite(
        [NotNullWhen(true)] out NewFloatingMinimumCompositePrice? value
    )
    {
        value = this.Value as NewFloatingMinimumCompositePrice;
        return value != null;
    }

    public bool TryPickPercent([NotNullWhen(true)] out Percent1? value)
    {
        value = this.Value as Percent1;
        return value != null;
    }

    public bool TryPickEventOutput([NotNullWhen(true)] out EventOutput1? value)
    {
        value = this.Value as EventOutput1;
        return value != null;
    }

    public void Switch(
        System::Action<NewFloatingUnitPrice> newFloatingUnit,
        System::Action<NewFloatingTieredPrice> newFloatingTiered,
        System::Action<NewFloatingBulkPrice> newFloatingBulk,
        System::Action<BulkWithFilters1> bulkWithFilters,
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
        System::Action<GroupedWithMinMaxThresholds1> groupedWithMinMaxThresholds,
        System::Action<NewFloatingMatrixWithDisplayNamePrice> newFloatingMatrixWithDisplayName,
        System::Action<NewFloatingGroupedTieredPackagePrice> newFloatingGroupedTieredPackage,
        System::Action<NewFloatingMaxGroupTieredPackagePrice> newFloatingMaxGroupTieredPackage,
        System::Action<NewFloatingScalableMatrixWithUnitPricingPrice> newFloatingScalableMatrixWithUnitPricing,
        System::Action<NewFloatingScalableMatrixWithTieredPricingPrice> newFloatingScalableMatrixWithTieredPricing,
        System::Action<NewFloatingCumulativeGroupedBulkPrice> newFloatingCumulativeGroupedBulk,
        System::Action<NewFloatingMinimumCompositePrice> newFloatingMinimumComposite,
        System::Action<Percent1> percent,
        System::Action<EventOutput1> eventOutput
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
            case BulkWithFilters1 value:
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
            case GroupedWithMinMaxThresholds1 value:
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
            case NewFloatingMinimumCompositePrice value:
                newFloatingMinimumComposite(value);
                break;
            case Percent1 value:
                percent(value);
                break;
            case EventOutput1 value:
                eventOutput(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Price1");
        }
    }

    public T Match<T>(
        System::Func<NewFloatingUnitPrice, T> newFloatingUnit,
        System::Func<NewFloatingTieredPrice, T> newFloatingTiered,
        System::Func<NewFloatingBulkPrice, T> newFloatingBulk,
        System::Func<BulkWithFilters1, T> bulkWithFilters,
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
        System::Func<GroupedWithMinMaxThresholds1, T> groupedWithMinMaxThresholds,
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
        System::Func<NewFloatingMinimumCompositePrice, T> newFloatingMinimumComposite,
        System::Func<Percent1, T> percent,
        System::Func<EventOutput1, T> eventOutput
    )
    {
        return this.Value switch
        {
            NewFloatingUnitPrice value => newFloatingUnit(value),
            NewFloatingTieredPrice value => newFloatingTiered(value),
            NewFloatingBulkPrice value => newFloatingBulk(value),
            BulkWithFilters1 value => bulkWithFilters(value),
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
            GroupedWithMinMaxThresholds1 value => groupedWithMinMaxThresholds(value),
            NewFloatingMatrixWithDisplayNamePrice value => newFloatingMatrixWithDisplayName(value),
            NewFloatingGroupedTieredPackagePrice value => newFloatingGroupedTieredPackage(value),
            NewFloatingMaxGroupTieredPackagePrice value => newFloatingMaxGroupTieredPackage(value),
            NewFloatingScalableMatrixWithUnitPricingPrice value =>
                newFloatingScalableMatrixWithUnitPricing(value),
            NewFloatingScalableMatrixWithTieredPricingPrice value =>
                newFloatingScalableMatrixWithTieredPricing(value),
            NewFloatingCumulativeGroupedBulkPrice value => newFloatingCumulativeGroupedBulk(value),
            NewFloatingMinimumCompositePrice value => newFloatingMinimumComposite(value),
            Percent1 value => percent(value),
            EventOutput1 value => eventOutput(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Price1"),
        };
    }

    public static implicit operator Price1(NewFloatingUnitPrice value) => new(value);

    public static implicit operator Price1(NewFloatingTieredPrice value) => new(value);

    public static implicit operator Price1(NewFloatingBulkPrice value) => new(value);

    public static implicit operator Price1(BulkWithFilters1 value) => new(value);

    public static implicit operator Price1(NewFloatingPackagePrice value) => new(value);

    public static implicit operator Price1(NewFloatingMatrixPrice value) => new(value);

    public static implicit operator Price1(NewFloatingThresholdTotalAmountPrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingTieredPackagePrice value) => new(value);

    public static implicit operator Price1(NewFloatingTieredWithMinimumPrice value) => new(value);

    public static implicit operator Price1(NewFloatingGroupedTieredPrice value) => new(value);

    public static implicit operator Price1(NewFloatingTieredPackageWithMinimumPrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingPackageWithAllocationPrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingUnitWithPercentPrice value) => new(value);

    public static implicit operator Price1(NewFloatingMatrixWithAllocationPrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingTieredWithProrationPrice value) => new(value);

    public static implicit operator Price1(NewFloatingUnitWithProrationPrice value) => new(value);

    public static implicit operator Price1(NewFloatingGroupedAllocationPrice value) => new(value);

    public static implicit operator Price1(NewFloatingBulkWithProrationPrice value) => new(value);

    public static implicit operator Price1(NewFloatingGroupedWithProratedMinimumPrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingGroupedWithMeteredMinimumPrice value) =>
        new(value);

    public static implicit operator Price1(GroupedWithMinMaxThresholds1 value) => new(value);

    public static implicit operator Price1(NewFloatingMatrixWithDisplayNamePrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingGroupedTieredPackagePrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingMaxGroupTieredPackagePrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingScalableMatrixWithUnitPricingPrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingScalableMatrixWithTieredPricingPrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingCumulativeGroupedBulkPrice value) =>
        new(value);

    public static implicit operator Price1(NewFloatingMinimumCompositePrice value) => new(value);

    public static implicit operator Price1(Percent1 value) => new(value);

    public static implicit operator Price1(EventOutput1 value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Price1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Price1Converter : JsonConverter<Price1?>
{
    public override Price1? Read(
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingBulkPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingBulkPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<BulkWithFilters1>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BulkWithFilters1'",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingPackagePrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMatrixPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixPrice'",
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingThresholdTotalAmountPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingThresholdTotalAmountPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingTieredPackagePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPackagePrice'",
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingTieredWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredWithMinimumPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingGroupedTieredPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedTieredPrice'",
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
                        JsonSerializer.Deserialize<NewFloatingTieredPackageWithMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredPackageWithMinimumPrice'",
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
                        JsonSerializer.Deserialize<NewFloatingPackageWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingPackageWithAllocationPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingUnitWithPercentPrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitWithPercentPrice'",
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingMatrixWithAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixWithAllocationPrice'",
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
                        JsonSerializer.Deserialize<NewFloatingTieredWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingTieredWithProrationPrice'",
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingUnitWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingUnitWithProrationPrice'",
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedAllocationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedAllocationPrice'",
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingBulkWithProrationPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingBulkWithProrationPrice'",
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithProratedMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedWithProratedMinimumPrice'",
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
                        JsonSerializer.Deserialize<NewFloatingGroupedWithMeteredMinimumPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedWithMeteredMinimumPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<GroupedWithMinMaxThresholds1>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'GroupedWithMinMaxThresholds1'",
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
                        JsonSerializer.Deserialize<NewFloatingMatrixWithDisplayNamePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMatrixWithDisplayNamePrice'",
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
                    var deserialized =
                        JsonSerializer.Deserialize<NewFloatingGroupedTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingGroupedTieredPackagePrice'",
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
                        JsonSerializer.Deserialize<NewFloatingMaxGroupTieredPackagePrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMaxGroupTieredPackagePrice'",
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithUnitPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingScalableMatrixWithUnitPricingPrice'",
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
                        JsonSerializer.Deserialize<NewFloatingScalableMatrixWithTieredPricingPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingScalableMatrixWithTieredPricingPrice'",
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
                        JsonSerializer.Deserialize<NewFloatingCumulativeGroupedBulkPrice>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingCumulativeGroupedBulkPrice'",
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
                    var deserialized = JsonSerializer.Deserialize<NewFloatingMinimumCompositePrice>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewFloatingMinimumCompositePrice'",
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
                    var deserialized = JsonSerializer.Deserialize<Percent1>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'Percent1'",
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
                    var deserialized = JsonSerializer.Deserialize<EventOutput1>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Price1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'EventOutput1'",
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

    public override void Write(Utf8JsonWriter writer, Price1? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<BulkWithFilters1>))]
public sealed record class BulkWithFilters1 : ModelBase, IFromRaw<BulkWithFilters1>
{
    /// <summary>
    /// Configuration for bulk_with_filters pricing
    /// </summary>
    public required BulkWithFiltersConfig1 BulkWithFiltersConfig
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

            return JsonSerializer.Deserialize<BulkWithFiltersConfig1>(
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
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence9> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence9>
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
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
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
    public global::Orb.Models.Subscriptions.ModelType9 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType9>(
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
    public global::Orb.Models.Subscriptions.ConversionRateConfig9? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig9?>(
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

    public BulkWithFilters1()
    {
        this.ModelType = new();
    }

    public BulkWithFilters1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFilters1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkWithFilters1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for bulk_with_filters pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<BulkWithFiltersConfig1>))]
public sealed record class BulkWithFiltersConfig1 : ModelBase, IFromRaw<BulkWithFiltersConfig1>
{
    /// <summary>
    /// Property filters to apply (all must match)
    /// </summary>
    public required List<global::Orb.Models.Subscriptions.Filter1> Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Filter1>>(
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
    public required List<global::Orb.Models.Subscriptions.Tier3> Tiers
    {
        get
        {
            if (!this._properties.TryGetValue("tiers", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tiers' cannot be null",
                    new System::ArgumentOutOfRangeException("tiers", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Subscriptions.Tier3>>(
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

    public BulkWithFiltersConfig1() { }

    public BulkWithFiltersConfig1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkWithFiltersConfig1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkWithFiltersConfig1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single property filter
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.Filter1>))]
public sealed record class Filter1 : ModelBase, IFromRaw<global::Orb.Models.Subscriptions.Filter1>
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

    public Filter1() { }

    public Filter1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Filter1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Configuration for a single bulk pricing tier
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Subscriptions.Tier3>))]
public sealed record class Tier3 : ModelBase, IFromRaw<global::Orb.Models.Subscriptions.Tier3>
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

    public Tier3() { }

    public Tier3(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier3(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Subscriptions.Tier3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Tier3(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence9Converter))]
public enum Cadence9
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence9Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence9>
{
    public override global::Orb.Models.Subscriptions.Cadence9 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence9.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence9.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence9.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence9.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence9.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence9.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence9)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence9 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence9.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence9.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence9.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence9.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence9.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence9.Custom => "custom",
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
public class ModelType9
{
    public JsonElement Json { get; private init; }

    public ModelType9()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ModelType9(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType9().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'ModelType9'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType9>
    {
        public override global::Orb.Models.Subscriptions.ModelType9? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType9 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig9Converter))]
public record class ConversionRateConfig9
{
    public object Value { get; private init; }

    public ConversionRateConfig9(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig9(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig9(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig9 CreateUnknownVariant(
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
                    "Data did not match any variant of ConversionRateConfig9"
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
                "Data did not match any variant of ConversionRateConfig9"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Subscriptions.ConversionRateConfig9(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Subscriptions.ConversionRateConfig9(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig9"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig9Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig9>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig9? Read(
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig9(
                            deserialized
                        );
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig9(
                            deserialized
                        );
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
        global::Orb.Models.Subscriptions.ConversionRateConfig9 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholds1>))]
public sealed record class GroupedWithMinMaxThresholds1
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholds1>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence10> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence10>
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
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
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
    /// Configuration for grouped_with_min_max_thresholds pricing
    /// </summary>
    public required GroupedWithMinMaxThresholdsConfig1 GroupedWithMinMaxThresholdsConfig
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

            return JsonSerializer.Deserialize<GroupedWithMinMaxThresholdsConfig1>(
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
    public global::Orb.Models.Subscriptions.ModelType10 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType10>(
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
    public global::Orb.Models.Subscriptions.ConversionRateConfig10? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig10?>(
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

    public GroupedWithMinMaxThresholds1()
    {
        this.ModelType = new();
    }

    public GroupedWithMinMaxThresholds1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholds1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholds1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence10Converter))]
public enum Cadence10
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence10Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence10>
{
    public override global::Orb.Models.Subscriptions.Cadence10 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence10.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence10.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence10.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence10.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence10.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence10.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence10)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence10 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence10.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence10.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence10.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence10.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence10.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence10.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<GroupedWithMinMaxThresholdsConfig1>))]
public sealed record class GroupedWithMinMaxThresholdsConfig1
    : ModelBase,
        IFromRaw<GroupedWithMinMaxThresholdsConfig1>
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

    public GroupedWithMinMaxThresholdsConfig1() { }

    public GroupedWithMinMaxThresholdsConfig1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedWithMinMaxThresholdsConfig1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GroupedWithMinMaxThresholdsConfig1 FromRawUnchecked(
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
public class ModelType10
{
    public JsonElement Json { get; private init; }

    public ModelType10()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"grouped_with_min_max_thresholds\"");
    }

    ModelType10(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType10().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'ModelType10'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType10>
    {
        public override global::Orb.Models.Subscriptions.ModelType10? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType10 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig10Converter))]
public record class ConversionRateConfig10
{
    public object Value { get; private init; }

    public ConversionRateConfig10(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig10(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig10(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig10 CreateUnknownVariant(
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
                    "Data did not match any variant of ConversionRateConfig10"
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
                "Data did not match any variant of ConversionRateConfig10"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Subscriptions.ConversionRateConfig10(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Subscriptions.ConversionRateConfig10(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig10"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig10Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig10>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig10? Read(
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig10(
                            deserialized
                        );
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig10(
                            deserialized
                        );
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
        global::Orb.Models.Subscriptions.ConversionRateConfig10 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<Percent1>))]
public sealed record class Percent1 : ModelBase, IFromRaw<Percent1>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence11> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence11>
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
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
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
    public global::Orb.Models.Subscriptions.ModelType11 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType11>(
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
    public required PercentConfig1 PercentConfig
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

            return JsonSerializer.Deserialize<PercentConfig1>(element, ModelBase.SerializerOptions)
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
    public global::Orb.Models.Subscriptions.ConversionRateConfig11? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig11?>(
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

    public Percent1()
    {
        this.ModelType = new();
    }

    public Percent1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Percent1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Percent1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence11Converter))]
public enum Cadence11
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence11Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence11>
{
    public override global::Orb.Models.Subscriptions.Cadence11 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence11.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence11.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence11.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence11.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence11.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence11.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence11)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence11 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence11.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence11.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence11.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence11.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence11.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence11.Custom => "custom",
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
public class ModelType11
{
    public JsonElement Json { get; private init; }

    public ModelType11()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"percent\"");
    }

    ModelType11(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType11().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'ModelType11'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType11>
    {
        public override global::Orb.Models.Subscriptions.ModelType11? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType11 value,
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
[JsonConverter(typeof(ModelConverter<PercentConfig1>))]
public sealed record class PercentConfig1 : ModelBase, IFromRaw<PercentConfig1>
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

    public PercentConfig1() { }

    public PercentConfig1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentConfig1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PercentConfig1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public PercentConfig1(double percent)
        : this()
    {
        this.Percent = percent;
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig11Converter))]
public record class ConversionRateConfig11
{
    public object Value { get; private init; }

    public ConversionRateConfig11(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig11(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig11(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig11 CreateUnknownVariant(
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
                    "Data did not match any variant of ConversionRateConfig11"
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
                "Data did not match any variant of ConversionRateConfig11"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Subscriptions.ConversionRateConfig11(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Subscriptions.ConversionRateConfig11(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig11"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig11Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig11>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig11? Read(
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig11(
                            deserialized
                        );
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig11(
                            deserialized
                        );
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
        global::Orb.Models.Subscriptions.ConversionRateConfig11 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<EventOutput1>))]
public sealed record class EventOutput1 : ModelBase, IFromRaw<EventOutput1>
{
    /// <summary>
    /// The cadence to bill for this price on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Subscriptions.Cadence12> Cadence
    {
        get
        {
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Subscriptions.Cadence12>
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
    /// An ISO 4217 currency string for which this price is billed in.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
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
    /// Configuration for event_output pricing
    /// </summary>
    public required EventOutputConfig1 EventOutputConfig
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

            return JsonSerializer.Deserialize<EventOutputConfig1>(
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
    public global::Orb.Models.Subscriptions.ModelType12 ModelType
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

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ModelType12>(
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
    public global::Orb.Models.Subscriptions.ConversionRateConfig12? ConversionRateConfig
    {
        get
        {
            if (!this._properties.TryGetValue("conversion_rate_config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.ConversionRateConfig12?>(
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

    public EventOutput1()
    {
        this.ModelType = new();
    }

    public EventOutput1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.ModelType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutput1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EventOutput1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The cadence to bill for this price on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Cadence12Converter))]
public enum Cadence12
{
    Annual,
    SemiAnnual,
    Monthly,
    Quarterly,
    OneTime,
    Custom,
}

sealed class Cadence12Converter : JsonConverter<global::Orb.Models.Subscriptions.Cadence12>
{
    public override global::Orb.Models.Subscriptions.Cadence12 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "annual" => global::Orb.Models.Subscriptions.Cadence12.Annual,
            "semi_annual" => global::Orb.Models.Subscriptions.Cadence12.SemiAnnual,
            "monthly" => global::Orb.Models.Subscriptions.Cadence12.Monthly,
            "quarterly" => global::Orb.Models.Subscriptions.Cadence12.Quarterly,
            "one_time" => global::Orb.Models.Subscriptions.Cadence12.OneTime,
            "custom" => global::Orb.Models.Subscriptions.Cadence12.Custom,
            _ => (global::Orb.Models.Subscriptions.Cadence12)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Cadence12 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Cadence12.Annual => "annual",
                global::Orb.Models.Subscriptions.Cadence12.SemiAnnual => "semi_annual",
                global::Orb.Models.Subscriptions.Cadence12.Monthly => "monthly",
                global::Orb.Models.Subscriptions.Cadence12.Quarterly => "quarterly",
                global::Orb.Models.Subscriptions.Cadence12.OneTime => "one_time",
                global::Orb.Models.Subscriptions.Cadence12.Custom => "custom",
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
[JsonConverter(typeof(ModelConverter<EventOutputConfig1>))]
public sealed record class EventOutputConfig1 : ModelBase, IFromRaw<EventOutputConfig1>
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

    public EventOutputConfig1() { }

    public EventOutputConfig1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventOutputConfig1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EventOutputConfig1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public EventOutputConfig1(string unitRatingKey)
        : this()
    {
        this.UnitRatingKey = unitRatingKey;
    }
}

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType12
{
    public JsonElement Json { get; private init; }

    public ModelType12()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"event_output\"");
    }

    ModelType12(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (
            JsonElement.DeepEquals(
                this.Json,
                new global::Orb.Models.Subscriptions.ModelType12().Json
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for 'ModelType12'");
        }
    }

    class Converter : JsonConverter<global::Orb.Models.Subscriptions.ModelType12>
    {
        public override global::Orb.Models.Subscriptions.ModelType12? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            global::Orb.Models.Subscriptions.ModelType12 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.ConversionRateConfig12Converter))]
public record class ConversionRateConfig12
{
    public object Value { get; private init; }

    public ConversionRateConfig12(UnitConversionRateConfig value)
    {
        Value = value;
    }

    public ConversionRateConfig12(TieredConversionRateConfig value)
    {
        Value = value;
    }

    ConversionRateConfig12(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.ConversionRateConfig12 CreateUnknownVariant(
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
                    "Data did not match any variant of ConversionRateConfig12"
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
                "Data did not match any variant of ConversionRateConfig12"
            ),
        };
    }

    public static implicit operator global::Orb.Models.Subscriptions.ConversionRateConfig12(
        UnitConversionRateConfig value
    ) => new(value);

    public static implicit operator global::Orb.Models.Subscriptions.ConversionRateConfig12(
        TieredConversionRateConfig value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of ConversionRateConfig12"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ConversionRateConfig12Converter
    : JsonConverter<global::Orb.Models.Subscriptions.ConversionRateConfig12>
{
    public override global::Orb.Models.Subscriptions.ConversionRateConfig12? Read(
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig12(
                            deserialized
                        );
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
                        return new global::Orb.Models.Subscriptions.ConversionRateConfig12(
                            deserialized
                        );
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
        global::Orb.Models.Subscriptions.ConversionRateConfig12 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<AddAdjustmentModel>))]
public sealed record class AddAdjustmentModel : ModelBase, IFromRaw<AddAdjustmentModel>
{
    /// <summary>
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `start_date`. This `start_date` is
    /// treated as inclusive for in-advance prices, and exclusive for in-arrears prices.
    /// </summary>
    public required StartDateModel StartDate
    {
        get
        {
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "start_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<StartDateModel>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentNullException("start_date")
                );
        }
        init
        {
            this._properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public global::Orb.Models.Subscriptions.Adjustment1? Adjustment
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Orb.Models.Subscriptions.Adjustment1?>(
                element,
                ModelBase.SerializerOptions
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
    /// The ID of the adjustment to add to the subscription. Adjustment IDs can be
    /// re-used from existing subscriptions or plans, but adjustments associated with
    /// coupon redemptions cannot be re-used.
    /// </summary>
    public string? AdjustmentID
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `end_date`.This `end_date` is treated
    /// as exclusive for in-advance prices, and inclusive for in-arrears prices.
    /// </summary>
    public EndDateModel? EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EndDateModel?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.StartDate.Validate();
        this.Adjustment?.Validate();
        _ = this.AdjustmentID;
        this.EndDate?.Validate();
    }

    public AddAdjustmentModel() { }

    public AddAdjustmentModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustmentModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AddAdjustmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public AddAdjustmentModel(StartDateModel startDate)
        : this()
    {
        this.StartDate = startDate;
    }
}

/// <summary>
/// The start date of the adjustment interval. This is the date that the adjustment
/// will start affecting prices on the subscription. The adjustment will apply to
/// invoice dates that overlap with this `start_date`. This `start_date` is treated
/// as inclusive for in-advance prices, and exclusive for in-arrears prices.
/// </summary>
[JsonConverter(typeof(StartDateModelConverter))]
public record class StartDateModel
{
    public object Value { get; private init; }

    public StartDateModel(System::DateTimeOffset value)
    {
        Value = value;
    }

    public StartDateModel(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    StartDateModel(UnknownVariant value)
    {
        Value = value;
    }

    public static StartDateModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
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
                    "Data did not match any variant of StartDateModel"
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
                "Data did not match any variant of StartDateModel"
            ),
        };
    }

    public static implicit operator StartDateModel(System::DateTimeOffset value) => new(value);

    public static implicit operator StartDateModel(
        ApiEnum<string, BillingCycleRelativeDate> value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of StartDateModel");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class StartDateModelConverter : JsonConverter<StartDateModel>
{
    public override StartDateModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new StartDateModel(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new StartDateModel(
                JsonSerializer.Deserialize<System::DateTimeOffset>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTimeOffset'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        StartDateModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// The definition of a new adjustment to create and add to the subscription.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Subscriptions.Adjustment1Converter))]
public record class Adjustment1
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

    public Adjustment1(NewPercentageDiscount value)
    {
        Value = value;
    }

    public Adjustment1(NewUsageDiscount value)
    {
        Value = value;
    }

    public Adjustment1(NewAmountDiscount value)
    {
        Value = value;
    }

    public Adjustment1(NewMinimum value)
    {
        Value = value;
    }

    public Adjustment1(NewMaximum value)
    {
        Value = value;
    }

    Adjustment1(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.Subscriptions.Adjustment1 CreateUnknownVariant(
        JsonElement value
    )
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
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment1");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment1"),
        };
    }

    public static implicit operator global::Orb.Models.Subscriptions.Adjustment1(
        NewPercentageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Subscriptions.Adjustment1(
        NewUsageDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Subscriptions.Adjustment1(
        NewAmountDiscount value
    ) => new(value);

    public static implicit operator global::Orb.Models.Subscriptions.Adjustment1(
        NewMinimum value
    ) => new(value);

    public static implicit operator global::Orb.Models.Subscriptions.Adjustment1(
        NewMaximum value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Adjustment1Converter : JsonConverter<global::Orb.Models.Subscriptions.Adjustment1?>
{
    public override global::Orb.Models.Subscriptions.Adjustment1? Read(
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
                        return new global::Orb.Models.Subscriptions.Adjustment1(deserialized);
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
                        return new global::Orb.Models.Subscriptions.Adjustment1(deserialized);
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
                        return new global::Orb.Models.Subscriptions.Adjustment1(deserialized);
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
                        return new global::Orb.Models.Subscriptions.Adjustment1(deserialized);
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
                        return new global::Orb.Models.Subscriptions.Adjustment1(deserialized);
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
        global::Orb.Models.Subscriptions.Adjustment1? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// The end date of the adjustment interval. This is the date that the adjustment
/// will stop affecting prices on the subscription. The adjustment will apply to
/// invoice dates that overlap with this `end_date`.This `end_date` is treated as
/// exclusive for in-advance prices, and inclusive for in-arrears prices.
/// </summary>
[JsonConverter(typeof(EndDateModelConverter))]
public record class EndDateModel
{
    public object Value { get; private init; }

    public EndDateModel(System::DateTimeOffset value)
    {
        Value = value;
    }

    public EndDateModel(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    EndDateModel(UnknownVariant value)
    {
        Value = value;
    }

    public static EndDateModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
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
                throw new OrbInvalidDataException("Data did not match any variant of EndDateModel");
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
                "Data did not match any variant of EndDateModel"
            ),
        };
    }

    public static implicit operator EndDateModel(System::DateTimeOffset value) => new(value);

    public static implicit operator EndDateModel(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EndDateModel");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class EndDateModelConverter : JsonConverter<EndDateModel?>
{
    public override EndDateModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new EndDateModel(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new EndDateModel(
                JsonSerializer.Deserialize<System::DateTimeOffset>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTimeOffset'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EndDateModel? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<Edit>))]
public sealed record class Edit : ModelBase, IFromRaw<Edit>
{
    /// <summary>
    /// The id of the price interval to edit.
    /// </summary>
    public required string PriceIntervalID
    {
        get
        {
            if (!this._properties.TryGetValue("price_interval_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price_interval_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "price_interval_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'price_interval_id' cannot be null",
                    new System::ArgumentNullException("price_interval_id")
                );
        }
        init
        {
            this._properties["price_interval_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The updated billing cycle day for this price interval. If not specified,
    /// the billing cycle day will not be updated. Note that overlapping price intervals
    /// must have the same billing cycle day.
    /// </summary>
    public long? BillingCycleDay
    {
        get
        {
            if (!this._properties.TryGetValue("billing_cycle_day", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billing_cycle_day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, ending an in-arrears price interval mid-cycle will defer billing
    /// the final line itemuntil the next scheduled invoice. If false, it will be
    /// billed on its end date. If not provided, behaviorwill follow account default.
    /// </summary>
    public bool? CanDeferBilling
    {
        get
        {
            if (!this._properties.TryGetValue("can_defer_billing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["can_defer_billing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The updated end date of this price interval. If not specified, the end date
    /// will not be updated.
    /// </summary>
    public EndDate1? EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EndDate1?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get
        {
            if (!this._properties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to use for this price interval. Note
    /// that this list will overwrite all existing fixed fee quantity transitions
    /// on the price interval.
    /// </summary>
    public List<FixedFeeQuantityTransitionModel>? FixedFeeQuantityTransitions
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "fixed_fee_quantity_transitions",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<List<FixedFeeQuantityTransitionModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["fixed_fee_quantity_transitions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The updated start date of this price interval. If not specified, the start
    /// date will not be updated.
    /// </summary>
    public StartDate1? StartDate
    {
        get
        {
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<StartDate1?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
    public List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this._properties.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    public Edit(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Edit(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Edit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Edit(string priceIntervalID)
        : this()
    {
        this.PriceIntervalID = priceIntervalID;
    }
}

/// <summary>
/// The updated end date of this price interval. If not specified, the end date will
/// not be updated.
/// </summary>
[JsonConverter(typeof(EndDate1Converter))]
public record class EndDate1
{
    public object Value { get; private init; }

    public EndDate1(System::DateTimeOffset value)
    {
        Value = value;
    }

    public EndDate1(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    EndDate1(UnknownVariant value)
    {
        Value = value;
    }

    public static EndDate1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
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
                throw new OrbInvalidDataException("Data did not match any variant of EndDate1");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of EndDate1"),
        };
    }

    public static implicit operator EndDate1(System::DateTimeOffset value) => new(value);

    public static implicit operator EndDate1(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EndDate1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class EndDate1Converter : JsonConverter<EndDate1?>
{
    public override EndDate1? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new EndDate1(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new EndDate1(
                JsonSerializer.Deserialize<System::DateTimeOffset>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTimeOffset'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EndDate1? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<FixedFeeQuantityTransitionModel>))]
public sealed record class FixedFeeQuantityTransitionModel
    : ModelBase,
        IFromRaw<FixedFeeQuantityTransitionModel>
{
    /// <summary>
    /// The date that the fixed fee quantity transition should take effect.
    /// </summary>
    public required System::DateTimeOffset EffectiveDate
    {
        get
        {
            if (!this._properties.TryGetValue("effective_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'effective_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "effective_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["effective_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The quantity of the fixed fee quantity transition.
    /// </summary>
    public required long Quantity
    {
        get
        {
            if (!this._properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransitionModel() { }

    public FixedFeeQuantityTransitionModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityTransitionModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static FixedFeeQuantityTransitionModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The updated start date of this price interval. If not specified, the start date
/// will not be updated.
/// </summary>
[JsonConverter(typeof(StartDate1Converter))]
public record class StartDate1
{
    public object Value { get; private init; }

    public StartDate1(System::DateTimeOffset value)
    {
        Value = value;
    }

    public StartDate1(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    StartDate1(UnknownVariant value)
    {
        Value = value;
    }

    public static StartDate1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
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
                throw new OrbInvalidDataException("Data did not match any variant of StartDate1");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of StartDate1"),
        };
    }

    public static implicit operator StartDate1(System::DateTimeOffset value) => new(value);

    public static implicit operator StartDate1(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of StartDate1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class StartDate1Converter : JsonConverter<StartDate1>
{
    public override StartDate1? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new StartDate1(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new StartDate1(
                JsonSerializer.Deserialize<System::DateTimeOffset>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTimeOffset'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        StartDate1 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<EditAdjustment>))]
public sealed record class EditAdjustment : ModelBase, IFromRaw<EditAdjustment>
{
    /// <summary>
    /// The id of the adjustment interval to edit.
    /// </summary>
    public required string AdjustmentIntervalID
    {
        get
        {
            if (!this._properties.TryGetValue("adjustment_interval_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_interval_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustment_interval_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment_interval_id' cannot be null",
                    new System::ArgumentNullException("adjustment_interval_id")
                );
        }
        init
        {
            this._properties["adjustment_interval_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The updated end date of this adjustment interval. If not specified, the end
    /// date will not be updated.
    /// </summary>
    public EndDate2? EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EndDate2?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The updated start date of this adjustment interval. If not specified, the
    /// start date will not be updated.
    /// </summary>
    public StartDate2? StartDate
    {
        get
        {
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<StartDate2?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AdjustmentIntervalID;
        this.EndDate?.Validate();
        this.StartDate?.Validate();
    }

    public EditAdjustment() { }

    public EditAdjustment(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EditAdjustment(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EditAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public EditAdjustment(string adjustmentIntervalID)
        : this()
    {
        this.AdjustmentIntervalID = adjustmentIntervalID;
    }
}

/// <summary>
/// The updated end date of this adjustment interval. If not specified, the end date
/// will not be updated.
/// </summary>
[JsonConverter(typeof(EndDate2Converter))]
public record class EndDate2
{
    public object Value { get; private init; }

    public EndDate2(System::DateTimeOffset value)
    {
        Value = value;
    }

    public EndDate2(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    EndDate2(UnknownVariant value)
    {
        Value = value;
    }

    public static EndDate2 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
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
                throw new OrbInvalidDataException("Data did not match any variant of EndDate2");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of EndDate2"),
        };
    }

    public static implicit operator EndDate2(System::DateTimeOffset value) => new(value);

    public static implicit operator EndDate2(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EndDate2");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class EndDate2Converter : JsonConverter<EndDate2?>
{
    public override EndDate2? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new EndDate2(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new EndDate2(
                JsonSerializer.Deserialize<System::DateTimeOffset>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTimeOffset'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EndDate2? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// The updated start date of this adjustment interval. If not specified, the start
/// date will not be updated.
/// </summary>
[JsonConverter(typeof(StartDate2Converter))]
public record class StartDate2
{
    public object Value { get; private init; }

    public StartDate2(System::DateTimeOffset value)
    {
        Value = value;
    }

    public StartDate2(ApiEnum<string, BillingCycleRelativeDate> value)
    {
        Value = value;
    }

    StartDate2(UnknownVariant value)
    {
        Value = value;
    }

    public static StartDate2 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        value = this.Value as ApiEnum<string, BillingCycleRelativeDate>?;
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
                throw new OrbInvalidDataException("Data did not match any variant of StartDate2");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of StartDate2"),
        };
    }

    public static implicit operator StartDate2(System::DateTimeOffset value) => new(value);

    public static implicit operator StartDate2(ApiEnum<string, BillingCycleRelativeDate> value) =>
        new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of StartDate2");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class StartDate2Converter : JsonConverter<StartDate2>
{
    public override StartDate2? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new StartDate2(
                JsonSerializer.Deserialize<ApiEnum<string, BillingCycleRelativeDate>>(
                    ref reader,
                    options
                )
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'ApiEnum<string, BillingCycleRelativeDate>'",
                    e
                )
            );
        }

        try
        {
            return new StartDate2(
                JsonSerializer.Deserialize<System::DateTimeOffset>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTimeOffset'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        StartDate2 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
