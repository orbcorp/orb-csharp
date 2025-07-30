using System.Text.Json.Serialization;
using SubLineItemVariants = Orb.Models.InvoiceProperties.LineItemProperties.SubLineItemVariants;

namespace Orb.Models.InvoiceProperties.LineItemProperties;

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
