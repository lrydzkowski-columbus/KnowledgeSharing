namespace KnowledgeSharing.Persistence.Db.Common.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string? Description { get; set; }

    public bool IsVisible { get; set; } = true;

    public int? ParentCategoryId { get; set; }

    public CategoryEntity? ParentCategory { get; set; } = null;

    public ICollection<CategoryEntity> ChildrenCategories { get; set; } = new List<CategoryEntity>();

    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
