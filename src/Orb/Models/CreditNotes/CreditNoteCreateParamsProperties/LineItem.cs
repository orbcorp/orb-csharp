using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNotes.CreditNoteCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<LineItem>))]
public sealed record class LineItem : Orb::ModelBase, Orb::IFromRaw<LineItem>
{
    /// <summary>
    /// The total amount in the invoice's currency to credit this line item.
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
    /// The ID of the line item to credit.
    /// </summary>
    public required string InvoiceLineItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_line_item_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoice_line_item_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("invoice_line_item_id");
        }
        set
        {
            this.Properties["invoice_line_item_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// A date string to specify this line item's credit note service period end date
    /// in the customer's timezone. If provided, this will be used for this specific
    /// line item. If not provided, will use the global end_date if available, otherwise
    /// defaults to the original invoice line item's end date. This date is inclusive.
    /// </summary>
    public System::DateOnly? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify this line item's credit note service period start
    /// date in the customer's timezone. If provided, this will be used for this specific
    /// line item. If not provided, will use the global start_date if available, otherwise
    /// defaults to the original invoice line item's start date. This date is inclusive.
    /// </summary>
    public System::DateOnly? StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.InvoiceLineItemID;
        _ = this.EndDate;
        _ = this.StartDate;
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
