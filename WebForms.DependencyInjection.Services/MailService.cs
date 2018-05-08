using System;

namespace WebForms.DependencyInjection.Services
{
    public class MailService : IMailService
    {
     
        public string SendMail(string to, string body)
        {
            return $"Mail sent to: {to}, with this content: {body}";
        }
    }
}
