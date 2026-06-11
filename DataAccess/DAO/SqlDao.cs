using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.DAO
{
    /*
     Clase que se encarga de la comunicacion con la base de datos
     Solo ejecuta store procedures

    Implementacion el patron singleton, para asegurar la existencia de un unico 
    objeto que se conencta a la base de datos y centraliza esta gestion.
     */
    public class SqlDao
    {
        //Paso 1: Crear una instancia privada de la clase de esta misma clase
        private static SqlDao instance;

        private string connectionString;

        //Paso 2: Redefinir el constructor default de la clase
        private SqlDao()
        {
            connectionString = @"Data Source=TETO5D0D;Initial Catalog=cenfocinemas-db;Integrated Security=True;Trust Server Certificate=True";
        }

        //Paso 3: Definir un metodo estatico que expone la instancia
        public static SqlDao GetInstance() {
            if(instance == null)
            {
                instance = new SqlDao();
            }
            return instance;
        }

        //Metodo que ejcuta store procedures a partir de la especificacion recibida por parametro
        public void ExecuteProcedure(Operation sqlOperation)
        {
            using  (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sqlOperation.ProcedureName, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    //Set de los parametro que utiliza el SP
                    foreach(var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    //Ejecuta el StoreProcuedure
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
