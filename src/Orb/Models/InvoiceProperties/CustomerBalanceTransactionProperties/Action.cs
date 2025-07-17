using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.InvoiceProperties.CustomerBalanceTransactionProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Action, string>))]
public sealed record class Action(string value) : Orb::IEnum<Action, string>
{
    public static readonly Action AppliedToInvoice = new("applied_to_invoice");

    public static readonly Action ManualAdjustment = new("manual_adjustment");

    public static readonly Action ProratedRefund = new("prorated_refund");

    public static readonly Action RevertProratedRefund = new("revert_prorated_refund");

    public static readonly Action ReturnFromVoiding = new("return_from_voiding");

    public static readonly Action CreditNoteApplied = new("credit_note_applied");

    public static readonly Action CreditNoteVoided = new("credit_note_voided");

    public static readonly Action OverpaymentRefund = new("overpayment_refund");

    public static readonly Action ExternalPayment = new("external_payment");

    readonly string _value = value;

    public enum Value
    {
        AppliedToInvoice,
        ManualAdjustment,
        ProratedRefund,
        RevertProratedRefund,
        ReturnFromVoiding,
        CreditNoteApplied,
        CreditNoteVoided,
        OverpaymentRefund,
        ExternalPayment,
    }

    public Value Known() =>
        _value switch
        {
            "applied_to_invoice" => Value.AppliedToInvoice,
            "manual_adjustment" => Value.ManualAdjustment,
            "prorated_refund" => Value.ProratedRefund,
            "revert_prorated_refund" => Value.RevertProratedRefund,
            "return_from_voiding" => Value.ReturnFromVoiding,
            "credit_note_applied" => Value.CreditNoteApplied,
            "credit_note_voided" => Value.CreditNoteVoided,
            "overpayment_refund" => Value.OverpaymentRefund,
            "external_payment" => Value.ExternalPayment,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Action FromRaw(string value)
    {
        return new(value);
    }
}
