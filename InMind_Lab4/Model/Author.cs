using System;
using System.Collections.Generic;

namespace InMind_Lab4.Model;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
