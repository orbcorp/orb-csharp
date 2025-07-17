using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<CustomerHierarchyConfig>))]
public sealed record class CustomerHierarchyConfig
    : Orb::ModelBase,
        Orb::IFromRaw<CustomerHierarchyConfig>
{
    /// <summary>
    /// A list of child customer IDs to add to the hierarchy. The desired child customers
    /// must not already be part of another hierarchy.
    /// </summary>
    public Generic::List<string>? ChildCustomerIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("child_customer_ids", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set
        {
            this.Properties["child_customer_ids"] = Json::JsonSerializer.SerializeToElement(value);
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
            if (!this.Properties.TryGetValue("parent_customer_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["parent_customer_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        foreach (var item in this.ChildCustomerIDs ?? [])
        {
            _ = item;
        }
        _ = this.ParentCustomerID;
    }

    public CustomerHierarchyConfig() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    CustomerHierarchyConfig(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerHierarchyConfig FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
