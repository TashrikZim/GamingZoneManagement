using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class GamingSetup
{
    public int Id { get; set; }

    public string SetupName { get; set; } = null!;

    public string SetupType { get; set; } = null!;

    public decimal HourlyRate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
