using Models = Orb.Models;
using Orb = Orb;
using PriceProperties = Orb.Models.PriceProperties;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.PriceVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Unit, PriceProperties::Unit>))]
public sealed record class Unit(PriceProperties::Unit Value)
    : Models::Price,
        Orb::IVariant<Unit, PriceProperties::Unit>
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

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Package, PriceProperties::Package>))]
public sealed record class Package(PriceProperties::Package Value)
    : Models::Price,
        Orb::IVariant<Package, PriceProperties::Package>
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

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Matrix, PriceProperties::Matrix>))]
public sealed record class Matrix(PriceProperties::Matrix Value)
    : Models::Price,
        Orb::IVariant<Matrix, PriceProperties::Matrix>
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

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Tiered, PriceProperties::Tiered>))]
public sealed record class Tiered(PriceProperties::Tiered Value)
    : Models::Price,
        Orb::IVariant<Tiered, PriceProperties::Tiered>
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

[Serialization::JsonConverter(typeof(Orb::VariantConverter<TieredBPS, PriceProperties::TieredBPS>))]
public sealed record class TieredBPS(PriceProperties::TieredBPS Value)
    : Models::Price,
        Orb::IVariant<TieredBPS, PriceProperties::TieredBPS>
{
    public static TieredBPS From(PriceProperties::TieredBPS value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<BPS, PriceProperties::BPS>))]
public sealed record class BPS(PriceProperties::BPS Value)
    : Models::Price,
        Orb::IVariant<BPS, PriceProperties::BPS>
{
    public static BPS From(PriceProperties::BPS value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<BulkBPS, PriceProperties::BulkBPS>))]
public sealed record class BulkBPS(PriceProperties::BulkBPS Value)
    : Models::Price,
        Orb::IVariant<BulkBPS, PriceProperties::BulkBPS>
{
    public static BulkBPS From(PriceProperties::BulkBPS value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Bulk, PriceProperties::Bulk>))]
public sealed record class Bulk(PriceProperties::Bulk Value)
    : Models::Price,
        Orb::IVariant<Bulk, PriceProperties::Bulk>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<ThresholdTotalAmount, PriceProperties::ThresholdTotalAmount>)
)]
public sealed record class ThresholdTotalAmount(PriceProperties::ThresholdTotalAmount Value)
    : Models::Price,
        Orb::IVariant<ThresholdTotalAmount, PriceProperties::ThresholdTotalAmount>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<TieredPackage, PriceProperties::TieredPackage>)
)]
public sealed record class TieredPackage(PriceProperties::TieredPackage Value)
    : Models::Price,
        Orb::IVariant<TieredPackage, PriceProperties::TieredPackage>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<GroupedTiered, PriceProperties::GroupedTiered>)
)]
public sealed record class GroupedTiered(PriceProperties::GroupedTiered Value)
    : Models::Price,
        Orb::IVariant<GroupedTiered, PriceProperties::GroupedTiered>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<TieredWithMinimum, PriceProperties::TieredWithMinimum>)
)]
public sealed record class TieredWithMinimum(PriceProperties::TieredWithMinimum Value)
    : Models::Price,
        Orb::IVariant<TieredWithMinimum, PriceProperties::TieredWithMinimum>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        TieredPackageWithMinimum,
        PriceProperties::TieredPackageWithMinimum
    >)
)]
public sealed record class TieredPackageWithMinimum(PriceProperties::TieredPackageWithMinimum Value)
    : Models::Price,
        Orb::IVariant<TieredPackageWithMinimum, PriceProperties::TieredPackageWithMinimum>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<PackageWithAllocation, PriceProperties::PackageWithAllocation>)
)]
public sealed record class PackageWithAllocation(PriceProperties::PackageWithAllocation Value)
    : Models::Price,
        Orb::IVariant<PackageWithAllocation, PriceProperties::PackageWithAllocation>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<UnitWithPercent, PriceProperties::UnitWithPercent>)
)]
public sealed record class UnitWithPercent(PriceProperties::UnitWithPercent Value)
    : Models::Price,
        Orb::IVariant<UnitWithPercent, PriceProperties::UnitWithPercent>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<MatrixWithAllocation, PriceProperties::MatrixWithAllocation>)
)]
public sealed record class MatrixWithAllocation(PriceProperties::MatrixWithAllocation Value)
    : Models::Price,
        Orb::IVariant<MatrixWithAllocation, PriceProperties::MatrixWithAllocation>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<TieredWithProration, PriceProperties::TieredWithProration>)
)]
public sealed record class TieredWithProration(PriceProperties::TieredWithProration Value)
    : Models::Price,
        Orb::IVariant<TieredWithProration, PriceProperties::TieredWithProration>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<UnitWithProration, PriceProperties::UnitWithProration>)
)]
public sealed record class UnitWithProration(PriceProperties::UnitWithProration Value)
    : Models::Price,
        Orb::IVariant<UnitWithProration, PriceProperties::UnitWithProration>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<GroupedAllocation, PriceProperties::GroupedAllocation>)
)]
public sealed record class GroupedAllocation(PriceProperties::GroupedAllocation Value)
    : Models::Price,
        Orb::IVariant<GroupedAllocation, PriceProperties::GroupedAllocation>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        GroupedWithProratedMinimum,
        PriceProperties::GroupedWithProratedMinimum
    >)
)]
public sealed record class GroupedWithProratedMinimum(
    PriceProperties::GroupedWithProratedMinimum Value
)
    : Models::Price,
        Orb::IVariant<GroupedWithProratedMinimum, PriceProperties::GroupedWithProratedMinimum>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        GroupedWithMeteredMinimum,
        PriceProperties::GroupedWithMeteredMinimum
    >)
)]
public sealed record class GroupedWithMeteredMinimum(
    PriceProperties::GroupedWithMeteredMinimum Value
)
    : Models::Price,
        Orb::IVariant<GroupedWithMeteredMinimum, PriceProperties::GroupedWithMeteredMinimum>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<MatrixWithDisplayName, PriceProperties::MatrixWithDisplayName>)
)]
public sealed record class MatrixWithDisplayName(PriceProperties::MatrixWithDisplayName Value)
    : Models::Price,
        Orb::IVariant<MatrixWithDisplayName, PriceProperties::MatrixWithDisplayName>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<BulkWithProration, PriceProperties::BulkWithProration>)
)]
public sealed record class BulkWithProration(PriceProperties::BulkWithProration Value)
    : Models::Price,
        Orb::IVariant<BulkWithProration, PriceProperties::BulkWithProration>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<GroupedTieredPackage, PriceProperties::GroupedTieredPackage>)
)]
public sealed record class GroupedTieredPackage(PriceProperties::GroupedTieredPackage Value)
    : Models::Price,
        Orb::IVariant<GroupedTieredPackage, PriceProperties::GroupedTieredPackage>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<MaxGroupTieredPackage, PriceProperties::MaxGroupTieredPackage>)
)]
public sealed record class MaxGroupTieredPackage(PriceProperties::MaxGroupTieredPackage Value)
    : Models::Price,
        Orb::IVariant<MaxGroupTieredPackage, PriceProperties::MaxGroupTieredPackage>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        ScalableMatrixWithUnitPricing,
        PriceProperties::ScalableMatrixWithUnitPricing
    >)
)]
public sealed record class ScalableMatrixWithUnitPricing(
    PriceProperties::ScalableMatrixWithUnitPricing Value
)
    : Models::Price,
        Orb::IVariant<ScalableMatrixWithUnitPricing, PriceProperties::ScalableMatrixWithUnitPricing>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        ScalableMatrixWithTieredPricing,
        PriceProperties::ScalableMatrixWithTieredPricing
    >)
)]
public sealed record class ScalableMatrixWithTieredPricing(
    PriceProperties::ScalableMatrixWithTieredPricing Value
)
    : Models::Price,
        Orb::IVariant<
            ScalableMatrixWithTieredPricing,
            PriceProperties::ScalableMatrixWithTieredPricing
        >
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<CumulativeGroupedBulk, PriceProperties::CumulativeGroupedBulk>)
)]
public sealed record class CumulativeGroupedBulk(PriceProperties::CumulativeGroupedBulk Value)
    : Models::Price,
        Orb::IVariant<CumulativeGroupedBulk, PriceProperties::CumulativeGroupedBulk>
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
