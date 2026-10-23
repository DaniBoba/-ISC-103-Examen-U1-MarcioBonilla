using System;
using System.Collections.Generic;

namespace ExamenesPoo
{
    public class Ejercicio5
    {
        public void Inventario()
        {
            List<string> nombres = new List<string>();
            List<int> existencias = new List<int>();
            List<decimal> precios = new List<decimal>();
            int opcion = 0;

            while (opcion != 6)
            {
                Console.WriteLine("\n Papelería ");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Vender producto");
                Console.WriteLine("3. Abastecer producto");
                Console.WriteLine("4. Mostrar inventario");
                Console.WriteLine("5. Mostrar alertas");
                Console.WriteLine("6. Salir");
                Console.Write("Elija opción: ");
                opcion = int.TryParse(Console.ReadLine(), out int op) ? op : 0;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string nom = Console.ReadLine() ?? "";
                        if (nom == "" || nombres.Contains(nom))
                        {
                            Console.WriteLine("Error: Inválido o repetido.");
                            break;
                        }
                        
                        Console.Write("Existencia: ");
                        int ext = int.TryParse(Console.ReadLine(), out int e) ? e : -1;
                        
                        Console.Write("Precio unitario: ");
                        decimal prec = decimal.TryParse(Console.ReadLine(), out decimal pr) ? pr : 0;

                        if (ext < 0 || prec <= 0)
                        {
                            Console.WriteLine("Error: Cantidades inválidas.");
                            break;
                        }
                        
                        nombres.Add(nom);
                        existencias.Add(ext);
                        precios.Add(prec);
                        break;

                    case 2:
                        Console.Write("Producto a vender: ");
                        string vNom = Console.ReadLine() ?? "";
                        if (nombres.Contains(vNom) == false)
                        {
                            Console.WriteLine("Producto no existe.");
                            break;
                        }
                        
                        Console.Write("Cantidad: ");
                        int vCant = int.TryParse(Console.ReadLine(), out int vc) ? vc : 0;
                        int vIndex = nombres.IndexOf(vNom);

                        if (vCant > 0 && existencias[vIndex] >= vCant)
                        {
                            existencias[vIndex] = existencias[vIndex] - vCant;
                            decimal totalVenta = vCant * precios[vIndex];
                            Console.WriteLine($"Venta exitosa. Total: L. {totalVenta:F2}");
                        }
                        else
                        {
                            Console.WriteLine($"Error. Existencia disponible: {existencias[vIndex]}");
                        }
                        break;

                    case 3:
                        Console.Write("Producto a abastecer: ");
                        string aNom = Console.ReadLine() ?? "";
                        if (nombres.Contains(aNom) == false)
                        {
                            Console.WriteLine("Producto no existe.");
                            break;
                        }
                        
                        Console.Write("Cantidad a ingresar: ");
                        int aCant = int.TryParse(Console.ReadLine(), out int ac) ? ac : 0;
                        
                        if (aCant > 0)
                        {
                            int aIndex = nombres.IndexOf(aNom);
                            existencias[aIndex] = existencias[aIndex] + aCant;
                            Console.WriteLine("Abastecido correctamente.");
                        }
                        else Console.WriteLine("Cantidad inválida.");
                        break;

                    case 4:
                        decimal totalInventario = 0;
                        for (int i = 0; i < nombres.Count; i++)
                        {
                            decimal valorTotalItem = existencias[i] * precios[i];
                            totalInventario = totalInventario + valorTotalItem;
                            Console.WriteLine($"{nombres[i]} | Existencia: {existencias[i]} | Precio: L. {precios[i]:F2} | Valor Total: L. {valorTotalItem:F2}");
                        }
                        Console.WriteLine($"\nValor total del inventario: L. {totalInventario:F2}");
                        break;

                    case 5:
                        decimal mayorValor = -1;
                        string productoMayor = "";
                        
                        Console.WriteLine("\n--- Alertas de Existencia Baja ---");
                        for (int i = 0; i < nombres.Count; i++)
                        {
                            if (existencias[i] <= 5) Console.WriteLine($"{nombres[i]} (Solo quedan {existencias[i]})");
                            
                            decimal valorItem = existencias[i] * precios[i];
                            if (valorItem > mayorValor)
                            {
                                mayorValor = valorItem;
                                productoMayor = nombres[i];
                            }
                        }
                        Console.WriteLine($"\nProducto con mayor valor en inventario: {productoMayor} (L. {mayorValor:F2})");
                        break;
                }
            }
        }
    }
}