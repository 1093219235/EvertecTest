using BusinessEvertecTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEvertecTest.DomainService
{
    public interface IloginDomainService
    {
        loginDTO GetLogin(loginDTO log);
        loginDTO create(loginDTO log);

    }
}
