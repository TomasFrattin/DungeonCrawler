public static class Menu
{
    private static Player? currentPlayer;

    public static void Show()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("╔══════════════════════╗");
        Console.WriteLine("║    DUNGEON CRAWLER   ║");
        Console.WriteLine("╚══════════════════════╝");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nBienvenido al Menu!\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Iniciar Exploración.");
        Console.WriteLine("2. Información.");
        Console.WriteLine("7. Eliminar progreso.");
        Console.WriteLine("9. Salir del juego");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nPor favor, ingresa una opción: ");

        Console.ResetColor();

        string? choice = Console.ReadLine();
        HandleChoice(choice);
    }

    private static void HandleChoice(string? choice)
    {
        switch (choice)
        {
            case "1":
                currentPlayer = Utils.SaveSystem.LoadPlayer();

                if (currentPlayer == null)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Utils.WriteSlowly("Parece que no tienes un guardado previo. Vamos a crear uno nuevo.\n");
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Por favor, ingresa tu nombre aventurero:");
                    Console.ResetColor();
                    string? playerName = Console.ReadLine();

                    currentPlayer = new Player
                    {
                        Name = playerName ?? "Aventurero",
                        MaxHealth = 100,
                        Health = 80,
                        Attack = 10,
                        Gold = 0
                    };
                }

                Game.StartExploration(currentPlayer);
                break;

            case "2":
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Utils.WriteSlowly("Información del juego:\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Utils.WriteSlowly("Bienvenido a Dungeon Crawler, un juego roguelike de exploración de mazmorra donde la suerte lo es todo.");
                Utils.WriteSlowly("...\n");
                Utils.WriteSlowly("En este juego, te enfrentarás a criaturas, encontrarás tesoros y tomarás decisiones que afectarán tu aventura.");
                Utils.WriteSlowly("...\n");
                Utils.WriteSlowly("Recuerda que cada partida es única y la exploración es clave para sobrevivir.");
                Utils.WriteSlowly("...\n");
                Utils.WriteSlowly("Sin embargo, Dugeon Crawler cuenta con un sistema de guardado y progreso, donde tus estadísticas se mantienen entre sesiones.");
                Utils.WriteSlowly("Estos guardados se generan de manera automática cada vez que acabes con un evento (descanso, pelea, muerte, etc.).");
                Utils.WriteSlowly("Así que tenlo en cuenta aventurero! Ahora ve en busca de aventuras! Grandes tesoros te esperan.");
                Utils.PlaceHolder();
                Show();
                break;
            case "7":
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Utils.WriteSlowly("¡Atención! Esta acción eliminará todo tu progreso guardado.");
                Utils.WriteSlowly("¿Estás seguro de que deseas continuar? (S/N)");
                Console.ResetColor();

                string? confirm = Console.ReadLine()?.Trim().ToUpper();

                if (confirm == "S")
                {
                    Utils.SaveSystem.DeleteSave();
                    Utils.WriteSlowly("Progreso eliminado exitosamente.");
                    Utils.PlaceHolder();
                }
                else
                {
                    Utils.WriteSlowly("Operación cancelada. Tu progreso permanece intacto.");
                    Utils.PlaceHolder();
                }

                Show();
                break;
            case "9":
                Environment.Exit(0);
                break;
            default:
                Show();
                break;
        }
    }
}
