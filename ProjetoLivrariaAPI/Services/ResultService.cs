using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace Locadora.API.Services {
    public class ResultService {
        public bool IsSucess { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? Message { get; init; }

        public static ResultService RequestError(ValidationResult validationResult) {
            return new ResultService {
                IsSucess = false,
                Message = validationResult.Errors.Select(x => x.ErrorMessage).ToArray(),
            };
        }

        public static ResultService Fail(string message) => new() { IsSucess = false, Message = new string[] { message } };
        public static ResultService<T> Fail<T>(string message) => new() { IsSucess = false, Message = new string[] { message } };

        public static ResultService Ok(string message) => new() { IsSucess = true, Message = new string[] { message } };
        public static ResultService<T> Ok<T>(T data) {
            return new ResultService<T> {
                Data = data,
                IsSucess = true
            };
        }
        public static ResultService<T> OkPaged<T>(T data, int totalRegisters , int totalPages , int page) {
            return new ResultService<T> {
                Data = data,
                TotalRegisters = totalRegisters,
                TotalPages = totalPages ,
                Page = page,
                IsSucess = true
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
