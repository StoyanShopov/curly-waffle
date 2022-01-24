using SBC.Common.Enums;

namespace SBC.Common
{
    public class ApiResult
    {
        public bool Succeeded { get; private set; }

        public bool Failure => !this.Succeeded;

        public ErrorEnum Error { get; private set; }

        public string Message { get; set; }

        public object Value { get; set; }

        public static implicit operator ApiResult(bool succeeded)
            => new ApiResult { Succeeded = succeeded };

        public static implicit operator ApiResult(ErrorEnum error)
            => new ApiResult
            {
                Succeeded = false,
                Error = error,
            };
    }
}
