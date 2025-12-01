using Orb.Models;

namespace Orb.Tests.Models;

public class PackageConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PackageConfig { PackageAmount = "package_amount", PackageSize = 1 };

        string expectedPackageAmount = "package_amount";
        long expectedPackageSize = 1;

        Assert.Equal(expectedPackageAmount, model.PackageAmount);
        Assert.Equal(expectedPackageSize, model.PackageSize);
    }
}
