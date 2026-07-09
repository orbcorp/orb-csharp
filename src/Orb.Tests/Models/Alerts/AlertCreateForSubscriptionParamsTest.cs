using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Alerts;

namespace Orb.Tests.Models.Alerts;

public class AlertCreateForSubscriptionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlertCreateForSubscriptionParams
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,
            Currency = "currency",
            GroupingKeys = ["string"],
            MetricID = "metric_id",
            PriceFilters =
            [
                new()
                {
                    Field = AlertCreateForSubscriptionParamsPriceFilterField.PriceID,
                    Operator = AlertCreateForSubscriptionParamsPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ThresholdOverrides = [new() { GroupValues = ["string"], Thresholds = [new(0)] }],
        };

        string expectedSubscriptionID = "subscription_id";
        List<Threshold> expectedThresholds = [new(0)];
        ApiEnum<string, AlertCreateForSubscriptionParamsType> expectedType =
            AlertCreateForSubscriptionParamsType.UsageExceeded;
        string expectedCurrency = "currency";
        List<string> expectedGroupingKeys = ["string"];
        string expectedMetricID = "metric_id";
        List<AlertCreateForSubscriptionParamsPriceFilter> expectedPriceFilters =
        [
            new()
            {
                Field = AlertCreateForSubscriptionParamsPriceFilterField.PriceID,
                Operator = AlertCreateForSubscriptionParamsPriceFilterOperator.Includes,
                Values = ["string"],
            },
        ];
        List<AlertCreateForSubscriptionParamsThresholdOverride> expectedThresholdOverrides =
        [
            new() { GroupValues = ["string"], Thresholds = [new(0)] },
        ];

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedThresholds.Count, parameters.Thresholds.Count);
        for (int i = 0; i < expectedThresholds.Count; i++)
        {
            Assert.Equal(expectedThresholds[i], parameters.Thresholds[i]);
        }
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.NotNull(parameters.GroupingKeys);
        Assert.Equal(expectedGroupingKeys.Count, parameters.GroupingKeys.Count);
        for (int i = 0; i < expectedGroupingKeys.Count; i++)
        {
            Assert.Equal(expectedGroupingKeys[i], parameters.GroupingKeys[i]);
        }
        Assert.Equal(expectedMetricID, parameters.MetricID);
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
        var parameters = new AlertCreateForSubscriptionParams
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,
        };

        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.GroupingKeys);
        Assert.False(parameters.RawBodyData.ContainsKey("grouping_keys"));
        Assert.Null(parameters.MetricID);
        Assert.False(parameters.RawBodyData.ContainsKey("metric_id"));
        Assert.Null(parameters.PriceFilters);
        Assert.False(parameters.RawBodyData.ContainsKey("price_filters"));
        Assert.Null(parameters.ThresholdOverrides);
        Assert.False(parameters.RawBodyData.ContainsKey("threshold_overrides"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AlertCreateForSubscriptionParams
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,

            Currency = null,
            GroupingKeys = null,
            MetricID = null,
            PriceFilters = null,
            ThresholdOverrides = null,
        };

        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.GroupingKeys);
        Assert.True(parameters.RawBodyData.ContainsKey("grouping_keys"));
        Assert.Null(parameters.MetricID);
        Assert.True(parameters.RawBodyData.ContainsKey("metric_id"));
        Assert.Null(parameters.PriceFilters);
        Assert.True(parameters.RawBodyData.ContainsKey("price_filters"));
        Assert.Null(parameters.ThresholdOverrides);
        Assert.True(parameters.RawBodyData.ContainsKey("threshold_overrides"));
    }

    [Fact]
    public void Url_Works()
    {
        AlertCreateForSubscriptionParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.withorb.com/v1/alerts/subscription_id/subscription_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AlertCreateForSubscriptionParams
        {
            SubscriptionID = "subscription_id",
            Thresholds = [new(0)],
            Type = AlertCreateForSubscriptionParamsType.UsageExceeded,
            Currency = "currency",
            GroupingKeys = ["string"],
            MetricID = "metric_id",
            PriceFilters =
            [
                new()
                {
                    Field = AlertCreateForSubscriptionParamsPriceFilterField.PriceID,
                    Operator = AlertCreateForSubscriptionParamsPriceFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            ThresholdOverrides = [new() { GroupValues = ["string"], Thresholds = [new(0)] }],
        };

        AlertCreateForSubscriptionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AlertCreateForSubscriptionParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsType.UsageExceeded)]
    [InlineData(AlertCreateForSubscriptionParamsType.CostExceeded)]
    public void Validation_Works(AlertCreateForSubscriptionParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsType.UsageExceeded)]
    [InlineData(AlertCreateForSubscriptionParamsType.CostExceeded)]
    public void SerializationRoundtrip_Works(AlertCreateForSubscriptionParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AlertCreateForSubscriptionParamsPriceFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AlertCreateForSubscriptionParamsPriceFilter
        {
            Field = AlertCreateForSubscriptionParamsPriceFilterField.PriceID,
            Operator = AlertCreateForSubscriptionParamsPriceFilterOperator.Includes,
            Values = ["string"],
        };

        ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterField> expectedField =
            AlertCreateForSubscriptionParamsPriceFilterField.PriceID;
        ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterOperator> expectedOperator =
            AlertCreateForSubscriptionParamsPriceFilterOperator.Includes;
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
        var model = new AlertCreateForSubscriptionParamsPriceFilter
        {
            Field = AlertCreateForSubscriptionParamsPriceFilterField.PriceID,
            Operator = AlertCreateForSubscriptionParamsPriceFilterOperator.Includes,
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AlertCreateForSubscriptionParamsPriceFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AlertCreateForSubscriptionParamsPriceFilter
        {
            Field = AlertCreateForSubscriptionParamsPriceFilterField.PriceID,
            Operator = AlertCreateForSubscriptionParamsPriceFilterOperator.Includes,
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AlertCreateForSubscriptionParamsPriceFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterField> expectedField =
            AlertCreateForSubscriptionParamsPriceFilterField.PriceID;
        ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterOperator> expectedOperator =
            AlertCreateForSubscriptionParamsPriceFilterOperator.Includes;
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
        var model = new AlertCreateForSubscriptionParamsPriceFilter
        {
            Field = AlertCreateForSubscriptionParamsPriceFilterField.PriceID,
            Operator = AlertCreateForSubscriptionParamsPriceFilterOperator.Includes,
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AlertCreateForSubscriptionParamsPriceFilter
        {
            Field = AlertCreateForSubscriptionParamsPriceFilterField.PriceID,
            Operator = AlertCreateForSubscriptionParamsPriceFilterOperator.Includes,
            Values = ["string"],
        };

        AlertCreateForSubscriptionParamsPriceFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AlertCreateForSubscriptionParamsPriceFilterFieldTest : TestBase
{
    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.PriceID)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.ItemID)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.PriceType)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.Currency)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.PricingUnitID)]
    public void Validation_Works(AlertCreateForSubscriptionParamsPriceFilterField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.PriceID)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.ItemID)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.PriceType)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.Currency)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterField.PricingUnitID)]
    public void SerializationRoundtrip_Works(
        AlertCreateForSubscriptionParamsPriceFilterField rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AlertCreateForSubscriptionParamsPriceFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterOperator.Includes)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterOperator.Excludes)]
    public void Validation_Works(AlertCreateForSubscriptionParamsPriceFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterOperator.Includes)]
    [InlineData(AlertCreateForSubscriptionParamsPriceFilterOperator.Excludes)]
    public void SerializationRoundtrip_Works(
        AlertCreateForSubscriptionParamsPriceFilterOperator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterOperator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AlertCreateForSubscriptionParamsPriceFilterOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AlertCreateForSubscriptionParamsThresholdOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AlertCreateForSubscriptionParamsThresholdOverride
        {
            GroupValues = ["string"],
            Thresholds = [new(0)],
        };

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
        var model = new AlertCreateForSubscriptionParamsThresholdOverride
        {
            GroupValues = ["string"],
            Thresholds = [new(0)],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AlertCreateForSubscriptionParamsThresholdOverride>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AlertCreateForSubscriptionParamsThresholdOverride
        {
            GroupValues = ["string"],
            Thresholds = [new(0)],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AlertCreateForSubscriptionParamsThresholdOverride>(
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
        var model = new AlertCreateForSubscriptionParamsThresholdOverride
        {
            GroupValues = ["string"],
            Thresholds = [new(0)],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AlertCreateForSubscriptionParamsThresholdOverride
        {
            GroupValues = ["string"],
            Thresholds = [new(0)],
        };

        AlertCreateForSubscriptionParamsThresholdOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}
