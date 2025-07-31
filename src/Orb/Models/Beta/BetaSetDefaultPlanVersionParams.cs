using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Orb.Models.Beta;

/// <summary>
/// This API endpoint is in beta and its interface may change. It is recommended for
/// use only in test mode.
///
/// This endpoint allows setting the default version of a plan.
/// </summary>
public sealed record class BetaSetDefaultPlanVersionParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string PlanID;

    /// <summary>
    /// Plan version to set as the default.
    /// </summary>
    public required long Version
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("version", out JsonElement element))
                throw new ArgumentOutOfRangeException("version", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["version"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/plans/{0}/set_default_version", this.PlanID)
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
