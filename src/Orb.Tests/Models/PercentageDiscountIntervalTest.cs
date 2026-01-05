using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class PercentageDiscountIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PercentageDiscountInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountIntervalFilterField.PriceID,
                    Operator = PercentageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PercentageDiscount = 0.15,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        ApiEnum<string, PercentageDiscountIntervalDiscountType> expectedDiscountType =
            PercentageDiscountIntervalDiscountType.Percentage;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<PercentageDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = PercentageDiscountIntervalFilterField.PriceID,
                Operator = PercentageDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedPercentageDiscount = 0.15;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

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
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PercentageDiscountInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountIntervalFilterField.PriceID,
                    Operator = PercentageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PercentageDiscount = 0.15,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PercentageDiscountInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountIntervalFilterField.PriceID,
                    Operator = PercentageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PercentageDiscount = 0.15,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountInterval>(element);
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        ApiEnum<string, PercentageDiscountIntervalDiscountType> expectedDiscountType =
            PercentageDiscountIntervalDiscountType.Percentage;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<PercentageDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = PercentageDiscountIntervalFilterField.PriceID,
                Operator = PercentageDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedPercentageDiscount = 0.15;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

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
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PercentageDiscountInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = PercentageDiscountIntervalDiscountType.Percentage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = PercentageDiscountIntervalFilterField.PriceID,
                    Operator = PercentageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PercentageDiscount = 0.15,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class PercentageDiscountIntervalDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(PercentageDiscountIntervalDiscountType.Percentage)]
    public void Validation_Works(PercentageDiscountIntervalDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountIntervalDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalDiscountType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PercentageDiscountIntervalDiscountType.Percentage)]
    public void SerializationRoundtrip_Works(PercentageDiscountIntervalDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountIntervalDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalDiscountType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PercentageDiscountIntervalFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PercentageDiscountIntervalFilter
        {
            Field = PercentageDiscountIntervalFilterField.PriceID,
            Operator = PercentageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, PercentageDiscountIntervalFilterField> expectedField =
            PercentageDiscountIntervalFilterField.PriceID;
        ApiEnum<string, PercentageDiscountIntervalFilterOperator> expectedOperator =
            PercentageDiscountIntervalFilterOperator.Includes;
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
        var model = new PercentageDiscountIntervalFilter
        {
            Field = PercentageDiscountIntervalFilterField.PriceID,
            Operator = PercentageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountIntervalFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PercentageDiscountIntervalFilter
        {
            Field = PercentageDiscountIntervalFilterField.PriceID,
            Operator = PercentageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PercentageDiscountIntervalFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, PercentageDiscountIntervalFilterField> expectedField =
            PercentageDiscountIntervalFilterField.PriceID;
        ApiEnum<string, PercentageDiscountIntervalFilterOperator> expectedOperator =
            PercentageDiscountIntervalFilterOperator.Includes;
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
        var model = new PercentageDiscountIntervalFilter
        {
            Field = PercentageDiscountIntervalFilterField.PriceID,
            Operator = PercentageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class PercentageDiscountIntervalFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(PercentageDiscountIntervalFilterField.PriceID)]
    [InlineData(PercentageDiscountIntervalFilterField.ItemID)]
    [InlineData(PercentageDiscountIntervalFilterField.PriceType)]
    [InlineData(PercentageDiscountIntervalFilterField.Currency)]
    [InlineData(PercentageDiscountIntervalFilterField.PricingUnitID)]
    public void Validation_Works(PercentageDiscountIntervalFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountIntervalFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PercentageDiscountIntervalFilterField.PriceID)]
    [InlineData(PercentageDiscountIntervalFilterField.ItemID)]
    [InlineData(PercentageDiscountIntervalFilterField.PriceType)]
    [InlineData(PercentageDiscountIntervalFilterField.Currency)]
    [InlineData(PercentageDiscountIntervalFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(PercentageDiscountIntervalFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountIntervalFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalFilterField>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PercentageDiscountIntervalFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(PercentageDiscountIntervalFilterOperator.Includes)]
    [InlineData(PercentageDiscountIntervalFilterOperator.Excludes)]
    public void Validation_Works(PercentageDiscountIntervalFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountIntervalFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PercentageDiscountIntervalFilterOperator.Includes)]
    [InlineData(PercentageDiscountIntervalFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(PercentageDiscountIntervalFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PercentageDiscountIntervalFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalFilterOperator>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PercentageDiscountIntervalFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
