using VyshKat.Domain;

namespace VyshKat.Tests;

public class ValidationTests
{
    [Fact]
    public void ConstructorVehicle_WithEmptyNumber_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Bicycle("", "bicycle", 5.4, 6));
    }

    [Fact]
    public void ConstructorVehicle_WithEmptyName_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Scooter("RAR_69", "", 7.3, 5));
    }

    [Fact]
    public void ConstructorVehicle_WithNegativeEnergy_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ElectricBike("III7", "electric bike", -10.8, 4));
    }

    [Fact]
    public void ConstructorVehicle_WithZeroEnergy_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ElectricBike("III7", "electric bike", 0, 4));
    }

    [Fact]
    public void ConstructorVehicle_WithInvalidBeginnerLevel_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ElectricBike("III7", "electric bike", 20, 12));
    }

    [Fact]
    public void ConstructorAccessory_WithEmptyNumber_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Helmet("", "helmet"));
    }

    [Fact]
    public void ConstructorAccessory_WithEmptyName_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Helmet("12-10-2026", ""));
    }

    [Fact]
    public void ConstructorAccessory_WithNegativeEnergy_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new ChargingStation("III7", "chrging station", -6.8));
    }

    [Fact]
    public void ConstructorAccessory_WithZeroEnergy_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new DockingStation("JJJ8", "docking station", 0));
    }
}
