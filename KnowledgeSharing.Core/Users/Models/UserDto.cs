namespace KnowledgeSharing.Core.Users.Models;

public class UserDto
{
    public int Id { get; set; }

    public string Login { get; set; } = "";

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public ICollection<string> RoleNames { get; set; } = new List<string>();
}
