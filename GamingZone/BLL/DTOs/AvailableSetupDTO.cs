using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class AvailableSetupDTO
    {
        [Required]
        public string SetupType { get; set; }

    }
}
