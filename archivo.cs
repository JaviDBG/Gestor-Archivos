using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GestorArchivo
{
    class archivo
    {

        public void createFile(string ruta, string nombre)
        {
            bool exit = false;
            FileStream fs;
            try {
                //File.WriteAllText("@"+ruta+"/"+nombre, "");
                
                    if (!File.Exists(@ruta + "/" + nombre + ".txt"))
                    {
                        fs = File.Create(@ruta + "/" + nombre + ".txt");
                        fs.Close();
                        Console.WriteLine("Archivo Creado Correctamente. Ruta: " + ruta + "/" + nombre + ".txt");
                    }
                    else
                    {
                        while (exit != true)
                        {
                            Console.WriteLine("[ADVERTENCIA]: SI REMPLAZA EL ARCHIVO, TODO SU CONTENIDO SE PERDERA ");
                            Console.Write("El archivo ya existe ¿Desea Remplazarlo? [s/n]: ");
                            string opc = Console.ReadLine().ToUpper();
                            if (opc.Equals("S"))
                            {
                                fs=File.Create(@ruta + "/" + nombre + ".txt");
                                fs.Close();
                                Console.WriteLine("Archivo Remplazado Correctamente. Ruta: " + ruta + "/" + nombre + ".txt");
                                exit = true;
                            }
                            else if (opc.Equals("N"))
                            {
                                exit = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Opcion invalida, intenta nuevamente: ");
                            }
                        }
                    }
                
            }
            catch (Exception ex){    
                 Console.WriteLine( ex.ToString());
            }
        }
        public string updateFile()
        {
            return "Seccion Modificar Archivo";
        }
        public void renameFile(string ruta, string nombre, string nombreNuevo)
        {
            string archivoExistente = ruta + "/" + nombre ;
            string archivoNuevo = ruta + "/" + nombreNuevo + ".txt";
            bool exit = false;
            if (!File.Exists(archivoNuevo))
            {
                File.Move(archivoExistente,archivoNuevo);
                File.Delete(archivoExistente);
                Console.WriteLine("Archivo renombrado correctamente. Ruta: "+archivoNuevo);
            }else {
                while (exit != true) {
                    Console.WriteLine("[ADVERTENCIA]: SI REMPLAZA EL ARCHIVO, TODO SU CONTENIDO SE PERDERA ");
                    Console.WriteLine("Ya existe un archivo con el nombre '"+nombreNuevo+"'.¿Desea Remplazarlo? [s/n]: ");
                    string opc = Console.ReadLine().ToUpper();
                    if (opc.Equals("S")){
                        File.Create(archivoNuevo);
                        File.Delete(archivoExistente);
                        Console.WriteLine("Archivo Renombrado Correctamente. Ruta: " +archivoNuevo);
                        exit = true;
                    }else if (opc.Equals("N")){
                        exit = true;
                    }else{
                        Console.Clear();
                        Console.WriteLine("Opcion invalida, intenta nuevamente: ");
                    }
                }
            }
        }

        public void readFile(string nombre)
        {
            bool exit = false;
            StreamReader sr;
            StreamWriter sw;
            string linea;
            int contador = 0;
            var opc="";
            var opcS = "";
            var contenido = "";
            bool canConvert;
            string input;
            int flag = 0;
            List<string> lista = new List<string>();

            while (exit != true)
            {
                lista.Clear();
                contador = 0;


                    sr = new StreamReader("C:/files/"+nombre);
                
                    Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒MINIBARRI EDITOR V1.0A ["+nombre+"]▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");

                    while ((linea = sr.ReadLine()) != null)
                    {
                        lista.Add(linea);
                        Console.Write("[" + contador + "]>: ");
                        Console.WriteLine(lista[contador]);
                        contador++;
                    }
                    sr.Close();
                    Console.WriteLine();
                    Console.Write("[R= Regresar] [E= Editar] : >");
                    opc = Console.ReadLine().ToUpper();

                    if (opc.Equals("E"))
                    {
                        Console.Write("[N= Nueva Fila] [F= Editar Fila] : >");
                        opcS = Console.ReadLine().ToUpper();
                        if (opcS.Equals("N"))
                        {
                            sw = new StreamWriter("C:/files/"+nombre);                            
                            Console.Write(">");
                            contenido = Console.ReadLine();
                            lista.Add(contenido);
                            foreach (var lineaLista in lista)
                            {
                                sw.WriteLine(lineaLista);
                            }
                            sw.Close();
                            Console.Write("Modificacion Guardada, Presione intro para continuar...");
                            Console.ReadLine();
                        }else if (opcS.Equals("F"))
                        {
                                Console.Write("Seleccione la fila del archivo que desea Editar: > ");
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
                                        sw = new StreamWriter("C:/files/" + nombre);
                                        Console.Write(">");
                                        contenido = Console.ReadLine();
                                        lista[flag]=contenido;
                                        foreach (var lineaLista in lista)
                                        {
                                            sw.WriteLine(lineaLista);
                                        }
                                        sw.Close();
                                        Console.Write("Modificacion Guardada, Presione intro para continuar...");
                                        Console.ReadLine();
                                    }
                                }
                        }
                        else
                        {
                            Console.Write("Opcion Incorrecta, Presione intro para continuar...");
                            Console.ReadLine();
                        }

                    }
                    else if (opc.Equals("R"))
                    {
                        exit = true;
                    }

                    Console.Clear();
                }



            
            
            
           


            
        }

    }
}
