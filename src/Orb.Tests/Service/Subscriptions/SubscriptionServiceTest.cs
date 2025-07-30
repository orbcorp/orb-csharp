using System;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models;
using Orb.Models.CustomExpirationProperties;
using Orb.Models.NewFloatingUnitPriceProperties;
using Orb.Models.NewPercentageDiscountProperties;
using Orb.Models.Subscriptions;
using Orb.Models.Subscriptions.DiscountOverrideProperties;
using Orb.Models.Subscriptions.SubscriptionCancelParamsProperties;
using Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;
using Orb.Models.Subscriptions.SubscriptionFetchCostsParamsProperties;
using Orb.Models.Subscriptions.SubscriptionListParamsProperties;
using Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;
using Orb.Models.Subscriptions.SubscriptionRedeemCouponParamsProperties;
using Orb.Models.TransformPriceFilterProperties;
using Orb.Models.UnitConversionRateConfigProperties;
using NewAllocationPriceProperties = Orb.Models.NewAllocationPriceProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewSubscriptionUnitPriceProperties = Orb.Models.Subscriptions.NewSubscriptionUnitPriceProperties;
using SubscriptionFetchUsageParamsProperties = Orb.Models.Subscriptions.SubscriptionFetchUsageParamsProperties;
using SubscriptionSchedulePlanChangeParamsProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;
using SubscriptionUpdateFixedFeeQuantityParamsProperties = Orb.Models.Subscriptions.SubscriptionUpdateFixedFeeQuantityParamsProperties;

namespace Orb.Tests.Service.Subscriptions;

public class SubscriptionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.Create(
            new()
            {
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
                        EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        PlanPhaseOrder = 0,
                        StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AddPrices =
                [
                    new()
                    {
                        AllocationPrice = new()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts =
                        [
                            new()
                            {
                                DiscountType = DiscountType.Percentage,
                                AmountDiscount = "amount_discount",
                                PercentageDiscount = 0.15,
                                UsageDiscount = 0,
                            },
                        ],
                        EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalPriceID = "external_price_id",
                        MaximumAmount = "1.23",
                        MinimumAmount = "1.23",
                        PlanPhaseOrder = 0,
                        Price = new NewSubscriptionUnitPrice()
                        {
                            Cadence = NewSubscriptionUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewSubscriptionUnitPriceProperties::ModelType.Unit,
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
                        PriceID = "h74gfhdjvn7ujokd",
                        StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AlignBillingWithSubscriptionStartDate = true,
                AutoCollection = true,
                AwsRegion = "aws_region",
                BillingCycleAnchorConfiguration = new()
                {
                    Day = 1,
                    Month = 1,
                    Year = 0,
                },
                CouponRedemptionCode = "coupon_redemption_code",
                CreditsOverageRate = 0,
                Currency = "currency",
                CustomerID = "customer_id",
                DefaultInvoiceMemo = "default_invoice_memo",
                EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                ExternalCustomerID = "external_customer_id",
                ExternalMarketplace = ExternalMarketplace.Google,
                ExternalMarketplaceReportingID = "external_marketplace_reporting_id",
                ExternalPlanID = "ZMwNQefe7J3ecf7W",
                Filter = "my_property > 100 AND my_other_property = 'bar'",
                InitialPhaseOrder = 2,
                InvoicingThreshold = "10.00",
                Metadata = new() { { "foo", "string" } },
                Name = "name",
                NetTerms = 0,
                PerCreditOverageAmount = 0,
                PlanID = "ZMwNQefe7J3ecf7W",
                PlanVersionNumber = 0,
                PriceOverrides = [JsonSerializer.Deserialize<JsonElement>("{}")],
                RemoveAdjustments = [new() { AdjustmentID = "h74gfhdjvn7ujokd" }],
                RemovePrices =
                [
                    new() { ExternalPriceID = "external_price_id", PriceID = "h74gfhdjvn7ujokd" },
                ],
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
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts =
                        [
                            new()
                            {
                                DiscountType = DiscountType.Percentage,
                                AmountDiscount = "amount_discount",
                                PercentageDiscount = 0.15,
                                UsageDiscount = 0,
                            },
                        ],
                        ExternalPriceID = "external_price_id",
                        FixedPriceQuantity = 2,
                        MaximumAmount = "1.23",
                        MinimumAmount = "1.23",
                        Price = new NewSubscriptionUnitPrice()
                        {
                            Cadence = NewSubscriptionUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewSubscriptionUnitPriceProperties::ModelType.Unit,
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
                        PriceID = "h74gfhdjvn7ujokd",
                    },
                ],
                StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TrialDurationDays = 0,
                UsageCustomerIDs = ["string"],
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var subscription = await this.client.Subscriptions.Update(
            new()
            {
                SubscriptionID = "subscription_id",
                AutoCollection = true,
                DefaultInvoiceMemo = "default_invoice_memo",
                InvoicingThreshold = "10.00",
                Metadata = new() { { "foo", "string" } },
                NetTerms = 0,
            }
        );
        subscription.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Subscriptions.List(
            new()
            {
                CreatedAtGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                CustomerID = ["string"],
                ExternalCustomerID = ["string"],
                Limit = 1,
                Status = Status.Active,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.Cancel(
            new()
            {
                SubscriptionID = "subscription_id",
                CancelOption = CancelOption.EndOfSubscriptionTerm,
                AllowInvoiceCreditOrVoid = true,
                CancellationDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task Fetch_Works()
    {
        var subscription = await this.client.Subscriptions.Fetch(
            new() { SubscriptionID = "subscription_id" }
        );
        subscription.Validate();
    }

    [Fact]
    public async Task FetchCosts_Works()
    {
        var response = await this.client.Subscriptions.FetchCosts(
            new()
            {
                SubscriptionID = "subscription_id",
                Currency = "currency",
                TimeframeEnd = DateTime.Parse("2022-03-01T05:00:00Z"),
                TimeframeStart = DateTime.Parse("2022-02-01T05:00:00Z"),
                ViewMode = ViewMode.Periodic,
            }
        );
        response.Validate();
    }

    [Fact]
    public async Task FetchSchedule_Works()
    {
        var page = await this.client.Subscriptions.FetchSchedule(
            new()
            {
                SubscriptionID = "subscription_id",
                Cursor = "cursor",
                Limit = 1,
                StartDateGt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                StartDateGte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                StartDateLt = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                StartDateLte = DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task FetchUsage_Works()
    {
        var subscriptionUsage = await this.client.Subscriptions.FetchUsage(
            new()
            {
                SubscriptionID = "subscription_id",
                BillableMetricID = "billable_metric_id",
                FirstDimensionKey = "first_dimension_key",
                FirstDimensionValue = "first_dimension_value",
                Granularity = SubscriptionFetchUsageParamsProperties::Granularity.Day,
                GroupBy = "group_by",
                SecondDimensionKey = "second_dimension_key",
                SecondDimensionValue = "second_dimension_value",
                TimeframeEnd = DateTime.Parse("2022-03-01T05:00:00Z"),
                TimeframeStart = DateTime.Parse("2022-02-01T05:00:00Z"),
                ViewMode = SubscriptionFetchUsageParamsProperties::ViewMode.Periodic,
            }
        );
        subscriptionUsage.Validate();
    }

    [Fact]
    public async Task PriceIntervals_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.PriceIntervals(
            new()
            {
                SubscriptionID = "subscription_id",
                Add =
                [
                    new()
                    {
                        StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        AllocationPrice = new()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts = [new Amount() { AmountDiscount = 0 }],
                        EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalPriceID = "external_price_id",
                        Filter = "my_property > 100 AND my_other_property = 'bar'",
                        FixedFeeQuantityTransitions =
                        [
                            new()
                            {
                                EffectiveDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                                Quantity = 5,
                            },
                        ],
                        MaximumAmount = 0,
                        MinimumAmount = 0,
                        Price = new NewFloatingUnitPrice()
                        {
                            Cadence = Cadence.Annual,
                            Currency = "currency",
                            ItemID = "item_id",
                            ModelType = ModelType.Unit,
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
                        },
                        PriceID = "h74gfhdjvn7ujokd",
                        UsageCustomerIDs = ["string"],
                    },
                ],
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
                        StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AllowInvoiceCreditOrVoid = true,
                Edit =
                [
                    new()
                    {
                        PriceIntervalID = "sdfs6wdjvn7ujokd",
                        BillingCycleDay = 0,
                        EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        Filter = "my_property > 100 AND my_other_property = 'bar'",
                        FixedFeeQuantityTransitions =
                        [
                            new()
                            {
                                EffectiveDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                                Quantity = 5,
                            },
                        ],
                        StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        UsageCustomerIDs = ["string"],
                    },
                ],
                EditAdjustments =
                [
                    new()
                    {
                        AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
                        EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task RedeemCoupon_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.RedeemCoupon(
            new()
            {
                SubscriptionID = "subscription_id",
                ChangeOption = ChangeOption.RequestedDate,
                AllowInvoiceCreditOrVoid = true,
                ChangeDate = DateTime.Parse("2017-07-21T17:32:28Z"),
                CouponID = "coupon_id",
                CouponRedemptionCode = "coupon_redemption_code",
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task SchedulePlanChange_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.SchedulePlanChange(
            new()
            {
                SubscriptionID = "subscription_id",
                ChangeOption =
                    SubscriptionSchedulePlanChangeParamsProperties::ChangeOption.RequestedDate,
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
                        EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        PlanPhaseOrder = 0,
                        StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AddPrices =
                [
                    new()
                    {
                        AllocationPrice = new()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts =
                        [
                            new()
                            {
                                DiscountType = DiscountType.Percentage,
                                AmountDiscount = "amount_discount",
                                PercentageDiscount = 0.15,
                                UsageDiscount = 0,
                            },
                        ],
                        EndDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalPriceID = "external_price_id",
                        MaximumAmount = "1.23",
                        MinimumAmount = "1.23",
                        PlanPhaseOrder = 0,
                        Price = new NewSubscriptionUnitPrice()
                        {
                            Cadence = NewSubscriptionUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewSubscriptionUnitPriceProperties::ModelType.Unit,
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
                        PriceID = "h74gfhdjvn7ujokd",
                        StartDate = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AlignBillingWithPlanChangeDate = true,
                AutoCollection = true,
                BillingCycleAlignment =
                    SubscriptionSchedulePlanChangeParamsProperties::BillingCycleAlignment.Unchanged,
                BillingCycleAnchorConfiguration = new()
                {
                    Day = 1,
                    Month = 1,
                    Year = 0,
                },
                ChangeDate = DateTime.Parse("2017-07-21T17:32:28Z"),
                CouponRedemptionCode = "coupon_redemption_code",
                CreditsOverageRate = 0,
                DefaultInvoiceMemo = "default_invoice_memo",
                ExternalPlanID = "ZMwNQefe7J3ecf7W",
                Filter = "my_property > 100 AND my_other_property = 'bar'",
                InitialPhaseOrder = 2,
                InvoicingThreshold = "10.00",
                NetTerms = 0,
                PerCreditOverageAmount = 0,
                PlanID = "ZMwNQefe7J3ecf7W",
                PlanVersionNumber = 0,
                PriceOverrides = [JsonSerializer.Deserialize<JsonElement>("{}")],
                RemoveAdjustments = [new() { AdjustmentID = "h74gfhdjvn7ujokd" }],
                RemovePrices =
                [
                    new() { ExternalPriceID = "external_price_id", PriceID = "h74gfhdjvn7ujokd" },
                ],
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
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new()
                            {
                                Duration = 0,
                                DurationUnit = DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts =
                        [
                            new()
                            {
                                DiscountType = DiscountType.Percentage,
                                AmountDiscount = "amount_discount",
                                PercentageDiscount = 0.15,
                                UsageDiscount = 0,
                            },
                        ],
                        ExternalPriceID = "external_price_id",
                        FixedPriceQuantity = 2,
                        MaximumAmount = "1.23",
                        MinimumAmount = "1.23",
                        Price = new NewSubscriptionUnitPrice()
                        {
                            Cadence = NewSubscriptionUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewSubscriptionUnitPriceProperties::ModelType.Unit,
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
                        PriceID = "h74gfhdjvn7ujokd",
                    },
                ],
                TrialDurationDays = 0,
                UsageCustomerIDs = ["string"],
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task TriggerPhase_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.TriggerPhase(
            new()
            {
                SubscriptionID = "subscription_id",
                AllowInvoiceCreditOrVoid = true,
                EffectiveDate = DateOnly.Parse("2019-12-27"),
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnscheduleCancellation_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnscheduleCancellation(
            new() { SubscriptionID = "subscription_id" }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnscheduleFixedFeeQuantityUpdates_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnscheduleFixedFeeQuantityUpdates(
            new() { SubscriptionID = "subscription_id", PriceID = "price_id" }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UnschedulePendingPlanChanges_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnschedulePendingPlanChanges(
            new() { SubscriptionID = "subscription_id" }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UpdateFixedFeeQuantity_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UpdateFixedFeeQuantity(
            new()
            {
                SubscriptionID = "subscription_id",
                PriceID = "price_id",
                Quantity = 0,
                AllowInvoiceCreditOrVoid = true,
                ChangeOption =
                    SubscriptionUpdateFixedFeeQuantityParamsProperties::ChangeOption.Immediate,
                EffectiveDate = DateOnly.Parse("2022-12-21"),
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Task UpdateTrial_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UpdateTrial(
            new()
            {
                SubscriptionID = "subscription_id",
                TrialEndDate = DateTime.Parse("2017-07-21T17:32:28Z"),
                Shift = true,
            }
        );
        mutatedSubscription.Validate();
    }
}
