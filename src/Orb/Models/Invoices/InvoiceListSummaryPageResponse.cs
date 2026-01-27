using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Invoices;

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceListSummaryPageResponse,
        InvoiceListSummaryPageResponseFromRaw
    >)
)]
public sealed record class InvoiceListSummaryPageResponse : JsonModel
{
    public required IReadOnlyList<InvoiceListSummaryResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InvoiceListSummaryResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvoiceListSummaryResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationMetadata>("pagination_metadata");
        }
        init { this._rawData.Set("pagination_metadata", value); }
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

    public InvoiceListSummaryPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceListSummaryPageResponse(
        InvoiceListSummaryPageResponse invoiceListSummaryPageResponse
    )
        : base(invoiceListSummaryPageResponse) { }
#pragma warning restore CS8618

    public InvoiceListSummaryPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListSummaryPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListSummaryPageResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceListSummaryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceListSummaryPageResponseFromRaw : IFromRawJson<InvoiceListSummaryPageResponse>
{
    /// <inheritdoc/>
    public InvoiceListSummaryPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListSummaryPageResponse.FromRawUnchecked(rawData);
}
