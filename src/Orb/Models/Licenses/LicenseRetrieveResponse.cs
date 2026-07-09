using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Licenses;

[JsonConverter(typeof(JsonModelConverter<LicenseRetrieveResponse, LicenseRetrieveResponseFromRaw>))]
public sealed record class LicenseRetrieveResponse : JsonModel
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

    public required ApiEnum<string, LicenseRetrieveResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LicenseRetrieveResponseStatus>>(
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

    public LicenseRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseRetrieveResponse(LicenseRetrieveResponse licenseRetrieveResponse)
        : base(licenseRetrieveResponse) { }
#pragma warning restore CS8618

    public LicenseRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static LicenseRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseRetrieveResponseFromRaw : IFromRawJson<LicenseRetrieveResponse>
{
    /// <inheritdoc/>
    public LicenseRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LicenseRetrieveResponseStatusConverter))]
public enum LicenseRetrieveResponseStatus
{
    Active,
    Inactive,
}

sealed class LicenseRetrieveResponseStatusConverter : JsonConverter<LicenseRetrieveResponseStatus>
{
    public override LicenseRetrieveResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => LicenseRetrieveResponseStatus.Active,
            "inactive" => LicenseRetrieveResponseStatus.Inactive,
            _ => (LicenseRetrieveResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LicenseRetrieveResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LicenseRetrieveResponseStatus.Active => "active",
                LicenseRetrieveResponseStatus.Inactive => "inactive",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
