using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Password.Api.Models;
using Password.Api.Validators;
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

        [HttpPost("validate-rule")]
        public ActionResult Post([FromBody] PasswordRequest request)
        {
            //var Validator = new PasswordValidator();
            //if (!Validator.Validate(request).IsValid)
            //    return BadRequest(Validator.Validate(request).IsValid);

            //return Ok(Validator.Validate(request).IsValid);
            return Ok(ModelState.IsValid);
        }
    }
}
