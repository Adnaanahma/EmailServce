using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Email.Service.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using Org.BouncyCastle.Bcpg;


namespace Email.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort; 
        private readonly string _smtpUser;
        private readonly string _smtpPass;
        public EmailService(string smtpHost, int smtpPort, string smtpUser, string smtpPass)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort; 
            _smtpUser = smtpUser;
            _smtpPass = smtpPass;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string message)
        { 
            var emailMessage = new MimeMessage(); 
            emailMessage.From.Add(new MailboxAddress("Adnanahmad", "adnanhashim1212@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", "alexanderoladokun155@gmail.com"));
            emailMessage.Subject = "Testing testing testing"; 
            emailMessage.Body = new TextPart("plain") { Text = "Hi i'm sending this mail to you through code," +
                " Acknowledge it as soon you receive this" }; 

            using (var client = new MailKit.Net.Smtp.SmtpClient()) 
            { 
                await client.ConnectAsync(_smtpHost, _smtpPort, true);
                await client.AuthenticateAsync(_smtpUser, _smtpPass); 
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true); 
            } 


        }
        public async Task SendMultipleEmailAsync(List<string> recipientEmail, string subject, string message)
        { 
            var emailMessage = new MimeMessage(); 
            emailMessage.From.Add(new MailboxAddress("Adnanahmad", "adnanhashim1212@gmail.com"));
            foreach(var recipient in recipientEmail)
            {
                emailMessage.To.Add(new MailboxAddress("", "alexanderoladokun155@gmail.com"));
                emailMessage.To.Add(new MailboxAddress("", "hashimsumayyauthman@gmail.com"));
            }
           
            emailMessage.Subject = "Testing testing testing"; 
            emailMessage.Body = new TextPart("plain") { Text = "Hi i'm sending this mail to you through code," +
                " Acknowledge it as soon you receive this" }; 

            using (var client = new MailKit.Net.Smtp.SmtpClient()) 
            { 
                await client.ConnectAsync(_smtpHost, _smtpPort, true);
                await client.AuthenticateAsync(_smtpUser, _smtpPass); 
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true); 
            } 


        }

       

    }
}
