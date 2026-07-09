using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlertUpdateParams
        {
            AlertConfigurationID = "alert_configuration_id",
            Thresholds = [new(0)],
            PriceFilters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            ThresholdOverrides = [new() { GroupValues = ["string"], Thresholds = [new(0)] }],
        };

        string expectedAlertConfigurationID = "alert_configuration_id";
        List<Threshold> expectedThresholds = [new(0)];
        List<PriceFilter> expectedPriceFilters =
        [
            new()
            {
                Field = Field.PriceID,
                Operator = Operator.Includes,
                Values = ["string"],
            },
        ];
        List<ThresholdOverride> expectedThresholdOverrides =
        [
            new() { GroupValues = ["string"], Thresholds = [new(0)] },
        ];

        Assert.Equal(expectedAlertConfigurationID, parameters.AlertConfigurationID);
        Assert.Equal(expectedThresholds.Count, parameters.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], parameters.Thresholds[i]);
        }
        Assert.NotNull(parameters.PriceFilters);
        Assert.Equal(expectedPriceFilters.Count, parameters.PriceFilters.Count);
        for (int i = 0; i < expectedPriceFilters.Count; i++)
        {
            Assert.Equal(expectedPriceFilters[i], parameters.PriceFilters[i]);
        }
        Assert.NotNull(parameters.ThresholdOverrides);
        Assert.Equal(expectedThresholdOverrides.Count, parameters.ThresholdOverrides.Count);
        for (int i = 0; i < expectedThresholdOverrides.Count; i++)
        {
            Assert.Equal(expectedThresholdOverrides[i], parameters.ThresholdOverrides[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AlertUpdateParams
        {
            AlertConfigurationID = "alert_configuration_id",
            Thresholds = [new(0)],
        };

        Assert.Null(parameters.PriceFilters);
        Assert.False(parameters.RawBodyData.ContainsKey("price_filters"));
        Assert.Null(parameters.ThresholdOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("threshold_overrides"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AlertUpdateParams
        {
            AlertConfigurationID = "alert_configuration_id",
            Thresholds = [new(0)],

            PriceFilters = null,
            ThresholdOverrides = null,
        };

        Assert.Null(parameters.PriceFilters);
        Assert.True(parameters.RawBodyData.ContainsKey("price_filters"));
        Assert.Null(parameters.ThresholdOverrides);
        Assert.True(parameters.RawBodyData.ContainsKey("threshold_overrides"));
    }

    [Fact]
    public void Url_Works()
    {
        AlertUpdateParams parameters = new()
        {
            AlertConfigurationID = "alert_configuration_id",
            Thresholds = [new(0)],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.withorb.com/v1/alerts/alert_configuration_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AlertUpdateParams
        {
            AlertConfigurationID = "alert_configuration_id",
            Thresholds = [new(0)],
            PriceFilters =
            [
                new()
                {
                    Field = Field.PriceID,
                    Operator = Operator.Includes,
                    Values = ["string"],
                },
            ],
            ThresholdOverrides = [new() { GroupValues = ["string"], Thresholds = [new(0)] }],
        };

        AlertUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PriceFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceFilter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, Field> expectedField = Field.PriceID;
        ApiEnum<string, Operator> expectedOperator = Operator.Includes;
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
        var model = new PriceFilter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PriceFilter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Field> expectedField = Field.PriceID;
        ApiEnum<string, Operator> expectedOperator = Operator.Includes;
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
        var model = new PriceFilter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PriceFilter
        {
            Field = Field.PriceID,
            Operator = Operator.Includes,
            Values = ["string"],
        };

        PriceFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldTest : TestBase
{
    [Theory]
    [InlineData(Field.PriceID)]
    [InlineData(Field.ItemID)]
    [InlineData(Field.PriceType)]
    [InlineData(Field.Currency)]
    [InlineData(Field.PricingUnitID)]
    public void Validation_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Field.PriceID)]
    [InlineData(Field.ItemID)]
    [InlineData(Field.PriceType)]
    [InlineData(Field.Currency)]
    [InlineData(Field.PricingUnitID)]
    public void SerializationRoundtrip_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Operator.Includes)]
    [InlineData(Operator.Excludes)]
    public void Validation_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operator.Includes)]
    [InlineData(Operator.Excludes)]
    public void SerializationRoundtrip_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThresholdOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThresholdOverride { GroupValues = ["string"], Thresholds = [new(0)] };

        List<string> expectedGroupValues = ["string"];
        List<Threshold> expectedThresholds = [new(0)];

        Assert.Equal(expectedGroupValues.Count, model.GroupValues.Count);
        for (int i = 0; i < expectedGroupValues.Count; i++)
        {
            Assert.Equal(expectedGroupValues[i], model.GroupValues[i]);
        }
        Assert.Equal(expectedThresholds.Count, model.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], model.Thresholds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThresholdOverride { GroupValues = ["string"], Thresholds = [new(0)] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThresholdOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThresholdOverride { GroupValues = ["string"], Thresholds = [new(0)] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThresholdOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedGroupValues = ["string"];
        List<Threshold> expectedThresholds = [new(0)];

        Assert.Equal(expectedGroupValues.Count, deserialized.GroupValues.Count);
        for (int i = 0; i < expectedGroupValues.Count; i++)
        {
            Assert.Equal(expectedGroupValues[i], deserialized.GroupValues[i]);
        }
        Assert.Equal(expectedThresholds.Count, deserialized.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], deserialized.Thresholds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThresholdOverride { GroupValues = ["string"], Thresholds = [new(0)] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThresholdOverride { GroupValues = ["string"], Thresholds = [new(0)] };

        ThresholdOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}
