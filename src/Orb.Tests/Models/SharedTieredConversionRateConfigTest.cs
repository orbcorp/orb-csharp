using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedTieredConversionRateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedTieredConversionRateConfig
        {
            ConversionRateType = ConversionRateType.Tiered,
            TieredConfig = new(
                [
                    new()
                    {
                        FirstUnit = 0,
                        UnitAmount = "unit_amount",
                        LastUnit = 0,
                    },
                ]
            ),
        };

        ApiEnum<string, ConversionRateType> expectedConversionRateType = ConversionRateType.Tiered;
        ConversionRateTieredConfig expectedTieredConfig = new(
            [
                new()
                {
                    FirstUnit = 0,
                    UnitAmount = "unit_amount",
                    LastUnit = 0,
                },
            ]
        );

        Assert.Equal(expectedConversionRateType, model.ConversionRateType);
        Assert.Equal(expectedTieredConfig, model.TieredConfig);
    }
}
