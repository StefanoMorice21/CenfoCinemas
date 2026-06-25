using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreApp
{
    //Logica del Negocio
    public class UserManager
    {
        private void ValidateUser(User u)
        {
            // Regla de formato 1: Campos obligatorios no vacios
            if (string.IsNullOrEmpty(u.UserCode) || string.IsNullOrEmpty(u.Name) ||
                string.IsNullOrEmpty(u.Email) || string.IsNullOrEmpty(u.Password) ||
                string.IsNullOrEmpty(u.Status))
            {
                throw new Exception("Todos los campos obligatorios deben estar completos.");
            }

            // Regla de formato 2: Phone debe ser positivo y en rango razonable
            if (u.Phone <= 0 || u.Phone > 99999999)
            {
                throw new Exception("El numero de telefono debe ser positivo y no mayor a 8 digitos.");
            }

            // Regla de formato 3: Email debe tener formato valido
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(u.Email, emailPattern))
            {
                throw new Exception("El email no tiene un formato valido.");
            }

            // Regla de formato 3: UserCode debe cumplir un patron valido (alfanumerico, 3-25 caracteres)
            var userCodePattern = @"^[A-Za-z0-9]{3,25}$";
            if (!Regex.IsMatch(u.UserCode, userCodePattern))
            {
                throw new Exception("El codigo de usuario debe ser alfanumerico y tener entre 3 y 25 caracteres.");
            }

            // Regla de negocio: Usuario debe ser mayor de 18 anios
            var edad = DateTime.Now.Year - u.Birthday.Year;
            if (u.Birthday > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }
            if (edad < 18)
            {
                throw new Exception("El usuario debe ser mayor de 18 anios para registrarse.");
            }
        }

        public List<User> RetrieveAllUsers()
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveAll<User>();
        }

        public User RetrieveUserById(int id)
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveById<User>(id);
        }

        public void CreateUser(User u)
        {
            ValidateUser(u);
            var uCrud = new UserCrudFactory();
            uCrud.Create(u);
        }

        public void UpdateUser(User u)
        {
            ValidateUser(u);
            var uCrud = new UserCrudFactory();
            uCrud.Update(u);
        }

        public void DeleteUser(User u)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Delete(u);
        }
    }
}
 
