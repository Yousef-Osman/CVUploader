using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVUploader.Models.Domains;
using CVUploader.Repositoris;
using Microsoft.AspNetCore.Mvc;

namespace CVUploader.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;

        public DashboardController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<IActionResult> Index()
        {
            var candidates = await _candidateRepository.GetAllAsync();
            return View(candidates);
        }
    }
}
