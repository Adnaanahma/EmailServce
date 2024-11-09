using Email.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Email.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendEmail([FromForm] string recipientEmail, [FromForm] string subject, [FromForm] string message)
        {
            await _emailService.SendEmailAsync(recipientEmail, subject, message);
            return Ok("Email sent successfully");
        }
    }

}
