using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookHiveDB.Service.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
