using BuilderPattern.Models;

namespace BuilderPattern.Builders;

public class BakeryPurchaseOrderBuilder : IBuildsPurchaseOrders
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
        _id = $"🍞bakery_{date}";
    }

    public void SetRequestDate()
    {
        _requestDate = DateTime.UtcNow;
    }

    public void SetAddress()
    {
        _companyAddress = "18 River run lane";
    }

    public void SetCompany()
    {
        _companyName = "River run Dry Goods";
    }

    public void SetItems()
    {
        _lineItems = new List<LineItem>{
            new("bread flour", 4, 1.2m),
            new("salt", 2, 0.3m),
            new("yeast", 8, 0/75m),
        };
    }

    public void SetSupplier()
    {
        _supplier = new Supplier
        (
            "River run Dry Goods",
            "Wes",
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