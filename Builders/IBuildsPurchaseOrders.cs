using BuilderPattern.Models;

namespace BuilderPattern.Builders;


public interface IBuildsPurchaseOrders
{
    PurchaseOrder BuildPurchaseOrder();
    void SetAddress();
    void SetCompany();
    void SetId();
    void SetItems();
    void SetRequestDate();
    void SetSupplier();
}
