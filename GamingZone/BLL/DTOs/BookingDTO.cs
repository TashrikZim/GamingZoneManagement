using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public int GamingSetupId { get; set; }

        [Required]
        public DateOnly BookingDate { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        public decimal TotalAmount { get; set; }

        public string BookingStatus { get; set; }
    }
}
