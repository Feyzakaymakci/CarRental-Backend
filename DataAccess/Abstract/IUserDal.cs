using Core.DataAccess;
using Core.Entities.Concrete;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user); //Parametre olarak verdiğimiz kullanıcının sahip olduğu claimlerini çekmek istiyoruz. Bizim için bir join operasyonu olucak.
        UserDto GetDto(Expression<Func<User, bool>> filter);
    }
}
