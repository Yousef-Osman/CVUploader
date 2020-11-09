using CVUploader.Models.Domains;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVUploader.Repositoris
{
    public interface ICandidateRepository: IGenericRepository<Candidate>
    {
        string AddImage(IFormFile imageFile, IWebHostEnvironment webHostEnvironment);
        Task<string> AddResumeAsync(IFormFile Resume, IWebHostEnvironment webHostEnvironment);
    }
}
