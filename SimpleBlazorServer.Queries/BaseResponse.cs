using System.Collections.Generic;

namespace SimpleBlazorServer.Queries
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Data = new List<T>();
        }
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
