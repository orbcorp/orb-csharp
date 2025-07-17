using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using ExternalConnectionProperties = Orb.Models.Items.ItemUpdateParamsProperties.ExternalConnectionProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Items.ItemUpdateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ExternalConnection>))]
public sealed record class ExternalConnection : Orb::ModelBase, Orb::IFromRaw<ExternalConnection>
{
    public required ExternalConnectionProperties::ExternalConnectionName ExternalConnectionName
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "external_connection_name",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "external_connection_name",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<ExternalConnectionProperties::ExternalConnectionName>(
                    element
                ) ?? throw new System::ArgumentNullException("external_connection_name");
        }
        set
        {
            this.Properties["external_connection_name"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required string ExternalEntityID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_entity_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "external_entity_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("external_entity_id");
        }
        set
        {
            this.Properties["external_entity_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        this.ExternalConnectionName.Validate();
        _ = this.ExternalEntityID;
    }

    public ExternalConnection() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ExternalConnection(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ExternalConnection FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
