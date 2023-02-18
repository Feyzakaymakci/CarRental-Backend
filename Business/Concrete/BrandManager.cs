using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        //[SecuredOperation("admin, moderator")]
        //[ValidationAspect(typeof(BrandValidator))]
        //[CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExist(brand.BrandName));
            if (result != null)
            {
                return new ErrorResult();
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }


        public IResult Delete(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckBrandExist(brand.BrandId));
            if (result != null)
            {
                return new ErrorResult();
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }



        //[ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExist(brand.BrandName), CheckBrandExist(brand.BrandId));
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }


        //[CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }


        //[CacheAspect]
        public IDataResult<List<Brand>> GetById(int brandId)
        {
            IResult result = BusinessRules.Run(CheckBrandExist(brandId));
            if (result != null)
            {
                return new ErrorDataResult<List<Brand>>();
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == brandId), Messages.BrandListed);
        }


        private IResult CheckIfBrandNameExist(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.SameNameExist);
            }
            return new SuccessResult();
        }


        private IResult CheckBrandExist(int brandId)
        {
            var result = _brandDal.GetAll(b => b.BrandId == brandId).Any();
            if (!result)
            {
                return new ErrorResult("Brand not found.");
            }
            return new SuccessResult();
        }
    }
}
