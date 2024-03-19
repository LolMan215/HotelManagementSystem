namespace HotelManagementSystemBL.Services
{
    using HotelManagementSystemBL.DTOs.Account;
    using Mailjet.Client;
    using Mailjet.Client.TransactionalEmails;
    using Mailjet.Client.Resources;
    using Microsoft.Extensions.Configuration;

    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(EmailSendDto emailSend)
        {
            MailjetClient client = new MailjetClient("61e98508be3481512debc9e8c8c9eca1", "d88414f0e263c18f83b7a17773daee6e");

            var email = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(_configuration["Email:From"])) //, _configuration["Email:ApplicationName"]
                .WithSubject(emailSend.Subject)
                .WithHtmlPart(emailSend.Body)
                .WithTo(new SendContact(emailSend.To))
                .Build();
            
            var response = await client.SendTransactionalEmailAsync(email);
            if(response.Messages != null)
            {
                if (response.Messages[0].Status == "success")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
