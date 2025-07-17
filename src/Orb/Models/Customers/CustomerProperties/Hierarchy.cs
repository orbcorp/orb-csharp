using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.CustomerProperties;

/// <summary>
/// The hierarchical relationships for this customer.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Hierarchy>))]
public sealed record class Hierarchy : Orb::ModelBase, Orb::IFromRaw<Hierarchy>
{
    public required Generic::List<Models::CustomerMinified> Children
    {
        get
        {
            if (!this.Properties.TryGetValue("children", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "children",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Models::CustomerMinified>>(
                    element
                ) ?? throw new System::ArgumentNullException("children");
        }
        set { this.Properties["children"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::CustomerMinified? Parent
    {
        get
        {
            if (!this.Properties.TryGetValue("parent", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "parent",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::CustomerMinified?>(element);
        }
        set { this.Properties["parent"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    Hierarchy(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Hierarchy FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
