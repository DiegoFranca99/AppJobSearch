using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobSearch.Domain.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string CityStare { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public string ContractType { get; set; }

        [Required]
        public string TecnologyTools { get; set; }
        
        public string CompanyDescription { get; set; }

        [Required]
        public string JobDescription { get; set; }
        public string Benefits { get; set; }

        [Required]
        [EmailAddress]
        public string InterestedSendEmailTo { get; set; }
        
        public DateTime PublicationDate { get; set; }
        
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }


    }
}
