using FluentValidation.TestHelper;
using Password.Api.Models;
using Password.Api.Validators;
using System;
using Xunit;

namespace Password.Api.Test
{
    public class PasswordValidatorTest
    {
        private readonly PasswordValidator passwordValidator;

        public PasswordValidatorTest()
        {
            passwordValidator = new PasswordValidator();
        }

        [Fact]
        public void Senha_não_pode_ser_null()
        {
            var model = new PasswordRequest { Password = null };
            var result = passwordValidator.TestValidate(model);
            var aa = result.ShouldHaveValidationErrorFor(a => a.Password)
                           .WithErrorMessage("'Password' não pode ser nulo.");
        }

        [Fact]
        public void Senha_não_contem_letra_maiuscula()
        {
            var model = new PasswordRequest { Password = "aa" };
            var result = passwordValidator.TestValidate(model);
            var aa = result.ShouldHaveValidationErrorFor(a => a.Password)
                           .WithErrorMessage("Não contem letra maiuscula");
        }

        [Fact]
        public void Senha_não_contem_letra_minuscula()
        {
            var model = new PasswordRequest { Password = "AB" };
            var result = passwordValidator.TestValidate(model);
            var aa = result.ShouldHaveValidationErrorFor(a => a.Password)
                           .WithErrorMessage("Não contem letra minuscula");
        }

        [Fact]
        public void Senha_deve_conter_caractere()
        {
            var model = new PasswordRequest { Password = "AAAbbbCc" };
            var result = passwordValidator.TestValidate(model);
            var aa = result.ShouldHaveValidationErrorFor(a => a.Password)
                           .WithErrorMessage("Deve conter no mínimo um caractere especial");
        }

        [Theory]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        public void Senha_não_deve_conter_caractere_duplicados(string password)
        {
            var model = new PasswordRequest { Password = password };
            var result = passwordValidator.TestValidate(model);
            var aa = result.ShouldHaveValidationErrorFor(a => a.Password)
                           .WithErrorMessage("Não deve conter caracteres duplicados ou repetidos");
        }

        [Fact]
        public void Senha_não_deve_conter_espaços_em_branco()
        {
            var model = new PasswordRequest { Password = "AbTp9 fok" };
            var result = passwordValidator.TestValidate(model);
            var aa = result.ShouldHaveValidationErrorFor(a => a.Password)
                           .WithErrorMessage("Não deve conter espaços em branco");
        }

        [Fact]
        public void Senha_deve_conter_minimo_9_caracteres()
        {
            var model = new PasswordRequest { Password = "Abfok$" };
            var result = passwordValidator.TestValidate(model);
            var aa = result.ShouldHaveValidationErrorFor(a => a.Password)
                           .WithErrorMessage("Deve conter no minimo 9 caracteres");
        }

        [Fact]
        public void Senha_valido()
        {
            var model = new PasswordRequest { Password = "AbTp9!fok" };
            var result = passwordValidator.TestValidate(model);
           result.ShouldNotHaveValidationErrorFor(a => a.Password);
        }
    }
}
