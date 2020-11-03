using BUS.Interface;
using BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS.Services
{
    public class UserServices: IUserService
    {
        public ErrorObject Login(string Username, string Password)
        {
            var error = Error.Success();
            try
            {
                using (var db = new SprintRetrospectiveContext())
                {
                    var user = db.User.FirstOrDefault(x => x.UserName.ToLower().Equals(Username.ToLower()) && x.PassWord.Equals(Password));
                    if (user == null)
                    {
                        return Error.USER_INVALID;
                    }
                    return error.SetData(user);
                } 
    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ErrorObject Register(User user)
        {          
            try
            {
                var error = Error.Success();
                using (var db = new SprintRetrospectiveContext())
                {
                    var u = db.User.FirstOrDefault(x => x.UserName.ToLower().Equals(user.UserName.ToLower()) );
                    if (user != null)
                    {
                        return Error.USER_EXISTED ;
                    }
                    else
                    {
                        db.Add(user);
                        db.SaveChanges();
                    }
                    return error.SetData(user);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetInforUserById(int Id)
        {
            try
            {
                using (var db = new SprintRetrospectiveContext())
                {
                    var user = db.User.FirstOrDefault(x=>x.Id== Id);
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
