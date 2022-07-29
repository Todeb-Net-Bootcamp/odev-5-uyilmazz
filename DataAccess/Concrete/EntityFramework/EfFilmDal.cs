using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Dto;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFilmDal : EfEntityRepository<Film, Homework5Context>, IFilmDal
    {
        public List<Film> GetFilmDetailDtos()
        {
            using (var context = new Homework5Context())
            {
                var films = context.Films.Include(x => x.Category);
                return films.ToList();
            }
        }
    }
}
