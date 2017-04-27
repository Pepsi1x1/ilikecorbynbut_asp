using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILikeCorbynBut.Models
{
    public class FaqViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DivId { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public bool Publish { get; set; }

        public ApplicationUser Author { get; set; }

        public ApplicationUser Reviewer { get; set; }

        [Required]
        public DateTime SubmittedOn { get; set; }
    }
}
