using Core.Enums;

namespace Core.Entities;
public class User
{
    public int Id { get; set; }
    public string Login {  get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
