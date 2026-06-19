using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{
    //Logica del Negocio
    public class UserManager
    {
        public List<User> RetrieveAllUsers()
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveAll<User>();
        }
        public void CreateUser(User u)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Create(u);
        }
    }
}
 
