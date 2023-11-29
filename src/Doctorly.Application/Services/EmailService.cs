using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmailService
{
    private readonly string smtpServer;
    private readonly int smtpPort;
    private readonly string smtpUsername;
    private readonly string smtpPassword;

    public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
    {
        this.smtpServer = smtpServer;
        this.smtpPort = smtpPort;
        this.smtpUsername = smtpUsername;
        this.smtpPassword = smtpPassword;
    }

    public async Task SendEmailAsync(string to)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Doctorly", "no-reply@doctorly.com"));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = "Updates from the event you attended"; // This could be personalised and move to a app setting or DB

        var textPart = new TextPart("plain")
        {
            Text = "Thank you for coming" // Also read from a DB and personalise it
        };

        var multipart = new Multipart("mixed");
        multipart.Add(textPart);

        message.Body = multipart;

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(smtpServer, smtpPort, useSsl: true);
            await client.AuthenticateAsync(smtpUsername, smtpPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}