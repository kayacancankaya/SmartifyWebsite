using MimeKit;
using MailKit.Net.Smtp;
using SmartifyWebsite.Interfaces;

namespace SmartifyWebsite.Services
{
	public class EmailService : IEmailService
	{

		public async Task<bool> SendEmailAsync(string userName, string email, string subject, string body)
		{
			try
			{
				var message = new MimeMessage();
				message.From.Add(new MailboxAddress(userName, "info@smartifyyb.com"));
				message.To.Add(new MailboxAddress("Smartify", "info@smartifyyb.com"));
				string messageBody = string.Format("{0} {1}", email, body);
				message.Subject = subject;
				message.Body = new TextPart("plain") { Text = messageBody };

				using var client = new SmtpClient();
				await client.ConnectAsync("smtp.hostinger.com", 465, true);
				await client.AuthenticateAsync("info@smartifyyb.com", "Smail,604053");
				await client.SendAsync(message);
				client.Disconnect(true);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
