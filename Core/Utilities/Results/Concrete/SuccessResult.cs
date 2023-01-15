using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message)     //Base burda Result oluyor.
        {



        }           
        public SuccessResult() : base(true)
        {

                                                       //Yani bu 2 sinde true değeri kendiliğinden dönüyor.
        } 


    }
}
