using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// Configuration for package pricing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PackageConfig, PackageConfigFromRaw>))]
public sealed record class PackageConfig : JsonModel
{
    /// <summary>
    /// A currency amount to rate usage by
    /// </summary>
    public required string PackageAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "package_amount"); }
        init { JsonModel.Set(this._rawData, "package_amount", value); }
    }

    /// <summary>
    /// An integer amount to represent package size. For example, 1000 here would
    /// divide usage by 1000 before multiplying by package_amount in rating
    /// </summary>
    public required long PackageSize
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "package_size"); }
        init { JsonModel.Set(this._rawData, "package_size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PackageAmount;
        _ = this.PackageSize;
    }

    public PackageConfig() { }

    public PackageConfig(PackageConfig packageConfig)
        : base(packageConfig) { }

    public PackageConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PackageConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PackageConfigFromRaw.FromRawUnchecked"/>
    public static PackageConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PackageConfigFromRaw : IFromRawJson<PackageConfig>
{
    /// <inheritdoc/>
    public PackageConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PackageConfig.FromRawUnchecked(rawData);
}
