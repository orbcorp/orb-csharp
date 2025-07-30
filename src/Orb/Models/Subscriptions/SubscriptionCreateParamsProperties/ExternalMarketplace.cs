using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;

[JsonConverter(typeof(EnumConverter<ExternalMarketplace, string>))]
public sealed record class ExternalMarketplace(string value) : IEnum<ExternalMarketplace, string>
{
    public static readonly ExternalMarketplace Google = new("google");

    public static readonly ExternalMarketplace Aws = new("aws");

    public static readonly ExternalMarketplace Azure = new("azure");

    readonly string _value = value;

    public enum Value
    {
        Google,
        Aws,
        Azure,
    }

    public Value Known() =>
        _value switch
        {
            "google" => Value.Google,
            "aws" => Value.Aws,
            "azure" => Value.Azure,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static ExternalMarketplace FromRaw(string value)
    {
        return new(value);
    }
}
