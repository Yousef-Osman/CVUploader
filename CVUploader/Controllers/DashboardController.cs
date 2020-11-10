using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVUploader.Models.Domains;
using CVUploader.Models.ViewModels;
using CVUploader.Repositoris;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CVUploader.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DashboardController(ICandidateRepository candidateRepository,
                                   IWebHostEnvironment webHostEnvironment)
        {
            _candidateRepository = candidateRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var candidates = await _candidateRepository.GetAllAsync();
            return View(candidates);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateVM candidate)
        {
            if (ModelState.IsValid)
            {
                try
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

                    await _candidateRepository.AddAsync(newCandidate);
                    await _candidateRepository.SaveAllAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View();
                }
            }

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var candidate = await _candidateRepository.GetAsync(id);
            return View(candidate);
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var candidate = await _candidateRepository.GetAsync(id);
                _candidateRepository.Delete(candidate);
                await _candidateRepository.SaveAllAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
