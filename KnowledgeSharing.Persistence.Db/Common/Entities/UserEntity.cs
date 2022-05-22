namespace KnowledgeSharing.Persistence.Db.Common.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public string Login { get; set; } = "";

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string? Email { get; set; }

    public ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();

    public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}
