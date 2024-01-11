namespace MovieStore.Data.Entities;

public class Purchase
{
    public int PurchaseId { get; set; }
    public int CustomerId { get; set; }
    public int FilmId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Film Film { get; set; }
}
