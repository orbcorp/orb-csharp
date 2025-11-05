using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(ModelConverter<AmendmentLedgerEntry>))]
public sealed record class AmendmentLedgerEntry : ModelBase, IFromRaw<AmendmentLedgerEntry>
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

    public required double Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public required AffectedBlock CreditBlock
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_block", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'credit_block' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "credit_block",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AffectedBlock>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'credit_block' cannot be null",
                    new System::ArgumentNullException("credit_block")
                );
        }
        set
        {
            this.Properties["credit_block"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public required CustomerMinified Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerMinified>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentNullException("customer")
                );
        }
        set
        {
            this.Properties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public required double EndingBalance
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

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ending_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, EntryStatus1> EntryStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_status' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "entry_status",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, EntryStatus1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["entry_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, EntryType11> EntryType
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "entry_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, EntryType11>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["entry_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long LedgerSequenceNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("ledger_sequence_number", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'ledger_sequence_number' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "ledger_sequence_number",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ledger_sequence_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double StartingBalance
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

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["starting_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.CreditBlock.Validate();
        _ = this.Currency;
        this.Customer.Validate();
        _ = this.Description;
        _ = this.EndingBalance;
        this.EntryStatus.Validate();
        this.EntryType.Validate();
        _ = this.LedgerSequenceNumber;
        _ = this.Metadata;
        _ = this.StartingBalance;
    }

    public AmendmentLedgerEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmendmentLedgerEntry(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AmendmentLedgerEntry FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(EntryStatus1Converter))]
public enum EntryStatus1
{
    Committed,
    Pending,
}

sealed class EntryStatus1Converter : JsonConverter<EntryStatus1>
{
    public override EntryStatus1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => EntryStatus1.Committed,
            "pending" => EntryStatus1.Pending,
            _ => (EntryStatus1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryStatus1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryStatus1.Committed => "committed",
                EntryStatus1.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EntryType11Converter))]
public enum EntryType11
{
    Amendment,
}

sealed class EntryType11Converter : JsonConverter<EntryType11>
{
    public override EntryType11 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amendment" => EntryType11.Amendment,
            _ => (EntryType11)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryType11 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryType11.Amendment => "amendment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
