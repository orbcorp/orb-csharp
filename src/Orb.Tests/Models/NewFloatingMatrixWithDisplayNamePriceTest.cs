using System.Collections.Generic;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class NewFloatingMatrixWithDisplayNamePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewFloatingMatrixWithDisplayNamePrice
        {
            Cadence = NewFloatingMatrixWithDisplayNamePriceCadence.Annual,
            Currency = "currency",
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
            ModelType = NewFloatingMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName,
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
        };

        ApiEnum<string, NewFloatingMatrixWithDisplayNamePriceCadence> expectedCadence =
            NewFloatingMatrixWithDisplayNamePriceCadence.Annual;
        string expectedCurrency = "currency";
        string expectedItemID = "item_id";
        MatrixWithDisplayNameConfig expectedMatrixWithDisplayNameConfig = new()
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
        ApiEnum<string, NewFloatingMatrixWithDisplayNamePriceModelType> expectedModelType =
            NewFloatingMatrixWithDisplayNamePriceModelType.MatrixWithDisplayName;
        string expectedName = "Annual fee";
        string expectedBillableMetricID = "billable_metric_id";
        bool expectedBilledInAdvance = true;
        NewBillingCycleConfiguration expectedBillingCycleConfiguration = new()
        {
            Duration = 0,
            DurationUnit = NewBillingCycleConfigurationDurationUnit.Day,
        };
        double expectedConversionRate = 0;
        NewFloatingMatrixWithDisplayNamePriceConversionRateConfig expectedConversionRateConfig =
            new SharedUnitConversionRateConfig()
            {
                ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
                UnitConfig = new("unit_amount"),
            };
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

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedMatrixWithDisplayNameConfig, model.MatrixWithDisplayNameConfig);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillableMetricID, model.BillableMetricID);
        Assert.Equal(expectedBilledInAdvance, model.BilledInAdvance);
        Assert.Equal(expectedBillingCycleConfiguration, model.BillingCycleConfiguration);
        Assert.Equal(expectedConversionRate, model.ConversionRate);
        Assert.Equal(expectedConversionRateConfig, model.ConversionRateConfig);
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
    }
}

public class MatrixWithDisplayNameConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixWithDisplayNameConfig
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
        List<UnitAmountModel> expectedUnitAmounts =
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

public class UnitAmountModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitAmountModel
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
