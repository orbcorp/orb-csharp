using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Events.Backfills.BackfillRevertResponseProperties;

/// <summary>
/// The status of the backfill.
/// </summary>
[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
{
    public static readonly Status Pending = new("pending");

    public static readonly Status Reflected = new("reflected");

    public static readonly Status PendingRevert = new("pending_revert");

    public static readonly Status Reverted = new("reverted");

    readonly string _value = value;

    public enum Value
    {
        Pending,
        Reflected,
        PendingRevert,
        Reverted,
    }

    public Value Known() =>
        _value switch
        {
            "pending" => Value.Pending,
            "reflected" => Value.Reflected,
            "pending_revert" => Value.PendingRevert,
            "reverted" => Value.Reverted,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
