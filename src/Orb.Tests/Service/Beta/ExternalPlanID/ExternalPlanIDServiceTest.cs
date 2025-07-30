using System.Threading.Tasks;
using Orb.Models;
using Orb.Models.CustomExpirationProperties;
using Orb.Models.NewAllocationPriceProperties;
using Orb.Models.NewPercentageDiscountProperties;
using Orb.Models.TransformPriceFilterProperties;
using Orb.Models.UnitConversionRateConfigProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewPlanUnitPriceProperties = Orb.Models.NewPlanUnitPriceProperties;

namespace Orb.Tests.Service.Beta.ExternalPlanID;

public class ExternalPlanIDServiceTest : TestBase
{
    [Fact]
    public async Task CreatePlanVersion_Works()
    {
        var planVersion = await this.client.Beta.ExternalPlanID.CreatePlanVersion(
            new()
            {
                ExternalPlanID = "external_plan_id",
                Version = 0,
                AddAdjustments =
                [
                    new()
                    {
                        Adjustment = new NewPercentageDiscount()
                        {
                            AdjustmentType = AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new()
                                {
                                    Field = Field.PriceID,
                                    Operator = Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = PriceType.Usage,
                        },
                        PlanPhaseOrder = 0,
                    },
                ],
                AddPrices =
                [
                    new()
                    {
                        AllocationPrice = new()
                        {
                            Amount = "10.00",
                            Cadence = Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        PlanPhaseOrder = 0,
                        Price = new NewPlanUnitPrice()
                        {
                            Cadence = NewPlanUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewPlanUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new UnitConversionRateConfig()
                            {
                                ConversionRateType = ConversionRateType.Unit,
                                UnitConfig = new() { UnitAmount = "unit_amount" },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration = new()
                            {
                                DimensionValues = ["string"],
                                DimensionalPriceGroupID = "dimensional_price_group_id",
                                ExternalDimensionalPriceGroupID =
                                    "external_dimensional_price_group_id",
                            },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            Metadata = new() { { "foo", "string" } },
                            ReferenceID = "reference_id",
                        },
                    },
                ],
                RemoveAdjustments = [new() { AdjustmentID = "adjustment_id", PlanPhaseOrder = 0 }],
                RemovePrices = [new() { PriceID = "price_id", PlanPhaseOrder = 0 }],
                ReplaceAdjustments =
                [
                    new()
                    {
                        Adjustment = new NewPercentageDiscount()
                        {
                            AdjustmentType = AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new()
                                {
                                    Field = Field.PriceID,
                                    Operator = Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = PriceType.Usage,
                        },
                        ReplacesAdjustmentID = "replaces_adjustment_id",
                        PlanPhaseOrder = 0,
                    },
                ],
                ReplacePrices =
                [
                    new()
                    {
                        ReplacesPriceID = "replaces_price_id",
                        AllocationPrice = new()
                        {
                            Amount = "10.00",
                            Cadence = Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        PlanPhaseOrder = 0,
                        Price = new NewPlanUnitPrice()
                        {
                            Cadence = NewPlanUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewPlanUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new UnitConversionRateConfig()
                            {
                                ConversionRateType = ConversionRateType.Unit,
                                UnitConfig = new() { UnitAmount = "unit_amount" },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration = new()
                            {
                                DimensionValues = ["string"],
                                DimensionalPriceGroupID = "dimensional_price_group_id",
                                ExternalDimensionalPriceGroupID =
                                    "external_dimensional_price_group_id",
                            },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            Metadata = new() { { "foo", "string" } },
                            ReferenceID = "reference_id",
                        },
                    },
                ],
                SetAsDefault = true,
            }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task FetchPlanVersion_Works()
    {
        var planVersion = await this.client.Beta.ExternalPlanID.FetchPlanVersion(
            new() { ExternalPlanID = "external_plan_id", Version = "version" }
        );
        planVersion.Validate();
    }

    [Fact]
    public async Task SetDefaultPlanVersion_Works()
    {
        var plan = await this.client.Beta.ExternalPlanID.SetDefaultPlanVersion(
            new() { ExternalPlanID = "external_plan_id", Version = 0 }
        );
        plan.Validate();
    }
}
