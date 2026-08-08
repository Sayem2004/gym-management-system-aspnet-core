using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class PackageDTO
    {
        public int PackageId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? TrainerId { get; set; }

        public int? UserId { get; set; }
    }
}
