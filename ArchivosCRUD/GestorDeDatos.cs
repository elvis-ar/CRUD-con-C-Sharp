using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArchivosCRUD
{
    internal class GestorDeDatos
    {
        //###### CREANDO los libros
        public static void CrearLibro(Libro nuevoLibro)
        {
            StreamWriter EscribirArchivo = File.AppendText("Libros.txt");


            EscribirArchivo.WriteLine(nuevoLibro.IdLibro);
            EscribirArchivo.WriteLine(nuevoLibro.Nombre);
            EscribirArchivo.WriteLine(nuevoLibro.Autor);
            EscribirArchivo.WriteLine(nuevoLibro.AnioDePublicacion);
            EscribirArchivo.WriteLine();

            EscribirArchivo.Close();
        }

        //###### LEYENDO TODOS los libros
        internal static void LeerLibro()
        {
            
            if (File.Exists("Libros.txt"))
            {
                
                StreamReader SR = File.OpenText("Libros.txt");
                Libro LibroLeido = new Libro();
                string linea;

                do
                {
                    linea = SR.ReadLine();
                    if (linea != null && linea.Trim() != "")
                    {
                        LibroLeido.IdLibro = Convert.ToInt32(linea);
                        LibroLeido.Nombre = SR.ReadLine().Trim();
                        LibroLeido.Autor = SR.ReadLine().Trim();
                        LibroLeido.AnioDePublicacion = Convert.ToInt32(SR.ReadLine().Trim());
                        MostrarLibro(LibroLeido);
                    }
                } while (linea != null);

                SR.Close();
            }
            else
            {
                Console.WriteLine("El archivos que intentas leer no existe.");
                Console.WriteLine("ingresa daton en el archivo.");
            }

        }

        //###### LEYENDO los libros por IdLibro
        internal static void LeerLibro(int idLibro)
        {
            if (File.Exists("Libros.txt"))
            {

                StreamReader SR = File.OpenText("Libros.txt");
                Libro LibroLeido = new Libro();
                string linea;
                bool libroEncontrado = false;

                do
                {
                    linea = SR.ReadLine();
                    if (linea != null && linea.Trim() != "" && linea == idLibro.ToString())
                    {
                        {
                            LibroLeido.IdLibro = Convert.ToInt32(linea);
                            LibroLeido.Nombre = SR.ReadLine().Trim();
                            LibroLeido.Autor = SR.ReadLine().Trim();
                            LibroLeido.AnioDePublicacion = Convert.ToInt32(SR.ReadLine().Trim());
                            MostrarLibro(LibroLeido);
                            libroEncontrado = true;
                        }
                    }
                } while (linea != null);
                SR.Close();

                if(!libroEncontrado) Console.WriteLine("El libro con ID: {0} no existe", idLibro);
            }
            else
            {
                Console.WriteLine("El archivos que intentas leer no existe.");
                Console.WriteLine("ingresa daton en el archivo.");
            }
        }

        //###### ACTUALIZANDO los libros
        internal static void ActualizarLibros(int idLibro)
        {
            if (File.Exists("Libros.txt"))
            {

                StreamReader SR = File.OpenText("Libros.txt");
                List<Libro> libros = new List<Libro>();
                Libro libroLeido;
                string linea;

                do
                {
                    libroLeido = new Libro();
                    linea = SR.ReadLine();
                    if (linea != null && linea.Trim() != "")
                    {
                        if(linea == idLibro.ToString())
                        {
                            libroLeido.IdLibro = Convert.ToInt32(linea);
                            linea = SR.ReadLine();

                            libroLeido.Nombre = Console.ReadLine();
                            linea = SR.ReadLine();
                            libroLeido.Autor = Console.ReadLine();
                            linea = SR.ReadLine();
                            libroLeido.AnioDePublicacion = Convert.ToInt32(Console.ReadLine());
                            libros.Add(libroLeido);
                        }
                        else
                        {
                            libroLeido.IdLibro = Convert.ToInt32(linea);
                            linea = SR.ReadLine();
                            libroLeido.Nombre = linea;
                            linea = SR.ReadLine();
                            libroLeido.Autor = linea;
                            linea = SR.ReadLine();
                            libroLeido.AnioDePublicacion = Convert.ToInt32(linea);
                            libros.Add(libroLeido);
                        }                        
                    }
                } while(linea != null);
                SR.Close();

                StreamWriter SW = File.CreateText("Libros.txt");
                foreach(Libro libro in libros){
                    SW.WriteLine(libro.IdLibro);
                    SW.WriteLine(libro.Nombre);
                    SW.WriteLine(libro.Autor);
                    SW.WriteLine(libro.AnioDePublicacion);
                    SW.WriteLine(); 
                }
                SW.Close();

            }
            else
            {
                Console.WriteLine("El archivos que intentas leer no existe.");
                Console.WriteLine("ingresa daton en el archivo.");
            }
        }

        //###### Metodo para motrar los libros
        private static void MostrarLibro(Libro libroLeido)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("id: " + libroLeido.IdLibro);
            Console.WriteLine("Nombre: " + libroLeido.Nombre);
            Console.WriteLine("Autor: " + libroLeido.Autor);
            Console.WriteLine("Año de publicacion: " + libroLeido.AnioDePublicacion);
            Console.WriteLine("----------------------------------");
        }

        //###### Metodo para agregar los libros
        
    }
}
