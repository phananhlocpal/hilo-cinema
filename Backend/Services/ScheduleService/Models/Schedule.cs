using System;
using System.Collections.Generic;

namespace ScheduleService.Models;

public partial class Schedule
{
    public int TheaterId { get; set; }

    public int MovieId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public string MovieType { get; set; } = null!;

    public int RoomId { get; set; }
}
