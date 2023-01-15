using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //İş kodları
        //Ye

        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService= categoryService;
        }


        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour==14)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Product>>(_productDal.Getall(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllBycategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.Getall(p => p.CategoryId == categoryId));
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.Getall(p => p.UnitPrice >= min && p.UnitPrice <= max)); //Constructor a gönderiyorsun bunu.
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 14)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        [ValidationAspect(typeof(ProductValidator))]  //Bu şu demek: Add methodunu doğrula ProductValidator u kullanarak.
        public IResult Add(Product product)
        {
            //Burdaki kod standart bir kod.
            // var context = new ValidationContext<Product>(product);     //Burayı bütün projelerımde kullanmak ve ortak olsun istiyorum
            // ProductValidator prodocutValidator = new ProductValidator(); //Çünkü burda aşşagısı hep aynı oluyor.
            //var result= prodocutValidator.Validate(context);
            // if (!result.IsValid)
            // {
            //     throw new ValidationException(result.Errors);
            // }



            IResult result = BusinessRules.Run(CheckIfProductsNameExists(product.ProductName),
                CheckIfProdutsCountOfCategoryCorrect(product.CategoryId),Check());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }

        private IResult CheckIfProdutsCountOfCategoryCorrect(int categoryıd)
        {
            var result = _productDal.Getall(p => p.CategoryId == categoryıd).Count();
            if (result >= 10)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductsNameExists(string name)
        {

            var result = _productDal.Getall(p => p.ProductName == name).Any();


            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }
        private IResult Check()
        {

            var result = _categoryService.GetAll();

           if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceed);
            }
            return new SuccessResult();
        }

    }
}
