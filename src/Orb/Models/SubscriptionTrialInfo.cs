using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubscriptionTrialInfo>))]
public sealed record class SubscriptionTrialInfo : ModelBase, IFromRaw<SubscriptionTrialInfo>
{
    public required System::DateTime? EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EndDate;
    }

    public SubscriptionTrialInfo() { }

    public SubscriptionTrialInfo(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionTrialInfo(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static SubscriptionTrialInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public SubscriptionTrialInfo(System::DateTime? endDate)
        : this()
    {
        this.EndDate = endDate;
    }
}
