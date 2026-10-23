namespace ExamenesPoo
{
    public class Ejercicio1
    {
        public void Cotizar()
        {
            Console.Write("Nombre del cliente: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Zona (1=local, 2=departamental, 3=nacional): ");
            int zona = int.TryParse(Console.ReadLine(), out int z) ? z : 0;

            Console.Write("Peso (kg): ");
            decimal peso = decimal.TryParse(Console.ReadLine(), out decimal p) ? p : 0;

            Console.Write("Tipo de servicio (1=estándar, 2=express, 3=mismo día): ");
            int servicio = int.TryParse(Console.ReadLine(), out int s) ? s : 0;

            Console.Write("Valor declarado (L): ");
            decimal valor = decimal.TryParse(Console.ReadLine(), out decimal v) ? v : -1;

            if (zona < 1 || zona > 3 || peso <= 0 || servicio < 1 || servicio > 3 || valor < 0)
            {
                Console.WriteLine("Error: Ingrese datos válidos según los rangos establecidos.");
                return;
            }

            decimal tarifaBase = 0;
            switch (zona)
            {
                case 1: tarifaBase = 60.00m; break;
                case 2: tarifaBase = 100.00m; break;
                case 3: tarifaBase = 150.00m; break;
            }

            decimal recargoPeso = 0;
            if (peso > 1 && peso <= 5) recargoPeso = 40.00m;
            else if (peso > 5 && peso <= 10) recargoPeso = 80.00m;
            else if (peso > 10) recargoPeso = 140.00m;

            decimal subtotalBase = tarifaBase + recargoPeso;
            decimal recargoServicio = 0;

            switch (servicio)
            {
                case 1: recargoServicio = 0; break;
                case 2: recargoServicio = subtotalBase * 0.25m; break;
                case 3: recargoServicio = subtotalBase * 0.50m; break;
            }

            decimal seguro = 0;
            if (valor > 5000)
            {
                seguro = valor * 0.02m;
            }

            string estadoSeguro = (valor > 5000) ? "Envío asegurado" : "Envío sin seguro";

            decimal subtotal = subtotalBase + recargoServicio + seguro;
            decimal descuento = 0;

            if (subtotal > 700)
            {
                descuento = subtotal * 0.05m;
            }

            decimal total = subtotal - descuento;

            Console.WriteLine($"\n Recibo de {nombre} ");
            Console.WriteLine(estadoSeguro);
            Console.WriteLine($"Tarifa base: L. {tarifaBase:F2}");
            Console.WriteLine($"Recargo por peso: L. {recargoPeso:F2}");
            Console.WriteLine($"Recargo por servicio: L. {recargoServicio:F2}");
            Console.WriteLine($"Seguro: L. {seguro:F2}");
            Console.WriteLine($"Subtotal: L. {subtotal:F2}");
            Console.WriteLine($"Descuento: L. {descuento:F2}");
            Console.WriteLine($"Total a pagar: L. {total:F2}");
        }
    }
}