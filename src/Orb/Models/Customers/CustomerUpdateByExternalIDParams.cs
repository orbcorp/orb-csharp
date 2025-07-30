using CustomerUpdateByExternalIDParamsProperties = Orb.Models.Customers.CustomerUpdateByExternalIDParamsProperties;
using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Customers;

/// <summary>
/// This endpoint is used to update customer details given an `external_customer_id`
/// (see [Customer ID Aliases](/events-and-metrics/customer-aliases)). Note that
/// the resource and semantics of this endpoint exactly mirror [Update Customer](update-customer).
/// </summary>
public sealed record class CustomerUpdateByExternalIDParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    public NewAccountingSyncConfiguration? AccountingSyncConfiguration
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "accounting_sync_configuration",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<NewAccountingSyncConfiguration?>(element);
        }
        set
        {
            this.BodyProperties["accounting_sync_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Additional email addresses for this customer. If populated, these email addresses
    /// will be CC'd for customer communications.
    /// </summary>
    public Generic::List<string>? AdditionalEmails
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("additional_emails", out Json::JsonElement element)
            )
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set
        {
            this.BodyProperties["additional_emails"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Used to determine if invoices for this customer will automatically attempt
    /// to charge a saved payment method, if available. This parameter defaults to
    /// `True` when a payment provider is provided on customer creation.
    /// </summary>
    public bool? AutoCollection
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("auto_collection", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["auto_collection"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public AddressInput? BillingAddress
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("billing_address", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<AddressInput?>(element);
        }
        set
        {
            this.BodyProperties["billing_address"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// An ISO 4217 currency string used for the customer's invoices and balance. If
    /// not set at creation time, will be set at subscription creation time.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A valid customer email, to be used for invoicing and notifications.
    /// </summary>
    public string? Email
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("email", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["email"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public bool? EmailDelivery
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("email_delivery", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["email_delivery"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The external customer ID. This can only be set if the customer has no existing
    /// external customer ID. Since this action may change usage quantities for all
    /// existing subscriptions, it is disallowed if the customer has issued invoices
    /// with usage line items and subject to the same restrictions as backdated subscription creation.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "external_customer_id",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["external_customer_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The hierarchical relationships for this customer.
    /// </summary>
    public CustomerHierarchyConfig? Hierarchy
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("hierarchy", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<CustomerHierarchyConfig?>(element);
        }
        set { this.BodyProperties["hierarchy"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Generic::Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string?>?>(element);
        }
        set { this.BodyProperties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The full name of the customer
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode: - the connection must first be configured in the Orb
    /// webapp.  - if the provider is an invoicing provider (`stripe_invoice`, `quickbooks`,
    /// `bill.com`, `netsuite`), any product mappings must first be configured with
    /// the Orb team.
    /// </summary>
    public CustomerUpdateByExternalIDParamsProperties::PaymentProvider? PaymentProvider
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("payment_provider", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsProperties::PaymentProvider?>(
                element
            );
        }
        set
        {
            this.BodyProperties["payment_provider"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The ID of this customer in an external payments solution, such as Stripe. This
    /// is used for creating charges or invoices in the external system via Orb.
    /// </summary>
    public string? PaymentProviderID
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "payment_provider_id",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.BodyProperties["payment_provider_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public NewReportingConfiguration? ReportingConfiguration
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "reporting_configuration",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<NewReportingConfiguration?>(element);
        }
        set
        {
            this.BodyProperties["reporting_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public AddressInput? ShippingAddress
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("shipping_address", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<AddressInput?>(element);
        }
        set
        {
            this.BodyProperties["shipping_address"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public CustomerUpdateByExternalIDParamsProperties::TaxConfiguration? TaxConfiguration
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("tax_configuration", out Json::JsonElement element)
            )
                return null;

            return Json::JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsProperties::TaxConfiguration?>(
                element
            );
        }
        set
        {
            this.BodyProperties["tax_configuration"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// Tax IDs are commonly required to be displayed on customer invoices, which are
    /// added to the headers of invoices.
    ///
    /// ### Supported Tax ID Countries and Types
    ///
    /// | Country | Type | Description | |---------|------|-------------| | Albania
    /// | `al_tin` | Albania Tax Identification Number | | Andorra | `ad_nrt` | Andorran
    /// NRT Number | | Angola | `ao_tin` | Angola Tax Identification Number | | Argentina
    /// | `ar_cuit` | Argentinian Tax ID Number | | Armenia | `am_tin` | Armenia Tax
    /// Identification Number | | Aruba | `aw_tin` | Aruba Tax Identification Number
    /// | | Australia | `au_abn` | Australian Business Number (AU ABN) | | Australia
    /// | `au_arn` | Australian Taxation Office Reference Number | | Austria | `eu_vat`
    /// | European VAT Number | | Azerbaijan | `az_tin` | Azerbaijan Tax Identification
    /// Number | | Bahamas | `bs_tin` | Bahamas Tax Identification Number | | Bahrain
    /// | `bh_vat` | Bahraini VAT Number | | Bangladesh | `bd_bin` | Bangladesh Business
    /// Identification Number | | Barbados | `bb_tin` | Barbados Tax Identification
    /// Number | | Belarus | `by_tin` | Belarus TIN Number | | Belgium | `eu_vat` |
    /// European VAT Number | | Benin | `bj_ifu` | Benin Tax Identification Number (Identifiant
    /// Fiscal Unique) | | Bolivia | `bo_tin` | Bolivian Tax ID | | Bosnia and Herzegovina
    /// | `ba_tin` | Bosnia and Herzegovina Tax Identification Number | | Brazil | `br_cnpj`
    /// | Brazilian CNPJ Number | | Brazil | `br_cpf` | Brazilian CPF Number | | Bulgaria
    /// | `bg_uic` | Bulgaria Unified Identification Code | | Bulgaria | `eu_vat` |
    /// European VAT Number | | Burkina Faso | `bf_ifu` | Burkina Faso Tax Identification
    /// Number (Numéro d'Identifiant Fiscal Unique) | | Cambodia | `kh_tin` | Cambodia
    /// Tax Identification Number | | Cameroon | `cm_niu` | Cameroon Tax Identification
    /// Number (Numéro d'Identifiant fiscal Unique) | | Canada | `ca_bn` | Canadian
    /// BN | | Canada | `ca_gst_hst` | Canadian GST/HST Number | | Canada | `ca_pst_bc`
    /// | Canadian PST Number (British Columbia) | | Canada | `ca_pst_mb` | Canadian
    /// PST Number (Manitoba) | | Canada | `ca_pst_sk` | Canadian PST Number (Saskatchewan)
    /// | | Canada | `ca_qst` | Canadian QST Number (Québec) | | Cape Verde | `cv_nif`
    /// | Cape Verde Tax Identification Number (Número de Identificação Fiscal) | |
    /// Chile | `cl_tin` | Chilean TIN | | China | `cn_tin` | Chinese Tax ID | | Colombia
    /// | `co_nit` | Colombian NIT Number | | Congo-Kinshasa | `cd_nif` | Congo (DR)
    /// Tax Identification Number (Número de Identificação Fiscal) | | Costa Rica |
    /// `cr_tin` | Costa Rican Tax ID | | Croatia | `eu_vat` | European VAT Number |
    /// | Croatia | `hr_oib` | Croatian Personal Identification Number (OIB) | | Cyprus
    /// | `eu_vat` | European VAT Number | | Czech Republic | `eu_vat` | European VAT
    /// Number | | Denmark | `eu_vat` | European VAT Number | | Dominican Republic
    /// | `do_rcn` | Dominican RCN Number | | Ecuador | `ec_ruc` | Ecuadorian RUC Number
    /// | | Egypt | `eg_tin` | Egyptian Tax Identification Number | | El Salvador |
    /// `sv_nit` | El Salvadorian NIT Number | | Estonia | `eu_vat` | European VAT
    /// Number | | Ethiopia | `et_tin` | Ethiopia Tax Identification Number | | European
    /// Union | `eu_oss_vat` | European One Stop Shop VAT Number for non-Union scheme
    /// | | Finland | `eu_vat` | European VAT Number | | France | `eu_vat` | European
    /// VAT Number | | Georgia | `ge_vat` | Georgian VAT | | Germany | `de_stn` | German
    /// Tax Number (Steuernummer) | | Germany | `eu_vat` | European VAT Number | |
    /// Greece | `eu_vat` | European VAT Number | | Guinea | `gn_nif` | Guinea Tax Identification
    /// Number (Número de Identificação Fiscal) | | Hong Kong | `hk_br` | Hong Kong
    /// BR Number | | Hungary | `eu_vat` | European VAT Number | | Hungary | `hu_tin`
    /// | Hungary Tax Number (adószám) | | Iceland | `is_vat` | Icelandic VAT | | India
    /// | `in_gst` | Indian GST Number | | Indonesia | `id_npwp` | Indonesian NPWP
    /// Number | | Ireland | `eu_vat` | European VAT Number | | Israel | `il_vat` |
    /// Israel VAT | | Italy | `eu_vat` | European VAT Number | | Japan | `jp_cn` |
    /// Japanese Corporate Number (*Hōjin Bangō*) | | Japan | `jp_rn` | Japanese Registered
    /// Foreign Businesses' Registration Number (*Tōroku Kokugai Jigyōsha no Tōroku
    /// Bangō*) | | Japan | `jp_trn` | Japanese Tax Registration Number (*Tōroku Bangō*)
    /// | | Kazakhstan | `kz_bin` | Kazakhstani Business Identification Number | |
    /// Kenya | `ke_pin` | Kenya Revenue Authority Personal Identification Number |
    /// | Kyrgyzstan | `kg_tin` | Kyrgyzstan Tax Identification Number | | Laos | `la_tin`
    /// | Laos Tax Identification Number | | Latvia | `eu_vat` | European VAT Number
    /// | | Liechtenstein | `li_uid` | Liechtensteinian UID Number | | Liechtenstein
    /// | `li_vat` | Liechtenstein VAT Number | | Lithuania | `eu_vat` | European VAT
    /// Number | | Luxembourg | `eu_vat` | European VAT Number | | Malaysia | `my_frp`
    /// | Malaysian FRP Number | | Malaysia | `my_itn` | Malaysian ITN | | Malaysia
    /// | `my_sst` | Malaysian SST Number | | Malta | `eu_vat` | European VAT Number
    /// | | Mauritania | `mr_nif` | Mauritania Tax Identification Number (Número de
    /// Identificação Fiscal) | | Mexico | `mx_rfc` | Mexican RFC Number | | Moldova
    /// | `md_vat` | Moldova VAT Number | | Montenegro | `me_pib` | Montenegro PIB
    /// Number | | Morocco | `ma_vat` | Morocco VAT Number | | Nepal | `np_pan` | Nepal
    /// PAN Number | | Netherlands | `eu_vat` | European VAT Number | | New Zealand
    /// | `nz_gst` | New Zealand GST Number | | Nigeria | `ng_tin` | Nigerian Tax Identification
    /// Number | | North Macedonia | `mk_vat` | North Macedonia VAT Number | | Northern
    /// Ireland | `eu_vat` | Northern Ireland VAT Number | | Norway | `no_vat` | Norwegian
    /// VAT Number | | Norway | `no_voec` | Norwegian VAT on e-commerce Number | | Oman
    /// | `om_vat` | Omani VAT Number | | Peru | `pe_ruc` | Peruvian RUC Number | |
    /// Philippines | `ph_tin` | Philippines Tax Identification Number | | Poland |
    /// `eu_vat` | European VAT Number | | Portugal | `eu_vat` | European VAT Number
    /// | | Romania | `eu_vat` | European VAT Number | | Romania | `ro_tin` | Romanian
    /// Tax ID Number | | Russia | `ru_inn` | Russian INN | | Russia | `ru_kpp` | Russian
    /// KPP | | Saudi Arabia | `sa_vat` | Saudi Arabia VAT | | Senegal | `sn_ninea`
    /// | Senegal NINEA Number | | Serbia | `rs_pib` | Serbian PIB Number | | Singapore
    /// | `sg_gst` | Singaporean GST | | Singapore | `sg_uen` | Singaporean UEN | |
    /// Slovakia | `eu_vat` | European VAT Number | | Slovenia | `eu_vat` | European
    /// VAT Number | | Slovenia | `si_tin` | Slovenia Tax Number (davčna številka) |
    /// | South Africa | `za_vat` | South African VAT Number | | South Korea | `kr_brn`
    /// | Korean BRN | | Spain | `es_cif` | Spanish NIF Number (previously Spanish
    /// CIF Number) | | Spain | `eu_vat` | European VAT Number | | Suriname | `sr_fin`
    /// | Suriname FIN Number | | Sweden | `eu_vat` | European VAT Number | | Switzerland
    /// | `ch_uid` | Switzerland UID Number | | Switzerland | `ch_vat` | Switzerland
    /// VAT Number | | Taiwan | `tw_vat` | Taiwanese VAT | | Tajikistan | `tj_tin`
    /// | Tajikistan Tax Identification Number | | Tanzania | `tz_vat` | Tanzania VAT
    /// Number | | Thailand | `th_vat` | Thai VAT | | Turkey | `tr_tin` | Turkish Tax
    /// Identification Number | | Uganda | `ug_tin` | Uganda Tax Identification Number
    /// | | Ukraine | `ua_vat` | Ukrainian VAT | | United Arab Emirates | `ae_trn` |
    /// United Arab Emirates TRN | | United Kingdom | `gb_vat` | United Kingdom VAT
    /// Number | | United States | `us_ein` | United States EIN | | Uruguay | `uy_ruc`
    /// | Uruguayan RUC Number | | Uzbekistan | `uz_tin` | Uzbekistan TIN Number |
    /// | Uzbekistan | `uz_vat` | Uzbekistan VAT Number | | Venezuela | `ve_rif` |
    /// Venezuelan RIF Number | | Vietnam | `vn_tin` | Vietnamese Tax ID Number | |
    /// Zambia | `zm_tin` | Zambia Tax Identification Number | | Zimbabwe | `zw_tin`
    /// | Zimbabwe Tax Identification Number |
    /// </summary>
    public Models::CustomerTaxID? TaxID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tax_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Models::CustomerTaxID?>(element);
        }
        set { this.BodyProperties["tax_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/external_customer_id/{0}", this.ID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
