using Orb.Core;
using Orb.Models.Items;

namespace Orb.Tests.Models.Items;

public class ExternalConnectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        ApiEnum<string, ExternalConnectionName> expectedExternalConnectionName =
            ExternalConnectionName.Stripe;
        string expectedExternalEntityID = "external_entity_id";

        Assert.Equal(expectedExternalConnectionName, model.ExternalConnectionName);
        Assert.Equal(expectedExternalEntityID, model.ExternalEntityID);
    }
}
