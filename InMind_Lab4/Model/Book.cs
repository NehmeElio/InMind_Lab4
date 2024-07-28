using System;
using System.Collections.Generic;

namespace InMind_Lab4.Model;

public partial class Book
{
    public int BookId { get; set; }

    public int? AuthorId { get; set; }

    public string? Title { get; set; }

    public string? Isbn { get; set; }

    public int? PublishedYear { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
