using System.Collections.Frozen;
using System.Collections.Generic;
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
/// </summary>
public sealed record class AlertCreateForExternalCustomerParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ExternalCustomerID { get; init; }

    /// <summary>
    /// The case sensitive currency or custom pricing unit to use for this alert.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "currency"); }
        init { JsonModel.Set(this._rawBodyData, "currency", value); }
    }

    /// <summary>
    /// The type of alert to create. This must be a valid alert type.
    /// </summary>
    public required ApiEnum<string, AlertCreateForExternalCustomerParamsType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, AlertCreateForExternalCustomerParamsType>
            >(this.RawBodyData, "type");
        }
        init { JsonModel.Set(this._rawBodyData, "type", value); }
    }

    /// <summary>
    /// The thresholds that define the values at which the alert will be triggered.
    /// </summary>
    public IReadOnlyList<Threshold>? Thresholds
    {
        get { return JsonModel.GetNullableClass<List<Threshold>>(this.RawBodyData, "thresholds"); }
        init { JsonModel.Set(this._rawBodyData, "thresholds", value); }
    }

    public AlertCreateForExternalCustomerParams() { }

    public AlertCreateForExternalCustomerParams(
        AlertCreateForExternalCustomerParams alertCreateForExternalCustomerParams
    )
        : base(alertCreateForExternalCustomerParams)
    {
        this._rawBodyData = [.. alertCreateForExternalCustomerParams._rawBodyData];
    }

    public AlertCreateForExternalCustomerParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlertCreateForExternalCustomerParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static AlertCreateForExternalCustomerParams FromRawUnchecked(
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/alerts/external_customer_id/{0}", this.ExternalCustomerID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
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
}

/// <summary>
/// The type of alert to create. This must be a valid alert type.
/// </summary>
[JsonConverter(typeof(AlertCreateForExternalCustomerParamsTypeConverter))]
public enum AlertCreateForExternalCustomerParamsType
{
    CreditBalanceDepleted,
    CreditBalanceDropped,
    CreditBalanceRecovered,
}

sealed class AlertCreateForExternalCustomerParamsTypeConverter
    : JsonConverter<AlertCreateForExternalCustomerParamsType>
{
    public override AlertCreateForExternalCustomerParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit_balance_depleted" =>
                AlertCreateForExternalCustomerParamsType.CreditBalanceDepleted,
            "credit_balance_dropped" =>
                AlertCreateForExternalCustomerParamsType.CreditBalanceDropped,
            "credit_balance_recovered" =>
                AlertCreateForExternalCustomerParamsType.CreditBalanceRecovered,
            _ => (AlertCreateForExternalCustomerParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlertCreateForExternalCustomerParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlertCreateForExternalCustomerParamsType.CreditBalanceDepleted =>
                    "credit_balance_depleted",
                AlertCreateForExternalCustomerParamsType.CreditBalanceDropped =>
                    "credit_balance_dropped",
                AlertCreateForExternalCustomerParamsType.CreditBalanceRecovered =>
                    "credit_balance_recovered",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
