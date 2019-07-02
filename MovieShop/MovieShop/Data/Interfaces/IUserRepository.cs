using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();

        int GetCount();
    }
}
