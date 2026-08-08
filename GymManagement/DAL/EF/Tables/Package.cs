using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Package
{
    public int PackageId { get; set; }

    public string? Title { get; set; }

    public int? Duration { get; set; }

    public decimal? Price { get; set; }

    public int? TrainerId { get; set; }

    public int? UserId { get; set; }

    public virtual Trainer? Trainer { get; set; }

    public virtual User? User { get; set; }
}
