using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string Name { get; set; } = null!;

    public string Speciality { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int Experience { get; set; }

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
