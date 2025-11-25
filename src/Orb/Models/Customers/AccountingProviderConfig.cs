using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<AccountingProviderConfig, AccountingProviderConfigFromRaw>))]
public sealed record class AccountingProviderConfig : ModelBase
{
    public required string ExternalProviderID
    {
        get
        {
            if (!this._rawData.TryGetValue("external_provider_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'external_provider_id' cannot be null",
                    new ArgumentOutOfRangeException(
                        "external_provider_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'external_provider_id' cannot be null",
                    new ArgumentNullException("external_provider_id")
                );
        }
        init
        {
            this._rawData["external_provider_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ProviderType
    {
        get
        {
            if (!this._rawData.TryGetValue("provider_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'provider_type' cannot be null",
                    new ArgumentOutOfRangeException("provider_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'provider_type' cannot be null",
                    new ArgumentNullException("provider_type")
                );
        }
        init
        {
            this._rawData["provider_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
