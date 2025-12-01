using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewPlanMatrixWithDisplayNamePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPlanMatrixWithDisplayNamePrice
        {
            Cadence = NewPlanMatrixWithDisplayNamePriceCadence.Annual,
            ItemID = "item_id",
            MatrixWithDisplayNameConfig = new()
            {
                Dimension = "dimension",
                UnitAmounts =
                [
                    new()
                    {
                        DimensionValue = "dimension_value",
                        DisplayName = "display_name",
                        UnitAmount = "unit_amount",
                    },
                ],
            },
            ModelType = NewPlanMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
            Name = "Annual fee",
            BillableMetricID = "billable_metric_id",
            BilledInAdvance = true,
            BillingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            ConversionRate = 0,
            ConversionRateConfig = new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            },
            Currency = "currency",
            DimensionalPriceConfiguration = new()
            {
                DimensionValues = ["string"],
                DimensionalPriceGroupID = "dimensional_price_group_id",
                ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
            },
            ExternalPriceID = "external_price_id",
            FixedPriceQuantity = 0,
            InvoiceGroupingKey = "x",
            InvoicingCycleConfiguration = new()
            {
                Duration = 0,
                DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
            },
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            ReferenceID = "reference_id",
        };

        ApiEnum<string, NewPlanMatrixWithDisplayNamePriceCadence> expectedCadence =
            NewPlanMatrixWithDisplayNamePriceCadence.Annual;
        string expectedItemID = "item_id";
        NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig expectedMatrixWithDisplayNameConfig =
            new()
            {
                Dimension = "dimension",
                UnitAmounts =
                [
                    new()
                    {
                        DimensionValue = "dimension_value",
                        DisplayName = "display_name",
                        UnitAmount = "unit_amount",
                    },
                ],
            };
        ApiEnum<string, NewPlanMatrixWithDisplayNamePriceModelType> expectedModelType =
            NewPlanMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewPlanMatrixWithDisplayNamePriceConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
        string expectedCurrency = "currency";
        NewDimensionalPriceConfiguration expectedDimensionalPriceConfiguration = new()
        {
            DimensionValues = ["string"],
            DimensionalPriceGroupID = "dimensional_price_group_id",
            ExternalDimensionalPriceGroupID = "external_dimensional_price_group_id",
        };
        string expectedExternalPriceID = "external_price_id";
        double expectedFixedPriceQuantity = 0;
        string expectedInvoiceGroupingKey = "x";
        NewBillingCycleConfiguration expectedInvoicingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedReferenceID = "reference_id";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedMatrixWithDisplayNameConfig, model.MatrixWithDisplayNameConfig);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDimensionalPriceConfiguration, model.DimensionalPriceConfiguration);
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedFixedPriceQuantity, model.FixedPriceQuantity);
        Assert.Equal(expectedInvoiceGroupingKey, model.InvoiceGroupingKey);
        Assert.Equal(expectedInvoicingCycleConfiguration, model.InvoicingCycleConfiguration);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }
}

public class NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewPlanMatrixWithDisplayNamePriceMatrixWithDisplayNameConfig
        {
            Dimension = "dimension",
            UnitAmounts =
            [
                new()
                {
                    DimensionValue = "dimension_value",
                    DisplayName = "display_name",
                    UnitAmount = "unit_amount",
                },
            ],
        };

        string expectedDimension = "dimension";
        List<UnitAmount2> expectedUnitAmounts =
        [
            new()
            {
                DimensionValue = "dimension_value",
                DisplayName = "display_name",
                UnitAmount = "unit_amount",
            },
        ];

        Assert.Equal(expectedDimension, model.Dimension);
        Assert.Equal(expectedUnitAmounts.Count, model.UnitAmounts.Count);
        for (int i = 0; i < expectedUnitAmounts.Count; i++)
        {
            Assert.Equal(expectedUnitAmounts[i], model.UnitAmounts[i]);
        }
    }
}

public class UnitAmount2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitAmount2
        {
            DimensionValue = "dimension_value",
            DisplayName = "display_name",
            UnitAmount = "unit_amount",
        };

        string expectedDimensionValue = "dimension_value";
        string expectedDisplayName = "display_name";
        string expectedUnitAmount = "unit_amount";

        Assert.Equal(expectedDimensionValue, model.DimensionValue);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedUnitAmount, model.UnitAmount);
    }
}
