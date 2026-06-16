using System;
using System.Collections.Generic;

namespace MOVIFY.Model;

public partial class Director
{
    public int DirectorId { get; set; }

    public required string DirectorFullName { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
