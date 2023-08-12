using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult AddNewUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("User is added");
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("User is deleted");
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = new SuccessDataResult<List<User>>(_userDal.GetAll());
            return result;
        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("User is updated");
        }
    }
}
