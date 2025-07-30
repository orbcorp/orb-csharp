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

### Dotnet

```bash
dotnet add reference /path/to/orb-csharp/src/Orb/
```

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```C#
using Orb;
using Orb.Models.Customers;
using System;

// Configured using the ORB_API_KEY, ORB_WEBHOOK_SECRET and ORB_BASE_URL environment variables
OrbClient client = new();

CustomerCreateParams param = new()
{
  Email = "example-customer@withorb.com", Name = "My Customer"
};

var customer = await client.Customers.Create(param);

Console.WriteLine(customer);
```

## Client Configuration

Configure the client using environment variables:

```C#
using Orb;

// Configured using the ORB_API_KEY, ORB_WEBHOOK_SECRET and ORB_BASE_URL environment variables
OrbClient client = new();
```

Or manually:

```C#
using Orb;

OrbClient client = new()
{
  APIKey = "My API Key"
};
```

Alternatively, you can use a combination of the two approaches.
