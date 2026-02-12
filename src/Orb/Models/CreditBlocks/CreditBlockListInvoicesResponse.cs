using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.CreditBlocks;

[JsonConverter(
    typeof(JsonModelConverter<
        CreditBlockListInvoicesResponse,
        CreditBlockListInvoicesResponseFromRaw
    >)
)]
public sealed record class CreditBlockListInvoicesResponse : JsonModel
{
    /// <summary>
    /// The Credit Block resource models prepaid credits within Orb.
    /// </summary>
    public required Block Block
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Block>("block");
        }
        init { this._rawData.Set("block", value); }
    }

    public required IReadOnlyList<Invoice> Invoices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Invoice>>("invoices");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Invoice>>(
                "invoices",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Block.Validate();
        foreach (var item in this.Invoices)
        {
            item.Validate();
        }
    }

    public CreditBlockListInvoicesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditBlockListInvoicesResponse(
        CreditBlockListInvoicesResponse creditBlockListInvoicesResponse
    )
        : base(creditBlockListInvoicesResponse) { }
#pragma warning restore CS8618

    public CreditBlockListInvoicesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBlockListInvoicesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditBlockListInvoicesResponseFromRaw.FromRawUnchecked"/>
    public static CreditBlockListInvoicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditBlockListInvoicesResponseFromRaw : IFromRawJson<CreditBlockListInvoicesResponse>
{
    /// <inheritdoc/>
    public CreditBlockListInvoicesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditBlockListInvoicesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The Credit Block resource models prepaid credits within Orb.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Block, BlockFromRaw>))]
public sealed record class Block : JsonModel
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

    public required double Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    public required System::DateTimeOffset? EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("effective_date");
        }
        init { this._rawData.Set("effective_date", value); }
    }

    public required System::DateTimeOffset? ExpiryDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expiry_date");
        }
        init { this._rawData.Set("expiry_date", value); }
    }

    public required IReadOnlyList<BlockFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BlockFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BlockFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required double? MaximumInitialBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maximum_initial_balance");
        }
        init { this._rawData.Set("maximum_initial_balance", value); }
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

    public required string? PerUnitCostBasis
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("per_unit_cost_basis");
        }
        init { this._rawData.Set("per_unit_cost_basis", value); }
    }

    public required ApiEnum<string, BlockStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BlockStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Balance;
        _ = this.EffectiveDate;
        _ = this.ExpiryDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MaximumInitialBalance;
        _ = this.Metadata;
        _ = this.PerUnitCostBasis;
        this.Status.Validate();
    }

    public Block() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Block(Block block)
        : base(block) { }
#pragma warning restore CS8618

    public Block(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Block(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockFromRaw.FromRawUnchecked"/>
    public static Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockFromRaw : IFromRawJson<Block>
{
    /// <inheritdoc/>
    public Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Block.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BlockFilter, BlockFilterFromRaw>))]
public sealed record class BlockFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, BlockFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BlockFilterField>>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, BlockFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BlockFilterOperator>>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public BlockFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BlockFilter(BlockFilter blockFilter)
        : base(blockFilter) { }
#pragma warning restore CS8618

    public BlockFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BlockFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockFilterFromRaw.FromRawUnchecked"/>
    public static BlockFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockFilterFromRaw : IFromRawJson<BlockFilter>
{
    /// <inheritdoc/>
    public BlockFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BlockFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(BlockFilterFieldConverter))]
public enum BlockFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class BlockFilterFieldConverter : JsonConverter<BlockFilterField>
{
    public override BlockFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => BlockFilterField.PriceID,
            "item_id" => BlockFilterField.ItemID,
            "price_type" => BlockFilterField.PriceType,
            "currency" => BlockFilterField.Currency,
            "pricing_unit_id" => BlockFilterField.PricingUnitID,
            _ => (BlockFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BlockFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BlockFilterField.PriceID => "price_id",
                BlockFilterField.ItemID => "item_id",
                BlockFilterField.PriceType => "price_type",
                BlockFilterField.Currency => "currency",
                BlockFilterField.PricingUnitID => "pricing_unit_id",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(BlockFilterOperatorConverter))]
public enum BlockFilterOperator
{
    Includes,
    Excludes,
}

sealed class BlockFilterOperatorConverter : JsonConverter<BlockFilterOperator>
{
    public override BlockFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => BlockFilterOperator.Includes,
            "excludes" => BlockFilterOperator.Excludes,
            _ => (BlockFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BlockFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BlockFilterOperator.Includes => "includes",
                BlockFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BlockStatusConverter))]
public enum BlockStatus
{
    Active,
    PendingPayment,
}

sealed class BlockStatusConverter : JsonConverter<BlockStatus>
{
    public override BlockStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => BlockStatus.Active,
            "pending_payment" => BlockStatus.PendingPayment,
            _ => (BlockStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BlockStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BlockStatus.Active => "active",
                BlockStatus.PendingPayment => "pending_payment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Invoice, InvoiceFromRaw>))]
public sealed record class Invoice : JsonModel
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

    public required CustomerMinified Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerMinified>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    public required string InvoiceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoice_number");
        }
        init { this._rawData.Set("invoice_number", value); }
    }

    public required ApiEnum<string, InvoiceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvoiceStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required SubscriptionMinified? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionMinified>("subscription");
        }
        init { this._rawData.Set("subscription", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Customer.Validate();
        _ = this.InvoiceNumber;
        this.Status.Validate();
        this.Subscription?.Validate();
    }

    public Invoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Invoice(Invoice invoice)
        : base(invoice) { }
#pragma warning restore CS8618

    public Invoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Invoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceFromRaw.FromRawUnchecked"/>
    public static Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceFromRaw : IFromRawJson<Invoice>
{
    /// <inheritdoc/>
    public Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Invoice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InvoiceStatusConverter))]
public enum InvoiceStatus
{
    Issued,
    Paid,
    Synced,
    Void,
    Draft,
}

sealed class InvoiceStatusConverter : JsonConverter<InvoiceStatus>
{
    public override InvoiceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issued" => InvoiceStatus.Issued,
            "paid" => InvoiceStatus.Paid,
            "synced" => InvoiceStatus.Synced,
            "void" => InvoiceStatus.Void,
            "draft" => InvoiceStatus.Draft,
            _ => (InvoiceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceStatus.Issued => "issued",
                InvoiceStatus.Paid => "paid",
                InvoiceStatus.Synced => "synced",
                InvoiceStatus.Void => "void",
                InvoiceStatus.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
