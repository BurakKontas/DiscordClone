using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.LoadBalaner.Core.Models
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T Body { get; set; }
        public string Message { get; set; }
        private Response(bool IsSuccess, T Body, string Message)
        {
            this.IsSuccess = IsSuccess;
            this.Body = Body;
            this.Message = Message;
        }

        public static Response<T> Success(T Body)
        {
            return new Response<T>(true, Body, "");
        }

        public static Response<T> Fail(string Message)
        {
            return new Response<T>(false, default!, Message);
        }

        public static Response<T> Fail(Exception ex)
        {
            return new Response<T>(false, default!, ex.Message);
        }
    }
}
