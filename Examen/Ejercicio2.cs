
namespace ExamenesPoo
{
    public class Ejercicio2
    {
        public void SimularCarga()
        {
            Console.Write("Tipo (1=regular, 2=premium, 3=diésel): ");
            int tipo = int.TryParse(Console.ReadLine(), out int t) ? t : 0;

            Console.Write("Cantidad de litros (máx 60): ");
            int litrosSolicitados = int.TryParse(Console.ReadLine(), out int l) ? l : 0;

            if (tipo < 1 || tipo > 3 || litrosSolicitados <= 0 || litrosSolicitados > 60)
            {
                Console.WriteLine("Error: Datos fuera de rango.");
                return;
            }

            decimal precioLitro = 0;
            switch (tipo)
            {
                case 1: precioLitro = 28.50m; break;
                case 2: precioLitro = 32.00m; break;
                case 3: precioLitro = 26.75m; break;
            }

            int litrosCargados = 0;
            Console.WriteLine("\nIniciando carga...");

            while (litrosCargados < litrosSolicitados)
            {
                int carga = 5;
                if (litrosSolicitados - litrosCargados < 5)
                {
                    carga = litrosSolicitados - litrosCargados;
                }
                
                litrosCargados = litrosCargados + carga;
                Console.WriteLine($"Litros cargados: {litrosCargados}");
            }

            decimal subtotal = litrosCargados * precioLitro;
            decimal descuento = 0;

            if (subtotal >= 1500)
            {
                descuento = subtotal * 0.05m;
            }
            else if (subtotal >= 1000)
            {
                descuento = subtotal * 0.03m;
            }

            decimal total = subtotal - descuento;

            Console.WriteLine("\n Resumen ");
            Console.WriteLine($"Total litros: {litrosCargados}");
            Console.WriteLine($"Subtotal: L. {subtotal:F2}");
            Console.WriteLine($"Descuento: L. {descuento:F2}");
            Console.WriteLine($"Total a pagar: L. {total:F2}");
        }
    }
}