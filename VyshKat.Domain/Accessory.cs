namespace VyshKat.Domain;

abstract public class Accessory : IInventoryItem
{
    private string _inventoryNumber;
    private string _name;
    public Accessory(string inventoryNumber, string name)
    {
        if (string.IsNullOrWhiteSpace(inventoryNumber))
        {
            throw new ArgumentException("Number cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }
        _inventoryNumber = inventoryNumber;
        _name = name;
    }
    public string InventoryNumber { get { return _inventoryNumber; } }
    public string Name { get { return _name; } }
}
