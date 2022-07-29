using Core.DataAccess;
using Dto;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFilmDal : IEntityRepository<Film>
    {
        public List<Film> GetFilmDetailDtos();
    }
}
