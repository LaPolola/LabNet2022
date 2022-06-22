using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.EntityFramework.API.Models.Dto
{
    public class RickMortyApiInfoDto
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }
}