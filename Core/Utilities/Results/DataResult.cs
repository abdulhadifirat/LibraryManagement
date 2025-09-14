using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results;

public class DataResult<T> : Result, IDataResult<T>
     where T : class
{
    public DataResult(T data, bool success) : base(success)
    {
        Data = data;
    }

    public DataResult(T data, bool success, string message) : base(success, message)
    {
        Data = data;
    }
    T Data { get; }

    T IDataResult<T>.Data => Data;

 
}
