using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVUploader.Helpers
{
    public class AllowFileSizeAttribute: ValidationAttribute
    {
        public int FileSize { get; private set; } 
        public AllowFileSizeAttribute()
        {
            FileSize = 1 * 1024 * 1024;
        }

        public override bool IsValid(object value)
        {
            bool isValid = false;

            if (value is IFormFile file)
            {
                isValid = file.Length <= FileSize;
            }

            return isValid;
        }
    }
}
