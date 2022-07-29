using Core.Entities;
using System;

namespace Dto
{
    public class CreateFilmDto : IDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }

    }
}
