using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CVUploader.Models.Domains;
using CVUploader.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CVUploader.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidatesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CandidateVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidateVM candidate)
        {
            if (ModelState.IsValid)
            {
                //Dealing with image
                string imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/candidateImages");
                var imageTitle = Guid.NewGuid() + "_" + candidate.Image.FileName;
                string imagePath = Path.Combine(imagesFolder, imageTitle);

                int width = 256, height = 256;
                Image image = Image.FromStream(candidate.Image.OpenReadStream(), true, true);
                var newImage = new Bitmap(width, height);

                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.DrawImage(image, 0, 0, width, height);
                    newImage.Save(imagePath);
                }

                //Dealing with file
                string ResumesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "resumes");
                var fileName = Guid.NewGuid() + "_" + candidate.Resume.FileName;
                string filePath = Path.Combine(ResumesFolder, fileName);

                var stream = new FileStream(filePath, FileMode.Create);
                await candidate.Resume.CopyToAsync(stream);

                //creating the candidate object
                var newCandidate = new Candidate()
                {
                    FullName = candidate.FullName,
                    Age = candidate.Age,
                    City = candidate.City,
                    Area = candidate.Area,
                    Address = candidate.Address,
                    ImagePath = imagePath,
                    FilePath = filePath
                };
            }

            return View();
        }
    }
}
