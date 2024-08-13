using Core.Enums;

namespace Core.Entities;
public class Person
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document {  get; set; }
    public Gender Gender {  get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
