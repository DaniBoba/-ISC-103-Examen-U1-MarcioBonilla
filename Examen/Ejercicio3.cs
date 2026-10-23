using System;

namespace ExamenesPoo
{
    public class Ejercicio3
    {
        public void ControlAsistencia()
        {
            string[] nombres = { "Ana", "Luis", "Carlos", "María", "José", "Elena", "Pedro", "Sofia", "Jorge", "Lucía" };
            bool[] asistencia = { true, false, true, true, false, true, false, true, true, false };

            int asistieron = 0;
            int faltaron = 0;

            Console.WriteLine("Lista de Participantes");
            for (int i = 0; i < nombres.Length; i++)
            {
                string estado = asistencia[i] ? "Asistió" : "Faltó";
                Console.WriteLine($"{nombres[i]} - {estado}");

                if (asistencia[i]) asistieron = asistieron + 1;
                else faltaron = faltaron + 1;
            }

            double porcentaje = ((double)asistieron / (double)nombres.Length) * 100.0;

            Console.WriteLine($"\nAsistieron: {asistieron}");
            Console.WriteLine($"Faltaron: {faltaron}");
            Console.WriteLine($"Porcentaje de asistencia: {porcentaje}%");

            Console.WriteLine("\nLista de ausentes:");
            foreach (string nombre in nombres)
            {
                int indice = Array.IndexOf(nombres, nombre);
                if (asistencia[indice] == false)
                {
                    Console.WriteLine(nombre);
                }
            }

            Console.Write("\nIngrese nombre a buscar: ");
            string buscar = Console.ReadLine() ?? "";

            if (buscar == "")
            {
                Console.WriteLine("Error: El nombre no puede estar vacío.");
                return;
            }

            bool encontrado = false;
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i] == buscar)
                {
                    string est = asistencia[i] ? "asistió" : "faltó";
                    Console.WriteLine($"Encontrado en posición {i + 1}. El participante {est}.");
                    encontrado = true;
                }
            }

            if (encontrado == false) Console.WriteLine("El participante no está en la lista.");

            Console.WriteLine("\nNombres en orden inverso:");
            for (int i = nombres.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(nombres[i]);
            }
        }
    }
}