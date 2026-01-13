using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class AddressInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddressInput
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddressInput
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddressInput
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddressInput
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AddressInput { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AddressInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddressInput
        {
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.True(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.True(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.True(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AddressInput
        {
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }
}
