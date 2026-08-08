using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class TrainerDTO
    {
        public int TrainerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Speciality { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int Experience { get; set; }
    }
}
