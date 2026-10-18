using Moq;
using VyshKat.Application;
using VyshKat.Domain;

namespace VyshKat.Tests;

public class FleetManagerTests
{
    [Fact]
    public void AddDevice_WithValidDevice_ReturnsSuccess()
    {
        ServiceCenter service = new();
        FleetManager manager = new(service);
        Bicycle bicycleExample = new("A1", "bicycle", 5.4, 7);

        AddDeviceResult success = manager.AddDevice(bicycleExample);

        Assert.Equal(AddDeviceResult.Success, success);
    }

    [Fact]
    public void AddDevice_WithSameId_ReturnsDuplicateNumber()
    {
        ServiceCenter service = new();
        FleetManager manager = new(service);
        Scooter scooterExample = new("B2", "scooter", 4.70, 6);
        ElectricBike electricBikeExample = new("B2", "electric bike", 3.65, 5);

        manager.AddDevice(scooterExample);
        AddDeviceResult success = manager.AddDevice(electricBikeExample);

        Assert.Equal(AddDeviceResult.DuplicateNumber, success);
    }

    [Fact]
    public void AddDevice_WithEnergyAbove10_ReturnsInspectionFailed()
    {
        ServiceCenter service = new();
        FleetManager manager = new(service);
        ChargingStation chargingStationExample = new("C3", "charging station", 10.66);

        AddDeviceResult success = manager.AddDevice(chargingStationExample);

        Assert.Equal(AddDeviceResult.InspectionFailed, success);
    }

    [Fact]
    public void GetTotalEnergyConsumption_ReturnsExpectedResult()
    {
        ServiceCenter service = new();
        FleetManager manager = new(service);
        Helmet helmetExample = new("J9", "helmet");
        ElectricBike electricBikeExample = new("K2", "electric bike", 2.78, 5);
        DockingStation dockingStationExample = new("U01", "docking station", 4.1);

        manager.AddDevice(helmetExample);
        manager.AddDevice(electricBikeExample);
        manager.AddDevice(dockingStationExample);
        double result = manager.GetTotalEnergyConsumption();

        Assert.Equal(true, Math.Abs(6.88 - result) < 0.000001);
    }

    [Fact]
    public void GetBeginnerFriendlyDevices_ReturnsExpectedResult()
    {
        ServiceCenter service = new();
        FleetManager manager = new(service);
        Bicycle bicycleExample = new("Q6", "bicycle", 5.3, 7);
        Scooter scooterExample = new("B2", "scooter", 4.70, 6);
        ElectricBike electricBikeExample = new("K2", "electric bike", 2.78, 4);

        manager.AddDevice(bicycleExample);
        manager.AddDevice(scooterExample);
        manager.AddDevice(electricBikeExample);
        List<IInventoryItem> result = manager.GetBeginnerFriendlyDevices();

        Assert.Equal(2, result.Count);
        Assert.Contains(result, el => el.Name == "bicycle");
        Assert.Contains(result, el => el.Name == "scooter");
    }

    [Fact]
    public void GetAllDevicesInfo_ReturnsExpectedResult()
    {
        ServiceCenter service = new();
        FleetManager manager = new(service);
        Bicycle bicycleExample = new("I1", "bicycle", 4.45, 6);
        Scooter scooterExample = new("O2", "scooter", 3.75, 5);

        manager.AddDevice(bicycleExample);
        manager.AddDevice(scooterExample);
        List<(string, string)> result = manager.GetAllDevicesInfo();

        Assert.Equal(2, result.Count);
        Assert.Contains(result, el => el == ("I1", "bicycle"));
        Assert.Contains(result, el => el == ("O2", "scooter"));
    }

    [Fact]
    public void DI_WorksProperly()
    {
        Mock<IInspectionService> mock = new();
        mock.Setup(x => x.CheckItem(It.IsAny<IInventoryItem>())).Returns(true);
        FleetManager manager = new(mock.Object);

        Bicycle bicycleExample = new("I1", "bicycle", 20, 6);
        AddDeviceResult success = manager.AddDevice(bicycleExample);
        Assert.Equal(AddDeviceResult.Success, success);
    }
}
