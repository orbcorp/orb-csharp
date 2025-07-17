using CustomerCreateParamsProperties = Orb.Models.Customers.CustomerCreateParamsProperties;
using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Customers;

/// <summary>
/// This operation is used to create an Orb customer, who is party to the core billing
/// relationship. See [Customer](/core-concepts##customer) for an overview of the
/// customer resource.
///
/// This endpoint is critical in the following Orb functionality: * Automated charges
/// can be configured by setting `payment_provider` and `payment_provider_id` to
/// automatically   issue invoices * [Customer ID Aliases](/events-and-metrics/customer-aliases)
/// can be configured by setting   `external_customer_id` * [Timezone localization](/essentials/timezones)
/// can be configured on a per-customer basis by   setting the `timezone` parameter
/// </summary>
public sealed record class CustomerCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// A valid customer email, to be used for notifications. When Orb triggers payment
    /// through a payment gateway, this email will be used for any automatically issued receipts.
    /// </summary>
    public required string Email
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("email", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("email", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("email");
        }
        set { this.BodyProperties["email"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The full name of the customer
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.BodyProperties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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
    /// An optional user-defined ID for this customer resource, used throughout the
    /// system as an alias for this Customer. Use this field to identify a customer
    /// by an existing identifier in your system.
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
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode, the connection must first be configured in the Orb webapp.
    /// </summary>
    public CustomerCreateParamsProperties::PaymentProvider? PaymentProvider
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("payment_provider", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<CustomerCreateParamsProperties::PaymentProvider?>(
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

    public CustomerCreateParamsProperties::TaxConfiguration? TaxConfiguration
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("tax_configuration", out Json::JsonElement element)
            )
                return null;

            return Json::JsonSerializer.Deserialize<CustomerCreateParamsProperties::TaxConfiguration?>(
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
    /// | Country        | Type         | Description
    ///   | |----------------|--------------|---------------------------------------------|
    /// | Andorra        | `ad_nrt`     | Andorran NRT Number
    ///   | | Argentina      | `ar_cuit`    | Argentinian Tax ID Number
    ///       | | Australia      | `au_abn`     | Australian Business Number (AU ABN)
    ///               | | Australia      | `au_arn`     | Australian Taxation Office
    /// Reference Number | | Austria        | `eu_vat`     | European VAT Number
    ///                       | | Bahrain        | `bh_vat`     | Bahraini VAT Number
    ///                         | | Belgium        | `eu_vat`     | European VAT Number
    ///                         | | Bolivia        | `bo_tin`     | Bolivian Tax ID
    ///                             | | Brazil         | `br_cnpj`    | Brazilian CNPJ
    /// Number                       | | Brazil         | `br_cpf`     | Brazilian CPF
    /// Number                             | | Bulgaria       | `bg_uic`     | Bulgaria
    /// Unified Identification Code        | | Bulgaria       | `eu_vat`     | European
    /// VAT Number                         | | Canada         | `ca_bn`      | Canadian
    /// BN                                 | | Canada         | `ca_gst_hst` | Canadian
    /// GST/HST Number                     | | Canada         | `ca_pst_bc`  | Canadian
    /// PST Number (British Columbia)      | | Canada         | `ca_pst_mb`  | Canadian
    /// PST Number (Manitoba)              | | Canada         | `ca_pst_sk`  | Canadian
    /// PST Number (Saskatchewan)          | | Canada         | `ca_qst`     | Canadian
    /// QST Number (Québec)                | | Chile          | `cl_tin`     | Chilean
    /// TIN                                 | | China          | `cn_tin`     | Chinese
    /// Tax ID                              | | Colombia       | `co_nit`     | Colombian
    /// NIT Number                        | | Costa Rica     | `cr_tin`     | Costa
    /// Rican Tax ID                          | | Croatia        | `eu_vat`     | European
    /// VAT Number                         | | Cyprus         | `eu_vat`     | European
    /// VAT Number                         | | Czech Republic | `eu_vat`     | European
    /// VAT Number                         | | Denmark        | `eu_vat`     | European
    /// VAT Number                         | | Dominican Republic | `do_rcn` | Dominican
    /// RCN Number                        | | Ecuador        | `ec_ruc`     | Ecuadorian
    /// RUC Number                       | | Egypt          | `eg_tin`     | Egyptian
    /// Tax Identification Number                 | | El Salvador    | `sv_nit`
    /// | El Salvadorian NIT Number                   | | Estonia   | `eu_vat`     |
    /// European VAT Number   | | EU        | `eu_oss_vat` | European One Stop Shop
    /// VAT Number for non-Union scheme | | Finland   | `eu_vat`     | European VAT
    /// Number                                    | | France    | `eu_vat`     | European
    /// VAT Number                                    | | Georgia   | `ge_vat`     |
    /// Georgian VAT                                           | | Germany   | `eu_vat`
    ///     | European VAT Number                                    | | Greece
    /// | `eu_vat`     | European VAT Number                                    | |
    /// Hong Kong | `hk_br`      | Hong Kong BR Number
    ///       | | Hungary   | `eu_vat`     | European VAT Number
    ///                  | | Hungary   | `hu_tin`     | Hungary Tax Number (adószám)
    ///                           | | Iceland   | `is_vat`     | Icelandic VAT
    ///                                      | | India     | `in_gst`     | Indian GST
    /// Number                                      | | Indonesia | `id_npwp`    | Indonesian
    /// NPWP Number                                 | | Ireland   | `eu_vat`     |
    /// European VAT Number                                    | | Israel    | `il_vat`
    ///     | Israel VAT                                             | | Italy
    /// | `eu_vat`     | European VAT Number                                    | |
    /// Japan     | `jp_cn`      | Japanese Corporate Number (*Hōjin Bangō*)
    ///       | | Japan     | `jp_rn`      | Japanese Registered Foreign Businesses'
    /// Registration Number (*Tōroku Kokugai Jigyōsha no Tōroku Bangō*)         | |
    /// Japan     | `jp_trn`     | Japanese Tax Registration Number (*Tōroku Bangō*)
    ///          | | Kazakhstan    | `kz_bin` | Kazakhstani Business Identification
    /// Number                 | | Kenya     | `ke_pin`     | Kenya Revenue Authority
    /// Personal Identification Number | | Latvia    | `eu_vat`     | European VAT Number
    ///                                    | | Liechtenstein | `li_uid`  | Liechtensteinian
    /// UID Number           | | Lithuania     | `eu_vat`  | European VAT Number
    ///                   | | Luxembourg    | `eu_vat`  | European VAT Number
    ///               | | Malaysia      | `my_frp`  | Malaysian FRP Number
    ///          | | Malaysia      | `my_itn`  | Malaysian ITN
    ///     | | Malaysia      | `my_sst`  | Malaysian SST Number                  |
    /// | Malta         | `eu_vat ` | European VAT Number                   | | Mexico
    ///        | `mx_rfc`  | Mexican RFC Number                    | | Netherlands
    ///  | `eu_vat`  | European VAT Number                     | | New Zealand   |
    /// `nz_gst`  | New Zealand GST Number                       | | Nigeria       |
    /// `ng_tin`  | Nigerian Tax Identification Number    | | Norway        | `no_vat`
    ///  | Norwegian VAT Number                  | | Norway        | `no_voec` | Norwegian
    /// VAT on e-commerce Number    | | Oman          | `om_vat`  | Omani VAT Number
    ///                      | | Peru          | `pe_ruc`  | Peruvian RUC Number
    ///                 | | Philippines   | `ph_tin   ` | Philippines Tax Identification
    /// Number | | Poland        | `eu_vat`  | European VAT Number
    ///   | | Portugal      | `eu_vat`  | European VAT Number                   | |
    /// Romania       | `eu_vat`  | European VAT Number                   | | Romania
    ///       | `ro_tin`  | Romanian Tax ID Number                | | Russia
    /// | `ru_inn`  | Russian INN                           | | Russia        | `ru_kpp`
    ///  | Russian KPP                           | | Saudi Arabia  | `sa_vat`  | Saudi
    /// Arabia VAT                      | | Serbia        | `rs_pib`  | Serbian PIB
    /// Number                    | | Singapore     | `sg_gst`  | Singaporean GST
    ///                     | | Singapore     | `sg_uen`  | Singaporean UEN
    ///                     | | Slovakia      | `eu_vat`  | European VAT Number
    ///                | | Slovenia      | `eu_vat`  | European VAT Number
    ///          | | Slovenia             | `si_tin` | Slovenia Tax Number (davčna številka)
    ///                | | South Africa              | `za_vat` | South African VAT
    /// Number                           | | South Korea          | `kr_brn` | Korean
    /// BRN                                         | | Spain                | `es_cif`
    /// | Spanish NIF Number (previously Spanish CIF Number) | | Spain
    ///    | `eu_vat` | European VAT Number                                    | |
    /// Sweden               | `eu_vat` | European VAT Number
    ///          | | Switzerland          | `ch_vat` | Switzerland VAT Number
    ///                         | | Taiwan               | `tw_vat` | Taiwanese VAT
    ///                                        | | Thailand             | `th_vat` |
    /// Thai VAT                                           | | Turkey
    /// | `tr_tin` | Turkish Tax Identification Number                  | | Ukraine
    ///              | `ua_vat` | Ukrainian VAT
    ///   | | United Arab Emirates | `ae_trn` | United Arab Emirates TRN
    ///                        | | United Kingdom       | `eu_vat` | Northern Ireland
    /// VAT Number                        | | United Kingdom       | `gb_vat` | United
    /// Kingdom VAT Number                          | | United States        | `us_ein`
    /// | United States EIN                                  | | Uruguay
    ///   | `uy_ruc` | Uruguayan RUC Number                               | | Venezuela
    ///            | `ve_rif` | Venezuelan RIF Number
    /// | | Vietnam              | `vn_tin` | Vietnamese Tax ID Number
    ///               |
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

    /// <summary>
    /// A timezone identifier from the IANA timezone database, such as `"America/Los_Angeles"`.
    /// This defaults to your account's timezone if not set. This cannot be changed
    /// after customer creation.
    /// </summary>
    public string? Timezone
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("timezone", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["timezone"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/customers")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new Http::StringContent(
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
