using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.InvoiceLineItems;

[JsonConverter(typeof(ModelConverter<InvoiceLineItemCreateResponse>))]
public sealed record class InvoiceLineItemCreateResponse
    : ModelBase,
        IFromRaw<InvoiceLineItemCreateResponse>
{
    /// <summary>
    /// A unique ID for this line item.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The line amount after any adjustments and before overage conversion, credits
    /// and partial invoicing.
    /// </summary>
    public required string AdjustedSubtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("adjusted_subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjusted_subtotal' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjusted_subtotal",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjusted_subtotal' cannot be null",
                    new System::ArgumentNullException("adjusted_subtotal")
                );
        }
        set
        {
            this.Properties["adjusted_subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// All adjustments applied to the line item in the order they were applied based
    /// on invoice calculations (ie. usage discounts -> amount discounts -> percentage
    /// discounts -> minimums -> maximums).
    /// </summary>
    public required List<global::Orb.Models.InvoiceLineItems.Adjustment> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustments",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.InvoiceLineItems.Adjustment>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new System::ArgumentNullException("adjustments")
                );
        }
        set
        {
            this.Properties["adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The final amount for a line item after all adjustments and pre paid credits
    /// have been applied.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of prepaid credits applied.
    /// </summary>
    public required string CreditsApplied
    {
        get
        {
            if (!this.Properties.TryGetValue("credits_applied", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'credits_applied' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "credits_applied",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'credits_applied' cannot be null",
                    new System::ArgumentNullException("credits_applied")
                );
        }
        set
        {
            this.Properties["credits_applied"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This field is deprecated in favor of `adjustments`
    /// </summary>
    public required Discount1? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Discount1?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the range of time applied for this line item's price.
    /// </summary>
    public required System::DateTime EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'end_date' cannot be null",
                    new System::ArgumentOutOfRangeException("end_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An additional filter that was used to calculate the usage for this line item.
    /// </summary>
    public required string? Filter
    {
        get
        {
            if (!this.Properties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] For configured prices that are split by a grouping key, this
    /// will be populated with the key and a value. The `amount` and `subtotal` will
    /// be the values for this particular grouping.
    /// </summary>
    public required string? Grouping
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["grouping"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This field is deprecated in favor of `adjustments`.
    /// </summary>
    public required Maximum? Maximum
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Maximum?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This field is deprecated in favor of `adjustments`.
    /// </summary>
    public required string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This field is deprecated in favor of `adjustments`.
    /// </summary>
    public required Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Minimum?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minimum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This field is deprecated in favor of `adjustments`.
    /// </summary>
    public required string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price associated with this line item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
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
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Any amount applied from a partial invoice
    /// </summary>
    public required string PartiallyInvoicedAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("partially_invoiced_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'partially_invoiced_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "partially_invoiced_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'partially_invoiced_amount' cannot be null",
                    new System::ArgumentNullException("partially_invoiced_amount")
                );
        }
        set
        {
            this.Properties["partially_invoiced_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Price resource represents a price that can be billed on a subscription,
    /// resulting in a charge on an invoice in the form of an invoice line item. Prices
    /// take a quantity and determine an amount to bill.
    ///
    /// Orb supports a few different pricing models out of the box. Each of these
    /// models is serialized differently in a given Price object. The model_type
    /// field determines the key for the configuration object that is present.
    ///
    /// For more on the types of prices, see [the core concepts documentation](/core-concepts#plan-and-price)
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price' cannot be null",
                    new System::ArgumentOutOfRangeException("price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'price' cannot be null",
                    new System::ArgumentNullException("price")
                );
        }
        set
        {
            this.Properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Either the fixed fee quantity or the usage during the service period.
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the range of time applied for this line item's price.
    /// </summary>
    public required System::DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "start_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For complex pricing structures, the line item can be broken down further in `sub_line_items`.
    /// </summary>
    public required List<global::Orb.Models.InvoiceLineItems.SubLineItem> SubLineItems
    {
        get
        {
            if (!this.Properties.TryGetValue("sub_line_items", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'sub_line_items' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "sub_line_items",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                    List<global::Orb.Models.InvoiceLineItems.SubLineItem>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'sub_line_items' cannot be null",
                    new System::ArgumentNullException("sub_line_items")
                );
        }
        set
        {
            this.Properties["sub_line_items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The line amount before any adjustments.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentOutOfRangeException("subtotal", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentNullException("subtotal")
                );
        }
        set
        {
            this.Properties["subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of tax rates and their incurred tax amounts. Empty if no tax integration
    /// is configured.
    /// </summary>
    public required List<TaxAmount> TaxAmounts
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_amounts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_amounts' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_amounts",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<TaxAmount>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tax_amounts' cannot be null",
                    new System::ArgumentNullException("tax_amounts")
                );
        }
        set
        {
            this.Properties["tax_amounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of customer ids that were used to calculate the usage for this line item.
    /// </summary>
    public required List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.AdjustedSubtotal;
        foreach (var item in this.Adjustments)
        {
            item.Validate();
        }
        _ = this.Amount;
        _ = this.CreditsApplied;
        this.Discount?.Validate();
        _ = this.EndDate;
        _ = this.Filter;
        _ = this.Grouping;
        this.Maximum?.Validate();
        _ = this.MaximumAmount;
        this.Minimum?.Validate();
        _ = this.MinimumAmount;
        _ = this.Name;
        _ = this.PartiallyInvoicedAmount;
        this.Price.Validate();
        _ = this.Quantity;
        _ = this.StartDate;
        foreach (var item in this.SubLineItems)
        {
            item.Validate();
        }
        _ = this.Subtotal;
        foreach (var item in this.TaxAmounts)
        {
            item.Validate();
        }
        _ = this.UsageCustomerIDs;
    }

    public InvoiceLineItemCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceLineItemCreateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InvoiceLineItemCreateResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(global::Orb.Models.InvoiceLineItems.AdjustmentConverter))]
public record class Adjustment
{
    public object Value { get; private init; }

    public string ID
    {
        get
        {
            return Match(
                monetaryUsageDiscount: (x) => x.ID,
                monetaryAmountDiscount: (x) => x.ID,
                monetaryPercentageDiscount: (x) => x.ID,
                monetaryMinimum: (x) => x.ID,
                monetaryMaximum: (x) => x.ID
            );
        }
    }

    public string Amount
    {
        get
        {
            return Match(
                monetaryUsageDiscount: (x) => x.Amount,
                monetaryAmountDiscount: (x) => x.Amount,
                monetaryPercentageDiscount: (x) => x.Amount,
                monetaryMinimum: (x) => x.Amount,
                monetaryMaximum: (x) => x.Amount
            );
        }
    }

    public bool IsInvoiceLevel
    {
        get
        {
            return Match(
                monetaryUsageDiscount: (x) => x.IsInvoiceLevel,
                monetaryAmountDiscount: (x) => x.IsInvoiceLevel,
                monetaryPercentageDiscount: (x) => x.IsInvoiceLevel,
                monetaryMinimum: (x) => x.IsInvoiceLevel,
                monetaryMaximum: (x) => x.IsInvoiceLevel
            );
        }
    }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                monetaryUsageDiscount: (x) => x.Reason,
                monetaryAmountDiscount: (x) => x.Reason,
                monetaryPercentageDiscount: (x) => x.Reason,
                monetaryMinimum: (x) => x.Reason,
                monetaryMaximum: (x) => x.Reason
            );
        }
    }

    public string? ReplacesAdjustmentID
    {
        get
        {
            return Match<string?>(
                monetaryUsageDiscount: (x) => x.ReplacesAdjustmentID,
                monetaryAmountDiscount: (x) => x.ReplacesAdjustmentID,
                monetaryPercentageDiscount: (x) => x.ReplacesAdjustmentID,
                monetaryMinimum: (x) => x.ReplacesAdjustmentID,
                monetaryMaximum: (x) => x.ReplacesAdjustmentID
            );
        }
    }

    public Adjustment(MonetaryUsageDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment(MonetaryAmountDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment(MonetaryPercentageDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment(MonetaryMinimumAdjustment value)
    {
        Value = value;
    }

    public Adjustment(MonetaryMaximumAdjustment value)
    {
        Value = value;
    }

    Adjustment(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.InvoiceLineItems.Adjustment CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickMonetaryUsageDiscount(
        [NotNullWhen(true)] out MonetaryUsageDiscountAdjustment? value
    )
    {
        value = this.Value as MonetaryUsageDiscountAdjustment;
        return value != null;
    }

    public bool TryPickMonetaryAmountDiscount(
        [NotNullWhen(true)] out MonetaryAmountDiscountAdjustment? value
    )
    {
        value = this.Value as MonetaryAmountDiscountAdjustment;
        return value != null;
    }

    public bool TryPickMonetaryPercentageDiscount(
        [NotNullWhen(true)] out MonetaryPercentageDiscountAdjustment? value
    )
    {
        value = this.Value as MonetaryPercentageDiscountAdjustment;
        return value != null;
    }

    public bool TryPickMonetaryMinimum([NotNullWhen(true)] out MonetaryMinimumAdjustment? value)
    {
        value = this.Value as MonetaryMinimumAdjustment;
        return value != null;
    }

    public bool TryPickMonetaryMaximum([NotNullWhen(true)] out MonetaryMaximumAdjustment? value)
    {
        value = this.Value as MonetaryMaximumAdjustment;
        return value != null;
    }

    public void Switch(
        System::Action<MonetaryUsageDiscountAdjustment> monetaryUsageDiscount,
        System::Action<MonetaryAmountDiscountAdjustment> monetaryAmountDiscount,
        System::Action<MonetaryPercentageDiscountAdjustment> monetaryPercentageDiscount,
        System::Action<MonetaryMinimumAdjustment> monetaryMinimum,
        System::Action<MonetaryMaximumAdjustment> monetaryMaximum
    )
    {
        switch (this.Value)
        {
            case MonetaryUsageDiscountAdjustment value:
                monetaryUsageDiscount(value);
                break;
            case MonetaryAmountDiscountAdjustment value:
                monetaryAmountDiscount(value);
                break;
            case MonetaryPercentageDiscountAdjustment value:
                monetaryPercentageDiscount(value);
                break;
            case MonetaryMinimumAdjustment value:
                monetaryMinimum(value);
                break;
            case MonetaryMaximumAdjustment value:
                monetaryMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    public T Match<T>(
        System::Func<MonetaryUsageDiscountAdjustment, T> monetaryUsageDiscount,
        System::Func<MonetaryAmountDiscountAdjustment, T> monetaryAmountDiscount,
        System::Func<MonetaryPercentageDiscountAdjustment, T> monetaryPercentageDiscount,
        System::Func<MonetaryMinimumAdjustment, T> monetaryMinimum,
        System::Func<MonetaryMaximumAdjustment, T> monetaryMaximum
    )
    {
        return this.Value switch
        {
            MonetaryUsageDiscountAdjustment value => monetaryUsageDiscount(value),
            MonetaryAmountDiscountAdjustment value => monetaryAmountDiscount(value),
            MonetaryPercentageDiscountAdjustment value => monetaryPercentageDiscount(value),
            MonetaryMinimumAdjustment value => monetaryMinimum(value),
            MonetaryMaximumAdjustment value => monetaryMaximum(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class AdjustmentConverter : JsonConverter<global::Orb.Models.InvoiceLineItems.Adjustment>
{
    public override global::Orb.Models.InvoiceLineItems.Adjustment? Read(
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
            case "usage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.InvoiceLineItems.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryUsageDiscountAdjustment'",
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
                    var deserialized = JsonSerializer.Deserialize<MonetaryAmountDiscountAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.InvoiceLineItems.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryAmountDiscountAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percentage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<MonetaryPercentageDiscountAdjustment>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.InvoiceLineItems.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryPercentageDiscountAdjustment'",
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
                    var deserialized = JsonSerializer.Deserialize<MonetaryMinimumAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.InvoiceLineItems.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryMinimumAdjustment'",
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
                    var deserialized = JsonSerializer.Deserialize<MonetaryMaximumAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.InvoiceLineItems.Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryMaximumAdjustment'",
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
        global::Orb.Models.InvoiceLineItems.Adjustment value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(global::Orb.Models.InvoiceLineItems.SubLineItemConverter))]
public record class SubLineItem
{
    public object Value { get; private init; }

    public string Amount
    {
        get
        {
            return Match(matrix: (x) => x.Amount, tier: (x) => x.Amount, other: (x) => x.Amount);
        }
    }

    public SubLineItemGrouping? Grouping
    {
        get
        {
            return Match<SubLineItemGrouping?>(
                matrix: (x) => x.Grouping,
                tier: (x) => x.Grouping,
                other: (x) => x.Grouping
            );
        }
    }

    public string Name
    {
        get { return Match(matrix: (x) => x.Name, tier: (x) => x.Name, other: (x) => x.Name); }
    }

    public double Quantity
    {
        get
        {
            return Match(
                matrix: (x) => x.Quantity,
                tier: (x) => x.Quantity,
                other: (x) => x.Quantity
            );
        }
    }

    public SubLineItem(MatrixSubLineItem value)
    {
        Value = value;
    }

    public SubLineItem(TierSubLineItem value)
    {
        Value = value;
    }

    public SubLineItem(OtherSubLineItem value)
    {
        Value = value;
    }

    SubLineItem(UnknownVariant value)
    {
        Value = value;
    }

    public static global::Orb.Models.InvoiceLineItems.SubLineItem CreateUnknownVariant(
        JsonElement value
    )
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickMatrix([NotNullWhen(true)] out MatrixSubLineItem? value)
    {
        value = this.Value as MatrixSubLineItem;
        return value != null;
    }

    public bool TryPickTier([NotNullWhen(true)] out TierSubLineItem? value)
    {
        value = this.Value as TierSubLineItem;
        return value != null;
    }

    public bool TryPickOther([NotNullWhen(true)] out OtherSubLineItem? value)
    {
        value = this.Value as OtherSubLineItem;
        return value != null;
    }

    public void Switch(
        System::Action<MatrixSubLineItem> matrix,
        System::Action<TierSubLineItem> tier,
        System::Action<OtherSubLineItem> other
    )
    {
        switch (this.Value)
        {
            case MatrixSubLineItem value:
                matrix(value);
                break;
            case TierSubLineItem value:
                tier(value);
                break;
            case OtherSubLineItem value:
                other(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of SubLineItem");
        }
    }

    public T Match<T>(
        System::Func<MatrixSubLineItem, T> matrix,
        System::Func<TierSubLineItem, T> tier,
        System::Func<OtherSubLineItem, T> other
    )
    {
        return this.Value switch
        {
            MatrixSubLineItem value => matrix(value),
            TierSubLineItem value => tier(value),
            OtherSubLineItem value => other(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of SubLineItem"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of SubLineItem");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class SubLineItemConverter : JsonConverter<global::Orb.Models.InvoiceLineItems.SubLineItem>
{
    public override global::Orb.Models.InvoiceLineItems.SubLineItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MatrixSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.InvoiceLineItems.SubLineItem(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MatrixSubLineItem'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tier":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TierSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.InvoiceLineItems.SubLineItem(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TierSubLineItem'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "'null'":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<OtherSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new global::Orb.Models.InvoiceLineItems.SubLineItem(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'OtherSubLineItem'",
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
        global::Orb.Models.InvoiceLineItems.SubLineItem value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
