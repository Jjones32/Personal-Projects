global using ClarityEmailApp.Models;
global using ClarityEmailApp.Services.EmailService;
using ClarityEmailApp.Data;
using FluentEmail.Smtp;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        // DependencyInjection
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IEmailService, EmailService>();
        builder.Services.AddDbContext<EmailDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    }
}













/*
using System.Net;
using System.Net.Mail;


    public static void SendEmail(string from, string password)
    {
        using SmtpClient email= new SmtpClient();
        {
             DeliveryMethod = SmtpDeliveryMethod.Network,
             UseDefaultCredntials = false,
             EnableSs1 = true,
             Host = "smtp.ethereal.email"
             Port = 587,
             Credentials = new NetworkCredential(userName: from, password);
        }

    string subject = "Youtube Video";
    string body = $"This is the main email sent @ {DateTime.UtcNow:F}";
    try
    {
        Console.WriteLine("Sending email *****");
        email.Send(from, to)
    }
    catch (SmtpException e)
    {

        throw;
    }

    };*/