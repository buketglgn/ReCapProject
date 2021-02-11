using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {

            _userDal.Add(user);
            return new SuccessResult("Kullanıcı eklendi");
        }

        public IResult Delete(int Id)
        {
            _userDal.Delete(p => p.Id == Id);
            return new SuccessResult("Kullanıcı silindi");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Kullanıcılar Listelendi");
        }

        public IDataResult<User> GetById(int Id)
        {

            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == Id), "Kullanıcılar Listelendi");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı güncellendi");
        }
    }
}
