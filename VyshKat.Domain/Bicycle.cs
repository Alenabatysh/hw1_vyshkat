namespace VyshKat.Domain;

public class Bicycle : Vehicle
{
    public Bicycle(string inventoryNumber, string name, double energyConsumption, int beginnerLevel) :
        base(inventoryNumber, name, energyConsumption, beginnerLevel)
    { }
}
