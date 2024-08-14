using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivosCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>();

            int opcMenu;

            try
            {
                do
                {
                    do
                    {
                        MostrarMenu();
                        opcMenu = Convert.ToInt32(Console.ReadLine());
                        if (opcMenu >= 0 && opcMenu <= 4)
                        {
                            EligirOpcionMenu(opcMenu, libros);
                        }
                        else
                        {
                            Console.WriteLine("Numero ingresado fuera de rango");
                        }
                    } while (opcMenu < 0 || opcMenu > 4);
                } while (opcMenu != 0);
            } catch (FormatException)
            {
                Console.WriteLine("ERROR valor ingresado invalido");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message );
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("1- Crear");
            Console.WriteLine("2- Leer");
            Console.WriteLine("3- Actualizar");
            Console.WriteLine("4- Eliminar");
            Console.WriteLine("0- SALIR");
        }


        private static void EligirOpcionMenu(int opcMenu, List<Libro> libros)
        {
            switch (opcMenu)
            {
                case 1: CrearLibro();
                    break;
                case 2: LeerLibro();
                    break;
                case 3: ActualizarLibro();
                    break;
                case 4: EliminarLibro(libros);
                    break;
            }
        }

        private static void CrearLibro()
        {
            Libro nuevoLibro = new Libro(); 
            Console.WriteLine("Ingrese el id del libro:");
            nuevoLibro.IdLibro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del libro:");
            nuevoLibro.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el autor del libro:");
            nuevoLibro.Autor = Console.ReadLine();
            Console.WriteLine("Ingrese el año de publicacion:");
            nuevoLibro.AnioDePublicacion = Convert.ToInt32(Console.ReadLine());

            GestorDeDatos.CrearLibro(nuevoLibro);
        }

        private static void LeerLibro()
        {
            int opc;
            Console.WriteLine("1- Leer todos los libros");
            Console.WriteLine("2- Leer por id");

            try { 
                opc = Convert.ToInt32(Console.ReadLine());

                if(opc == 1) GestorDeDatos.LeerLibro();
                if (opc == 2)
                {
                    Console.WriteLine("Ingresa el id del libro:");
                    int idLibro = Convert.ToInt32(Console.ReadLine());
                    GestorDeDatos.LeerLibro(idLibro);
                }
            }catch(Exception e)
            {
                Console.WriteLine(">> ERROR:" + e.Message);
                Console.WriteLine(e);
            }
        }

        private static void ActualizarLibro()
        {
            Libro libroActualizado = new Libro();

            Console.WriteLine("Ingrese el id del libro que desea actualizar: ");
            libroActualizado.IdLibro = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese su nommbre:");
            libroActualizado.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el autor:");
            libroActualizado.Autor = Console.ReadLine();

            Console.WriteLine("Ingrese año de publicacion:");
            libroActualizado.AnioDePublicacion = Convert.ToInt32(Console.ReadLine());

            GestorDeDatos.ActualizarLibros(libroActualizado);
        }

        private static void EliminarLibro(List<Libro> libros)
        {
            Console.WriteLine("Eliminando......!!!");
        }
    }
}
