using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    public IReadOnlyList<string>? ChildCustomerIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("child_customer_ids");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "child_customer_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID of the parent customer in the hierarchy. The desired parent customer
    /// must not be a child of another customer.
    /// </summary>
    public string? ParentCustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent_customer_id");
        }
        init { this._rawData.Set("parent_customer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChildCustomerIds;
        _ = this.ParentCustomerID;
    }

    public CustomerHierarchyConfig() { }

    public CustomerHierarchyConfig(CustomerHierarchyConfig customerHierarchyConfig)
        : base(customerHierarchyConfig) { }

    public CustomerHierarchyConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerHierarchyConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
