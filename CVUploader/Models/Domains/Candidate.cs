using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVUploader.Models.Domains
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ImageTitle { get; set; }
        [Required]
        public string FileName { get; set; }
    }
}
