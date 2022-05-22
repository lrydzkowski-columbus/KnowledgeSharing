namespace KnowledgeSharing.Persistence.Db.Common.Entities;

public class ProductCommentEntity
{
    public int Id { get; set; }

    public string Comment { get; set; } = "";

    public int? ProductId { get; set; }

    public ProductEntity? Product { get; set; }
}
