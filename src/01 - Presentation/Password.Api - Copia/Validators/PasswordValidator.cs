using FluentValidation;
using Password.Api.Models;
using System;

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
                    .Matches("[!@#$%^&*()-+]+")
                    .WithMessage("Deve conter no mínimo um caractere especial");

            RuleFor(m => m.Password)
                    .Must((password) => !HasNotDuplicate(password))
                    .WithMessage("Não deve conter caracteres duplicados ou repetidos");
        }

        private static bool HasNotDuplicate(string password)
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
