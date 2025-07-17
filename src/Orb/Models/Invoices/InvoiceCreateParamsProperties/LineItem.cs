using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using LineItemProperties = Orb.Models.Invoices.InvoiceCreateParamsProperties.LineItemProperties;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Invoices.InvoiceCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<LineItem>))]
public sealed record class LineItem : Orb::ModelBase, Orb::IFromRaw<LineItem>
{
    /// <summary>
    /// A date string to specify the line item's end date in the customer's timezone.
    /// </summary>
    public required System::DateOnly EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateOnly>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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

    public required LineItemProperties::ModelType ModelType
    {
        get
        {
            if (!this.Properties.TryGetValue("model_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "model_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<LineItemProperties::ModelType>(element)
                ?? throw new System::ArgumentNullException("model_type");
        }
        set { this.Properties["model_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the line item.
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
    /// The number of units on the line item
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify the line item's start date in the customer's timezone.
    /// </summary>
    public required System::DateOnly StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateOnly>(element);
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::UnitConfig UnitConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_config", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "unit_config",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::UnitConfig>(element)
                ?? throw new System::ArgumentNullException("unit_config");
        }
        set { this.Properties["unit_config"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.EndDate;
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.Quantity;
        _ = this.StartDate;
        this.UnitConfig.Validate();
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
