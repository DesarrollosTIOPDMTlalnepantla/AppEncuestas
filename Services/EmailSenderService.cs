using System.Net.Mime;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using AppEncuestas.Models;

namespace AppEncuestas.Services;

public class EmailSenderService : IEmailSenderService
{
    public readonly SmtpSettings _smtpSettings;
    public EmailSenderService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings=smtpSettings.Value;
    }
    public async Task SendEmailAsync(SolicitudCorreo solicitud) 
    {
        try
        {
            var correo=new MimeMessage();
            // correo.From.Add(new MailboxAddress(_smtpSettings.SenderName,_smtpSettings.SenderEmail));
            correo.From.Add(new MailboxAddress(_smtpSettings.SenderName,solicitud.EmailEnvia));            
            correo.To.Add(new MailboxAddress("",solicitud.Email));
            correo.Subject=solicitud.Subject;
                  
            // var filePath = solicitud.Anexo1;
            // var buffer = File.ReadAllBytes(filePath);
            var bodyBuilder = new BodyBuilder();             
            bodyBuilder.Attachments.Add(fileName: "Archivo_1.pdf",
                            data: solicitud.Anexo1,
                            contentType: MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf));

            // filePath = solicitud.Anexo2;
            // buffer = File.ReadAllBytes(filePath);
            //bodyBuilder = new BodyBuilder();             
            bodyBuilder.Attachments.Add(fileName: "Archivo_2.pdf",
                            data: solicitud.Anexo2,
                            contentType: MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf)); 

            // filePath = solicitud.Anexo3;
            // buffer = File.ReadAllBytes(filePath);
            //var bodyBuilder = new BodyBuilder();             
            bodyBuilder.Attachments.Add(fileName: "Archivo_3.pdf",
                            data: solicitud.Anexo3,
                            contentType: MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf));   

            if(solicitud.Anexo4!=null)   
            {
                bodyBuilder.Attachments.Add(fileName: "Archivo_4.pdf",
                                data: solicitud.Anexo4,
                                contentType: MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf));
            }                     

            if(solicitud.Anexo5!=null)   
            {
                // filePath = solicitud.Anexo2;
                // buffer = File.ReadAllBytes(filePath);
                //bodyBuilder = new BodyBuilder();                   
                bodyBuilder.Attachments.Add(fileName: "Archivo_5.pdf",
                                data: solicitud.Anexo5,
                                contentType: MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf)); 
            }   

            if(solicitud.Anexo6!=null)   
            {
                // filePath = solicitud.Anexo3;
                // buffer = File.ReadAllBytes(filePath);
                //var bodyBuilder = new BodyBuilder();             
                bodyBuilder.Attachments.Add(fileName: "Archivo_6.pdf",
                                data: solicitud.Anexo6,
                                contentType: MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf));  
            }             

            if(solicitud.Anexo7!=null)   
            {
                bodyBuilder.Attachments.Add(fileName: "Archivo_7.pdf",
                                data: solicitud.Anexo7,
                                contentType: MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf));   
            }    
    

                                                        

            bodyBuilder.HtmlBody = solicitud.Body;   
            correo.Body=bodyBuilder.ToMessageBody();    

            using (var client=new SmtpClient())
            {
                // await client.ConnectAsync(_smtpSettings.Server);
                // await client.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password);
                await client.ConnectAsync(_smtpSettings.Server);                
                await client.AuthenticateAsync(solicitud.UsuarioEnvia, solicitud.ContraseniaEnvia);
                await client.SendAsync(correo);
                await client.DisconnectAsync(true);
            }
        }
        catch (Exception e)
        {
            throw;
        }
    } 
}