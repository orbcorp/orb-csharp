using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System = System;

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
                throw new System::ArgumentOutOfRangeException(
                    "thresholds",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<Threshold>>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("thresholds");
        }
        set { this.BodyProperties["thresholds"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
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
