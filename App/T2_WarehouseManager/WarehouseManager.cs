namespace App.T2_WarehouseManager;

public class Product
{
    public int ID { get; }
    public string Name { get; }

    public Product(int id, string name)
    {
        ID = id;
        Name = name;
    }
}

public class Electronics : Product
{
    public int WarrantyMonths { get; }

    public Electronics(int id, string name, int warrantyMonths)
        : base(id, name)
    {
        WarrantyMonths = warrantyMonths;
    }
}

public class Food : Product
{
    public DateTime ExpirationDate { get; }

    public Food(int id, string name, DateTime expirationDate)
        : base(id, name)
    {
        ExpirationDate = expirationDate;
    }
}

public class WarehouseManager<T> where T : Product
{
    private readonly IEnumerable<T> _items;

    public WarehouseManager(IEnumerable<T> items)
    {
        if (items == null)
            throw new ArgumentNullException(nameof(items));

        _items = items;
    }

    public void PrintBasicInfo()
    {
        foreach (var item in _items)
        {
            Console.WriteLine($"ID: {item.ID}, Name: {item.Name}");
        }
    }
}