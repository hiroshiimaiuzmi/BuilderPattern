namespace BuilderPattern.Models;
public class FluentPurchaseOrderBuilder : IFluentPurchaseOrderBuilder
{

    private string _id = string.Empty;
    private DateTime _requestDate;
    private string _companyName = string.Empty;
    private string _companyAddress = string.Empty;
    private Supplier _supplier = null!;
    private IEnumerable<LineItem> _lineItems = new List<LineItem>();

    public IFluentPurchaseOrderBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public IFluentPurchaseOrderBuilder RequestDate(DateTime date)
    {
        _requestDate = date;
        return this;
    }

    public IFluentPurchaseOrderBuilder AtAddress(string address)
    {
        _companyAddress = address;
        return this;
    }

    public IFluentPurchaseOrderBuilder ForCompany(string companyName)
    {
        _companyName = companyName;
        return this;
    }

    public IFluentPurchaseOrderBuilder ForItems(List<LineItem> lineItems)
    {
        _lineItems = lineItems;
        return this;
    }

    public IFluentPurchaseOrderBuilder FromSupplier(Supplier supplier)
    {
        _supplier = supplier;
        return this;
    }

    public PurchaseOrder BuildPurchaseOrder()
    {
        return new()
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

    public static implicit operator PurchaseOrder(FluentPurchaseOrderBuilder builder)
    {
        return builder.BuildPurchaseOrder();
    }
}
