using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetByCarId(int carId);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetDetails();
        IDataResult<List<CarDetailDto>> GetDetailsDtoByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetDetailsDtoByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetDetailsDtoByColorId(int colorId);
    }
}
