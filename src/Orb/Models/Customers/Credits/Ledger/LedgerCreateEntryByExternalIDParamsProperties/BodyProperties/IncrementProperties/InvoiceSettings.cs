using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties;

/// <summary>
/// Passing `invoice_settings` automatically generates an invoice for the newly added
/// credits. If `invoice_settings` is passed, you must specify per_unit_cost_basis,
/// as the calculation of the invoice total is done on that basis.
/// </summary>
[JsonConverter(typeof(ModelConverter<InvoiceSettings>))]
public sealed record class InvoiceSettings : ModelBase, IFromRaw<InvoiceSettings>
{
    /// <summary>
    /// Whether the credits purchase invoice should auto collect with the customer's
    /// saved payment method.
    /// </summary>
    public required bool AutoCollection
    {
        get
        {
            if (!this.Properties.TryGetValue("auto_collection", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "auto_collection",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The net terms determines the due date of the invoice. Due date is calculated
    /// based on the invoice or issuance date, depending on the account's configured
    /// due date calculation method. A value of '0' here represents that the invoice
    /// is due on issue, whereas a value of '30' represents that the customer has
    /// 30 days to pay the invoice. Do not set this field if you want to set a custom
    /// due date.
    /// </summary>
    public required long? NetTerms
    {
        get
        {
            if (!this.Properties.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["net_terms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional custom due date for the invoice. If not set, the due date will
    /// be calculated based on the `net_terms` value.
    /// </summary>
    public CustomDueDate? CustomDueDate
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomDueDate?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["custom_due_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 8601 format date that denotes when this invoice should be dated in
    /// the customer's timezone. If not provided, the invoice date will default to
    /// the credit block's effective date.
    /// </summary>
    public InvoiceDate? InvoiceDate
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceDate?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["invoice_date"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, the new credit block will require that the corresponding invoice
    /// is paid before it can be drawn down from.
    /// </summary>
    public bool? RequireSuccessfulPayment
    {
        get
        {
            if (!this.Properties.TryGetValue("require_successful_payment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["require_successful_payment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AutoCollection;
        _ = this.NetTerms;
        this.CustomDueDate?.Validate();
        this.InvoiceDate?.Validate();
        _ = this.Memo;
        _ = this.RequireSuccessfulPayment;
    }

    public InvoiceSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceSettings(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InvoiceSettings FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
