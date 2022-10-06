using BuilderPattern.Builders;
using BuilderPattern.Models;

public class PurchaseOrderProcessor
{
    public async Task GenerateWeeklyPurchaseOrder(IBuildsPurchaseOrders builder)
    {
        var purchaseOrder = builder.BuildPurchaseOrder();
        PrintPurchaseOrder(purchaseOrder);
        await SavePurchaseOrderToDatabase(purchaseOrder);
    }

    public async Task SavePurchaseOrderToDatabase(PurchaseOrder purchaseOrder)
    {
        Console.WriteLine($"Saving P.O. ({purchaseOrder.Id}) to database");
        await Task.Delay(100);
    }

    public void PrintPurchaseOrder(PurchaseOrder order)
    {
        Console.WriteLine($"----------------------------------------", ConsoleColor.Blue);
        Console.WriteLine($"== 📝 Generated Purchase Order", ConsoleColor.Blue);
        Console.WriteLine($"----------------------------------------", ConsoleColor.Blue);
        Console.WriteLine($"== ID: {order.Id} | {order.CreatedOn}", ConsoleColor.Blue);
        Console.WriteLine($"== {order.CompanyName}", ConsoleColor.Blue);
        Console.WriteLine($"== {order.CompanyAddress}", ConsoleColor.Blue);
        Console.WriteLine($"----------------------------------------");
        Console.WriteLine($"== Supplier: {order.Supplier.Name}", ConsoleColor.Blue);
        foreach (var item in order.LineItems)
        {
            Console.WriteLine($"  - {item.Qty} x {item.Name} @{Math.Round(item.UnitCost, 2)})", ConsoleColor.DarkBlue);
        }
        Console.WriteLine($"== PO Total: $ {Math.Round(order.TotalCost, 2)}", ConsoleColor.Blue);
        Console.WriteLine($"----------------------------------------", ConsoleColor.Blue);
        Console.WriteLine($"== Deliver By: {order.RequestDate})", ConsoleColor.Blue);
        Console.WriteLine($"----------------------------------------", ConsoleColor.Blue);
    }
}