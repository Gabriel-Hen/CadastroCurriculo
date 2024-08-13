using Core.Enums;

namespace Core.Entities;
public class Curricolum
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string Name { get; set; }
    public SchoolLevel SchoolLevel { get; set; }
    public decimal SalaryExpectation { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
