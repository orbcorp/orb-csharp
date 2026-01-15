using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class NewAccountingSyncConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewAccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = "provider_type",
                },
            ],
            Excluded = true,
        };

        List<AccountingProviderConfig> expectedAccountingProviders =
        [
            new() { ExternalProviderID = "external_provider_id", ProviderType = "provider_type" },
        ];
        bool expectedExcluded = true;

        Assert.NotNull(model.AccountingProviders);
        Assert.Equal(expectedAccountingProviders.Count, model.AccountingProviders.Count);
        for (int i = 0; i < expectedAccountingProviders.Count; i++)
        {
            Assert.Equal(expectedAccountingProviders[i], model.AccountingProviders[i]);
        }
        Assert.Equal(expectedExcluded, model.Excluded);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewAccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = "provider_type",
                },
            ],
            Excluded = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAccountingSyncConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewAccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = "provider_type",
                },
            ],
            Excluded = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewAccountingSyncConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AccountingProviderConfig> expectedAccountingProviders =
        [
            new() { ExternalProviderID = "external_provider_id", ProviderType = "provider_type" },
        ];
        bool expectedExcluded = true;

        Assert.NotNull(deserialized.AccountingProviders);
        Assert.Equal(expectedAccountingProviders.Count, deserialized.AccountingProviders.Count);
        for (int i = 0; i < expectedAccountingProviders.Count; i++)
        {
            Assert.Equal(expectedAccountingProviders[i], deserialized.AccountingProviders[i]);
        }
        Assert.Equal(expectedExcluded, deserialized.Excluded);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewAccountingSyncConfiguration
        {
            AccountingProviders =
            [
                new()
                {
                    ExternalProviderID = "external_provider_id",
                    ProviderType = "provider_type",
                },
            ],
            Excluded = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NewAccountingSyncConfiguration { };

        Assert.Null(model.AccountingProviders);
        Assert.False(model.RawData.ContainsKey("accounting_providers"));
        Assert.Null(model.Excluded);
        Assert.False(model.RawData.ContainsKey("excluded"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NewAccountingSyncConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NewAccountingSyncConfiguration
        {
            AccountingProviders = null,
            Excluded = null,
        };

        Assert.Null(model.AccountingProviders);
        Assert.True(model.RawData.ContainsKey("accounting_providers"));
        Assert.Null(model.Excluded);
        Assert.True(model.RawData.ContainsKey("excluded"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NewAccountingSyncConfiguration
        {
            AccountingProviders = null,
            Excluded = null,
        };

        model.Validate();
    }
}
