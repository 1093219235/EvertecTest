using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEvertecTest.DTO;
using BusinessEvertecTest.DTO.Mapping;
using EvertecTest.Entities;
using EvertecTest.Repositories;


namespace BusinessEvertecTest.DomainService
{
   public class loginDomainService:IloginDomainService
    {
        public readonly IloginRepository _loginRepository;
        public loginDomainService(IloginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public loginDTO GetLogin(loginDTO log )
        {
            login user_log = _loginRepository.GetLogin(log.Map());
            if (user_log == null)
            {
                return null;
            }
           
            return user_log.Map();
        }
        public loginDTO create(loginDTO log)
        {
           if (log == null)
            {
                return null;
            }
           login l= _loginRepository.Create(log.Map());
            return l.Map();
        }
    }
}
