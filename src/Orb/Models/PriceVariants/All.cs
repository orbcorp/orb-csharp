using Orb.Core;
using PriceProperties = Orb.Models.PriceProperties;

namespace Orb.Models.PriceVariants;

public sealed record class Unit(PriceProperties::Unit Value)
    : Price,
        IVariant<Unit, PriceProperties::Unit>
{
    public static Unit From(PriceProperties::Unit value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Tiered(PriceProperties::Tiered Value)
    : Price,
        IVariant<Tiered, PriceProperties::Tiered>
{
    public static Tiered From(PriceProperties::Tiered value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Bulk(PriceProperties::Bulk Value)
    : Price,
        IVariant<Bulk, PriceProperties::Bulk>
{
    public static Bulk From(PriceProperties::Bulk value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Package(PriceProperties::Package Value)
    : Price,
        IVariant<Package, PriceProperties::Package>
{
    public static Package From(PriceProperties::Package value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Matrix(PriceProperties::Matrix Value)
    : Price,
        IVariant<Matrix, PriceProperties::Matrix>
{
    public static Matrix From(PriceProperties::Matrix value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ThresholdTotalAmount(PriceProperties::ThresholdTotalAmount Value)
    : Price,
        IVariant<ThresholdTotalAmount, PriceProperties::ThresholdTotalAmount>
{
    public static ThresholdTotalAmount From(PriceProperties::ThresholdTotalAmount value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class TieredPackage(PriceProperties::TieredPackage Value)
    : Price,
        IVariant<TieredPackage, PriceProperties::TieredPackage>
{
    public static TieredPackage From(PriceProperties::TieredPackage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class TieredWithMinimum(PriceProperties::TieredWithMinimum Value)
    : Price,
        IVariant<TieredWithMinimum, PriceProperties::TieredWithMinimum>
{
    public static TieredWithMinimum From(PriceProperties::TieredWithMinimum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GroupedTiered(PriceProperties::GroupedTiered Value)
    : Price,
        IVariant<GroupedTiered, PriceProperties::GroupedTiered>
{
    public static GroupedTiered From(PriceProperties::GroupedTiered value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class TieredPackageWithMinimum(PriceProperties::TieredPackageWithMinimum Value)
    : Price,
        IVariant<TieredPackageWithMinimum, PriceProperties::TieredPackageWithMinimum>
{
    public static TieredPackageWithMinimum From(PriceProperties::TieredPackageWithMinimum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PackageWithAllocation(PriceProperties::PackageWithAllocation Value)
    : Price,
        IVariant<PackageWithAllocation, PriceProperties::PackageWithAllocation>
{
    public static PackageWithAllocation From(PriceProperties::PackageWithAllocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnitWithPercent(PriceProperties::UnitWithPercent Value)
    : Price,
        IVariant<UnitWithPercent, PriceProperties::UnitWithPercent>
{
    public static UnitWithPercent From(PriceProperties::UnitWithPercent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MatrixWithAllocation(PriceProperties::MatrixWithAllocation Value)
    : Price,
        IVariant<MatrixWithAllocation, PriceProperties::MatrixWithAllocation>
{
    public static MatrixWithAllocation From(PriceProperties::MatrixWithAllocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class TieredWithProration(PriceProperties::TieredWithProration Value)
    : Price,
        IVariant<TieredWithProration, PriceProperties::TieredWithProration>
{
    public static TieredWithProration From(PriceProperties::TieredWithProration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class UnitWithProration(PriceProperties::UnitWithProration Value)
    : Price,
        IVariant<UnitWithProration, PriceProperties::UnitWithProration>
{
    public static UnitWithProration From(PriceProperties::UnitWithProration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GroupedAllocation(PriceProperties::GroupedAllocation Value)
    : Price,
        IVariant<GroupedAllocation, PriceProperties::GroupedAllocation>
{
    public static GroupedAllocation From(PriceProperties::GroupedAllocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BulkWithProration(PriceProperties::BulkWithProration Value)
    : Price,
        IVariant<BulkWithProration, PriceProperties::BulkWithProration>
{
    public static BulkWithProration From(PriceProperties::BulkWithProration value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GroupedWithProratedMinimum(
    PriceProperties::GroupedWithProratedMinimum Value
) : Price, IVariant<GroupedWithProratedMinimum, PriceProperties::GroupedWithProratedMinimum>
{
    public static GroupedWithProratedMinimum From(PriceProperties::GroupedWithProratedMinimum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GroupedWithMeteredMinimum(
    PriceProperties::GroupedWithMeteredMinimum Value
) : Price, IVariant<GroupedWithMeteredMinimum, PriceProperties::GroupedWithMeteredMinimum>
{
    public static GroupedWithMeteredMinimum From(PriceProperties::GroupedWithMeteredMinimum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GroupedWithMinMaxThresholds(
    PriceProperties::GroupedWithMinMaxThresholds Value
) : Price, IVariant<GroupedWithMinMaxThresholds, PriceProperties::GroupedWithMinMaxThresholds>
{
    public static GroupedWithMinMaxThresholds From(
        PriceProperties::GroupedWithMinMaxThresholds value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MatrixWithDisplayName(PriceProperties::MatrixWithDisplayName Value)
    : Price,
        IVariant<MatrixWithDisplayName, PriceProperties::MatrixWithDisplayName>
{
    public static MatrixWithDisplayName From(PriceProperties::MatrixWithDisplayName value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GroupedTieredPackage(PriceProperties::GroupedTieredPackage Value)
    : Price,
        IVariant<GroupedTieredPackage, PriceProperties::GroupedTieredPackage>
{
    public static GroupedTieredPackage From(PriceProperties::GroupedTieredPackage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MaxGroupTieredPackage(PriceProperties::MaxGroupTieredPackage Value)
    : Price,
        IVariant<MaxGroupTieredPackage, PriceProperties::MaxGroupTieredPackage>
{
    public static MaxGroupTieredPackage From(PriceProperties::MaxGroupTieredPackage value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ScalableMatrixWithUnitPricing(
    PriceProperties::ScalableMatrixWithUnitPricing Value
) : Price, IVariant<ScalableMatrixWithUnitPricing, PriceProperties::ScalableMatrixWithUnitPricing>
{
    public static ScalableMatrixWithUnitPricing From(
        PriceProperties::ScalableMatrixWithUnitPricing value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ScalableMatrixWithTieredPricing(
    PriceProperties::ScalableMatrixWithTieredPricing Value
)
    : Price,
        IVariant<ScalableMatrixWithTieredPricing, PriceProperties::ScalableMatrixWithTieredPricing>
{
    public static ScalableMatrixWithTieredPricing From(
        PriceProperties::ScalableMatrixWithTieredPricing value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CumulativeGroupedBulk(PriceProperties::CumulativeGroupedBulk Value)
    : Price,
        IVariant<CumulativeGroupedBulk, PriceProperties::CumulativeGroupedBulk>
{
    public static CumulativeGroupedBulk From(PriceProperties::CumulativeGroupedBulk value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Minimum(PriceProperties::Minimum Value)
    : Price,
        IVariant<Minimum, PriceProperties::Minimum>
{
    public static Minimum From(PriceProperties::Minimum value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Percent(PriceProperties::Percent Value)
    : Price,
        IVariant<Percent, PriceProperties::Percent>
{
    public static Percent From(PriceProperties::Percent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class EventOutput(PriceProperties::EventOutput Value)
    : Price,
        IVariant<EventOutput, PriceProperties::EventOutput>
{
    public static EventOutput From(PriceProperties::EventOutput value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
