using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
public class Curricolum
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SchoolLevel SchoolLevel { get; set; }
    public decimal SalaryExpectation { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public IEnumerable<Course>? Courses { get; set; }
    public IEnumerable<ProfessionalExperience>? ProfessionalExperiences { get; set; }
}
