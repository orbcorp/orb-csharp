using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using LineItemProperties = Orb.Models.CreditNoteProperties.LineItemProperties;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<LineItem>))]
public sealed record class LineItem : Orb::ModelBase, Orb::IFromRaw<LineItem>
{
    /// <summary>
    /// The Orb id of this resource.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The amount of the line item, including any line item minimums and discounts.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the item associated with this line item.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "item_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("item_id");
        }
        set { this.Properties["item_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the corresponding invoice line item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional quantity credited.
    /// </summary>
    public required double? Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The amount of the line item, excluding any line item minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subtotal",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("subtotal");
        }
        set { this.Properties["subtotal"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any tax amounts applied onto the line item.
    /// </summary>
    public required Generic::List<Models::TaxAmount> TaxAmounts
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_amounts", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_amounts",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::TaxAmount>>(element)
                ?? throw new System::ArgumentNullException("tax_amounts");
        }
        set { this.Properties["tax_amounts"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any line item discounts from the invoice's line item.
    /// </summary>
    public Generic::List<LineItemProperties::Discount>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<LineItemProperties::Discount>?>(
                element
            );
        }
        set { this.Properties["discounts"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end time of the service period for this credit note line item.
    /// </summary>
    public System::DateTime? EndTimeExclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("end_time_exclusive", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.Properties["end_time_exclusive"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The start time of the service period for this credit note line item.
    /// </summary>
    public System::DateTime? StartTimeInclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("start_time_inclusive", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.Properties["start_time_inclusive"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
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
    [CodeAnalysis::SetsRequiredMembers]
    LineItem(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LineItem FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
