using System;
using System.Collections.Frozen;
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
            if (!this._properties.TryGetValue("exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'exempt' cannot be null",
                    new ArgumentOutOfRangeException("exempt", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["exempt"] = JsonSerializer.SerializeToElement(
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

    public NewReportingConfiguration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewReportingConfiguration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewReportingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public NewReportingConfiguration(bool exempt)
        : this()
    {
        this.Exempt = exempt;
    }
}
