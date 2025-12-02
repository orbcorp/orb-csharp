using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Ledger = Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class IncrementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::Increment
        {
            Amount = 0,
            EntryType = JsonSerializer.Deserialize<JsonElement>("\"increment\""),
            Currency = "currency",
            Description = "description",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Ledger::Field.ItemID,
                    Operator = Ledger::Operator.Includes,
                    Values = ["string"],
                },
            ],
            InvoiceSettings = new()
            {
                AutoCollection = true,
                CustomDueDate =
#if NET
                DateOnly
#else
                DateTimeOffset
#endif
                .Parse("2019-12-27"),
                InvoiceDate =
#if NET
                DateOnly
#else
                DateTimeOffset
#endif
                .Parse("2019-12-27"),
                ItemID = "item_id",
                Memo = "memo",
                NetTerms = 0,
                RequireSuccessfulPayment = true,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        double expectedAmount = 0;
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"increment\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Ledger::Filter> expectedFilters =
        [
            new()
            {
                Field = Ledger::Field.ItemID,
                Operator = Ledger::Operator.Includes,
                Values = ["string"],
            },
        ];
        Ledger::InvoiceSettings expectedInvoiceSettings = new()
        {
            AutoCollection = true,
            CustomDueDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            InvoiceDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            ItemID = "item_id",
            Memo = "memo",
            NetTerms = 0,
            RequireSuccessfulPayment = true,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, model.EntryType));
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedInvoiceSettings, model.InvoiceSettings);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::Filter
        {
            Field = Ledger::Field.ItemID,
            Operator = Ledger::Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Ledger::Field> expectedField = Ledger::Field.ItemID;
        ApiEnum<string, Ledger::Operator> expectedOperator = Ledger::Operator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }
}

public class InvoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            CustomDueDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            InvoiceDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            ItemID = "item_id",
            Memo = "memo",
            NetTerms = 0,
            RequireSuccessfulPayment = true,
        };

        bool expectedAutoCollection = true;
        Ledger::CustomDueDate expectedCustomDueDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2019-12-27");
        Ledger::InvoiceDate expectedInvoiceDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2019-12-27");
        string expectedItemID = "item_id";
        string expectedMemo = "memo";
        long expectedNetTerms = 0;
        bool expectedRequireSuccessfulPayment = true;

        Assert.Equal(expectedAutoCollection, model.AutoCollection);
        Assert.Equal(expectedCustomDueDate, model.CustomDueDate);
        Assert.Equal(expectedInvoiceDate, model.InvoiceDate);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedNetTerms, model.NetTerms);
        Assert.Equal(expectedRequireSuccessfulPayment, model.RequireSuccessfulPayment);
    }
}

public class DecrementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::Decrement
        {
            Amount = 0,
            EntryType = JsonSerializer.Deserialize<JsonElement>("\"decrement\""),
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        double expectedAmount = 0;
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"decrement\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, model.Amount);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, model.EntryType));
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }
}

public class ExpirationChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::ExpirationChange
        {
            EntryType = JsonSerializer.Deserialize<JsonElement>("\"expiration_change\""),
            TargetExpiryDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>(
            "\"expiration_change\""
        );

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedTargetExpiryDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2019-12-27");
        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.True(JsonElement.DeepEquals(expectedEntryType, model.EntryType));
        Assert.Equal(expectedTargetExpiryDate, model.TargetExpiryDate);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBlockID, model.BlockID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }
}

public class VoidTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::Void
        {
            Amount = 0,
            BlockID = "block_id",
            EntryType = JsonSerializer.Deserialize<JsonElement>("\"void\""),
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = Ledger::VoidReason.Refund,
        };

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"void\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Ledger::VoidReason> expectedVoidReason = Ledger::VoidReason.Refund;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBlockID, model.BlockID);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, model.EntryType));
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedVoidReason, model.VoidReason);
    }
}

public class AmendmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::Amendment
        {
            Amount = 0,
            BlockID = "block_id",
            EntryType = JsonSerializer.Deserialize<JsonElement>("\"amendment\""),
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"amendment\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBlockID, model.BlockID);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, model.EntryType));
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
    }
}
