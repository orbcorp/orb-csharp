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
/// This endpoint is used to create alerts at the subscription level.
///
/// <para>Subscription level alerts can be one of two types: `usage_exceeded` or `cost_exceeded`.
/// A `usage_exceeded` alert is scoped to a particular metric and is triggered when
/// the usage of that metric exceeds predefined thresholds during the current billing
/// cycle. A `cost_exceeded` alert is triggered when the total amount due during the
/// current billing cycle surpasses predefined thresholds. `cost_exceeded` alerts
/// do not include burndown of pre-purchase credits. Each subscription can have one
/// `cost_exceeded` alert and one `usage_exceeded` alert per metric that is a part
/// of the subscription. Alerts are triggered based on usage or cost conditions met
/// during the current billing cycle.</para>
/// </summary>
public sealed record class AlertCreateForSubscriptionParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SubscriptionID { get; init; }

    /// <summary>
    /// The thresholds that define the values at which the alert will be triggered.
    /// </summary>
    public required IReadOnlyList<Threshold> Thresholds
    {
        get { return ModelBase.GetNotNullClass<List<Threshold>>(this.RawBodyData, "thresholds"); }
        init { ModelBase.Set(this._rawBodyData, "thresholds", value); }
    }

    /// <summary>
    /// The type of alert to create. This must be a valid alert type.
    /// </summary>
    public required ApiEnum<string, AlertCreateForSubscriptionParamsType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, AlertCreateForSubscriptionParamsType>>(
                this.RawBodyData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "type", value); }
    }

    /// <summary>
    /// The metric to track usage for.
    /// </summary>
    public string? MetricID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "metric_id"); }
        init { ModelBase.Set(this._rawBodyData, "metric_id", value); }
    }

    public AlertCreateForSubscriptionParams() { }

    public AlertCreateForSubscriptionParams(
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
    AlertCreateForSubscriptionParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static AlertCreateForSubscriptionParams FromRawUnchecked(
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
                + string.Format("/alerts/subscription_id/{0}", this.SubscriptionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
[JsonConverter(typeof(AlertCreateForSubscriptionParamsTypeConverter))]
public enum AlertCreateForSubscriptionParamsType
{
    UsageExceeded,
    CostExceeded,
}

sealed class AlertCreateForSubscriptionParamsTypeConverter
    : JsonConverter<AlertCreateForSubscriptionParamsType>
{
    public override AlertCreateForSubscriptionParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_exceeded" => AlertCreateForSubscriptionParamsType.UsageExceeded,
            "cost_exceeded" => AlertCreateForSubscriptionParamsType.CostExceeded,
            _ => (AlertCreateForSubscriptionParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlertCreateForSubscriptionParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlertCreateForSubscriptionParamsType.UsageExceeded => "usage_exceeded",
                AlertCreateForSubscriptionParamsType.CostExceeded => "cost_exceeded",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
