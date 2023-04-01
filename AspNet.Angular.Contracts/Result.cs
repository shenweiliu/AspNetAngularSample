using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AspNet.Angular.Contracts
{
    [Serializable]
    public class StatusMessage : IStatusMessage
    {
        /// <summary>
        /// Optional: A localizable, standardized error code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Required: The textual description of the error.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Optional: Additional information to help identify the source of the error.
        /// </summary>
        public string Scope { get; set; }
    }

    [Serializable]
    public class Result : IResult
    {
        public StatusCode Status { get; private set; }

        // NOTE: An interface can't be used here
        //       because this will be serialized/deserialized
        //       through WCF calls.
        //       An interface can't be deserialized.
        public List</*I*/StatusMessage> Errors { get; private set; }

        public Result(StatusCode status)
        {
            this.Status = status;
        }

        public Result(StatusCode status, List</*I*/StatusMessage> errors)
            : this(status)
        {
            this.Errors = errors;
        }

        public Result(StatusCode status, params /*I*/StatusMessage[] errors)
            : this(status)
        {
            this.Errors = errors.ToList();
        }

        public static Result Succeed()
        {
            return new Result(StatusCode.Ok);
        }

        public static Result Fail(StatusCode status)
        {
            return new Result(status);
        }

        public static Result Fail(StatusCode status, params /*I*/StatusMessage[] errors)
        {
            return new Result(status, errors);
        }

        public static Result Fail(StatusCode status, List</*I*/StatusMessage> errors)
        {
            return new Result(status, errors);
        }

        public static Result Fail(StatusCode errorStatus, Exception ex)
        {
            return Result.Fail(errorStatus, GetExceptionMessages(ex));
        }

        public static Result Fail(StatusCode status, string errorMessage)
        {
            return new Result(status, new StatusMessage() { Detail = errorMessage });
        }

        public static Result Forbidden(string errorMessage)
        {
            return Fail(StatusCode.Forbidden, errorMessage);
        }


        public static Result<T> Succeed<T>(T data)
        {
            return new Result<T>(StatusCode.Ok, data);
        }

        public static Result<T> Fail<T>(StatusCode status)
        {
            return new Result<T>(status);
        }

        public static Result<T> Fail<T>(StatusCode status, params /*I*/StatusMessage[] errors)
        {
            return new Result<T>(status, errors);
        }
        public static Result<T> Fail<T>(StatusCode status, Exception ex)
        {
            return new Result<T>(status, GetExceptionMessages(ex));
        }

        private static List<StatusMessage> GetExceptionMessages(Exception ex)
        {
            List<StatusMessage> statusMessages = new List<StatusMessage>();
            var current = ex;
            while (current != null)
            {
                statusMessages.Add(new StatusMessage { Detail = current.Message });
                current = current.InnerException;
            }
            return statusMessages;
        }
        public static Result<T> Fail<T>(StatusCode status, List</*I*/StatusMessage> errors)
        {
            return new Result<T>(status, errors);
        }

        public static Result<T> Fail<T>(StatusCode status, string errorMessage)
        {
            return new Result<T>(status, new StatusMessage() { Detail = errorMessage });
        }

        public static Result<T> Forbidden<T>(string errorMessage)
        {
            return Fail<T>(StatusCode.Forbidden, errorMessage);
        }

        public static implicit operator bool(Result r)
        {
            return r.Status == StatusCode.Ok;
        }
    }

    [Serializable]
    public class Result<T> : Result, IResult<T>
    {
        public T Data { get; private set; }

        public Result(StatusCode status)
            : base(status)
        {
            this.Data = default(T);
        }

        public Result(StatusCode status, T data)
            : this(status, data, null)
        {
        }

        // NOTE: An interface can't be used here
        //       because this will be serialized/deserialized
        //       through WCF calls.
        //       An interface can't be deserialized.
        public Result(StatusCode status, List</*I*/StatusMessage> errors)
            : base(status, errors)
        {
        }

        public Result(StatusCode status, T data, List</*I*/StatusMessage> errors)
            : base(status, errors)
        {
            this.Data = data;
        }

        public Result(StatusCode status, params /*I*/StatusMessage[] errors)
            : this(status, errors.ToList())
        {
        }
    }

    [DataContract]
    public enum StatusCode
    {
        [EnumMember]
        Ok = 200, //Everything's good
        [EnumMember]
        BadRequest = 400, //Malformed request header or body
        [EnumMember]
        NotAuthenticated = 401, //Login is required to access this resource
        [EnumMember]
        Forbidden = 403, //Authenticated but not authorized to access this resource
        [EnumMember]
        NotFound = 404, //Resource does not exist
        [EnumMember]
        MethodNotAllowed = 405, //Invalid verb
        [EnumMember]
        ServerError = 500, //Unhandled exception, or something plain broke
        [EnumMember]
        ServiceUnavailable = 503, //System under maintenance, or required remote service is down
    }

}