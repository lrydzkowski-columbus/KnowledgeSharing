namespace KnowledgeSharing.Persistence.Db.Common.Entities;

public class OrderEntity
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public UserEntity? User { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? FinalizedAt { get; set; }

    public ICollection<OrderPositionEntity> OrderPositions { get; set; } = new List<OrderPositionEntity>();
}
