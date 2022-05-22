namespace KnowledgeSharing.Persistence.Db.Common.Entities;

public class OrderPositionEntity
{
    public int Id { get; set; }

    public string ProductName { get; set; } = "";

    public string? ProductDescription { get; set; }

    public decimal ProductPrice { get; set; }

    public int Amount { get; set; }

    public int OrderId { get; set; }

    public OrderEntity OrderEntity { get; set; } = new();
}
