using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using SubLineItemVariants = Orb.Models.InvoiceProperties.LineItemProperties.SubLineItemVariants;

namespace Orb.Models.InvoiceProperties.LineItemProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<SubLineItem>))]
public abstract record class SubLineItem
{
    internal SubLineItem() { }

    public static implicit operator SubLineItem(Models::MatrixSubLineItem value) =>
        new SubLineItemVariants::MatrixSubLineItem(value);

    public static implicit operator SubLineItem(Models::TierSubLineItem value) =>
        new SubLineItemVariants::TierSubLineItem(value);

    public static implicit operator SubLineItem(Models::OtherSubLineItem value) =>
        new SubLineItemVariants::OtherSubLineItem(value);

    public abstract void Validate();
}
