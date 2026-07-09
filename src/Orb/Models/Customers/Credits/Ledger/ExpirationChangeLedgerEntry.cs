using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(
    typeof(JsonModelConverter<ExpirationChangeLedgerEntry, ExpirationChangeLedgerEntryFromRaw>)
)]
public sealed record class ExpirationChangeLedgerEntry : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required AffectedBlock CreditBlock
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AffectedBlock>("credit_block");
        }
        init { this._rawData.Set("credit_block", value); }
    }

    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required CustomerMinified Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerMinified>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required double EndingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("ending_balance");
        }
        init { this._rawData.Set("ending_balance", value); }
    }

    public required ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ExpirationChangeLedgerEntryEntryStatus>
            >("entry_status");
        }
        init { this._rawData.Set("entry_status", value); }
    }

    public required ApiEnum<string, ExpirationChangeLedgerEntryEntryType> EntryType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ExpirationChangeLedgerEntryEntryType>
            >("entry_type");
        }
        init { this._rawData.Set("entry_type", value); }
    }

    public required long LedgerSequenceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("ledger_sequence_number");
        }
        init { this._rawData.Set("ledger_sequence_number", value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required System::DateTimeOffset? NewBlockExpiryDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("new_block_expiry_date");
        }
        init { this._rawData.Set("new_block_expiry_date", value); }
    }

    public required double StartingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("starting_balance");
        }
        init { this._rawData.Set("starting_balance", value); }
    }

    /// <inheritdoc/>
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
        _ = this.NewBlockExpiryDate;
        _ = this.StartingBalance;
    }

    public ExpirationChangeLedgerEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExpirationChangeLedgerEntry(ExpirationChangeLedgerEntry expirationChangeLedgerEntry)
        : base(expirationChangeLedgerEntry) { }
#pragma warning restore CS8618

    public ExpirationChangeLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpirationChangeLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExpirationChangeLedgerEntryFromRaw.FromRawUnchecked"/>
    public static ExpirationChangeLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExpirationChangeLedgerEntryFromRaw : IFromRawJson<ExpirationChangeLedgerEntry>
{
    /// <inheritdoc/>
    public ExpirationChangeLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExpirationChangeLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ExpirationChangeLedgerEntryEntryStatusConverter))]
public enum ExpirationChangeLedgerEntryEntryStatus
{
    Committed,
    Pending,
}

sealed class ExpirationChangeLedgerEntryEntryStatusConverter
    : JsonConverter<ExpirationChangeLedgerEntryEntryStatus>
{
    public override ExpirationChangeLedgerEntryEntryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => ExpirationChangeLedgerEntryEntryStatus.Committed,
            "pending" => ExpirationChangeLedgerEntryEntryStatus.Pending,
            _ => (ExpirationChangeLedgerEntryEntryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpirationChangeLedgerEntryEntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExpirationChangeLedgerEntryEntryStatus.Committed => "committed",
                ExpirationChangeLedgerEntryEntryStatus.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExpirationChangeLedgerEntryEntryTypeConverter))]
public enum ExpirationChangeLedgerEntryEntryType
{
    ExpirationChange,
}

sealed class ExpirationChangeLedgerEntryEntryTypeConverter
    : JsonConverter<ExpirationChangeLedgerEntryEntryType>
{
    public override ExpirationChangeLedgerEntryEntryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "expiration_change" => ExpirationChangeLedgerEntryEntryType.ExpirationChange,
            _ => (ExpirationChangeLedgerEntryEntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpirationChangeLedgerEntryEntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExpirationChangeLedgerEntryEntryType.ExpirationChange => "expiration_change",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
