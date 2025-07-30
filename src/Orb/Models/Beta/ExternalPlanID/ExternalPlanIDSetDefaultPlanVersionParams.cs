using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Beta.ExternalPlanID;

/// <summary>
/// This API endpoint is in beta and its interface may change. It is recommended for
/// use only in test mode.
///
/// This endpoint allows setting the default version of a plan.
/// </summary>
public sealed record class ExternalPlanIDSetDefaultPlanVersionParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string ExternalPlanID;

    /// <summary>
    /// Plan version to set as the default.
    /// </summary>
    public required long Version
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("version", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "version",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.BodyProperties["version"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/plans/external_plan_id/{0}/set_default_version",
                    this.ExternalPlanID
                )
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
