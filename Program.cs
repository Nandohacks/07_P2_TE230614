//Ejercicio 7

namespace Ejercicio07_BrazoRobotico
{
    // Clase que representa el Brazo Robótico y sus operaciones de ciclo
    public class BrazoRobotico
    {
        // Propiedades con auto-implementación
        public double TiempoTomar { get; set; }
        public double TiempoTrasladar { get; set; }
        public double TiempoSoltar { get; set; }
        public int NumeroCiclos { get; set; }

        // Constructor por defecto
        public BrazoRobotico() { }

        // Constructor con parámetros
        public BrazoRobotico(double tiempoTomar, double tiempoTrasladar, double tiempoSoltar, int numeroCiclos)
        {
            TiempoTomar = tiempoTomar;
            TiempoTrasladar = tiempoTrasladar;
            TiempoSoltar = tiempoSoltar;
            NumeroCiclos = numeroCiclos;
        }

        // Método para calcular el tiempo total de un solo ciclo
        public double CalcularTiempoPorCiclo()
        {
            return TiempoTomar + TiempoTrasladar + TiempoSoltar;
        }

        // Método para simular el proceso de producción y mostrar los acumulados por ciclo
        public void SimularProduccion()
        {
            double tiempoPorCiclo = CalcularTiempoPorCiclo();
            double tiempoAcumulado = 0.0;

            Console.WriteLine("\n==================================================");
            Console.WriteLine($"Tiempo por ciclo individual: {tiempoPorCiclo:F2} s");
            Console.WriteLine("==================================================");
            Console.WriteLine("INICIANDO SIMULACIÓN DE CICLOS:\n");

            // Ciclo for para calcular e imprimir el tiempo acumulado paso a paso
            for (int i = 1; i <= NumeroCiclos; i++)
            {
                tiempoAcumulado += tiempoPorCiclo;
                Console.WriteLine($"  -> Ciclo {i} completado. Tiempo acumulado: {tiempoAcumulado:F2} s");
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine($"TIEMPO TOTAL DE PRODUCCIÓN: {tiempoAcumulado:F2} s");
            Console.WriteLine("==================================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 7 - Simulación de Brazo Robótico";

            Console.WriteLine("==================================================");
            Console.WriteLine("   SISTEMA DE SIMULACIÓN DE BRAZO ROBÓTICO");
            Console.WriteLine("==================================================\n");

            // Lectura con validación para evitar números negativos o entradas inválidas
            double tTomar = LeerTiempoValido("Ingrese el tiempo para TOMAR la pieza (s): ");
            double tTrasladar = LeerTiempoValido("Ingrese el tiempo para TRASLADAR la pieza (s): ");
            double tSoltar = LeerTiempoValido("Ingrese el tiempo para SOLTAR la pieza (s): ");
            int ciclos = LeerCiclosValidos("Ingrese el número de ciclos a simular: ");

            // Creación/Instanciación del objeto 'robot' a partir de la clase BrazoRobotico
            BrazoRobotico robot = new BrazoRobotico(tTomar, tTrasladar, tSoltar, ciclos);

            // Ejecución del método principal de simulación
            robot.SimularProduccion();

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Método auxiliar para la validación de tiempos (evita valores < 0)
        static double LeerTiempoValido(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out valor) && valor >= 0)
                {
                    return valor;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error: Ingrese un valor numérico válido mayor o igual a 0 s.");
                Console.ResetColor();
            }
        }

        // Método auxiliar para la validación de ciclos (evita ciclos infinitos y valores <= 0)
        static int LeerCiclosValidos(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out valor) && valor > 0)
                {
                    return valor;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error: Ingrese un número entero de ciclos mayor a 0.");
                Console.ResetColor();
            }
        }
    }
}