using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<NewReportingConfiguration, NewReportingConfigurationFromRaw>)
)]
public sealed record class NewReportingConfiguration : JsonModel
{
    public required bool Exempt
    {
        get { return this._rawData.GetNotNullStruct<bool>("exempt"); }
        init { this._rawData.Set("exempt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Exempt;
    }

    public NewReportingConfiguration() { }

    public NewReportingConfiguration(NewReportingConfiguration newReportingConfiguration)
        : base(newReportingConfiguration) { }

    public NewReportingConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewReportingConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewReportingConfigurationFromRaw.FromRawUnchecked"/>
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

class NewReportingConfigurationFromRaw : IFromRawJson<NewReportingConfiguration>
{
    /// <inheritdoc/>
    public NewReportingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewReportingConfiguration.FromRawUnchecked(rawData);
}
