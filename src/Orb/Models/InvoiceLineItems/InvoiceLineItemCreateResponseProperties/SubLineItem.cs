using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using SubLineItemVariants = Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties.SubLineItemVariants;

namespace Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties;

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
