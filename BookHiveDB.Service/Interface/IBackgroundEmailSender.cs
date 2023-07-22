using System.Threading.Tasks;

namespace BookHiveDB.Service.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
