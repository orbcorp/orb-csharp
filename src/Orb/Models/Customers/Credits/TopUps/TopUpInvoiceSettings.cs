using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.Credits.TopUps;

[JsonConverter(typeof(JsonModelConverter<TopUpInvoiceSettings, TopUpInvoiceSettingsFromRaw>))]
public sealed record class TopUpInvoiceSettings : JsonModel
{
    /// <summary>
    /// Whether the credits purchase invoice should auto collect with the customer's
    /// saved payment method.
    /// </summary>
    public required bool AutoCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("auto_collection");
        }
        init { this._rawData.Set("auto_collection", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("net_terms");
        }
        init { this._rawData.Set("net_terms", value); }
    }

    /// <summary>
    /// An optional memo to display on the invoice.
    /// </summary>
    public string? Memo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("memo");
        }
        init { this._rawData.Set("memo", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("require_successful_payment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("require_successful_payment", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AutoCollection;
        _ = this.NetTerms;
        _ = this.Memo;
        _ = this.RequireSuccessfulPayment;
    }

    public TopUpInvoiceSettings() { }

    public TopUpInvoiceSettings(TopUpInvoiceSettings topUpInvoiceSettings)
        : base(topUpInvoiceSettings) { }

    public TopUpInvoiceSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUpInvoiceSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUpInvoiceSettingsFromRaw.FromRawUnchecked"/>
    public static TopUpInvoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUpInvoiceSettingsFromRaw : IFromRawJson<TopUpInvoiceSettings>
{
    /// <inheritdoc/>
    public TopUpInvoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUpInvoiceSettings.FromRawUnchecked(rawData);
}
