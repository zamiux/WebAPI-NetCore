namespace WebAPI_Core.API.Services
{
    public class CloudMailService : ILocalMailService
    {
        string _mailTo = "mohsen@gmail.com";
        string _mailFrom = "info@mohsenzamani.ir";

        public void SendMail(string subject, string message)
        {
            Console.WriteLine($"mail from {_mailFrom} To {_mailTo} , " +
                $"with {nameof(LocalMailService)} , ");

            Console.WriteLine($"subject : {subject}");
            Console.WriteLine($"message : {message}");
        }
    }
}
