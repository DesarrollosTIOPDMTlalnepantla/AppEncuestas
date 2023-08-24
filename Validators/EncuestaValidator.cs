using FluentValidation;
using AppEncuestas.Services.Base;

namespace AppEncuestas.Validators
{
    public class EncuestaValidator : AbstractValidator<EncuestaCrearDTO>
    {
        public EncuestaValidator()
        {
            // RuleSet("Nombres", () =>
            // {
            RuleFor(e => e.CalificaTiempo)
                .InclusiveBetween(0, 3)            
                .WithMessage("Dato {PropertyName} es obligatorio");            

            RuleFor(e => e.CalificaInformacion)
                .InclusiveBetween(0, 3)   
                //.NotEmpty()
                .WithMessage("dato {PropertyName} es obligatorio"); 
                // .MustAsync(async (email, _) => await IsUniqueAsync(email)).WithMessage("Email address must be unique");

            RuleFor(e => e.CalificaTrato)
                .InclusiveBetween(0, 3)   
                // .NotEmpty()
                .WithMessage("Dato {PropertyName} es obligatorio");
            // });          

            // RuleFor(d => d.Predio)
            //     .NotNull().WithMessage("dato {PropertyName} es obligatorio")
            //     .GreaterThanOrEqualTo(1).WithMessage("Valores validos para {PropertyName} mayor o igual a 1")
            //     .LessThan(200000).WithMessage("Valores validos para {PropertyName} menores a 200000");
            RuleFor(e => e.TramiteSolucionado)
                // .NotEmpty()
                .Must(e => e == true || e == false)                
                .WithMessage("dato {PropertyName} es obligatorio");            
        }

        private static async Task<bool> IsUniqueAsync(string? email)
        {
            await Task.Delay(300);
            return email?.ToLower() != "mail@my.com";
        }
    }
}