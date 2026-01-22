using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<CustomerListPageResponse, CustomerListPageResponseFromRaw>)
)]
public sealed record class CustomerListPageResponse : JsonModel
{
    public required IReadOnlyList<Customer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Customer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Customer>>(
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

    public CustomerListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListPageResponse(CustomerListPageResponse customerListPageResponse)
        : base(customerListPageResponse) { }
#pragma warning restore CS8618

    public CustomerListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListPageResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListPageResponseFromRaw : IFromRawJson<CustomerListPageResponse>
{
    /// <inheritdoc/>
    public CustomerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListPageResponse.FromRawUnchecked(rawData);
}
