using System;
using System.Collections.Generic;

namespace MOVIFY.Model;

public partial class Movie
{
    public int MovieId { get; set; }

    public required string MovieTitle { get; set; }

    public required int ReleaseYear { get; set; }

    public required int CategoryId { get; set; }

    public int? DirectorId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Director? Director { get; set; }
}
