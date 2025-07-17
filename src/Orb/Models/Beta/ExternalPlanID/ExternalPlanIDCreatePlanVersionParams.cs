using ExternalPlanIDCreatePlanVersionParamsProperties = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties;
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
/// This endpoint allows the creation of a new plan version for an existing plan.
/// </summary>
public sealed record class ExternalPlanIDCreatePlanVersionParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string ExternalPlanID;

    /// <summary>
    /// New version number.
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

    /// <summary>
    /// Additional adjustments to be added to the plan.
    /// </summary>
    public Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::AddAdjustment>? AddAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("add_adjustments", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::AddAdjustment>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["add_adjustments"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Additional prices to be added to the plan.
    /// </summary>
    public Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::AddPrice>? AddPrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("add_prices", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::AddPrice>?>(
                element
            );
        }
        set { this.BodyProperties["add_prices"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Adjustments to be removed from the plan.
    /// </summary>
    public Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::RemoveAdjustment>? RemoveAdjustments
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "remove_adjustments",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::RemoveAdjustment>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["remove_adjustments"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Prices to be removed from the plan.
    /// </summary>
    public Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::RemovePrice>? RemovePrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("remove_prices", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::RemovePrice>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["remove_prices"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Adjustments to be replaced with additional adjustments on the plan.
    /// </summary>
    public Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::ReplaceAdjustment>? ReplaceAdjustments
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "replace_adjustments",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::ReplaceAdjustment>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["replace_adjustments"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Prices to be replaced with additional prices on the plan.
    /// </summary>
    public Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::ReplacePrice>? ReplacePrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("replace_prices", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<ExternalPlanIDCreatePlanVersionParamsProperties::ReplacePrice>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["replace_prices"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Set this new plan version as the default
    /// </summary>
    public bool? SetAsDefault
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("set_as_default", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["set_as_default"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/plans/external_plan_id/{0}/versions", this.ExternalPlanID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new Http::StringContent(
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
