using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using ExternalPlanIDCreatePlanVersionParamsProperties = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties;

namespace Orb.Models.Beta.ExternalPlanID;

/// <summary>
/// This API endpoint is in beta and its interface may change. It is recommended for
/// use only in test mode.
///
/// This endpoint allows the creation of a new plan version for an existing plan.
/// </summary>
public sealed record class ExternalPlanIDCreatePlanVersionParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ExternalPlanID;

    /// <summary>
    /// New version number.
    /// </summary>
    public required long Version
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("version", out JsonElement element))
                throw new ArgumentOutOfRangeException("version", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element);
        }
        set { this.BodyProperties["version"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Additional adjustments to be added to the plan.
    /// </summary>
    public List<ExternalPlanIDCreatePlanVersionParamsProperties::AddAdjustment>? AddAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("add_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ExternalPlanIDCreatePlanVersionParamsProperties::AddAdjustment>?>(
                element
            );
        }
        set { this.BodyProperties["add_adjustments"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Additional prices to be added to the plan.
    /// </summary>
    public List<ExternalPlanIDCreatePlanVersionParamsProperties::AddPrice>? AddPrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("add_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ExternalPlanIDCreatePlanVersionParamsProperties::AddPrice>?>(
                element
            );
        }
        set { this.BodyProperties["add_prices"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Adjustments to be removed from the plan.
    /// </summary>
    public List<ExternalPlanIDCreatePlanVersionParamsProperties::RemoveAdjustment>? RemoveAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("remove_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ExternalPlanIDCreatePlanVersionParamsProperties::RemoveAdjustment>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["remove_adjustments"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Prices to be removed from the plan.
    /// </summary>
    public List<ExternalPlanIDCreatePlanVersionParamsProperties::RemovePrice>? RemovePrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("remove_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ExternalPlanIDCreatePlanVersionParamsProperties::RemovePrice>?>(
                element
            );
        }
        set { this.BodyProperties["remove_prices"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Adjustments to be replaced with additional adjustments on the plan.
    /// </summary>
    public List<ExternalPlanIDCreatePlanVersionParamsProperties::ReplaceAdjustment>? ReplaceAdjustments
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("replace_adjustments", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ExternalPlanIDCreatePlanVersionParamsProperties::ReplaceAdjustment>?>(
                element
            );
        }
        set
        {
            this.BodyProperties["replace_adjustments"] = JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Prices to be replaced with additional prices on the plan.
    /// </summary>
    public List<ExternalPlanIDCreatePlanVersionParamsProperties::ReplacePrice>? ReplacePrices
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("replace_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ExternalPlanIDCreatePlanVersionParamsProperties::ReplacePrice>?>(
                element
            );
        }
        set { this.BodyProperties["replace_prices"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Set this new plan version as the default
    /// </summary>
    public bool? SetAsDefault
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("set_as_default", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.BodyProperties["set_as_default"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/plans/external_plan_id/{0}/versions", this.ExternalPlanID)
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
