namespace BuilderPattern.Models;

public class LineItem
{
    public LineItem(string name, int qty, decimal unitCost)
        => (Name, Qty, UnitCost) = (name, qty, unitCost);

    public string Name { get; set; } = string.Empty;
    public int Qty { get; set; }
    public decimal UnitCost { get; set; }
}