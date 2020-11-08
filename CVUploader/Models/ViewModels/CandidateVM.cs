using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVUploader.Models.ViewModels
{
    public class CandidateVM
    {
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        [DisplayName("Upload your Resume")]
        public IFormFile Resume { get; set; }
    }
}
