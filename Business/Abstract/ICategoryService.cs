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
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> Get(int id);

        IResult Add(CreateCategoryDto createCategoryDto);
        IResult Update(UpdateCategoryDto updateCategoryDto);
        IResult Delete(int id);
    }
}
