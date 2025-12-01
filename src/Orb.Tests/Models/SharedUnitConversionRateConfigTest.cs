using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedUnitConversionRateConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedUnitConversionRateConfig
        {
            ConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit,
            UnitConfig = new("unit_amount"),
        };

        ApiEnum<
            string,
            SharedUnitConversionRateConfigConversionRateType
        > expectedConversionRateType = SharedUnitConversionRateConfigConversionRateType.Unit;
        ConversionRateUnitConfig expectedUnitConfig = new("unit_amount");

        Assert.Equal(expectedConversionRateType, model.ConversionRateType);
        Assert.Equal(expectedUnitConfig, model.UnitConfig);
    }
}
