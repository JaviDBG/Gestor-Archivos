using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestorArchivo
{
    class Program
    {
        static void Main(string[] args)
        {
            archivo file = new archivo();

            
            string opc = "";
            bool exit = false;
            while(exit!=true)
            {
                Console.WriteLine("..:: Administrador de archivos ::..");
                Console.WriteLine("OPCIONES");
                Console.WriteLine("1. Crear Archivo");
                Console.WriteLine("2. Modificar Archivo");
                Console.WriteLine("3. Renombrar Archivo");
                Console.WriteLine("4. salir");
                Console.WriteLine("Ingresa opcion:");
                opc = Console.ReadLine();

                if (opc.Equals("1"))
                {
                    Console.WriteLine(file.createFile());
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (opc.Equals("2"))
                {
                    Console.WriteLine(file.updateFile());
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (opc.Equals("3"))
                {
                    Console.WriteLine(file.renameFile());
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (opc.Equals("4"))
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("No existe opcion, intenta nuevamente");
                    Console.ReadLine();
                    Console.Clear();
                }



            }
           
            


        }
    }
}
