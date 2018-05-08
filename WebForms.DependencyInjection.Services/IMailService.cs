namespace WebForms.DependencyInjection.Services
{
    public interface IMailService
    {
        string SendMail(string to, string body);
    }
}