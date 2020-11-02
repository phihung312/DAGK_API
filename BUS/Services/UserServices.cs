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
    }
}
