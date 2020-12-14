using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Password.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Password.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        public PasswordController()
        {

        }

        [HttpPost("validate-rule")]
        public ActionResult Post([FromBody] PasswordRequest request)
        {
            return Ok(ModelState.IsValid);
        }
    }
}
