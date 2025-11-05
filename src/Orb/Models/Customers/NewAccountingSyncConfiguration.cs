using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<NewAccountingSyncConfiguration>))]
public sealed record class NewAccountingSyncConfiguration
    : ModelBase,
        IFromRaw<NewAccountingSyncConfiguration>
{
    public List<AccountingProviderConfig>? AccountingProviders
    {
        get
        {
            if (!this._properties.TryGetValue("accounting_providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AccountingProviderConfig>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["accounting_providers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? Excluded
    {
        get
        {
            if (!this._properties.TryGetValue("excluded", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["excluded"] = JsonSerializer.SerializeToElement(
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

    public NewAccountingSyncConfiguration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAccountingSyncConfiguration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewAccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
