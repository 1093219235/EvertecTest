using EvertecTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertecTest.Repositories
{
    public interface IloginRepository
    {
        login GetLogin(login log);
        login Create(login log);
    }
}
