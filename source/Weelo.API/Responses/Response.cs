namespace Weelo.API.Responses
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The response default
    /// </summary>
    public sealed class Response
    {
        public Response(short success, object data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        /// <summary>
        /// Success
        /// </summary>
        [Required]
        public short Success { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [Required]
        public object Data { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}