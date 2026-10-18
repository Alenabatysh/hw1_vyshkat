namespace VyshKat.Domain;

public class ChargingStation : Accessory, IEnergyConsumer
{
    private double _energyConsumption;
    public ChargingStation(string inventoryNumber, string name, double energyConsumption) :
        base(inventoryNumber, name)
    {
        if (energyConsumption <= 0)
        {
            throw new ArgumentException("Energy must be positive");
        }
        _energyConsumption = energyConsumption;
    }
    public double EnergyConsumption { get { return _energyConsumption; } }
}
