using System;

namespace Monitoreo_de_Pacientes
{
    internal class Program
    {
        const int N = 17;

        static string[] nombres = new string[N];
        static int[] gravedad = new int[N];

        static int cantidad = 0;

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                MostrarMenu();

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Registrar();
                        break;

                    case 2:
                        Consultar();
                        break;

                    case 3:
                        Modificar();
                        break;

                    case 4:
                        Eliminar();
                        break;

                    case 5:
                        MostrarReporte();
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Programa finalizado.");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion no valida.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine();

            } while (opcion != 6);
        }

        static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("================================");
            Console.WriteLine("     MONITOREO DE PACIENTES");
            Console.WriteLine("================================");

            Console.ResetColor();

            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Consultar paciente");
            Console.WriteLine("3. Modificar gravedad");
            Console.WriteLine("4. Eliminar paciente");
            Console.WriteLine("5. Mostrar reporte");
            Console.WriteLine("6. Salir");
            Console.WriteLine("Seleccione una opcion:");
        }

        static void Registrar()
        {
            if (cantidad < N)
            {
                Console.WriteLine("Ingrese el nombre del paciente");
                string nomb = Console.ReadLine();

                int nivel;

                do
                {
                    Console.WriteLine("Ingrese el nivel de gravedad (1-5)");
                    nivel = int.Parse(Console.ReadLine());

                    if (nivel < 1 || nivel > 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El nivel de gravedad debe estar entre 1 y 5");
                        Console.ResetColor();
                    }

                } while (nivel < 1 || nivel > 5);

                nombres[cantidad] = nomb;
                gravedad[cantidad] = nivel;

                cantidad++;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Paciente registrado correctamente");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se alcanzo el limite maximo de pacientes");
                Console.ResetColor();
            }
        }

        static void Consultar()
        {
            Console.WriteLine("Ingrese el nombre que desea buscar");
            string nomb = Console.ReadLine();

            Boolean encontrado = false;

            for (int i = 0; i < cantidad; i++)
            {
                if (nomb.Equals(nombres[i]))
                {
                    encontrado = true;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"El nivel de gravedad del paciente es {gravedad[i]}");
                    Console.ResetColor();
                }
            }

            if (encontrado == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El paciente no se encuentra registrado");
                Console.ResetColor();
            }
        }

        static void Modificar()
        {
            Console.WriteLine("Ingrese el nombre que desea modificar");
            string nomb = Console.ReadLine();

            Boolean encontrado = false;

            for (int i = 0; i < cantidad; i++)
            {
                if (nomb.Equals(nombres[i]))
                {
                    encontrado = true;

                    Console.WriteLine($"El nivel de gravedad actual es {gravedad[i]}");

                    int nuevoNivel;

                    do
                    {
                        Console.WriteLine("Ingrese el nuevo nivel de gravedad (1-5)");
                        nuevoNivel = int.Parse(Console.ReadLine());

                        if (nuevoNivel < 1 || nuevoNivel > 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El nivel de gravedad debe estar entre 1 y 5");
                            Console.ResetColor();
                        }

                    } while (nuevoNivel < 1 || nuevoNivel > 5);

                    gravedad[i] = nuevoNivel;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Gravedad modificada correctamente");
                    Console.ResetColor();
                }
            }

            if (encontrado == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El paciente no se encuentra registrado");
                Console.ResetColor();
            }
        }

        static void Eliminar()
        {
            Console.WriteLine("Ingrese el nombre que desea eliminar");
            string nomb = Console.ReadLine();

            Boolean encontrado = false;

            for (int i = 0; i < cantidad; i++)
            {
                if (nomb.Equals(nombres[i]))
                {
                    encontrado = true;

                    for (int j = i; j < cantidad - 1; j++)
                    {
                        nombres[j] = nombres[j + 1];
                        gravedad[j] = gravedad[j + 1];
                    }

                    cantidad--;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Paciente eliminado correctamente");
                    Console.ResetColor();

                    break;
                }
            }

            if (encontrado == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El paciente no se encuentra registrado");
                Console.ResetColor();
            }
        }

        static void MostrarReporte()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("================================");
            Console.WriteLine("       REPORTE DE PACIENTES");
            Console.WriteLine("================================");

            Console.ResetColor();

            if (cantidad == 0)
            {
                Console.WriteLine("No hay pacientes registrados");
            }
            else
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine($"Nombre: {nombres[i]}");
                    Console.WriteLine($"Nivel de gravedad: {gravedad[i]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }
    }
}