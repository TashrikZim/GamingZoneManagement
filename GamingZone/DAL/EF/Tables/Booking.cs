using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Booking
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int GamingSetupId { get; set; }

    public DateOnly BookingDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public decimal TotalAmount { get; set; }

    public string BookingStatus { get; set; } = null!;

    public virtual GamingSetup GamingSetup { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User User { get; set; } = null!;
}
