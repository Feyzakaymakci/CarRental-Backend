using Core.DataAccess;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetDetailsDto();
        List<CarDetailDto> GetDetailsDtoByBrandIdAndColorId(int brandId, int colorId);
        List<CarDetailDto> GetDetailsDtoByCarId(int carId);
    }
}
