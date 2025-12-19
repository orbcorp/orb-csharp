using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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
            EndDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            ModelType = ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate = "2023-09-22",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        string expectedEndDate = "2023-09-22";
        string expectedItemID = "4khy3nwzktxv7";
        ApiEnum<string, ModelType> expectedModelType = ModelType.Unit;
        string expectedName = "Line Item Name";
        double expectedQuantity = 1;
        string expectedStartDate = "2023-09-22";
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
            EndDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            ModelType = ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate = "2023-09-22",
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
            EndDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            ModelType = ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate = "2023-09-22",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LineItem>(element);
        Assert.NotNull(deserialized);

        string expectedEndDate = "2023-09-22";
        string expectedItemID = "4khy3nwzktxv7";
        ApiEnum<string, ModelType> expectedModelType = ModelType.Unit;
        string expectedName = "Line Item Name";
        double expectedQuantity = 1;
        string expectedStartDate = "2023-09-22";
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
            EndDate = "2023-09-22",
            ItemID = "4khy3nwzktxv7",
            ModelType = ModelType.Unit,
            Name = "Line Item Name",
            Quantity = 1,
            StartDate = "2023-09-22",
            UnitConfig = new() { UnitAmount = "unit_amount", Prorated = true },
        };

        model.Validate();
    }
}

public class ModelTypeTest : TestBase
{
    [Theory]
    [InlineData(ModelType.Unit)]
    public void Validation_Works(ModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelType.Unit)]
    public void SerializationRoundtrip_Works(ModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DueDateTest : TestBase
{
    [Fact]
    public void DateValidationWorks()
    {
        DueDate value = new("2019-12-27");
        value.Validate();
    }

    [Fact]
    public void DateTimeValidationWorks()
    {
        DueDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        value.Validate();
    }

    [Fact]
    public void DateSerializationRoundtripWorks()
    {
        DueDate value = new("2019-12-27");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<DueDate>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeSerializationRoundtripWorks()
    {
        DueDate value = new(DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<DueDate>(element);

        Assert.Equal(value, deserialized);
    }
}
