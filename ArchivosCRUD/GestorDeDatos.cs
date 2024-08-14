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
                //cargamos en una lista de libros todos los libros y posteriormente los leemos
                List<Libro> libros = new List<Libro>();
                cargarLibros(libros);
                foreach(Libro libro in libros)
                {
                    MostrarLibro(libro);
                }
            }
            else
            {
                Console.WriteLine("El archivos que intentas leer no existe.");
                Console.WriteLine("ingresa datos en el archivo.");
            }

        }

        //###### LEYENDO los libros por IdLibro
        internal static void LeerLibro(int idLibro)
        {
            if (File.Exists("Libros.txt"))
            {
                bool libroEncontrado = false;

                List<Libro> libros = new List<Libro>();
                cargarLibros(libros);

                foreach(Libro libro in libros)
                {
                    if (libro.IdLibro == idLibro)
                    {
                        MostrarLibro(libro);
                        libroEncontrado = true;
                    }
                }

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


        
         //###### Metodo para cargar libros
        public static void cargarLibros(List<Libro> libros) 
        {
            //abrimos el fichero y creamos las variables para guardar el libro y la linea leida
            StreamReader SR = File.OpenText("Libros.txt");
            Libro libro;
            string linea ;

            //evaluamos que no sea null es decir fin del fichero ni que sea un salto de linea o linea vacia

            do 
            {
                linea = SR.ReadLine();
                if (linea != null && linea != "")
                {
                    // agregamos el id - nombre - autor - año de publicacion y agregamos el libro a la lista de libros 
                    libro = new Libro();
                    libro.IdLibro = Convert.ToInt32(linea);

                    linea = SR.ReadLine().Trim();
                    libro.Nombre = linea;

                    linea = SR.ReadLine().Trim();
                    libro.Autor = linea;

                    linea = SR.ReadLine().Trim();
                    libro.AnioDePublicacion = Convert.ToInt32(linea);

                    libros.Add(libro);                    
                }
            } while (linea != null);
            SR.Close();
        }
    }
}
