using CVUploader.Models.Data;
using CVUploader.Models.Domains;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CVUploader.Repositoris
{
    public class CandidateRepository: GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(ApplicationDbContext context) : base(context) { }

        public string AddImage(IFormFile imageFile, IWebHostEnvironment webHostEnvironment)
        {
            string imagesFolder = Path.Combine(webHostEnvironment.WebRootPath, "images\\candidateImages");
            var imageTitle = Guid.NewGuid() + "_" + imageFile.FileName;
            string imagePath = Path.Combine(imagesFolder, imageTitle);
            Image image = Image.FromStream(imageFile.OpenReadStream(), true, true);

            int width = 256, height = 256;
            double ratio = (double)image.Width / image.Height;

            if (ratio >= 1)
                height = (int)(width / ratio);
            else
                width = (int)(height * ratio);

            var newImage = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
                newImage.Save(imagePath);
            }

            return imageTitle;
        }

        public async Task<string> AddResumeAsync(IFormFile resume, IWebHostEnvironment webHostEnvironment)
        {
            string ResumesFolder = Path.Combine(webHostEnvironment.WebRootPath, "resumes");
            var fileName = Guid.NewGuid() + "_" + resume.FileName;
            string filePath = Path.Combine(ResumesFolder, fileName);

            var stream = new FileStream(filePath, FileMode.Create);
            await resume.CopyToAsync(stream);

            return fileName;
        }
    }
}
