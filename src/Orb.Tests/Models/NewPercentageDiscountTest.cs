using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewPercentageDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewPercentageDiscountFilterField.PriceID,
                    Operator = NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewPercentageDiscountPriceType.Usage,
        };

        ApiEnum<string, NewPercentageDiscountAdjustmentType> expectedAdjustmentType =
            NewPercentageDiscountAdjustmentType.PercentageDiscount;
        double expectedPercentageDiscount = 0;
        ApiEnum<bool, NewPercentageDiscountAppliesToAll> expectedAppliesToAll =
            NewPercentageDiscountAppliesToAll.True;
        List<string> expectedAppliesToItemIds = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIds = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewPercentageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = NewPercentageDiscountFilterField.PriceID,
                Operator = NewPercentageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewPercentageDiscountPriceType> expectedPriceType =
            NewPercentageDiscountPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedAppliesToAll, model.AppliesToAll);
        Assert.NotNull(model.AppliesToItemIds);
        Assert.Equal(expectedAppliesToItemIds.Count, model.AppliesToItemIds.Count);
        for (int i = 0; i < expectedAppliesToItemIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIds[i], model.AppliesToItemIds[i]);
        }
        Assert.NotNull(model.AppliesToPriceIds);
        Assert.Equal(expectedAppliesToPriceIds.Count, model.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], model.AppliesToPriceIds[i]);
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
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewPercentageDiscountFilterField.PriceID,
                    Operator = NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewPercentageDiscountPriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewPercentageDiscountFilterField.PriceID,
                    Operator = NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewPercentageDiscountPriceType.Usage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewPercentageDiscount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewPercentageDiscountAdjustmentType> expectedAdjustmentType =
            NewPercentageDiscountAdjustmentType.PercentageDiscount;
        double expectedPercentageDiscount = 0;
        ApiEnum<bool, NewPercentageDiscountAppliesToAll> expectedAppliesToAll =
            NewPercentageDiscountAppliesToAll.True;
        List<string> expectedAppliesToItemIds = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIds = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewPercentageDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = NewPercentageDiscountFilterField.PriceID,
                Operator = NewPercentageDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, NewPercentageDiscountPriceType> expectedPriceType =
            NewPercentageDiscountPriceType.Usage;

        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.Equal(expectedAppliesToAll, deserialized.AppliesToAll);
        Assert.NotNull(deserialized.AppliesToItemIds);
        Assert.Equal(expectedAppliesToItemIds.Count, deserialized.AppliesToItemIds.Count);
        for (int i = 0; i < expectedAppliesToItemIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToItemIds[i], deserialized.AppliesToItemIds[i]);
        }
        Assert.NotNull(deserialized.AppliesToPriceIds);
        Assert.Equal(expectedAppliesToPriceIds.Count, deserialized.AppliesToPriceIds.Count);
        for (int i = 0; i < expectedAppliesToPriceIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIds[i], deserialized.AppliesToPriceIds[i]);
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
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewPercentageDiscountFilterField.PriceID,
                    Operator = NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = NewPercentageDiscountPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewPercentageDiscountFilterField.PriceID,
                    Operator = NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewPercentageDiscountPriceType.Usage,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewPercentageDiscountFilterField.PriceID,
                    Operator = NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewPercentageDiscountPriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewPercentageDiscountFilterField.PriceID,
                    Operator = NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewPercentageDiscountPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            AppliesToAll = NewPercentageDiscountAppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewPercentageDiscountFilterField.PriceID,
                    Operator = NewPercentageDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = NewPercentageDiscountPriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            IsInvoiceLevel = true,
        };

        Assert.Null(model.AppliesToAll);
        Assert.False(model.RawData.ContainsKey("applies_to_all"));
        Assert.Null(model.AppliesToItemIds);
        Assert.False(model.RawData.ContainsKey("applies_to_item_ids"));
        Assert.Null(model.AppliesToPriceIds);
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
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            IsInvoiceLevel = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            IsInvoiceLevel = true,

            AppliesToAll = null,
            AppliesToItemIds = null,
            AppliesToPriceIds = null,
            Currency = null,
            Filters = null,
            PriceType = null,
        };

        Assert.Null(model.AppliesToAll);
        Assert.True(model.RawData.ContainsKey("applies_to_all"));
        Assert.Null(model.AppliesToItemIds);
        Assert.True(model.RawData.ContainsKey("applies_to_item_ids"));
        Assert.Null(model.AppliesToPriceIds);
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
        var model = new NewPercentageDiscount
        {
            AdjustmentType = NewPercentageDiscountAdjustmentType.PercentageDiscount,
            PercentageDiscount = 0,
            IsInvoiceLevel = true,

            AppliesToAll = null,
            AppliesToItemIds = null,
            AppliesToPriceIds = null,
            Currency = null,
            Filters = null,
            PriceType = null,
        };

        model.Validate();
    }
}

public class NewPercentageDiscountAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(NewPercentageDiscountAdjustmentType.PercentageDiscount)]
    public void Validation_Works(NewPercentageDiscountAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPercentageDiscountAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPercentageDiscountAdjustmentType.PercentageDiscount)]
    public void SerializationRoundtrip_Works(NewPercentageDiscountAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPercentageDiscountAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountAdjustmentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewPercentageDiscountAppliesToAllTest : TestBase
{
    [Theory]
    [InlineData(NewPercentageDiscountAppliesToAll.True)]
    public void Validation_Works(NewPercentageDiscountAppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, NewPercentageDiscountAppliesToAll> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, NewPercentageDiscountAppliesToAll>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPercentageDiscountAppliesToAll.True)]
    public void SerializationRoundtrip_Works(NewPercentageDiscountAppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, NewPercentageDiscountAppliesToAll> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, NewPercentageDiscountAppliesToAll>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, NewPercentageDiscountAppliesToAll>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, NewPercentageDiscountAppliesToAll>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewPercentageDiscountFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPercentageDiscountFilter
        {
            Field = NewPercentageDiscountFilterField.PriceID,
            Operator = NewPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, NewPercentageDiscountFilterField> expectedField =
            NewPercentageDiscountFilterField.PriceID;
        ApiEnum<string, NewPercentageDiscountFilterOperator> expectedOperator =
            NewPercentageDiscountFilterOperator.Includes;
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
        var model = new NewPercentageDiscountFilter
        {
            Field = NewPercentageDiscountFilterField.PriceID,
            Operator = NewPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewPercentageDiscountFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewPercentageDiscountFilter
        {
            Field = NewPercentageDiscountFilterField.PriceID,
            Operator = NewPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewPercentageDiscountFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewPercentageDiscountFilterField> expectedField =
            NewPercentageDiscountFilterField.PriceID;
        ApiEnum<string, NewPercentageDiscountFilterOperator> expectedOperator =
            NewPercentageDiscountFilterOperator.Includes;
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
        var model = new NewPercentageDiscountFilter
        {
            Field = NewPercentageDiscountFilterField.PriceID,
            Operator = NewPercentageDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class NewPercentageDiscountFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(NewPercentageDiscountFilterField.PriceID)]
    [InlineData(NewPercentageDiscountFilterField.ItemID)]
    [InlineData(NewPercentageDiscountFilterField.PriceType)]
    [InlineData(NewPercentageDiscountFilterField.Currency)]
    [InlineData(NewPercentageDiscountFilterField.PricingUnitID)]
    public void Validation_Works(NewPercentageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPercentageDiscountFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewPercentageDiscountFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPercentageDiscountFilterField.PriceID)]
    [InlineData(NewPercentageDiscountFilterField.ItemID)]
    [InlineData(NewPercentageDiscountFilterField.PriceType)]
    [InlineData(NewPercentageDiscountFilterField.Currency)]
    [InlineData(NewPercentageDiscountFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(NewPercentageDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPercentageDiscountFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewPercentageDiscountFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewPercentageDiscountFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(NewPercentageDiscountFilterOperator.Includes)]
    [InlineData(NewPercentageDiscountFilterOperator.Excludes)]
    public void Validation_Works(NewPercentageDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPercentageDiscountFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPercentageDiscountFilterOperator.Includes)]
    [InlineData(NewPercentageDiscountFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(NewPercentageDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPercentageDiscountFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewPercentageDiscountPriceTypeTest : TestBase
{
    [Theory]
    [InlineData(NewPercentageDiscountPriceType.Usage)]
    [InlineData(NewPercentageDiscountPriceType.FixedInAdvance)]
    [InlineData(NewPercentageDiscountPriceType.FixedInArrears)]
    [InlineData(NewPercentageDiscountPriceType.Fixed)]
    [InlineData(NewPercentageDiscountPriceType.InArrears)]
    public void Validation_Works(NewPercentageDiscountPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPercentageDiscountPriceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewPercentageDiscountPriceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewPercentageDiscountPriceType.Usage)]
    [InlineData(NewPercentageDiscountPriceType.FixedInAdvance)]
    [InlineData(NewPercentageDiscountPriceType.FixedInArrears)]
    [InlineData(NewPercentageDiscountPriceType.Fixed)]
    [InlineData(NewPercentageDiscountPriceType.InArrears)]
    public void SerializationRoundtrip_Works(NewPercentageDiscountPriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewPercentageDiscountPriceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountPriceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewPercentageDiscountPriceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewPercentageDiscountPriceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
