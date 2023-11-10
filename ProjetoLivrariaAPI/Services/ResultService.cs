using System.Net;
using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace Locadora.API.Services {
    public class ResultService {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? Message { get; init; }
        public HttpStatusCode StatusCode { get; set; }



        public static ResultService BadRequest(ValidationResult validationResult) {
            return new ResultService {
                Message = validationResult.Errors.Select(x => x.ErrorMessage).ToArray(),
                StatusCode = HttpStatusCode.BadRequest,
            };
        }
        public static ResultService BadRequest(string message) => new() { StatusCode = HttpStatusCode.BadRequest, Message = new string[] { message } };
        public static ResultService NotFound(string message) => new() { StatusCode = HttpStatusCode.OK, Message = new string[] { message } };
        public static ResultService<T> NotFound<T>(string message) => new() { StatusCode = HttpStatusCode.OK, Message = new string[] { message } };

        public static ResultService Ok(string message) => new() { StatusCode = HttpStatusCode.OK, Message = new string[] { message } };
        public static ResultService<T> Ok<T>(T data) {
            return new ResultService<T> {
                Data = data,
                StatusCode = HttpStatusCode.OK
            };
        }
        public static ResultService<T> OkPaged<T>(T data, int totalRegisters , int totalPages , int page) {
            return new ResultService<T> {
                Data = data,
                TotalRegisters = totalRegisters,
                TotalPages = totalPages ,
                Page = page,
                StatusCode = HttpStatusCode.OK
            };
        }
    }

    public class ResultService<T> : ResultService {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TotalRegisters { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TotalPages { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int?Page { get; set; }
    }

}
