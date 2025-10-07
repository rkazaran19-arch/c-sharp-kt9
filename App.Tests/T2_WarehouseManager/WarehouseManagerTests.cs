using App.T2_WarehouseManager;

namespace App.Tests.T2_WarehouseManager;

[TestFixture]
public class WarehouseManagerTests
{
    [Test]
    public void PrintBasicInfo_Prints_For_Electronics()
    {
        var items = new List<Electronics>
        {
            new Electronics(1, "Phone", 24),
            new Electronics(2, "Laptop", 12)
        };

        var manager = new WarehouseManager<Electronics>(items);
        using var sw = new StringWriter();
        Console.SetOut(sw);

        manager.PrintBasicInfo();

        var output = sw.ToString().Replace("\r\n", "\n");
        Assert.That(output, Is.EqualTo(
            "ID: 1, Name: Phone\n" +
            "ID: 2, Name: Laptop\n"));
    }

    [Test]
    public void PrintBasicInfo_Prints_For_Food()
    {
        var items = new List<Food>
        {
            new Food(10, "Milk", new DateTime(2030, 1, 1)),
            new Food(20, "Bread", new DateTime(2026, 12, 31))
        };

        var manager = new WarehouseManager<Food>(items);
        using var sw = new StringWriter();
        Console.SetOut(sw);

        manager.PrintBasicInfo();

        var output = sw.ToString().Replace("\r\n", "\n");
        Assert.That(output, Is.EqualTo(
            "ID: 10, Name: Milk\n" +
            "ID: 20, Name: Bread\n"));
    }

    [Test]
    public void Empty_List_Prints_Nothing()
    {
        var manager = new WarehouseManager<Electronics>(new List<Electronics>());
        using var sw = new StringWriter();
        Console.SetOut(sw);

        manager.PrintBasicInfo();
        Assert.That(sw.ToString(), Is.EqualTo(string.Empty));
    }

    [Test]
    public void Ctor_Null_Items_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new WarehouseManager<Food>(null!));
    }
}
