using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.MGT.Core
{
    public partial class WebApiResult<T> : BaseModel
    {
        public T Data { get; set; }
        public WebApiResult(T data)
        {
            Data = data;
        }

        public WebApiResult(string err)
        {
            AddError(err);
        }

        public static WebApiResult<T> OK(T data)
        {
            return new WebApiResult<T>(data);
        }

        public static WebApiResult<T> Error(string error)
        {
            return new WebApiResult<T>(error);
        }
    }


    public partial class WebApiResult : BaseModel
    {
        public WebApiResult(string error)
        {
            AddError(error);
        }

        public WebApiResult() { }

        public static WebApiResult Ok()
        {
            return new WebApiResult();
        }

        public static WebApiResult Error(string error)
        {
            return new WebApiResult(error);
        }
    }
}
