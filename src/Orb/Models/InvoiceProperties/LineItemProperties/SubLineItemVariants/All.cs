using System.Text.Json.Serialization;

namespace Orb.Models.InvoiceProperties.LineItemProperties.SubLineItemVariants;

[JsonConverter(typeof(VariantConverter<MatrixSubLineItemVariant, MatrixSubLineItem>))]
public sealed record class MatrixSubLineItemVariant(MatrixSubLineItem Value)
    : SubLineItem,
        IVariant<MatrixSubLineItemVariant, MatrixSubLineItem>
{
    public static MatrixSubLineItemVariant From(MatrixSubLineItem value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<TierSubLineItemVariant, TierSubLineItem>))]
public sealed record class TierSubLineItemVariant(TierSubLineItem Value)
    : SubLineItem,
        IVariant<TierSubLineItemVariant, TierSubLineItem>
{
    public static TierSubLineItemVariant From(TierSubLineItem value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<OtherSubLineItemVariant, OtherSubLineItem>))]
public sealed record class OtherSubLineItemVariant(OtherSubLineItem Value)
    : SubLineItem,
        IVariant<OtherSubLineItemVariant, OtherSubLineItem>
{
    public static OtherSubLineItemVariant From(OtherSubLineItem value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
