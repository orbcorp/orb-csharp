using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BalanceTransactionListPageResponseProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionListPageResponseProperties;
using Models = Orb.Models;
using System = System;

namespace Orb.Models.Customers.BalanceTransactions;

[JsonConverter(typeof(ModelConverter<BalanceTransactionListPageResponse>))]
public sealed record class BalanceTransactionListPageResponse
    : ModelBase,
        IFromRaw<BalanceTransactionListPageResponse>
{
    public required List<BalanceTransactionListPageResponseProperties::Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<
                    List<BalanceTransactionListPageResponseProperties::Data>
                >(element) ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::PaginationMetadata PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "pagination_metadata",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Models::PaginationMetadata>(element)
                ?? throw new System::ArgumentNullException("pagination_metadata");
        }
        set { this.Properties["pagination_metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public BalanceTransactionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BalanceTransactionListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
