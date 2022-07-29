using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Models;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using Business.Configuration.Validator.FluentValidation;
using System.Linq;
using Business.Constants.Message;
using Dto;

namespace Business.Concrete
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
         private IFilmDal _filmDal;

        public FilmService(IMapper mapper, IFilmDal filmDal)
        {
            _mapper = mapper;
            _filmDal = filmDal;
        }

        public IResult Add(CreateFilmDto createFilmDto)
        {
            var validator = new CreateFilmValidator();
            var valid = validator.Validate(createFilmDto);

            if (!valid.IsValid)
            {
                var messageText = string.Join(',', valid.Errors.Select(x => x.ErrorMessage));
                return new ErrorResult(messageText);
            }

            var mappedFilm = _mapper.Map<Film>(createFilmDto);
            _filmDal.Add(mappedFilm);
            return new SuccessResult(MessageText.FilmAddedSuccess);
        }

        public IResult Delete(int id)
        {

            var film = _filmDal.Get(f => f.Id == id);
            if(film is null)
            {
                return new ErrorResult(MessageText.FilmNotFound);
            }

            _filmDal.Delete(film);
            return new SuccessResult(MessageText.FilmDeleted);
        }

        public IDataResult<FilmDetailDto> Get(int id)
        {
            var film = _filmDal.Get(film => film.Id == id);
            if(film is null)
            {
                return new ErrorDataResult<FilmDetailDto>(MessageText.FilmNotFound);
            }

            var mappedFilm = _mapper.Map<FilmDetailDto>(film);
            return new SuccessDataResult<FilmDetailDto>(mappedFilm);
        }

        public IDataResult<List<FilmDetailDto>> GetAll()
        {
            var films = _filmDal.GetFilmDetailDtos();
            var mappedFilms = _mapper.Map<List<FilmDetailDto>>(films);
            return new SuccessDataResult<List<FilmDetailDto>>(mappedFilms);
        }

        public IResult Update(UpdateFilmDto updateFilmDto)
        {
            var validator = new UpdateFilmValidator();
            var valid = validator.Validate(updateFilmDto);

            if (!valid.IsValid)
            {
                var messageText = string.Join(',', valid.Errors.Select(x => x.ErrorMessage));
                return new ErrorResult(messageText);
            }

            var film = _filmDal.Get(f => f.Id == updateFilmDto.Id);
            if(film is null)
            {
                return new ErrorResult(MessageText.FilmNotFound);
            }

            var mappedFilm = _mapper.Map<Film>(updateFilmDto);
            _filmDal.Update(mappedFilm);
            return new SuccessResult($"The film with id {mappedFilm.Id} has been updated");
        }
    }
}
