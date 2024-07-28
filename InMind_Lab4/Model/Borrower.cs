using System;
using System.Collections.Generic;

namespace InMind_Lab4.Model;

public partial class Borrower
{
    public int BorrowerId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
