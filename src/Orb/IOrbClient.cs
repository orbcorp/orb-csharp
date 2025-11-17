using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Services;

namespace Orb;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOrbClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int? MaxRetries { get; init; }

    TimeSpan? Timeout { get; init; }

    string APIKey { get; init; }

    string? WebhookSecret { get; init; }

    IOrbClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITopLevelService TopLevel { get; }

    IBetaService Beta { get; }

    ICouponService Coupons { get; }

    ICreditNoteService CreditNotes { get; }

    ICustomerService Customers { get; }

    IEventService Events { get; }

    IInvoiceLineItemService InvoiceLineItems { get; }

    IInvoiceService Invoices { get; }

    IItemService Items { get; }

    IMetricService Metrics { get; }

    IPlanService Plans { get; }

    IPriceService Prices { get; }

    ISubscriptionService Subscriptions { get; }

    IAlertService Alerts { get; }

    IDimensionalPriceGroupService DimensionalPriceGroups { get; }

    ISubscriptionChangeService SubscriptionChanges { get; }

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
