using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class LedgerCreateEntryByExternalIDParamsBodyIncrementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
                    Operator =
                        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
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
        List<LedgerCreateEntryByExternalIDParamsBodyIncrementFilter> expectedFilters =
        [
            new()
            {
                Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
                Operator = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings expectedInvoiceSettings =
            new()
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
                    Operator =
                        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyIncrement>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
                    Operator =
                        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
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

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyIncrement>(json);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"increment\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<LedgerCreateEntryByExternalIDParamsBodyIncrementFilter> expectedFilters =
        [
            new()
            {
                Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
                Operator = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings expectedInvoiceSettings =
            new()
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

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, deserialized.EntryType));
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedInvoiceSettings, deserialized.InvoiceSettings);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPerUnitCostBasis, deserialized.PerUnitCostBasis);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
                    Operator =
                        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrement { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.EffectiveDate);
        Assert.False(model.RawData.ContainsKey("effective_date"));
        Assert.Null(model.ExpiryDate);
        Assert.False(model.RawData.ContainsKey("expiry_date"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.InvoiceSettings);
        Assert.False(model.RawData.ContainsKey("invoice_settings"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PerUnitCostBasis);
        Assert.False(model.RawData.ContainsKey("per_unit_cost_basis"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrement { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrement
        {
            Amount = 0,

            Currency = null,
            Description = null,
            EffectiveDate = null,
            ExpiryDate = null,
            Filters = null,
            InvoiceSettings = null,
            Metadata = null,
            PerUnitCostBasis = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.EffectiveDate);
        Assert.True(model.RawData.ContainsKey("effective_date"));
        Assert.Null(model.ExpiryDate);
        Assert.True(model.RawData.ContainsKey("expiry_date"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.InvoiceSettings);
        Assert.True(model.RawData.ContainsKey("invoice_settings"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PerUnitCostBasis);
        Assert.True(model.RawData.ContainsKey("per_unit_cost_basis"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrement
        {
            Amount = 0,

            Currency = null,
            Description = null,
            EffectiveDate = null,
            ExpiryDate = null,
            Filters = null,
            InvoiceSettings = null,
            Metadata = null,
            PerUnitCostBasis = null,
        };

        model.Validate();
    }
}

public class LedgerCreateEntryByExternalIDParamsBodyIncrementFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementFilter
        {
            Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
            Operator = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField> expectedField =
            LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID;
        ApiEnum<
            string,
            LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator
        > expectedOperator =
            LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementFilter
        {
            Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
            Operator = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyIncrementFilter>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementFilter
        {
            Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
            Operator = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyIncrementFilter>(
                json
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField> expectedField =
            LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID;
        ApiEnum<
            string,
            LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator
        > expectedOperator =
            LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes;
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementFilter
        {
            Field = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
            Operator = LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
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
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate expectedCustomDueDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27");
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate expectedInvoiceDate =
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
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

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
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

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings>(
                json
            );
        Assert.NotNull(deserialized);

        bool expectedAutoCollection = true;
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate expectedCustomDueDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27");
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate expectedInvoiceDate =
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

        Assert.Equal(expectedAutoCollection, deserialized.AutoCollection);
        Assert.Equal(expectedCustomDueDate, deserialized.CustomDueDate);
        Assert.Equal(expectedInvoiceDate, deserialized.InvoiceDate);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedNetTerms, deserialized.NetTerms);
        Assert.Equal(expectedRequireSuccessfulPayment, deserialized.RequireSuccessfulPayment);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
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
        };

        Assert.Null(model.RequireSuccessfulPayment);
        Assert.False(model.RawData.ContainsKey("require_successful_payment"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
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

            // Null should be interpreted as omitted for these properties
            RequireSuccessfulPayment = null,
        };

        Assert.Null(model.RequireSuccessfulPayment);
        Assert.False(model.RawData.ContainsKey("require_successful_payment"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
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

            // Null should be interpreted as omitted for these properties
            RequireSuccessfulPayment = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
        {
            AutoCollection = true,
            RequireSuccessfulPayment = true,
        };

        Assert.Null(model.CustomDueDate);
        Assert.False(model.RawData.ContainsKey("custom_due_date"));
        Assert.Null(model.InvoiceDate);
        Assert.False(model.RawData.ContainsKey("invoice_date"));
        Assert.Null(model.ItemID);
        Assert.False(model.RawData.ContainsKey("item_id"));
        Assert.Null(model.Memo);
        Assert.False(model.RawData.ContainsKey("memo"));
        Assert.Null(model.NetTerms);
        Assert.False(model.RawData.ContainsKey("net_terms"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
        {
            AutoCollection = true,
            RequireSuccessfulPayment = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
        {
            AutoCollection = true,
            RequireSuccessfulPayment = true,

            CustomDueDate = null,
            InvoiceDate = null,
            ItemID = null,
            Memo = null,
            NetTerms = null,
        };

        Assert.Null(model.CustomDueDate);
        Assert.True(model.RawData.ContainsKey("custom_due_date"));
        Assert.Null(model.InvoiceDate);
        Assert.True(model.RawData.ContainsKey("invoice_date"));
        Assert.Null(model.ItemID);
        Assert.True(model.RawData.ContainsKey("item_id"));
        Assert.Null(model.Memo);
        Assert.True(model.RawData.ContainsKey("memo"));
        Assert.Null(model.NetTerms);
        Assert.True(model.RawData.ContainsKey("net_terms"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
        {
            AutoCollection = true,
            RequireSuccessfulPayment = true,

            CustomDueDate = null,
            InvoiceDate = null,
            ItemID = null,
            Memo = null,
            NetTerms = null,
        };

        model.Validate();
    }
}

public class LedgerCreateEntryByExternalIDParamsBodyDecrementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyDecrement
        {
            Amount = 0,
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyDecrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyDecrement>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyDecrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyDecrement>(json);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"decrement\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, deserialized.EntryType));
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyDecrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyDecrement { Amount = 0 };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyDecrement { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyDecrement
        {
            Amount = 0,

            Currency = null,
            Description = null,
            Metadata = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyDecrement
        {
            Amount = 0,

            Currency = null,
            Description = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class LedgerCreateEntryByExternalIDParamsBodyExpirationChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyExpirationChange
        {
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyExpirationChange
        {
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

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyExpirationChange>(
                json
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyExpirationChange
        {
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

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyExpirationChange>(
                json
            );
        Assert.NotNull(deserialized);

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

        Assert.True(JsonElement.DeepEquals(expectedEntryType, deserialized.EntryType));
        Assert.Equal(expectedTargetExpiryDate, deserialized.TargetExpiryDate);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBlockID, deserialized.BlockID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyExpirationChange
        {
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyExpirationChange
        {
            TargetExpiryDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BlockID);
        Assert.False(model.RawData.ContainsKey("block_id"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExpiryDate);
        Assert.False(model.RawData.ContainsKey("expiry_date"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyExpirationChange
        {
            TargetExpiryDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyExpirationChange
        {
            TargetExpiryDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),

            Amount = null,
            BlockID = null,
            Currency = null,
            Description = null,
            ExpiryDate = null,
            Metadata = null,
        };

        Assert.Null(model.Amount);
        Assert.True(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BlockID);
        Assert.True(model.RawData.ContainsKey("block_id"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExpiryDate);
        Assert.True(model.RawData.ContainsKey("expiry_date"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyExpirationChange
        {
            TargetExpiryDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),

            Amount = null,
            BlockID = null,
            Currency = null,
            Description = null,
            ExpiryDate = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class LedgerCreateEntryByExternalIDParamsBodyVoidTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyVoid
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason.Refund,
        };

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"void\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason> expectedVoidReason =
            LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason.Refund;

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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyVoid
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason.Refund,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyVoid>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyVoid
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason.Refund,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyVoid>(
            json
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"void\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason> expectedVoidReason =
            LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason.Refund;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBlockID, deserialized.BlockID);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, deserialized.EntryType));
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedVoidReason, deserialized.VoidReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyVoid
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason.Refund,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyVoid
        {
            Amount = 0,
            BlockID = "block_id",
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.VoidReason);
        Assert.False(model.RawData.ContainsKey("void_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyVoid
        {
            Amount = 0,
            BlockID = "block_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyVoid
        {
            Amount = 0,
            BlockID = "block_id",

            Currency = null,
            Description = null,
            Metadata = null,
            VoidReason = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.VoidReason);
        Assert.True(model.RawData.ContainsKey("void_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyVoid
        {
            Amount = 0,
            BlockID = "block_id",

            Currency = null,
            Description = null,
            Metadata = null,
            VoidReason = null,
        };

        model.Validate();
    }
}

public class LedgerCreateEntryByExternalIDParamsBodyAmendmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyAmendment
        {
            Amount = 0,
            BlockID = "block_id",
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyAmendment
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyAmendment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyAmendment
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyAmendment>(json);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.Deserialize<JsonElement>("\"amendment\"");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBlockID, deserialized.BlockID);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, deserialized.EntryType));
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyAmendment
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyAmendment
        {
            Amount = 0,
            BlockID = "block_id",
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyAmendment
        {
            Amount = 0,
            BlockID = "block_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyAmendment
        {
            Amount = 0,
            BlockID = "block_id",

            Currency = null,
            Description = null,
            Metadata = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LedgerCreateEntryByExternalIDParamsBodyAmendment
        {
            Amount = 0,
            BlockID = "block_id",

            Currency = null,
            Description = null,
            Metadata = null,
        };

        model.Validate();
    }
}
