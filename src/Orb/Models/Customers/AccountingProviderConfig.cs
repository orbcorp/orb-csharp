using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<AccountingProviderConfig, AccountingProviderConfigFromRaw>))]
public sealed record class AccountingProviderConfig : ModelBase
{
    public required string ExternalProviderID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "external_provider_id"); }
        init { ModelBase.Set(this._rawData, "external_provider_id", value); }
    }

    public required string ProviderType
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "provider_type"); }
        init { ModelBase.Set(this._rawData, "provider_type", value); }
    }

    public override void Validate()
    {
        _ = this.ExternalProviderID;
        _ = this.ProviderType;
    }

    public AccountingProviderConfig() { }

    public AccountingProviderConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountingProviderConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AccountingProviderConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountingProviderConfigFromRaw : IFromRaw<AccountingProviderConfig>
{
    public AccountingProviderConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountingProviderConfig.FromRawUnchecked(rawData);
}
