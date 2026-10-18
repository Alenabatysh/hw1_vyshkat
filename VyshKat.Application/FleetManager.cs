using VyshKat.Domain;

namespace VyshKat.Application;

public enum AddDeviceResult
{
    Success,
    DuplicateNumber,
    InspectionFailed
}

public class FleetManager
{
    private readonly List<IInventoryItem> _devices = new();
    private readonly IInspectionService _InspectionService;

    public FleetManager(IInspectionService inspectionService)
    {
        _InspectionService = inspectionService;
    }

    public AddDeviceResult AddDevice(IInventoryItem device)
    {
        if (_devices.Any(el => el.InventoryNumber == device.InventoryNumber))
        {
            return AddDeviceResult.DuplicateNumber;
        }
        if (_InspectionService.CheckItem(device))
        {
            _devices.Add(device);
            return AddDeviceResult.Success;
        }
        return AddDeviceResult.InspectionFailed;
    }

    public double GetTotalEnergyConsumption()
    {
        double totalEnergyConsumption = 0;
        foreach (IInventoryItem device in _devices)
        {
            if (device is IEnergyConsumer consumer)
            {
                totalEnergyConsumption += consumer.EnergyConsumption;
            }
        }
        return totalEnergyConsumption;
    }

    public List<IInventoryItem> GetBeginnerFriendlyDevices()
    {
        List<IInventoryItem> beginnerFriendly = new();
        foreach (IInventoryItem device in _devices)
        {
            if (device is IBeginnerFriendly beginner && beginner.BeginnerLevel >= 6)
            {
                beginnerFriendly.Add(device);
            }
        }
        return beginnerFriendly;
    }

    public List<(string, string)> GetAllDevicesInfo()
    {
        List<(string, string)> devicesInfo = new();
        foreach (IInventoryItem device in _devices)
        {
            devicesInfo.Add((device.InventoryNumber, device.Name));
        }
        return devicesInfo;
    }
}
