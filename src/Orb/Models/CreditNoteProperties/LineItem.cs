using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LineItemProperties = Orb.Models.CreditNoteProperties.LineItemProperties;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[JsonConverter(typeof(ModelConverter<LineItem>))]
public sealed record class LineItem : ModelBase, IFromRaw<LineItem>
{
    /// <summary>
    /// The Orb id of this resource.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The amount of the line item, including any line item minimums and discounts.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the item associated with this line item.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "item_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("item_id");
        }
        set { this.Properties["item_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the corresponding invoice line item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional quantity credited.
    /// </summary>
    public required double? Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The amount of the line item, excluding any line item minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subtotal",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("subtotal");
        }
        set { this.Properties["subtotal"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any tax amounts applied onto the line item.
    /// </summary>
    public required List<TaxAmount> TaxAmounts
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_amounts", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_amounts",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<TaxAmount>>(element)
                ?? throw new System::ArgumentNullException("tax_amounts");
        }
        set { this.Properties["tax_amounts"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any line item discounts from the invoice's line item.
    /// </summary>
    public List<LineItemProperties::Discount>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<LineItemProperties::Discount>?>(element);
        }
        set { this.Properties["discounts"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end time of the service period for this credit note line item.
    /// </summary>
    public System::DateTime? EndTimeExclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("end_time_exclusive", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["end_time_exclusive"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The start time of the service period for this credit note line item.
    /// </summary>
    public System::DateTime? StartTimeInclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("start_time_inclusive", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["start_time_inclusive"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.ItemID;
        _ = this.Name;
        _ = this.Quantity;
        _ = this.Subtotal;
        foreach (var item in this.TaxAmounts)
        {
            item.Validate();
        }
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        _ = this.EndTimeExclusive;
        _ = this.StartTimeInclusive;
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
