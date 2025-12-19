using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers.BalanceTransactions;

[JsonConverter(
    typeof(JsonModelConverter<
        BalanceTransactionListPageResponse,
        BalanceTransactionListPageResponseFromRaw
    >)
)]
public sealed record class BalanceTransactionListPageResponse : JsonModel
{
    public required IReadOnlyList<BalanceTransactionListResponse> Data
    {
        get
        {
            return JsonModel.GetNotNullClass<List<BalanceTransactionListResponse>>(
                this.RawData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return JsonModel.GetNotNullClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public BalanceTransactionListPageResponse() { }

    public BalanceTransactionListPageResponse(
        BalanceTransactionListPageResponse balanceTransactionListPageResponse
    )
        : base(balanceTransactionListPageResponse) { }

    public BalanceTransactionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceTransactionListPageResponseFromRaw.FromRawUnchecked"/>
    public static BalanceTransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceTransactionListPageResponseFromRaw : IFromRawJson<BalanceTransactionListPageResponse>
{
    /// <inheritdoc/>
    public BalanceTransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceTransactionListPageResponse.FromRawUnchecked(rawData);
}
