using System;

class CajeroAutomatico
{
    static double saldo = 1000.00;

    static void Main()
    {
        bool activo = true;

        while (activo)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConsultarSaldo();
                    break;

                case "2":
                    Depositar();
                    break;

                case "3":
                    Retirar();
                    break;

                case "4":
                    MostrarNumeros();
                    break;

                case "5":
                    Salir();
                    activo = false;
                    break;

                default:
                    Console.WriteLine("❌ Opción inválida. Intenta de nuevo.\n");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n╔═══════════════════════════════════╗");
        Console.WriteLine("║     CAJERO AUTOMÁTICO - MENÚ      ║");
        Console.WriteLine("╚═══════════════════════════════════╝");
        Console.WriteLine("1. Consultar saldo");
        Console.WriteLine("2. Depositar dinero");
        Console.WriteLine("3. Retirar dinero");
        Console.WriteLine("4. Mostrar números (conteo)");
        Console.WriteLine("5. Salir");
        Console.Write("Selecciona una opción: ");
    }

    static void ConsultarSaldo()
    {
        Console.WriteLine($"\n✓ Tu saldo actual es: S/ {saldo:F2}\n");
    }

    static void Depositar()
    {
        Console.Write("\nIngresa el monto a depositar: S/ ");
        
        if (double.TryParse(Console.ReadLine(), out double monto))
        {
            if (monto > 0)
            {
                saldo += monto;
                Console.WriteLine($"✓ Depósito exitoso. Nuevo saldo: S/ {saldo:F2}\n");
            }
            else
            {
                Console.WriteLine("❌ El monto debe ser mayor a cero.\n");
            }
        }
        else
        {
            Console.WriteLine("❌ Entrada inválida. Ingresa un número.\n");
        }
    }

    static void Retirar()
    {
        Console.Write("\nIngresa el monto a retirar: S/ ");
        
        if (double.TryParse(Console.ReadLine(), out double monto))
        {
            if (monto <= 0)
            {
                Console.WriteLine(" El monto debe ser mayor a cero.\n");
            }
            else if (monto > saldo)
            {
                Console.WriteLine($"❌ Saldo insuficiente. Saldo disponible: S/ {saldo:F2}\n");
            }
            else
            {
                saldo -= monto;
                Console.WriteLine($"✓ Retiro exitoso. Nuevo saldo: S/ {saldo:F2}\n");
            }
        }
        else
        {
            Console.WriteLine("❌ Entrada inválida. Ingresa un número.\n");
        }
    }

    static void MostrarNumeros()
    {
        Console.Write("\nIngresa el límite para el conteo: ");
        
        if (int.TryParse(Console.ReadLine(), out int limite))
        {
            if (limite < 1)
            {
                Console.WriteLine("❌ El límite debe ser mínimo 1.\n");
                return;
            }

            Console.WriteLine("\nSecuencia:");
            for (int i = 1; i <= limite; i++)
            {
                Console.Write(i);
                if (i < limite) Console.Write(", ");
            }
            Console.WriteLine("\n");
        }
        else
        {
            Console.WriteLine("❌ Entrada inválida. Ingresa un número entero.\n");
        }
    }

    static void Salir()
    {
        Console.WriteLine("\n╔═══════════════════════════════════╗");
        Console.WriteLine("║   Gracias por usar el cajero. ¡Adiós! ║");
        Console.WriteLine("╚═══════════════════════════════════╝\n");
    }
}