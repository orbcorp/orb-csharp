using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewMinimumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            AppliesToAll = NewMinimumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMinimumFilterField.PriceID,
                    Operator = NewMinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMinimumPriceType.Usage,
        };

        ApiEnum<string, NewMinimumAdjustmentType> expectedAdjustmentType =
            NewMinimumAdjustmentType.Minimum;
        string expectedItemID = "item_id";
        string expectedMinimumAmount = "minimum_amount";
        ApiEnum<bool, NewMinimumAppliesToAll> expectedAppliesToAll = NewMinimumAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewMinimumFilter> expectedFilters =
        [
            new()
            {
                Field = NewMinimumFilterField.PriceID,
                Operator = NewMinimumFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewMinimumPriceType> expectedPriceType = NewMinimumPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedMinimumAmount, model.MinimumAmount);
        Assert.Equal(expectedAppliesToAll, model.AppliesToAll);
        Assert.NotNull(model.AppliesToItemIDs);
        Assert.Equal(expectedAppliesToItemIDs.Count, model.AppliesToItemIDs.Count);
        for (int i = 0; i < expectedAppliesToItemIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIDs[i], model.AppliesToItemIDs[i]);
        }
        Assert.NotNull(model.AppliesToPriceIDs);
        Assert.Equal(expectedAppliesToPriceIDs.Count, model.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], model.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.NotNull(model.Filters);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, model.IsInvoiceLevel);
        Assert.Equal(expectedPriceType, model.PriceType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            AppliesToAll = NewMinimumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMinimumFilterField.PriceID,
                    Operator = NewMinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMinimumPriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewMinimum>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            AppliesToAll = NewMinimumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMinimumFilterField.PriceID,
                    Operator = NewMinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMinimumPriceType.Usage,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewMinimum>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewMinimumAdjustmentType> expectedAdjustmentType =
            NewMinimumAdjustmentType.Minimum;
        string expectedItemID = "item_id";
        string expectedMinimumAmount = "minimum_amount";
        ApiEnum<bool, NewMinimumAppliesToAll> expectedAppliesToAll = NewMinimumAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewMinimumFilter> expectedFilters =
        [
            new()
            {
                Field = NewMinimumFilterField.PriceID,
                Operator = NewMinimumFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewMinimumPriceType> expectedPriceType = NewMinimumPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedAppliesToAll, deserialized.AppliesToAll);
        Assert.NotNull(deserialized.AppliesToItemIDs);
        Assert.Equal(expectedAppliesToItemIDs.Count, deserialized.AppliesToItemIDs.Count);
        for (int i = 0; i < expectedAppliesToItemIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIDs[i], deserialized.AppliesToItemIDs[i]);
        }
        Assert.NotNull(deserialized.AppliesToPriceIDs);
        Assert.Equal(expectedAppliesToPriceIDs.Count, deserialized.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], deserialized.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.NotNull(deserialized.Filters);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedIsInvoiceLevel, deserialized.IsInvoiceLevel);
        Assert.Equal(expectedPriceType, deserialized.PriceType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            AppliesToAll = NewMinimumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMinimumFilterField.PriceID,
                    Operator = NewMinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMinimumPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            AppliesToAll = NewMinimumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMinimumFilterField.PriceID,
                    Operator = NewMinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewMinimumPriceType.Usage,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            AppliesToAll = NewMinimumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMinimumFilterField.PriceID,
                    Operator = NewMinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewMinimumPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            AppliesToAll = NewMinimumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMinimumFilterField.PriceID,
                    Operator = NewMinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewMinimumPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            AppliesToAll = NewMinimumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMinimumFilterField.PriceID,
                    Operator = NewMinimumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewMinimumPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            IsInvoiceLevel = true,
        };

        Assert.Null(model.AppliesToAll);
        Assert.False(model.RawData.ContainsKey("applies_to_all"));
        Assert.Null(model.AppliesToItemIDs);
        Assert.False(model.RawData.ContainsKey("applies_to_item_ids"));
        Assert.Null(model.AppliesToPriceIDs);
        Assert.False(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Filters);
        Assert.False(model.RawData.ContainsKey("filters"));
        Assert.Null(model.PriceType);
        Assert.False(model.RawData.ContainsKey("price_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            IsInvoiceLevel = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            IsInvoiceLevel = true,

            AppliesToAll = null,
            AppliesToItemIDs = null,
            AppliesToPriceIDs = null,
            Currency = null,
            Filters = null,
            PriceType = null,
        };

        Assert.Null(model.AppliesToAll);
        Assert.True(model.RawData.ContainsKey("applies_to_all"));
        Assert.Null(model.AppliesToItemIDs);
        Assert.True(model.RawData.ContainsKey("applies_to_item_ids"));
        Assert.Null(model.AppliesToPriceIDs);
        Assert.True(model.RawData.ContainsKey("applies_to_price_ids"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Filters);
        Assert.True(model.RawData.ContainsKey("filters"));
        Assert.Null(model.PriceType);
        Assert.True(model.RawData.ContainsKey("price_type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewMinimum
        {
            AdjustmentType = NewMinimumAdjustmentType.Minimum,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            IsInvoiceLevel = true,

            AppliesToAll = null,
            AppliesToItemIDs = null,
            AppliesToPriceIDs = null,
            Currency = null,
            Filters = null,
            PriceType = null,
        };

        model.Validate();
    }
}

public class NewMinimumAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(NewMinimumAdjustmentType.Minimum)]
    public void Validation_Works(NewMinimumAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMinimumAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumAdjustmentType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMinimumAdjustmentType.Minimum)]
    public void SerializationRoundtrip_Works(NewMinimumAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMinimumAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumAdjustmentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumAdjustmentType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumAdjustmentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewMinimumAppliesToAllTest : TestBase
{
    [Theory]
    [InlineData(NewMinimumAppliesToAll.True)]
    public void Validation_Works(NewMinimumAppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, NewMinimumAppliesToAll> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, NewMinimumAppliesToAll>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMinimumAppliesToAll.True)]
    public void SerializationRoundtrip_Works(NewMinimumAppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, NewMinimumAppliesToAll> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, NewMinimumAppliesToAll>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, NewMinimumAppliesToAll>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, NewMinimumAppliesToAll>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewMinimumFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewMinimumFilter
        {
            Field = NewMinimumFilterField.PriceID,
            Operator = NewMinimumFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, NewMinimumFilterField> expectedField = NewMinimumFilterField.PriceID;
        ApiEnum<string, NewMinimumFilterOperator> expectedOperator =
            NewMinimumFilterOperator.Includes;
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
        var model = new NewMinimumFilter
        {
            Field = NewMinimumFilterField.PriceID,
            Operator = NewMinimumFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewMinimumFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewMinimumFilter
        {
            Field = NewMinimumFilterField.PriceID,
            Operator = NewMinimumFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewMinimumFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewMinimumFilterField> expectedField = NewMinimumFilterField.PriceID;
        ApiEnum<string, NewMinimumFilterOperator> expectedOperator =
            NewMinimumFilterOperator.Includes;
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
        var model = new NewMinimumFilter
        {
            Field = NewMinimumFilterField.PriceID,
            Operator = NewMinimumFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class NewMinimumFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(NewMinimumFilterField.PriceID)]
    [InlineData(NewMinimumFilterField.ItemID)]
    [InlineData(NewMinimumFilterField.PriceType)]
    [InlineData(NewMinimumFilterField.Currency)]
    [InlineData(NewMinimumFilterField.PricingUnitID)]
    public void Validation_Works(NewMinimumFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMinimumFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMinimumFilterField.PriceID)]
    [InlineData(NewMinimumFilterField.ItemID)]
    [InlineData(NewMinimumFilterField.PriceType)]
    [InlineData(NewMinimumFilterField.Currency)]
    [InlineData(NewMinimumFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(NewMinimumFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMinimumFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewMinimumFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(NewMinimumFilterOperator.Includes)]
    [InlineData(NewMinimumFilterOperator.Excludes)]
    public void Validation_Works(NewMinimumFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMinimumFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMinimumFilterOperator.Includes)]
    [InlineData(NewMinimumFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(NewMinimumFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMinimumFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewMinimumPriceTypeTest : TestBase
{
    [Theory]
    [InlineData(NewMinimumPriceType.Usage)]
    [InlineData(NewMinimumPriceType.FixedInAdvance)]
    [InlineData(NewMinimumPriceType.FixedInArrears)]
    [InlineData(NewMinimumPriceType.Fixed)]
    [InlineData(NewMinimumPriceType.InArrears)]
    public void Validation_Works(NewMinimumPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMinimumPriceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMinimumPriceType.Usage)]
    [InlineData(NewMinimumPriceType.FixedInAdvance)]
    [InlineData(NewMinimumPriceType.FixedInArrears)]
    [InlineData(NewMinimumPriceType.Fixed)]
    [InlineData(NewMinimumPriceType.InArrears)]
    public void SerializationRoundtrip_Works(NewMinimumPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMinimumPriceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMinimumPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
