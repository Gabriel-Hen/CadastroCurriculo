using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Courses
{
    [Key]
    public int Id { get; set; }
    public int CurricolumId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly InitialDate { get; set; }
    public DateOnly EndDate { get; set; }
}
