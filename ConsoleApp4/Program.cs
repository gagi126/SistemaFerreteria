using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("Herramientas.txt"))
            {
                //Si el archivo ya existe no hace nada, en caso de no existir (es porque es la primera vez que se inicia el programa), se crea el archivo.
            }
            else
            {
                Console.WriteLine("Hola, bienvenido al sistema de stock para ferreterias....");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                StreamWriter escritura = File.CreateText("Herramientas.txt");
                Console.WriteLine("Se esta creando el archivo de datos, por favor espere...");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                escritura.Close();
            }
            string respuesta = "";
            while (respuesta != "4")
            {
                respuesta = Opciones();
                Console.Clear();
                switch (respuesta)
                {
                    case "1":
                        Agregarherramienta();
                        Console.Clear();
                        Console.WriteLine("Guardando articulo.....");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Guardando articulo.....Guardado con exito");
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case "2":
                        Console.WriteLine("Atencion: El sistema unicamente busca por MARCA, por favor ingrese unicamente la marca del articulo");
                        Buscarherramientas();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Recibiendo stock...");
                        System.Threading.Thread.Sleep(1000);
                        Listaherramienta();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del sistema...");
                        System.Threading.Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("La opcion ingresada es invalida, por favor reintente.");
                        Console.Clear();
                        break;
                }
            }


        }
        private static void Agregarherramienta()
        {
            
            {
                string codigo, descripcion, marca,cadena;
                int stockactual;
                int aux;
                decimal stockActual, stockMinimoActual,PRECIOU;

                Console.WriteLine("Ingrese el codigo del articulo a cargar (MAXIMO 7 CARACTERES) : ");
                codigo = Console.ReadLine();
                aux = codigo.Length;
                Console.Clear();
                while (aux >= 8 ||  aux == 0)
                {
                    Console.WriteLine("Al parecer, ingresaste mas de 7 caracteres, por favor reintente ");
                    Console.WriteLine("Ingrese el codigo del articulo a cargar (MAXIMO 7 CARACTERES) :");
                    codigo = Console.ReadLine();
                    aux = codigo.Length;
                }
                Console.Clear();
                Console.WriteLine("Ingrese la descripcion del articulo a cargar (MAXIMO 15 CARACTERES) : ");
                descripcion = Console.ReadLine();
                aux = descripcion.Length;
                Console.Clear();
                while (aux >= 16 || aux == 0)
                {
                    Console.WriteLine("Al parecer, ingresaste mas de 15 caracteres, por favor reintente ");
                    Console.WriteLine("Ingrese la descripcion del articulo a cargar (MAXIMO 15 CARACTERES) :");
                    descripcion = Console.ReadLine();
                    aux = descripcion.Length;
                }
                Console.Clear();
                Console.WriteLine("Ingrese la marca del articulo a cargar (MAXIMO 10 CARACTERES) : ");
                marca = Console.ReadLine();
                aux = marca.Length;
                Console.Clear();
                while (aux >= 11 || aux == 0)
                {
                    Console.WriteLine("Al parecer, ingresaste mas de 10 caracteres, por favor reintente  ");
                    Console.WriteLine("Ingrese la marca del articulo a cargar (MAXIMO 10 CARACTERES) :");
                    marca = Console.ReadLine();
                    aux = marca.Length;
                }
                Console.Clear();
                Console.WriteLine("Ingrese el stock actual del articulo a cargar (MAXIMO 5 CARACTERES): ");
                cadena = Console.ReadLine();
                aux = cadena.Length;
                Console.Clear();
                while (int.TryParse(cadena, out stockactual) == false || (aux>= 6 || aux == 0))
                {
                    Console.WriteLine("Lo que has ingresado es invalido, reingrese...");
                    cadena = Console.ReadLine();
                    aux = cadena.Length;
                }
                decimal.TryParse(cadena, out stockActual);
                Console.Clear();
                Console.WriteLine("Ingrese el stock minimo del articulo a cargar (MAXIMO 5 CARACTERES): ");
                cadena = Console.ReadLine();
                aux = cadena.Length;
                Console.Clear();
                while (int.TryParse(cadena, out stockactual) == false || (aux >= 6 || aux == 0))
                {
                    Console.WriteLine("Lo que has ingresado es invalido, reingrese...");
                    cadena = Console.ReadLine();
                    aux = cadena.Length;
                }
                decimal.TryParse(cadena, out stockMinimoActual);
                Console.Clear();
                Console.WriteLine("Ingrese el precio unitario del articulo a cargar(MAXIMO 7 CARACTERES): ");
                cadena = Console.ReadLine();
                aux = cadena.Length;
                Console.Clear();
                while (int.TryParse(cadena, out stockactual) == false || (aux >= 8 || aux == 0))
                {
                    Console.WriteLine("Lo que has ingresado es invalido, reingrese...");
                    cadena = Console.ReadLine();
                    aux = cadena.Length;
                }   
                decimal.TryParse(cadena, out PRECIOU);
                Console.Clear();
                FileStream escritura = new FileStream("Herramientas.txt", FileMode.Append);
                StreamWriter lectura = new StreamWriter(escritura);
                 lectura.WriteLine(string.Join(";", (new List<string>()
            {
                    codigo,

                    descripcion,

                    stockActual.ToString(),

                    stockMinimoActual.ToString(),

                    marca,

                    PRECIOU.ToString()

            }
                )
                    )
                        );

                lectura.Close();

                escritura.Close();

            }
            
        }
        private static void Listaherramienta()
        {
            FileStream escritura = new FileStream("Herramientas.txt", FileMode.Open);
            StreamReader lectura = new StreamReader(escritura);
         List<string[]> resultados = new List<string[]>();
        while (lectura.EndOfStream == false)
            {
            resultados.Add(lectura.ReadLine().Split(';'));
            }
            escritura.Close();
            lectura.Close();

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("|Código |Descripción    |St.A |St.M |Marca     |P. U.  |");
                Console.WriteLine("--------------------------------------------------------");

            foreach (string[] datos in resultados)
                {
                   Console.WriteLine("|{0,7}|{1,-15}|{2,5}|{3,5}|{4,-10}|{5,7}|", datos);
                 }
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Cantidad de articulos listados: {0}", resultados.Count);
            Console.WriteLine("Aprete una tecla para continuar.");
        }
        private static void Buscarherramientas()
        {
            Console.WriteLine("Ingrese la marca del articulo a buscar ");
            string busqueda = Console.ReadLine();
            while (busqueda == "")
            {
                Console.WriteLine("No has ingresado nada, por favor ingrese la marca.");
                busqueda = Console.ReadLine();
            }
            Console.WriteLine("Buscando...");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            FileStream escritura = new FileStream("Herramientas.txt", FileMode.Open);
            StreamReader lectura = new StreamReader(escritura);
            List<string[]> resultados = new List<string[]>();
            while (lectura.EndOfStream == false)
            {
                string[] resultado = lectura.ReadLine().Split(';');
                if (resultado[4].Contains(busqueda))
                {
                    resultados.Add(resultado);
                    
                }
            }
            int res;
            res = Convert.ToInt32(resultados.Count);
            if (res == 0)
            {
                Console.WriteLine("Lo solicitado no existe en el sistema. ");
            }
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("|Código |Descripción    |St.A |St.M |Marca     |P. U.  |");
                Console.WriteLine("--------------------------------------------------------");
            foreach (string[] datos in resultados)
            {
                Console.WriteLine("|{0,7}|{1,-15}|{2,5}|{3,5}|{4,-10}|{5,7}|", datos);
            }
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Cantidad de articulos listados: {0}", resultados.Count);
                Console.WriteLine("Aprete una tecla para continuar.");
            lectura.Close();
            escritura.Close();
        }
        private static string Opciones()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Control de stock para ferreterias");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("1) Agregar articulos");
            Console.WriteLine("2) Busqueda de articulos");
            Console.WriteLine("3) Lista de stock del sistema");
            Console.WriteLine("4) Salir del sistema");
            Console.WriteLine("--------------------------------------------------------");
            return Console.ReadKey().KeyChar.ToString();
        }
    }
}

