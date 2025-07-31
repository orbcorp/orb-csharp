using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataProperties = Orb.Models.Customers.Credits.CreditListByExternalIDPageResponseProperties.DataProperties;

namespace Orb.Models.Customers.Credits.CreditListByExternalIDPageResponseProperties;

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double Balance
    {
        get
        {
            if (!this.Properties.TryGetValue("balance", out JsonElement element))
                throw new ArgumentOutOfRangeException("balance", "Missing required argument");

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["balance"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DateTime? EffectiveDate
    {
        get
        {
            if (!this.Properties.TryGetValue("effective_date", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "effective_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["effective_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DateTime? ExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry_date", out JsonElement element))
                throw new ArgumentOutOfRangeException("expiry_date", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["expiry_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double? MaximumInitialBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_initial_balance", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "maximum_initial_balance",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum_initial_balance"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public required string? PerUnitCostBasis
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_cost_basis", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "per_unit_cost_basis",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["per_unit_cost_basis"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DataProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new ArgumentOutOfRangeException("status", "Missing required argument");

            return JsonSerializer.Deserialize<DataProperties::Status>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("status");
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Balance;
        _ = this.EffectiveDate;
        _ = this.ExpiryDate;
        _ = this.MaximumInitialBalance;
        _ = this.PerUnitCostBasis;
        this.Status.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
