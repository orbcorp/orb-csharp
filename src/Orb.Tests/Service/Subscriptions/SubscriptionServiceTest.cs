using AddProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;
using CustomExpirationProperties = Orb.Models.CustomExpirationProperties;
using DiscountOverrideProperties = Orb.Models.Subscriptions.DiscountOverrideProperties;
using DiscountProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;
using EditProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;
using Json = System.Text.Json;
using Models = Orb.Models;
using NewAllocationPriceProperties = Orb.Models.NewAllocationPriceProperties;
using NewBillingCycleConfigurationProperties = Orb.Models.NewBillingCycleConfigurationProperties;
using NewFloatingUnitPriceProperties = Orb.Models.NewFloatingUnitPriceProperties;
using NewPercentageDiscountProperties = Orb.Models.NewPercentageDiscountProperties;
using NewSubscriptionUnitPriceProperties = Orb.Models.Subscriptions.NewSubscriptionUnitPriceProperties;
using SubscriptionCancelParamsProperties = Orb.Models.Subscriptions.SubscriptionCancelParamsProperties;
using SubscriptionCreateParamsProperties = Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;
using SubscriptionFetchCostsParamsProperties = Orb.Models.Subscriptions.SubscriptionFetchCostsParamsProperties;
using SubscriptionFetchUsageParamsProperties = Orb.Models.Subscriptions.SubscriptionFetchUsageParamsProperties;
using SubscriptionListParamsProperties = Orb.Models.Subscriptions.SubscriptionListParamsProperties;
using SubscriptionPriceIntervalsParamsProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties;
using SubscriptionRedeemCouponParamsProperties = Orb.Models.Subscriptions.SubscriptionRedeemCouponParamsProperties;
using Subscriptions = Orb.Models.Subscriptions;
using SubscriptionSchedulePlanChangeParamsProperties = Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;
using SubscriptionUpdateFixedFeeQuantityParamsProperties = Orb.Models.Subscriptions.SubscriptionUpdateFixedFeeQuantityParamsProperties;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using TransformPriceFilterProperties = Orb.Models.TransformPriceFilterProperties;
using UnitConversionRateConfigProperties = Orb.Models.UnitConversionRateConfigProperties;

namespace Orb.Tests.Service.Subscriptions;

public class SubscriptionServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Create_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.Create(
            new Subscriptions::SubscriptionCreateParams()
            {
                AddAdjustments =
                [
                    new SubscriptionCreateParamsProperties::AddAdjustment()
                    {
                        Adjustment = new Models::NewPercentageDiscount()
                        {
                            AdjustmentType =
                                NewPercentageDiscountProperties::AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = NewPercentageDiscountProperties::AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new Models::TransformPriceFilter()
                                {
                                    Field = TransformPriceFilterProperties::Field.PriceID,
                                    Operator = TransformPriceFilterProperties::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = NewPercentageDiscountProperties::PriceType.Usage,
                        },
                        EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        PlanPhaseOrder = 0,
                        StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AddPrices =
                [
                    new SubscriptionCreateParamsProperties::AddPrice()
                    {
                        AllocationPrice = new Models::NewAllocationPrice()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new Models::CustomExpiration()
                            {
                                Duration = 0,
                                DurationUnit = CustomExpirationProperties::DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts =
                        [
                            new Subscriptions::DiscountOverride()
                            {
                                DiscountType = DiscountOverrideProperties::DiscountType.Percentage,
                                AmountDiscount = "amount_discount",
                                PercentageDiscount = 0.15,
                                UsageDiscount = 0,
                            },
                        ],
                        EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalPriceID = "external_price_id",
                        MaximumAmount = "1.23",
                        MinimumAmount = "1.23",
                        PlanPhaseOrder = 0,
                        Price = new Subscriptions::NewSubscriptionUnitPrice()
                        {
                            Cadence = NewSubscriptionUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewSubscriptionUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new Models::UnitConfig() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new Models::NewBillingCycleConfiguration()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::UnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    UnitConversionRateConfigProperties::ConversionRateType.Unit,
                                UnitConfig = new Models::ConversionRateUnitConfig()
                                {
                                    UnitAmount = "unit_amount",
                                },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration =
                                new Models::NewDimensionalPriceConfiguration()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                    ExternalDimensionalPriceGroupID =
                                        "external_dimensional_price_group_id",
                                },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new Models::NewBillingCycleConfiguration()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            Metadata = new() { { "foo", "string" } },
                            ReferenceID = "reference_id",
                        },
                        PriceID = "h74gfhdjvn7ujokd",
                        StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AlignBillingWithSubscriptionStartDate = true,
                AutoCollection = true,
                AwsRegion = "aws_region",
                BillingCycleAnchorConfiguration = new Models::BillingCycleAnchorConfiguration()
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
                EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                ExternalCustomerID = "external_customer_id",
                ExternalMarketplace =
                    SubscriptionCreateParamsProperties::ExternalMarketplace.Google,
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
                PriceOverrides = [Json::JsonSerializer.Deserialize<Json::JsonElement>("{}")],
                RemoveAdjustments =
                [
                    new SubscriptionCreateParamsProperties::RemoveAdjustment()
                    {
                        AdjustmentID = "h74gfhdjvn7ujokd",
                    },
                ],
                RemovePrices =
                [
                    new SubscriptionCreateParamsProperties::RemovePrice()
                    {
                        ExternalPriceID = "external_price_id",
                        PriceID = "h74gfhdjvn7ujokd",
                    },
                ],
                ReplaceAdjustments =
                [
                    new SubscriptionCreateParamsProperties::ReplaceAdjustment()
                    {
                        Adjustment = new Models::NewPercentageDiscount()
                        {
                            AdjustmentType =
                                NewPercentageDiscountProperties::AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = NewPercentageDiscountProperties::AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new Models::TransformPriceFilter()
                                {
                                    Field = TransformPriceFilterProperties::Field.PriceID,
                                    Operator = TransformPriceFilterProperties::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = NewPercentageDiscountProperties::PriceType.Usage,
                        },
                        ReplacesAdjustmentID = "replaces_adjustment_id",
                    },
                ],
                ReplacePrices =
                [
                    new SubscriptionCreateParamsProperties::ReplacePrice()
                    {
                        ReplacesPriceID = "replaces_price_id",
                        AllocationPrice = new Models::NewAllocationPrice()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new Models::CustomExpiration()
                            {
                                Duration = 0,
                                DurationUnit = CustomExpirationProperties::DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts =
                        [
                            new Subscriptions::DiscountOverride()
                            {
                                DiscountType = DiscountOverrideProperties::DiscountType.Percentage,
                                AmountDiscount = "amount_discount",
                                PercentageDiscount = 0.15,
                                UsageDiscount = 0,
                            },
                        ],
                        ExternalPriceID = "external_price_id",
                        FixedPriceQuantity = 2,
                        MaximumAmount = "1.23",
                        MinimumAmount = "1.23",
                        Price = new Subscriptions::NewSubscriptionUnitPrice()
                        {
                            Cadence = NewSubscriptionUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewSubscriptionUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new Models::UnitConfig() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new Models::NewBillingCycleConfiguration()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::UnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    UnitConversionRateConfigProperties::ConversionRateType.Unit,
                                UnitConfig = new Models::ConversionRateUnitConfig()
                                {
                                    UnitAmount = "unit_amount",
                                },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration =
                                new Models::NewDimensionalPriceConfiguration()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                    ExternalDimensionalPriceGroupID =
                                        "external_dimensional_price_group_id",
                                },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new Models::NewBillingCycleConfiguration()
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
                StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TrialDurationDays = 0,
                UsageCustomerIDs = ["string"],
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task Update_Works()
    {
        var subscription = await this.client.Subscriptions.Update(
            new Subscriptions::SubscriptionUpdateParams()
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
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Subscriptions.List(
            new Subscriptions::SubscriptionListParams()
            {
                CreatedAtGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAtLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                CustomerID = ["string"],
                ExternalCustomerID = ["string"],
                Limit = 1,
                Status = SubscriptionListParamsProperties::Status.Active,
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task Cancel_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.Cancel(
            new Subscriptions::SubscriptionCancelParams()
            {
                SubscriptionID = "subscription_id",
                CancelOption =
                    SubscriptionCancelParamsProperties::CancelOption.EndOfSubscriptionTerm,
                AllowInvoiceCreditOrVoid = true,
                CancellationDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task Fetch_Works()
    {
        var subscription = await this.client.Subscriptions.Fetch(
            new Subscriptions::SubscriptionFetchParams() { SubscriptionID = "subscription_id" }
        );
        subscription.Validate();
    }

    [Fact]
    public async Tasks::Task FetchCosts_Works()
    {
        var response = await this.client.Subscriptions.FetchCosts(
            new Subscriptions::SubscriptionFetchCostsParams()
            {
                SubscriptionID = "subscription_id",
                Currency = "currency",
                TimeframeEnd = System::DateTime.Parse("2022-03-01T05:00:00Z"),
                TimeframeStart = System::DateTime.Parse("2022-02-01T05:00:00Z"),
                ViewMode = SubscriptionFetchCostsParamsProperties::ViewMode.Periodic,
            }
        );
        response.Validate();
    }

    [Fact]
    public async Tasks::Task FetchSchedule_Works()
    {
        var page = await this.client.Subscriptions.FetchSchedule(
            new Subscriptions::SubscriptionFetchScheduleParams()
            {
                SubscriptionID = "subscription_id",
                Cursor = "cursor",
                Limit = 1,
                StartDateGt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                StartDateGte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                StartDateLt = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                StartDateLte = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        page.Validate();
    }

    [Fact]
    public async Tasks::Task FetchUsage_Works()
    {
        var subscriptionUsage = await this.client.Subscriptions.FetchUsage(
            new Subscriptions::SubscriptionFetchUsageParams()
            {
                SubscriptionID = "subscription_id",
                BillableMetricID = "billable_metric_id",
                FirstDimensionKey = "first_dimension_key",
                FirstDimensionValue = "first_dimension_value",
                Granularity = SubscriptionFetchUsageParamsProperties::Granularity.Day,
                GroupBy = "group_by",
                SecondDimensionKey = "second_dimension_key",
                SecondDimensionValue = "second_dimension_value",
                TimeframeEnd = System::DateTime.Parse("2022-03-01T05:00:00Z"),
                TimeframeStart = System::DateTime.Parse("2022-02-01T05:00:00Z"),
                ViewMode = SubscriptionFetchUsageParamsProperties::ViewMode.Periodic,
            }
        );
        subscriptionUsage.Validate();
    }

    [Fact]
    public async Tasks::Task PriceIntervals_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.PriceIntervals(
            new Subscriptions::SubscriptionPriceIntervalsParams()
            {
                SubscriptionID = "subscription_id",
                Add =
                [
                    new SubscriptionPriceIntervalsParamsProperties::Add()
                    {
                        StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        AllocationPrice = new Models::NewAllocationPrice()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new Models::CustomExpiration()
                            {
                                Duration = 0,
                                DurationUnit = CustomExpirationProperties::DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts = [new DiscountProperties::Amount() { AmountDiscount = 0 }],
                        EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalPriceID = "external_price_id",
                        Filter = "my_property > 100 AND my_other_property = 'bar'",
                        FixedFeeQuantityTransitions =
                        [
                            new AddProperties::FixedFeeQuantityTransition()
                            {
                                EffectiveDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                                Quantity = 5,
                            },
                        ],
                        MaximumAmount = 0,
                        MinimumAmount = 0,
                        Price = new Models::NewFloatingUnitPrice()
                        {
                            Cadence = NewFloatingUnitPriceProperties::Cadence.Annual,
                            Currency = "currency",
                            ItemID = "item_id",
                            ModelType = NewFloatingUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new Models::UnitConfig() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new Models::NewBillingCycleConfiguration()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::UnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    UnitConversionRateConfigProperties::ConversionRateType.Unit,
                                UnitConfig = new Models::ConversionRateUnitConfig()
                                {
                                    UnitAmount = "unit_amount",
                                },
                            },
                            DimensionalPriceConfiguration =
                                new Models::NewDimensionalPriceConfiguration()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                    ExternalDimensionalPriceGroupID =
                                        "external_dimensional_price_group_id",
                                },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new Models::NewBillingCycleConfiguration()
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
                    new SubscriptionPriceIntervalsParamsProperties::AddAdjustment()
                    {
                        Adjustment = new Models::NewPercentageDiscount()
                        {
                            AdjustmentType =
                                NewPercentageDiscountProperties::AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = NewPercentageDiscountProperties::AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new Models::TransformPriceFilter()
                                {
                                    Field = TransformPriceFilterProperties::Field.PriceID,
                                    Operator = TransformPriceFilterProperties::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = NewPercentageDiscountProperties::PriceType.Usage,
                        },
                        StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AllowInvoiceCreditOrVoid = true,
                Edit =
                [
                    new SubscriptionPriceIntervalsParamsProperties::Edit()
                    {
                        PriceIntervalID = "sdfs6wdjvn7ujokd",
                        BillingCycleDay = 0,
                        EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        Filter = "my_property > 100 AND my_other_property = 'bar'",
                        FixedFeeQuantityTransitions =
                        [
                            new EditProperties::FixedFeeQuantityTransition()
                            {
                                EffectiveDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                                Quantity = 5,
                            },
                        ],
                        StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        UsageCustomerIDs = ["string"],
                    },
                ],
                EditAdjustments =
                [
                    new SubscriptionPriceIntervalsParamsProperties::EditAdjustment()
                    {
                        AdjustmentIntervalID = "sdfs6wdjvn7ujokd",
                        EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task RedeemCoupon_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.RedeemCoupon(
            new Subscriptions::SubscriptionRedeemCouponParams()
            {
                SubscriptionID = "subscription_id",
                ChangeOption = SubscriptionRedeemCouponParamsProperties::ChangeOption.RequestedDate,
                AllowInvoiceCreditOrVoid = true,
                ChangeDate = System::DateTime.Parse("2017-07-21T17:32:28Z"),
                CouponID = "coupon_id",
                CouponRedemptionCode = "coupon_redemption_code",
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task SchedulePlanChange_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.SchedulePlanChange(
            new Subscriptions::SubscriptionSchedulePlanChangeParams()
            {
                SubscriptionID = "subscription_id",
                ChangeOption =
                    SubscriptionSchedulePlanChangeParamsProperties::ChangeOption.RequestedDate,
                AddAdjustments =
                [
                    new SubscriptionSchedulePlanChangeParamsProperties::AddAdjustment()
                    {
                        Adjustment = new Models::NewPercentageDiscount()
                        {
                            AdjustmentType =
                                NewPercentageDiscountProperties::AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = NewPercentageDiscountProperties::AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new Models::TransformPriceFilter()
                                {
                                    Field = TransformPriceFilterProperties::Field.PriceID,
                                    Operator = TransformPriceFilterProperties::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = NewPercentageDiscountProperties::PriceType.Usage,
                        },
                        EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        PlanPhaseOrder = 0,
                        StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AddPrices =
                [
                    new SubscriptionSchedulePlanChangeParamsProperties::AddPrice()
                    {
                        AllocationPrice = new Models::NewAllocationPrice()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new Models::CustomExpiration()
                            {
                                Duration = 0,
                                DurationUnit = CustomExpirationProperties::DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts =
                        [
                            new Subscriptions::DiscountOverride()
                            {
                                DiscountType = DiscountOverrideProperties::DiscountType.Percentage,
                                AmountDiscount = "amount_discount",
                                PercentageDiscount = 0.15,
                                UsageDiscount = 0,
                            },
                        ],
                        EndDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalPriceID = "external_price_id",
                        MaximumAmount = "1.23",
                        MinimumAmount = "1.23",
                        PlanPhaseOrder = 0,
                        Price = new Subscriptions::NewSubscriptionUnitPrice()
                        {
                            Cadence = NewSubscriptionUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewSubscriptionUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new Models::UnitConfig() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new Models::NewBillingCycleConfiguration()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::UnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    UnitConversionRateConfigProperties::ConversionRateType.Unit,
                                UnitConfig = new Models::ConversionRateUnitConfig()
                                {
                                    UnitAmount = "unit_amount",
                                },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration =
                                new Models::NewDimensionalPriceConfiguration()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                    ExternalDimensionalPriceGroupID =
                                        "external_dimensional_price_group_id",
                                },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new Models::NewBillingCycleConfiguration()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            Metadata = new() { { "foo", "string" } },
                            ReferenceID = "reference_id",
                        },
                        PriceID = "h74gfhdjvn7ujokd",
                        StartDate = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                AlignBillingWithPlanChangeDate = true,
                AutoCollection = true,
                BillingCycleAlignment =
                    SubscriptionSchedulePlanChangeParamsProperties::BillingCycleAlignment.Unchanged,
                BillingCycleAnchorConfiguration = new Models::BillingCycleAnchorConfiguration()
                {
                    Day = 1,
                    Month = 1,
                    Year = 0,
                },
                ChangeDate = System::DateTime.Parse("2017-07-21T17:32:28Z"),
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
                PriceOverrides = [Json::JsonSerializer.Deserialize<Json::JsonElement>("{}")],
                RemoveAdjustments =
                [
                    new SubscriptionSchedulePlanChangeParamsProperties::RemoveAdjustment()
                    {
                        AdjustmentID = "h74gfhdjvn7ujokd",
                    },
                ],
                RemovePrices =
                [
                    new SubscriptionSchedulePlanChangeParamsProperties::RemovePrice()
                    {
                        ExternalPriceID = "external_price_id",
                        PriceID = "h74gfhdjvn7ujokd",
                    },
                ],
                ReplaceAdjustments =
                [
                    new SubscriptionSchedulePlanChangeParamsProperties::ReplaceAdjustment()
                    {
                        Adjustment = new Models::NewPercentageDiscount()
                        {
                            AdjustmentType =
                                NewPercentageDiscountProperties::AdjustmentType.PercentageDiscount,
                            PercentageDiscount = 0,
                            AppliesToAll = NewPercentageDiscountProperties::AppliesToAll.True,
                            AppliesToItemIDs = ["item_1", "item_2"],
                            AppliesToPriceIDs = ["price_1", "price_2"],
                            Currency = "currency",
                            Filters =
                            [
                                new Models::TransformPriceFilter()
                                {
                                    Field = TransformPriceFilterProperties::Field.PriceID,
                                    Operator = TransformPriceFilterProperties::Operator.Includes,
                                    Values = ["string"],
                                },
                            ],
                            IsInvoiceLevel = true,
                            PriceType = NewPercentageDiscountProperties::PriceType.Usage,
                        },
                        ReplacesAdjustmentID = "replaces_adjustment_id",
                    },
                ],
                ReplacePrices =
                [
                    new SubscriptionSchedulePlanChangeParamsProperties::ReplacePrice()
                    {
                        ReplacesPriceID = "replaces_price_id",
                        AllocationPrice = new Models::NewAllocationPrice()
                        {
                            Amount = "10.00",
                            Cadence = NewAllocationPriceProperties::Cadence.Monthly,
                            Currency = "USD",
                            CustomExpiration = new Models::CustomExpiration()
                            {
                                Duration = 0,
                                DurationUnit = CustomExpirationProperties::DurationUnit.Day,
                            },
                            ExpiresAtEndOfCadence = true,
                        },
                        Discounts =
                        [
                            new Subscriptions::DiscountOverride()
                            {
                                DiscountType = DiscountOverrideProperties::DiscountType.Percentage,
                                AmountDiscount = "amount_discount",
                                PercentageDiscount = 0.15,
                                UsageDiscount = 0,
                            },
                        ],
                        ExternalPriceID = "external_price_id",
                        FixedPriceQuantity = 2,
                        MaximumAmount = "1.23",
                        MinimumAmount = "1.23",
                        Price = new Subscriptions::NewSubscriptionUnitPrice()
                        {
                            Cadence = NewSubscriptionUnitPriceProperties::Cadence.Annual,
                            ItemID = "item_id",
                            ModelType = NewSubscriptionUnitPriceProperties::ModelType.Unit,
                            Name = "Annual fee",
                            UnitConfig = new Models::UnitConfig() { UnitAmount = "unit_amount" },
                            BillableMetricID = "billable_metric_id",
                            BilledInAdvance = true,
                            BillingCycleConfiguration = new Models::NewBillingCycleConfiguration()
                            {
                                Duration = 0,
                                DurationUnit =
                                    NewBillingCycleConfigurationProperties::DurationUnit.Day,
                            },
                            ConversionRate = 0,
                            ConversionRateConfig = new Models::UnitConversionRateConfig()
                            {
                                ConversionRateType =
                                    UnitConversionRateConfigProperties::ConversionRateType.Unit,
                                UnitConfig = new Models::ConversionRateUnitConfig()
                                {
                                    UnitAmount = "unit_amount",
                                },
                            },
                            Currency = "currency",
                            DimensionalPriceConfiguration =
                                new Models::NewDimensionalPriceConfiguration()
                                {
                                    DimensionValues = ["string"],
                                    DimensionalPriceGroupID = "dimensional_price_group_id",
                                    ExternalDimensionalPriceGroupID =
                                        "external_dimensional_price_group_id",
                                },
                            ExternalPriceID = "external_price_id",
                            FixedPriceQuantity = 0,
                            InvoiceGroupingKey = "x",
                            InvoicingCycleConfiguration = new Models::NewBillingCycleConfiguration()
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
    public async Tasks::Task TriggerPhase_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.TriggerPhase(
            new Subscriptions::SubscriptionTriggerPhaseParams()
            {
                SubscriptionID = "subscription_id",
                AllowInvoiceCreditOrVoid = true,
                EffectiveDate = System::DateOnly.Parse("2019-12-27"),
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task UnscheduleCancellation_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnscheduleCancellation(
            new Subscriptions::SubscriptionUnscheduleCancellationParams()
            {
                SubscriptionID = "subscription_id",
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task UnscheduleFixedFeeQuantityUpdates_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnscheduleFixedFeeQuantityUpdates(
            new Subscriptions::SubscriptionUnscheduleFixedFeeQuantityUpdatesParams()
            {
                SubscriptionID = "subscription_id",
                PriceID = "price_id",
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task UnschedulePendingPlanChanges_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UnschedulePendingPlanChanges(
            new Subscriptions::SubscriptionUnschedulePendingPlanChangesParams()
            {
                SubscriptionID = "subscription_id",
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task UpdateFixedFeeQuantity_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UpdateFixedFeeQuantity(
            new Subscriptions::SubscriptionUpdateFixedFeeQuantityParams()
            {
                SubscriptionID = "subscription_id",
                PriceID = "price_id",
                Quantity = 0,
                AllowInvoiceCreditOrVoid = true,
                ChangeOption =
                    SubscriptionUpdateFixedFeeQuantityParamsProperties::ChangeOption.Immediate,
                EffectiveDate = System::DateOnly.Parse("2022-12-21"),
            }
        );
        mutatedSubscription.Validate();
    }

    [Fact]
    public async Tasks::Task UpdateTrial_Works()
    {
        var mutatedSubscription = await this.client.Subscriptions.UpdateTrial(
            new Subscriptions::SubscriptionUpdateTrialParams()
            {
                SubscriptionID = "subscription_id",
                TrialEndDate = System::DateTime.Parse("2017-07-21T17:32:28Z"),
                Shift = true,
            }
        );
        mutatedSubscription.Validate();
    }
}
