using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewUsageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewUsageDiscountFilterField.PriceID,
                    Operator = NewUsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        ApiEnum<string, NewUsageDiscountAdjustmentType> expectedAdjustmentType =
            NewUsageDiscountAdjustmentType.UsageDiscount;
        double expectedUsageDiscount = 0;
        ApiEnum<bool, NewUsageDiscountAppliesToAll> expectedAppliesToAll =
            NewUsageDiscountAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewUsageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = NewUsageDiscountFilterField.PriceID,
                Operator = NewUsageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewUsageDiscountPriceType> expectedPriceType =
            NewUsageDiscountPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
        Assert.Equal(expectedAppliesToAll, model.AppliesToAll);
        Assert.Equal(expectedAppliesToItemIDs.Count, model.AppliesToItemIDs.Count);
        for (int i = 0; i < expectedAppliesToItemIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIDs[i], model.AppliesToItemIDs[i]);
        }
        Assert.Equal(expectedAppliesToPriceIDs.Count, model.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], model.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
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
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewUsageDiscountFilterField.PriceID,
                    Operator = NewUsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewUsageDiscountFilterField.PriceID,
                    Operator = NewUsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewUsageDiscount>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewUsageDiscountAdjustmentType> expectedAdjustmentType =
            NewUsageDiscountAdjustmentType.UsageDiscount;
        double expectedUsageDiscount = 0;
        ApiEnum<bool, NewUsageDiscountAppliesToAll> expectedAppliesToAll =
            NewUsageDiscountAppliesToAll.True;
        List<string> expectedAppliesToItemIDs = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIDs = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewUsageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = NewUsageDiscountFilterField.PriceID,
                Operator = NewUsageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewUsageDiscountPriceType> expectedPriceType =
            NewUsageDiscountPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
        Assert.Equal(expectedAppliesToAll, deserialized.AppliesToAll);
        Assert.Equal(expectedAppliesToItemIDs.Count, deserialized.AppliesToItemIDs.Count);
        for (int i = 0; i < expectedAppliesToItemIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIDs[i], deserialized.AppliesToItemIDs[i]);
        }
        Assert.Equal(expectedAppliesToPriceIDs.Count, deserialized.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], deserialized.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedCurrency, deserialized.Currency);
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
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewUsageDiscountFilterField.PriceID,
                    Operator = NewUsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewUsageDiscountFilterField.PriceID,
                    Operator = NewUsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewUsageDiscountFilterField.PriceID,
                    Operator = NewUsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewUsageDiscountPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewUsageDiscountFilterField.PriceID,
                    Operator = NewUsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewUsageDiscountPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            AppliesToAll = NewUsageDiscountAppliesToAll.True,
            AppliesToItemIDs = ["item_1", "item_2"],
            AppliesToPriceIDs = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewUsageDiscountFilterField.PriceID,
                    Operator = NewUsageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewUsageDiscountPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
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
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
            IsInvoiceLevel = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
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
        var model = new NewUsageDiscount
        {
            AdjustmentType = NewUsageDiscountAdjustmentType.UsageDiscount,
            UsageDiscount = 0,
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

public class NewUsageDiscountAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(NewUsageDiscountAdjustmentType.UsageDiscount)]
    public void Validation_Works(NewUsageDiscountAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewUsageDiscountAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountAdjustmentType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewUsageDiscountAdjustmentType.UsageDiscount)]
    public void SerializationRoundtrip_Works(NewUsageDiscountAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewUsageDiscountAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewUsageDiscountAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountAdjustmentType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewUsageDiscountAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewUsageDiscountAppliesToAllTest : TestBase
{
    [Theory]
    [InlineData(NewUsageDiscountAppliesToAll.True)]
    public void Validation_Works(NewUsageDiscountAppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, NewUsageDiscountAppliesToAll> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, NewUsageDiscountAppliesToAll>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewUsageDiscountAppliesToAll.True)]
    public void SerializationRoundtrip_Works(NewUsageDiscountAppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, NewUsageDiscountAppliesToAll> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, NewUsageDiscountAppliesToAll>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, NewUsageDiscountAppliesToAll>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, NewUsageDiscountAppliesToAll>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewUsageDiscountFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewUsageDiscountFilter
        {
            Field = NewUsageDiscountFilterField.PriceID,
            Operator = NewUsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, NewUsageDiscountFilterField> expectedField =
            NewUsageDiscountFilterField.PriceID;
        ApiEnum<string, NewUsageDiscountFilterOperator> expectedOperator =
            NewUsageDiscountFilterOperator.Includes;
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
        var model = new NewUsageDiscountFilter
        {
            Field = NewUsageDiscountFilterField.PriceID,
            Operator = NewUsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewUsageDiscountFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewUsageDiscountFilter
        {
            Field = NewUsageDiscountFilterField.PriceID,
            Operator = NewUsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewUsageDiscountFilter>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, NewUsageDiscountFilterField> expectedField =
            NewUsageDiscountFilterField.PriceID;
        ApiEnum<string, NewUsageDiscountFilterOperator> expectedOperator =
            NewUsageDiscountFilterOperator.Includes;
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
        var model = new NewUsageDiscountFilter
        {
            Field = NewUsageDiscountFilterField.PriceID,
            Operator = NewUsageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class NewUsageDiscountFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(NewUsageDiscountFilterField.PriceID)]
    [InlineData(NewUsageDiscountFilterField.ItemID)]
    [InlineData(NewUsageDiscountFilterField.PriceType)]
    [InlineData(NewUsageDiscountFilterField.Currency)]
    [InlineData(NewUsageDiscountFilterField.PricingUnitID)]
    public void Validation_Works(NewUsageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewUsageDiscountFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewUsageDiscountFilterField.PriceID)]
    [InlineData(NewUsageDiscountFilterField.ItemID)]
    [InlineData(NewUsageDiscountFilterField.PriceType)]
    [InlineData(NewUsageDiscountFilterField.Currency)]
    [InlineData(NewUsageDiscountFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(NewUsageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewUsageDiscountFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountFilterField>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewUsageDiscountFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(NewUsageDiscountFilterOperator.Includes)]
    [InlineData(NewUsageDiscountFilterOperator.Excludes)]
    public void Validation_Works(NewUsageDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewUsageDiscountFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewUsageDiscountFilterOperator.Includes)]
    [InlineData(NewUsageDiscountFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(NewUsageDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewUsageDiscountFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewUsageDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountFilterOperator>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewUsageDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewUsageDiscountPriceTypeTest : TestBase
{
    [Theory]
    [InlineData(NewUsageDiscountPriceType.Usage)]
    [InlineData(NewUsageDiscountPriceType.FixedInAdvance)]
    [InlineData(NewUsageDiscountPriceType.FixedInArrears)]
    [InlineData(NewUsageDiscountPriceType.Fixed)]
    [InlineData(NewUsageDiscountPriceType.InArrears)]
    public void Validation_Works(NewUsageDiscountPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewUsageDiscountPriceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewUsageDiscountPriceType.Usage)]
    [InlineData(NewUsageDiscountPriceType.FixedInAdvance)]
    [InlineData(NewUsageDiscountPriceType.FixedInArrears)]
    [InlineData(NewUsageDiscountPriceType.Fixed)]
    [InlineData(NewUsageDiscountPriceType.InArrears)]
    public void SerializationRoundtrip_Works(NewUsageDiscountPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewUsageDiscountPriceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountPriceType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NewUsageDiscountPriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
