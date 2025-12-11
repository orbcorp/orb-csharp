using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewMaximumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMaximumFilterField.PriceID,
                    Operator = NewMaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMaximumPriceType.Usage,
        };

        ApiEnum<string, NewMaximumAdjustmentType> expectedAdjustmentType =
            NewMaximumAdjustmentType.Maximum;
        string expectedMaximumAmount = "maximum_amount";
        ApiEnum<bool, NewMaximumAppliesToAll> expectedAppliesToAll = NewMaximumAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewMaximumFilter> expectedFilters =
        [
            new()
            {
                Field = NewMaximumFilterField.PriceID,
                Operator = NewMaximumFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewMaximumPriceType> expectedPriceType = NewMaximumPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
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
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMaximumFilterField.PriceID,
                    Operator = NewMaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMaximumPriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewMaximum>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMaximumFilterField.PriceID,
                    Operator = NewMaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMaximumPriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewMaximum>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewMaximumAdjustmentType> expectedAdjustmentType =
            NewMaximumAdjustmentType.Maximum;
        string expectedMaximumAmount = "maximum_amount";
        ApiEnum<bool, NewMaximumAppliesToAll> expectedAppliesToAll = NewMaximumAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewMaximumFilter> expectedFilters =
        [
            new()
            {
                Field = NewMaximumFilterField.PriceID,
                Operator = NewMaximumFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewMaximumPriceType> expectedPriceType = NewMaximumPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
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
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMaximumFilterField.PriceID,
                    Operator = NewMaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewMaximumPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMaximumFilterField.PriceID,
                    Operator = NewMaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewMaximumPriceType.Usage,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMaximumFilterField.PriceID,
                    Operator = NewMaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewMaximumPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMaximumFilterField.PriceID,
                    Operator = NewMaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewMaximumPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            AppliesToAll = NewMaximumAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewMaximumFilterField.PriceID,
                    Operator = NewMaximumFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewMaximumPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
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
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
            IsInvoiceLevel = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
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
        var model = new NewMaximum
        {
            AdjustmentType = NewMaximumAdjustmentType.Maximum,
            MaximumAmount = "maximum_amount",
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

public class NewMaximumAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(NewMaximumAdjustmentType.Maximum)]
    public void Validation_Works(NewMaximumAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMaximumAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumAdjustmentType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMaximumAdjustmentType.Maximum)]
    public void SerializationRoundtrip_Works(NewMaximumAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMaximumAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumAdjustmentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumAdjustmentType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumAdjustmentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewMaximumAppliesToAllTest : TestBase
{
    [Theory]
    [InlineData(NewMaximumAppliesToAll.True)]
    public void Validation_Works(NewMaximumAppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, NewMaximumAppliesToAll> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, NewMaximumAppliesToAll>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMaximumAppliesToAll.True)]
    public void SerializationRoundtrip_Works(NewMaximumAppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, NewMaximumAppliesToAll> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, NewMaximumAppliesToAll>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, NewMaximumAppliesToAll>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, NewMaximumAppliesToAll>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewMaximumFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewMaximumFilter
        {
            Field = NewMaximumFilterField.PriceID,
            Operator = NewMaximumFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, NewMaximumFilterField> expectedField = NewMaximumFilterField.PriceID;
        ApiEnum<string, NewMaximumFilterOperator> expectedOperator =
            NewMaximumFilterOperator.Includes;
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
        var model = new NewMaximumFilter
        {
            Field = NewMaximumFilterField.PriceID,
            Operator = NewMaximumFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewMaximumFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewMaximumFilter
        {
            Field = NewMaximumFilterField.PriceID,
            Operator = NewMaximumFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewMaximumFilter>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewMaximumFilterField> expectedField = NewMaximumFilterField.PriceID;
        ApiEnum<string, NewMaximumFilterOperator> expectedOperator =
            NewMaximumFilterOperator.Includes;
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
        var model = new NewMaximumFilter
        {
            Field = NewMaximumFilterField.PriceID,
            Operator = NewMaximumFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class NewMaximumFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(NewMaximumFilterField.PriceID)]
    [InlineData(NewMaximumFilterField.ItemID)]
    [InlineData(NewMaximumFilterField.PriceType)]
    [InlineData(NewMaximumFilterField.Currency)]
    [InlineData(NewMaximumFilterField.PricingUnitID)]
    public void Validation_Works(NewMaximumFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMaximumFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMaximumFilterField.PriceID)]
    [InlineData(NewMaximumFilterField.ItemID)]
    [InlineData(NewMaximumFilterField.PriceType)]
    [InlineData(NewMaximumFilterField.Currency)]
    [InlineData(NewMaximumFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(NewMaximumFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMaximumFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewMaximumFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(NewMaximumFilterOperator.Includes)]
    [InlineData(NewMaximumFilterOperator.Excludes)]
    public void Validation_Works(NewMaximumFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMaximumFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMaximumFilterOperator.Includes)]
    [InlineData(NewMaximumFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(NewMaximumFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMaximumFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewMaximumPriceTypeTest : TestBase
{
    [Theory]
    [InlineData(NewMaximumPriceType.Usage)]
    [InlineData(NewMaximumPriceType.FixedInAdvance)]
    [InlineData(NewMaximumPriceType.FixedInArrears)]
    [InlineData(NewMaximumPriceType.Fixed)]
    [InlineData(NewMaximumPriceType.InArrears)]
    public void Validation_Works(NewMaximumPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMaximumPriceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewMaximumPriceType.Usage)]
    [InlineData(NewMaximumPriceType.FixedInAdvance)]
    [InlineData(NewMaximumPriceType.FixedInArrears)]
    [InlineData(NewMaximumPriceType.Fixed)]
    [InlineData(NewMaximumPriceType.InArrears)]
    public void SerializationRoundtrip_Works(NewMaximumPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewMaximumPriceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewMaximumPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
