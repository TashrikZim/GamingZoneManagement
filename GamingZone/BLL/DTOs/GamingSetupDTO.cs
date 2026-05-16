using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class GamingSetupDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Setup Name is Required")]
        public string SetupName { get; set; }

        [Required(ErrorMessage = "Setup Type is Required")]
        public string SetupType { get; set; }

        [Required(ErrorMessage = "Hourly Rate is Required")]
        public decimal HourlyRate { get; set; }

        [Required(ErrorMessage = "Status is Required")]
        public string Status { get; set; }
    }
}
