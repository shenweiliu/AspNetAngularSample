using System.Collections.Generic;

namespace AspNet.Angular.Contracts
{
    public interface IStatusMessage
    {
        /// <summary>
        /// Optional: A localizeable, standardized error code.
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Required: The textual description of the error.
        /// </summary>
        string Detail { get; set; }

        /// <summary>
        /// Optional: Additional information to help identify the source of the error.
        /// </summary>
        string Scope { get; set; }
    }

    public interface IResult
    {
        // NOTE: An interface can't be used here
        //       because this will be serialized/deserialized
        //       through WCF calls.
        //       An interface can't be deserialized.
        
        List</*I*/StatusMessage> Errors { get; }
    }

    public interface IResult<T> : IResult
    {
        T Data { get; }
    }

}