using BookHiveDB.Domain.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookHiveDB.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}
