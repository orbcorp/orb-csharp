using InvoiceLineItemCreateResponseProperties = Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties.SubLineItemVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<MatrixSubLineItem, Models::MatrixSubLineItem>)
)]
public sealed record class MatrixSubLineItem(Models::MatrixSubLineItem Value)
    : InvoiceLineItemCreateResponseProperties::SubLineItem,
        Orb::IVariant<MatrixSubLineItem, Models::MatrixSubLineItem>
{
    public static MatrixSubLineItem From(Models::MatrixSubLineItem value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<TierSubLineItem, Models::TierSubLineItem>)
)]
public sealed record class TierSubLineItem(Models::TierSubLineItem Value)
    : InvoiceLineItemCreateResponseProperties::SubLineItem,
        Orb::IVariant<TierSubLineItem, Models::TierSubLineItem>
{
    public static TierSubLineItem From(Models::TierSubLineItem value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<OtherSubLineItem, Models::OtherSubLineItem>)
)]
public sealed record class OtherSubLineItem(Models::OtherSubLineItem Value)
    : InvoiceLineItemCreateResponseProperties::SubLineItem,
        Orb::IVariant<OtherSubLineItem, Models::OtherSubLineItem>
{
    public static OtherSubLineItem From(Models::OtherSubLineItem value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
