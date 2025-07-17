using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using DataProperties = Orb.Models.Customers.Credits.CreditListByExternalIDPageResponseProperties.DataProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.CreditListByExternalIDPageResponseProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Data>))]
public sealed record class Data : Orb::ModelBase, Orb::IFromRaw<Data>
{
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

    public required double Balance
    {
        get
        {
            if (!this.Properties.TryGetValue("balance", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "balance",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["balance"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime? EffectiveDate
    {
        get
        {
            if (!this.Properties.TryGetValue("effective_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "effective_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["effective_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime? ExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "expiry_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["expiry_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double? MaximumInitialBalance
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "maximum_initial_balance",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "maximum_initial_balance",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set
        {
            this.Properties["maximum_initial_balance"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required string? PerUnitCostBasis
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_cost_basis", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "per_unit_cost_basis",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["per_unit_cost_basis"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required DataProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "status",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<DataProperties::Status>(element)
                ?? throw new System::ArgumentNullException("status");
        }
        set { this.Properties["status"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    Data(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
