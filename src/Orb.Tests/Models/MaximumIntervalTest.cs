using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class MaximumIntervalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaximumInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = MaximumIntervalFilterField.PriceID,
                    Operator = MaximumIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<MaximumIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = MaximumIntervalFilterField.PriceID,
                Operator = MaximumIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMaximumAmount = "maximum_amount";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(
            expectedAppliesToPriceIntervalIds.Count,
            model.AppliesToPriceIntervalIds.Count
        );
        for (int i = 0; i < expectedAppliesToPriceIntervalIds.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIntervalIds[i], model.AppliesToPriceIntervalIds[i]);
        }
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedMaximumAmount, model.MaximumAmount);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MaximumInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = MaximumIntervalFilterField.PriceID,
                    Operator = MaximumIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaximumInterval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MaximumInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = MaximumIntervalFilterField.PriceID,
                    Operator = MaximumIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaximumInterval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAppliesToPriceIntervalIds = ["string"];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<MaximumIntervalFilter> expectedFilters =
        [
            new()
            {
                Field = MaximumIntervalFilterField.PriceID,
                Operator = MaximumIntervalFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedMaximumAmount = "maximum_amount";
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
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MaximumInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = MaximumIntervalFilterField.PriceID,
                    Operator = MaximumIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MaximumInterval
        {
            AppliesToPriceIntervalIds = ["string"],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = MaximumIntervalFilterField.PriceID,
                    Operator = MaximumIntervalFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumAmount = "maximum_amount",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        MaximumInterval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MaximumIntervalFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaximumIntervalFilter
        {
            Field = MaximumIntervalFilterField.PriceID,
            Operator = MaximumIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, MaximumIntervalFilterField> expectedField =
            MaximumIntervalFilterField.PriceID;
        ApiEnum<string, MaximumIntervalFilterOperator> expectedOperator =
            MaximumIntervalFilterOperator.Includes;
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
        var model = new MaximumIntervalFilter
        {
            Field = MaximumIntervalFilterField.PriceID,
            Operator = MaximumIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaximumIntervalFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MaximumIntervalFilter
        {
            Field = MaximumIntervalFilterField.PriceID,
            Operator = MaximumIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaximumIntervalFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, MaximumIntervalFilterField> expectedField =
            MaximumIntervalFilterField.PriceID;
        ApiEnum<string, MaximumIntervalFilterOperator> expectedOperator =
            MaximumIntervalFilterOperator.Includes;
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
        var model = new MaximumIntervalFilter
        {
            Field = MaximumIntervalFilterField.PriceID,
            Operator = MaximumIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MaximumIntervalFilter
        {
            Field = MaximumIntervalFilterField.PriceID,
            Operator = MaximumIntervalFilterOperator.Includes,
            Values = ["string"],
        };

        MaximumIntervalFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MaximumIntervalFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(MaximumIntervalFilterField.PriceID)]
    [InlineData(MaximumIntervalFilterField.ItemID)]
    [InlineData(MaximumIntervalFilterField.PriceType)]
    [InlineData(MaximumIntervalFilterField.Currency)]
    [InlineData(MaximumIntervalFilterField.PricingUnitID)]
    public void Validation_Works(MaximumIntervalFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumIntervalFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MaximumIntervalFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MaximumIntervalFilterField.PriceID)]
    [InlineData(MaximumIntervalFilterField.ItemID)]
    [InlineData(MaximumIntervalFilterField.PriceType)]
    [InlineData(MaximumIntervalFilterField.Currency)]
    [InlineData(MaximumIntervalFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(MaximumIntervalFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumIntervalFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MaximumIntervalFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MaximumIntervalFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MaximumIntervalFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MaximumIntervalFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(MaximumIntervalFilterOperator.Includes)]
    [InlineData(MaximumIntervalFilterOperator.Excludes)]
    public void Validation_Works(MaximumIntervalFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumIntervalFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MaximumIntervalFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MaximumIntervalFilterOperator.Includes)]
    [InlineData(MaximumIntervalFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(MaximumIntervalFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumIntervalFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MaximumIntervalFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MaximumIntervalFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MaximumIntervalFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
