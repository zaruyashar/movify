using System;
using System.Collections.Generic;

namespace MOVIFY.Model;

public partial class Movie
{
    public int MovieId { get; set; }

    public string? MovieTitle { get; set; }

    public int? ReleaseYear { get; set; }

    public int? CategoryId { get; set; }

    public int? DirectorId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Director? Director { get; set; }
}
