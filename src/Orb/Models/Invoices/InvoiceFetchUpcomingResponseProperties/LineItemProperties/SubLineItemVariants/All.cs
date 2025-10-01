using Orb.Core;
using Models = Orb.Models;

namespace Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.LineItemProperties.SubLineItemVariants;

public sealed record class MatrixSubLineItem(Models::MatrixSubLineItem Value)
    : SubLineItem,
        IVariant<MatrixSubLineItem, Models::MatrixSubLineItem>
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

public sealed record class TierSubLineItem(Models::TierSubLineItem Value)
    : SubLineItem,
        IVariant<TierSubLineItem, Models::TierSubLineItem>
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

public sealed record class OtherSubLineItem(Models::OtherSubLineItem Value)
    : SubLineItem,
        IVariant<OtherSubLineItem, Models::OtherSubLineItem>
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
