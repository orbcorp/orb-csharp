using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
///  This endpoint creates a new alert to monitor a customer's credit balance. There
/// are three types of alerts that can be scoped to  customers: `credit_balance_depleted`,
/// `credit_balance_dropped`, and `credit_balance_recovered`. Customers can have a
/// maximum  of one of each type of alert per [credit balance currency](/product-catalog/prepurchase).
/// `credit_balance_dropped` alerts require a list of thresholds to be provided while
/// `credit_balance_depleted`  and `credit_balance_recovered` alerts do not require thresholds.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AlertCreateForCustomerParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CustomerID { get; init; }

    /// <summary>
    /// The case sensitive currency or custom pricing unit to use for this alert.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    /// <summary>
    /// The type of alert to create. This must be a valid alert type.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Alerts.Type> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Alerts.Type>
            >("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// The thresholds that define the values at which the alert will be triggered.
    /// </summary>
    public IReadOnlyList<Threshold>? Thresholds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Threshold>>("thresholds");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Threshold>?>(
                "thresholds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AlertCreateForCustomerParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlertCreateForCustomerParams(AlertCreateForCustomerParams alertCreateForCustomerParams)
        : base(alertCreateForCustomerParams)
    {
        this.CustomerID = alertCreateForCustomerParams.CustomerID;

        this._rawBodyData = new(alertCreateForCustomerParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AlertCreateForCustomerParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlertCreateForCustomerParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static AlertCreateForCustomerParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["CustomerID"] = this.CustomerID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AlertCreateForCustomerParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CustomerID?.Equals(other.CustomerID) ?? other.CustomerID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/alerts/customer_id/{0}", this.CustomerID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The type of alert to create. This must be a valid alert type.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CreditBalanceDepleted,
    CreditBalanceDropped,
    CreditBalanceRecovered,
}

sealed class TypeConverter : JsonConverter<global::Orb.Models.Alerts.Type>
{
    public override global::Orb.Models.Alerts.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit_balance_depleted" => global::Orb.Models.Alerts.Type.CreditBalanceDepleted,
            "credit_balance_dropped" => global::Orb.Models.Alerts.Type.CreditBalanceDropped,
            "credit_balance_recovered" => global::Orb.Models.Alerts.Type.CreditBalanceRecovered,
            _ => (global::Orb.Models.Alerts.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Alerts.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Alerts.Type.CreditBalanceDepleted => "credit_balance_depleted",
                global::Orb.Models.Alerts.Type.CreditBalanceDropped => "credit_balance_dropped",
                global::Orb.Models.Alerts.Type.CreditBalanceRecovered => "credit_balance_recovered",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
