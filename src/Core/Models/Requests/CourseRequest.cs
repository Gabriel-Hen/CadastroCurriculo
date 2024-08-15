using System;

namespace Core.Models.Requests;
public class CourseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly InitialDate { get; set; }
    public DateOnly EndDate { get; set; }
}
