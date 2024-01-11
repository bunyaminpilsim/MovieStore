namespace MovieStore.Schema;

public class PurchaseRequest
{
    public int CustomerId { get; set; }
    public int FilmId { get; set; }
}
public class PurchaseResponse
{
    public int PurchaseId { get; set; }
    public string CustomerName { get; set; }
    public string FilmName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
}

