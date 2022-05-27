namespace KnowledgeSharing.Persistence.Db.Common.Entities;

public class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public ICollection<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();

    public ICollection<ProductCommentEntity> Comments { get; set; } = new List<ProductCommentEntity>();
}
