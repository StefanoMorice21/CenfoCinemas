using DataAccess.CRUD;
using Entities_DTOs;
using System.Globalization;

public class Program
{
    public static void CrearUsuario()
    {
        try
        {
            Console.WriteLine("Indique un Codigo de Usuario:");
            string userCode = Console.ReadLine();

            Console.WriteLine("Ingrese el Nombre Completo:");
            string name = Console.ReadLine();

            Console.WriteLine("Ingrese el Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Ingrese la Contrasenia:");
            string password = Console.ReadLine();

            DateTime birthday;
            Console.WriteLine("Ingrese la fecha de nacimiento (MM-dd-yyyy):");

            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Fecha inválida. Intente nuevamente:");
            }

            int phone;
            Console.WriteLine("Ingrese su Numero de Telefono:");

            while (!int.TryParse(Console.ReadLine(), out phone))
            {
                Console.WriteLine("Número inválido. Intente nuevamente:");
            }

            var userDTO = new User()
            {
                UserCode = userCode,
                Name = name,
                Email = email,
                Password = password,
                Birthday = birthday,
                Status = "AC",
                Phone = phone
            };

            var uCrud = new UserCrudFactory();
            uCrud.Create(userDTO);

            Console.WriteLine("Usuario creado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear usuario: {ex.Message}");
        }
    }

    public static void ListarUsuarios()
    {
        try
        {
            Console.WriteLine("Listado de Usuarios");

            var uCrud = new UserCrudFactory();
            var lstUsers = uCrud.RetrieveAll<User>();

            if (lstUsers.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            foreach (var user in lstUsers)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Código: {user.UserCode}");
                Console.WriteLine($"Nombre: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Teléfono: {user.Phone}");
                Console.WriteLine($"Estado: {user.Status}");
                Console.WriteLine($"Fecha Nacimiento: {user.Birthday:d}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar usuarios: {ex.Message}");
        }
    }

    public static void ConsultarUsuarioPorId()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del usuario:");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Intente nuevamente:");
            }

            var uCrud = new UserCrudFactory();
            var user = uCrud.RetrieveById<User>(id);

            if (user != null)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Código: {user.UserCode}");
                Console.WriteLine($"Nombre: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Teléfono: {user.Phone}");
                Console.WriteLine($"Estado: {user.Status}");
                Console.WriteLine($"Fecha Nacimiento: {user.Birthday:d}");
            }
            else
            {
                Console.WriteLine("No se encontró ningún usuario con ese ID.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al consultar usuario: {ex.Message}");
        }
    }


    //---------------------Funciones Movies------------------------------

    public static void CrearMovie()
    {
        try
        {
            Console.WriteLine("Indique un el Titulo de la Movie:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Ingrese la Sinopsis:");
            string sinopsis = Console.ReadLine();

            Console.WriteLine("Ingrese el Genero:");
            string genero = Console.ReadLine();

            Console.WriteLine("Ingrese la duracion:");
            int duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la Clasificacion: ");
            string clasificacion = Console.ReadLine(); 

            Console.WriteLine("Ingrese el Url de la Imagen: ");
            string imagen = Console.ReadLine();





            var movieDTO = new Movie()
            {
                Title = titulo,
                Sinopsis = sinopsis,
                Genre = genero,
                Duration = duration,
                Clasification = clasificacion,
                Image = imagen,
                Status = "AC"
            };

            var mCrud = new MovieCrudFactory();
            mCrud.Create(movieDTO);

            Console.WriteLine("Usuario creado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear usuario: {ex.Message}");
        }
    }

    public static void ListarMovies()
    {
        try
        {
            Console.WriteLine("Listado de Movies");

            var mCrud = new MovieCrudFactory();
            var lstMovies = mCrud.RetrieveAll<Movie>();

            if (lstMovies.Count == 0)
            {
                Console.WriteLine("No hay películas registradas.");
                return;
            }

            foreach (var movie in lstMovies)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Id: {movie.Id}");
                Console.WriteLine($"Título: {movie.Title}");
                Console.WriteLine($"Sinopsis: {movie.Sinopsis}");
                Console.WriteLine($"Género: {movie.Genre}");
                Console.WriteLine($"Duración: {movie.Duration} minutos");
                Console.WriteLine($"Clasificación: {movie.Clasification}");
                Console.WriteLine($"Imagen: {movie.Image}");
                Console.WriteLine($"Estado: {movie.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar películas: {ex.Message}");
        }
    }
    public static void ConsultarMoviePorId()
    {
        try
        {
            Console.WriteLine("Ingrese el ID de la película:");

            int id = int.Parse(Console.ReadLine());

            var mCrud = new MovieCrudFactory();
            var movie = mCrud.RetrieveById<Movie>(id);

            if (movie != null)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Id: {movie.Id}");
                Console.WriteLine($"Título: {movie.Title}");
                Console.WriteLine($"Sinopsis: {movie.Sinopsis}");
                Console.WriteLine($"Género: {movie.Genre}");
                Console.WriteLine($"Duración: {movie.Duration} minutos");
                Console.WriteLine($"Clasificación: {movie.Clasification}");
                Console.WriteLine($"Imagen: {movie.Image}");
                Console.WriteLine($"Estado: {movie.Status}");
            }
            else
            {
                Console.WriteLine("No se encontró ninguna película con ese ID.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al consultar película: {ex.Message}");
        }
    }


    //---------------------Funciones Tickets------------------------------
    public static void CrearTicket()
    {
        try
        {
            Console.WriteLine("Ingrese el Precio:");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Horario (MM-dd-yyyy HH:mm):");
            DateTime schedule = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la Fecha (MM-dd-yyyy):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Tipo de Ticket:");
            string type = Console.ReadLine();

            Console.WriteLine("Ingrese el ID de la Película:");
            int movieId = int.Parse(Console.ReadLine());

            var ticketDTO = new Ticket()
            {
                Price = price,
                Schedule = schedule,
                Date = date,
                Type = type,
                MovieId = movieId
            };

            var tCrud = new TicketCrudFactory();
            tCrud.Create(ticketDTO);

            Console.WriteLine("Ticket creado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear ticket: {ex.Message}");
        }
    }

    public static void ListarTickets()
    {
        try
        {
            Console.WriteLine("Listado de Tickets");

            var tCrud = new TicketCrudFactory();
            var lstTickets = tCrud.RetrieveAll<Ticket>();

            if (lstTickets.Count == 0)
            {
                Console.WriteLine("No hay tickets registrados.");
                return;
            }

            foreach (var ticket in lstTickets)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Id: {ticket.Id}");
                Console.WriteLine($"Precio: {ticket.Price}");
                Console.WriteLine($"Horario: {ticket.Schedule}");
                Console.WriteLine($"Fecha: {ticket.Date:d}");
                Console.WriteLine($"Tipo: {ticket.Type}");
                Console.WriteLine($"MovieId: {ticket.MovieId}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar tickets: {ex.Message}");
        }
    }

    public static void ConsultarTicketPorId()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del Ticket:");

            int id = int.Parse(Console.ReadLine());

            var tCrud = new TicketCrudFactory();
            var ticket = tCrud.RetrieveById<Ticket>(id);

            if (ticket != null)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Id: {ticket.Id}");
                Console.WriteLine($"Precio: {ticket.Price}");
                Console.WriteLine($"Horario: {ticket.Schedule}");
                Console.WriteLine($"Fecha: {ticket.Date:d}");
                Console.WriteLine($"Tipo: {ticket.Type}");
                Console.WriteLine($"MovieId: {ticket.MovieId}");
            }
            else
            {
                Console.WriteLine("No se encontró ningún ticket con ese ID.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al consultar ticket: {ex.Message}");
        }
    }
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("#######################");
            Console.WriteLine("Seleccione una Opción:");
            Console.WriteLine("_______________________");
            Console.WriteLine("1 - Crear");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Consulta por ID");
            Console.WriteLine("4 - Salir");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Opción inválida.");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("#######################");
                    Console.WriteLine("Seleccione una Opción:");
                    Console.WriteLine("_______________________");
                    Console.WriteLine("1 - Crear Usuario");
                    Console.WriteLine("2 - Crear Movie");
                    Console.WriteLine("3 - Crear Ticket");

                    if (int.TryParse(Console.ReadLine(), out int opcionCrear))
                    {
                        if (opcionCrear == 1)
                        {
                            CrearUsuario();
                        }else if (opcionCrear == 2)
                        {
                            CrearMovie();
                        }
                        else
                        {
                            CrearTicket();
                        }
                    }
                    break;

                case 2:
                    Console.Clear();

                    Console.WriteLine("#######################");
                    Console.WriteLine("Seleccione una Opción:");
                    Console.WriteLine("_______________________");
                    Console.WriteLine("1 - Listar Usuarios");
                    Console.WriteLine("2 - Listar Movies");
                    Console.WriteLine("3 - Listar Tickets");

                    if (int.TryParse(Console.ReadLine(), out int opcionListar))
                    {
                        if (opcionListar == 1)
                        {
                            ListarUsuarios();
                        }else if(opcionListar == 2)
                        {
                            ListarMovies();
                        }
                        else
                        {
                            ListarTickets();
                        }
                    }
                    break;

                case 3:
                    Console.Clear();

                    Console.WriteLine("#######################");
                    Console.WriteLine("Seleccione una Opción:");
                    Console.WriteLine("_______________________");
                    Console.WriteLine("1 - Consultar Usuario por Id");
                    Console.WriteLine("2 - Consultar Movie por Id");
                    Console.WriteLine("3 - Consultar Ticket por Id");

                    if (int.TryParse(Console.ReadLine(), out int opcionConsultar))
                    {
                        if (opcionConsultar == 1)
                        {
                            ConsultarUsuarioPorId();
                        }
                        else if (opcionConsultar == 2)
                        {
                            ConsultarMoviePorId();
                        }
                        else
                        {
                            ConsultarTicketPorId();
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("Ha salido del Sistema");
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}