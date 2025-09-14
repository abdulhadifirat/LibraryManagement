using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results;

public class ErrorDataResult<T> : IDataResult<T>
{
    public T Data { get; set; }

    public bool Success { get; }

    public string Message { get; }
    public ErrorDataResult(string message)
    {
    }
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



