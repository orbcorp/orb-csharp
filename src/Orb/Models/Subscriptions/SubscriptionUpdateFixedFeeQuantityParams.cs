using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to update the quantity for a fixed fee.
///
/// To be eligible, the subscription must currently be active and the price specified
/// must be a fixed fee (not usage-based). This operation will immediately update
/// the quantity for the fee, or if a `effective_date` is passed in, will update
/// the quantity on the requested date at midnight in the customer's timezone.
///
/// In order to change the fixed fee quantity as of the next draft invoice for this
/// subscription, pass `change_option=upcoming_invoice` without an `effective_date` specified.
///
/// If the fee is an in-advance fixed fee, it will also issue an immediate invoice
/// for the difference for the remainder of the billing period.
/// </summary>
public sealed record class SubscriptionUpdateFixedFeeQuantityParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// Price for which the quantity should be updated. Must be a fixed fee.
    /// </summary>
    public required string PriceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price_id' cannot be null",
                    new System::ArgumentOutOfRangeException("price_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'price_id' cannot be null",
                    new System::ArgumentNullException("price_id")
                );
        }
        set
        {
            this.BodyProperties["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double Quantity
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If false, this request will fail if it would void an issued invoice or create
    /// a credit note. Consider using this as a safety mechanism if you do not expect
    /// existing invoices to be changed.
    /// </summary>
    public bool? AllowInvoiceCreditOrVoid
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "allow_invoice_credit_or_void",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["allow_invoice_credit_or_void"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determines when the change takes effect. Note that if `effective_date` is
    /// specified, this defaults to `effective_date`. Otherwise, this defaults to
    /// `immediate` unless it's explicitly set to `upcoming_invoice`.
    /// </summary>
    public ApiEnum<string, ChangeOption1>? ChangeOption
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("change_option", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ChangeOption1>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["change_option"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The date that the quantity change should take effect, localized to the customer's
    /// timezone. If this parameter is not passed in, the quantity change is effective
    /// according to `change_option`.
    /// </summary>
    public System::DateOnly? EffectiveDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("effective_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["effective_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/update_fixed_fee_quantity", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Determines when the change takes effect. Note that if `effective_date` is specified,
/// this defaults to `effective_date`. Otherwise, this defaults to `immediate` unless
/// it's explicitly set to `upcoming_invoice`.
/// </summary>
[JsonConverter(typeof(ChangeOption1Converter))]
public enum ChangeOption1
{
    Immediate,
    UpcomingInvoice,
    EffectiveDate,
}

sealed class ChangeOption1Converter : JsonConverter<ChangeOption1>
{
    public override ChangeOption1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediate" => ChangeOption1.Immediate,
            "upcoming_invoice" => ChangeOption1.UpcomingInvoice,
            "effective_date" => ChangeOption1.EffectiveDate,
            _ => (ChangeOption1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChangeOption1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChangeOption1.Immediate => "immediate",
                ChangeOption1.UpcomingInvoice => "upcoming_invoice",
                ChangeOption1.EffectiveDate => "effective_date",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
