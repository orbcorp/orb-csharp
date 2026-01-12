using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class AffectedBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AffectedBlock
        {
            ID = "id",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AffectedBlockFilterField.PriceID,
                    Operator = AffectedBlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string expectedID = "id";
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<AffectedBlockFilter> expectedFilters =
        [
            new()
            {
                Field = AffectedBlockFilterField.PriceID,
                Operator = AffectedBlockFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedPerUnitCostBasis = "per_unit_cost_basis";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AffectedBlock
        {
            ID = "id",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AffectedBlockFilterField.PriceID,
                    Operator = AffectedBlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AffectedBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AffectedBlock
        {
            ID = "id",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AffectedBlockFilterField.PriceID,
                    Operator = AffectedBlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AffectedBlock>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<AffectedBlockFilter> expectedFilters =
        [
            new()
            {
                Field = AffectedBlockFilterField.PriceID,
                Operator = AffectedBlockFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        string expectedPerUnitCostBasis = "per_unit_cost_basis";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedPerUnitCostBasis, deserialized.PerUnitCostBasis);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AffectedBlock
        {
            ID = "id",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = AffectedBlockFilterField.PriceID,
                    Operator = AffectedBlockFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            PerUnitCostBasis = "per_unit_cost_basis",
        };

        model.Validate();
    }
}

public class AffectedBlockFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AffectedBlockFilter
        {
            Field = AffectedBlockFilterField.PriceID,
            Operator = AffectedBlockFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, AffectedBlockFilterField> expectedField = AffectedBlockFilterField.PriceID;
        ApiEnum<string, AffectedBlockFilterOperator> expectedOperator =
            AffectedBlockFilterOperator.Includes;
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
        var model = new AffectedBlockFilter
        {
            Field = AffectedBlockFilterField.PriceID,
            Operator = AffectedBlockFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AffectedBlockFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AffectedBlockFilter
        {
            Field = AffectedBlockFilterField.PriceID,
            Operator = AffectedBlockFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AffectedBlockFilter>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, AffectedBlockFilterField> expectedField = AffectedBlockFilterField.PriceID;
        ApiEnum<string, AffectedBlockFilterOperator> expectedOperator =
            AffectedBlockFilterOperator.Includes;
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
        var model = new AffectedBlockFilter
        {
            Field = AffectedBlockFilterField.PriceID,
            Operator = AffectedBlockFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class AffectedBlockFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(AffectedBlockFilterField.PriceID)]
    [InlineData(AffectedBlockFilterField.ItemID)]
    [InlineData(AffectedBlockFilterField.PriceType)]
    [InlineData(AffectedBlockFilterField.Currency)]
    [InlineData(AffectedBlockFilterField.PricingUnitID)]
    public void Validation_Works(AffectedBlockFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AffectedBlockFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AffectedBlockFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AffectedBlockFilterField.PriceID)]
    [InlineData(AffectedBlockFilterField.ItemID)]
    [InlineData(AffectedBlockFilterField.PriceType)]
    [InlineData(AffectedBlockFilterField.Currency)]
    [InlineData(AffectedBlockFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(AffectedBlockFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AffectedBlockFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AffectedBlockFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AffectedBlockFilterField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AffectedBlockFilterField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AffectedBlockFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(AffectedBlockFilterOperator.Includes)]
    [InlineData(AffectedBlockFilterOperator.Excludes)]
    public void Validation_Works(AffectedBlockFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AffectedBlockFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AffectedBlockFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AffectedBlockFilterOperator.Includes)]
    [InlineData(AffectedBlockFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(AffectedBlockFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AffectedBlockFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AffectedBlockFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AffectedBlockFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AffectedBlockFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
