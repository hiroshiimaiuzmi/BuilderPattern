
using BuilderPattern.Builders;
using BuilderPattern.Models;

// ----------------------------------------------------------------
// builders
var bakeryPoBuilder = new BakeryPurchaseOrderBuilder();
var coffeePoBuilder = new CoffeePurchaseOrderBuilder();

// Director 
var processor = new PurchaseOrderProcessor();

await processor.GenerateWeeklyPurchaseOrder(bakeryPoBuilder);
await processor.GenerateWeeklyPurchaseOrder(coffeePoBuilder);



// ----------------------------------------------------------------
// Second Approach - "Custom" builder using a fluent syntax
var customOrder = new FluentPurchaseOrderBuilder();

var items = new List<LineItem> {
                new("cups", 100, 1.0m),
                new("napkins", 250, 0.3m),
            };

var supplier = new Supplier("Jenkins", "contact@productivedev.com", "C.I. Jenkins");

customOrder
    .WithId("Custom_Order")
    .AtAddress("123 River run Lane")
    .ForCompany("Productive Dev")
    .FromSupplier(supplier)
    .RequestDate(DateTime.UtcNow.AddDays(2))
    .ForItems(items);

await processor.SavePurchaseOrderToDatabase(customOrder);
processor.PrintPurchaseOrder(customOrder);
