using System;
using System.Collections.Generic;

namespace ExamenesPoo
{
    public class Ejercicio4
    {
        public void FilaClinica()
        {
            List<string> urgentes = new List<string>();
            List<string> normales = new List<string>();
            int opcion = 0;

            while (opcion != 6)
            {
                Console.WriteLine("\n=== Clínica ===");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Atender siguiente");
                Console.WriteLine("3. Mostrar fila");
                Console.WriteLine("4. Buscar paciente");
                Console.WriteLine("5. Mostrar cantidad");
                Console.WriteLine("6. Salir");
                Console.Write("Elija opción: ");
                opcion = int.TryParse(Console.ReadLine(), out int op) ? op : 0;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine() ?? "";
                        if (nombre == "" || urgentes.Contains(nombre) || normales.Contains(nombre))
                        {
                            Console.WriteLine("Error: Nombre vacío o ya registrado.");
                            break;
                        }
                        
                        Console.Write("Prioridad (1=urgente, 2=normal): ");
                        int prioridad = int.TryParse(Console.ReadLine(), out int p) ? p : 0;
                        
                        if (prioridad == 1) urgentes.Add(nombre);
                        else if (prioridad == 2) normales.Add(nombre);
                        else Console.WriteLine("Prioridad inválida.");
                        break;

                    case 2:
                        if (urgentes.Count > 0)
                        {
                            Console.WriteLine($"Atendiendo URGENTE: {urgentes[0]}");
                            urgentes.RemoveAt(0);
                        }
                        else if (normales.Count > 0)
                        {
                            Console.WriteLine($"Atendiendo NORMAL: {normales[0]}");
                            normales.RemoveAt(0);
                        }
                        else
                        {
                            Console.WriteLine("No hay pacientes en espera.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nFila Urgentes:");
                        for (int i = 0; i < urgentes.Count; i++) Console.WriteLine($"{i + 1}. {urgentes[i]}");
                        
                        Console.WriteLine("\nFila Normales:");
                        for (int i = 0; i < normales.Count; i++) Console.WriteLine($"{i + 1}. {normales[i]}");
                        
                        Console.WriteLine($"\nTotal en espera: {urgentes.Count + normales.Count}");
                        break;

                    case 4:
                        Console.Write("Nombre a buscar: ");
                        string buscar = Console.ReadLine() ?? "";
                        if (urgentes.Contains(buscar))
                        {
                            int pos = urgentes.IndexOf(buscar);
                            Console.WriteLine($"Está en fila URGENTE, posición {pos + 1}. Tiene {pos} pacientes delante.");
                        }
                        else if (normales.Contains(buscar))
                        {
                            int pos = normales.IndexOf(buscar);
                            Console.WriteLine($"Está en fila NORMAL, posición {pos + 1}. Tiene {pos} pacientes delante.");
                        }
                        else
                        {
                            Console.WriteLine("El paciente no está en fila.");
                        }
                        break;

                    case 5:
                        Console.WriteLine($"Urgentes: {urgentes.Count}, Normales: {normales.Count}");
                        Console.WriteLine($"Total general: {urgentes.Count + normales.Count}");
                        break;
                        
                    case 6:
                        Console.WriteLine("Saliendo...");
                        break;
                        
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}