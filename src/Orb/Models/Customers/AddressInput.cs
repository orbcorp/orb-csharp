using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(typeof(ModelConverter<AddressInput, AddressInputFromRaw>))]
public sealed record class AddressInput : ModelBase
{
    public string? City
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "city"); }
        init { ModelBase.Set(this._rawData, "city", value); }
    }

    public string? Country
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "country"); }
        init { ModelBase.Set(this._rawData, "country", value); }
    }

    public string? Line1
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "line1"); }
        init { ModelBase.Set(this._rawData, "line1", value); }
    }

    public string? Line2
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "line2"); }
        init { ModelBase.Set(this._rawData, "line2", value); }
    }

    public string? PostalCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "postal_code"); }
        init { ModelBase.Set(this._rawData, "postal_code", value); }
    }

    public string? State
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "state"); }
        init { ModelBase.Set(this._rawData, "state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public AddressInput() { }

    public AddressInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressInputFromRaw.FromRawUnchecked"/>
    public static AddressInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressInputFromRaw : IFromRaw<AddressInput>
{
    /// <inheritdoc/>
    public AddressInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddressInput.FromRawUnchecked(rawData);
}
