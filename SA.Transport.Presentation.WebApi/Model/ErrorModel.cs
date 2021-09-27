using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA.Transport.Presentation.WebApi.Model
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public string Exception { get; set; } = "";
        public int ErrorCode { get; set; } = StatusCodes.Status400BadRequest;
    }
}
