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
    public List<AccountingProviderConfig>? AccountingProviders
    {
        get
        {
            if (!this._rawData.TryGetValue("accounting_providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AccountingProviderConfig>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["accounting_providers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? Excluded
    {
        get
        {
            if (!this._rawData.TryGetValue("excluded", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["excluded"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static NewAccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAccountingSyncConfigurationFromRaw : IFromRaw<NewAccountingSyncConfiguration>
{
    public NewAccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewAccountingSyncConfiguration.FromRawUnchecked(rawData);
}
