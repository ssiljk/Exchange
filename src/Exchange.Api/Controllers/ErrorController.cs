using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.Api.Controllers
{
    [Route("/error")]
    public class ErrorController : ControllerBase
    {
        public IActionResult HandleError() => Problem();
    }
}
