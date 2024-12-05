using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Service.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string recipientEmail, string subject, string message);
        Task SendMultipleEmailAsync(List<string> recipientEmail, string subject, string message);
    }
}
