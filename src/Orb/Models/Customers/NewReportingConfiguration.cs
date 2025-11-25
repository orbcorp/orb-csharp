using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<NewReportingConfiguration, NewReportingConfigurationFromRaw>))]
public sealed record class NewReportingConfiguration : ModelBase
{
    public required bool Exempt
    {
        get
        {
            if (!this._rawData.TryGetValue("exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'exempt' cannot be null",
                    new ArgumentOutOfRangeException("exempt", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["exempt"] = JsonSerializer.SerializeToElement(
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

    public NewReportingConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewReportingConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewReportingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NewReportingConfiguration(bool exempt)
        : this()
    {
        this.Exempt = exempt;
    }
}

class NewReportingConfigurationFromRaw : IFromRaw<NewReportingConfiguration>
{
    public NewReportingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewReportingConfiguration.FromRawUnchecked(rawData);
}
