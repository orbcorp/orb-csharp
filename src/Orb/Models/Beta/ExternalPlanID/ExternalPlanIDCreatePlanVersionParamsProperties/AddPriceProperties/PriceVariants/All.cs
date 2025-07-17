using AddPriceProperties = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties.PriceVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanUnitPrice, Models::NewPlanUnitPrice>)
)]
public sealed record class NewPlanUnitPrice(Models::NewPlanUnitPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanUnitPrice, Models::NewPlanUnitPrice>
{
    public static NewPlanUnitPrice From(Models::NewPlanUnitPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanPackagePrice, Models::NewPlanPackagePrice>)
)]
public sealed record class NewPlanPackagePrice(Models::NewPlanPackagePrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanPackagePrice, Models::NewPlanPackagePrice>
{
    public static NewPlanPackagePrice From(Models::NewPlanPackagePrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanMatrixPrice, Models::NewPlanMatrixPrice>)
)]
public sealed record class NewPlanMatrixPrice(Models::NewPlanMatrixPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanMatrixPrice, Models::NewPlanMatrixPrice>
{
    public static NewPlanMatrixPrice From(Models::NewPlanMatrixPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanTieredPrice, Models::NewPlanTieredPrice>)
)]
public sealed record class NewPlanTieredPrice(Models::NewPlanTieredPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanTieredPrice, Models::NewPlanTieredPrice>
{
    public static NewPlanTieredPrice From(Models::NewPlanTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanTieredBPSPrice, Models::NewPlanTieredBPSPrice>)
)]
public sealed record class NewPlanTieredBPSPrice(Models::NewPlanTieredBPSPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanTieredBPSPrice, Models::NewPlanTieredBPSPrice>
{
    public static NewPlanTieredBPSPrice From(Models::NewPlanTieredBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanBPSPrice, Models::NewPlanBPSPrice>)
)]
public sealed record class NewPlanBPSPrice(Models::NewPlanBPSPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanBPSPrice, Models::NewPlanBPSPrice>
{
    public static NewPlanBPSPrice From(Models::NewPlanBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanBulkBPSPrice, Models::NewPlanBulkBPSPrice>)
)]
public sealed record class NewPlanBulkBPSPrice(Models::NewPlanBulkBPSPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanBulkBPSPrice, Models::NewPlanBulkBPSPrice>
{
    public static NewPlanBulkBPSPrice From(Models::NewPlanBulkBPSPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanBulkPrice, Models::NewPlanBulkPrice>)
)]
public sealed record class NewPlanBulkPrice(Models::NewPlanBulkPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanBulkPrice, Models::NewPlanBulkPrice>
{
    public static NewPlanBulkPrice From(Models::NewPlanBulkPrice value)
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
        NewPlanThresholdTotalAmountPrice,
        Models::NewPlanThresholdTotalAmountPrice
    >)
)]
public sealed record class NewPlanThresholdTotalAmountPrice(
    Models::NewPlanThresholdTotalAmountPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanThresholdTotalAmountPrice, Models::NewPlanThresholdTotalAmountPrice>
{
    public static NewPlanThresholdTotalAmountPrice From(
        Models::NewPlanThresholdTotalAmountPrice value
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
    typeof(Orb::VariantConverter<NewPlanTieredPackagePrice, Models::NewPlanTieredPackagePrice>)
)]
public sealed record class NewPlanTieredPackagePrice(Models::NewPlanTieredPackagePrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanTieredPackagePrice, Models::NewPlanTieredPackagePrice>
{
    public static NewPlanTieredPackagePrice From(Models::NewPlanTieredPackagePrice value)
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
        NewPlanTieredWithMinimumPrice,
        Models::NewPlanTieredWithMinimumPrice
    >)
)]
public sealed record class NewPlanTieredWithMinimumPrice(
    Models::NewPlanTieredWithMinimumPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanTieredWithMinimumPrice, Models::NewPlanTieredWithMinimumPrice>
{
    public static NewPlanTieredWithMinimumPrice From(Models::NewPlanTieredWithMinimumPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<NewPlanUnitWithPercentPrice, Models::NewPlanUnitWithPercentPrice>)
)]
public sealed record class NewPlanUnitWithPercentPrice(Models::NewPlanUnitWithPercentPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanUnitWithPercentPrice, Models::NewPlanUnitWithPercentPrice>
{
    public static NewPlanUnitWithPercentPrice From(Models::NewPlanUnitWithPercentPrice value)
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
        NewPlanPackageWithAllocationPrice,
        Models::NewPlanPackageWithAllocationPrice
    >)
)]
public sealed record class NewPlanPackageWithAllocationPrice(
    Models::NewPlanPackageWithAllocationPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanPackageWithAllocationPrice, Models::NewPlanPackageWithAllocationPrice>
{
    public static NewPlanPackageWithAllocationPrice From(
        Models::NewPlanPackageWithAllocationPrice value
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
        NewPlanTierWithProrationPrice,
        Models::NewPlanTierWithProrationPrice
    >)
)]
public sealed record class NewPlanTierWithProrationPrice(
    Models::NewPlanTierWithProrationPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanTierWithProrationPrice, Models::NewPlanTierWithProrationPrice>
{
    public static NewPlanTierWithProrationPrice From(Models::NewPlanTierWithProrationPrice value)
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
        NewPlanUnitWithProrationPrice,
        Models::NewPlanUnitWithProrationPrice
    >)
)]
public sealed record class NewPlanUnitWithProrationPrice(
    Models::NewPlanUnitWithProrationPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanUnitWithProrationPrice, Models::NewPlanUnitWithProrationPrice>
{
    public static NewPlanUnitWithProrationPrice From(Models::NewPlanUnitWithProrationPrice value)
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
        NewPlanGroupedAllocationPrice,
        Models::NewPlanGroupedAllocationPrice
    >)
)]
public sealed record class NewPlanGroupedAllocationPrice(
    Models::NewPlanGroupedAllocationPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanGroupedAllocationPrice, Models::NewPlanGroupedAllocationPrice>
{
    public static NewPlanGroupedAllocationPrice From(Models::NewPlanGroupedAllocationPrice value)
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
        NewPlanGroupedWithProratedMinimumPrice,
        Models::NewPlanGroupedWithProratedMinimumPrice
    >)
)]
public sealed record class NewPlanGroupedWithProratedMinimumPrice(
    Models::NewPlanGroupedWithProratedMinimumPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<
            NewPlanGroupedWithProratedMinimumPrice,
            Models::NewPlanGroupedWithProratedMinimumPrice
        >
{
    public static NewPlanGroupedWithProratedMinimumPrice From(
        Models::NewPlanGroupedWithProratedMinimumPrice value
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
        NewPlanGroupedWithMeteredMinimumPrice,
        Models::NewPlanGroupedWithMeteredMinimumPrice
    >)
)]
public sealed record class NewPlanGroupedWithMeteredMinimumPrice(
    Models::NewPlanGroupedWithMeteredMinimumPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<
            NewPlanGroupedWithMeteredMinimumPrice,
            Models::NewPlanGroupedWithMeteredMinimumPrice
        >
{
    public static NewPlanGroupedWithMeteredMinimumPrice From(
        Models::NewPlanGroupedWithMeteredMinimumPrice value
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
        NewPlanMatrixWithDisplayNamePrice,
        Models::NewPlanMatrixWithDisplayNamePrice
    >)
)]
public sealed record class NewPlanMatrixWithDisplayNamePrice(
    Models::NewPlanMatrixWithDisplayNamePrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanMatrixWithDisplayNamePrice, Models::NewPlanMatrixWithDisplayNamePrice>
{
    public static NewPlanMatrixWithDisplayNamePrice From(
        Models::NewPlanMatrixWithDisplayNamePrice value
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
        NewPlanBulkWithProrationPrice,
        Models::NewPlanBulkWithProrationPrice
    >)
)]
public sealed record class NewPlanBulkWithProrationPrice(
    Models::NewPlanBulkWithProrationPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanBulkWithProrationPrice, Models::NewPlanBulkWithProrationPrice>
{
    public static NewPlanBulkWithProrationPrice From(Models::NewPlanBulkWithProrationPrice value)
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
        NewPlanGroupedTieredPackagePrice,
        Models::NewPlanGroupedTieredPackagePrice
    >)
)]
public sealed record class NewPlanGroupedTieredPackagePrice(
    Models::NewPlanGroupedTieredPackagePrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanGroupedTieredPackagePrice, Models::NewPlanGroupedTieredPackagePrice>
{
    public static NewPlanGroupedTieredPackagePrice From(
        Models::NewPlanGroupedTieredPackagePrice value
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
        NewPlanMaxGroupTieredPackagePrice,
        Models::NewPlanMaxGroupTieredPackagePrice
    >)
)]
public sealed record class NewPlanMaxGroupTieredPackagePrice(
    Models::NewPlanMaxGroupTieredPackagePrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanMaxGroupTieredPackagePrice, Models::NewPlanMaxGroupTieredPackagePrice>
{
    public static NewPlanMaxGroupTieredPackagePrice From(
        Models::NewPlanMaxGroupTieredPackagePrice value
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
        NewPlanScalableMatrixWithUnitPricingPrice,
        Models::NewPlanScalableMatrixWithUnitPricingPrice
    >)
)]
public sealed record class NewPlanScalableMatrixWithUnitPricingPrice(
    Models::NewPlanScalableMatrixWithUnitPricingPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<
            NewPlanScalableMatrixWithUnitPricingPrice,
            Models::NewPlanScalableMatrixWithUnitPricingPrice
        >
{
    public static NewPlanScalableMatrixWithUnitPricingPrice From(
        Models::NewPlanScalableMatrixWithUnitPricingPrice value
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
        NewPlanScalableMatrixWithTieredPricingPrice,
        Models::NewPlanScalableMatrixWithTieredPricingPrice
    >)
)]
public sealed record class NewPlanScalableMatrixWithTieredPricingPrice(
    Models::NewPlanScalableMatrixWithTieredPricingPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<
            NewPlanScalableMatrixWithTieredPricingPrice,
            Models::NewPlanScalableMatrixWithTieredPricingPrice
        >
{
    public static NewPlanScalableMatrixWithTieredPricingPrice From(
        Models::NewPlanScalableMatrixWithTieredPricingPrice value
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
        NewPlanCumulativeGroupedBulkPrice,
        Models::NewPlanCumulativeGroupedBulkPrice
    >)
)]
public sealed record class NewPlanCumulativeGroupedBulkPrice(
    Models::NewPlanCumulativeGroupedBulkPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanCumulativeGroupedBulkPrice, Models::NewPlanCumulativeGroupedBulkPrice>
{
    public static NewPlanCumulativeGroupedBulkPrice From(
        Models::NewPlanCumulativeGroupedBulkPrice value
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
        NewPlanTieredPackageWithMinimumPrice,
        Models::NewPlanTieredPackageWithMinimumPrice
    >)
)]
public sealed record class NewPlanTieredPackageWithMinimumPrice(
    Models::NewPlanTieredPackageWithMinimumPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<
            NewPlanTieredPackageWithMinimumPrice,
            Models::NewPlanTieredPackageWithMinimumPrice
        >
{
    public static NewPlanTieredPackageWithMinimumPrice From(
        Models::NewPlanTieredPackageWithMinimumPrice value
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
        NewPlanMatrixWithAllocationPrice,
        Models::NewPlanMatrixWithAllocationPrice
    >)
)]
public sealed record class NewPlanMatrixWithAllocationPrice(
    Models::NewPlanMatrixWithAllocationPrice Value
)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanMatrixWithAllocationPrice, Models::NewPlanMatrixWithAllocationPrice>
{
    public static NewPlanMatrixWithAllocationPrice From(
        Models::NewPlanMatrixWithAllocationPrice value
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
    typeof(Orb::VariantConverter<NewPlanGroupedTieredPrice, Models::NewPlanGroupedTieredPrice>)
)]
public sealed record class NewPlanGroupedTieredPrice(Models::NewPlanGroupedTieredPrice Value)
    : AddPriceProperties::Price,
        Orb::IVariant<NewPlanGroupedTieredPrice, Models::NewPlanGroupedTieredPrice>
{
    public static NewPlanGroupedTieredPrice From(Models::NewPlanGroupedTieredPrice value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
