namespace SmartifyWebsite.Interfaces
{
	public interface IEmailService
	{
		Task<bool> SendEmailAsync(string userName, string email, string subject, string body);

	}
}
