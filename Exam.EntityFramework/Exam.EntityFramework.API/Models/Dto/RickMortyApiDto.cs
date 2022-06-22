using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.EntityFramework.API.Models.Dto
{
    public class RickMortyApiDto
    {
        public RickMortyApiInfoDto Info { get; set; }
        public List<RickMortyApiCharacter> Results { get; set; }
    }
}