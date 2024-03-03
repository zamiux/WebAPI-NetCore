namespace WebAPI_Core.API.Services
{
    public interface ILocalMailService
    {
        void SendMail(string subject, string message);
    }
}