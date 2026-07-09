using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers;

[JsonConverter(
    typeof(JsonModelConverter<AccountingProviderConfig, AccountingProviderConfigFromRaw>)
)]
public sealed record class AccountingProviderConfig : JsonModel
{
    public required string ExternalProviderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("external_provider_id");
        }
        init { this._rawData.Set("external_provider_id", value); }
    }

    public required ApiEnum<string, AccountingProviderConfigProviderType> ProviderType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountingProviderConfigProviderType>
            >("provider_type");
        }
        init { this._rawData.Set("provider_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalProviderID;
        this.ProviderType.Validate();
    }

    public AccountingProviderConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountingProviderConfig(AccountingProviderConfig accountingProviderConfig)
        : base(accountingProviderConfig) { }
#pragma warning restore CS8618

    public AccountingProviderConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountingProviderConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(typeof(AccountingProviderConfigProviderTypeConverter))]
public enum AccountingProviderConfigProviderType
{
    Quickbooks,
    Netsuite,
}

sealed class AccountingProviderConfigProviderTypeConverter
    : JsonConverter<AccountingProviderConfigProviderType>
{
    public override AccountingProviderConfigProviderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quickbooks" => AccountingProviderConfigProviderType.Quickbooks,
            "netsuite" => AccountingProviderConfigProviderType.Netsuite,
            _ => (AccountingProviderConfigProviderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountingProviderConfigProviderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountingProviderConfigProviderType.Quickbooks => "quickbooks",
                AccountingProviderConfigProviderType.Netsuite => "netsuite",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
