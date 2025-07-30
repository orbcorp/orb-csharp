using System.Text.Json.Serialization;
using SubLineItemVariants = Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties.SubLineItemVariants;

namespace Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties;

[JsonConverter(typeof(UnionConverter<SubLineItem>))]
public abstract record class SubLineItem
{
    internal SubLineItem() { }

    public static implicit operator SubLineItem(MatrixSubLineItem value) =>
        new SubLineItemVariants::MatrixSubLineItemVariant(value);

    public static implicit operator SubLineItem(TierSubLineItem value) =>
        new SubLineItemVariants::TierSubLineItemVariant(value);

    public static implicit operator SubLineItem(OtherSubLineItem value) =>
        new SubLineItemVariants::OtherSubLineItemVariant(value);

    public abstract void Validate();
}
