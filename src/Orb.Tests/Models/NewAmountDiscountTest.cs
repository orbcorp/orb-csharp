using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewAmountDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = PriceType.Usage,
        };

        ApiEnum<string, NewAmountDiscountAdjustmentType> expectedAdjustmentType =
            NewAmountDiscountAdjustmentType.AmountDiscount;
        string expectedAmountDiscount = "amount_discount";
        ApiEnum<bool, AppliesToAll> expectedAppliesToAll = AppliesToAll.True;
        List<string> expectedAppliesToItemIds = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIds = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewAmountDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = NewAmountDiscountFilterField.PriceID,
                Operator = NewAmountDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, PriceType> expectedPriceType = PriceType.Usage;

        Assert.Equal(expectedAdjustmentType, model.AdjustmentType);
        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
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
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = PriceType.Usage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = PriceType.Usage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAmountDiscount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewAmountDiscountAdjustmentType> expectedAdjustmentType =
            NewAmountDiscountAdjustmentType.AmountDiscount;
        string expectedAmountDiscount = "amount_discount";
        ApiEnum<bool, AppliesToAll> expectedAppliesToAll = AppliesToAll.True;
        List<string> expectedAppliesToItemIds = ["item_1", "item_2"];
        List<string> expectedAppliesToPriceIds = ["price_1", "price_2"];
        string expectedCurrency = "currency";
        List<NewAmountDiscountFilter> expectedFilters =
        [
            new()
            {
                Field = NewAmountDiscountFilterField.PriceID,
                Operator = NewAmountDiscountFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        bool expectedIsInvoiceLevel = true;
        ApiEnum<string, PriceType> expectedPriceType = PriceType.Usage;

        Assert.Equal(expectedAdjustmentType, deserialized.AdjustmentType);
        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
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
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = PriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = PriceType.Usage,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = PriceType.Usage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = PriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        Assert.Null(model.IsInvoiceLevel);
        Assert.False(model.RawData.ContainsKey("is_invoice_level"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PriceType = PriceType.Usage,

            // Null should be interpreted as omitted for these properties
            IsInvoiceLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
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
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            IsInvoiceLevel = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
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
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NewAmountDiscount
        {
            AdjustmentType = NewAmountDiscountAdjustmentType.AmountDiscount,
            AmountDiscount = "amount_discount",
            AppliesToAll = AppliesToAll.True,
            AppliesToItemIds = ["item_1", "item_2"],
            AppliesToPriceIds = ["price_1", "price_2"],
            Currency = "currency",
            Filters =
            [
                new()
                {
                    Field = NewAmountDiscountFilterField.PriceID,
                    Operator = NewAmountDiscountFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PriceType = PriceType.Usage,
        };

        NewAmountDiscount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NewAmountDiscountAdjustmentTypeTest : TestBase
{
    [Theory]
    [InlineData(NewAmountDiscountAdjustmentType.AmountDiscount)]
    public void Validation_Works(NewAmountDiscountAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAmountDiscountAdjustmentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAmountDiscountAdjustmentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewAmountDiscountAdjustmentType.AmountDiscount)]
    public void SerializationRoundtrip_Works(NewAmountDiscountAdjustmentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAmountDiscountAdjustmentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAmountDiscountAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAmountDiscountAdjustmentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAmountDiscountAdjustmentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AppliesToAllTest : TestBase
{
    [Theory]
    [InlineData(AppliesToAll.True)]
    public void Validation_Works(AppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AppliesToAll> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AppliesToAll>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AppliesToAll.True)]
    public void SerializationRoundtrip_Works(AppliesToAll rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, AppliesToAll> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AppliesToAll>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, AppliesToAll>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, AppliesToAll>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NewAmountDiscountFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewAmountDiscountFilter
        {
            Field = NewAmountDiscountFilterField.PriceID,
            Operator = NewAmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, NewAmountDiscountFilterField> expectedField =
            NewAmountDiscountFilterField.PriceID;
        ApiEnum<string, NewAmountDiscountFilterOperator> expectedOperator =
            NewAmountDiscountFilterOperator.Includes;
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
        var model = new NewAmountDiscountFilter
        {
            Field = NewAmountDiscountFilterField.PriceID,
            Operator = NewAmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAmountDiscountFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewAmountDiscountFilter
        {
            Field = NewAmountDiscountFilterField.PriceID,
            Operator = NewAmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAmountDiscountFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NewAmountDiscountFilterField> expectedField =
            NewAmountDiscountFilterField.PriceID;
        ApiEnum<string, NewAmountDiscountFilterOperator> expectedOperator =
            NewAmountDiscountFilterOperator.Includes;
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
        var model = new NewAmountDiscountFilter
        {
            Field = NewAmountDiscountFilterField.PriceID,
            Operator = NewAmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NewAmountDiscountFilter
        {
            Field = NewAmountDiscountFilterField.PriceID,
            Operator = NewAmountDiscountFilterOperator.Includes,
            Values = ["string"],
        };

        NewAmountDiscountFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NewAmountDiscountFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(NewAmountDiscountFilterField.PriceID)]
    [InlineData(NewAmountDiscountFilterField.ItemID)]
    [InlineData(NewAmountDiscountFilterField.PriceType)]
    [InlineData(NewAmountDiscountFilterField.Currency)]
    [InlineData(NewAmountDiscountFilterField.PricingUnitID)]
    public void Validation_Works(NewAmountDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAmountDiscountFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAmountDiscountFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewAmountDiscountFilterField.PriceID)]
    [InlineData(NewAmountDiscountFilterField.ItemID)]
    [InlineData(NewAmountDiscountFilterField.PriceType)]
    [InlineData(NewAmountDiscountFilterField.Currency)]
    [InlineData(NewAmountDiscountFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(NewAmountDiscountFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAmountDiscountFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAmountDiscountFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAmountDiscountFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAmountDiscountFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NewAmountDiscountFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(NewAmountDiscountFilterOperator.Includes)]
    [InlineData(NewAmountDiscountFilterOperator.Excludes)]
    public void Validation_Works(NewAmountDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAmountDiscountFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAmountDiscountFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NewAmountDiscountFilterOperator.Includes)]
    [InlineData(NewAmountDiscountFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(NewAmountDiscountFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NewAmountDiscountFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAmountDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NewAmountDiscountFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NewAmountDiscountFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PriceTypeTest : TestBase
{
    [Theory]
    [InlineData(PriceType.Usage)]
    [InlineData(PriceType.FixedInAdvance)]
    [InlineData(PriceType.FixedInArrears)]
    [InlineData(PriceType.Fixed)]
    [InlineData(PriceType.InArrears)]
    public void Validation_Works(PriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PriceType.Usage)]
    [InlineData(PriceType.FixedInAdvance)]
    [InlineData(PriceType.FixedInArrears)]
    [InlineData(PriceType.Fixed)]
    [InlineData(PriceType.InArrears)]
    public void SerializationRoundtrip_Works(PriceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PriceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PriceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PriceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
