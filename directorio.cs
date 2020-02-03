using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestorArchivo
{
    class directorio
    {
        DirectoryInfo directory = new DirectoryInfo(@"C:\files");
        public void inicializacion()
        {
            if (!directory.Exists)
            {
                directory.Create();
            }
        }
        public List<String> mostrarArchivo()
        {
            List<String> lista = new List<string>();
            try
            {
                
                
                FileInfo[] files = directory.GetFiles("*.txt");
                DirectoryInfo[] directories = directory.GetDirectories();
                Console.WriteLine("Lista Archivos [Opcion]: ");
                if(files.Length==0){
                    Console.WriteLine("[El directorio esta Vacio]");
                }
                for (int i = 0; i < files.Length; i++){
                    lista.Add(((FileInfo)files[i]).Name);
                    Console.WriteLine("["+i+"] "+((FileInfo)files[i]).Name);
                }
                /*  Console.WriteLine();
                  Console.WriteLine("Lista Directorios [Opcion]: ");
                  for (int i = 0; i < directories.Length; i++)

                  {

                      Console.WriteLine("["+i+"] " + ((DirectoryInfo)directories[i]).FullName);

                  }*/
               
            }catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }
            return lista;
        }
        public string obtenerRuta()
        {
            return directory.FullName;
        }
    }
}
