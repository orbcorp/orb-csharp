using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using SubLineItemVariants = Orb.Models.InvoiceProperties.LineItemProperties.SubLineItemVariants;

namespace Orb.Models.InvoiceProperties.LineItemProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<SubLineItem>))]
public abstract record class SubLineItem
{
    internal SubLineItem() { }

    public static SubLineItemVariants::MatrixSubLineItem Create(Models::MatrixSubLineItem value) =>
        new(value);

    public static SubLineItemVariants::TierSubLineItem Create(Models::TierSubLineItem value) =>
        new(value);

    public static SubLineItemVariants::OtherSubLineItem Create(Models::OtherSubLineItem value) =>
        new(value);

    public abstract void Validate();
}
