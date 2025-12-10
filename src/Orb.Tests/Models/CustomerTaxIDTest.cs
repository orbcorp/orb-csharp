using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class CustomerTaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerTaxID
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        ApiEnum<string, Country> expectedCountry = Country.Ad;
        ApiEnum<string, CustomerTaxIDType> expectedType = CustomerTaxIDType.AdNrt;
        string expectedValue = "value";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerTaxID
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerTaxID>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerTaxID
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CustomerTaxID>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Country> expectedCountry = Country.Ad;
        ApiEnum<string, CustomerTaxIDType> expectedType = CustomerTaxIDType.AdNrt;
        string expectedValue = "value";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerTaxID
        {
            Country = Country.Ad,
            Type = CustomerTaxIDType.AdNrt,
            Value = "value",
        };

        model.Validate();
    }
}

public class CountryTest : TestBase
{
    [Theory]
    [InlineData(Country.Ad)]
    [InlineData(Country.Ae)]
    [InlineData(Country.Al)]
    [InlineData(Country.Am)]
    [InlineData(Country.Ao)]
    [InlineData(Country.Ar)]
    [InlineData(Country.At)]
    [InlineData(Country.Au)]
    [InlineData(Country.Aw)]
    [InlineData(Country.Az)]
    [InlineData(Country.Ba)]
    [InlineData(Country.Bb)]
    [InlineData(Country.Bd)]
    [InlineData(Country.Be)]
    [InlineData(Country.Bf)]
    [InlineData(Country.Bg)]
    [InlineData(Country.Bh)]
    [InlineData(Country.Bj)]
    [InlineData(Country.Bo)]
    [InlineData(Country.Br)]
    [InlineData(Country.Bs)]
    [InlineData(Country.By)]
    [InlineData(Country.Ca)]
    [InlineData(Country.Cd)]
    [InlineData(Country.Ch)]
    [InlineData(Country.Cl)]
    [InlineData(Country.Cm)]
    [InlineData(Country.Cn)]
    [InlineData(Country.Co)]
    [InlineData(Country.Cr)]
    [InlineData(Country.Cv)]
    [InlineData(Country.De)]
    [InlineData(Country.Cy)]
    [InlineData(Country.Cz)]
    [InlineData(Country.Dk)]
    [InlineData(Country.Do)]
    [InlineData(Country.Ec)]
    [InlineData(Country.Ee)]
    [InlineData(Country.Eg)]
    [InlineData(Country.Es)]
    [InlineData(Country.Et)]
    [InlineData(Country.Eu)]
    [InlineData(Country.Fi)]
    [InlineData(Country.Fr)]
    [InlineData(Country.GB)]
    [InlineData(Country.Ge)]
    [InlineData(Country.Gn)]
    [InlineData(Country.Gr)]
    [InlineData(Country.Hk)]
    [InlineData(Country.Hr)]
    [InlineData(Country.Hu)]
    [InlineData(Country.ID)]
    [InlineData(Country.Ie)]
    [InlineData(Country.Il)]
    [InlineData(Country.In)]
    [InlineData(Country.Is)]
    [InlineData(Country.It)]
    [InlineData(Country.Jp)]
    [InlineData(Country.Ke)]
    [InlineData(Country.Kg)]
    [InlineData(Country.Kh)]
    [InlineData(Country.Kr)]
    [InlineData(Country.Kz)]
    [InlineData(Country.La)]
    [InlineData(Country.Li)]
    [InlineData(Country.Lt)]
    [InlineData(Country.Lu)]
    [InlineData(Country.Lv)]
    [InlineData(Country.Ma)]
    [InlineData(Country.Md)]
    [InlineData(Country.Me)]
    [InlineData(Country.Mk)]
    [InlineData(Country.Mr)]
    [InlineData(Country.Mt)]
    [InlineData(Country.Mx)]
    [InlineData(Country.My)]
    [InlineData(Country.Ng)]
    [InlineData(Country.Nl)]
    [InlineData(Country.No)]
    [InlineData(Country.Np)]
    [InlineData(Country.Nz)]
    [InlineData(Country.Om)]
    [InlineData(Country.Pe)]
    [InlineData(Country.Ph)]
    [InlineData(Country.Pl)]
    [InlineData(Country.Pt)]
    [InlineData(Country.Ro)]
    [InlineData(Country.Rs)]
    [InlineData(Country.Ru)]
    [InlineData(Country.Sa)]
    [InlineData(Country.Se)]
    [InlineData(Country.Sg)]
    [InlineData(Country.Si)]
    [InlineData(Country.Sk)]
    [InlineData(Country.Sn)]
    [InlineData(Country.Sr)]
    [InlineData(Country.Sv)]
    [InlineData(Country.Th)]
    [InlineData(Country.Tj)]
    [InlineData(Country.Tr)]
    [InlineData(Country.Tw)]
    [InlineData(Country.Tz)]
    [InlineData(Country.Ua)]
    [InlineData(Country.Ug)]
    [InlineData(Country.Us)]
    [InlineData(Country.Uy)]
    [InlineData(Country.Uz)]
    [InlineData(Country.Ve)]
    [InlineData(Country.Vn)]
    [InlineData(Country.Za)]
    [InlineData(Country.Zm)]
    [InlineData(Country.Zw)]
    public void Validation_Works(Country rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Country> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Country>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Country.Ad)]
    [InlineData(Country.Ae)]
    [InlineData(Country.Al)]
    [InlineData(Country.Am)]
    [InlineData(Country.Ao)]
    [InlineData(Country.Ar)]
    [InlineData(Country.At)]
    [InlineData(Country.Au)]
    [InlineData(Country.Aw)]
    [InlineData(Country.Az)]
    [InlineData(Country.Ba)]
    [InlineData(Country.Bb)]
    [InlineData(Country.Bd)]
    [InlineData(Country.Be)]
    [InlineData(Country.Bf)]
    [InlineData(Country.Bg)]
    [InlineData(Country.Bh)]
    [InlineData(Country.Bj)]
    [InlineData(Country.Bo)]
    [InlineData(Country.Br)]
    [InlineData(Country.Bs)]
    [InlineData(Country.By)]
    [InlineData(Country.Ca)]
    [InlineData(Country.Cd)]
    [InlineData(Country.Ch)]
    [InlineData(Country.Cl)]
    [InlineData(Country.Cm)]
    [InlineData(Country.Cn)]
    [InlineData(Country.Co)]
    [InlineData(Country.Cr)]
    [InlineData(Country.Cv)]
    [InlineData(Country.De)]
    [InlineData(Country.Cy)]
    [InlineData(Country.Cz)]
    [InlineData(Country.Dk)]
    [InlineData(Country.Do)]
    [InlineData(Country.Ec)]
    [InlineData(Country.Ee)]
    [InlineData(Country.Eg)]
    [InlineData(Country.Es)]
    [InlineData(Country.Et)]
    [InlineData(Country.Eu)]
    [InlineData(Country.Fi)]
    [InlineData(Country.Fr)]
    [InlineData(Country.GB)]
    [InlineData(Country.Ge)]
    [InlineData(Country.Gn)]
    [InlineData(Country.Gr)]
    [InlineData(Country.Hk)]
    [InlineData(Country.Hr)]
    [InlineData(Country.Hu)]
    [InlineData(Country.ID)]
    [InlineData(Country.Ie)]
    [InlineData(Country.Il)]
    [InlineData(Country.In)]
    [InlineData(Country.Is)]
    [InlineData(Country.It)]
    [InlineData(Country.Jp)]
    [InlineData(Country.Ke)]
    [InlineData(Country.Kg)]
    [InlineData(Country.Kh)]
    [InlineData(Country.Kr)]
    [InlineData(Country.Kz)]
    [InlineData(Country.La)]
    [InlineData(Country.Li)]
    [InlineData(Country.Lt)]
    [InlineData(Country.Lu)]
    [InlineData(Country.Lv)]
    [InlineData(Country.Ma)]
    [InlineData(Country.Md)]
    [InlineData(Country.Me)]
    [InlineData(Country.Mk)]
    [InlineData(Country.Mr)]
    [InlineData(Country.Mt)]
    [InlineData(Country.Mx)]
    [InlineData(Country.My)]
    [InlineData(Country.Ng)]
    [InlineData(Country.Nl)]
    [InlineData(Country.No)]
    [InlineData(Country.Np)]
    [InlineData(Country.Nz)]
    [InlineData(Country.Om)]
    [InlineData(Country.Pe)]
    [InlineData(Country.Ph)]
    [InlineData(Country.Pl)]
    [InlineData(Country.Pt)]
    [InlineData(Country.Ro)]
    [InlineData(Country.Rs)]
    [InlineData(Country.Ru)]
    [InlineData(Country.Sa)]
    [InlineData(Country.Se)]
    [InlineData(Country.Sg)]
    [InlineData(Country.Si)]
    [InlineData(Country.Sk)]
    [InlineData(Country.Sn)]
    [InlineData(Country.Sr)]
    [InlineData(Country.Sv)]
    [InlineData(Country.Th)]
    [InlineData(Country.Tj)]
    [InlineData(Country.Tr)]
    [InlineData(Country.Tw)]
    [InlineData(Country.Tz)]
    [InlineData(Country.Ua)]
    [InlineData(Country.Ug)]
    [InlineData(Country.Us)]
    [InlineData(Country.Uy)]
    [InlineData(Country.Uz)]
    [InlineData(Country.Ve)]
    [InlineData(Country.Vn)]
    [InlineData(Country.Za)]
    [InlineData(Country.Zm)]
    [InlineData(Country.Zw)]
    public void SerializationRoundtrip_Works(Country rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Country> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Country>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Country>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Country>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomerTaxIDTypeTest : TestBase
{
    [Theory]
    [InlineData(CustomerTaxIDType.AdNrt)]
    [InlineData(CustomerTaxIDType.AeTrn)]
    [InlineData(CustomerTaxIDType.AlTin)]
    [InlineData(CustomerTaxIDType.AmTin)]
    [InlineData(CustomerTaxIDType.AoTin)]
    [InlineData(CustomerTaxIDType.ArCuit)]
    [InlineData(CustomerTaxIDType.EuVat)]
    [InlineData(CustomerTaxIDType.AuAbn)]
    [InlineData(CustomerTaxIDType.AuArn)]
    [InlineData(CustomerTaxIDType.AwTin)]
    [InlineData(CustomerTaxIDType.AzTin)]
    [InlineData(CustomerTaxIDType.BaTin)]
    [InlineData(CustomerTaxIDType.BbTin)]
    [InlineData(CustomerTaxIDType.BdBin)]
    [InlineData(CustomerTaxIDType.BfIfu)]
    [InlineData(CustomerTaxIDType.BgUic)]
    [InlineData(CustomerTaxIDType.BhVat)]
    [InlineData(CustomerTaxIDType.BjIfu)]
    [InlineData(CustomerTaxIDType.BoTin)]
    [InlineData(CustomerTaxIDType.BrCnpj)]
    [InlineData(CustomerTaxIDType.BrCpf)]
    [InlineData(CustomerTaxIDType.BsTin)]
    [InlineData(CustomerTaxIDType.ByTin)]
    [InlineData(CustomerTaxIDType.CaBn)]
    [InlineData(CustomerTaxIDType.CaGstHst)]
    [InlineData(CustomerTaxIDType.CaPstBc)]
    [InlineData(CustomerTaxIDType.CaPstMB)]
    [InlineData(CustomerTaxIDType.CaPstSk)]
    [InlineData(CustomerTaxIDType.CaQst)]
    [InlineData(CustomerTaxIDType.CdNif)]
    [InlineData(CustomerTaxIDType.ChUid)]
    [InlineData(CustomerTaxIDType.ChVat)]
    [InlineData(CustomerTaxIDType.ClTin)]
    [InlineData(CustomerTaxIDType.CmNiu)]
    [InlineData(CustomerTaxIDType.CnTin)]
    [InlineData(CustomerTaxIDType.CoNit)]
    [InlineData(CustomerTaxIDType.CrTin)]
    [InlineData(CustomerTaxIDType.CvNif)]
    [InlineData(CustomerTaxIDType.DeStn)]
    [InlineData(CustomerTaxIDType.DoRcn)]
    [InlineData(CustomerTaxIDType.EcRuc)]
    [InlineData(CustomerTaxIDType.EgTin)]
    [InlineData(CustomerTaxIDType.EsCif)]
    [InlineData(CustomerTaxIDType.EtTin)]
    [InlineData(CustomerTaxIDType.EuOssVat)]
    [InlineData(CustomerTaxIDType.GBVat)]
    [InlineData(CustomerTaxIDType.GeVat)]
    [InlineData(CustomerTaxIDType.GnNif)]
    [InlineData(CustomerTaxIDType.HkBr)]
    [InlineData(CustomerTaxIDType.HrOib)]
    [InlineData(CustomerTaxIDType.HuTin)]
    [InlineData(CustomerTaxIDType.IDNpwp)]
    [InlineData(CustomerTaxIDType.IlVat)]
    [InlineData(CustomerTaxIDType.InGst)]
    [InlineData(CustomerTaxIDType.IsVat)]
    [InlineData(CustomerTaxIDType.JpCn)]
    [InlineData(CustomerTaxIDType.JpRn)]
    [InlineData(CustomerTaxIDType.JpTrn)]
    [InlineData(CustomerTaxIDType.KePin)]
    [InlineData(CustomerTaxIDType.KgTin)]
    [InlineData(CustomerTaxIDType.KhTin)]
    [InlineData(CustomerTaxIDType.KrBrn)]
    [InlineData(CustomerTaxIDType.KzBin)]
    [InlineData(CustomerTaxIDType.LaTin)]
    [InlineData(CustomerTaxIDType.LiUid)]
    [InlineData(CustomerTaxIDType.LiVat)]
    [InlineData(CustomerTaxIDType.MaVat)]
    [InlineData(CustomerTaxIDType.MdVat)]
    [InlineData(CustomerTaxIDType.MePib)]
    [InlineData(CustomerTaxIDType.MkVat)]
    [InlineData(CustomerTaxIDType.MrNif)]
    [InlineData(CustomerTaxIDType.MxRfc)]
    [InlineData(CustomerTaxIDType.MyFrp)]
    [InlineData(CustomerTaxIDType.MyItn)]
    [InlineData(CustomerTaxIDType.MySst)]
    [InlineData(CustomerTaxIDType.NgTin)]
    [InlineData(CustomerTaxIDType.NoVat)]
    [InlineData(CustomerTaxIDType.NoVoec)]
    [InlineData(CustomerTaxIDType.NpPan)]
    [InlineData(CustomerTaxIDType.NzGst)]
    [InlineData(CustomerTaxIDType.OmVat)]
    [InlineData(CustomerTaxIDType.PeRuc)]
    [InlineData(CustomerTaxIDType.PhTin)]
    [InlineData(CustomerTaxIDType.RoTin)]
    [InlineData(CustomerTaxIDType.RsPib)]
    [InlineData(CustomerTaxIDType.RuInn)]
    [InlineData(CustomerTaxIDType.RuKpp)]
    [InlineData(CustomerTaxIDType.SaVat)]
    [InlineData(CustomerTaxIDType.SgGst)]
    [InlineData(CustomerTaxIDType.SgUen)]
    [InlineData(CustomerTaxIDType.SiTin)]
    [InlineData(CustomerTaxIDType.SnNinea)]
    [InlineData(CustomerTaxIDType.SrFin)]
    [InlineData(CustomerTaxIDType.SvNit)]
    [InlineData(CustomerTaxIDType.ThVat)]
    [InlineData(CustomerTaxIDType.TjTin)]
    [InlineData(CustomerTaxIDType.TrTin)]
    [InlineData(CustomerTaxIDType.TwVat)]
    [InlineData(CustomerTaxIDType.TzVat)]
    [InlineData(CustomerTaxIDType.UaVat)]
    [InlineData(CustomerTaxIDType.UgTin)]
    [InlineData(CustomerTaxIDType.UsEin)]
    [InlineData(CustomerTaxIDType.UyRuc)]
    [InlineData(CustomerTaxIDType.UzTin)]
    [InlineData(CustomerTaxIDType.UzVat)]
    [InlineData(CustomerTaxIDType.VeRif)]
    [InlineData(CustomerTaxIDType.VnTin)]
    [InlineData(CustomerTaxIDType.ZaVat)]
    [InlineData(CustomerTaxIDType.ZmTin)]
    [InlineData(CustomerTaxIDType.ZwTin)]
    public void Validation_Works(CustomerTaxIDType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerTaxIDType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerTaxIDType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerTaxIDType.AdNrt)]
    [InlineData(CustomerTaxIDType.AeTrn)]
    [InlineData(CustomerTaxIDType.AlTin)]
    [InlineData(CustomerTaxIDType.AmTin)]
    [InlineData(CustomerTaxIDType.AoTin)]
    [InlineData(CustomerTaxIDType.ArCuit)]
    [InlineData(CustomerTaxIDType.EuVat)]
    [InlineData(CustomerTaxIDType.AuAbn)]
    [InlineData(CustomerTaxIDType.AuArn)]
    [InlineData(CustomerTaxIDType.AwTin)]
    [InlineData(CustomerTaxIDType.AzTin)]
    [InlineData(CustomerTaxIDType.BaTin)]
    [InlineData(CustomerTaxIDType.BbTin)]
    [InlineData(CustomerTaxIDType.BdBin)]
    [InlineData(CustomerTaxIDType.BfIfu)]
    [InlineData(CustomerTaxIDType.BgUic)]
    [InlineData(CustomerTaxIDType.BhVat)]
    [InlineData(CustomerTaxIDType.BjIfu)]
    [InlineData(CustomerTaxIDType.BoTin)]
    [InlineData(CustomerTaxIDType.BrCnpj)]
    [InlineData(CustomerTaxIDType.BrCpf)]
    [InlineData(CustomerTaxIDType.BsTin)]
    [InlineData(CustomerTaxIDType.ByTin)]
    [InlineData(CustomerTaxIDType.CaBn)]
    [InlineData(CustomerTaxIDType.CaGstHst)]
    [InlineData(CustomerTaxIDType.CaPstBc)]
    [InlineData(CustomerTaxIDType.CaPstMB)]
    [InlineData(CustomerTaxIDType.CaPstSk)]
    [InlineData(CustomerTaxIDType.CaQst)]
    [InlineData(CustomerTaxIDType.CdNif)]
    [InlineData(CustomerTaxIDType.ChUid)]
    [InlineData(CustomerTaxIDType.ChVat)]
    [InlineData(CustomerTaxIDType.ClTin)]
    [InlineData(CustomerTaxIDType.CmNiu)]
    [InlineData(CustomerTaxIDType.CnTin)]
    [InlineData(CustomerTaxIDType.CoNit)]
    [InlineData(CustomerTaxIDType.CrTin)]
    [InlineData(CustomerTaxIDType.CvNif)]
    [InlineData(CustomerTaxIDType.DeStn)]
    [InlineData(CustomerTaxIDType.DoRcn)]
    [InlineData(CustomerTaxIDType.EcRuc)]
    [InlineData(CustomerTaxIDType.EgTin)]
    [InlineData(CustomerTaxIDType.EsCif)]
    [InlineData(CustomerTaxIDType.EtTin)]
    [InlineData(CustomerTaxIDType.EuOssVat)]
    [InlineData(CustomerTaxIDType.GBVat)]
    [InlineData(CustomerTaxIDType.GeVat)]
    [InlineData(CustomerTaxIDType.GnNif)]
    [InlineData(CustomerTaxIDType.HkBr)]
    [InlineData(CustomerTaxIDType.HrOib)]
    [InlineData(CustomerTaxIDType.HuTin)]
    [InlineData(CustomerTaxIDType.IDNpwp)]
    [InlineData(CustomerTaxIDType.IlVat)]
    [InlineData(CustomerTaxIDType.InGst)]
    [InlineData(CustomerTaxIDType.IsVat)]
    [InlineData(CustomerTaxIDType.JpCn)]
    [InlineData(CustomerTaxIDType.JpRn)]
    [InlineData(CustomerTaxIDType.JpTrn)]
    [InlineData(CustomerTaxIDType.KePin)]
    [InlineData(CustomerTaxIDType.KgTin)]
    [InlineData(CustomerTaxIDType.KhTin)]
    [InlineData(CustomerTaxIDType.KrBrn)]
    [InlineData(CustomerTaxIDType.KzBin)]
    [InlineData(CustomerTaxIDType.LaTin)]
    [InlineData(CustomerTaxIDType.LiUid)]
    [InlineData(CustomerTaxIDType.LiVat)]
    [InlineData(CustomerTaxIDType.MaVat)]
    [InlineData(CustomerTaxIDType.MdVat)]
    [InlineData(CustomerTaxIDType.MePib)]
    [InlineData(CustomerTaxIDType.MkVat)]
    [InlineData(CustomerTaxIDType.MrNif)]
    [InlineData(CustomerTaxIDType.MxRfc)]
    [InlineData(CustomerTaxIDType.MyFrp)]
    [InlineData(CustomerTaxIDType.MyItn)]
    [InlineData(CustomerTaxIDType.MySst)]
    [InlineData(CustomerTaxIDType.NgTin)]
    [InlineData(CustomerTaxIDType.NoVat)]
    [InlineData(CustomerTaxIDType.NoVoec)]
    [InlineData(CustomerTaxIDType.NpPan)]
    [InlineData(CustomerTaxIDType.NzGst)]
    [InlineData(CustomerTaxIDType.OmVat)]
    [InlineData(CustomerTaxIDType.PeRuc)]
    [InlineData(CustomerTaxIDType.PhTin)]
    [InlineData(CustomerTaxIDType.RoTin)]
    [InlineData(CustomerTaxIDType.RsPib)]
    [InlineData(CustomerTaxIDType.RuInn)]
    [InlineData(CustomerTaxIDType.RuKpp)]
    [InlineData(CustomerTaxIDType.SaVat)]
    [InlineData(CustomerTaxIDType.SgGst)]
    [InlineData(CustomerTaxIDType.SgUen)]
    [InlineData(CustomerTaxIDType.SiTin)]
    [InlineData(CustomerTaxIDType.SnNinea)]
    [InlineData(CustomerTaxIDType.SrFin)]
    [InlineData(CustomerTaxIDType.SvNit)]
    [InlineData(CustomerTaxIDType.ThVat)]
    [InlineData(CustomerTaxIDType.TjTin)]
    [InlineData(CustomerTaxIDType.TrTin)]
    [InlineData(CustomerTaxIDType.TwVat)]
    [InlineData(CustomerTaxIDType.TzVat)]
    [InlineData(CustomerTaxIDType.UaVat)]
    [InlineData(CustomerTaxIDType.UgTin)]
    [InlineData(CustomerTaxIDType.UsEin)]
    [InlineData(CustomerTaxIDType.UyRuc)]
    [InlineData(CustomerTaxIDType.UzTin)]
    [InlineData(CustomerTaxIDType.UzVat)]
    [InlineData(CustomerTaxIDType.VeRif)]
    [InlineData(CustomerTaxIDType.VnTin)]
    [InlineData(CustomerTaxIDType.ZaVat)]
    [InlineData(CustomerTaxIDType.ZmTin)]
    [InlineData(CustomerTaxIDType.ZwTin)]
    public void SerializationRoundtrip_Works(CustomerTaxIDType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerTaxIDType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CustomerTaxIDType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerTaxIDType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CustomerTaxIDType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
