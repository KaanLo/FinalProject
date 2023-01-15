using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {

       IDataResult<List<Product>> GetAll();          //BURDAKİ <LİST<PRODUCT>> DÖNDÜRDÜĞÜ ŞEY YANİ T

        IDataResult<List<Product>> GetAllBycategoryId(int categoryId);

        IDataResult<List<Product>> GetByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product);

        IDataResult<Product> GetById(int id);

    }
}
