using VyshKat.Application;
using VyshKat.Domain;

SimpleContainer container = new();
container.Register<IInspectionService>(() => new ServiceCenter());
container.Register<FleetManager>(() => new FleetManager(container.Resolve<IInspectionService>()));
FleetManager manager = container.Resolve<FleetManager>();

bool demoExamplesAreIncluded = false;
Bicycle bicycleExample = new("1", "bicycle", 5.5, 6);
Scooter scooterExample = new("2", "scooter", 4.7, 5);
ElectricBike electricBikeExample = new("3", "electric bike", 3.4, 7);
ElectricBike electricBikeBadExample = new("4", "electric bike", 10.67, 7);

Helmet helmetExample = new("5", "helmet");
ChargingStation chargingStationExample = new("6", "charging station", 4.3);
DockingStation dockingStationExample = new("7", "docking station", 5.8);

(string, string, double, int) ReadInformationTransport()
{
    Console.WriteLine("Enter an id of transport that you want to add:");
    string idTransport = Console.ReadLine();
    Console.WriteLine("Enter a name of transport that you want to add:");
    string nameTransport = Console.ReadLine();
    Console.WriteLine("Enter energy consumption of transport that you want to add:");
    double energyConsumptionTransport;
    while (!double.TryParse(Console.ReadLine(), out energyConsumptionTransport))
    {
        Console.WriteLine("Incorrect input! Try again");
    }
    Console.WriteLine("Enter beginner level of transport that you want to add:");
    int beginnerLevelTransport;
    while (!int.TryParse(Console.ReadLine(), out beginnerLevelTransport))
    {
        Console.WriteLine("Incorrect input! Try again");
    }
    return (idTransport, nameTransport, energyConsumptionTransport, beginnerLevelTransport);
}

(string, string) ReadInformationItem()
{
    Console.WriteLine("Enter an id of item that you want to add:");
    string idItem = Console.ReadLine();
    Console.WriteLine("Enter a name of item that you want to add:");
    string nameItem = Console.ReadLine();
    return (idItem, nameItem);
}

double ReadInformationItemEnergy()
{
    Console.WriteLine("Enter energy consumption of type that you want to add");
    double energyConsumptionItem;
    while (!double.TryParse(Console.ReadLine(), out energyConsumptionItem))
    {
        Console.WriteLine("Incorrect input! Try again");
    }
    return energyConsumptionItem;
}


void ConsoleWriteStatus(IInventoryItem itemExample)
{
    AddDeviceResult success = manager.AddDevice(itemExample);
    if (success == AddDeviceResult.Success)
    {
        Console.WriteLine("Successful adding!");
        return;
    }
    else if (success == AddDeviceResult.InspectionFailed)
    {
        Console.WriteLine("Failure! Device didn't pass inspection. Try again");
    }
    else
    {
        Console.WriteLine("A device with such id already exists. Try again");
    }
}

while (true)
{
    Console.WriteLine("Choose variant:");
    Console.WriteLine("1. Add transport");
    Console.WriteLine("2. Add item");
    Console.WriteLine("3. Add demo-examples");
    Console.WriteLine("4. Show all devices information");
    Console.WriteLine("5. Show total devices energy consumption");
    Console.WriteLine("6. Show list of all devices for beginners");
    Console.WriteLine("7. Quit");
    int choice;
    while (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Incorrect input! Try again");
    }
    if (choice == 1)
    {
        Console.WriteLine("Enter a type of transport that you want to add:");
        Console.WriteLine("1. Bicycle");
        Console.WriteLine("2. Scooter");
        Console.WriteLine("3. ElectricBike");
        int typeTransport;
        while (!int.TryParse(Console.ReadLine(), out typeTransport) || typeTransport < 1 || typeTransport > 3)
        {
            Console.WriteLine("Incorrect input! Try again");
        }
        (string idTransport, string nameTransport,
                double energyConsumptionTransport, int beginnerLevelTransport) = ReadInformationTransport();
        if (typeTransport == 1)
        {
            Bicycle userTransport = new(idTransport, nameTransport, energyConsumptionTransport, beginnerLevelTransport);
            ConsoleWriteStatus(userTransport);
        }
        else if (typeTransport == 2)
        {
            Scooter userTransport = new(idTransport, nameTransport, energyConsumptionTransport, beginnerLevelTransport);
            ConsoleWriteStatus(userTransport);
        }
        else
        {
            ElectricBike userTransport = new(idTransport, nameTransport, energyConsumptionTransport, beginnerLevelTransport);
            ConsoleWriteStatus(userTransport);
        }

    }
    else if (choice == 2)
    {
        Console.WriteLine("Enter a type of item that you want to add:");
        Console.WriteLine("1. Helmet");
        Console.WriteLine("2. ChargingStation");
        Console.WriteLine("3. DockingStation");
        int typeItem;
        while (!int.TryParse(Console.ReadLine(), out typeItem) || typeItem < 1 || typeItem > 3)
        {
            Console.WriteLine("Incorrect input! Try again");
        }
        (string idItem, string nameItem) = ReadInformationItem();
        if (typeItem == 1)
        {
            Helmet userItem = new(idItem, nameItem);
            ConsoleWriteStatus(userItem);
        }
        else if (typeItem == 2)
        {
            double energyConsumptionItem = ReadInformationItemEnergy();
            ChargingStation userItem = new(idItem, nameItem, energyConsumptionItem);
            ConsoleWriteStatus(userItem);
        }
        else
        {
            double energyConsumptionItem = ReadInformationItemEnergy();
            DockingStation userItem = new(idItem, nameItem, energyConsumptionItem);
            ConsoleWriteStatus(userItem);
        }
    }
    else if (choice == 3)
    {
        if (!demoExamplesAreIncluded)
        {
            ConsoleWriteStatus(bicycleExample);
            ConsoleWriteStatus(scooterExample);
            ConsoleWriteStatus(electricBikeExample);
            ConsoleWriteStatus(electricBikeBadExample);
            ConsoleWriteStatus(helmetExample);
            ConsoleWriteStatus(chargingStationExample);
            ConsoleWriteStatus(dockingStationExample);
            Console.WriteLine("Demo data loaded!");
            demoExamplesAreIncluded = true;
        }
        else
        {
            Console.WriteLine("Demo examples are already included");
        }
    }
    else if (choice == 4)
    {
        List<(string, string)> devices = manager.GetAllDevicesInfo();
        if (devices.Count == 0)
        {
            Console.WriteLine("No devices yet");
        }
        else
        {
            foreach ((string idDevice, string nameDevice) in devices)
            {
                Console.WriteLine($"Id of device: {idDevice}, name of device: {nameDevice}");
            }
        }
    }
    else if (choice == 5)
    {
        double devicesStatistics = manager.GetTotalEnergyConsumption();
        Console.WriteLine($"Total devices energy consumption is {devicesStatistics}");
    }
    else if (choice == 6)
    {
        List<IInventoryItem> beginnerDevices = manager.GetBeginnerFriendlyDevices();
        if (beginnerDevices.Count == 0)
        {
            Console.WriteLine("No any devices for beginners yet");
        }
        else
        {
            foreach (IInventoryItem item in beginnerDevices)
            {
                Console.WriteLine($"Id of device: {item.InventoryNumber}, name of device: {item.Name}");
            }
        }
    }
    else if (choice == 7)
    {
        Console.WriteLine("Your session ended");
        break;
    }
    else
    {
        Console.WriteLine("Incorrect input! Try again");
    }
}