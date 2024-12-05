using Email.Service.Interfaces;
using Email.Service.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Smtp Mimekits added
var smtpSettings = builder.Configuration.GetSection("SmtpSettings");
builder.Services.AddSingleton(new EmailService(smtpSettings["Host"], int.Parse(smtpSettings["Port"]), smtpSettings["User"], smtpSettings["Pass"]));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
