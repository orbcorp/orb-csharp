using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Services;

namespace Orb;

/// <summary>
/// A client for interacting with the Orb REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IOrbClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    string? WebhookSecret { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOrbClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    ICreditBlockService CreditBlocks { get; }
}

/// <summary>
/// A view of <see cref="IOrbClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IOrbClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    string? WebhookSecret { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrbClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITopLevelServiceWithRawResponse TopLevel { get; }

    IBetaServiceWithRawResponse Beta { get; }

    ICouponServiceWithRawResponse Coupons { get; }

    ICreditNoteServiceWithRawResponse CreditNotes { get; }

    ICustomerServiceWithRawResponse Customers { get; }

    IEventServiceWithRawResponse Events { get; }

    IInvoiceLineItemServiceWithRawResponse InvoiceLineItems { get; }

    IInvoiceServiceWithRawResponse Invoices { get; }

    IItemServiceWithRawResponse Items { get; }

    IMetricServiceWithRawResponse Metrics { get; }

    IPlanServiceWithRawResponse Plans { get; }

    IPriceServiceWithRawResponse Prices { get; }

    ISubscriptionServiceWithRawResponse Subscriptions { get; }

    IAlertServiceWithRawResponse Alerts { get; }

    IDimensionalPriceGroupServiceWithRawResponse DimensionalPriceGroups { get; }

    ISubscriptionChangeServiceWithRawResponse SubscriptionChanges { get; }

    ICreditBlockServiceWithRawResponse CreditBlocks { get; }

    /// <summary>
    /// Sends a request to the Orb REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
