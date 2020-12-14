using FluentValidation;
using Password.Api.Models;
using System;
using System.Text.RegularExpressions;

namespace Password.Api.Validators
{
    public class PasswordValidator : AbstractValidator<PasswordRequest>
    {
        public PasswordValidator()
        {
            RuleFor(x => x.Password)
                    .NotNull()
                    .NotEmpty();

            RuleFor(m => m.Password)
                    .Matches("[A-Z]+")
                    .WithMessage("Não contem letra maiuscula");

            RuleFor(m => m.Password)
                    .Matches("[a-z]+")
                    .WithMessage("Não contem letra minuscula");

            RuleFor(m => m.Password)
                    .Matches("[!@#$%^&*()-+]+")
                    .WithMessage("Deve conter no mínimo um caractere especial");

            RuleFor(m => m.Password)
                    .Must((password) => !HasDuplicate(password))
                    .WithMessage("Não deve conter caracteres duplicados ou repetidos");


            RuleFor(m => m.Password)
                    .Must((password) => string.IsNullOrEmpty(password) ? true : !password.Contains(" "))
                    .WithMessage("Não deve conter espaços em branco");

            RuleFor(m => m.Password)
                    .MinimumLength(9)
                    .WithMessage("Deve conter no minimo 9 caracteres");
        }

        private static bool HasDuplicate(string password)
        {
            var pw = password.AsSpan();
            foreach (var ch in pw.ToArray())
            {
                var cont = 0;
                foreach (var i in pw.ToArray())
                {
                    if (ch == i) cont++;
                }
                if (cont > 1) return true;
            };
            return false;
        }
        
    }
}
