using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.EntityFramework.API.Models.Dto
{
    public class RickMortyApiCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}