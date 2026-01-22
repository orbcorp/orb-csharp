using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<
        NewAccountingSyncConfiguration,
        NewAccountingSyncConfigurationFromRaw
    >)
)]
public sealed record class NewAccountingSyncConfiguration : JsonModel
{
    public IReadOnlyList<AccountingProviderConfig>? AccountingProviders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AccountingProviderConfig>>(
                "accounting_providers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AccountingProviderConfig>?>(
                "accounting_providers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? Excluded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("excluded");
        }
        init { this._rawData.Set("excluded", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewAccountingSyncConfiguration(
        NewAccountingSyncConfiguration newAccountingSyncConfiguration
    )
        : base(newAccountingSyncConfiguration) { }
#pragma warning restore CS8618

    public NewAccountingSyncConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAccountingSyncConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class NewAccountingSyncConfigurationFromRaw : IFromRawJson<NewAccountingSyncConfiguration>
{
    /// <inheritdoc/>
    public NewAccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewAccountingSyncConfiguration.FromRawUnchecked(rawData);
}
