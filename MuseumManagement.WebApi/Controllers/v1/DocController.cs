using Microsoft.AspNetCore.Mvc;
using MuseumManagement.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MuseumManagement.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class DocController : BaseApiController
    {
        [HttpGet]
        public Dictionary<string, string> GetErrorCodes()
        {
            return Enum.GetValues(typeof(ErrorCode))
                 .Cast<ErrorCode>()
                 .ToDictionary(t => ((int)t).ToString(), t => t.ToString());
        }
    }
}