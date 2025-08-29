using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Orb.Models.Alerts;

/// <summary>
/// This endpoint updates the thresholds of an alert.
/// </summary>
public sealed record class AlertUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string AlertConfigurationID;

    /// <summary>
    /// The thresholds that define the values at which the alert will be triggered.
    /// </summary>
    public required List<Threshold> Thresholds
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("thresholds", out JsonElement element))
                throw new ArgumentOutOfRangeException("thresholds", "Missing required argument");

            return JsonSerializer.Deserialize<List<Threshold>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("thresholds");
        }
        set
        {
            this.BodyProperties["thresholds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/alerts/{0}", this.AlertConfigurationID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
