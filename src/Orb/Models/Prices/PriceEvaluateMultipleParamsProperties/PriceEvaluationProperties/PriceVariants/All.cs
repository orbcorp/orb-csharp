using Models = Orb.Models;
using Orb = Orb;
using PriceEvaluationProperties = Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties.PriceVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewFloatingUnitPrice, Models::NewFloatingUnitPrice>)
)]
public sealed record class NewFloatingUnitPrice(Models::NewFloatingUnitPrice Value)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingUnitPrice, Models::NewFloatingUnitPrice>
{
    public static NewFloatingUnitPrice From(Models::NewFloatingUnitPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewFloatingPackagePrice, Models::NewFloatingPackagePrice>)
)]
public sealed record class NewFloatingPackagePrice(Models::NewFloatingPackagePrice Value)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingPackagePrice, Models::NewFloatingPackagePrice>
{
    public static NewFloatingPackagePrice From(Models::NewFloatingPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewFloatingMatrixPrice, Models::NewFloatingMatrixPrice>)
)]
public sealed record class NewFloatingMatrixPrice(Models::NewFloatingMatrixPrice Value)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingMatrixPrice, Models::NewFloatingMatrixPrice>
{
    public static NewFloatingMatrixPrice From(Models::NewFloatingMatrixPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingMatrixWithAllocationPrice,
        Models::NewFloatingMatrixWithAllocationPrice
    >)
)]
public sealed record class NewFloatingMatrixWithAllocationPrice(
    Models::NewFloatingMatrixWithAllocationPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingMatrixWithAllocationPrice,
            Models::NewFloatingMatrixWithAllocationPrice
        >
{
    public static NewFloatingMatrixWithAllocationPrice From(
        Models::NewFloatingMatrixWithAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewFloatingTieredPrice, Models::NewFloatingTieredPrice>)
)]
public sealed record class NewFloatingTieredPrice(Models::NewFloatingTieredPrice Value)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingTieredPrice, Models::NewFloatingTieredPrice>
{
    public static NewFloatingTieredPrice From(Models::NewFloatingTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewFloatingTieredBPSPrice, Models::NewFloatingTieredBPSPrice>)
)]
public sealed record class NewFloatingTieredBPSPrice(Models::NewFloatingTieredBPSPrice Value)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingTieredBPSPrice, Models::NewFloatingTieredBPSPrice>
{
    public static NewFloatingTieredBPSPrice From(Models::NewFloatingTieredBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewFloatingBPSPrice, Models::NewFloatingBPSPrice>)
)]
public sealed record class NewFloatingBPSPrice(Models::NewFloatingBPSPrice Value)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingBPSPrice, Models::NewFloatingBPSPrice>
{
    public static NewFloatingBPSPrice From(Models::NewFloatingBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewFloatingBulkBPSPrice, Models::NewFloatingBulkBPSPrice>)
)]
public sealed record class NewFloatingBulkBPSPrice(Models::NewFloatingBulkBPSPrice Value)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingBulkBPSPrice, Models::NewFloatingBulkBPSPrice>
{
    public static NewFloatingBulkBPSPrice From(Models::NewFloatingBulkBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewFloatingBulkPrice, Models::NewFloatingBulkPrice>)
)]
public sealed record class NewFloatingBulkPrice(Models::NewFloatingBulkPrice Value)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingBulkPrice, Models::NewFloatingBulkPrice>
{
    public static NewFloatingBulkPrice From(Models::NewFloatingBulkPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingThresholdTotalAmountPrice,
        Models::NewFloatingThresholdTotalAmountPrice
    >)
)]
public sealed record class NewFloatingThresholdTotalAmountPrice(
    Models::NewFloatingThresholdTotalAmountPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingThresholdTotalAmountPrice,
            Models::NewFloatingThresholdTotalAmountPrice
        >
{
    public static NewFloatingThresholdTotalAmountPrice From(
        Models::NewFloatingThresholdTotalAmountPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingTieredPackagePrice,
        Models::NewFloatingTieredPackagePrice
    >)
)]
public sealed record class NewFloatingTieredPackagePrice(
    Models::NewFloatingTieredPackagePrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingTieredPackagePrice, Models::NewFloatingTieredPackagePrice>
{
    public static NewFloatingTieredPackagePrice From(Models::NewFloatingTieredPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingGroupedTieredPrice,
        Models::NewFloatingGroupedTieredPrice
    >)
)]
public sealed record class NewFloatingGroupedTieredPrice(
    Models::NewFloatingGroupedTieredPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingGroupedTieredPrice, Models::NewFloatingGroupedTieredPrice>
{
    public static NewFloatingGroupedTieredPrice From(Models::NewFloatingGroupedTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingMaxGroupTieredPackagePrice,
        Models::NewFloatingMaxGroupTieredPackagePrice
    >)
)]
public sealed record class NewFloatingMaxGroupTieredPackagePrice(
    Models::NewFloatingMaxGroupTieredPackagePrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingMaxGroupTieredPackagePrice,
            Models::NewFloatingMaxGroupTieredPackagePrice
        >
{
    public static NewFloatingMaxGroupTieredPackagePrice From(
        Models::NewFloatingMaxGroupTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingTieredWithMinimumPrice,
        Models::NewFloatingTieredWithMinimumPrice
    >)
)]
public sealed record class NewFloatingTieredWithMinimumPrice(
    Models::NewFloatingTieredWithMinimumPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingTieredWithMinimumPrice, Models::NewFloatingTieredWithMinimumPrice>
{
    public static NewFloatingTieredWithMinimumPrice From(
        Models::NewFloatingTieredWithMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingPackageWithAllocationPrice,
        Models::NewFloatingPackageWithAllocationPrice
    >)
)]
public sealed record class NewFloatingPackageWithAllocationPrice(
    Models::NewFloatingPackageWithAllocationPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingPackageWithAllocationPrice,
            Models::NewFloatingPackageWithAllocationPrice
        >
{
    public static NewFloatingPackageWithAllocationPrice From(
        Models::NewFloatingPackageWithAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingTieredPackageWithMinimumPrice,
        Models::NewFloatingTieredPackageWithMinimumPrice
    >)
)]
public sealed record class NewFloatingTieredPackageWithMinimumPrice(
    Models::NewFloatingTieredPackageWithMinimumPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingTieredPackageWithMinimumPrice,
            Models::NewFloatingTieredPackageWithMinimumPrice
        >
{
    public static NewFloatingTieredPackageWithMinimumPrice From(
        Models::NewFloatingTieredPackageWithMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingUnitWithPercentPrice,
        Models::NewFloatingUnitWithPercentPrice
    >)
)]
public sealed record class NewFloatingUnitWithPercentPrice(
    Models::NewFloatingUnitWithPercentPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingUnitWithPercentPrice, Models::NewFloatingUnitWithPercentPrice>
{
    public static NewFloatingUnitWithPercentPrice From(
        Models::NewFloatingUnitWithPercentPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingTieredWithProrationPrice,
        Models::NewFloatingTieredWithProrationPrice
    >)
)]
public sealed record class NewFloatingTieredWithProrationPrice(
    Models::NewFloatingTieredWithProrationPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingTieredWithProrationPrice,
            Models::NewFloatingTieredWithProrationPrice
        >
{
    public static NewFloatingTieredWithProrationPrice From(
        Models::NewFloatingTieredWithProrationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingUnitWithProrationPrice,
        Models::NewFloatingUnitWithProrationPrice
    >)
)]
public sealed record class NewFloatingUnitWithProrationPrice(
    Models::NewFloatingUnitWithProrationPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingUnitWithProrationPrice, Models::NewFloatingUnitWithProrationPrice>
{
    public static NewFloatingUnitWithProrationPrice From(
        Models::NewFloatingUnitWithProrationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingGroupedAllocationPrice,
        Models::NewFloatingGroupedAllocationPrice
    >)
)]
public sealed record class NewFloatingGroupedAllocationPrice(
    Models::NewFloatingGroupedAllocationPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingGroupedAllocationPrice, Models::NewFloatingGroupedAllocationPrice>
{
    public static NewFloatingGroupedAllocationPrice From(
        Models::NewFloatingGroupedAllocationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingGroupedWithProratedMinimumPrice,
        Models::NewFloatingGroupedWithProratedMinimumPrice
    >)
)]
public sealed record class NewFloatingGroupedWithProratedMinimumPrice(
    Models::NewFloatingGroupedWithProratedMinimumPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingGroupedWithProratedMinimumPrice,
            Models::NewFloatingGroupedWithProratedMinimumPrice
        >
{
    public static NewFloatingGroupedWithProratedMinimumPrice From(
        Models::NewFloatingGroupedWithProratedMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingGroupedWithMeteredMinimumPrice,
        Models::NewFloatingGroupedWithMeteredMinimumPrice
    >)
)]
public sealed record class NewFloatingGroupedWithMeteredMinimumPrice(
    Models::NewFloatingGroupedWithMeteredMinimumPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingGroupedWithMeteredMinimumPrice,
            Models::NewFloatingGroupedWithMeteredMinimumPrice
        >
{
    public static NewFloatingGroupedWithMeteredMinimumPrice From(
        Models::NewFloatingGroupedWithMeteredMinimumPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingMatrixWithDisplayNamePrice,
        Models::NewFloatingMatrixWithDisplayNamePrice
    >)
)]
public sealed record class NewFloatingMatrixWithDisplayNamePrice(
    Models::NewFloatingMatrixWithDisplayNamePrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingMatrixWithDisplayNamePrice,
            Models::NewFloatingMatrixWithDisplayNamePrice
        >
{
    public static NewFloatingMatrixWithDisplayNamePrice From(
        Models::NewFloatingMatrixWithDisplayNamePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingBulkWithProrationPrice,
        Models::NewFloatingBulkWithProrationPrice
    >)
)]
public sealed record class NewFloatingBulkWithProrationPrice(
    Models::NewFloatingBulkWithProrationPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<NewFloatingBulkWithProrationPrice, Models::NewFloatingBulkWithProrationPrice>
{
    public static NewFloatingBulkWithProrationPrice From(
        Models::NewFloatingBulkWithProrationPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingGroupedTieredPackagePrice,
        Models::NewFloatingGroupedTieredPackagePrice
    >)
)]
public sealed record class NewFloatingGroupedTieredPackagePrice(
    Models::NewFloatingGroupedTieredPackagePrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingGroupedTieredPackagePrice,
            Models::NewFloatingGroupedTieredPackagePrice
        >
{
    public static NewFloatingGroupedTieredPackagePrice From(
        Models::NewFloatingGroupedTieredPackagePrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingScalableMatrixWithUnitPricingPrice,
        Models::NewFloatingScalableMatrixWithUnitPricingPrice
    >)
)]
public sealed record class NewFloatingScalableMatrixWithUnitPricingPrice(
    Models::NewFloatingScalableMatrixWithUnitPricingPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingScalableMatrixWithUnitPricingPrice,
            Models::NewFloatingScalableMatrixWithUnitPricingPrice
        >
{
    public static NewFloatingScalableMatrixWithUnitPricingPrice From(
        Models::NewFloatingScalableMatrixWithUnitPricingPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingScalableMatrixWithTieredPricingPrice,
        Models::NewFloatingScalableMatrixWithTieredPricingPrice
    >)
)]
public sealed record class NewFloatingScalableMatrixWithTieredPricingPrice(
    Models::NewFloatingScalableMatrixWithTieredPricingPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingScalableMatrixWithTieredPricingPrice,
            Models::NewFloatingScalableMatrixWithTieredPricingPrice
        >
{
    public static NewFloatingScalableMatrixWithTieredPricingPrice From(
        Models::NewFloatingScalableMatrixWithTieredPricingPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        NewFloatingCumulativeGroupedBulkPrice,
        Models::NewFloatingCumulativeGroupedBulkPrice
    >)
)]
public sealed record class NewFloatingCumulativeGroupedBulkPrice(
    Models::NewFloatingCumulativeGroupedBulkPrice Value
)
    : PriceEvaluationProperties::Price,
        Orb::IVariant<
            NewFloatingCumulativeGroupedBulkPrice,
            Models::NewFloatingCumulativeGroupedBulkPrice
        >
{
    public static NewFloatingCumulativeGroupedBulkPrice From(
        Models::NewFloatingCumulativeGroupedBulkPrice value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
