using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService: IEntityServiceBase<User>
    {
        List<OperationClaim> GetClaims(User user);
      User GetByEmail(string email);
        
    }
}
