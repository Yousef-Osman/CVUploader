using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVUploader.Models.Domains
{
    public class ImageFile
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
