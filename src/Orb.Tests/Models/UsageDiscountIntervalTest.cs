using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class UsageDiscountIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageDiscountInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = UsageDiscountIntervalDiscountType.Usage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = UsageDiscountIntervalFilterField.PriceID,
                    Operator = UsageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageDiscount = 0,
        };

        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        ApiEnum<string, UsageDiscountIntervalDiscountType> expectedDiscountType =
            UsageDiscountIntervalDiscountType.Usage;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<UsageDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = UsageDiscountIntervalFilterField.PriceID,
                Operator = UsageDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageDiscount = 0;

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
        Assert.Equal(expectedUsageDiscount, model.UsageDiscount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageDiscountInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = UsageDiscountIntervalDiscountType.Usage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = UsageDiscountIntervalFilterField.PriceID,
                    Operator = UsageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageDiscount = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageDiscountInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = UsageDiscountIntervalDiscountType.Usage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = UsageDiscountIntervalFilterField.PriceID,
                    Operator = UsageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageDiscount = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountInterval>(element);
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        ApiEnum<string, UsageDiscountIntervalDiscountType> expectedDiscountType =
            UsageDiscountIntervalDiscountType.Usage;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<UsageDiscountIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = UsageDiscountIntervalFilterField.PriceID,
                Operator = UsageDiscountIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageDiscount = 0;

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
        Assert.Equal(expectedUsageDiscount, deserialized.UsageDiscount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageDiscountInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            DiscountType = UsageDiscountIntervalDiscountType.Usage,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = UsageDiscountIntervalFilterField.PriceID,
                    Operator = UsageDiscountIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageDiscount = 0,
        };

        model.Validate();
    }
}

public class UsageDiscountIntervalDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(UsageDiscountIntervalDiscountType.Usage)]
    public void Validation_Works(UsageDiscountIntervalDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountIntervalDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountIntervalDiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UsageDiscountIntervalDiscountType.Usage)]
    public void SerializationRoundtrip_Works(UsageDiscountIntervalDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountIntervalDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UsageDiscountIntervalDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountIntervalDiscountType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UsageDiscountIntervalDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UsageDiscountIntervalFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageDiscountIntervalFilter
        {
            Field = UsageDiscountIntervalFilterField.PriceID,
            Operator = UsageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, UsageDiscountIntervalFilterField> expectedField =
            UsageDiscountIntervalFilterField.PriceID;
        ApiEnum<string, UsageDiscountIntervalFilterOperator> expectedOperator =
            UsageDiscountIntervalFilterOperator.Includes;
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
        var model = new UsageDiscountIntervalFilter
        {
            Field = UsageDiscountIntervalFilterField.PriceID,
            Operator = UsageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountIntervalFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageDiscountIntervalFilter
        {
            Field = UsageDiscountIntervalFilterField.PriceID,
            Operator = UsageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UsageDiscountIntervalFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, UsageDiscountIntervalFilterField> expectedField =
            UsageDiscountIntervalFilterField.PriceID;
        ApiEnum<string, UsageDiscountIntervalFilterOperator> expectedOperator =
            UsageDiscountIntervalFilterOperator.Includes;
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
        var model = new UsageDiscountIntervalFilter
        {
            Field = UsageDiscountIntervalFilterField.PriceID,
            Operator = UsageDiscountIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class UsageDiscountIntervalFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(UsageDiscountIntervalFilterField.PriceID)]
    [InlineData(UsageDiscountIntervalFilterField.ItemID)]
    [InlineData(UsageDiscountIntervalFilterField.PriceType)]
    [InlineData(UsageDiscountIntervalFilterField.Currency)]
    [InlineData(UsageDiscountIntervalFilterField.PricingUnitID)]
    public void Validation_Works(UsageDiscountIntervalFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountIntervalFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountIntervalFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UsageDiscountIntervalFilterField.PriceID)]
    [InlineData(UsageDiscountIntervalFilterField.ItemID)]
    [InlineData(UsageDiscountIntervalFilterField.PriceType)]
    [InlineData(UsageDiscountIntervalFilterField.Currency)]
    [InlineData(UsageDiscountIntervalFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(UsageDiscountIntervalFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountIntervalFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UsageDiscountIntervalFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UsageDiscountIntervalFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UsageDiscountIntervalFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UsageDiscountIntervalFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(UsageDiscountIntervalFilterOperator.Includes)]
    [InlineData(UsageDiscountIntervalFilterOperator.Excludes)]
    public void Validation_Works(UsageDiscountIntervalFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountIntervalFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UsageDiscountIntervalFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UsageDiscountIntervalFilterOperator.Includes)]
    [InlineData(UsageDiscountIntervalFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(UsageDiscountIntervalFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UsageDiscountIntervalFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UsageDiscountIntervalFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UsageDiscountIntervalFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UsageDiscountIntervalFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
