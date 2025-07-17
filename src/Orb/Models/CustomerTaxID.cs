using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using CustomerTaxIDProperties = Orb.Models.CustomerTaxIDProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

/// <summary>
/// Tax IDs are commonly required to be displayed on customer invoices, which are
/// added to the headers of invoices.
///
/// ### Supported Tax ID Countries and Types
///
/// | Country        | Type         | Description
/// | |----------------|--------------|---------------------------------------------|
/// | Andorra        | `ad_nrt`     | Andorran NRT Number
/// | | Argentina      | `ar_cuit`    | Argentinian Tax ID Number
///   | | Australia      | `au_abn`     | Australian Business Number (AU ABN)
///            | | Australia      | `au_arn`     | Australian Taxation Office Reference
/// Number | | Austria        | `eu_vat`     | European VAT Number
///           | | Bahrain        | `bh_vat`     | Bahraini VAT Number
///             | | Belgium        | `eu_vat`     | European VAT Number
///                | | Bolivia        | `bo_tin`     | Bolivian Tax ID
///                  | | Brazil         | `br_cnpj`    | Brazilian CNPJ Number
///                     | | Brazil         | `br_cpf`     | Brazilian CPF Number
///                            | | Bulgaria       | `bg_uic`     | Bulgaria Unified
/// Identification Code        | | Bulgaria       | `eu_vat`     | European VAT Number
///                         | | Canada         | `ca_bn`      | Canadian BN
///                            | | Canada         | `ca_gst_hst` | Canadian GST/HST
/// Number                     | | Canada         | `ca_pst_bc`  | Canadian PST Number
/// (British Columbia)      | | Canada         | `ca_pst_mb`  | Canadian PST Number
/// (Manitoba)              | | Canada         | `ca_pst_sk`  | Canadian PST Number
/// (Saskatchewan)          | | Canada         | `ca_qst`     | Canadian QST Number
/// (Québec)                | | Chile          | `cl_tin`     | Chilean TIN
///                            | | China          | `cn_tin`     | Chinese Tax ID
///                              | | Colombia       | `co_nit`     | Colombian NIT
/// Number                        | | Costa Rica     | `cr_tin`     | Costa Rican
/// Tax ID                          | | Croatia        | `eu_vat`     | European
/// VAT Number                         | | Cyprus         | `eu_vat`     | European
/// VAT Number                         | | Czech Republic | `eu_vat`     | European
/// VAT Number                         | | Denmark        | `eu_vat`     | European
/// VAT Number                         | | Dominican Republic | `do_rcn` | Dominican
/// RCN Number                        | | Ecuador        | `ec_ruc`     | Ecuadorian
/// RUC Number                       | | Egypt          | `eg_tin`     | Egyptian
/// Tax Identification Number                 | | El Salvador    | `sv_nit`     |
/// El Salvadorian NIT Number                   | | Estonia   | `eu_vat`     | European
/// VAT Number   | | EU        | `eu_oss_vat` | European One Stop Shop VAT Number
/// for non-Union scheme | | Finland   | `eu_vat`     | European VAT Number
///                              | | France    | `eu_vat`     | European VAT Number
///                                    | | Georgia   | `ge_vat`     | Georgian VAT
///                                           | | Germany   | `eu_vat`     | European
/// VAT Number                                    | | Greece    | `eu_vat`     | European
/// VAT Number                                    | | Hong Kong | `hk_br`      | Hong
/// Kong BR Number                                    | | Hungary   | `eu_vat`
///   | European VAT Number                                    | | Hungary   | `hu_tin`
///     | Hungary Tax Number (adószám)                           | | Iceland   |
/// `is_vat`     | Icelandic VAT                                          | | India
///     | `in_gst`     | Indian GST Number                                      |
/// | Indonesia | `id_npwp`    | Indonesian NPWP Number
///        | | Ireland   | `eu_vat`     | European VAT Number
///                | | Israel    | `il_vat`     | Israel VAT
///                        | | Italy     | `eu_vat`     | European VAT Number
///                                 | | Japan     | `jp_cn`      | Japanese Corporate
/// Number (*Hōjin Bangō*)              | | Japan     | `jp_rn`      | Japanese Registered
/// Foreign Businesses' Registration Number (*Tōroku Kokugai Jigyōsha no Tōroku Bangō*)
///         | | Japan     | `jp_trn`     | Japanese Tax Registration Number (*Tōroku
/// Bangō*)          | | Kazakhstan    | `kz_bin` | Kazakhstani Business Identification
/// Number                 | | Kenya     | `ke_pin`     | Kenya Revenue Authority
/// Personal Identification Number | | Latvia    | `eu_vat`     | European VAT Number
///                                    | | Liechtenstein | `li_uid`  | Liechtensteinian
/// UID Number           | | Lithuania     | `eu_vat`  | European VAT Number
///                 | | Luxembourg    | `eu_vat`  | European VAT Number
///           | | Malaysia      | `my_frp`  | Malaysian FRP Number
///    | | Malaysia      | `my_itn`  | Malaysian ITN                         | |
/// Malaysia      | `my_sst`  | Malaysian SST Number                  | | Malta
///        | `eu_vat ` | European VAT Number                   | | Mexico
/// | `mx_rfc`  | Mexican RFC Number                    | | Netherlands   | `eu_vat`
///  | European VAT Number                     | | New Zealand   | `nz_gst`  | New
/// Zealand GST Number                       | | Nigeria       | `ng_tin`  | Nigerian
/// Tax Identification Number    | | Norway        | `no_vat`  | Norwegian VAT Number
///                  | | Norway        | `no_voec` | Norwegian VAT on e-commerce Number
///    | | Oman          | `om_vat`  | Omani VAT Number                      | | Peru
///          | `pe_ruc`  | Peruvian RUC Number                   | | Philippines
///  | `ph_tin   ` | Philippines Tax Identification Number | | Poland        | `eu_vat`
///  | European VAT Number                   | | Portugal      | `eu_vat`  | European
/// VAT Number                   | | Romania       | `eu_vat`  | European VAT Number
///                   | | Romania       | `ro_tin`  | Romanian Tax ID Number
///            | | Russia        | `ru_inn`  | Russian INN
///     | | Russia        | `ru_kpp`  | Russian KPP                           | |
/// Saudi Arabia  | `sa_vat`  | Saudi Arabia VAT                      | | Serbia
///       | `rs_pib`  | Serbian PIB Number                    | | Singapore     |
/// `sg_gst`  | Singaporean GST                       | | Singapore     | `sg_uen`
///  | Singaporean UEN                             | | Slovakia      | `eu_vat`
/// | European VAT Number                   | | Slovenia      | `eu_vat`  | European
/// VAT Number                   | | Slovenia             | `si_tin` | Slovenia Tax
/// Number (davčna številka)                | | South Africa              | `za_vat`
/// | South African VAT Number                           | | South Korea
/// | `kr_brn` | Korean BRN                                         | | Spain
///            | `es_cif` | Spanish NIF Number (previously Spanish CIF Number) |
/// | Spain                | `eu_vat` | European VAT Number
///               | | Sweden               | `eu_vat` | European VAT Number
///                          | | Switzerland          | `ch_vat` | Switzerland VAT
/// Number                              | | Taiwan               | `tw_vat` | Taiwanese
/// VAT                                        | | Thailand             | `th_vat`
/// | Thai VAT                                           | | Turkey
/// | `tr_tin` | Turkish Tax Identification Number                  | | Ukraine
///            | `ua_vat` | Ukrainian VAT                                      | |
/// United Arab Emirates | `ae_trn` | United Arab Emirates TRN
///                | | United Kingdom       | `eu_vat` | Northern Ireland VAT Number
///                        | | United Kingdom       | `gb_vat` | United Kingdom VAT
/// Number                          | | United States        | `us_ein` | United
/// States EIN                                  | | Uruguay              | `uy_ruc`
/// | Uruguayan RUC Number                               | | Venezuela
///  | `ve_rif` | Venezuelan RIF Number                              | | Vietnam
///             | `vn_tin` | Vietnamese Tax ID Number                           |
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<CustomerTaxID>))]
public sealed record class CustomerTaxID : Orb::ModelBase, Orb::IFromRaw<CustomerTaxID>
{
    public required CustomerTaxIDProperties::Country Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "country",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CustomerTaxIDProperties::Country>(element)
                ?? throw new System::ArgumentNullException("country");
        }
        set { this.Properties["country"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required CustomerTaxIDProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<CustomerTaxIDProperties::Type>(element)
                ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("value", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("value");
        }
        set { this.Properties["value"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Country.Validate();
        this.Type.Validate();
        _ = this.Value;
    }

    public CustomerTaxID() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    CustomerTaxID(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomerTaxID FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
