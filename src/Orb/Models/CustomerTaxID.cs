using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

/// <summary>
/// Tax IDs are commonly required to be displayed on customer invoices, which are
/// added to the headers of invoices.
///
/// ### Supported Tax ID Countries and Types
///
/// | Country | Type | Description | |---------|------|-------------| | Albania |
/// `al_tin` | Albania Tax Identification Number | | Andorra | `ad_nrt` | Andorran
/// NRT Number | | Angola | `ao_tin` | Angola Tax Identification Number | | Argentina
/// | `ar_cuit` | Argentinian Tax ID Number | | Armenia | `am_tin` | Armenia Tax Identification
/// Number | | Aruba | `aw_tin` | Aruba Tax Identification Number | | Australia |
/// `au_abn` | Australian Business Number (AU ABN) | | Australia | `au_arn` | Australian
/// Taxation Office Reference Number | | Austria | `eu_vat` | European VAT Number
/// | | Azerbaijan | `az_tin` | Azerbaijan Tax Identification Number | | Bahamas |
/// `bs_tin` | Bahamas Tax Identification Number | | Bahrain | `bh_vat` | Bahraini
/// VAT Number | | Bangladesh | `bd_bin` | Bangladesh Business Identification Number
/// | | Barbados | `bb_tin` | Barbados Tax Identification Number | | Belarus | `by_tin`
/// | Belarus TIN Number | | Belgium | `eu_vat` | European VAT Number | | Benin |
/// `bj_ifu` | Benin Tax Identification Number (Identifiant Fiscal Unique) | | Bolivia
/// | `bo_tin` | Bolivian Tax ID | | Bosnia and Herzegovina | `ba_tin` | Bosnia and
/// Herzegovina Tax Identification Number | | Brazil | `br_cnpj` | Brazilian CNPJ
/// Number | | Brazil | `br_cpf` | Brazilian CPF Number | | Bulgaria | `bg_uic` |
/// Bulgaria Unified Identification Code | | Bulgaria | `eu_vat` | European VAT Number
/// | | Burkina Faso | `bf_ifu` | Burkina Faso Tax Identification Number (Numéro d'Identifiant
/// Fiscal Unique) | | Cambodia | `kh_tin` | Cambodia Tax Identification Number |
/// | Cameroon | `cm_niu` | Cameroon Tax Identification Number (Numéro d'Identifiant
/// fiscal Unique) | | Canada | `ca_bn` | Canadian BN | | Canada | `ca_gst_hst` |
/// Canadian GST/HST Number | | Canada | `ca_pst_bc` | Canadian PST Number (British
/// Columbia) | | Canada | `ca_pst_mb` | Canadian PST Number (Manitoba) | | Canada
/// | `ca_pst_sk` | Canadian PST Number (Saskatchewan) | | Canada | `ca_qst` | Canadian
/// QST Number (Québec) | | Cape Verde | `cv_nif` | Cape Verde Tax Identification
/// Number (Número de Identificação Fiscal) | | Chile | `cl_tin` | Chilean TIN | |
/// China | `cn_tin` | Chinese Tax ID | | Colombia | `co_nit` | Colombian NIT Number
/// | | Congo-Kinshasa | `cd_nif` | Congo (DR) Tax Identification Number (Número
/// de Identificação Fiscal) | | Costa Rica | `cr_tin` | Costa Rican Tax ID | | Croatia
/// | `eu_vat` | European VAT Number | | Croatia | `hr_oib` | Croatian Personal Identification
/// Number (OIB) | | Cyprus | `eu_vat` | European VAT Number | | Czech Republic |
/// `eu_vat` | European VAT Number | | Denmark | `eu_vat` | European VAT Number |
/// | Dominican Republic | `do_rcn` | Dominican RCN Number | | Ecuador | `ec_ruc`
/// | Ecuadorian RUC Number | | Egypt | `eg_tin` | Egyptian Tax Identification Number
/// | | El Salvador | `sv_nit` | El Salvadorian NIT Number | | Estonia | `eu_vat`
/// | European VAT Number | | Ethiopia | `et_tin` | Ethiopia Tax Identification Number
/// | | European Union | `eu_oss_vat` | European One Stop Shop VAT Number for non-Union
/// scheme | | Finland | `eu_vat` | European VAT Number | | France | `eu_vat` | European
/// VAT Number | | Georgia | `ge_vat` | Georgian VAT | | Germany | `de_stn` | German
/// Tax Number (Steuernummer) | | Germany | `eu_vat` | European VAT Number | | Greece
/// | `eu_vat` | European VAT Number | | Guinea | `gn_nif` | Guinea Tax Identification
/// Number (Número de Identificação Fiscal) | | Hong Kong | `hk_br` | Hong Kong BR
/// Number | | Hungary | `eu_vat` | European VAT Number | | Hungary | `hu_tin` | Hungary
/// Tax Number (adószám) | | Iceland | `is_vat` | Icelandic VAT | | India | `in_gst`
/// | Indian GST Number | | Indonesia | `id_npwp` | Indonesian NPWP Number | | Ireland
/// | `eu_vat` | European VAT Number | | Israel | `il_vat` | Israel VAT | | Italy
/// | `eu_vat` | European VAT Number | | Japan | `jp_cn` | Japanese Corporate Number
/// (*Hōjin Bangō*) | | Japan | `jp_rn` | Japanese Registered Foreign Businesses'
/// Registration Number (*Tōroku Kokugai Jigyōsha no Tōroku Bangō*) | | Japan | `jp_trn`
/// | Japanese Tax Registration Number (*Tōroku Bangō*) | | Kazakhstan | `kz_bin`
/// | Kazakhstani Business Identification Number | | Kenya | `ke_pin` | Kenya Revenue
/// Authority Personal Identification Number | | Kyrgyzstan | `kg_tin` | Kyrgyzstan
/// Tax Identification Number | | Laos | `la_tin` | Laos Tax Identification Number
/// | | Latvia | `eu_vat` | European VAT Number | | Liechtenstein | `li_uid` | Liechtensteinian
/// UID Number | | Liechtenstein | `li_vat` | Liechtenstein VAT Number | | Lithuania
/// | `eu_vat` | European VAT Number | | Luxembourg | `eu_vat` | European VAT Number
/// | | Malaysia | `my_frp` | Malaysian FRP Number | | Malaysia | `my_itn` | Malaysian
/// ITN | | Malaysia | `my_sst` | Malaysian SST Number | | Malta | `eu_vat` | European
/// VAT Number | | Mauritania | `mr_nif` | Mauritania Tax Identification Number (Número
/// de Identificação Fiscal) | | Mexico | `mx_rfc` | Mexican RFC Number | | Moldova
/// | `md_vat` | Moldova VAT Number | | Montenegro | `me_pib` | Montenegro PIB Number
/// | | Morocco | `ma_vat` | Morocco VAT Number | | Nepal | `np_pan` | Nepal PAN
/// Number | | Netherlands | `eu_vat` | European VAT Number | | New Zealand | `nz_gst`
/// | New Zealand GST Number | | Nigeria | `ng_tin` | Nigerian Tax Identification
/// Number | | North Macedonia | `mk_vat` | North Macedonia VAT Number | | Northern
/// Ireland | `eu_vat` | Northern Ireland VAT Number | | Norway | `no_vat` | Norwegian
/// VAT Number | | Norway | `no_voec` | Norwegian VAT on e-commerce Number | | Oman
/// | `om_vat` | Omani VAT Number | | Peru | `pe_ruc` | Peruvian RUC Number | | Philippines
/// | `ph_tin` | Philippines Tax Identification Number | | Poland | `eu_vat` | European
/// VAT Number | | Portugal | `eu_vat` | European VAT Number | | Romania | `eu_vat`
/// | European VAT Number | | Romania | `ro_tin` | Romanian Tax ID Number | | Russia
/// | `ru_inn` | Russian INN | | Russia | `ru_kpp` | Russian KPP | | Saudi Arabia
/// | `sa_vat` | Saudi Arabia VAT | | Senegal | `sn_ninea` | Senegal NINEA Number
/// | | Serbia | `rs_pib` | Serbian PIB Number | | Singapore | `sg_gst` | Singaporean
/// GST | | Singapore | `sg_uen` | Singaporean UEN | | Slovakia | `eu_vat` | European
/// VAT Number | | Slovenia | `eu_vat` | European VAT Number | | Slovenia | `si_tin`
/// | Slovenia Tax Number (davčna številka) | | South Africa | `za_vat` | South African
/// VAT Number | | South Korea | `kr_brn` | Korean BRN | | Spain | `es_cif` | Spanish
/// NIF Number (previously Spanish CIF Number) | | Spain | `eu_vat` | European VAT
/// Number | | Suriname | `sr_fin` | Suriname FIN Number | | Sweden | `eu_vat` |
/// European VAT Number | | Switzerland | `ch_uid` | Switzerland UID Number | | Switzerland
/// | `ch_vat` | Switzerland VAT Number | | Taiwan | `tw_vat` | Taiwanese VAT | |
/// Tajikistan | `tj_tin` | Tajikistan Tax Identification Number | | Tanzania | `tz_vat`
/// | Tanzania VAT Number | | Thailand | `th_vat` | Thai VAT | | Turkey | `tr_tin`
/// | Turkish Tax Identification Number | | Uganda | `ug_tin` | Uganda Tax Identification
/// Number | | Ukraine | `ua_vat` | Ukrainian VAT | | United Arab Emirates | `ae_trn`
/// | United Arab Emirates TRN | | United Kingdom | `gb_vat` | United Kingdom VAT
/// Number | | United States | `us_ein` | United States EIN | | Uruguay | `uy_ruc`
/// | Uruguayan RUC Number | | Uzbekistan | `uz_tin` | Uzbekistan TIN Number | | Uzbekistan
/// | `uz_vat` | Uzbekistan VAT Number | | Venezuela | `ve_rif` | Venezuelan RIF
/// Number | | Vietnam | `vn_tin` | Vietnamese Tax ID Number | | Zambia | `zm_tin`
/// | Zambia Tax Identification Number | | Zimbabwe | `zw_tin` | Zimbabwe Tax Identification
/// Number |
/// </summary>
[JsonConverter(typeof(ModelConverter<CustomerTaxID>))]
public sealed record class CustomerTaxID : ModelBase, IFromRaw<CustomerTaxID>
{
    public required ApiEnum<string, Country> Country
    {
        get
        {
            if (!this._properties.TryGetValue("country", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'country' cannot be null",
                    new System::ArgumentOutOfRangeException("country", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Country>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Type1> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Type1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Country.Validate();
        this.Type.Validate();
        _ = this.Value;
    }

    public CustomerTaxID() { }

    public CustomerTaxID(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerTaxID(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CustomerTaxID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(CountryConverter))]
public enum Country
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

sealed class CountryConverter : JsonConverter<Country>
{
    public override Country Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AD" => Country.Ad,
            "AE" => Country.Ae,
            "AL" => Country.Al,
            "AM" => Country.Am,
            "AO" => Country.Ao,
            "AR" => Country.Ar,
            "AT" => Country.At,
            "AU" => Country.Au,
            "AW" => Country.Aw,
            "AZ" => Country.Az,
            "BA" => Country.Ba,
            "BB" => Country.Bb,
            "BD" => Country.Bd,
            "BE" => Country.Be,
            "BF" => Country.Bf,
            "BG" => Country.Bg,
            "BH" => Country.Bh,
            "BJ" => Country.Bj,
            "BO" => Country.Bo,
            "BR" => Country.Br,
            "BS" => Country.Bs,
            "BY" => Country.By,
            "CA" => Country.Ca,
            "CD" => Country.Cd,
            "CH" => Country.Ch,
            "CL" => Country.Cl,
            "CM" => Country.Cm,
            "CN" => Country.Cn,
            "CO" => Country.Co,
            "CR" => Country.Cr,
            "CV" => Country.Cv,
            "DE" => Country.De,
            "CY" => Country.Cy,
            "CZ" => Country.Cz,
            "DK" => Country.Dk,
            "DO" => Country.Do,
            "EC" => Country.Ec,
            "EE" => Country.Ee,
            "EG" => Country.Eg,
            "ES" => Country.Es,
            "ET" => Country.Et,
            "EU" => Country.Eu,
            "FI" => Country.Fi,
            "FR" => Country.Fr,
            "GB" => Country.GB,
            "GE" => Country.Ge,
            "GN" => Country.Gn,
            "GR" => Country.Gr,
            "HK" => Country.Hk,
            "HR" => Country.Hr,
            "HU" => Country.Hu,
            "ID" => Country.ID,
            "IE" => Country.Ie,
            "IL" => Country.Il,
            "IN" => Country.In,
            "IS" => Country.Is,
            "IT" => Country.It,
            "JP" => Country.Jp,
            "KE" => Country.Ke,
            "KG" => Country.Kg,
            "KH" => Country.Kh,
            "KR" => Country.Kr,
            "KZ" => Country.Kz,
            "LA" => Country.La,
            "LI" => Country.Li,
            "LT" => Country.Lt,
            "LU" => Country.Lu,
            "LV" => Country.Lv,
            "MA" => Country.Ma,
            "MD" => Country.Md,
            "ME" => Country.Me,
            "MK" => Country.Mk,
            "MR" => Country.Mr,
            "MT" => Country.Mt,
            "MX" => Country.Mx,
            "MY" => Country.My,
            "NG" => Country.Ng,
            "NL" => Country.Nl,
            "NO" => Country.No,
            "NP" => Country.Np,
            "NZ" => Country.Nz,
            "OM" => Country.Om,
            "PE" => Country.Pe,
            "PH" => Country.Ph,
            "PL" => Country.Pl,
            "PT" => Country.Pt,
            "RO" => Country.Ro,
            "RS" => Country.Rs,
            "RU" => Country.Ru,
            "SA" => Country.Sa,
            "SE" => Country.Se,
            "SG" => Country.Sg,
            "SI" => Country.Si,
            "SK" => Country.Sk,
            "SN" => Country.Sn,
            "SR" => Country.Sr,
            "SV" => Country.Sv,
            "TH" => Country.Th,
            "TJ" => Country.Tj,
            "TR" => Country.Tr,
            "TW" => Country.Tw,
            "TZ" => Country.Tz,
            "UA" => Country.Ua,
            "UG" => Country.Ug,
            "US" => Country.Us,
            "UY" => Country.Uy,
            "UZ" => Country.Uz,
            "VE" => Country.Ve,
            "VN" => Country.Vn,
            "ZA" => Country.Za,
            "ZM" => Country.Zm,
            "ZW" => Country.Zw,
            _ => (Country)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Country value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Country.Ad => "AD",
                Country.Ae => "AE",
                Country.Al => "AL",
                Country.Am => "AM",
                Country.Ao => "AO",
                Country.Ar => "AR",
                Country.At => "AT",
                Country.Au => "AU",
                Country.Aw => "AW",
                Country.Az => "AZ",
                Country.Ba => "BA",
                Country.Bb => "BB",
                Country.Bd => "BD",
                Country.Be => "BE",
                Country.Bf => "BF",
                Country.Bg => "BG",
                Country.Bh => "BH",
                Country.Bj => "BJ",
                Country.Bo => "BO",
                Country.Br => "BR",
                Country.Bs => "BS",
                Country.By => "BY",
                Country.Ca => "CA",
                Country.Cd => "CD",
                Country.Ch => "CH",
                Country.Cl => "CL",
                Country.Cm => "CM",
                Country.Cn => "CN",
                Country.Co => "CO",
                Country.Cr => "CR",
                Country.Cv => "CV",
                Country.De => "DE",
                Country.Cy => "CY",
                Country.Cz => "CZ",
                Country.Dk => "DK",
                Country.Do => "DO",
                Country.Ec => "EC",
                Country.Ee => "EE",
                Country.Eg => "EG",
                Country.Es => "ES",
                Country.Et => "ET",
                Country.Eu => "EU",
                Country.Fi => "FI",
                Country.Fr => "FR",
                Country.GB => "GB",
                Country.Ge => "GE",
                Country.Gn => "GN",
                Country.Gr => "GR",
                Country.Hk => "HK",
                Country.Hr => "HR",
                Country.Hu => "HU",
                Country.ID => "ID",
                Country.Ie => "IE",
                Country.Il => "IL",
                Country.In => "IN",
                Country.Is => "IS",
                Country.It => "IT",
                Country.Jp => "JP",
                Country.Ke => "KE",
                Country.Kg => "KG",
                Country.Kh => "KH",
                Country.Kr => "KR",
                Country.Kz => "KZ",
                Country.La => "LA",
                Country.Li => "LI",
                Country.Lt => "LT",
                Country.Lu => "LU",
                Country.Lv => "LV",
                Country.Ma => "MA",
                Country.Md => "MD",
                Country.Me => "ME",
                Country.Mk => "MK",
                Country.Mr => "MR",
                Country.Mt => "MT",
                Country.Mx => "MX",
                Country.My => "MY",
                Country.Ng => "NG",
                Country.Nl => "NL",
                Country.No => "NO",
                Country.Np => "NP",
                Country.Nz => "NZ",
                Country.Om => "OM",
                Country.Pe => "PE",
                Country.Ph => "PH",
                Country.Pl => "PL",
                Country.Pt => "PT",
                Country.Ro => "RO",
                Country.Rs => "RS",
                Country.Ru => "RU",
                Country.Sa => "SA",
                Country.Se => "SE",
                Country.Sg => "SG",
                Country.Si => "SI",
                Country.Sk => "SK",
                Country.Sn => "SN",
                Country.Sr => "SR",
                Country.Sv => "SV",
                Country.Th => "TH",
                Country.Tj => "TJ",
                Country.Tr => "TR",
                Country.Tw => "TW",
                Country.Tz => "TZ",
                Country.Ua => "UA",
                Country.Ug => "UG",
                Country.Us => "US",
                Country.Uy => "UY",
                Country.Uz => "UZ",
                Country.Ve => "VE",
                Country.Vn => "VN",
                Country.Za => "ZA",
                Country.Zm => "ZM",
                Country.Zw => "ZW",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(Type1Converter))]
public enum Type1
{
    AdNrt,
    AeTrn,
    AlTin,
    AmTin,
    AoTin,
    ArCuit,
    EuVat,
    AuAbn,
    AuArn,
    AwTin,
    AzTin,
    BaTin,
    BbTin,
    BdBin,
    BfIfu,
    BgUic,
    BhVat,
    BjIfu,
    BoTin,
    BrCnpj,
    BrCpf,
    BsTin,
    ByTin,
    CaBn,
    CaGstHst,
    CaPstBc,
    CaPstMB,
    CaPstSk,
    CaQst,
    CdNif,
    ChUid,
    ChVat,
    ClTin,
    CmNiu,
    CnTin,
    CoNit,
    CrTin,
    CvNif,
    DeStn,
    DoRcn,
    EcRuc,
    EgTin,
    EsCif,
    EtTin,
    EuOssVat,
    GBVat,
    GeVat,
    GnNif,
    HkBr,
    HrOib,
    HuTin,
    IDNpwp,
    IlVat,
    InGst,
    IsVat,
    JpCn,
    JpRn,
    JpTrn,
    KePin,
    KgTin,
    KhTin,
    KrBrn,
    KzBin,
    LaTin,
    LiUid,
    LiVat,
    MaVat,
    MdVat,
    MePib,
    MkVat,
    MrNif,
    MxRfc,
    MyFrp,
    MyItn,
    MySst,
    NgTin,
    NoVat,
    NoVoec,
    NpPan,
    NzGst,
    OmVat,
    PeRuc,
    PhTin,
    RoTin,
    RsPib,
    RuInn,
    RuKpp,
    SaVat,
    SgGst,
    SgUen,
    SiTin,
    SnNinea,
    SrFin,
    SvNit,
    ThVat,
    TjTin,
    TrTin,
    TwVat,
    TzVat,
    UaVat,
    UgTin,
    UsEin,
    UyRuc,
    UzTin,
    UzVat,
    VeRif,
    VnTin,
    ZaVat,
    ZmTin,
    ZwTin,
}

sealed class Type1Converter : JsonConverter<Type1>
{
    public override Type1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ad_nrt" => Type1.AdNrt,
            "ae_trn" => Type1.AeTrn,
            "al_tin" => Type1.AlTin,
            "am_tin" => Type1.AmTin,
            "ao_tin" => Type1.AoTin,
            "ar_cuit" => Type1.ArCuit,
            "eu_vat" => Type1.EuVat,
            "au_abn" => Type1.AuAbn,
            "au_arn" => Type1.AuArn,
            "aw_tin" => Type1.AwTin,
            "az_tin" => Type1.AzTin,
            "ba_tin" => Type1.BaTin,
            "bb_tin" => Type1.BbTin,
            "bd_bin" => Type1.BdBin,
            "bf_ifu" => Type1.BfIfu,
            "bg_uic" => Type1.BgUic,
            "bh_vat" => Type1.BhVat,
            "bj_ifu" => Type1.BjIfu,
            "bo_tin" => Type1.BoTin,
            "br_cnpj" => Type1.BrCnpj,
            "br_cpf" => Type1.BrCpf,
            "bs_tin" => Type1.BsTin,
            "by_tin" => Type1.ByTin,
            "ca_bn" => Type1.CaBn,
            "ca_gst_hst" => Type1.CaGstHst,
            "ca_pst_bc" => Type1.CaPstBc,
            "ca_pst_mb" => Type1.CaPstMB,
            "ca_pst_sk" => Type1.CaPstSk,
            "ca_qst" => Type1.CaQst,
            "cd_nif" => Type1.CdNif,
            "ch_uid" => Type1.ChUid,
            "ch_vat" => Type1.ChVat,
            "cl_tin" => Type1.ClTin,
            "cm_niu" => Type1.CmNiu,
            "cn_tin" => Type1.CnTin,
            "co_nit" => Type1.CoNit,
            "cr_tin" => Type1.CrTin,
            "cv_nif" => Type1.CvNif,
            "de_stn" => Type1.DeStn,
            "do_rcn" => Type1.DoRcn,
            "ec_ruc" => Type1.EcRuc,
            "eg_tin" => Type1.EgTin,
            "es_cif" => Type1.EsCif,
            "et_tin" => Type1.EtTin,
            "eu_oss_vat" => Type1.EuOssVat,
            "gb_vat" => Type1.GBVat,
            "ge_vat" => Type1.GeVat,
            "gn_nif" => Type1.GnNif,
            "hk_br" => Type1.HkBr,
            "hr_oib" => Type1.HrOib,
            "hu_tin" => Type1.HuTin,
            "id_npwp" => Type1.IDNpwp,
            "il_vat" => Type1.IlVat,
            "in_gst" => Type1.InGst,
            "is_vat" => Type1.IsVat,
            "jp_cn" => Type1.JpCn,
            "jp_rn" => Type1.JpRn,
            "jp_trn" => Type1.JpTrn,
            "ke_pin" => Type1.KePin,
            "kg_tin" => Type1.KgTin,
            "kh_tin" => Type1.KhTin,
            "kr_brn" => Type1.KrBrn,
            "kz_bin" => Type1.KzBin,
            "la_tin" => Type1.LaTin,
            "li_uid" => Type1.LiUid,
            "li_vat" => Type1.LiVat,
            "ma_vat" => Type1.MaVat,
            "md_vat" => Type1.MdVat,
            "me_pib" => Type1.MePib,
            "mk_vat" => Type1.MkVat,
            "mr_nif" => Type1.MrNif,
            "mx_rfc" => Type1.MxRfc,
            "my_frp" => Type1.MyFrp,
            "my_itn" => Type1.MyItn,
            "my_sst" => Type1.MySst,
            "ng_tin" => Type1.NgTin,
            "no_vat" => Type1.NoVat,
            "no_voec" => Type1.NoVoec,
            "np_pan" => Type1.NpPan,
            "nz_gst" => Type1.NzGst,
            "om_vat" => Type1.OmVat,
            "pe_ruc" => Type1.PeRuc,
            "ph_tin" => Type1.PhTin,
            "ro_tin" => Type1.RoTin,
            "rs_pib" => Type1.RsPib,
            "ru_inn" => Type1.RuInn,
            "ru_kpp" => Type1.RuKpp,
            "sa_vat" => Type1.SaVat,
            "sg_gst" => Type1.SgGst,
            "sg_uen" => Type1.SgUen,
            "si_tin" => Type1.SiTin,
            "sn_ninea" => Type1.SnNinea,
            "sr_fin" => Type1.SrFin,
            "sv_nit" => Type1.SvNit,
            "th_vat" => Type1.ThVat,
            "tj_tin" => Type1.TjTin,
            "tr_tin" => Type1.TrTin,
            "tw_vat" => Type1.TwVat,
            "tz_vat" => Type1.TzVat,
            "ua_vat" => Type1.UaVat,
            "ug_tin" => Type1.UgTin,
            "us_ein" => Type1.UsEin,
            "uy_ruc" => Type1.UyRuc,
            "uz_tin" => Type1.UzTin,
            "uz_vat" => Type1.UzVat,
            "ve_rif" => Type1.VeRif,
            "vn_tin" => Type1.VnTin,
            "za_vat" => Type1.ZaVat,
            "zm_tin" => Type1.ZmTin,
            "zw_tin" => Type1.ZwTin,
            _ => (Type1)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type1 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type1.AdNrt => "ad_nrt",
                Type1.AeTrn => "ae_trn",
                Type1.AlTin => "al_tin",
                Type1.AmTin => "am_tin",
                Type1.AoTin => "ao_tin",
                Type1.ArCuit => "ar_cuit",
                Type1.EuVat => "eu_vat",
                Type1.AuAbn => "au_abn",
                Type1.AuArn => "au_arn",
                Type1.AwTin => "aw_tin",
                Type1.AzTin => "az_tin",
                Type1.BaTin => "ba_tin",
                Type1.BbTin => "bb_tin",
                Type1.BdBin => "bd_bin",
                Type1.BfIfu => "bf_ifu",
                Type1.BgUic => "bg_uic",
                Type1.BhVat => "bh_vat",
                Type1.BjIfu => "bj_ifu",
                Type1.BoTin => "bo_tin",
                Type1.BrCnpj => "br_cnpj",
                Type1.BrCpf => "br_cpf",
                Type1.BsTin => "bs_tin",
                Type1.ByTin => "by_tin",
                Type1.CaBn => "ca_bn",
                Type1.CaGstHst => "ca_gst_hst",
                Type1.CaPstBc => "ca_pst_bc",
                Type1.CaPstMB => "ca_pst_mb",
                Type1.CaPstSk => "ca_pst_sk",
                Type1.CaQst => "ca_qst",
                Type1.CdNif => "cd_nif",
                Type1.ChUid => "ch_uid",
                Type1.ChVat => "ch_vat",
                Type1.ClTin => "cl_tin",
                Type1.CmNiu => "cm_niu",
                Type1.CnTin => "cn_tin",
                Type1.CoNit => "co_nit",
                Type1.CrTin => "cr_tin",
                Type1.CvNif => "cv_nif",
                Type1.DeStn => "de_stn",
                Type1.DoRcn => "do_rcn",
                Type1.EcRuc => "ec_ruc",
                Type1.EgTin => "eg_tin",
                Type1.EsCif => "es_cif",
                Type1.EtTin => "et_tin",
                Type1.EuOssVat => "eu_oss_vat",
                Type1.GBVat => "gb_vat",
                Type1.GeVat => "ge_vat",
                Type1.GnNif => "gn_nif",
                Type1.HkBr => "hk_br",
                Type1.HrOib => "hr_oib",
                Type1.HuTin => "hu_tin",
                Type1.IDNpwp => "id_npwp",
                Type1.IlVat => "il_vat",
                Type1.InGst => "in_gst",
                Type1.IsVat => "is_vat",
                Type1.JpCn => "jp_cn",
                Type1.JpRn => "jp_rn",
                Type1.JpTrn => "jp_trn",
                Type1.KePin => "ke_pin",
                Type1.KgTin => "kg_tin",
                Type1.KhTin => "kh_tin",
                Type1.KrBrn => "kr_brn",
                Type1.KzBin => "kz_bin",
                Type1.LaTin => "la_tin",
                Type1.LiUid => "li_uid",
                Type1.LiVat => "li_vat",
                Type1.MaVat => "ma_vat",
                Type1.MdVat => "md_vat",
                Type1.MePib => "me_pib",
                Type1.MkVat => "mk_vat",
                Type1.MrNif => "mr_nif",
                Type1.MxRfc => "mx_rfc",
                Type1.MyFrp => "my_frp",
                Type1.MyItn => "my_itn",
                Type1.MySst => "my_sst",
                Type1.NgTin => "ng_tin",
                Type1.NoVat => "no_vat",
                Type1.NoVoec => "no_voec",
                Type1.NpPan => "np_pan",
                Type1.NzGst => "nz_gst",
                Type1.OmVat => "om_vat",
                Type1.PeRuc => "pe_ruc",
                Type1.PhTin => "ph_tin",
                Type1.RoTin => "ro_tin",
                Type1.RsPib => "rs_pib",
                Type1.RuInn => "ru_inn",
                Type1.RuKpp => "ru_kpp",
                Type1.SaVat => "sa_vat",
                Type1.SgGst => "sg_gst",
                Type1.SgUen => "sg_uen",
                Type1.SiTin => "si_tin",
                Type1.SnNinea => "sn_ninea",
                Type1.SrFin => "sr_fin",
                Type1.SvNit => "sv_nit",
                Type1.ThVat => "th_vat",
                Type1.TjTin => "tj_tin",
                Type1.TrTin => "tr_tin",
                Type1.TwVat => "tw_vat",
                Type1.TzVat => "tz_vat",
                Type1.UaVat => "ua_vat",
                Type1.UgTin => "ug_tin",
                Type1.UsEin => "us_ein",
                Type1.UyRuc => "uy_ruc",
                Type1.UzTin => "uz_tin",
                Type1.UzVat => "uz_vat",
                Type1.VeRif => "ve_rif",
                Type1.VnTin => "vn_tin",
                Type1.ZaVat => "za_vat",
                Type1.ZmTin => "zm_tin",
                Type1.ZwTin => "zw_tin",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
