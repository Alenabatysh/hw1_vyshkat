using VyshKat.Application;
using VyshKat.Domain;

namespace VyshKat.Tests;

public class ServiceCenterTests
{
    [Fact]
    public void CheckItem_WithValidDevice_ReturnsTrue()
    {
        ServiceCenter service = new();
        Scooter scooterExample = new("123", "scooter", 5.48, 4);

        bool success = service.CheckItem(scooterExample);

        Assert.Equal(true, success);
    }

    [Fact]
    public void CheckItem_WithEnergyAbove10_ReturnsFalse()
    {
        ServiceCenter service = new();
        ElectricBike electricBikeExample = new("654", "electric bike", 10.98, 2);

        bool success = service.CheckItem(electricBikeExample);

        Assert.Equal(false, success);
    }
}
