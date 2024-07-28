using System;
using System.Collections.Generic;

namespace InMind_Lab4.Model;

public partial class Class
{
    public int ClassId { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
