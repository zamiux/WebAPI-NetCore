namespace WebAPI_Core.API.Services
{
    public class LocalMailService : ILocalMailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;
        public LocalMailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mailTo = _configuration["mailSetting:MailFromAddress"];
            _mailFrom = _configuration["mailSetting:MailToAddress"];
        }

        

        public void SendMail(string subject, string message)
        {
            Console.WriteLine($"mail from {_mailFrom} To {_mailTo} , " +
                $"with {nameof(LocalMailService)} , ");

            Console.WriteLine($"subject : {subject}");
            Console.WriteLine($"message : {message}");
        }
    }
}
