using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AppEncuestas.Data;
using AppEncuestas.Services;
using AppEncuestas.Services.Base;
using AppEncuestas.Models;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// builder.Services.Configure<SmtpSettings>());                                                                                                                                                                                                                                             
builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://opdmsitioweb.opdmtlalnepantla.gob.mx:446/"));
//builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("http://localhost:5006/"));
// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddOptions();
// builder.Services.Configure<MyAppSettings>(builder.Configuration);

builder.Services.AddScoped<IEncuestaService, EncuestaService>();
builder.Services.AddScoped<IEmpleadoEncuestaService, EmpleadoEncuestaService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

// Se levantan los settings para enviar los correos (estan registrados en appsettings.json),
// de otro modo en las solicitudes podemos poner nombre de quien envia, correo que envia, usuario y contraseña para autenticar el envio del correo
builder.Services.Configure<SmtpSettings>(
    builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

