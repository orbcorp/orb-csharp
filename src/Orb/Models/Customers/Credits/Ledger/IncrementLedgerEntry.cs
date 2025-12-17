using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(JsonModelConverter<IncrementLedgerEntry, IncrementLedgerEntryFromRaw>))]
public sealed record class IncrementLedgerEntry : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required double Amount
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required AffectedBlock CreditBlock
    {
        get { return JsonModel.GetNotNullClass<AffectedBlock>(this.RawData, "credit_block"); }
        init { JsonModel.Set(this._rawData, "credit_block", value); }
    }

    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    public required CustomerMinified Customer
    {
        get { return JsonModel.GetNotNullClass<CustomerMinified>(this.RawData, "customer"); }
        init { JsonModel.Set(this._rawData, "customer", value); }
    }

    public required string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    public required double EndingBalance
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "ending_balance"); }
        init { JsonModel.Set(this._rawData, "ending_balance", value); }
    }

    public required ApiEnum<string, IncrementLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, IncrementLedgerEntryEntryStatus>>(
                this.RawData,
                "entry_status"
            );
        }
        init { JsonModel.Set(this._rawData, "entry_status", value); }
    }

    public required ApiEnum<string, IncrementLedgerEntryEntryType> EntryType
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, IncrementLedgerEntryEntryType>>(
                this.RawData,
                "entry_type"
            );
        }
        init { JsonModel.Set(this._rawData, "entry_type", value); }
    }

    public required long LedgerSequenceNumber
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "ledger_sequence_number"); }
        init { JsonModel.Set(this._rawData, "ledger_sequence_number", value); }
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
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    public required double StartingBalance
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "starting_balance"); }
        init { JsonModel.Set(this._rawData, "starting_balance", value); }
    }

    /// <summary>
    /// If the increment resulted in invoice creation, the list of created invoices
    /// </summary>
    public IReadOnlyList<Invoice>? CreatedInvoices
    {
        get { return JsonModel.GetNullableClass<List<Invoice>>(this.RawData, "created_invoices"); }
        init { JsonModel.Set(this._rawData, "created_invoices", value); }
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
        foreach (var item in this.CreatedInvoices ?? [])
        {
            item.Validate();
        }
    }

    public IncrementLedgerEntry() { }

    public IncrementLedgerEntry(IncrementLedgerEntry incrementLedgerEntry)
        : base(incrementLedgerEntry) { }

    public IncrementLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncrementLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IncrementLedgerEntryFromRaw.FromRawUnchecked"/>
    public static IncrementLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IncrementLedgerEntryFromRaw : IFromRawJson<IncrementLedgerEntry>
{
    /// <inheritdoc/>
    public IncrementLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IncrementLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IncrementLedgerEntryEntryStatusConverter))]
public enum IncrementLedgerEntryEntryStatus
{
    Committed,
    Pending,
}

sealed class IncrementLedgerEntryEntryStatusConverter
    : JsonConverter<IncrementLedgerEntryEntryStatus>
{
    public override IncrementLedgerEntryEntryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => IncrementLedgerEntryEntryStatus.Committed,
            "pending" => IncrementLedgerEntryEntryStatus.Pending,
            _ => (IncrementLedgerEntryEntryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IncrementLedgerEntryEntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IncrementLedgerEntryEntryStatus.Committed => "committed",
                IncrementLedgerEntryEntryStatus.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(IncrementLedgerEntryEntryTypeConverter))]
public enum IncrementLedgerEntryEntryType
{
    Increment,
}

sealed class IncrementLedgerEntryEntryTypeConverter : JsonConverter<IncrementLedgerEntryEntryType>
{
    public override IncrementLedgerEntryEntryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => IncrementLedgerEntryEntryType.Increment,
            _ => (IncrementLedgerEntryEntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IncrementLedgerEntryEntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IncrementLedgerEntryEntryType.Increment => "increment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
