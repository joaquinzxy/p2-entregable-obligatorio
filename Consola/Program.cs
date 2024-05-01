﻿using Dominio;


namespace Consola
{

    public class Program
    {
        static Sistema sistema = Sistema.Instancia;
        
        static void Main(string[] args)
        {
            sistema.InicializarPrecarga(); 
            int opcion = 0;
            string[] opciones = { "Listar Animales", "Mostrar Potreros", "Precio por kilo de lana", "Alta de ganado Bovino", "Mostrar precios de venta" };
            do
            {
                Menu(opciones);
                opcion = LeerNumero();
                switch (opcion)
                {
                    case 1:
                        
                        ListarAnimales();
                        break;

                    case 2:
                        ObtenerPotreroSegunHectareas();
                        break;
                    case 3:
                        PrecioKiloLana();
                        break;
                    case 4:
                        AltaDeGanadoBovino();
                        break;
                    case 5:
                        MostrarPreciosVenta();
                        break;
                }

            } while (opcion != 0);
           
        }

        static void Menu(string[] opciones)
        {
            int numero = 1;
            Console.Clear();
            Console.WriteLine("Ingrese una de las siguientes opciones (0 para terminar)");
            foreach (string opcion in opciones)
            {
                Console.WriteLine($"[{numero}] - {opcion} ");
                numero++;
            }
        }
        public static void ListarAnimales()
        {
            Console.WriteLine("\nListado de animales:\n");
            List<Ganado> lista = sistema.ListarGanado();
            if (lista.Count > 0)
            {
                foreach (Ganado unGanado in lista)
                {
                    Console.WriteLine(unGanado.ToString());
                    Console.WriteLine("-------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No hay animales");
            }
            Console.WriteLine("Enter para continuar");
            Console.ReadLine();
        }



        public static void ObtenerPotreroSegunHectareas()
        {
            Console.Write("\n[ 📐 Filtrar potreros por hectareas y capacidad ]\n");
            Console.Write("> Ingrese el mínimo de hectareas: ");
            float cantidadhectareas = Convert.ToSingle(Console.ReadLine());
            Console.Write("> Ingrese el mínimo de capacidad: ");
            int capacidad = Convert.ToInt32(Console.ReadLine());
            List<Potrero> lista = sistema.ObtenerPotreroSegunHectareas(cantidadhectareas, capacidad);
            Console.WriteLine($"Potreros encontrados: {lista.Count}");
            foreach (Potrero unPotrero in lista)
            {
                Console.WriteLine(unPotrero.ToString());
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("\nEnter para continuar");
            Console.ReadLine();
        }


        public static void PrecioKiloLana()
        {
            try
            {
                Console.WriteLine("\n[ ✏️ Definir precio de venta KG lana ]");
                Console.Write("> Ingrese el precio en USD: ");
                float precio = Convert.ToSingle(Console.ReadLine());
                sistema.DefinirPrecioKgLana(precio);
                Console.WriteLine("\nEnter para continuar");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error al cambiar el precio");
                MensajeError(e.Message);
                Console.ReadLine();
            }
        }

        public static void AltaDeGanadoBovino()
        {
            try
            {
                Console.WriteLine("[ Registro de Bovino ]");
                string codCaravana = PedirTexto("> Ingrese código de caravana: ");
                DateTime fechaNacimiento = Convert.ToDateTime(PedirTexto("> Ingrese fecha de nacimiento (DD/MM/AA): "));
                float costoAdquisicion = Convert.ToSingle(PedirTexto("> Ingrese costo de adquisición en USD: "));
                float costoAlimentacion = Convert.ToSingle(PedirTexto("> Ingrese costo de alimentación en USD x KG: "));
                float peso = Convert.ToSingle(PedirTexto("> Ingrese peso en KG: "));
                string raza = PedirTexto("> Ingrese raza: ");
                sistema.AltaBovino(codCaravana, fechaNacimiento, costoAdquisicion, costoAlimentacion, TipoSexo.Macho, peso, false, raza, TipoAlimentacion.Grano);

                Console.WriteLine("Enter para continuar");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error al registrar bovino");
                MensajeError(e.Message);
                Console.ReadLine();
            }
        }
        
        public static void MostrarPreciosVenta()
        {
            Console.WriteLine("\n[💵 Precios de venta definidos en el sistema en USD ]");
            Console.WriteLine("[🐄] Precio por kilo bovino en pie: $" + Bovino.PrecioKgPie + " USD");
            Console.WriteLine("[🐑] Precio por kilo ovino en pie: $" + Ovino.PrecioKgPie + " USD");
            Console.WriteLine("[🐑] Precio por kilo de lana: $" + Ovino.PrecioKgLana + " USD");
            Console.WriteLine("\nEnter para continuar");
            Console.ReadLine();
        }

        static int LeerNumero()
        {
            int opcion;
            Console.Write("> Ingrese número: ");
            while (!(int.TryParse(Console.ReadLine(), out opcion)))
            {
                Console.WriteLine("El valor ingresado no es correcto");
                Console.Write("> Ingrese número: ");
            }
            return opcion;
        }

        static string? PedirTexto(string mensaje = "Ingrese número.")
        {
            bool exito;
            string? valor;
            do
            {
                Console.Write(mensaje);
                valor = Console.ReadLine();
                if (valor == null)
                {
                    MensajeError("No se ha ingresado nada");
                    exito = false;
                }
                else
                {
                    exito = true;
                }

            } while (!exito);
            return valor;
        }

        static void MensajeError(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"---Error----> {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }
        static void MensajeConfirmacion(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"---Confirmado----> {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

    }
}