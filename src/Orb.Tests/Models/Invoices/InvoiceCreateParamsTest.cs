using System;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Invoices;
using Models = Orb.Models;

namespace Orb.Tests.Models.Invoices;

public class LineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LineItem
        {
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            ItemID = "4khy3nwzktxv7",
            ModelType = ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedEndDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");
        string expectedItemID = "4khy3nwzktxv7";
        ApiEnum<string, ModelType> expectedModelType = ModelType.Unit;
        string expectedName = "Line Item Name";
        double expectedQuantity = 1;

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedStartDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");
        Models::UnitConfig expectedUnitConfig = new()
        {
            UnitAmount = "unit_amount",
            Prorated = true,
        };

        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedModelType, model.ModelType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedUnitConfig, model.UnitConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LineItem
        {
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            ItemID = "4khy3nwzktxv7",
            ModelType = ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LineItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LineItem
        {
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            ItemID = "4khy3nwzktxv7",
            ModelType = ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LineItem>(json);
        Assert.NotNull(deserialized);

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedEndDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");
        string expectedItemID = "4khy3nwzktxv7";
        ApiEnum<string, ModelType> expectedModelType = ModelType.Unit;
        string expectedName = "Line Item Name";
        double expectedQuantity = 1;

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedStartDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2023-09-22");
        Models::UnitConfig expectedUnitConfig = new()
        {
            UnitAmount = "unit_amount",
            Prorated = true,
        };

        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedModelType, deserialized.ModelType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedUnitConfig, deserialized.UnitConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LineItem
        {
            EndDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            ItemID = "4khy3nwzktxv7",
            ModelType = ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2023-09-22"),
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        model.Validate();
    }
}
