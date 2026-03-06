using System;

namespace SingletonApp
{
    public class Central_911
    {
        private static Central_911 _instance;
        private static readonly object _lock = new object();

        public string Central { get; private set; }

        private Central_911()
        {
            Central = "Central 911";
        }

        public static Central_911 Obtener_Instancia()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Central_911();
                    }
                }
            }
            return _instance;
        }

        public void ConectarLlamada(Operador operador, string tipoEmergencia)
        {
            Console.WriteLine("\nLlamada conectada con el operador " + operador.Nombre);
            operador.AtiendeEmergencia(tipoEmergencia);
        }
    }

    public class Operador
    {
        public int Id_Operador { get; set; }
        public string Nombre { get; set; }

        public Operador(int id, string nombre)
        {
            Id_Operador = id;
            Nombre = nombre;
        }

        public void AtiendeEmergencia(string tipoEmergencia)
        {
            Console.WriteLine($"Operador {Nombre} atendiendo emergencia de tipo: {tipoEmergencia}");
            switch (tipoEmergencia)
            {
                case "Intento de suicidio":
                    Console.WriteLine("Enviando unidades de apoyo y rescate.");
                    break;
                case "Incendio":
                    Console.WriteLine("Enviando bomberos.");
                    break;
                case "Accidente":
                    Console.WriteLine("Enviado paramedicos y oficiales.");
                    break;
                case "Violeta":
                    Console.WriteLine("Enviando una patrulla.");
                    break;
                default:
                    Console.WriteLine("Tipo de emergencia no reconocido.");
                    break;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Instancias del Singleton
            Central_911 Llamada1 = Central_911.Obtener_Instancia();
            Central_911 Llamada2 = Central_911.Obtener_Instancia();

            // Operadores originales
            Operador op1 = new Operador(1, "Laura");
            Operador op2 = new Operador(2, "Carlos");
            
            // AGREGADO: Más operadores
            Operador op3 = new Operador(3, "Marta");
            Operador op4 = new Operador(4, "Javier");

            // Llamadas originales
            Llamada1.ConectarLlamada(op1, "Incendio");
            Llamada2.ConectarLlamada(op2, "Violeta");
            Llamada1.ConectarLlamada(op1, "Accidente");
            Llamada2.ConectarLlamada(op2, "Intento de suicidio");

            // AGREGADO: Más llamadas
            Llamada1.ConectarLlamada(op3, "Violeta");
            Llamada2.ConectarLlamada(op4, "Incendio");
            Llamada2.ConectarLlamada(op3, "Accidente");

            // Verificando que es una única instancia
            Console.WriteLine("\nReferenceEquals: " + ReferenceEquals(Llamada1, Llamada2));
        }
    }
}
