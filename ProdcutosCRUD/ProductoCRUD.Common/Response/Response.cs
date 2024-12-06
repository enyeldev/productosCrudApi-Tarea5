using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoCRUD.Common.Response
{
    public class Response<T> where T : class
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public bool Succsess { get; set; }

        public T Data { get; set; }
    }
}
