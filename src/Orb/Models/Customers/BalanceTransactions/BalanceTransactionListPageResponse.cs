using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.BalanceTransactions;

[JsonConverter(typeof(ModelConverter<BalanceTransactionListPageResponse>))]
public sealed record class BalanceTransactionListPageResponse
    : ModelBase,
        IFromRaw<BalanceTransactionListPageResponse>
{
    public required List<Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Data>>(element, ModelBase.SerializerOptions)
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

    public BalanceTransactionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BalanceTransactionListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
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

    public required ApiEnum<
        string,
        global::Orb.Models.Customers.BalanceTransactions.ActionModel
    > Action
    {
        get
        {
            if (!this.Properties.TryGetValue("action", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.BalanceTransactions.ActionModel>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
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
    /// The creation time of this transaction.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CreditNoteTiny? CreditNote
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CreditNoteTiny?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["credit_note"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the
    /// customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("ending_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "ending_balance",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new System::ArgumentNullException("ending_balance")
                );
        }
        set
        {
            this.Properties["ending_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required InvoiceTiny? Invoice
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceTiny?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["invoice"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in
    /// the customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("starting_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "starting_balance",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new System::ArgumentNullException("starting_balance")
                );
        }
        set
        {
            this.Properties["starting_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Customers.BalanceTransactions.Type1> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.BalanceTransactions.Type1>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.Action.Validate();
        _ = this.Amount;
        _ = this.CreatedAt;
        this.CreditNote?.Validate();
        _ = this.Description;
        _ = this.EndingBalance;
        this.Invoice?.Validate();
        _ = this.StartingBalance;
        this.Type.Validate();
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

[JsonConverter(typeof(global::Orb.Models.Customers.BalanceTransactions.ActionModelConverter))]
public enum ActionModel
{
    AppliedToInvoice,
    ManualAdjustment,
    ProratedRefund,
    RevertProratedRefund,
    ReturnFromVoiding,
    CreditNoteApplied,
    CreditNoteVoided,
    OverpaymentRefund,
    ExternalPayment,
    SmallInvoiceCarryover,
}

sealed class ActionModelConverter
    : JsonConverter<global::Orb.Models.Customers.BalanceTransactions.ActionModel>
{
    public override global::Orb.Models.Customers.BalanceTransactions.ActionModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .AppliedToInvoice,
            "manual_adjustment" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .ManualAdjustment,
            "prorated_refund" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .ProratedRefund,
            "revert_prorated_refund" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .RevertProratedRefund,
            "return_from_voiding" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .ReturnFromVoiding,
            "credit_note_applied" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .CreditNoteApplied,
            "credit_note_voided" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .CreditNoteVoided,
            "overpayment_refund" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .OverpaymentRefund,
            "external_payment" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .ExternalPayment,
            "small_invoice_carryover" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .ActionModel
                .SmallInvoiceCarryover,
            _ => (global::Orb.Models.Customers.BalanceTransactions.ActionModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.BalanceTransactions.ActionModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.AppliedToInvoice =>
                    "applied_to_invoice",
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.ManualAdjustment =>
                    "manual_adjustment",
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.ProratedRefund =>
                    "prorated_refund",
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.RevertProratedRefund =>
                    "revert_prorated_refund",
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.ReturnFromVoiding =>
                    "return_from_voiding",
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.CreditNoteApplied =>
                    "credit_note_applied",
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.CreditNoteVoided =>
                    "credit_note_voided",
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.OverpaymentRefund =>
                    "overpayment_refund",
                global::Orb.Models.Customers.BalanceTransactions.ActionModel.ExternalPayment =>
                    "external_payment",
                global::Orb
                    .Models
                    .Customers
                    .BalanceTransactions
                    .ActionModel
                    .SmallInvoiceCarryover => "small_invoice_carryover",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.Customers.BalanceTransactions.Type1Converter))]
public enum Type1
{
    Increment,
    Decrement,
}

sealed class Type1Converter : JsonConverter<global::Orb.Models.Customers.BalanceTransactions.Type1>
{
    public override global::Orb.Models.Customers.BalanceTransactions.Type1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => global::Orb.Models.Customers.BalanceTransactions.Type1.Increment,
            "decrement" => global::Orb.Models.Customers.BalanceTransactions.Type1.Decrement,
            _ => (global::Orb.Models.Customers.BalanceTransactions.Type1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.BalanceTransactions.Type1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.BalanceTransactions.Type1.Increment => "increment",
                global::Orb.Models.Customers.BalanceTransactions.Type1.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
