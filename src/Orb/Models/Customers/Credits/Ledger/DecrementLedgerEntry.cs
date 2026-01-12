using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(JsonModelConverter<DecrementLedgerEntry, DecrementLedgerEntryFromRaw>))]
public sealed record class DecrementLedgerEntry : JsonModel
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

    public required ApiEnum<string, DecrementLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, DecrementLedgerEntryEntryStatus>>(
                "entry_status"
            );
        }
        init { this._rawData.Set("entry_status", value); }
    }

    public required ApiEnum<string, DecrementLedgerEntryEntryType> EntryType
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, DecrementLedgerEntryEntryType>>(
                "entry_type"
            );
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

    public required double StartingBalance
    {
        get { return this._rawData.GetNotNullStruct<double>("starting_balance"); }
        init { this._rawData.Set("starting_balance", value); }
    }

    public string? EventID
    {
        get { return this._rawData.GetNullableClass<string>("event_id"); }
        init { this._rawData.Set("event_id", value); }
    }

    public string? InvoiceID
    {
        get { return this._rawData.GetNullableClass<string>("invoice_id"); }
        init { this._rawData.Set("invoice_id", value); }
    }

    public string? PriceID
    {
        get { return this._rawData.GetNullableClass<string>("price_id"); }
        init { this._rawData.Set("price_id", value); }
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
        _ = this.StartingBalance;
        _ = this.EventID;
        _ = this.InvoiceID;
        _ = this.PriceID;
    }

    public DecrementLedgerEntry() { }

    public DecrementLedgerEntry(DecrementLedgerEntry decrementLedgerEntry)
        : base(decrementLedgerEntry) { }

    public DecrementLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DecrementLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DecrementLedgerEntryFromRaw.FromRawUnchecked"/>
    public static DecrementLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DecrementLedgerEntryFromRaw : IFromRawJson<DecrementLedgerEntry>
{
    /// <inheritdoc/>
    public DecrementLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DecrementLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DecrementLedgerEntryEntryStatusConverter))]
public enum DecrementLedgerEntryEntryStatus
{
    Committed,
    Pending,
}

sealed class DecrementLedgerEntryEntryStatusConverter
    : JsonConverter<DecrementLedgerEntryEntryStatus>
{
    public override DecrementLedgerEntryEntryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => DecrementLedgerEntryEntryStatus.Committed,
            "pending" => DecrementLedgerEntryEntryStatus.Pending,
            _ => (DecrementLedgerEntryEntryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DecrementLedgerEntryEntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DecrementLedgerEntryEntryStatus.Committed => "committed",
                DecrementLedgerEntryEntryStatus.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DecrementLedgerEntryEntryTypeConverter))]
public enum DecrementLedgerEntryEntryType
{
    Decrement,
}

sealed class DecrementLedgerEntryEntryTypeConverter : JsonConverter<DecrementLedgerEntryEntryType>
{
    public override DecrementLedgerEntryEntryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "decrement" => DecrementLedgerEntryEntryType.Decrement,
            _ => (DecrementLedgerEntryEntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DecrementLedgerEntryEntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DecrementLedgerEntryEntryType.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
