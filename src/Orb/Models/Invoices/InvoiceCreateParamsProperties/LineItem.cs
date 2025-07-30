using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LineItemProperties = Orb.Models.Invoices.InvoiceCreateParamsProperties.LineItemProperties;
using Models = Orb.Models;

namespace Orb.Models.Invoices.InvoiceCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<LineItem>))]
public sealed record class LineItem : ModelBase, IFromRaw<LineItem>
{
    /// <summary>
    /// A date string to specify the line item's end date in the customer's timezone.
    /// </summary>
    public required DateOnly EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new ArgumentOutOfRangeException("end_date", "Missing required argument");

            return JsonSerializer.Deserialize<DateOnly>(element);
        }
        set { this.Properties["end_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("item_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("item_id");
        }
        set { this.Properties["item_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required LineItemProperties::ModelType ModelType
    {
        get
        {
            if (!this.Properties.TryGetValue("model_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("model_type", "Missing required argument");

            return JsonSerializer.Deserialize<LineItemProperties::ModelType>(element)
                ?? throw new ArgumentNullException("model_type");
        }
        set { this.Properties["model_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the line item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of units on the line item
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new ArgumentOutOfRangeException("quantity", "Missing required argument");

            return JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify the line item's start date in the customer's timezone.
    /// </summary>
    public required DateOnly StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new ArgumentOutOfRangeException("start_date", "Missing required argument");

            return JsonSerializer.Deserialize<DateOnly>(element);
        }
        set { this.Properties["start_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::UnitConfig UnitConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_config", out JsonElement element))
                throw new ArgumentOutOfRangeException("unit_config", "Missing required argument");

            return JsonSerializer.Deserialize<Models::UnitConfig>(element)
                ?? throw new ArgumentNullException("unit_config");
        }
        set { this.Properties["unit_config"] = JsonSerializer.SerializeToElement(value); }
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
