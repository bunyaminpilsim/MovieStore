namespace MovieStore.Data.Entities;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerID { get; set; }
    public virtual Customer? Customer { get; set; }
    public int MovieID { get; set; }
    public virtual Movie? Movie { get; set; }
    public decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }
}