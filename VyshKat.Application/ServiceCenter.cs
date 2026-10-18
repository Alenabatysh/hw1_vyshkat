using VyshKat.Domain;

namespace VyshKat.Application;

public class ServiceCenter : IInspectionService
{
    public bool CheckItem(IInventoryItem item)
    {
        if (item is IEnergyConsumer consumer && consumer.EnergyConsumption > 10)
        {
            return false;
        }
        return true;
    }
}
