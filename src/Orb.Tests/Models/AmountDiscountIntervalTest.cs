using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class AmountDiscountIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AmountDiscountInterval
        {
            AmountDiscount = "amount_discount",
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = AmountDiscountIntervalDiscountType.Amount,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AmountDiscountIntervalFilterField.PriceID,
                    Operator = AmountDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        ApiEnum<string, AmountDiscountIntervalDiscountType> expectedDiscountType =
            AmountDiscountIntervalDiscountType.Amount;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<AmountDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = AmountDiscountIntervalFilterField.PriceID,
                Operator = AmountDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.Equal(
            expectedAppliesToPriceIntervalIds.Count,
            model.AppliesToPriceIntervalIds.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIntervalIds[i], model.AppliesToPriceIntervalIds[i]);
        }
        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AmountDiscountInterval
        {
            AmountDiscount = "amount_discount",
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = AmountDiscountIntervalDiscountType.Amount,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AmountDiscountIntervalFilterField.PriceID,
                    Operator = AmountDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AmountDiscountInterval>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AmountDiscountInterval
        {
            AmountDiscount = "amount_discount",
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = AmountDiscountIntervalDiscountType.Amount,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AmountDiscountIntervalFilterField.PriceID,
                    Operator = AmountDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AmountDiscountInterval>(element);
        Assert.NotNull(deserialized);

        string expectedAmountDiscount = "amount_discount";
        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        ApiEnum<string, AmountDiscountIntervalDiscountType> expectedDiscountType =
            AmountDiscountIntervalDiscountType.Amount;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<AmountDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = AmountDiscountIntervalFilterField.PriceID,
                Operator = AmountDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
        Assert.Equal(
            expectedAppliesToPriceIntervalIds.Count,
            deserialized.AppliesToPriceIntervalIds.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIds.Count; i++)
        {
            Assert.Equal(
                expectedAppliesToPriceIntervalIds[i],
                deserialized.AppliesToPriceIntervalIds[i]
            );
        }
        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AmountDiscountInterval
        {
            AmountDiscount = "amount_discount",
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = AmountDiscountIntervalDiscountType.Amount,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AmountDiscountIntervalFilterField.PriceID,
                    Operator = AmountDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class AmountDiscountIntervalDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(AmountDiscountIntervalDiscountType.Amount)]
    public void Validation_Works(AmountDiscountIntervalDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountIntervalDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountIntervalDiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AmountDiscountIntervalDiscountType.Amount)]
    public void SerializationRoundtrip_Works(AmountDiscountIntervalDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountIntervalDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountIntervalDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountIntervalDiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountIntervalDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AmountDiscountIntervalFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AmountDiscountIntervalFilter
        {
            Field = AmountDiscountIntervalFilterField.PriceID,
            Operator = AmountDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, AmountDiscountIntervalFilterField> expectedField =
            AmountDiscountIntervalFilterField.PriceID;
        ApiEnum<string, AmountDiscountIntervalFilterOperator> expectedOperator =
            AmountDiscountIntervalFilterOperator.Includes;
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
        var model = new AmountDiscountIntervalFilter
        {
            Field = AmountDiscountIntervalFilterField.PriceID,
            Operator = AmountDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AmountDiscountIntervalFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AmountDiscountIntervalFilter
        {
            Field = AmountDiscountIntervalFilterField.PriceID,
            Operator = AmountDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AmountDiscountIntervalFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, AmountDiscountIntervalFilterField> expectedField =
            AmountDiscountIntervalFilterField.PriceID;
        ApiEnum<string, AmountDiscountIntervalFilterOperator> expectedOperator =
            AmountDiscountIntervalFilterOperator.Includes;
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
        var model = new AmountDiscountIntervalFilter
        {
            Field = AmountDiscountIntervalFilterField.PriceID,
            Operator = AmountDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class AmountDiscountIntervalFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(AmountDiscountIntervalFilterField.PriceID)]
    [InlineData(AmountDiscountIntervalFilterField.ItemID)]
    [InlineData(AmountDiscountIntervalFilterField.PriceType)]
    [InlineData(AmountDiscountIntervalFilterField.Currency)]
    [InlineData(AmountDiscountIntervalFilterField.PricingUnitID)]
    public void Validation_Works(AmountDiscountIntervalFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountIntervalFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountIntervalFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AmountDiscountIntervalFilterField.PriceID)]
    [InlineData(AmountDiscountIntervalFilterField.ItemID)]
    [InlineData(AmountDiscountIntervalFilterField.PriceType)]
    [InlineData(AmountDiscountIntervalFilterField.Currency)]
    [InlineData(AmountDiscountIntervalFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(AmountDiscountIntervalFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountIntervalFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountIntervalFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountDiscountIntervalFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountIntervalFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AmountDiscountIntervalFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(AmountDiscountIntervalFilterOperator.Includes)]
    [InlineData(AmountDiscountIntervalFilterOperator.Excludes)]
    public void Validation_Works(AmountDiscountIntervalFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountIntervalFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountIntervalFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AmountDiscountIntervalFilterOperator.Includes)]
    [InlineData(AmountDiscountIntervalFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(AmountDiscountIntervalFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountDiscountIntervalFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountIntervalFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountIntervalFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AmountDiscountIntervalFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
