using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.CustomerProperties;

[JsonConverter(typeof(ModelConverter<ReportingConfiguration>))]
public sealed record class ReportingConfiguration : ModelBase, IFromRaw<ReportingConfiguration>
{
    public required bool Exempt
    {
        get
        {
            if (!this.Properties.TryGetValue("exempt", out JsonElement element))
                throw new ArgumentOutOfRangeException("exempt", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["exempt"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Exempt;
    }

    public ReportingConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportingConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ReportingConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    public ReportingConfiguration(bool exempt)
    {
        this.Exempt = exempt;
    }
}
