using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using CustomerProperties = Orb.Models.Customers.CustomerProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers;

/// <summary>
/// A customer is a buyer of your products, and the other party to the billing relationship.
///
/// In Orb, customers are assigned system generated identifiers automatically, but
/// it's often desirable to have these match existing identifiers in your system.
/// To avoid having to denormalize Orb ID information, you can pass in an `external_customer_id`
/// with your own identifier. See [Customer ID Aliases](/events-and-metrics/customer-aliases)
/// for further information about how these aliases work in Orb.
///
/// In addition to having an identifier in your system, a customer may exist in a
/// payment provider solution like Stripe. Use the `payment_provider_id` and the
/// `payment_provider` enum field to express this mapping.
///
/// A customer also has a timezone (from the standard [IANA timezone database](https://www.iana.org/time-zones)),
/// which defaults to your account's timezone. See [Timezone localization](/essentials/timezones)
/// for information on what this timezone parameter influences within Orb.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Customer>))]
public sealed record class Customer : Orb::ModelBase, Orb::IFromRaw<Customer>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Generic::List<string> AdditionalEmails
    {
        get
        {
            if (!this.Properties.TryGetValue("additional_emails", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "additional_emails",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("additional_emails");
        }
        set
        {
            this.Properties["additional_emails"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required bool AutoCollection
    {
        get
        {
            if (!this.Properties.TryGetValue("auto_collection", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "auto_collection",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["auto_collection"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The customer's current balance in their currency.
    /// </summary>
    public required string Balance
    {
        get
        {
            if (!this.Properties.TryGetValue("balance", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "balance",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("balance");
        }
        set { this.Properties["balance"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Address? BillingAddress
    {
        get
        {
            if (!this.Properties.TryGetValue("billing_address", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "billing_address",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Address?>(element);
        }
        set { this.Properties["billing_address"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A valid customer email, to be used for notifications. When Orb triggers payment
    /// through a payment gateway, this email will be used for any automatically issued receipts.
    /// </summary>
    public required string Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("email", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("email");
        }
        set { this.Properties["email"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required bool EmailDelivery
    {
        get
        {
            if (!this.Properties.TryGetValue("email_delivery", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "email_delivery",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["email_delivery"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required bool? ExemptFromAutomatedTax
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "exempt_from_automated_tax",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "exempt_from_automated_tax",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.Properties["exempt_from_automated_tax"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// An optional user-defined ID for this customer resource, used throughout the
    /// system as an alias for this Customer. Use this field to identify a customer
    /// by an existing identifier in your system.
    /// </summary>
    public required string? ExternalCustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_customer_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "external_customer_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_customer_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The hierarchical relationships for this customer.
    /// </summary>
    public required CustomerProperties::Hierarchy Hierarchy
    {
        get
        {
            if (!this.Properties.TryGetValue("hierarchy", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "hierarchy",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CustomerProperties::Hierarchy>(element)
                ?? throw new System::ArgumentNullException("hierarchy");
        }
        set { this.Properties["hierarchy"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Generic::Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "metadata",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string>>(element)
                ?? throw new System::ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The full name of the customer
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode, the connection must first be configured in the Orb webapp.
    /// </summary>
    public required CustomerProperties::PaymentProvider? PaymentProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_provider", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "payment_provider",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CustomerProperties::PaymentProvider?>(element);
        }
        set
        {
            this.Properties["payment_provider"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The ID of this customer in an external payments solution, such as Stripe. This
    /// is used for creating charges or invoices in the external system via Orb.
    /// </summary>
    public required string? PaymentProviderID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_provider_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "payment_provider_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["payment_provider_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required string? PortalURL
    {
        get
        {
            if (!this.Properties.TryGetValue("portal_url", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "portal_url",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["portal_url"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Models::Address? ShippingAddress
    {
        get
        {
            if (!this.Properties.TryGetValue("shipping_address", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "shipping_address",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::Address?>(element);
        }
        set
        {
            this.Properties["shipping_address"] = Json::JsonSerializer.SerializeToElement(value);
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
    public required Models::CustomerTaxID? TaxID
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::CustomerTaxID?>(element);
        }
        set { this.Properties["tax_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A timezone identifier from the IANA timezone database, such as "America/Los_Angeles".
    /// This "defaults to your account's timezone if not set. This cannot be changed
    /// after customer creation.
    /// </summary>
    public required string Timezone
    {
        get
        {
            if (!this.Properties.TryGetValue("timezone", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "timezone",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("timezone");
        }
        set { this.Properties["timezone"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public CustomerProperties::AccountingSyncConfiguration? AccountingSyncConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "accounting_sync_configuration",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<CustomerProperties::AccountingSyncConfiguration?>(
                element
            );
        }
        set
        {
            this.Properties["accounting_sync_configuration"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public CustomerProperties::ReportingConfiguration? ReportingConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "reporting_configuration",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<CustomerProperties::ReportingConfiguration?>(
                element
            );
        }
        set
        {
            this.Properties["reporting_configuration"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.AdditionalEmails)
        {
            _ = item;
        }
        _ = this.AutoCollection;
        _ = this.Balance;
        this.BillingAddress?.Validate();
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.Email;
        _ = this.EmailDelivery;
        _ = this.ExemptFromAutomatedTax;
        _ = this.ExternalCustomerID;
        this.Hierarchy.Validate();
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
        _ = this.Name;
        this.PaymentProvider?.Validate();
        _ = this.PaymentProviderID;
        _ = this.PortalURL;
        this.ShippingAddress?.Validate();
        this.TaxID?.Validate();
        _ = this.Timezone;
        this.AccountingSyncConfiguration?.Validate();
        this.ReportingConfiguration?.Validate();
    }

    public Customer() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Customer(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Customer FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
