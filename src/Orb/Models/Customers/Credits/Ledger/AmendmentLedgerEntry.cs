using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(JsonModelConverter<AmendmentLedgerEntry, AmendmentLedgerEntryFromRaw>))]
public sealed record class AmendmentLedgerEntry : JsonModel
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

    public required ApiEnum<string, AmendmentLedgerEntryEntryStatus> EntryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AmendmentLedgerEntryEntryStatus>>(
                "entry_status"
            );
        }
        init { this._rawData.Set("entry_status", value); }
    }

    public required ApiEnum<string, AmendmentLedgerEntryEntryType> EntryType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AmendmentLedgerEntryEntryType>>(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AmendmentLedgerEntry(AmendmentLedgerEntry amendmentLedgerEntry)
        : base(amendmentLedgerEntry) { }
#pragma warning restore CS8618

    public AmendmentLedgerEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmendmentLedgerEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class AmendmentLedgerEntryFromRaw : IFromRawJson<AmendmentLedgerEntry>
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
