namespace BuilderPattern.Models;

public class PurchaseOrder
{
    public string Id { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public DateTime RequestDate { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string CompanyAddress { get; set; } = string.Empty;
    public Supplier Supplier { get; set; } = null!;
    public IEnumerable<LineItem> LineItems { get; set; } = new List<LineItem>();

    public decimal TotalCost => LineItems.Select(item => item.Qty * item.UnitCost).Sum();
}