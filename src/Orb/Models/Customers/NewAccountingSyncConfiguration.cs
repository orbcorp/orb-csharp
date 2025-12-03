using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(
    typeof(ModelConverter<NewAccountingSyncConfiguration, NewAccountingSyncConfigurationFromRaw>)
)]
public sealed record class NewAccountingSyncConfiguration : ModelBase
{
    public IReadOnlyList<AccountingProviderConfig>? AccountingProviders
    {
        get
        {
            return ModelBase.GetNullableClass<List<AccountingProviderConfig>>(
                this.RawData,
                "accounting_providers"
            );
        }
        init { ModelBase.Set(this._rawData, "accounting_providers", value); }
    }

    public bool? Excluded
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "excluded"); }
        init { ModelBase.Set(this._rawData, "excluded", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AccountingProviders ?? [])
        {
            item.Validate();
        }
        _ = this.Excluded;
    }

    public NewAccountingSyncConfiguration() { }

    public NewAccountingSyncConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAccountingSyncConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewAccountingSyncConfigurationFromRaw.FromRawUnchecked"/>
    public static NewAccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAccountingSyncConfigurationFromRaw : IFromRaw<NewAccountingSyncConfiguration>
{
    /// <inheritdoc/>
    public NewAccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewAccountingSyncConfiguration.FromRawUnchecked(rawData);
}
