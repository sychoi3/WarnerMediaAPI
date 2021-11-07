using System.Text.Json.Serialization;

namespace WarnerMedia.Domain
{
    public class ErrorResponse
    {
        public string Code { get; }
        public string Message { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Errors { get; }

        public ErrorResponse(string code, string message, object errors = null)
        {
            Code = code;
            Message = message;
            Errors = errors;
        }

        public static readonly ErrorResponse InternalServerErrorResponse =
            new ErrorResponse("InternalServerError", "Internal Server Error");
    }
}
