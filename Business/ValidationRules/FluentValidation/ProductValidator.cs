using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        //Kuralları constructor ın içine yazıyorsun.
        public ProductValidator()
        {
            //Rulefor un içindeki p Producta denk geliyor Üstte yazdığın için (AbstractValidator<Product> burdaki product).
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //Burda diyoruzki 1.ci kategorideki Ürünlerin fiyatı 10 dan büyük olmalı.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile baslamalı");
            

        }

        private bool StartWithA(string arg) // Burdaki arg Aslında senin gönderdiğin şey yani burda ProductName
        {
            return arg.StartsWith("A");
        }
    }
}
