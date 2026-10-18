namespace VyshKat.Domain;

public class Scooter : Vehicle
{
    public Scooter(string inventoryNumber, string name, double energyConsumption, int beginnerLevel) :
        base(inventoryNumber, name, energyConsumption, beginnerLevel)
    { }
}
