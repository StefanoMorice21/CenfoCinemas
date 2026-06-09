

using DataAccess.DAO;

public class Program
{
    public static void Main(string[] args)
    {

        var sqlDao = SqlDao.getInstance();
        var sqlOperation = new Operation();

        Console.WriteLine("Indique un Codigo de Usuario: ");
        var userCode = Console.ReadLine();

        Console.WriteLine("Ingrese el Nombre Completo: ");
        var name = Console.ReadLine();

        Console.WriteLine("Ingrese el Email: ");
        var email = Console.ReadLine();

        Console.WriteLine("Ingrese la Contrasenia: ");
        var password = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha de nacimiento *MM-dd-yyyy*: ");
        var birthday = DateTime.Parse(Console.ReadLine());

        var status = "AC";

        Console.WriteLine("Ingrese su Numero de Telefono: ");
        var phone = int.Parse(Console.ReadLine());



        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_USER_CODE", userCode);
        sqlOperation.AddStringParameter("P_NAME", name);
        sqlOperation.AddStringParameter("P_EMAIL", email);
        sqlOperation.AddStringParameter("P_PASSWORD", password);
        sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", birthday);
        sqlOperation.AddIntParameter("P_PHONE_NUMBER", phone);
        sqlOperation.AddStringParameter("P_STATUS", status);

        sqlDao.ExecuteProcedure(sqlOperation);
    }
}