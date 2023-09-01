using FluentValidation;
using AppEncuestas.Services.Base;

namespace AppEncuestas.Validators
{    public class EmpleadoEncuestaValidator : AbstractValidator<EmpleadoEncuestaCrearDTO>
    {
        public EmpleadoEncuestaValidator()
        {
            // RuleSet("Nombres", () =>
            // {
            RuleFor(e => e.Nombre)
                .NotEmpty()        
                .WithMessage("Dato {PropertyName} es obligatorio");            

            RuleFor(e => e.Zona)
                .NotEmpty()
                .WithMessage("dato {PropertyName} es obligatorio"); 
                // .MustAsync(async (email, _) => await IsUniqueAsync(email)).WithMessage("Email address must be unique");

            RuleFor(e => e.Area)
                .NotEmpty()
                .WithMessage("Dato {PropertyName} es obligatorio");
            // });          
        }

        private static async Task<bool> IsUniqueAsync(string? email)
        {
            await Task.Delay(300);
            return email?.ToLower() != "mail@my.com";
        }
    }    
}