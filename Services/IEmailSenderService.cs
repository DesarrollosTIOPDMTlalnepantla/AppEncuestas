using AppEncuestas.Models;

namespace AppEncuestas.Services;

public interface IEmailSenderService
{
    Task SendEmailAsync(SolicitudCorreo solicitud);
}