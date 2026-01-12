using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits;

namespace Orb.Tests.Models.Customers.Credits;

public class CreditListByExternalIDResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDResponse
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = CreditListByExternalIDResponseFilterField.ItemID,
                    Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = CreditListByExternalIDResponseStatus.Active,
        };

        string expectedID = "id";
        double expectedBalance = 0;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<CreditListByExternalIDResponseFilter> expectedFilters =
        [
            new()
            {
                Field = CreditListByExternalIDResponseFilterField.ItemID,
                Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, CreditListByExternalIDResponseStatus> expectedStatus =
            CreditListByExternalIDResponseStatus.Active;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedExpiryDate, model.ExpiryDate);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedMaximumInitialBalance, model.MaximumInitialBalance);
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditListByExternalIDResponse
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = CreditListByExternalIDResponseFilterField.ItemID,
                    Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = CreditListByExternalIDResponseStatus.Active,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDResponse
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = CreditListByExternalIDResponseFilterField.ItemID,
                    Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = CreditListByExternalIDResponseStatus.Active,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDResponse>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedBalance = 0;
        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<CreditListByExternalIDResponseFilter> expectedFilters =
        [
            new()
            {
                Field = CreditListByExternalIDResponseFilterField.ItemID,
                Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        double expectedMaximumInitialBalance = 0;
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        ApiEnum<string, CreditListByExternalIDResponseStatus> expectedStatus =
            CreditListByExternalIDResponseStatus.Active;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedExpiryDate, deserialized.ExpiryDate);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedMaximumInitialBalance, deserialized.MaximumInitialBalance);
        Assert.Equal(expectedPerUnitCostBasis, deserialized.PerUnitCostBasis);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditListByExternalIDResponse
        {
            ID = "id",
            Balance = 0,
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = CreditListByExternalIDResponseFilterField.ItemID,
                    Operator = CreditListByExternalIDResponseFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            MaximumInitialBalance = 0,
            PerUnitCostBasis = "per_unit_cost_basis",
            Status = CreditListByExternalIDResponseStatus.Active,
        };

        model.Validate();
    }
}

public class CreditListByExternalIDResponseFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, CreditListByExternalIDResponseFilterField> expectedField =
            CreditListByExternalIDResponseFilterField.ItemID;
        ApiEnum<string, CreditListByExternalIDResponseFilterOperator> expectedOperator =
            CreditListByExternalIDResponseFilterOperator.Includes;
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
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDResponseFilter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditListByExternalIDResponseFilter>(
            element
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CreditListByExternalIDResponseFilterField> expectedField =
            CreditListByExternalIDResponseFilterField.ItemID;
        ApiEnum<string, CreditListByExternalIDResponseFilterOperator> expectedOperator =
            CreditListByExternalIDResponseFilterOperator.Includes;
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
        var model = new CreditListByExternalIDResponseFilter
        {
            Field = CreditListByExternalIDResponseFilterField.ItemID,
            Operator = CreditListByExternalIDResponseFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }
}

public class CreditListByExternalIDResponseFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseFilterField.ItemID)]
    public void Validation_Works(CreditListByExternalIDResponseFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseFilterField.ItemID)]
    public void SerializationRoundtrip_Works(CreditListByExternalIDResponseFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDResponseFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseFilterOperator.Includes)]
    [InlineData(CreditListByExternalIDResponseFilterOperator.Excludes)]
    public void Validation_Works(CreditListByExternalIDResponseFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseFilterOperator.Includes)]
    [InlineData(CreditListByExternalIDResponseFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(CreditListByExternalIDResponseFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreditListByExternalIDResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(CreditListByExternalIDResponseStatus.Active)]
    [InlineData(CreditListByExternalIDResponseStatus.PendingPayment)]
    public void Validation_Works(CreditListByExternalIDResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListByExternalIDResponseStatus.Active)]
    [InlineData(CreditListByExternalIDResponseStatus.PendingPayment)]
    public void SerializationRoundtrip_Works(CreditListByExternalIDResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListByExternalIDResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListByExternalIDResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
