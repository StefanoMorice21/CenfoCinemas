

using DataAccess.CRUD;
using DataAccess.DAO;
using Entities_DTOs;

public class Program
{
    public static void Main(string[] args)
    {

        

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

        var userDTO = new User();
        userDTO.UserCode = userCode;
        userDTO.Name = name;
        userDTO.Email = email;
        userDTO.Password = password;
        userDTO.BirthDate = birthday;
        userDTO.Status = status;
        userDTO.PhoneNumber = phone;

        var uCrud = new UserCrudFactory();
        uCrud.Create(userDTO);


    }
}