using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result = IsGenderValid(user.Gender);
            if (result)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            return new ErrorResult(Messages.UserIsNotValid);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<User> Login(string email, string password)
        {
            var userToCheck = GetByMail(email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.InvalidEmailOrPassword);
            }
            if (GetByMail(email).Data.Password != password)
            {
                return new ErrorDataResult<User>(Messages.InvalidEmailOrPassword);
            }
            return new SuccessDataResult<User>(userToCheck,Messages.SuccessfulLogin);
        }

        public bool IsGenderValid(string gender)
        {
            if(gender == "male" || gender == "female")
            {
                return true;
            }
            return false;
        }
        

    }
}
