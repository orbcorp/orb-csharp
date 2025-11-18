using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers;

/// <summary>
/// This endpoint can be used to update the `payment_provider`, `payment_provider_id`,
/// `name`, `email`, `email_delivery`, `tax_id`, `auto_collection`, `metadata`, `shipping_address`,
/// `billing_address`, and `additional_emails` of an existing customer. Other fields
/// on a customer are currently immutable.
/// </summary>
public sealed record class CustomerUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string CustomerID { get; init; }

    public NewAccountingSyncConfiguration? AccountingSyncConfiguration
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "accounting_sync_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewAccountingSyncConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["accounting_sync_configuration"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// Additional email addresses for this customer. If populated, these email addresses
    /// will be CC'd for customer communications. The total number of email addresses
    /// (including the primary email) cannot exceed 50.
    /// </summary>
    public List<string>? AdditionalEmails
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("additional_emails", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["additional_emails"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._bodyProperties.TryGetValue("auto_collection", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Used to determine if invoices for this customer will be automatically issued.
    /// If true, invoices will be automatically issued. If false, invoices will require
    /// manual approval.If `null` is specified, the customer's auto issuance setting
    /// will be inherited from the account-level setting.
    /// </summary>
    public bool? AutoIssuance
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("auto_issuance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["auto_issuance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public AddressInput? BillingAddress
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("billing_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddressInput?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["billing_address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string used for the customer's invoices and balance.
    /// If not set at creation time, will be set at subscription creation time.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A valid customer email, to be used for invoicing and notifications.
    /// </summary>
    public string? Email
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? EmailDelivery
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("email_delivery", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["email_delivery"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this._bodyProperties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._bodyProperties.TryGetValue("hierarchy", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomerHierarchyConfig?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["hierarchy"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The full name of the customer
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode: - the connection must first be configured in the Orb
    /// webapp.  - if the provider is an invoicing provider (`stripe_invoice`, `quickbooks`,
    /// `bill.com`, `netsuite`), any product mappings must first be configured with
    /// the Orb team.
    /// </summary>
    public ApiEnum<string, PaymentProviderModel>? PaymentProvider
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("payment_provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PaymentProviderModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["payment_provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of this customer in an external payments solution, such as Stripe.
    /// This is used for creating charges or invoices in the external system via Orb.
    /// </summary>
    public string? PaymentProviderID
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("payment_provider_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["payment_provider_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public NewReportingConfiguration? ReportingConfiguration
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "reporting_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<NewReportingConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["reporting_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public AddressInput? ShippingAddress
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("shipping_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddressInput?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["shipping_address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TaxConfigurationModel? TaxConfiguration
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("tax_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TaxConfigurationModel?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["tax_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax IDs are commonly required to be displayed on customer invoices, which
    /// are added to the headers of invoices.
    ///
    /// <para>### Supported Tax ID Countries and Types</para>
    ///
    /// <para>| Country | Type | Description | |---------|------|-------------| |
    /// Albania | `al_tin` | Albania Tax Identification Number | | Andorra | `ad_nrt`
    /// | Andorran NRT Number | | Angola | `ao_tin` | Angola Tax Identification Number
    /// | | Argentina | `ar_cuit` | Argentinian Tax ID Number | | Armenia | `am_tin`
    /// | Armenia Tax Identification Number | | Aruba | `aw_tin` | Aruba Tax Identification
    /// Number | | Australia | `au_abn` | Australian Business Number (AU ABN) | |
    /// Australia | `au_arn` | Australian Taxation Office Reference Number | | Austria
    /// | `eu_vat` | European VAT Number | | Azerbaijan | `az_tin` | Azerbaijan Tax
    /// Identification Number | | Bahamas | `bs_tin` | Bahamas Tax Identification
    /// Number | | Bahrain | `bh_vat` | Bahraini VAT Number | | Bangladesh | `bd_bin`
    /// | Bangladesh Business Identification Number | | Barbados | `bb_tin` | Barbados
    /// Tax Identification Number | | Belarus | `by_tin` | Belarus TIN Number | |
    /// Belgium | `eu_vat` | European VAT Number | | Benin | `bj_ifu` | Benin Tax
    /// Identification Number (Identifiant Fiscal Unique) | | Bolivia | `bo_tin`
    /// | Bolivian Tax ID | | Bosnia and Herzegovina | `ba_tin` | Bosnia and Herzegovina
    /// Tax Identification Number | | Brazil | `br_cnpj` | Brazilian CNPJ Number |
    /// | Brazil | `br_cpf` | Brazilian CPF Number | | Bulgaria | `bg_uic` | Bulgaria
    /// Unified Identification Code | | Bulgaria | `eu_vat` | European VAT Number
    /// | | Burkina Faso | `bf_ifu` | Burkina Faso Tax Identification Number (Numéro
    /// d'Identifiant Fiscal Unique) | | Cambodia | `kh_tin` | Cambodia Tax Identification
    /// Number | | Cameroon | `cm_niu` | Cameroon Tax Identification Number (Numéro
    /// d'Identifiant fiscal Unique) | | Canada | `ca_bn` | Canadian BN | | Canada
    /// | `ca_gst_hst` | Canadian GST/HST Number | | Canada | `ca_pst_bc` | Canadian
    /// PST Number (British Columbia) | | Canada | `ca_pst_mb` | Canadian PST Number
    /// (Manitoba) | | Canada | `ca_pst_sk` | Canadian PST Number (Saskatchewan) |
    /// | Canada | `ca_qst` | Canadian QST Number (Québec) | | Cape Verde | `cv_nif`
    /// | Cape Verde Tax Identification Number (Número de Identificação Fiscal) |
    /// | Chile | `cl_tin` | Chilean TIN | | China | `cn_tin` | Chinese Tax ID | |
    /// Colombia | `co_nit` | Colombian NIT Number | | Congo-Kinshasa | `cd_nif`
    /// | Congo (DR) Tax Identification Number (Número de Identificação Fiscal) |
    /// | Costa Rica | `cr_tin` | Costa Rican Tax ID | | Croatia | `eu_vat` | European
    /// VAT Number | | Croatia | `hr_oib` | Croatian Personal Identification Number
    /// (OIB) | | Cyprus | `eu_vat` | European VAT Number | | Czech Republic | `eu_vat`
    /// | European VAT Number | | Denmark | `eu_vat` | European VAT Number | | Dominican
    /// Republic | `do_rcn` | Dominican RCN Number | | Ecuador | `ec_ruc` | Ecuadorian
    /// RUC Number | | Egypt | `eg_tin` | Egyptian Tax Identification Number | |
    /// El Salvador | `sv_nit` | El Salvadorian NIT Number | | Estonia | `eu_vat`
    /// | European VAT Number | | Ethiopia | `et_tin` | Ethiopia Tax Identification
    /// Number | | European Union | `eu_oss_vat` | European One Stop Shop VAT Number
    /// for non-Union scheme | | Finland | `eu_vat` | European VAT Number | | France
    /// | `eu_vat` | European VAT Number | | Georgia | `ge_vat` | Georgian VAT | |
    /// Germany | `de_stn` | German Tax Number (Steuernummer) | | Germany | `eu_vat`
    /// | European VAT Number | | Greece | `eu_vat` | European VAT Number | | Guinea
    /// | `gn_nif` | Guinea Tax Identification Number (Número de Identificação Fiscal)
    /// | | Hong Kong | `hk_br` | Hong Kong BR Number | | Hungary | `eu_vat` | European
    /// VAT Number | | Hungary | `hu_tin` | Hungary Tax Number (adószám) | | Iceland
    /// | `is_vat` | Icelandic VAT | | India | `in_gst` | Indian GST Number | | Indonesia
    /// | `id_npwp` | Indonesian NPWP Number | | Ireland | `eu_vat` | European VAT
    /// Number | | Israel | `il_vat` | Israel VAT | | Italy | `eu_vat` | European
    /// VAT Number | | Japan | `jp_cn` | Japanese Corporate Number (*Hōjin Bangō*)
    /// | | Japan | `jp_rn` | Japanese Registered Foreign Businesses' Registration
    /// Number (*Tōroku Kokugai Jigyōsha no Tōroku Bangō*) | | Japan | `jp_trn` |
    /// Japanese Tax Registration Number (*Tōroku Bangō*) | | Kazakhstan | `kz_bin`
    /// | Kazakhstani Business Identification Number | | Kenya | `ke_pin` | Kenya
    /// Revenue Authority Personal Identification Number | | Kyrgyzstan | `kg_tin`
    /// | Kyrgyzstan Tax Identification Number | | Laos | `la_tin` | Laos Tax Identification
    /// Number | | Latvia | `eu_vat` | European VAT Number | | Liechtenstein | `li_uid`
    /// | Liechtensteinian UID Number | | Liechtenstein | `li_vat` | Liechtenstein
    /// VAT Number | | Lithuania | `eu_vat` | European VAT Number | | Luxembourg
    /// | `eu_vat` | European VAT Number | | Malaysia | `my_frp` | Malaysian FRP
    /// Number | | Malaysia | `my_itn` | Malaysian ITN | | Malaysia | `my_sst` | Malaysian
    /// SST Number | | Malta | `eu_vat` | European VAT Number | | Mauritania | `mr_nif`
    /// | Mauritania Tax Identification Number (Número de Identificação Fiscal) |
    /// | Mexico | `mx_rfc` | Mexican RFC Number | | Moldova | `md_vat` | Moldova
    /// VAT Number | | Montenegro | `me_pib` | Montenegro PIB Number | | Morocco |
    /// `ma_vat` | Morocco VAT Number | | Nepal | `np_pan` | Nepal PAN Number | |
    /// Netherlands | `eu_vat` | European VAT Number | | New Zealand | `nz_gst` |
    /// New Zealand GST Number | | Nigeria | `ng_tin` | Nigerian Tax Identification
    /// Number | | North Macedonia | `mk_vat` | North Macedonia VAT Number | | Northern
    /// Ireland | `eu_vat` | Northern Ireland VAT Number | | Norway | `no_vat` |
    /// Norwegian VAT Number | | Norway | `no_voec` | Norwegian VAT on e-commerce
    /// Number | | Oman | `om_vat` | Omani VAT Number | | Peru | `pe_ruc` | Peruvian
    /// RUC Number | | Philippines | `ph_tin` | Philippines Tax Identification Number
    /// | | Poland | `eu_vat` | European VAT Number | | Portugal | `eu_vat` | European
    /// VAT Number | | Romania | `eu_vat` | European VAT Number | | Romania | `ro_tin`
    /// | Romanian Tax ID Number | | Russia | `ru_inn` | Russian INN | | Russia |
    /// `ru_kpp` | Russian KPP | | Saudi Arabia | `sa_vat` | Saudi Arabia VAT | |
    /// Senegal | `sn_ninea` | Senegal NINEA Number | | Serbia | `rs_pib` | Serbian
    /// PIB Number | | Singapore | `sg_gst` | Singaporean GST | | Singapore | `sg_uen`
    /// | Singaporean UEN | | Slovakia | `eu_vat` | European VAT Number | | Slovenia
    /// | `eu_vat` | European VAT Number | | Slovenia | `si_tin` | Slovenia Tax Number
    /// (davčna številka) | | South Africa | `za_vat` | South African VAT Number |
    /// | South Korea | `kr_brn` | Korean BRN | | Spain | `es_cif` | Spanish NIF
    /// Number (previously Spanish CIF Number) | | Spain | `eu_vat` | European VAT
    /// Number | | Suriname | `sr_fin` | Suriname FIN Number | | Sweden | `eu_vat`
    /// | European VAT Number | | Switzerland | `ch_uid` | Switzerland UID Number
    /// | | Switzerland | `ch_vat` | Switzerland VAT Number | | Taiwan | `tw_vat`
    /// | Taiwanese VAT | | Tajikistan | `tj_tin` | Tajikistan Tax Identification
    /// Number | | Tanzania | `tz_vat` | Tanzania VAT Number | | Thailand | `th_vat`
    /// | Thai VAT | | Turkey | `tr_tin` | Turkish Tax Identification Number | | Uganda
    /// | `ug_tin` | Uganda Tax Identification Number | | Ukraine | `ua_vat` | Ukrainian
    /// VAT | | United Arab Emirates | `ae_trn` | United Arab Emirates TRN | | United
    /// Kingdom | `gb_vat` | United Kingdom VAT Number | | United States | `us_ein`
    /// | United States EIN | | Uruguay | `uy_ruc` | Uruguayan RUC Number | | Uzbekistan
    /// | `uz_tin` | Uzbekistan TIN Number | | Uzbekistan | `uz_vat` | Uzbekistan
    /// VAT Number | | Venezuela | `ve_rif` | Venezuelan RIF Number | | Vietnam |
    /// `vn_tin` | Vietnamese Tax ID Number | | Zambia | `zm_tin` | Zambia Tax Identification
    /// Number | | Zimbabwe | `zw_tin` | Zimbabwe Tax Identification Number |</para>
    /// </summary>
    public CustomerTaxID? TaxID
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomerTaxID?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["tax_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CustomerUpdateParams() { }

    public CustomerUpdateParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerUpdateParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static CustomerUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}", this.CustomerID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// This is used for creating charges or invoices in an external system via Orb.
/// When not in test mode: - the connection must first be configured in the Orb webapp.
///  - if the provider is an invoicing provider (`stripe_invoice`, `quickbooks`,
/// `bill.com`, `netsuite`), any product mappings must first be configured with the
/// Orb team.
/// </summary>
[JsonConverter(typeof(PaymentProviderModelConverter))]
public enum PaymentProviderModel
{
    Quickbooks,
    BillCom,
    StripeCharge,
    StripeInvoice,
    Netsuite,
}

sealed class PaymentProviderModelConverter : JsonConverter<PaymentProviderModel>
{
    public override PaymentProviderModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quickbooks" => PaymentProviderModel.Quickbooks,
            "bill.com" => PaymentProviderModel.BillCom,
            "stripe_charge" => PaymentProviderModel.StripeCharge,
            "stripe_invoice" => PaymentProviderModel.StripeInvoice,
            "netsuite" => PaymentProviderModel.Netsuite,
            _ => (PaymentProviderModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentProviderModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentProviderModel.Quickbooks => "quickbooks",
                PaymentProviderModel.BillCom => "bill.com",
                PaymentProviderModel.StripeCharge => "stripe_charge",
                PaymentProviderModel.StripeInvoice => "stripe_invoice",
                PaymentProviderModel.Netsuite => "netsuite",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TaxConfigurationModelConverter))]
public record class TaxConfigurationModel
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public bool TaxExempt
    {
        get
        {
            return Match(
                newAvalara: (x) => x.TaxExempt,
                newTaxJar: (x) => x.TaxExempt,
                newSphere: (x) => x.TaxExempt,
                numeral: (x) => x.TaxExempt,
                anrok: (x) => x.TaxExempt,
                stripe: (x) => x.TaxExempt
            );
        }
    }

    public bool? AutomaticTaxEnabled
    {
        get
        {
            return Match<bool?>(
                newAvalara: (x) => x.AutomaticTaxEnabled,
                newTaxJar: (x) => x.AutomaticTaxEnabled,
                newSphere: (x) => x.AutomaticTaxEnabled,
                numeral: (x) => x.AutomaticTaxEnabled,
                anrok: (x) => x.AutomaticTaxEnabled,
                stripe: (x) => x.AutomaticTaxEnabled
            );
        }
    }

    public TaxConfigurationModel(NewAvalaraTaxConfiguration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfigurationModel(NewTaxJarConfiguration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfigurationModel(NewSphereConfiguration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfigurationModel(TaxConfigurationModelNumeral value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfigurationModel(TaxConfigurationModelAnrok value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfigurationModel(TaxConfigurationModelStripe value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfigurationModel(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewAvalara([NotNullWhen(true)] out NewAvalaraTaxConfiguration? value)
    {
        value = this.Value as NewAvalaraTaxConfiguration;
        return value != null;
    }

    public bool TryPickNewTaxJar([NotNullWhen(true)] out NewTaxJarConfiguration? value)
    {
        value = this.Value as NewTaxJarConfiguration;
        return value != null;
    }

    public bool TryPickNewSphere([NotNullWhen(true)] out NewSphereConfiguration? value)
    {
        value = this.Value as NewSphereConfiguration;
        return value != null;
    }

    public bool TryPickNumeral([NotNullWhen(true)] out TaxConfigurationModelNumeral? value)
    {
        value = this.Value as TaxConfigurationModelNumeral;
        return value != null;
    }

    public bool TryPickAnrok([NotNullWhen(true)] out TaxConfigurationModelAnrok? value)
    {
        value = this.Value as TaxConfigurationModelAnrok;
        return value != null;
    }

    public bool TryPickStripe([NotNullWhen(true)] out TaxConfigurationModelStripe? value)
    {
        value = this.Value as TaxConfigurationModelStripe;
        return value != null;
    }

    public void Switch(
        System::Action<NewAvalaraTaxConfiguration> newAvalara,
        System::Action<NewTaxJarConfiguration> newTaxJar,
        System::Action<NewSphereConfiguration> newSphere,
        System::Action<TaxConfigurationModelNumeral> numeral,
        System::Action<TaxConfigurationModelAnrok> anrok,
        System::Action<TaxConfigurationModelStripe> stripe
    )
    {
        switch (this.Value)
        {
            case NewAvalaraTaxConfiguration value:
                newAvalara(value);
                break;
            case NewTaxJarConfiguration value:
                newTaxJar(value);
                break;
            case NewSphereConfiguration value:
                newSphere(value);
                break;
            case TaxConfigurationModelNumeral value:
                numeral(value);
                break;
            case TaxConfigurationModelAnrok value:
                anrok(value);
                break;
            case TaxConfigurationModelStripe value:
                stripe(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of TaxConfigurationModel"
                );
        }
    }

    public T Match<T>(
        System::Func<NewAvalaraTaxConfiguration, T> newAvalara,
        System::Func<NewTaxJarConfiguration, T> newTaxJar,
        System::Func<NewSphereConfiguration, T> newSphere,
        System::Func<TaxConfigurationModelNumeral, T> numeral,
        System::Func<TaxConfigurationModelAnrok, T> anrok,
        System::Func<TaxConfigurationModelStripe, T> stripe
    )
    {
        return this.Value switch
        {
            NewAvalaraTaxConfiguration value => newAvalara(value),
            NewTaxJarConfiguration value => newTaxJar(value),
            NewSphereConfiguration value => newSphere(value),
            TaxConfigurationModelNumeral value => numeral(value),
            TaxConfigurationModelAnrok value => anrok(value),
            TaxConfigurationModelStripe value => stripe(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of TaxConfigurationModel"
            ),
        };
    }

    public static implicit operator TaxConfigurationModel(NewAvalaraTaxConfiguration value) =>
        new(value);

    public static implicit operator TaxConfigurationModel(NewTaxJarConfiguration value) =>
        new(value);

    public static implicit operator TaxConfigurationModel(NewSphereConfiguration value) =>
        new(value);

    public static implicit operator TaxConfigurationModel(TaxConfigurationModelNumeral value) =>
        new(value);

    public static implicit operator TaxConfigurationModel(TaxConfigurationModelAnrok value) =>
        new(value);

    public static implicit operator TaxConfigurationModel(TaxConfigurationModelStripe value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of TaxConfigurationModel"
            );
        }
    }
}

sealed class TaxConfigurationModelConverter : JsonConverter<TaxConfigurationModel?>
{
    public override TaxConfigurationModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? taxProvider;
        try
        {
            taxProvider = json.GetProperty("tax_provider").GetString();
        }
        catch
        {
            taxProvider = null;
        }

        switch (taxProvider)
        {
            case "avalara":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAvalaraTaxConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "taxjar":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewTaxJarConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "sphere":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSphereConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "numeral":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TaxConfigurationModelNumeral>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "anrok":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TaxConfigurationModelAnrok>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "stripe":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TaxConfigurationModelStripe>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new TaxConfigurationModel(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxConfigurationModel? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<TaxConfigurationModelNumeral>))]
public sealed record class TaxConfigurationModelNumeral
    : ModelBase,
        IFromRaw<TaxConfigurationModelNumeral>
{
    public required bool TaxExempt
    {
        get
        {
            if (!this._properties.TryGetValue("tax_exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_exempt' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_exempt",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tax_exempt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TaxConfigurationModelNumeralTaxProvider TaxProvider
    {
        get
        {
            if (!this._properties.TryGetValue("tax_provider", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_provider",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TaxConfigurationModelNumeralTaxProvider>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentNullException("tax_provider")
                );
        }
        init
        {
            this._properties["tax_provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get
        {
            if (!this._properties.TryGetValue("automatic_tax_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["automatic_tax_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
        _ = this.AutomaticTaxEnabled;
    }

    public TaxConfigurationModelNumeral()
    {
        this.TaxProvider = new();
    }

    public TaxConfigurationModelNumeral(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.TaxProvider = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxConfigurationModelNumeral(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TaxConfigurationModelNumeral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TaxConfigurationModelNumeral(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

[JsonConverter(typeof(Converter))]
public class TaxConfigurationModelNumeralTaxProvider
{
    public JsonElement Json { get; private init; }

    public TaxConfigurationModelNumeralTaxProvider()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
    }

    TaxConfigurationModelNumeralTaxProvider(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new TaxConfigurationModelNumeralTaxProvider().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'TaxConfigurationModelNumeralTaxProvider'"
            );
        }
    }

    class Converter : JsonConverter<TaxConfigurationModelNumeralTaxProvider>
    {
        public override TaxConfigurationModelNumeralTaxProvider? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaxConfigurationModelNumeralTaxProvider value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<TaxConfigurationModelAnrok>))]
public sealed record class TaxConfigurationModelAnrok
    : ModelBase,
        IFromRaw<TaxConfigurationModelAnrok>
{
    public required bool TaxExempt
    {
        get
        {
            if (!this._properties.TryGetValue("tax_exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_exempt' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_exempt",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tax_exempt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TaxConfigurationModelAnrokTaxProvider TaxProvider
    {
        get
        {
            if (!this._properties.TryGetValue("tax_provider", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_provider",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TaxConfigurationModelAnrokTaxProvider>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentNullException("tax_provider")
                );
        }
        init
        {
            this._properties["tax_provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get
        {
            if (!this._properties.TryGetValue("automatic_tax_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["automatic_tax_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
        _ = this.AutomaticTaxEnabled;
    }

    public TaxConfigurationModelAnrok()
    {
        this.TaxProvider = new();
    }

    public TaxConfigurationModelAnrok(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.TaxProvider = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxConfigurationModelAnrok(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TaxConfigurationModelAnrok FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TaxConfigurationModelAnrok(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

[JsonConverter(typeof(Converter))]
public class TaxConfigurationModelAnrokTaxProvider
{
    public JsonElement Json { get; private init; }

    public TaxConfigurationModelAnrokTaxProvider()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
    }

    TaxConfigurationModelAnrokTaxProvider(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new TaxConfigurationModelAnrokTaxProvider().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'TaxConfigurationModelAnrokTaxProvider'"
            );
        }
    }

    class Converter : JsonConverter<TaxConfigurationModelAnrokTaxProvider>
    {
        public override TaxConfigurationModelAnrokTaxProvider? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaxConfigurationModelAnrokTaxProvider value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<TaxConfigurationModelStripe>))]
public sealed record class TaxConfigurationModelStripe
    : ModelBase,
        IFromRaw<TaxConfigurationModelStripe>
{
    public required bool TaxExempt
    {
        get
        {
            if (!this._properties.TryGetValue("tax_exempt", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_exempt' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_exempt",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tax_exempt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TaxConfigurationModelStripeTaxProvider TaxProvider
    {
        get
        {
            if (!this._properties.TryGetValue("tax_provider", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_provider",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<TaxConfigurationModelStripeTaxProvider>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'tax_provider' cannot be null",
                    new System::ArgumentNullException("tax_provider")
                );
        }
        init
        {
            this._properties["tax_provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get
        {
            if (!this._properties.TryGetValue("automatic_tax_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["automatic_tax_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        this.TaxProvider.Validate();
        _ = this.AutomaticTaxEnabled;
    }

    public TaxConfigurationModelStripe()
    {
        this.TaxProvider = new();
    }

    public TaxConfigurationModelStripe(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.TaxProvider = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxConfigurationModelStripe(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TaxConfigurationModelStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TaxConfigurationModelStripe(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

[JsonConverter(typeof(Converter))]
public class TaxConfigurationModelStripeTaxProvider
{
    public JsonElement Json { get; private init; }

    public TaxConfigurationModelStripeTaxProvider()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
    }

    TaxConfigurationModelStripeTaxProvider(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new TaxConfigurationModelStripeTaxProvider().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'TaxConfigurationModelStripeTaxProvider'"
            );
        }
    }

    class Converter : JsonConverter<TaxConfigurationModelStripeTaxProvider>
    {
        public override TaxConfigurationModelStripeTaxProvider? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaxConfigurationModelStripeTaxProvider value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
