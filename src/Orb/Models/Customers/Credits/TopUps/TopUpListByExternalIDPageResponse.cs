using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.TopUps;

[JsonConverter(
    typeof(ModelConverter<
        TopUpListByExternalIDPageResponse,
        TopUpListByExternalIDPageResponseFromRaw
    >)
)]
public sealed record class TopUpListByExternalIDPageResponse : ModelBase
{
    public required IReadOnlyList<global::Orb.Models.Customers.Credits.TopUps.DataModel> Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
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
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            if (!this._rawData.TryGetValue("pagination_metadata", out JsonElement element))
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
        init
        {
            this._rawData["pagination_metadata"] = JsonSerializer.SerializeToElement(
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

    public TopUpListByExternalIDPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUpListByExternalIDPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TopUpListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUpListByExternalIDPageResponseFromRaw : IFromRaw<TopUpListByExternalIDPageResponse>
{
    public TopUpListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUpListByExternalIDPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Customers.Credits.TopUps.DataModel,
        global::Orb.Models.Customers.Credits.TopUps.DataModelFromRaw
    >)
)]
public sealed record class DataModel : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
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
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
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
        init
        {
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this top-up. If this is a real-world
    /// currency, it must match the customer's invoicing currency.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
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
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("invoice_settings", out JsonElement element))
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
        init
        {
            this._rawData["invoice_settings"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("per_unit_cost_basis", out JsonElement element))
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
        init
        {
            this._rawData["per_unit_cost_basis"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("threshold", out JsonElement element))
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
        init
        {
            this._rawData["threshold"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("expires_after", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["expires_after"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unit of expires_after.
    /// </summary>
    public ApiEnum<string, DataModelExpiresAfterUnit>? ExpiresAfterUnit
    {
        get
        {
            if (!this._rawData.TryGetValue("expires_after_unit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, DataModelExpiresAfterUnit>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["expires_after_unit"] = JsonSerializer.SerializeToElement(
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

    public DataModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Customers.Credits.TopUps.DataModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataModelFromRaw : IFromRaw<global::Orb.Models.Customers.Credits.TopUps.DataModel>
{
    public global::Orb.Models.Customers.Credits.TopUps.DataModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Customers.Credits.TopUps.DataModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The unit of expires_after.
/// </summary>
[JsonConverter(typeof(DataModelExpiresAfterUnitConverter))]
public enum DataModelExpiresAfterUnit
{
    Day,
    Month,
}

sealed class DataModelExpiresAfterUnitConverter : JsonConverter<DataModelExpiresAfterUnit>
{
    public override DataModelExpiresAfterUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => DataModelExpiresAfterUnit.Day,
            "month" => DataModelExpiresAfterUnit.Month,
            _ => (DataModelExpiresAfterUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataModelExpiresAfterUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataModelExpiresAfterUnit.Day => "day",
                DataModelExpiresAfterUnit.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
