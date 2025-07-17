using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CustomerTaxIDProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Type, string>))]
public sealed record class Type(string value) : Orb::IEnum<Type, string>
{
    public static readonly Type AdNrt = new("ad_nrt");

    public static readonly Type AeTrn = new("ae_trn");

    public static readonly Type ArCuit = new("ar_cuit");

    public static readonly Type EuVat = new("eu_vat");

    public static readonly Type AuAbn = new("au_abn");

    public static readonly Type AuArn = new("au_arn");

    public static readonly Type BgUic = new("bg_uic");

    public static readonly Type BhVat = new("bh_vat");

    public static readonly Type BoTin = new("bo_tin");

    public static readonly Type BrCnpj = new("br_cnpj");

    public static readonly Type BrCpf = new("br_cpf");

    public static readonly Type CaBn = new("ca_bn");

    public static readonly Type CaGstHst = new("ca_gst_hst");

    public static readonly Type CaPstBc = new("ca_pst_bc");

    public static readonly Type CaPstMB = new("ca_pst_mb");

    public static readonly Type CaPstSk = new("ca_pst_sk");

    public static readonly Type CaQst = new("ca_qst");

    public static readonly Type ChVat = new("ch_vat");

    public static readonly Type ClTin = new("cl_tin");

    public static readonly Type CnTin = new("cn_tin");

    public static readonly Type CoNit = new("co_nit");

    public static readonly Type CrTin = new("cr_tin");

    public static readonly Type DoRcn = new("do_rcn");

    public static readonly Type EcRuc = new("ec_ruc");

    public static readonly Type EgTin = new("eg_tin");

    public static readonly Type EsCif = new("es_cif");

    public static readonly Type EuOssVat = new("eu_oss_vat");

    public static readonly Type GBVat = new("gb_vat");

    public static readonly Type GeVat = new("ge_vat");

    public static readonly Type HkBr = new("hk_br");

    public static readonly Type HuTin = new("hu_tin");

    public static readonly Type IDNpwp = new("id_npwp");

    public static readonly Type IlVat = new("il_vat");

    public static readonly Type InGst = new("in_gst");

    public static readonly Type IsVat = new("is_vat");

    public static readonly Type JpCn = new("jp_cn");

    public static readonly Type JpRn = new("jp_rn");

    public static readonly Type JpTrn = new("jp_trn");

    public static readonly Type KePin = new("ke_pin");

    public static readonly Type KrBrn = new("kr_brn");

    public static readonly Type KzBin = new("kz_bin");

    public static readonly Type LiUid = new("li_uid");

    public static readonly Type MxRfc = new("mx_rfc");

    public static readonly Type MyFrp = new("my_frp");

    public static readonly Type MyItn = new("my_itn");

    public static readonly Type MySst = new("my_sst");

    public static readonly Type NgTin = new("ng_tin");

    public static readonly Type NoVat = new("no_vat");

    public static readonly Type NoVoec = new("no_voec");

    public static readonly Type NzGst = new("nz_gst");

    public static readonly Type OmVat = new("om_vat");

    public static readonly Type PeRuc = new("pe_ruc");

    public static readonly Type PhTin = new("ph_tin");

    public static readonly Type RoTin = new("ro_tin");

    public static readonly Type RsPib = new("rs_pib");

    public static readonly Type RuInn = new("ru_inn");

    public static readonly Type RuKpp = new("ru_kpp");

    public static readonly Type SaVat = new("sa_vat");

    public static readonly Type SgGst = new("sg_gst");

    public static readonly Type SgUen = new("sg_uen");

    public static readonly Type SiTin = new("si_tin");

    public static readonly Type SvNit = new("sv_nit");

    public static readonly Type ThVat = new("th_vat");

    public static readonly Type TrTin = new("tr_tin");

    public static readonly Type TwVat = new("tw_vat");

    public static readonly Type UaVat = new("ua_vat");

    public static readonly Type UsEin = new("us_ein");

    public static readonly Type UyRuc = new("uy_ruc");

    public static readonly Type VeRif = new("ve_rif");

    public static readonly Type VnTin = new("vn_tin");

    public static readonly Type ZaVat = new("za_vat");

    readonly string _value = value;

    public enum Value
    {
        AdNrt,
        AeTrn,
        ArCuit,
        EuVat,
        AuAbn,
        AuArn,
        BgUic,
        BhVat,
        BoTin,
        BrCnpj,
        BrCpf,
        CaBn,
        CaGstHst,
        CaPstBc,
        CaPstMB,
        CaPstSk,
        CaQst,
        ChVat,
        ClTin,
        CnTin,
        CoNit,
        CrTin,
        DoRcn,
        EcRuc,
        EgTin,
        EsCif,
        EuOssVat,
        GBVat,
        GeVat,
        HkBr,
        HuTin,
        IDNpwp,
        IlVat,
        InGst,
        IsVat,
        JpCn,
        JpRn,
        JpTrn,
        KePin,
        KrBrn,
        KzBin,
        LiUid,
        MxRfc,
        MyFrp,
        MyItn,
        MySst,
        NgTin,
        NoVat,
        NoVoec,
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
        SvNit,
        ThVat,
        TrTin,
        TwVat,
        UaVat,
        UsEin,
        UyRuc,
        VeRif,
        VnTin,
        ZaVat,
    }

    public Value Known() =>
        _value switch
        {
            "ad_nrt" => Value.AdNrt,
            "ae_trn" => Value.AeTrn,
            "ar_cuit" => Value.ArCuit,
            "eu_vat" => Value.EuVat,
            "au_abn" => Value.AuAbn,
            "au_arn" => Value.AuArn,
            "bg_uic" => Value.BgUic,
            "bh_vat" => Value.BhVat,
            "bo_tin" => Value.BoTin,
            "br_cnpj" => Value.BrCnpj,
            "br_cpf" => Value.BrCpf,
            "ca_bn" => Value.CaBn,
            "ca_gst_hst" => Value.CaGstHst,
            "ca_pst_bc" => Value.CaPstBc,
            "ca_pst_mb" => Value.CaPstMB,
            "ca_pst_sk" => Value.CaPstSk,
            "ca_qst" => Value.CaQst,
            "ch_vat" => Value.ChVat,
            "cl_tin" => Value.ClTin,
            "cn_tin" => Value.CnTin,
            "co_nit" => Value.CoNit,
            "cr_tin" => Value.CrTin,
            "do_rcn" => Value.DoRcn,
            "ec_ruc" => Value.EcRuc,
            "eg_tin" => Value.EgTin,
            "es_cif" => Value.EsCif,
            "eu_oss_vat" => Value.EuOssVat,
            "gb_vat" => Value.GBVat,
            "ge_vat" => Value.GeVat,
            "hk_br" => Value.HkBr,
            "hu_tin" => Value.HuTin,
            "id_npwp" => Value.IDNpwp,
            "il_vat" => Value.IlVat,
            "in_gst" => Value.InGst,
            "is_vat" => Value.IsVat,
            "jp_cn" => Value.JpCn,
            "jp_rn" => Value.JpRn,
            "jp_trn" => Value.JpTrn,
            "ke_pin" => Value.KePin,
            "kr_brn" => Value.KrBrn,
            "kz_bin" => Value.KzBin,
            "li_uid" => Value.LiUid,
            "mx_rfc" => Value.MxRfc,
            "my_frp" => Value.MyFrp,
            "my_itn" => Value.MyItn,
            "my_sst" => Value.MySst,
            "ng_tin" => Value.NgTin,
            "no_vat" => Value.NoVat,
            "no_voec" => Value.NoVoec,
            "nz_gst" => Value.NzGst,
            "om_vat" => Value.OmVat,
            "pe_ruc" => Value.PeRuc,
            "ph_tin" => Value.PhTin,
            "ro_tin" => Value.RoTin,
            "rs_pib" => Value.RsPib,
            "ru_inn" => Value.RuInn,
            "ru_kpp" => Value.RuKpp,
            "sa_vat" => Value.SaVat,
            "sg_gst" => Value.SgGst,
            "sg_uen" => Value.SgUen,
            "si_tin" => Value.SiTin,
            "sv_nit" => Value.SvNit,
            "th_vat" => Value.ThVat,
            "tr_tin" => Value.TrTin,
            "tw_vat" => Value.TwVat,
            "ua_vat" => Value.UaVat,
            "us_ein" => Value.UsEin,
            "uy_ruc" => Value.UyRuc,
            "ve_rif" => Value.VeRif,
            "vn_tin" => Value.VnTin,
            "za_vat" => Value.ZaVat,
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

    public static Type FromRaw(string value)
    {
        return new(value);
    }
}
