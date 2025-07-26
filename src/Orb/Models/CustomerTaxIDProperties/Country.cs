using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CustomerTaxIDProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Country, string>))]
public sealed record class Country(string value) : Orb::IEnum<Country, string>
{
    public static readonly Country Ad = new("AD");

    public static readonly Country Ae = new("AE");

    public static readonly Country Al = new("AL");

    public static readonly Country Am = new("AM");

    public static readonly Country Ao = new("AO");

    public static readonly Country Ar = new("AR");

    public static readonly Country At = new("AT");

    public static readonly Country Au = new("AU");

    public static readonly Country Aw = new("AW");

    public static readonly Country Az = new("AZ");

    public static readonly Country Ba = new("BA");

    public static readonly Country Bb = new("BB");

    public static readonly Country Bd = new("BD");

    public static readonly Country Be = new("BE");

    public static readonly Country Bf = new("BF");

    public static readonly Country Bg = new("BG");

    public static readonly Country Bh = new("BH");

    public static readonly Country Bj = new("BJ");

    public static readonly Country Bo = new("BO");

    public static readonly Country Br = new("BR");

    public static readonly Country Bs = new("BS");

    public static readonly Country By = new("BY");

    public static readonly Country Ca = new("CA");

    public static readonly Country Cd = new("CD");

    public static readonly Country Ch = new("CH");

    public static readonly Country Cl = new("CL");

    public static readonly Country Cm = new("CM");

    public static readonly Country Cn = new("CN");

    public static readonly Country Co = new("CO");

    public static readonly Country Cr = new("CR");

    public static readonly Country Cv = new("CV");

    public static readonly Country De = new("DE");

    public static readonly Country Cy = new("CY");

    public static readonly Country Cz = new("CZ");

    public static readonly Country Dk = new("DK");

    public static readonly Country Do = new("DO");

    public static readonly Country Ec = new("EC");

    public static readonly Country Ee = new("EE");

    public static readonly Country Eg = new("EG");

    public static readonly Country Es = new("ES");

    public static readonly Country Et = new("ET");

    public static readonly Country Eu = new("EU");

    public static readonly Country Fi = new("FI");

    public static readonly Country Fr = new("FR");

    public static readonly Country GB = new("GB");

    public static readonly Country Ge = new("GE");

    public static readonly Country Gn = new("GN");

    public static readonly Country Gr = new("GR");

    public static readonly Country Hk = new("HK");

    public static readonly Country Hr = new("HR");

    public static readonly Country Hu = new("HU");

    public static readonly Country ID = new("ID");

    public static readonly Country Ie = new("IE");

    public static readonly Country Il = new("IL");

    public static readonly Country In = new("IN");

    public static readonly Country Is = new("IS");

    public static readonly Country It = new("IT");

    public static readonly Country Jp = new("JP");

    public static readonly Country Ke = new("KE");

    public static readonly Country Kg = new("KG");

    public static readonly Country Kh = new("KH");

    public static readonly Country Kr = new("KR");

    public static readonly Country Kz = new("KZ");

    public static readonly Country La = new("LA");

    public static readonly Country Li = new("LI");

    public static readonly Country Lt = new("LT");

    public static readonly Country Lu = new("LU");

    public static readonly Country Lv = new("LV");

    public static readonly Country Ma = new("MA");

    public static readonly Country Md = new("MD");

    public static readonly Country Me = new("ME");

    public static readonly Country Mk = new("MK");

    public static readonly Country Mr = new("MR");

    public static readonly Country Mt = new("MT");

    public static readonly Country Mx = new("MX");

    public static readonly Country My = new("MY");

    public static readonly Country Ng = new("NG");

    public static readonly Country Nl = new("NL");

    public static readonly Country No = new("NO");

    public static readonly Country Np = new("NP");

    public static readonly Country Nz = new("NZ");

    public static readonly Country Om = new("OM");

    public static readonly Country Pe = new("PE");

    public static readonly Country Ph = new("PH");

    public static readonly Country Pl = new("PL");

    public static readonly Country Pt = new("PT");

    public static readonly Country Ro = new("RO");

    public static readonly Country Rs = new("RS");

    public static readonly Country Ru = new("RU");

    public static readonly Country Sa = new("SA");

    public static readonly Country Se = new("SE");

    public static readonly Country Sg = new("SG");

    public static readonly Country Si = new("SI");

    public static readonly Country Sk = new("SK");

    public static readonly Country Sn = new("SN");

    public static readonly Country Sr = new("SR");

    public static readonly Country Sv = new("SV");

    public static readonly Country Th = new("TH");

    public static readonly Country Tj = new("TJ");

    public static readonly Country Tr = new("TR");

    public static readonly Country Tw = new("TW");

    public static readonly Country Tz = new("TZ");

    public static readonly Country Ua = new("UA");

    public static readonly Country Ug = new("UG");

    public static readonly Country Us = new("US");

    public static readonly Country Uy = new("UY");

    public static readonly Country Uz = new("UZ");

    public static readonly Country Ve = new("VE");

    public static readonly Country Vn = new("VN");

    public static readonly Country Za = new("ZA");

    public static readonly Country Zm = new("ZM");

    public static readonly Country Zw = new("ZW");

    readonly string _value = value;

    public enum Value
    {
        Ad,
        Ae,
        Al,
        Am,
        Ao,
        Ar,
        At,
        Au,
        Aw,
        Az,
        Ba,
        Bb,
        Bd,
        Be,
        Bf,
        Bg,
        Bh,
        Bj,
        Bo,
        Br,
        Bs,
        By,
        Ca,
        Cd,
        Ch,
        Cl,
        Cm,
        Cn,
        Co,
        Cr,
        Cv,
        De,
        Cy,
        Cz,
        Dk,
        Do,
        Ec,
        Ee,
        Eg,
        Es,
        Et,
        Eu,
        Fi,
        Fr,
        GB,
        Ge,
        Gn,
        Gr,
        Hk,
        Hr,
        Hu,
        ID,
        Ie,
        Il,
        In,
        Is,
        It,
        Jp,
        Ke,
        Kg,
        Kh,
        Kr,
        Kz,
        La,
        Li,
        Lt,
        Lu,
        Lv,
        Ma,
        Md,
        Me,
        Mk,
        Mr,
        Mt,
        Mx,
        My,
        Ng,
        Nl,
        No,
        Np,
        Nz,
        Om,
        Pe,
        Ph,
        Pl,
        Pt,
        Ro,
        Rs,
        Ru,
        Sa,
        Se,
        Sg,
        Si,
        Sk,
        Sn,
        Sr,
        Sv,
        Th,
        Tj,
        Tr,
        Tw,
        Tz,
        Ua,
        Ug,
        Us,
        Uy,
        Uz,
        Ve,
        Vn,
        Za,
        Zm,
        Zw,
    }

    public Value Known() =>
        _value switch
        {
            "AD" => Value.Ad,
            "AE" => Value.Ae,
            "AL" => Value.Al,
            "AM" => Value.Am,
            "AO" => Value.Ao,
            "AR" => Value.Ar,
            "AT" => Value.At,
            "AU" => Value.Au,
            "AW" => Value.Aw,
            "AZ" => Value.Az,
            "BA" => Value.Ba,
            "BB" => Value.Bb,
            "BD" => Value.Bd,
            "BE" => Value.Be,
            "BF" => Value.Bf,
            "BG" => Value.Bg,
            "BH" => Value.Bh,
            "BJ" => Value.Bj,
            "BO" => Value.Bo,
            "BR" => Value.Br,
            "BS" => Value.Bs,
            "BY" => Value.By,
            "CA" => Value.Ca,
            "CD" => Value.Cd,
            "CH" => Value.Ch,
            "CL" => Value.Cl,
            "CM" => Value.Cm,
            "CN" => Value.Cn,
            "CO" => Value.Co,
            "CR" => Value.Cr,
            "CV" => Value.Cv,
            "DE" => Value.De,
            "CY" => Value.Cy,
            "CZ" => Value.Cz,
            "DK" => Value.Dk,
            "DO" => Value.Do,
            "EC" => Value.Ec,
            "EE" => Value.Ee,
            "EG" => Value.Eg,
            "ES" => Value.Es,
            "ET" => Value.Et,
            "EU" => Value.Eu,
            "FI" => Value.Fi,
            "FR" => Value.Fr,
            "GB" => Value.GB,
            "GE" => Value.Ge,
            "GN" => Value.Gn,
            "GR" => Value.Gr,
            "HK" => Value.Hk,
            "HR" => Value.Hr,
            "HU" => Value.Hu,
            "ID" => Value.ID,
            "IE" => Value.Ie,
            "IL" => Value.Il,
            "IN" => Value.In,
            "IS" => Value.Is,
            "IT" => Value.It,
            "JP" => Value.Jp,
            "KE" => Value.Ke,
            "KG" => Value.Kg,
            "KH" => Value.Kh,
            "KR" => Value.Kr,
            "KZ" => Value.Kz,
            "LA" => Value.La,
            "LI" => Value.Li,
            "LT" => Value.Lt,
            "LU" => Value.Lu,
            "LV" => Value.Lv,
            "MA" => Value.Ma,
            "MD" => Value.Md,
            "ME" => Value.Me,
            "MK" => Value.Mk,
            "MR" => Value.Mr,
            "MT" => Value.Mt,
            "MX" => Value.Mx,
            "MY" => Value.My,
            "NG" => Value.Ng,
            "NL" => Value.Nl,
            "NO" => Value.No,
            "NP" => Value.Np,
            "NZ" => Value.Nz,
            "OM" => Value.Om,
            "PE" => Value.Pe,
            "PH" => Value.Ph,
            "PL" => Value.Pl,
            "PT" => Value.Pt,
            "RO" => Value.Ro,
            "RS" => Value.Rs,
            "RU" => Value.Ru,
            "SA" => Value.Sa,
            "SE" => Value.Se,
            "SG" => Value.Sg,
            "SI" => Value.Si,
            "SK" => Value.Sk,
            "SN" => Value.Sn,
            "SR" => Value.Sr,
            "SV" => Value.Sv,
            "TH" => Value.Th,
            "TJ" => Value.Tj,
            "TR" => Value.Tr,
            "TW" => Value.Tw,
            "TZ" => Value.Tz,
            "UA" => Value.Ua,
            "UG" => Value.Ug,
            "US" => Value.Us,
            "UY" => Value.Uy,
            "UZ" => Value.Uz,
            "VE" => Value.Ve,
            "VN" => Value.Vn,
            "ZA" => Value.Za,
            "ZM" => Value.Zm,
            "ZW" => Value.Zw,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Country FromRaw(string value)
    {
        return new(value);
    }
}
