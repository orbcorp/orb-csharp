using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.TopUps;

[JsonConverter(typeof(ModelConverter<TopUpListByExternalIDPageResponse>))]
public sealed record class TopUpListByExternalIDPageResponse
    : ModelBase,
        IFromRaw<TopUpListByExternalIDPageResponse>
{
    public required List<global::Orb.Models.Customers.Credits.TopUps.DataModel> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                    List<global::Orb.Models.Customers.Credits.TopUps.DataModel>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'pagination_metadata' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "pagination_metadata",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PaginationMetadata>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'pagination_metadata' cannot be null",
                    new System::ArgumentNullException("pagination_metadata")
                );
        }
        set
        {
            this.Properties["pagination_metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public TopUpListByExternalIDPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUpListByExternalIDPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TopUpListByExternalIDPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Customers.Credits.TopUps.DataModel>))]
public sealed record class DataModel
    : ModelBase,
        IFromRaw<global::Orb.Models.Customers.Credits.TopUps.DataModel>
{
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
    /// The amount to increment when the threshold is reached.
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
    /// The currency or custom pricing unit to use for this top-up. If this is a
    /// real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
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
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Settings for invoices generated by triggered top-ups.
    /// </summary>
    public required TopUpInvoiceSettings InvoiceSettings
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_settings", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_settings' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "invoice_settings",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TopUpInvoiceSettings>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'invoice_settings' cannot be null",
                    new System::ArgumentNullException("invoice_settings")
                );
        }
        set
        {
            this.Properties["invoice_settings"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// How much, in the customer's currency, to charge for each unit.
    /// </summary>
    public required string PerUnitCostBasis
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_cost_basis", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'per_unit_cost_basis' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "per_unit_cost_basis",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'per_unit_cost_basis' cannot be null",
                    new System::ArgumentNullException("per_unit_cost_basis")
                );
        }
        set
        {
            this.Properties["per_unit_cost_basis"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The threshold at which to trigger the top-up. If the balance is at or below
    /// this threshold, the top-up will be triggered.
    /// </summary>
    public required string Threshold
    {
        get
        {
            if (!this.Properties.TryGetValue("threshold", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'threshold' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "threshold",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'threshold' cannot be null",
                    new System::ArgumentNullException("threshold")
                );
        }
        set
        {
            this.Properties["threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of days or months after which the top-up expires. If unspecified,
    /// it does not expire.
    /// </summary>
    public long? ExpiresAfter
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_after", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expires_after"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unit of expires_after.
    /// </summary>
    public ApiEnum<string, ExpiresAfterUnit4>? ExpiresAfterUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_after_unit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ExpiresAfterUnit4>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["expires_after_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.Currency;
        this.InvoiceSettings.Validate();
        _ = this.PerUnitCostBasis;
        _ = this.Threshold;
        _ = this.ExpiresAfter;
        this.ExpiresAfterUnit?.Validate();
    }

    public DataModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Customers.Credits.TopUps.DataModel FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// The unit of expires_after.
/// </summary>
[JsonConverter(typeof(ExpiresAfterUnit4Converter))]
public enum ExpiresAfterUnit4
{
    Day,
    Month,
}

sealed class ExpiresAfterUnit4Converter : JsonConverter<ExpiresAfterUnit4>
{
    public override ExpiresAfterUnit4 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => ExpiresAfterUnit4.Day,
            "month" => ExpiresAfterUnit4.Month,
            _ => (ExpiresAfterUnit4)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpiresAfterUnit4 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExpiresAfterUnit4.Day => "day",
                ExpiresAfterUnit4.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
