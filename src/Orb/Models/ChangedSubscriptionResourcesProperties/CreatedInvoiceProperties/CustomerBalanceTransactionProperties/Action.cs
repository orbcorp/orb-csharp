using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.ChangedSubscriptionResourcesProperties.CreatedInvoiceProperties.CustomerBalanceTransactionProperties;

[JsonConverter(typeof(ActionConverter))]
public enum Action
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
    SmallInvoiceCarryover,
}

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" => Action.AppliedToInvoice,
            "manual_adjustment" => Action.ManualAdjustment,
            "prorated_refund" => Action.ProratedRefund,
            "revert_prorated_refund" => Action.RevertProratedRefund,
            "return_from_voiding" => Action.ReturnFromVoiding,
            "credit_note_applied" => Action.CreditNoteApplied,
            "credit_note_voided" => Action.CreditNoteVoided,
            "overpayment_refund" => Action.OverpaymentRefund,
            "external_payment" => Action.ExternalPayment,
            "small_invoice_carryover" => Action.SmallInvoiceCarryover,
            _ => (Action)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action.AppliedToInvoice => "applied_to_invoice",
                Action.ManualAdjustment => "manual_adjustment",
                Action.ProratedRefund => "prorated_refund",
                Action.RevertProratedRefund => "revert_prorated_refund",
                Action.ReturnFromVoiding => "return_from_voiding",
                Action.CreditNoteApplied => "credit_note_applied",
                Action.CreditNoteVoided => "credit_note_voided",
                Action.OverpaymentRefund => "overpayment_refund",
                Action.ExternalPayment => "external_payment",
                Action.SmallInvoiceCarryover => "small_invoice_carryover",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
