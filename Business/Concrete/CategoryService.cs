using AutoMapper;
using Business.Abstract;
using Business.Configuration.Validator.FluentValidation;
using Business.Constants.Message;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Dto;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryDal categoryDal, IMapper mapper = null)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public IResult Add(CreateCategoryDto createCategoryDto)
        {
            var validator = new CreateCategoryValidator();
            var valid = validator.Validate(createCategoryDto);

            if (!valid.IsValid)
            {
                var messageText = string.Join(',', valid.Errors.Select(x => x.ErrorMessage));
                return new ErrorResult(messageText);
            }

            var mappedCategory = _mapper.Map<Category>(createCategoryDto);
            _categoryDal.Add(mappedCategory);
            return new SuccessResult(MessageText.CategoryAddedSuccess);
        }

        public IResult Delete(int id)
        {
            var category = _categoryDal.Get(c => c.Id == id);
            if(category is null)
            {
                return new ErrorResult(MessageText.CategoryNotFound);
            }
            _categoryDal.Delete(category);
            return new SuccessResult(MessageText.CategoryDeleted);
        }

        public IDataResult<Category> Get(int id)
        {
            var category = _categoryDal.Get(c => c.Id == id);
            if(category is null)
            {
                return new ErrorDataResult<Category>(MessageText.CategoryNotFound);
            }
            return new SuccessDataResult<Category>(category);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var categories = _categoryDal.GetAll();
   
            return new SuccessDataResult<List<Category>>(categories);
        }

        public IResult Update(UpdateCategoryDto updateCategoryDto)
        {
            var validator = new UpdateCategoryValidator();
            var valid = validator.Validate(updateCategoryDto);

            if (!valid.IsValid)
            {
                var messageText = string.Join(',', valid.Errors.Select(x => x.ErrorMessage));
                return new ErrorResult(messageText);
            }

            var category = _categoryDal.Get(c => c.Id == updateCategoryDto.Id);
            if(category is null)
            {
                return new ErrorResult(MessageText.CategoryNotFound);
            }

            var mappedCategory = _mapper.Map<Category>(updateCategoryDto);
            _categoryDal.Update(mappedCategory);
            return new SuccessResult($"The category with id {mappedCategory.Id} has been updated");

        }
    }
}
