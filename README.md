# Orb C# API Library

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
using Customers = Orb.Models.Customers;
using Orb = Orb;
using System = System;

// Configured using the ORB_API_KEY, ORB_WEBHOOK_SECRET and ORB_BASE_URL environment variables
Orb::OrbClient client = new Orb::OrbClient();

var param = new Customers::CustomerCreateParams()
{
  Email = "example-customer@withorb.com", Name = "My Customer"
};

var customer = await client.Customers.Create(param);

System::Console.WriteLine(customer);
```

## Client Configuration

Configure the client using environment variables:

```C#
using Orb = Orb;

// Configured using the ORB_API_KEY, ORB_WEBHOOK_SECRET and ORB_BASE_URL environment variables
Orb::OrbClient client = new Orb::OrbClient();
```

Or manually:

```C#
using Orb = Orb;

Orb::OrbClient client = new Orb::OrbClient()
{
  APIKey = "My API Key"
};
```

Alternatively, you can use a combination of the two approaches.
