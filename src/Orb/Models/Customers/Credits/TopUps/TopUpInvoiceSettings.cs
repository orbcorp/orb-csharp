using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Customers.Credits.TopUps;

[JsonConverter(typeof(ModelConverter<TopUpInvoiceSettings, TopUpInvoiceSettingsFromRaw>))]
public sealed record class TopUpInvoiceSettings : ModelBase
{
    /// <summary>
    /// Whether the credits purchase invoice should auto collect with the customer's
    /// saved payment method.
    /// </summary>
    public required bool AutoCollection
    {
        get
        {
            if (!this._rawData.TryGetValue("auto_collection", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'auto_collection' cannot be null",
                    new ArgumentOutOfRangeException("auto_collection", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The net terms determines the difference between the invoice date and the
    /// issue date for the invoice. If you intend the invoice to be due on issue,
    /// set this to 0.
    /// </summary>
    public required long NetTerms
    {
        get
        {
            if (!this._rawData.TryGetValue("net_terms", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'net_terms' cannot be null",
                    new ArgumentOutOfRangeException("net_terms", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["net_terms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional memo to display on the invoice.
    /// </summary>
    public string? Memo
    {
        get
        {
            if (!this._rawData.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When true, credit blocks created by this top-up will require that the corresponding
    /// invoice is paid before they are drawn down from. If any topup block is pending
    /// payment, further automatic top-ups will be paused until the invoice is paid
    /// or voided.
    /// </summary>
    public bool? RequireSuccessfulPayment
    {
        get
        {
            if (!this._rawData.TryGetValue("require_successful_payment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["require_successful_payment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AutoCollection;
        _ = this.NetTerms;
        _ = this.Memo;
        _ = this.RequireSuccessfulPayment;
    }

    public TopUpInvoiceSettings() { }

    public TopUpInvoiceSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUpInvoiceSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TopUpInvoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUpInvoiceSettingsFromRaw : IFromRaw<TopUpInvoiceSettings>
{
    public TopUpInvoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUpInvoiceSettings.FromRawUnchecked(rawData);
}
