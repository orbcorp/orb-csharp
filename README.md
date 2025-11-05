# Orb C# API Library

> [!NOTE]
> The Orb C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/orbcorp/orb-csharp/issues/new).

The Orb C# SDK provides convenient access to the [Orb REST API](https://docs.withorb.com/reference/api-reference) from applications written in C#.

The REST API documentation can be found on [docs.withorb.com](https://docs.withorb.com/reference/api-reference).

## Installation

```bash
git clone git@github.com:orbcorp/orb-csharp.git
dotnet add reference orb-csharp/src/Orb
```

## Requirements

This library requires .NET 8 or later.

> [!NOTE]
> The library is currently in **beta**. The requirements will be lowered in the future.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Orb;
using Orb.Models.Customers;

OrbClient client = new();

CustomerCreateParams parameters = new()
{
    Email = "example-customer@withorb.com",
    Name = "My Customer",
};

var customer = await client.Customers.Create(parameters);

Console.WriteLine(customer);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Orb;

// Configured using the ORB_API_KEY, ORB_WEBHOOK_SECRET and ORB_BASE_URL environment variables
OrbClient client = new();
```

Or manually:

```csharp
using Orb;

OrbClient client = new() { APIKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property        | Environment variable | Required | Default value                  |
| --------------- | -------------------- | -------- | ------------------------------ |
| `APIKey`        | `ORB_API_KEY`        | true     | -                              |
| `WebhookSecret` | `ORB_WEBHOOK_SECRET` | false    | -                              |
| `BaseUrl`       | `ORB_BASE_URL`       | true     | `"https://api.withorb.com/v1"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var customer = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = new("https://example.com"),
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Customers.Create(parameters);

Console.WriteLine(customer);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Orb API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Customers.Create` should be called with an instance of `CustomerCreateParams`, and it will return an instance of `Task<Customer>`.

## Error handling

The SDK throws custom unchecked exception types:

- `OrbApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                          |
| ------ | ---------------------------------- |
| 400    | `OrbBadRequestException`           |
| 401    | `OrbUnauthorizedException`         |
| 403    | `OrbForbiddenException`            |
| 404    | `OrbNotFoundException`             |
| 422    | `OrbUnprocessableEntityException`  |
| 429    | `OrbRateLimitException`            |
| 5xx    | `Orb5xxException`                  |
| others | `OrbUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Orb4xxException`.

false

- `OrbIOException`: I/O networking errors.

- `OrbInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `OrbException`: Base class for all exceptions.

## Network options

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Orb;

OrbClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var customer = await client
    .WithOptions(options =>
        options with
        {
            Timeout = TimeSpan.FromSeconds(42)
        }
    )
    .Customers.Create(parameters);

Console.WriteLine(customer);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/orbcorp/orb-csharp/issues) with questions, bugs, or suggestions.
