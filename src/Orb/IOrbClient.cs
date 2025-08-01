using Alerts = Orb.Services.Alerts;
using Beta = Orb.Services.Beta;
using Coupons = Orb.Services.Coupons;
using CreditNotes = Orb.Services.CreditNotes;
using Customers = Orb.Services.Customers;
using Events = Orb.Services.Events;
using Http = System.Net.Http;
using InvoiceLineItems = Orb.Services.InvoiceLineItems;
using Invoices = Orb.Services.Invoices;
using Items = Orb.Services.Items;
using Metrics = Orb.Services.Metrics;
using Plans = Orb.Services.Plans;
using Prices = Orb.Services.Prices;
using SubscriptionChanges = Orb.Services.SubscriptionChanges;
using System = System;
using TopLevel = Orb.Services.TopLevel;

namespace Orb;

public interface IOrbClient
{
    Http::HttpClient HttpClient { get; init; }

    System::Uri BaseUrl { get; init; }

    string APIKey { get; init; }

    TopLevel::ITopLevelService TopLevel { get; }

    Beta::IBetaService Beta { get; }

    Coupons::ICouponService Coupons { get; }

    CreditNotes::ICreditNoteService CreditNotes { get; }

    Customers::ICustomerService Customers { get; }

    Events::IEventService Events { get; }

    InvoiceLineItems::IInvoiceLineItemService InvoiceLineItems { get; }

    Invoices::IInvoiceService Invoices { get; }

    Items::IItemService Items { get; }

    Metrics::IMetricService Metrics { get; }

    Plans::IPlanService Plans { get; }

    Prices::IPriceService Prices { get; }

    global::Orb.Services.Subscriptions.ISubscriptionService Subscriptions { get; }

    Alerts::IAlertService Alerts { get; }

    global::Orb.Services.DimensionalPriceGroups.IDimensionalPriceGroupService DimensionalPriceGroups { get; }

    SubscriptionChanges::ISubscriptionChangeService SubscriptionChanges { get; }
}
