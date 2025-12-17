using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Customers;

[JsonConverter(typeof(JsonModelConverter<AddressInput, AddressInputFromRaw>))]
public sealed record class AddressInput : JsonModel
{
    public string? City
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "city"); }
        init { JsonModel.Set(this._rawData, "city", value); }
    }

    public string? Country
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "country"); }
        init { JsonModel.Set(this._rawData, "country", value); }
    }

    public string? Line1
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "line1"); }
        init { JsonModel.Set(this._rawData, "line1", value); }
    }

    public string? Line2
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "line2"); }
        init { JsonModel.Set(this._rawData, "line2", value); }
    }

    public string? PostalCode
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "postal_code"); }
        init { JsonModel.Set(this._rawData, "postal_code", value); }
    }

    public string? State
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "state"); }
        init { JsonModel.Set(this._rawData, "state", value); }
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

    public AddressInput(AddressInput addressInput)
        : base(addressInput) { }

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

class AddressInputFromRaw : IFromRawJson<AddressInput>
{
    /// <inheritdoc/>
    public AddressInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddressInput.FromRawUnchecked(rawData);
}
