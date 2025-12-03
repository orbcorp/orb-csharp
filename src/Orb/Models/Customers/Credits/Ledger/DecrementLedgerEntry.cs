using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(ModelConverter<DecrementLedgerEntry, DecrementLedgerEntryFromRaw>))]
public sealed record class DecrementLedgerEntry : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required double Amount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required AffectedBlock CreditBlock
    {
        get { return ModelBase.GetNotNullClass<AffectedBlock>(this.RawData, "credit_block"); }
        init { ModelBase.Set(this._rawData, "credit_block", value); }
    }

    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    public required CustomerMinified Customer
    {
        get { return ModelBase.GetNotNullClass<CustomerMinified>(this.RawData, "customer"); }
        init { ModelBase.Set(this._rawData, "customer", value); }
    }

    public required string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    public required double EndingBalance
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "ending_balance"); }
        init { ModelBase.Set(this._rawData, "ending_balance", value); }
    }

    public required ApiEnum<string, DecrementLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DecrementLedgerEntryEntryStatus>>(
                this.RawData,
                "entry_status"
            );
        }
        init { ModelBase.Set(this._rawData, "entry_status", value); }
    }

    public required ApiEnum<string, DecrementLedgerEntryEntryType> EntryType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DecrementLedgerEntryEntryType>>(
                this.RawData,
                "entry_type"
            );
        }
        init { ModelBase.Set(this._rawData, "entry_type", value); }
    }

    public required long LedgerSequenceNumber
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "ledger_sequence_number"); }
        init { ModelBase.Set(this._rawData, "ledger_sequence_number", value); }
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
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    public required double StartingBalance
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "starting_balance"); }
        init { ModelBase.Set(this._rawData, "starting_balance", value); }
    }

    public string? EventID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "event_id"); }
        init { ModelBase.Set(this._rawData, "event_id", value); }
    }

    public string? InvoiceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "invoice_id"); }
        init { ModelBase.Set(this._rawData, "invoice_id", value); }
    }

    public string? PriceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "price_id"); }
        init { ModelBase.Set(this._rawData, "price_id", value); }
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

    public DecrementLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DecrementLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class DecrementLedgerEntryFromRaw : IFromRaw<DecrementLedgerEntry>
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
