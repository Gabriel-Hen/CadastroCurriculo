using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
public class Course
{
    [Key]
    public int Id { get; set; }
    public int CurricolumId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly InitialDate { get; set; }
    public DateOnly? EndDate { get; set; }


    [ForeignKey(nameof(CurricolumId))]
    public Curricolum Curricolum { get; set; }
}
