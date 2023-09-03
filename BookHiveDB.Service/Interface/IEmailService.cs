using System.Collections.Generic;
using System.Threading.Tasks;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
        Task SendEmailAsync(EmailMessage mail);
    }
}
