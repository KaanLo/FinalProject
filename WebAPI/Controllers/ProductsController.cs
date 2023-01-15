using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //Burdaki api buraya ulaşma adresi yani siteye" /api/Prodcuts yazdıgımız zaman Api miz çalısıyor.Controller ise Products oluyor burda controllerın ismi ProductsController yazmaya gerek yok.
    [ApiController]
    public class ProductsController : ControllerBase   //Burdaki Products ı Kllanıyorsun cagırırken.
    {
        //IOC diye bir yapı kullanıcaz.Değişimin kontrolü demektir.


        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
           var result= _productService.GetAll();

            if (result.Success==true)
            {
                return Ok(result);              //OBJECT veri tipine istediğini atayabiliyorsun.Bunun içinde de Overload olarak object Value var.
            }
            return BadRequest(result);         //Postman da sağ tarafta BadRequest ya da Ok yazsın ayrımı bu.

        }
        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product); 
            if (result.Success==true)
            {
                return Ok(result);

            }
            return BadRequest(result);



        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int ıd)
        {
            var result = _productService.GetById(ıd);
            if (result.Success==true)
            {
                return Ok(result);


            }
            return BadRequest(result);



        }


    }
}
