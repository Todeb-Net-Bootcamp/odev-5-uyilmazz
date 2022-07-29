using Core.Utilities.Results;
using Dto;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFilmService
    {
        IDataResult<List<FilmDetailDto>> GetAll();
        IDataResult<FilmDetailDto> Get(int id);

        IResult Add(CreateFilmDto film);
        IResult Update(UpdateFilmDto updateFilmDto);
        IResult Delete(int id);
    }
}
