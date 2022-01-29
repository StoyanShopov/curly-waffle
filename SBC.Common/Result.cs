namespace SBC.Common
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    public class Result
    {
        public bool Succeeded { get; private set; }

        public ResultModel Data { get; private set; }

        public string Message { get; set; }

        public Tuple<HttpStatusCode, string> Error { get; private set; }

        public static implicit operator Result(bool succeeded)
            => new() { Succeeded = succeeded };

        public static implicit operator Result(ResultModel data)
          => new() { Succeeded = true, Data = data };

        public static implicit operator Result(Tuple<HttpStatusCode, string> error)
            => new() { Error = error };
    }
}
