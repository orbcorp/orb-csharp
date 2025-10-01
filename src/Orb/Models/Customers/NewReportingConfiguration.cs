using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<NewReportingConfiguration>))]
public sealed record class NewReportingConfiguration
    : ModelBase,
        IFromRaw<NewReportingConfiguration>
{
    public required bool Exempt
    {
        get
        {
            if (!this.Properties.TryGetValue("exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'exempt' cannot be null",
                    new ArgumentOutOfRangeException("exempt", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["exempt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Exempt;
    }

    public NewReportingConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewReportingConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewReportingConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public NewReportingConfiguration(bool exempt)
        : this()
    {
        this.Exempt = exempt;
    }
}
