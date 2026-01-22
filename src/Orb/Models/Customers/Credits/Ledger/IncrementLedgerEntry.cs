using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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

    public required ApiEnum<string, IncrementLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IncrementLedgerEntryEntryStatus>>(
                "entry_status"
            );
        }
        init { this._rawData.Set("entry_status", value); }
    }

    public required ApiEnum<string, IncrementLedgerEntryEntryType> EntryType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IncrementLedgerEntryEntryType>>(
                "entry_type"
            );
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

    public required double StartingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("starting_balance");
        }
        init { this._rawData.Set("starting_balance", value); }
    }

    /// <summary>
    /// If the increment resulted in invoice creation, the list of created invoices
    /// </summary>
    public IReadOnlyList<Invoice>? CreatedInvoices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Invoice>>("created_invoices");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Invoice>?>(
                "created_invoices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IncrementLedgerEntry(IncrementLedgerEntry incrementLedgerEntry)
        : base(incrementLedgerEntry) { }
#pragma warning restore CS8618

    public IncrementLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncrementLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
