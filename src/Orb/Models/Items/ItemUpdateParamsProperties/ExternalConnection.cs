using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Items.ItemUpdateParamsProperties.ExternalConnectionProperties;

namespace Orb.Models.Items.ItemUpdateParamsProperties;

[JsonConverter(typeof(ModelConverter<ExternalConnection>))]
public sealed record class ExternalConnection : ModelBase, IFromRaw<ExternalConnection>
{
    public required ApiEnum<string, ExternalConnectionName> ExternalConnectionName
    {
        get
        {
            if (!this.Properties.TryGetValue("external_connection_name", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "external_connection_name",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ExternalConnectionName>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["external_connection_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ExternalEntityID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_entity_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "external_entity_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("external_entity_id");
        }
        set
        {
            this.Properties["external_entity_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ExternalConnectionName.Validate();
        _ = this.ExternalEntityID;
    }

    public ExternalConnection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnection(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ExternalConnection FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
