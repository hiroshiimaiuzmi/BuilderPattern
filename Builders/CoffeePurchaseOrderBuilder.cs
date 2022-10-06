using BuilderPattern.Models;

namespace BuilderPattern.Builders;

public class CoffeePurchaseOrderBuilder : IBuildsPurchaseOrders
{
    private string _id = string.Empty;
    private DateTime _requestDate;
    private string _companyName = string.Empty;
    private string _companyAddress = string.Empty;
    private Supplier _supplier = null!;
    private IEnumerable<LineItem> _lineItems = new List<LineItem>();

    public void SetId()
    {
        var date = DateTime.UtcNow.ToString("yyyy--MM--dd");
        _id = $"☕️coffee_{date}";
    }

    public void SetRequestDate()
    {
        _requestDate = DateTime.UtcNow;
    }

    public void SetAddress()
    {
        _companyAddress = "23 River run lane";
    }

    public void SetCompany()
    {
        _companyName = "River run Roasters";
    }

    public void SetItems()
    {
        _lineItems = new List<LineItem>{
            new("light roast", 3, 3.2m),
            new("dark roast", 3, 3.3m),
        };
    }

    public void SetSupplier()
    {
        _supplier = new Supplier
        (
            "River run Roasters",
            "Sam",
            "contact@productivedev.com"
        );
    }

    public PurchaseOrder BuildPurchaseOrder()
    {
        SetId();
        SetRequestDate();
        SetAddress();
        SetCompany();
        SetItems();
        SetSupplier();

        return new PurchaseOrder
        {
            Id = _id,
            CreatedOn = DateTime.UtcNow,
            CompanyName = _companyName,
            CompanyAddress = _companyAddress,
            LineItems = _lineItems,
            Supplier = _supplier,
            RequestDate = _requestDate
        };
    }

}