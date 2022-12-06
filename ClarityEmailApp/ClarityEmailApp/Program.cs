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







global using ClarityEmailApp.EmailService;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ClarityEmailDLL.Services.EmailService.IEmailService, EmailService>();

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