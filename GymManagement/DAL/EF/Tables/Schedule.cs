using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int TrainerId { get; set; }

    public string DayName { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string SessionName { get; set; } = null!;

    public virtual Trainer Trainer { get; set; } = null!;
}
