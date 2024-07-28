using System;
using System.Collections.Generic;

namespace InMind_Lab4.Model;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Department { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
