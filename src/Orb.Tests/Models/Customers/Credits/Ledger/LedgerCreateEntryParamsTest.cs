using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Ledger = Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class LedgerCreateEntryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Ledger::LedgerCreateEntryParams
        {
            CustomerID = "customer_id",
            Body = new Ledger::Increment()
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
                        Field = Ledger::Field.ItemID,
                        Operator = Ledger::Operator.Includes,
                        Values = ["string"],
                    },
                ],
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    CustomDueDate = "2019-12-27",
                    InvoiceDate = "2019-12-27",
                    ItemID = "item_id",
                    Memo = "memo",
                    NetTerms = 0,
                    RequireSuccessfulPayment = true,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
            },
        };

        string expectedCustomerID = "customer_id";
        Ledger::Body expectedBody = new Ledger::Increment()
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
                    Field = Ledger::Field.ItemID,
                    Operator = Ledger::Operator.Includes,
                    Values = ["string"],
                },
            ],
            InvoiceSettings = new()
            {
                AutoCollection = true,
                CustomDueDate = "2019-12-27",
                InvoiceDate = "2019-12-27",
                ItemID = "item_id",
                Memo = "memo",
                NetTerms = 0,
                RequireSuccessfulPayment = true,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        Ledger::LedgerCreateEntryParams parameters = new()
        {
            CustomerID = "customer_id",
            Body = new Ledger::Increment()
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
                        Field = Ledger::Field.ItemID,
                        Operator = Ledger::Operator.Includes,
                        Values = ["string"],
                    },
                ],
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    CustomDueDate = "2019-12-27",
                    InvoiceDate = "2019-12-27",
                    ItemID = "item_id",
                    Memo = "memo",
                    NetTerms = 0,
                    RequireSuccessfulPayment = true,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.withorb.com/v1/customers/customer_id/credits/ledger_entry"),
            url
        );
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void IncrementValidationWorks()
    {
        Ledger::Body value = new(
            new Ledger::Increment()
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
                        Field = Ledger::Field.ItemID,
                        Operator = Ledger::Operator.Includes,
                        Values = ["string"],
                    },
                ],
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    CustomDueDate = "2019-12-27",
                    InvoiceDate = "2019-12-27",
                    ItemID = "item_id",
                    Memo = "memo",
                    NetTerms = 0,
                    RequireSuccessfulPayment = true,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
            }
        );
        value.Validate();
    }

    [Fact]
    public void DecrementValidationWorks()
    {
        Ledger::Body value = new(
            new Ledger::Decrement()
            {
                Amount = 0,
                Currency = "currency",
                Description = "description",
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void ExpirationChangeValidationWorks()
    {
        Ledger::Body value = new(
            new Ledger::ExpirationChange()
            {
                TargetExpiryDate = "2019-12-27",
                Amount = 0,
                BlockID = "block_id",
                Currency = "currency",
                Description = "description",
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void VoidValidationWorks()
    {
        Ledger::Body value = new(
            new Ledger::Void()
            {
                Amount = 0,
                BlockID = "block_id",
                Currency = "currency",
                Description = "description",
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                VoidReason = Ledger::VoidReason.Refund,
            }
        );
        value.Validate();
    }

    [Fact]
    public void AmendmentValidationWorks()
    {
        Ledger::Body value = new(
            new Ledger::Amendment()
            {
                Amount = 0,
                BlockID = "block_id",
                Currency = "currency",
                Description = "description",
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        value.Validate();
    }

    [Fact]
    public void IncrementSerializationRoundtripWorks()
    {
        Ledger::Body value = new(
            new Ledger::Increment()
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
                        Field = Ledger::Field.ItemID,
                        Operator = Ledger::Operator.Includes,
                        Values = ["string"],
                    },
                ],
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    CustomDueDate = "2019-12-27",
                    InvoiceDate = "2019-12-27",
                    ItemID = "item_id",
                    Memo = "memo",
                    NetTerms = 0,
                    RequireSuccessfulPayment = true,
                },
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                PerUnitCostBasis = "per_unit_cost_basis",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::Body>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DecrementSerializationRoundtripWorks()
    {
        Ledger::Body value = new(
            new Ledger::Decrement()
            {
                Amount = 0,
                Currency = "currency",
                Description = "description",
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::Body>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExpirationChangeSerializationRoundtripWorks()
    {
        Ledger::Body value = new(
            new Ledger::ExpirationChange()
            {
                TargetExpiryDate = "2019-12-27",
                Amount = 0,
                BlockID = "block_id",
                Currency = "currency",
                Description = "description",
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::Body>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VoidSerializationRoundtripWorks()
    {
        Ledger::Body value = new(
            new Ledger::Void()
            {
                Amount = 0,
                BlockID = "block_id",
                Currency = "currency",
                Description = "description",
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
                VoidReason = Ledger::VoidReason.Refund,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::Body>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AmendmentSerializationRoundtripWorks()
    {
        Ledger::Body value = new(
            new Ledger::Amendment()
            {
                Amount = 0,
                BlockID = "block_id",
                Currency = "currency",
                Description = "description",
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::Body>(element);

        Assert.Equal(value, deserialized);
    }
}

public class IncrementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::Increment
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
                    Field = Ledger::Field.ItemID,
                    Operator = Ledger::Operator.Includes,
                    Values = ["string"],
                },
            ],
            InvoiceSettings = new()
            {
                AutoCollection = true,
                CustomDueDate = "2019-12-27",
                InvoiceDate = "2019-12-27",
                ItemID = "item_id",
                Memo = "memo",
                NetTerms = 0,
                RequireSuccessfulPayment = true,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        double expectedAmount = 0;
        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("increment");
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
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
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
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedInvoiceSettings, model.InvoiceSettings);
        Assert.NotNull(model.Metadata);
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
        var model = new Ledger::Increment
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
                    Field = Ledger::Field.ItemID,
                    Operator = Ledger::Operator.Includes,
                    Values = ["string"],
                },
            ],
            InvoiceSettings = new()
            {
                AutoCollection = true,
                CustomDueDate = "2019-12-27",
                InvoiceDate = "2019-12-27",
                ItemID = "item_id",
                Memo = "memo",
                NetTerms = 0,
                RequireSuccessfulPayment = true,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Increment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ledger::Increment
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
                    Field = Ledger::Field.ItemID,
                    Operator = Ledger::Operator.Includes,
                    Values = ["string"],
                },
            ],
            InvoiceSettings = new()
            {
                AutoCollection = true,
                CustomDueDate = "2019-12-27",
                InvoiceDate = "2019-12-27",
                ItemID = "item_id",
                Memo = "memo",
                NetTerms = 0,
                RequireSuccessfulPayment = true,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Increment>(element);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("increment");
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
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
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
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedInvoiceSettings, deserialized.InvoiceSettings);
        Assert.NotNull(deserialized.Metadata);
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
        var model = new Ledger::Increment
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
                    Field = Ledger::Field.ItemID,
                    Operator = Ledger::Operator.Includes,
                    Values = ["string"],
                },
            ],
            InvoiceSettings = new()
            {
                AutoCollection = true,
                CustomDueDate = "2019-12-27",
                InvoiceDate = "2019-12-27",
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
        var model = new Ledger::Increment { Amount = 0 };

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
        var model = new Ledger::Increment { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Ledger::Increment
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
        var model = new Ledger::Increment
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Ledger::Filter
        {
            Field = Ledger::Field.ItemID,
            Operator = Ledger::Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Filter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ledger::Filter
        {
            Field = Ledger::Field.ItemID,
            Operator = Ledger::Operator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Filter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, Ledger::Field> expectedField = Ledger::Field.ItemID;
        ApiEnum<string, Ledger::Operator> expectedOperator = Ledger::Operator.Includes;
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
        var model = new Ledger::Filter
        {
            Field = Ledger::Field.ItemID,
            Operator = Ledger::Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class FieldTest : TestBase
{
    [Theory]
    [InlineData(Ledger::Field.ItemID)]
    public void Validation_Works(Ledger::Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Ledger::Field> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Ledger::Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Ledger::Field.ItemID)]
    public void SerializationRoundtrip_Works(Ledger::Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Ledger::Field> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Ledger::Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Ledger::Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Ledger::Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Ledger::Operator.Includes)]
    [InlineData(Ledger::Operator.Excludes)]
    public void Validation_Works(Ledger::Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Ledger::Operator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Ledger::Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Ledger::Operator.Includes)]
    [InlineData(Ledger::Operator.Excludes)]
    public void SerializationRoundtrip_Works(Ledger::Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Ledger::Operator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Ledger::Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Ledger::Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Ledger::Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
            ItemID = "item_id",
            Memo = "memo",
            NetTerms = 0,
            RequireSuccessfulPayment = true,
        };

        bool expectedAutoCollection = true;
        Ledger::CustomDueDate expectedCustomDueDate = "2019-12-27";
        Ledger::InvoiceDate expectedInvoiceDate = "2019-12-27";
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
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
            ItemID = "item_id",
            Memo = "memo",
            NetTerms = 0,
            RequireSuccessfulPayment = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::InvoiceSettings>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
            ItemID = "item_id",
            Memo = "memo",
            NetTerms = 0,
            RequireSuccessfulPayment = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::InvoiceSettings>(element);
        Assert.NotNull(deserialized);

        bool expectedAutoCollection = true;
        Ledger::CustomDueDate expectedCustomDueDate = "2019-12-27";
        Ledger::InvoiceDate expectedInvoiceDate = "2019-12-27";
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
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
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
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
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
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
            ItemID = "item_id",
            Memo = "memo",
            NetTerms = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
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
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            CustomDueDate = "2019-12-27",
            InvoiceDate = "2019-12-27",
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
        var model = new Ledger::InvoiceSettings
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
        var model = new Ledger::InvoiceSettings
        {
            AutoCollection = true,
            RequireSuccessfulPayment = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Ledger::InvoiceSettings
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
        var model = new Ledger::InvoiceSettings
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

public class CustomDueDateTest : TestBase
{
    [Fact]
    public void DateValidationWorks()
    {
        Ledger::CustomDueDate value = new("2019-12-27");
        value.Validate();
    }

    [Fact]
    public void DateTimeValidationWorks()
    {
        Ledger::CustomDueDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        value.Validate();
    }

    [Fact]
    public void DateSerializationRoundtripWorks()
    {
        Ledger::CustomDueDate value = new("2019-12-27");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::CustomDueDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Ledger::CustomDueDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::CustomDueDate>(element);

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceDateTest : TestBase
{
    [Fact]
    public void DateValidationWorks()
    {
        Ledger::InvoiceDate value = new("2019-12-27");
        value.Validate();
    }

    [Fact]
    public void DateTimeValidationWorks()
    {
        Ledger::InvoiceDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        value.Validate();
    }

    [Fact]
    public void DateSerializationRoundtripWorks()
    {
        Ledger::InvoiceDate value = new("2019-12-27");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::InvoiceDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        Ledger::InvoiceDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Ledger::InvoiceDate>(element);

        Assert.Equal(value, deserialized);
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
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        double expectedAmount = 0;
        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("decrement");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, model.Amount);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, model.EntryType));
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Metadata);
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
        var model = new Ledger::Decrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Decrement>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ledger::Decrement
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Decrement>(element);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("decrement");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, deserialized.EntryType));
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Metadata);
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
        var model = new Ledger::Decrement
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
        var model = new Ledger::Decrement { Amount = 0 };

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
        var model = new Ledger::Decrement { Amount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Ledger::Decrement
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
        var model = new Ledger::Decrement
        {
            Amount = 0,

            Currency = null,
            Description = null,
            Metadata = null,
        };

        model.Validate();
    }
}

public class ExpirationChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::ExpirationChange
        {
            TargetExpiryDate = "2019-12-27",
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("expiration_change");
        string expectedTargetExpiryDate = "2019-12-27";
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
        Assert.NotNull(model.Metadata);
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
        var model = new Ledger::ExpirationChange
        {
            TargetExpiryDate = "2019-12-27",
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::ExpirationChange>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ledger::ExpirationChange
        {
            TargetExpiryDate = "2019-12-27",
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::ExpirationChange>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("expiration_change");
        string expectedTargetExpiryDate = "2019-12-27";
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
        Assert.NotNull(deserialized.Metadata);
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
        var model = new Ledger::ExpirationChange
        {
            TargetExpiryDate = "2019-12-27",
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
        var model = new Ledger::ExpirationChange { TargetExpiryDate = "2019-12-27" };

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
        var model = new Ledger::ExpirationChange { TargetExpiryDate = "2019-12-27" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Ledger::ExpirationChange
        {
            TargetExpiryDate = "2019-12-27",

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
        var model = new Ledger::ExpirationChange
        {
            TargetExpiryDate = "2019-12-27",

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

public class VoidTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ledger::Void
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = Ledger::VoidReason.Refund,
        };

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("void");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Ledger::VoidReason> expectedVoidReason = Ledger::VoidReason.Refund;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBlockID, model.BlockID);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, model.EntryType));
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Metadata);
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
        var model = new Ledger::Void
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = Ledger::VoidReason.Refund,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Void>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ledger::Void
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = Ledger::VoidReason.Refund,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Void>(element);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("void");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Ledger::VoidReason> expectedVoidReason = Ledger::VoidReason.Refund;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBlockID, deserialized.BlockID);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, deserialized.EntryType));
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Metadata);
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
        var model = new Ledger::Void
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            VoidReason = Ledger::VoidReason.Refund,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Ledger::Void { Amount = 0, BlockID = "block_id" };

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
        var model = new Ledger::Void { Amount = 0, BlockID = "block_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Ledger::Void
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
        var model = new Ledger::Void
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

public class VoidReasonTest : TestBase
{
    [Theory]
    [InlineData(Ledger::VoidReason.Refund)]
    public void Validation_Works(Ledger::VoidReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Ledger::VoidReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Ledger::VoidReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Ledger::VoidReason.Refund)]
    public void SerializationRoundtrip_Works(Ledger::VoidReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Ledger::VoidReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Ledger::VoidReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Ledger::VoidReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Ledger::VoidReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("amendment");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBlockID, model.BlockID);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, model.EntryType));
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Metadata);
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
        var model = new Ledger::Amendment
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Amendment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ledger::Amendment
        {
            Amount = 0,
            BlockID = "block_id",
            Currency = "currency",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Ledger::Amendment>(element);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedBlockID = "block_id";
        JsonElement expectedEntryType = JsonSerializer.SerializeToElement("amendment");
        string expectedCurrency = "currency";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBlockID, deserialized.BlockID);
        Assert.True(JsonElement.DeepEquals(expectedEntryType, deserialized.EntryType));
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Metadata);
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
        var model = new Ledger::Amendment
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
        var model = new Ledger::Amendment { Amount = 0, BlockID = "block_id" };

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
        var model = new Ledger::Amendment { Amount = 0, BlockID = "block_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Ledger::Amendment
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
        var model = new Ledger::Amendment
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
