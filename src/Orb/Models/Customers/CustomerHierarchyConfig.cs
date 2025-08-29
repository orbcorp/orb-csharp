using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<CustomerHierarchyConfig>))]
public sealed record class CustomerHierarchyConfig : ModelBase, IFromRaw<CustomerHierarchyConfig>
{
    /// <summary>
    /// A list of child customer IDs to add to the hierarchy. The desired child customers
    /// must not already be part of another hierarchy.
    /// </summary>
    public List<string>? ChildCustomerIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("child_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["child_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("parent_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["parent_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
    [SetsRequiredMembers]
    CustomerHierarchyConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerHierarchyConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
