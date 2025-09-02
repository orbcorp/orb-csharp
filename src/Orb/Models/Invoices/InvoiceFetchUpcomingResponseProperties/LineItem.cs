using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.LineItemProperties;
using Models = Orb.Models;

namespace Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties;

[JsonConverter(typeof(ModelConverter<LineItem>))]
public sealed record class LineItem : ModelBase, IFromRaw<LineItem>
{
    /// <summary>
    /// A unique ID for this line item.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
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
                throw new ArgumentOutOfRangeException(
                    "adjusted_subtotal",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("adjusted_subtotal");
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
    public required List<Adjustment> Adjustments
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustments", out JsonElement element))
                throw new ArgumentOutOfRangeException("adjustments", "Missing required argument");

            return JsonSerializer.Deserialize<List<Adjustment>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("adjustments");
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
                throw new ArgumentOutOfRangeException("amount", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("amount");
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
                throw new ArgumentOutOfRangeException(
                    "credits_applied",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("credits_applied");
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
    public required Models::Discount? Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Models::Discount?>(
                element,
                ModelBase.SerializerOptions
            );
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
    public required DateTime EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new ArgumentOutOfRangeException("end_date", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
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
    public required Models::Maximum? Maximum
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Models::Maximum?>(
                element,
                ModelBase.SerializerOptions
            );
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
    public required Models::Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Models::Minimum?>(
                element,
                ModelBase.SerializerOptions
            );
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
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
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
                throw new ArgumentOutOfRangeException(
                    "partially_invoiced_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("partially_invoiced_amount");
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
    public required Models::Price Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                throw new ArgumentOutOfRangeException("price", "Missing required argument");

            return JsonSerializer.Deserialize<Models::Price>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("price");
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
                throw new ArgumentOutOfRangeException("quantity", "Missing required argument");

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
    public required DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new ArgumentOutOfRangeException("start_date", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
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
    public required List<SubLineItem> SubLineItems
    {
        get
        {
            if (!this.Properties.TryGetValue("sub_line_items", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "sub_line_items",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<SubLineItem>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("sub_line_items");
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
                throw new ArgumentOutOfRangeException("subtotal", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("subtotal");
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
    public required List<Models::TaxAmount> TaxAmounts
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_amounts", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_amounts", "Missing required argument");

            return JsonSerializer.Deserialize<List<Models::TaxAmount>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("tax_amounts");
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
        foreach (var item in this.UsageCustomerIDs ?? [])
        {
            _ = item;
        }
    }

    public LineItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LineItem FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
