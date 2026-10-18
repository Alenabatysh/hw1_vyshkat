namespace VyshKat.Domain;

public class ElectricBike : Vehicle
{
    public ElectricBike(string inventoryNumber, string name, double energyConsumption, int beginnerLevel) :
        base(inventoryNumber, name, energyConsumption, beginnerLevel)
    { }
}
