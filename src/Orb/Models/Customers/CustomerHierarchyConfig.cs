using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<CustomerHierarchyConfig, CustomerHierarchyConfigFromRaw>))]
public sealed record class CustomerHierarchyConfig : JsonModel
{
    /// <summary>
    /// A list of child customer IDs to add to the hierarchy. The desired child customers
    /// must not already be part of another hierarchy.
    /// </summary>
    public IReadOnlyList<string>? ChildCustomerIDs
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "child_customer_ids"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "child_customer_ids", value);
        }
    }

    /// <summary>
    /// The ID of the parent customer in the hierarchy. The desired parent customer
    /// must not be a child of another customer.
    /// </summary>
    public string? ParentCustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "parent_customer_id"); }
        init { JsonModel.Set(this._rawData, "parent_customer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChildCustomerIDs;
        _ = this.ParentCustomerID;
    }

    public CustomerHierarchyConfig() { }

    public CustomerHierarchyConfig(CustomerHierarchyConfig customerHierarchyConfig)
        : base(customerHierarchyConfig) { }

    public CustomerHierarchyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerHierarchyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerHierarchyConfigFromRaw.FromRawUnchecked"/>
    public static CustomerHierarchyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerHierarchyConfigFromRaw : IFromRawJson<CustomerHierarchyConfig>
{
    /// <inheritdoc/>
    public CustomerHierarchyConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerHierarchyConfig.FromRawUnchecked(rawData);
}
