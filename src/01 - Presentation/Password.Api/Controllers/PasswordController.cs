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
        /// <summary>
        /// Validar formato de uma senha 
        /// </summary>
        /// <remarks>
        /// Considere uma senha sendo válida quando a mesma possuir as seguintes definições:
        /// <para>•	Nove ou mais caracteres</para>
        /// <para>•	Ao menos 1 dígito</para>
        /// <para>•	Ao menos 1 letra minúscula</para>
        /// <para>• Ao menos 1 letra maiúscula</para>
        /// <para>• Ao menos 1 caractere especial</para>
        /// <para>• Não possuir caracteres repetidos dentro do conjunto</para>
        /// </remarks>
        /// <param name="request">Parâmetros de requisição.</param>
        /// <returns>Imagem QRCode Estático</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Senha recusada</response>
        [HttpPost("validate-rule")]
        public ActionResult Post([FromBody] PasswordRequest request)
        {   
            return Ok(ModelState.IsValid);
        }
    }
}
