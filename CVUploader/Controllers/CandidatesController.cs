using System;
using System.Linq;
using System.Threading.Tasks;
using CVUploader.Models.Domains;
using CVUploader.Models.ViewModels;
using CVUploader.Repositoris;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CVUploader.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidatesController(ICandidateRepository candidateRepository,
                                    IWebHostEnvironment webHostEnvironment)
        {
            _candidateRepository = candidateRepository;
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
                var imageTitle = _candidateRepository.AddImage(candidate.Image, _webHostEnvironment);

                var fileName = await _candidateRepository.AddResumeAsync(candidate.Resume, _webHostEnvironment);

                var newCandidate = new Candidate()
                {
                    FullName = candidate.FullName,
                    Age = candidate.Age,
                    City = candidate.City,
                    Area = candidate.Area,
                    Address = candidate.Address,
                    ImageTitle = imageTitle,
                    FileName = fileName
                };

                //await _candidateRepository.AddAsync(newCandidate);
                //await _candidateRepository.SaveAllAsync();
            }

            return View();
        }
    }
}
