using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<T>:IResult
    {
        //Hem Data hem bool hemde message gönderecek.O yüzden IResult ı implemente ettik.
        T Data { get; }


    }
}
