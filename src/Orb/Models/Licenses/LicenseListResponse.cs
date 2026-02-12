using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Licenses;

[JsonConverter(typeof(JsonModelConverter<LicenseListResponse, LicenseListResponseFromRaw>))]
public sealed record class LicenseListResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required System::DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    public required string ExternalLicenseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("external_license_id");
        }
        init { this._rawData.Set("external_license_id", value); }
    }

    public required string LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
    }

    public required System::DateTimeOffset StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("start_date");
        }
        init { this._rawData.Set("start_date", value); }
    }

    public required ApiEnum<string, LicenseListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LicenseListResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.EndDate;
        _ = this.ExternalLicenseID;
        _ = this.LicenseTypeID;
        _ = this.StartDate;
        this.Status.Validate();
        _ = this.SubscriptionID;
    }

    public LicenseListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseListResponse(LicenseListResponse licenseListResponse)
        : base(licenseListResponse) { }
#pragma warning restore CS8618

    public LicenseListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseListResponseFromRaw.FromRawUnchecked"/>
    public static LicenseListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseListResponseFromRaw : IFromRawJson<LicenseListResponse>
{
    /// <inheritdoc/>
    public LicenseListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LicenseListResponseStatusConverter))]
public enum LicenseListResponseStatus
{
    Active,
    Inactive,
}

sealed class LicenseListResponseStatusConverter : JsonConverter<LicenseListResponseStatus>
{
    public override LicenseListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => LicenseListResponseStatus.Active,
            "inactive" => LicenseListResponseStatus.Inactive,
            _ => (LicenseListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LicenseListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LicenseListResponseStatus.Active => "active",
                LicenseListResponseStatus.Inactive => "inactive",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
