using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<AccountingProviderConfig, AccountingProviderConfigFromRaw>)
)]
public sealed record class AccountingProviderConfig : JsonModel
{
    public required string ExternalProviderID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "external_provider_id"); }
        init { JsonModel.Set(this._rawData, "external_provider_id", value); }
    }

    public required string ProviderType
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "provider_type"); }
        init { JsonModel.Set(this._rawData, "provider_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalProviderID;
        _ = this.ProviderType;
    }

    public AccountingProviderConfig() { }

    public AccountingProviderConfig(AccountingProviderConfig accountingProviderConfig)
        : base(accountingProviderConfig) { }

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

    /// <inheritdoc cref="AccountingProviderConfigFromRaw.FromRawUnchecked"/>
    public static AccountingProviderConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountingProviderConfigFromRaw : IFromRawJson<AccountingProviderConfig>
{
    /// <inheritdoc/>
    public AccountingProviderConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountingProviderConfig.FromRawUnchecked(rawData);
}
