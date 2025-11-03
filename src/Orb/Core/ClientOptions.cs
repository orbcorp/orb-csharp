using System;
using System.Net.Http;
using Orb.Exceptions;

namespace Orb.Core;

public struct ClientOptions()
{
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(Environment.GetEnvironmentVariable("ORB_BASE_URL") ?? "https://api.withorb.com/v1")
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    Lazy<string> _apiKey = new(() =>
        Environment.GetEnvironmentVariable("ORB_API_KEY")
        ?? throw new OrbInvalidDataException(
            string.Format("{0} cannot be null", nameof(APIKey)),
            new ArgumentNullException(nameof(APIKey))
        )
    );
    public string APIKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }

    Lazy<string?> _webhookSecret = new(() =>
        Environment.GetEnvironmentVariable("ORB_WEBHOOK_SECRET")
    );
    public string? WebhookSecret
    {
        readonly get { return _webhookSecret.Value; }
        set { _webhookSecret = new(() => value); }
    }
}
