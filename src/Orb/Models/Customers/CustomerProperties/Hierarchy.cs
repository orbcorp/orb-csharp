using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.CustomerProperties;

/// <summary>
/// The hierarchical relationships for this customer.
/// </summary>
[JsonConverter(typeof(ModelConverter<Hierarchy>))]
public sealed record class Hierarchy : ModelBase, IFromRaw<Hierarchy>
{
    public required List<CustomerMinified> Children
    {
        get
        {
            if (!this.Properties.TryGetValue("children", out JsonElement element))
                throw new ArgumentOutOfRangeException("children", "Missing required argument");

            return JsonSerializer.Deserialize<List<CustomerMinified>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("children");
        }
        set { this.Properties["children"] = JsonSerializer.SerializeToElement(value); }
    }

    public required CustomerMinified? Parent
    {
        get
        {
            if (!this.Properties.TryGetValue("parent", out JsonElement element))
                throw new ArgumentOutOfRangeException("parent", "Missing required argument");

            return JsonSerializer.Deserialize<CustomerMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["parent"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Children)
        {
            item.Validate();
        }
        this.Parent?.Validate();
    }

    public Hierarchy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Hierarchy(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Hierarchy FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
