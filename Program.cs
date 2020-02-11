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
            directorio directory = new directorio();
            archivo file = new archivo();
            directory.inicializacion();
            Menu(directory,file);
        }

        private static void Menu(directorio directory, archivo file)
        {
            string opc = "";
            bool exit = false;
            List<String> lista = new List<string>();
            bool exit2 = false;
            bool canConvert;
            string input;
            int flag = 0;
            while (exit != true)
            {
                Console.WriteLine("..:: Administrador de archivos V1.0A [DEV.MrB@rg2] ::..");
                Console.WriteLine("OPCIONES: ");
                Console.WriteLine("1. Crear Archivo");
                Console.WriteLine("2. Editor de Texto");
                Console.WriteLine("3. Renombrar Archivo");
                Console.WriteLine("4. Salir");
                Console.Write("Ingresa una opcion: ");
                opc = Console.ReadLine();
                if (opc.Equals("1"))
                {
                    Console.Clear();
                    Console.Write("Ingresa el nombre del nuevo archivo: ");
                    string nombre = Console.ReadLine();
                    file.createFile(directory.obtenerRuta(), nombre);
                    Console.Write("Pulsa la tecla intro para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (opc.Equals("2"))
                {
                    Console.Clear();
                    lista.Clear();
                    canConvert = false;
                    exit2 = false;
                    while (exit2 != true)
                    {
                        lista = directory.mostrarArchivo();
                        Console.Write("Seleccione la opcion de archivo que desea Editar: > ");
                        input = Console.ReadLine();
                        canConvert = int.TryParse(input, out flag);
                        Console.Clear();
                        if (canConvert.Equals(false))
                        {
                            Console.WriteLine("Opcion invalida, Intente nuevamente");
                            Console.Write("Pulsa la tecla intro para continuar...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            if (flag > (lista.Count - 1) || flag < 0)
                            {
                                Console.WriteLine("Opcion fuera de rango, Intente nuevamente");
                                Console.Write("Pulsa la tecla intro para continuar...");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else
                            {
                                file.writeFile(lista[flag]);
                                exit2 = true;
                            }
                        }

                    }
                }
                else if (opc.Equals("3"))
                {
                    lista.Clear();
                    canConvert=false;                    
                    Console.Clear();
                    exit2 = false;
                    while (exit2 != true)
                    {
                        lista = directory.mostrarArchivo();
                        Console.Write("Seleccione la opcion de archivo que desea renombrar: >");
                        input = Console.ReadLine();
                        canConvert = int.TryParse(input, out flag);
                        if (canConvert.Equals(false))
                        {
                            Console.WriteLine("Opcion invalida, Intente nuevamente");
                            Console.Write("Pulsa la tecla intro para continuar...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            if (flag > (lista.Count - 1) || flag < 0)
                            {
                                Console.WriteLine("Opcion fuera de rango, Intente nuevamente");
                                Console.Write("Pulsa la tecla intro para continuar...");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Write("Ingresar nuevo nombre: ");
                                string nuevoNombre = Console.ReadLine();
                                file.renameFile(directory.obtenerRuta(), lista[flag], nuevoNombre);
                                exit2 = true;
                            }
                        }

                        //Console.WriteLine(file.renameFile());
                    }
                    Console.Write("Pulsa la tecla intro para continuar...");
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
                    Console.Write("Pulsa la tecla intro para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
