using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(JsonModelConverter<VoidLedgerEntry, VoidLedgerEntryFromRaw>))]
public sealed record class VoidLedgerEntry : JsonModel
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

    public required ApiEnum<string, VoidLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VoidLedgerEntryEntryStatus>>(
                "entry_status"
            );
        }
        init { this._rawData.Set("entry_status", value); }
    }

    public required ApiEnum<string, VoidLedgerEntryEntryType> EntryType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VoidLedgerEntryEntryType>>(
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

    public required double VoidAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("void_amount");
        }
        init { this._rawData.Set("void_amount", value); }
    }

    public required string? VoidReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("void_reason");
        }
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
        _ = this.StartingBalance;
        _ = this.VoidAmount;
        _ = this.VoidReason;
    }

    public VoidLedgerEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoidLedgerEntry(VoidLedgerEntry voidLedgerEntry)
        : base(voidLedgerEntry) { }
#pragma warning restore CS8618

    public VoidLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoidLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VoidLedgerEntryFromRaw.FromRawUnchecked"/>
    public static VoidLedgerEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VoidLedgerEntryFromRaw : IFromRawJson<VoidLedgerEntry>
{
    /// <inheritdoc/>
    public VoidLedgerEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VoidLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(VoidLedgerEntryEntryStatusConverter))]
public enum VoidLedgerEntryEntryStatus
{
    Committed,
    Pending,
}

sealed class VoidLedgerEntryEntryStatusConverter : JsonConverter<VoidLedgerEntryEntryStatus>
{
    public override VoidLedgerEntryEntryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => VoidLedgerEntryEntryStatus.Committed,
            "pending" => VoidLedgerEntryEntryStatus.Pending,
            _ => (VoidLedgerEntryEntryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoidLedgerEntryEntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VoidLedgerEntryEntryStatus.Committed => "committed",
                VoidLedgerEntryEntryStatus.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(VoidLedgerEntryEntryTypeConverter))]
public enum VoidLedgerEntryEntryType
{
    Void,
}

sealed class VoidLedgerEntryEntryTypeConverter : JsonConverter<VoidLedgerEntryEntryType>
{
    public override VoidLedgerEntryEntryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "void" => VoidLedgerEntryEntryType.Void,
            _ => (VoidLedgerEntryEntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoidLedgerEntryEntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VoidLedgerEntryEntryType.Void => "void",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
