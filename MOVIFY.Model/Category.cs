using System;
using System.Collections.Generic;

namespace MOVIFY.Model;

public partial class Category
{
    public int CategoryId { get; set; }

    public required string CategoryName { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
