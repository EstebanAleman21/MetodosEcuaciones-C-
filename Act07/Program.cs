namespace Act07; 

class Program // Definición de la clase principal
{
    // Función que define la ecuación que queremos resolver
    static double Funcion(double x)
    {
        return Math.Pow(x, 4) - 2 * Math.Pow(x, 3) - 5 * Math.Pow(x, 2) + 12 * x - 5;
    }

    // Métod de bisección para encontrar la raíz de la ecuación
    static double Bisection(double a, double b, double tol, out int iter)
    {
        double c;
        iter = 0;
        while ((b - a) >= tol)
        {
            c = (a + b) / 2;
            if (Funcion(c) == 0.0)
                break;
            else if (Funcion(c) * Funcion(a) < 0)
                b = c;
            else
                a = c;
            iter++;
        }
        return (a + b) / 2;
    }

    // Métod de la secante para encontrar la raíz de la ecuación
    static double Secant(double x0, double x1, double tol, out int iter)
    {
        double x2;
        iter = 0;
        do
        {
            x2 = x1 - (Funcion(x1) * (x1 - x0)) / (Funcion(x1) - Funcion(x0));
            x0 = x1;
            x1 = x2;
            iter++;
        } while (Math.Abs(Funcion(x2)) > tol);
        return x2;
    }

    // Función que calcula la derivada de la ecuación
    static double Derivada(double x)
    {
        return 4 * Math.Pow(x, 3) - 6 * Math.Pow(x, 2) - 10 * x + 12;
    }

    // Métod de Newton-Raphson para encontrar la raíz de la ecuación
    static double NewtonRaphson(double x0, double tol, out int iter)
    {
        double x1;
        iter = 0;
        do
        {
            x1 = x0 - (Funcion(x0) / Derivada(x0));
            x0 = x1;
            iter++;
        } while (Math.Abs(Funcion(x1)) > tol);
        return x1;
    }

    // Métod principal que se ejecuta al iniciar el programa
    static void Main(string[] args)
    {
        double a = 0, b = 3; // Intervalo inicial
        double x0 = 0, x1 = 3; // Valores iniciales para la secante y Newton-Raphson
        double tol = 0.0001; // Tolerancia
        int iter; // Contador de iteraciones

        // Métod de Bisección
        double rootBiseccion = Bisection(a, b, tol, out iter);
        Console.WriteLine("Raiz encontrada con biseccion: " + rootBiseccion);
        Console.WriteLine("Numero de iteraciones con biseccion: " + iter);

        // Métod de la Secante
        double rootSecante = Secant(x0, x1, tol, out iter);
        Console.WriteLine("Raiz encontrada con secante: " + rootSecante);
        Console.WriteLine("Numero de iteraciones con secante: " + iter);

        // Métod de Newton-Raphson
        double rootNewton = NewtonRaphson(x0, tol, out iter);
        Console.WriteLine("Raiz encontrada con Newton-Raphson: " + rootNewton);
        Console.WriteLine("Numero de iteraciones con Newton-Raphson: " + iter);
    }
}
