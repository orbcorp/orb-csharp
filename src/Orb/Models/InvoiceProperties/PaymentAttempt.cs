using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PaymentAttemptProperties = Orb.Models.InvoiceProperties.PaymentAttemptProperties;
using System = System;

namespace Orb.Models.InvoiceProperties;

[JsonConverter(typeof(ModelConverter<PaymentAttempt>))]
public sealed record class PaymentAttempt : ModelBase, IFromRaw<PaymentAttempt>
{
    /// <summary>
    /// The ID of the payment attempt.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The amount of the payment attempt.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The time at which the payment attempt was created.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The payment provider that attempted to collect the payment.
    /// </summary>
    public required PaymentAttemptProperties::PaymentProvider? PaymentProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_provider", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "payment_provider",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<PaymentAttemptProperties::PaymentProvider?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["payment_provider"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The ID of the payment attempt in the payment provider.
    /// </summary>
    public required string? PaymentProviderID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_provider_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "payment_provider_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["payment_provider_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Whether the payment attempt succeeded.
    /// </summary>
    public required bool Succeeded
    {
        get
        {
            if (!this.Properties.TryGetValue("succeeded", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "succeeded",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["succeeded"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.PaymentProvider?.Validate();
        _ = this.PaymentProviderID;
        _ = this.Succeeded;
    }

    public PaymentAttempt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentAttempt(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PaymentAttempt FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
