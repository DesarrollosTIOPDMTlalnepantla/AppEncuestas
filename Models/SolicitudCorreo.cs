using Microsoft.AspNetCore.Components.Forms;
namespace AppEncuestas.Models;

public class SolicitudCorreo
{
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public byte[]? Anexo1 { get; set; }
    public string? Nombre1 { get; set; }    
    public byte[]? Anexo2 { get; set; }
    public string? Nombre2 { get; set; }      
    public byte[]? Anexo3 { get; set; } 
    public string? Nombre3 { get; set; }            
    public byte[]? Anexo4 { get; set; }
    public string? Nombre4 { get; set; }      
    public byte[]? Anexo5 { get; set; }
    public string? Nombre5 { get; set; }      
    public byte[]? Anexo6 { get; set; }         
    public string? Nombre6 { get; set; }  
    public byte[]? Anexo7 { get; set; }             
    public string? Nombre7 { get; set; }
    public string? EmailEnvia { get; set; }
    public string? UsuarioEnvia { get; set; }
    public string? ContraseniaEnvia { get; set; }      
}