using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DAO
{
    //Clase que define el procedimiento a ejecutar y los parametros de este
    public class Operation
    {
        public string ProcedureName {  get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public Operation() {
            Parameters = new List<SqlParameter>();
        }

        //Solo vamos a trabajar con estos 4 tipos

        public void AddStringParameter(string parameterName, string value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }

        public void AddIntParameter(string parameterName, int value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }

        public void AddDoubleParameter(string parameterName, double value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }

        public void AddDateTimeParameter(string parameterName, DateTime value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }


        
    }
}
