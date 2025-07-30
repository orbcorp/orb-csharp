using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CustomerTaxIDProperties;

[JsonConverter(typeof(EnumConverter<Type, string>))]
public sealed record class Type(string value) : IEnum<Type, string>
{
    public static readonly Type AdNrt = new("ad_nrt");

    public static readonly Type AeTrn = new("ae_trn");

    public static readonly Type AlTin = new("al_tin");

    public static readonly Type AmTin = new("am_tin");

    public static readonly Type AoTin = new("ao_tin");

    public static readonly Type ArCuit = new("ar_cuit");

    public static readonly Type EuVat = new("eu_vat");

    public static readonly Type AuAbn = new("au_abn");

    public static readonly Type AuArn = new("au_arn");

    public static readonly Type AwTin = new("aw_tin");

    public static readonly Type AzTin = new("az_tin");

    public static readonly Type BaTin = new("ba_tin");

    public static readonly Type BbTin = new("bb_tin");

    public static readonly Type BdBin = new("bd_bin");

    public static readonly Type BfIfu = new("bf_ifu");

    public static readonly Type BgUic = new("bg_uic");

    public static readonly Type BhVat = new("bh_vat");

    public static readonly Type BjIfu = new("bj_ifu");

    public static readonly Type BoTin = new("bo_tin");

    public static readonly Type BrCnpj = new("br_cnpj");

    public static readonly Type BrCpf = new("br_cpf");

    public static readonly Type BsTin = new("bs_tin");

    public static readonly Type ByTin = new("by_tin");

    public static readonly Type CaBn = new("ca_bn");

    public static readonly Type CaGstHst = new("ca_gst_hst");

    public static readonly Type CaPstBc = new("ca_pst_bc");

    public static readonly Type CaPstMB = new("ca_pst_mb");

    public static readonly Type CaPstSk = new("ca_pst_sk");

    public static readonly Type CaQst = new("ca_qst");

    public static readonly Type CdNif = new("cd_nif");

    public static readonly Type ChUid = new("ch_uid");

    public static readonly Type ChVat = new("ch_vat");

    public static readonly Type ClTin = new("cl_tin");

    public static readonly Type CmNiu = new("cm_niu");

    public static readonly Type CnTin = new("cn_tin");

    public static readonly Type CoNit = new("co_nit");

    public static readonly Type CrTin = new("cr_tin");

    public static readonly Type CvNif = new("cv_nif");

    public static readonly Type DeStn = new("de_stn");

    public static readonly Type DoRcn = new("do_rcn");

    public static readonly Type EcRuc = new("ec_ruc");

    public static readonly Type EgTin = new("eg_tin");

    public static readonly Type EsCif = new("es_cif");

    public static readonly Type EtTin = new("et_tin");

    public static readonly Type EuOssVat = new("eu_oss_vat");

    public static readonly Type GBVat = new("gb_vat");

    public static readonly Type GeVat = new("ge_vat");

    public static readonly Type GnNif = new("gn_nif");

    public static readonly Type HkBr = new("hk_br");

    public static readonly Type HrOib = new("hr_oib");

    public static readonly Type HuTin = new("hu_tin");

    public static readonly Type IDNpwp = new("id_npwp");

    public static readonly Type IlVat = new("il_vat");

    public static readonly Type InGst = new("in_gst");

    public static readonly Type IsVat = new("is_vat");

    public static readonly Type JpCn = new("jp_cn");

    public static readonly Type JpRn = new("jp_rn");

    public static readonly Type JpTrn = new("jp_trn");

    public static readonly Type KePin = new("ke_pin");

    public static readonly Type KgTin = new("kg_tin");

    public static readonly Type KhTin = new("kh_tin");

    public static readonly Type KrBrn = new("kr_brn");

    public static readonly Type KzBin = new("kz_bin");

    public static readonly Type LaTin = new("la_tin");

    public static readonly Type LiUid = new("li_uid");

    public static readonly Type LiVat = new("li_vat");

    public static readonly Type MaVat = new("ma_vat");

    public static readonly Type MdVat = new("md_vat");

    public static readonly Type MePib = new("me_pib");

    public static readonly Type MkVat = new("mk_vat");

    public static readonly Type MrNif = new("mr_nif");

    public static readonly Type MxRfc = new("mx_rfc");

    public static readonly Type MyFrp = new("my_frp");

    public static readonly Type MyItn = new("my_itn");

    public static readonly Type MySst = new("my_sst");

    public static readonly Type NgTin = new("ng_tin");

    public static readonly Type NoVat = new("no_vat");

    public static readonly Type NoVoec = new("no_voec");

    public static readonly Type NpPan = new("np_pan");

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

    public static readonly Type SnNinea = new("sn_ninea");

    public static readonly Type SrFin = new("sr_fin");

    public static readonly Type SvNit = new("sv_nit");

    public static readonly Type ThVat = new("th_vat");

    public static readonly Type TjTin = new("tj_tin");

    public static readonly Type TrTin = new("tr_tin");

    public static readonly Type TwVat = new("tw_vat");

    public static readonly Type TzVat = new("tz_vat");

    public static readonly Type UaVat = new("ua_vat");

    public static readonly Type UgTin = new("ug_tin");

    public static readonly Type UsEin = new("us_ein");

    public static readonly Type UyRuc = new("uy_ruc");

    public static readonly Type UzTin = new("uz_tin");

    public static readonly Type UzVat = new("uz_vat");

    public static readonly Type VeRif = new("ve_rif");

    public static readonly Type VnTin = new("vn_tin");

    public static readonly Type ZaVat = new("za_vat");

    public static readonly Type ZmTin = new("zm_tin");

    public static readonly Type ZwTin = new("zw_tin");

    readonly string _value = value;

    public enum Value
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

    public Value Known() =>
        _value switch
        {
            "ad_nrt" => Value.AdNrt,
            "ae_trn" => Value.AeTrn,
            "al_tin" => Value.AlTin,
            "am_tin" => Value.AmTin,
            "ao_tin" => Value.AoTin,
            "ar_cuit" => Value.ArCuit,
            "eu_vat" => Value.EuVat,
            "au_abn" => Value.AuAbn,
            "au_arn" => Value.AuArn,
            "aw_tin" => Value.AwTin,
            "az_tin" => Value.AzTin,
            "ba_tin" => Value.BaTin,
            "bb_tin" => Value.BbTin,
            "bd_bin" => Value.BdBin,
            "bf_ifu" => Value.BfIfu,
            "bg_uic" => Value.BgUic,
            "bh_vat" => Value.BhVat,
            "bj_ifu" => Value.BjIfu,
            "bo_tin" => Value.BoTin,
            "br_cnpj" => Value.BrCnpj,
            "br_cpf" => Value.BrCpf,
            "bs_tin" => Value.BsTin,
            "by_tin" => Value.ByTin,
            "ca_bn" => Value.CaBn,
            "ca_gst_hst" => Value.CaGstHst,
            "ca_pst_bc" => Value.CaPstBc,
            "ca_pst_mb" => Value.CaPstMB,
            "ca_pst_sk" => Value.CaPstSk,
            "ca_qst" => Value.CaQst,
            "cd_nif" => Value.CdNif,
            "ch_uid" => Value.ChUid,
            "ch_vat" => Value.ChVat,
            "cl_tin" => Value.ClTin,
            "cm_niu" => Value.CmNiu,
            "cn_tin" => Value.CnTin,
            "co_nit" => Value.CoNit,
            "cr_tin" => Value.CrTin,
            "cv_nif" => Value.CvNif,
            "de_stn" => Value.DeStn,
            "do_rcn" => Value.DoRcn,
            "ec_ruc" => Value.EcRuc,
            "eg_tin" => Value.EgTin,
            "es_cif" => Value.EsCif,
            "et_tin" => Value.EtTin,
            "eu_oss_vat" => Value.EuOssVat,
            "gb_vat" => Value.GBVat,
            "ge_vat" => Value.GeVat,
            "gn_nif" => Value.GnNif,
            "hk_br" => Value.HkBr,
            "hr_oib" => Value.HrOib,
            "hu_tin" => Value.HuTin,
            "id_npwp" => Value.IDNpwp,
            "il_vat" => Value.IlVat,
            "in_gst" => Value.InGst,
            "is_vat" => Value.IsVat,
            "jp_cn" => Value.JpCn,
            "jp_rn" => Value.JpRn,
            "jp_trn" => Value.JpTrn,
            "ke_pin" => Value.KePin,
            "kg_tin" => Value.KgTin,
            "kh_tin" => Value.KhTin,
            "kr_brn" => Value.KrBrn,
            "kz_bin" => Value.KzBin,
            "la_tin" => Value.LaTin,
            "li_uid" => Value.LiUid,
            "li_vat" => Value.LiVat,
            "ma_vat" => Value.MaVat,
            "md_vat" => Value.MdVat,
            "me_pib" => Value.MePib,
            "mk_vat" => Value.MkVat,
            "mr_nif" => Value.MrNif,
            "mx_rfc" => Value.MxRfc,
            "my_frp" => Value.MyFrp,
            "my_itn" => Value.MyItn,
            "my_sst" => Value.MySst,
            "ng_tin" => Value.NgTin,
            "no_vat" => Value.NoVat,
            "no_voec" => Value.NoVoec,
            "np_pan" => Value.NpPan,
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
            "sn_ninea" => Value.SnNinea,
            "sr_fin" => Value.SrFin,
            "sv_nit" => Value.SvNit,
            "th_vat" => Value.ThVat,
            "tj_tin" => Value.TjTin,
            "tr_tin" => Value.TrTin,
            "tw_vat" => Value.TwVat,
            "tz_vat" => Value.TzVat,
            "ua_vat" => Value.UaVat,
            "ug_tin" => Value.UgTin,
            "us_ein" => Value.UsEin,
            "uy_ruc" => Value.UyRuc,
            "uz_tin" => Value.UzTin,
            "uz_vat" => Value.UzVat,
            "ve_rif" => Value.VeRif,
            "vn_tin" => Value.VnTin,
            "za_vat" => Value.ZaVat,
            "zm_tin" => Value.ZmTin,
            "zw_tin" => Value.ZwTin,
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
