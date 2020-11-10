using CVUploader.Helpers;
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
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Please enter a valid Age")]
        public int Age { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Please select a file that doesn't exceed 1 MB")]
        [DisplayName("Upload your Resume")]
        [AllowFileSize(ErrorMessage = "file size shouldn't exceed 1 MB")]
        public IFormFile Resume { get; set; }
    }
}
