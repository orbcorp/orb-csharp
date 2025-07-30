using Alerts = Orb.Service.Alerts;
using Beta = Orb.Service.Beta;
using Coupons = Orb.Service.Coupons;
using CreditNotes = Orb.Service.CreditNotes;
using Customers = Orb.Service.Customers;
using Events = Orb.Service.Events;
using Http = System.Net.Http;
using InvoiceLineItems = Orb.Service.InvoiceLineItems;
using Invoices = Orb.Service.Invoices;
using Items = Orb.Service.Items;
using Metrics = Orb.Service.Metrics;
using Plans = Orb.Service.Plans;
using Prices = Orb.Service.Prices;
using SubscriptionChanges = Orb.Service.SubscriptionChanges;
using System = System;
using TopLevel = Orb.Service.TopLevel;

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

    global::Orb.Service.Subscriptions.ISubscriptionService Subscriptions { get; }

    Alerts::IAlertService Alerts { get; }

    global::Orb.Service.DimensionalPriceGroups.IDimensionalPriceGroupService DimensionalPriceGroups { get; }

    SubscriptionChanges::ISubscriptionChangeService SubscriptionChanges { get; }
}
