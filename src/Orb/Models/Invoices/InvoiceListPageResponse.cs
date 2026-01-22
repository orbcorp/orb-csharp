using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Invoices;

[JsonConverter(typeof(JsonModelConverter<InvoiceListPageResponse, InvoiceListPageResponseFromRaw>))]
public sealed record class InvoiceListPageResponse : JsonModel
{
    public required IReadOnlyList<Invoice> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Invoice>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Invoice>>(
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

    public InvoiceListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceListPageResponse(InvoiceListPageResponse invoiceListPageResponse)
        : base(invoiceListPageResponse) { }
#pragma warning restore CS8618

    public InvoiceListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListPageResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceListPageResponseFromRaw : IFromRawJson<InvoiceListPageResponse>
{
    /// <inheritdoc/>
    public InvoiceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListPageResponse.FromRawUnchecked(rawData);
}
