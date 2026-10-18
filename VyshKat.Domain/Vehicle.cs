namespace VyshKat.Domain;

public abstract class Vehicle : IInventoryItem, IEnergyConsumer, IBeginnerFriendly
{
    private string _inventoryNumber;
    private string _name;
    private double _energyConsumption;
    private int _beginnerLevel;
    public Vehicle(string inventoryNumber, string name, double energyConsumption, int beginnerLevel)
    {
        if (string.IsNullOrWhiteSpace(inventoryNumber))
        {
            throw new ArgumentException("Number cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }
        if (energyConsumption <= 0)
        {
            throw new ArgumentException("Energy must be positive");
        }
        if (beginnerLevel < 1 || beginnerLevel > 10)
        {
            throw new ArgumentException("Level must be between 1 and 10");
        }
        _inventoryNumber = inventoryNumber;
        _name = name;
        _energyConsumption = energyConsumption;
        _beginnerLevel = beginnerLevel;
    }
    public string InventoryNumber { get { return _inventoryNumber; } }
    public string Name { get { return _name; } }
    public double EnergyConsumption { get { return _energyConsumption; } }
    public int BeginnerLevel { get { return _beginnerLevel; } }
}