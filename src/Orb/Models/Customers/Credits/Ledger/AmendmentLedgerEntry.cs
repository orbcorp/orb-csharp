using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(ModelConverter<AmendmentLedgerEntry, AmendmentLedgerEntryFromRaw>))]
public sealed record class AmendmentLedgerEntry : ModelBase
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

    public required ApiEnum<string, AmendmentLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, AmendmentLedgerEntryEntryStatus>>(
                this.RawData,
                "entry_status"
            );
        }
        init { ModelBase.Set(this._rawData, "entry_status", value); }
    }

    public required ApiEnum<string, AmendmentLedgerEntryEntryType> EntryType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, AmendmentLedgerEntryEntryType>>(
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
    }

    public AmendmentLedgerEntry() { }

    public AmendmentLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmendmentLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmendmentLedgerEntryFromRaw.FromRawUnchecked"/>
    public static AmendmentLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmendmentLedgerEntryFromRaw : IFromRaw<AmendmentLedgerEntry>
{
    /// <inheritdoc/>
    public AmendmentLedgerEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AmendmentLedgerEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AmendmentLedgerEntryEntryStatusConverter))]
public enum AmendmentLedgerEntryEntryStatus
{
    Committed,
    Pending,
}

sealed class AmendmentLedgerEntryEntryStatusConverter
    : JsonConverter<AmendmentLedgerEntryEntryStatus>
{
    public override AmendmentLedgerEntryEntryStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => AmendmentLedgerEntryEntryStatus.Committed,
            "pending" => AmendmentLedgerEntryEntryStatus.Pending,
            _ => (AmendmentLedgerEntryEntryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmendmentLedgerEntryEntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmendmentLedgerEntryEntryStatus.Committed => "committed",
                AmendmentLedgerEntryEntryStatus.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AmendmentLedgerEntryEntryTypeConverter))]
public enum AmendmentLedgerEntryEntryType
{
    Amendment,
}

sealed class AmendmentLedgerEntryEntryTypeConverter : JsonConverter<AmendmentLedgerEntryEntryType>
{
    public override AmendmentLedgerEntryEntryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amendment" => AmendmentLedgerEntryEntryType.Amendment,
            _ => (AmendmentLedgerEntryEntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmendmentLedgerEntryEntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmendmentLedgerEntryEntryType.Amendment => "amendment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
