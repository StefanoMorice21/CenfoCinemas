using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {
        public UserCrudFactory()
        {
            sqlDao = SqlDao.GetInstance();
        }
        public override void Create(BaseDTO baseDTO)
        {
            //Convirtiendo el baseDTO en un objeto usuario
            var user = baseDTO as User;

            //definir el SP, por medio del sqlOperation
            var sqlOperation = new Operation();
            sqlOperation.ProcedureName = "CRE_USER_PR";
            sqlOperation.AddStringParameter("P_USER_CODE", user.UserCode);
            sqlOperation.AddStringParameter("P_NAME", user.Name);
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);
            sqlOperation.AddStringParameter("P_PASSWORD", user.Password);
            sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddIntParameter("P_PHONE_NUMBER", user.PhoneNumber);
            sqlOperation.AddStringParameter("P_STATUS", user.Status);

            //Ejecutamos el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

            var sqlOperation = new Operation();
            sqlOperation.ProcedureName = "DEL_USER_PR";
            sqlOperation.AddIntParameter("P_ID", user.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        } 
    }
}
