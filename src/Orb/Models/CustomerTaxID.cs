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
/// <para>### Supported Tax ID Countries and Types</para>
///
/// <para>| Country | Type | Description | |---------|------|-------------| | Albania
/// | `al_tin` | Albania Tax Identification Number | | Andorra | `ad_nrt` | Andorran
/// NRT Number | | Angola | `ao_tin` | Angola Tax Identification Number | | Argentina
/// | `ar_cuit` | Argentinian Tax ID Number | | Armenia | `am_tin` | Armenia Tax
/// Identification Number | | Aruba | `aw_tin` | Aruba Tax Identification Number
/// | | Australia | `au_abn` | Australian Business Number (AU ABN) | | Australia
/// | `au_arn` | Australian Taxation Office Reference Number | | Austria | `eu_vat`
/// | European VAT Number | | Azerbaijan | `az_tin` | Azerbaijan Tax Identification
/// Number | | Bahamas | `bs_tin` | Bahamas Tax Identification Number | | Bahrain
/// | `bh_vat` | Bahraini VAT Number | | Bangladesh | `bd_bin` | Bangladesh Business
/// Identification Number | | Barbados | `bb_tin` | Barbados Tax Identification Number
/// | | Belarus | `by_tin` | Belarus TIN Number | | Belgium | `eu_vat` | European
/// VAT Number | | Benin | `bj_ifu` | Benin Tax Identification Number (Identifiant
/// Fiscal Unique) | | Bolivia | `bo_tin` | Bolivian Tax ID | | Bosnia and Herzegovina
/// | `ba_tin` | Bosnia and Herzegovina Tax Identification Number | | Brazil | `br_cnpj`
/// | Brazilian CNPJ Number | | Brazil | `br_cpf` | Brazilian CPF Number | | Bulgaria
/// | `bg_uic` | Bulgaria Unified Identification Code | | Bulgaria | `eu_vat` | European
/// VAT Number | | Burkina Faso | `bf_ifu` | Burkina Faso Tax Identification Number
/// (Numéro d'Identifiant Fiscal Unique) | | Cambodia | `kh_tin` | Cambodia Tax Identification
/// Number | | Cameroon | `cm_niu` | Cameroon Tax Identification Number (Numéro d'Identifiant
/// fiscal Unique) | | Canada | `ca_bn` | Canadian BN | | Canada | `ca_gst_hst` |
/// Canadian GST/HST Number | | Canada | `ca_pst_bc` | Canadian PST Number (British
/// Columbia) | | Canada | `ca_pst_mb` | Canadian PST Number (Manitoba) | | Canada
/// | `ca_pst_sk` | Canadian PST Number (Saskatchewan) | | Canada | `ca_qst` | Canadian
/// QST Number (Québec) | | Cape Verde | `cv_nif` | Cape Verde Tax Identification
/// Number (Número de Identificação Fiscal) | | Chile | `cl_tin` | Chilean TIN |
/// | China | `cn_tin` | Chinese Tax ID | | Colombia | `co_nit` | Colombian NIT Number
/// | | Congo-Kinshasa | `cd_nif` | Congo (DR) Tax Identification Number (Número de
/// Identificação Fiscal) | | Costa Rica | `cr_tin` | Costa Rican Tax ID | | Croatia
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
/// Number | | Hungary | `eu_vat` | European VAT Number | | Hungary | `hu_tin` |
/// Hungary Tax Number (adószám) | | Iceland | `is_vat` | Icelandic VAT | | India
/// | `in_gst` | Indian GST Number | | Indonesia | `id_npwp` | Indonesian NPWP Number
/// | | Ireland | `eu_vat` | European VAT Number | | Israel | `il_vat` | Israel VAT
/// | | Italy | `eu_vat` | European VAT Number | | Japan | `jp_cn` | Japanese Corporate
/// Number (*Hōjin Bangō*) | | Japan | `jp_rn` | Japanese Registered Foreign Businesses'
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
/// | | Morocco | `ma_vat` | Morocco VAT Number | | Nepal | `np_pan` | Nepal PAN Number
/// | | Netherlands | `eu_vat` | European VAT Number | | New Zealand | `nz_gst` |
/// New Zealand GST Number | | Nigeria | `ng_tin` | Nigerian Tax Identification Number
/// | | North Macedonia | `mk_vat` | North Macedonia VAT Number | | Northern Ireland
/// | `eu_vat` | Northern Ireland VAT Number | | Norway | `no_vat` | Norwegian VAT
/// Number | | Norway | `no_voec` | Norwegian VAT on e-commerce Number | | Oman |
/// `om_vat` | Omani VAT Number | | Peru | `pe_ruc` | Peruvian RUC Number | | Philippines
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
/// Number | | Suriname | `sr_fin` | Suriname FIN Number | | Sweden | `eu_vat` | European
/// VAT Number | | Switzerland | `ch_uid` | Switzerland UID Number | | Switzerland
/// | `ch_vat` | Switzerland VAT Number | | Taiwan | `tw_vat` | Taiwanese VAT | |
/// Tajikistan | `tj_tin` | Tajikistan Tax Identification Number | | Tanzania | `tz_vat`
/// | Tanzania VAT Number | | Thailand | `th_vat` | Thai VAT | | Turkey | `tr_tin`
/// | Turkish Tax Identification Number | | Uganda | `ug_tin` | Uganda Tax Identification
/// Number | | Ukraine | `ua_vat` | Ukrainian VAT | | United Arab Emirates | `ae_trn`
/// | United Arab Emirates TRN | | United Kingdom | `gb_vat` | United Kingdom VAT
/// Number | | United States | `us_ein` | United States EIN | | Uruguay | `uy_ruc`
/// | Uruguayan RUC Number | | Uzbekistan | `uz_tin` | Uzbekistan TIN Number | |
/// Uzbekistan | `uz_vat` | Uzbekistan VAT Number | | Venezuela | `ve_rif` | Venezuelan
/// RIF Number | | Vietnam | `vn_tin` | Vietnamese Tax ID Number | | Zambia | `zm_tin`
/// | Zambia Tax Identification Number | | Zimbabwe | `zw_tin` | Zimbabwe Tax Identification
/// Number |</para>
/// </summary>
[JsonConverter(typeof(ModelConverter<CustomerTaxID, CustomerTaxIDFromRaw>))]
public sealed record class CustomerTaxID : ModelBase
{
    public required ApiEnum<string, Country> Country
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Country>>(this.RawData, "country"); }
        init { ModelBase.Set(this._rawData, "country", value); }
    }

    public required ApiEnum<string, CustomerTaxIDType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, CustomerTaxIDType>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required string Value
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Country.Validate();
        this.Type.Validate();
        _ = this.Value;
    }

    public CustomerTaxID() { }

    public CustomerTaxID(CustomerTaxID customerTaxID)
        : base(customerTaxID) { }

    public CustomerTaxID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerTaxID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerTaxIDFromRaw.FromRawUnchecked"/>
    public static CustomerTaxID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerTaxIDFromRaw : IFromRaw<CustomerTaxID>
{
    /// <inheritdoc/>
    public CustomerTaxID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerTaxID.FromRawUnchecked(rawData);
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

[JsonConverter(typeof(CustomerTaxIDTypeConverter))]
public enum CustomerTaxIDType
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

sealed class CustomerTaxIDTypeConverter : JsonConverter<CustomerTaxIDType>
{
    public override CustomerTaxIDType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ad_nrt" => CustomerTaxIDType.AdNrt,
            "ae_trn" => CustomerTaxIDType.AeTrn,
            "al_tin" => CustomerTaxIDType.AlTin,
            "am_tin" => CustomerTaxIDType.AmTin,
            "ao_tin" => CustomerTaxIDType.AoTin,
            "ar_cuit" => CustomerTaxIDType.ArCuit,
            "eu_vat" => CustomerTaxIDType.EuVat,
            "au_abn" => CustomerTaxIDType.AuAbn,
            "au_arn" => CustomerTaxIDType.AuArn,
            "aw_tin" => CustomerTaxIDType.AwTin,
            "az_tin" => CustomerTaxIDType.AzTin,
            "ba_tin" => CustomerTaxIDType.BaTin,
            "bb_tin" => CustomerTaxIDType.BbTin,
            "bd_bin" => CustomerTaxIDType.BdBin,
            "bf_ifu" => CustomerTaxIDType.BfIfu,
            "bg_uic" => CustomerTaxIDType.BgUic,
            "bh_vat" => CustomerTaxIDType.BhVat,
            "bj_ifu" => CustomerTaxIDType.BjIfu,
            "bo_tin" => CustomerTaxIDType.BoTin,
            "br_cnpj" => CustomerTaxIDType.BrCnpj,
            "br_cpf" => CustomerTaxIDType.BrCpf,
            "bs_tin" => CustomerTaxIDType.BsTin,
            "by_tin" => CustomerTaxIDType.ByTin,
            "ca_bn" => CustomerTaxIDType.CaBn,
            "ca_gst_hst" => CustomerTaxIDType.CaGstHst,
            "ca_pst_bc" => CustomerTaxIDType.CaPstBc,
            "ca_pst_mb" => CustomerTaxIDType.CaPstMB,
            "ca_pst_sk" => CustomerTaxIDType.CaPstSk,
            "ca_qst" => CustomerTaxIDType.CaQst,
            "cd_nif" => CustomerTaxIDType.CdNif,
            "ch_uid" => CustomerTaxIDType.ChUid,
            "ch_vat" => CustomerTaxIDType.ChVat,
            "cl_tin" => CustomerTaxIDType.ClTin,
            "cm_niu" => CustomerTaxIDType.CmNiu,
            "cn_tin" => CustomerTaxIDType.CnTin,
            "co_nit" => CustomerTaxIDType.CoNit,
            "cr_tin" => CustomerTaxIDType.CrTin,
            "cv_nif" => CustomerTaxIDType.CvNif,
            "de_stn" => CustomerTaxIDType.DeStn,
            "do_rcn" => CustomerTaxIDType.DoRcn,
            "ec_ruc" => CustomerTaxIDType.EcRuc,
            "eg_tin" => CustomerTaxIDType.EgTin,
            "es_cif" => CustomerTaxIDType.EsCif,
            "et_tin" => CustomerTaxIDType.EtTin,
            "eu_oss_vat" => CustomerTaxIDType.EuOssVat,
            "gb_vat" => CustomerTaxIDType.GBVat,
            "ge_vat" => CustomerTaxIDType.GeVat,
            "gn_nif" => CustomerTaxIDType.GnNif,
            "hk_br" => CustomerTaxIDType.HkBr,
            "hr_oib" => CustomerTaxIDType.HrOib,
            "hu_tin" => CustomerTaxIDType.HuTin,
            "id_npwp" => CustomerTaxIDType.IDNpwp,
            "il_vat" => CustomerTaxIDType.IlVat,
            "in_gst" => CustomerTaxIDType.InGst,
            "is_vat" => CustomerTaxIDType.IsVat,
            "jp_cn" => CustomerTaxIDType.JpCn,
            "jp_rn" => CustomerTaxIDType.JpRn,
            "jp_trn" => CustomerTaxIDType.JpTrn,
            "ke_pin" => CustomerTaxIDType.KePin,
            "kg_tin" => CustomerTaxIDType.KgTin,
            "kh_tin" => CustomerTaxIDType.KhTin,
            "kr_brn" => CustomerTaxIDType.KrBrn,
            "kz_bin" => CustomerTaxIDType.KzBin,
            "la_tin" => CustomerTaxIDType.LaTin,
            "li_uid" => CustomerTaxIDType.LiUid,
            "li_vat" => CustomerTaxIDType.LiVat,
            "ma_vat" => CustomerTaxIDType.MaVat,
            "md_vat" => CustomerTaxIDType.MdVat,
            "me_pib" => CustomerTaxIDType.MePib,
            "mk_vat" => CustomerTaxIDType.MkVat,
            "mr_nif" => CustomerTaxIDType.MrNif,
            "mx_rfc" => CustomerTaxIDType.MxRfc,
            "my_frp" => CustomerTaxIDType.MyFrp,
            "my_itn" => CustomerTaxIDType.MyItn,
            "my_sst" => CustomerTaxIDType.MySst,
            "ng_tin" => CustomerTaxIDType.NgTin,
            "no_vat" => CustomerTaxIDType.NoVat,
            "no_voec" => CustomerTaxIDType.NoVoec,
            "np_pan" => CustomerTaxIDType.NpPan,
            "nz_gst" => CustomerTaxIDType.NzGst,
            "om_vat" => CustomerTaxIDType.OmVat,
            "pe_ruc" => CustomerTaxIDType.PeRuc,
            "ph_tin" => CustomerTaxIDType.PhTin,
            "ro_tin" => CustomerTaxIDType.RoTin,
            "rs_pib" => CustomerTaxIDType.RsPib,
            "ru_inn" => CustomerTaxIDType.RuInn,
            "ru_kpp" => CustomerTaxIDType.RuKpp,
            "sa_vat" => CustomerTaxIDType.SaVat,
            "sg_gst" => CustomerTaxIDType.SgGst,
            "sg_uen" => CustomerTaxIDType.SgUen,
            "si_tin" => CustomerTaxIDType.SiTin,
            "sn_ninea" => CustomerTaxIDType.SnNinea,
            "sr_fin" => CustomerTaxIDType.SrFin,
            "sv_nit" => CustomerTaxIDType.SvNit,
            "th_vat" => CustomerTaxIDType.ThVat,
            "tj_tin" => CustomerTaxIDType.TjTin,
            "tr_tin" => CustomerTaxIDType.TrTin,
            "tw_vat" => CustomerTaxIDType.TwVat,
            "tz_vat" => CustomerTaxIDType.TzVat,
            "ua_vat" => CustomerTaxIDType.UaVat,
            "ug_tin" => CustomerTaxIDType.UgTin,
            "us_ein" => CustomerTaxIDType.UsEin,
            "uy_ruc" => CustomerTaxIDType.UyRuc,
            "uz_tin" => CustomerTaxIDType.UzTin,
            "uz_vat" => CustomerTaxIDType.UzVat,
            "ve_rif" => CustomerTaxIDType.VeRif,
            "vn_tin" => CustomerTaxIDType.VnTin,
            "za_vat" => CustomerTaxIDType.ZaVat,
            "zm_tin" => CustomerTaxIDType.ZmTin,
            "zw_tin" => CustomerTaxIDType.ZwTin,
            _ => (CustomerTaxIDType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerTaxIDType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerTaxIDType.AdNrt => "ad_nrt",
                CustomerTaxIDType.AeTrn => "ae_trn",
                CustomerTaxIDType.AlTin => "al_tin",
                CustomerTaxIDType.AmTin => "am_tin",
                CustomerTaxIDType.AoTin => "ao_tin",
                CustomerTaxIDType.ArCuit => "ar_cuit",
                CustomerTaxIDType.EuVat => "eu_vat",
                CustomerTaxIDType.AuAbn => "au_abn",
                CustomerTaxIDType.AuArn => "au_arn",
                CustomerTaxIDType.AwTin => "aw_tin",
                CustomerTaxIDType.AzTin => "az_tin",
                CustomerTaxIDType.BaTin => "ba_tin",
                CustomerTaxIDType.BbTin => "bb_tin",
                CustomerTaxIDType.BdBin => "bd_bin",
                CustomerTaxIDType.BfIfu => "bf_ifu",
                CustomerTaxIDType.BgUic => "bg_uic",
                CustomerTaxIDType.BhVat => "bh_vat",
                CustomerTaxIDType.BjIfu => "bj_ifu",
                CustomerTaxIDType.BoTin => "bo_tin",
                CustomerTaxIDType.BrCnpj => "br_cnpj",
                CustomerTaxIDType.BrCpf => "br_cpf",
                CustomerTaxIDType.BsTin => "bs_tin",
                CustomerTaxIDType.ByTin => "by_tin",
                CustomerTaxIDType.CaBn => "ca_bn",
                CustomerTaxIDType.CaGstHst => "ca_gst_hst",
                CustomerTaxIDType.CaPstBc => "ca_pst_bc",
                CustomerTaxIDType.CaPstMB => "ca_pst_mb",
                CustomerTaxIDType.CaPstSk => "ca_pst_sk",
                CustomerTaxIDType.CaQst => "ca_qst",
                CustomerTaxIDType.CdNif => "cd_nif",
                CustomerTaxIDType.ChUid => "ch_uid",
                CustomerTaxIDType.ChVat => "ch_vat",
                CustomerTaxIDType.ClTin => "cl_tin",
                CustomerTaxIDType.CmNiu => "cm_niu",
                CustomerTaxIDType.CnTin => "cn_tin",
                CustomerTaxIDType.CoNit => "co_nit",
                CustomerTaxIDType.CrTin => "cr_tin",
                CustomerTaxIDType.CvNif => "cv_nif",
                CustomerTaxIDType.DeStn => "de_stn",
                CustomerTaxIDType.DoRcn => "do_rcn",
                CustomerTaxIDType.EcRuc => "ec_ruc",
                CustomerTaxIDType.EgTin => "eg_tin",
                CustomerTaxIDType.EsCif => "es_cif",
                CustomerTaxIDType.EtTin => "et_tin",
                CustomerTaxIDType.EuOssVat => "eu_oss_vat",
                CustomerTaxIDType.GBVat => "gb_vat",
                CustomerTaxIDType.GeVat => "ge_vat",
                CustomerTaxIDType.GnNif => "gn_nif",
                CustomerTaxIDType.HkBr => "hk_br",
                CustomerTaxIDType.HrOib => "hr_oib",
                CustomerTaxIDType.HuTin => "hu_tin",
                CustomerTaxIDType.IDNpwp => "id_npwp",
                CustomerTaxIDType.IlVat => "il_vat",
                CustomerTaxIDType.InGst => "in_gst",
                CustomerTaxIDType.IsVat => "is_vat",
                CustomerTaxIDType.JpCn => "jp_cn",
                CustomerTaxIDType.JpRn => "jp_rn",
                CustomerTaxIDType.JpTrn => "jp_trn",
                CustomerTaxIDType.KePin => "ke_pin",
                CustomerTaxIDType.KgTin => "kg_tin",
                CustomerTaxIDType.KhTin => "kh_tin",
                CustomerTaxIDType.KrBrn => "kr_brn",
                CustomerTaxIDType.KzBin => "kz_bin",
                CustomerTaxIDType.LaTin => "la_tin",
                CustomerTaxIDType.LiUid => "li_uid",
                CustomerTaxIDType.LiVat => "li_vat",
                CustomerTaxIDType.MaVat => "ma_vat",
                CustomerTaxIDType.MdVat => "md_vat",
                CustomerTaxIDType.MePib => "me_pib",
                CustomerTaxIDType.MkVat => "mk_vat",
                CustomerTaxIDType.MrNif => "mr_nif",
                CustomerTaxIDType.MxRfc => "mx_rfc",
                CustomerTaxIDType.MyFrp => "my_frp",
                CustomerTaxIDType.MyItn => "my_itn",
                CustomerTaxIDType.MySst => "my_sst",
                CustomerTaxIDType.NgTin => "ng_tin",
                CustomerTaxIDType.NoVat => "no_vat",
                CustomerTaxIDType.NoVoec => "no_voec",
                CustomerTaxIDType.NpPan => "np_pan",
                CustomerTaxIDType.NzGst => "nz_gst",
                CustomerTaxIDType.OmVat => "om_vat",
                CustomerTaxIDType.PeRuc => "pe_ruc",
                CustomerTaxIDType.PhTin => "ph_tin",
                CustomerTaxIDType.RoTin => "ro_tin",
                CustomerTaxIDType.RsPib => "rs_pib",
                CustomerTaxIDType.RuInn => "ru_inn",
                CustomerTaxIDType.RuKpp => "ru_kpp",
                CustomerTaxIDType.SaVat => "sa_vat",
                CustomerTaxIDType.SgGst => "sg_gst",
                CustomerTaxIDType.SgUen => "sg_uen",
                CustomerTaxIDType.SiTin => "si_tin",
                CustomerTaxIDType.SnNinea => "sn_ninea",
                CustomerTaxIDType.SrFin => "sr_fin",
                CustomerTaxIDType.SvNit => "sv_nit",
                CustomerTaxIDType.ThVat => "th_vat",
                CustomerTaxIDType.TjTin => "tj_tin",
                CustomerTaxIDType.TrTin => "tr_tin",
                CustomerTaxIDType.TwVat => "tw_vat",
                CustomerTaxIDType.TzVat => "tz_vat",
                CustomerTaxIDType.UaVat => "ua_vat",
                CustomerTaxIDType.UgTin => "ug_tin",
                CustomerTaxIDType.UsEin => "us_ein",
                CustomerTaxIDType.UyRuc => "uy_ruc",
                CustomerTaxIDType.UzTin => "uz_tin",
                CustomerTaxIDType.UzVat => "uz_vat",
                CustomerTaxIDType.VeRif => "ve_rif",
                CustomerTaxIDType.VnTin => "vn_tin",
                CustomerTaxIDType.ZaVat => "za_vat",
                CustomerTaxIDType.ZmTin => "zm_tin",
                CustomerTaxIDType.ZwTin => "zw_tin",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
