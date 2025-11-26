using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class Mobile
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public int MobileNumber { get; set; }

        public string MobileType { get; set; }

        // Foreign key to Candidate
        [Required]
        public int CandidateNumber { get; set; }
        public Candidate Candidate { get; set; }    
    }
}
