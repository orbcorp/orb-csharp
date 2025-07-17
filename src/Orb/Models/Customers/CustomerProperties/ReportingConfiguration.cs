using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.CustomerProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ReportingConfiguration>))]
public sealed record class ReportingConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<ReportingConfiguration>
{
    public required bool Exempt
    {
        get
        {
            if (!this.Properties.TryGetValue("exempt", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "exempt",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["exempt"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Exempt;
    }

    public ReportingConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ReportingConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ReportingConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
