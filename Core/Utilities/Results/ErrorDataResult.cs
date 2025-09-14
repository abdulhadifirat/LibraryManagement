using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results;

public class ErrorDataResult<T> : IDataResult<T>
{
    public T Data => throw new NotImplementedException();

    public bool Success => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();
}

//public class ErrorDataResult<T> : DataResult<T>
    //public ErrorDataResult(T data, bool success) : base(data, false)
    //{
    //}

//public ErrorDataResult(T data, bool success, string message) : base(data, false, message)
//{
//}

//public ErrorDataResult() : base(default, false)
//{
//}

//public ErrorDataResult(string message) : base(default, false, message)
//{
//}

