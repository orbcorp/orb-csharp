using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class BodyModelIncrementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyModelIncrement
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
                    Field = FilterModelField.ItemID,
                    Operator = FilterModelOperator.Includes,
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
        BodyModelIncrementEntryType expectedEntryType = JsonSerializer.Deserialize<JsonElement>(
            "\"increment\""
        );
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<FilterModel> expectedFilters =
        [
            new()
            {
                Field = FilterModelField.ItemID,
                Operator = FilterModelOperator.Includes,
                Values = ["string"],
            },
        ];
        BodyModelIncrementInvoiceSettings expectedInvoiceSettings = new()
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
        Assert.Equal(expectedEntryType, model.EntryType);
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

public class FilterModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilterModel
        {
            Field = FilterModelField.ItemID,
            Operator = FilterModelOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, FilterModelField> expectedField = FilterModelField.ItemID;
        ApiEnum<string, FilterModelOperator> expectedOperator = FilterModelOperator.Includes;
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

public class BodyModelIncrementInvoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyModelIncrementInvoiceSettings
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
        BodyModelIncrementInvoiceSettingsCustomDueDate expectedCustomDueDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2019-12-27");
        BodyModelIncrementInvoiceSettingsInvoiceDate expectedInvoiceDate =
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

public class BodyModelDecrementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyModelDecrement
        {
            Amount = 0,
            EntryType = JsonSerializer.Deserialize<JsonElement>("\"decrement\""),
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        double expectedAmount = 0;
        BodyModelDecrementEntryType expectedEntryType = JsonSerializer.Deserialize<JsonElement>(
            "\"decrement\""
        );
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedEntryType, model.EntryType);
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

public class BodyModelExpirationChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyModelExpirationChange
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

        BodyModelExpirationChangeEntryType expectedEntryType =
            JsonSerializer.Deserialize<JsonElement>("\"expiration_change\"");

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

        Assert.Equal(expectedEntryType, model.EntryType);
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

public class BodyModelVoidTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyModelVoid
        {
            Amount = 0,
            BlockID = "block_id",
            EntryType = JsonSerializer.Deserialize<JsonElement>("\"void\""),
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = BodyModelVoidVoidReason.Refund,
        };

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        BodyModelVoidEntryType expectedEntryType = JsonSerializer.Deserialize<JsonElement>(
            "\"void\""
        );
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, BodyModelVoidVoidReason> expectedVoidReason =
            BodyModelVoidVoidReason.Refund;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBlockID, model.BlockID);
        Assert.Equal(expectedEntryType, model.EntryType);
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

public class BodyModelAmendmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyModelAmendment
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
        BodyModelAmendmentEntryType expectedEntryType = JsonSerializer.Deserialize<JsonElement>(
            "\"amendment\""
        );
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBlockID, model.BlockID);
        Assert.Equal(expectedEntryType, model.EntryType);
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
