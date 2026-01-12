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
    typeof(JsonModelConverter<VoidInitiatedLedgerEntry, VoidInitiatedLedgerEntryFromRaw>)
)]
public sealed record class VoidInitiatedLedgerEntry : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required double Amount
    {
        get { return this._rawData.GetNotNullStruct<double>("amount"); }
        init { this._rawData.Set("amount", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    public required AffectedBlock CreditBlock
    {
        get { return this._rawData.GetNotNullClass<AffectedBlock>("credit_block"); }
        init { this._rawData.Set("credit_block", value); }
    }

    public required string Currency
    {
        get { return this._rawData.GetNotNullClass<string>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    public required CustomerMinified Customer
    {
        get { return this._rawData.GetNotNullClass<CustomerMinified>("customer"); }
        init { this._rawData.Set("customer", value); }
    }

    public required string? Description
    {
        get { return this._rawData.GetNullableClass<string>("description"); }
        init { this._rawData.Set("description", value); }
    }

    public required double EndingBalance
    {
        get { return this._rawData.GetNotNullStruct<double>("ending_balance"); }
        init { this._rawData.Set("ending_balance", value); }
    }

    public required ApiEnum<string, VoidInitiatedLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VoidInitiatedLedgerEntryEntryStatus>
            >("entry_status");
        }
        init { this._rawData.Set("entry_status", value); }
    }

    public required ApiEnum<string, VoidInitiatedLedgerEntryEntryType> EntryType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VoidInitiatedLedgerEntryEntryType>
            >("entry_type");
        }
        init { this._rawData.Set("entry_type", value); }
    }

    public required long LedgerSequenceNumber
    {
        get { return this._rawData.GetNotNullStruct<long>("ledger_sequence_number"); }
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
        get { return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata"); }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required System::DateTimeOffset NewBlockExpiryDate
    {
        get
        {
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("new_block_expiry_date");
        }
        init { this._rawData.Set("new_block_expiry_date", value); }
    }

    public required double StartingBalance
    {
        get { return this._rawData.GetNotNullStruct<double>("starting_balance"); }
        init { this._rawData.Set("starting_balance", value); }
    }

    public required double VoidAmount
    {
        get { return this._rawData.GetNotNullStruct<double>("void_amount"); }
        init { this._rawData.Set("void_amount", value); }
    }

    public required string? VoidReason
    {
        get { return this._rawData.GetNullableClass<string>("void_reason"); }
        init { this._rawData.Set("void_reason", value); }
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
        _ = this.VoidAmount;
        _ = this.VoidReason;
    }

    public VoidInitiatedLedgerEntry() { }

    public VoidInitiatedLedgerEntry(VoidInitiatedLedgerEntry voidInitiatedLedgerEntry)
        : base(voidInitiatedLedgerEntry) { }

    public VoidInitiatedLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoidInitiatedLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoidInitiatedLedgerEntryFromRaw.FromRawUnchecked"/>
    public static VoidInitiatedLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoidInitiatedLedgerEntryFromRaw : IFromRawJson<VoidInitiatedLedgerEntry>
{
    /// <inheritdoc/>
    public VoidInitiatedLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VoidInitiatedLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(VoidInitiatedLedgerEntryEntryStatusConverter))]
public enum VoidInitiatedLedgerEntryEntryStatus
{
    Committed,
    Pending,
}

sealed class VoidInitiatedLedgerEntryEntryStatusConverter
    : JsonConverter<VoidInitiatedLedgerEntryEntryStatus>
{
    public override VoidInitiatedLedgerEntryEntryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => VoidInitiatedLedgerEntryEntryStatus.Committed,
            "pending" => VoidInitiatedLedgerEntryEntryStatus.Pending,
            _ => (VoidInitiatedLedgerEntryEntryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoidInitiatedLedgerEntryEntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VoidInitiatedLedgerEntryEntryStatus.Committed => "committed",
                VoidInitiatedLedgerEntryEntryStatus.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(VoidInitiatedLedgerEntryEntryTypeConverter))]
public enum VoidInitiatedLedgerEntryEntryType
{
    VoidInitiated,
}

sealed class VoidInitiatedLedgerEntryEntryTypeConverter
    : JsonConverter<VoidInitiatedLedgerEntryEntryType>
{
    public override VoidInitiatedLedgerEntryEntryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "void_initiated" => VoidInitiatedLedgerEntryEntryType.VoidInitiated,
            _ => (VoidInitiatedLedgerEntryEntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoidInitiatedLedgerEntryEntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VoidInitiatedLedgerEntryEntryType.VoidInitiated => "void_initiated",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
