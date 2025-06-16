using System.Resources;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

public static class Events
{
    public static void EmptyRoom(Player player)
    {
        Console.Clear();

        Utils.WriteSlowly(Utils.GetRandom(Texts.EmptyRoomDescriptions));

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nQué deseas hacer?\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Avanzar por el pasillo.");
        Console.WriteLine("2. Descansar un momento.");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nPor favor, ingresa una opción: ");
        Console.ResetColor();

        string choice = Utils.ReadOption("1", "2");

        if (choice == "1")
        {
            Console.Clear();
            Utils.WriteSlowly("Sientes que no necesitas descansar por el momento y decides salir a explorar los pasillos de la inmensa mazmorra.\n");

        }
        else if (choice == "2")
        {
            Console.Clear();
            Utils.WriteSlowly(Utils.GetRandom(Texts.ShortRestDescriptions));
            int dice = Utils.Random.Next(1, 5);

            player.Heal(dice);
        }
    }

    public static void CreatureEncounter(Player player)
    {
        Console.Clear();

        Enemy enemigo = Utils.EnemyFactory.GenerateRandomEnemy();

        Utils.WriteSlowly(Utils.GetRandom(Texts.CreatureEncounterDescriptions));
        Utils.WriteSlowly($"\n¡Un {enemigo.Name} aparece!");
        Utils.PlaceHolder();

        while (enemigo.Health > 0 && player.Health > 0)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Utils.WriteSlowly($"Tu vida: {player.Health}/{player.MaxHealth} | Vida del {enemigo.Name}: {enemigo.Health}\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Qué deseas hacer?\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Huir");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPor favor, ingresa una opción: ");
            Console.ResetColor();

            string turnoChoice = Utils.ReadOption("1", "2");

            if (turnoChoice == "1")
            {
                enemigo.Health -= player.Attack;

                Utils.WriteSlowly($"\nAtacas al {enemigo.Name} y le haces... {player.Attack} de daño. Vida enemiga: {Math.Max(enemigo.Health, 0)}");

                if (enemigo.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Utils.WriteSlowly($"\nLuego del último golpe, el {enemigo.Name} cae ante tus pies!");
                    Console.ResetColor();
                    Utils.WriteSlowly($"\nEntre sus restos encuentras...");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    int coins = Utils.Random.Next(1, 5);
                    Utils.WriteSlowly($"\t{coins} monedas de oro.");
                    player.Gold += coins;

                    Console.ResetColor();
                    Utils.WriteSlowly("\nPiensas en los que perecieron a manos de esta criatura y sientes que has hecho justicia.");
                    Utils.PlaceHolder();
                    break;
                }
            }
            else if (turnoChoice == "2")
            {
                int escapeChance = Utils.Random.Next(100);
                Utils.WriteSlowly("\nIntentas huir...\n");
                if (escapeChance < 70)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Utils.WriteSlowly("Has logrado huir con éxito.");
                    Utils.PlaceHolder();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Utils.WriteSlowly("Intentaste huir pero fallaste.\n");
                    Console.ResetColor();
                }
            }

            // Turno del enemigo
            player.Health -= enemigo.Attack;

            Utils.WriteSlowly($"El {enemigo.Name} te ataca y te hace... {enemigo.Attack} de daño. Tu vida: {Math.Max(player.Health, 0)}/{player.MaxHealth}");

            if (player.Health <= 0)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Utils.WriteSlowly("¡Has caído en combate!");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Utils.WriteSlowly("\nPierdes parte de tu oro pero vuelves a levantarte.\n");

                Console.ResetColor();

                player.Health = player.MaxHealth;

                int goldLost = player.Gold / 2;
                player.Gold -= goldLost;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Utils.WriteSlowly($"Has perdido {goldLost} monedas de oro.");
                Console.ResetColor();

                Utils.PlaceHolder();

                break;
            }

            Utils.PlaceHolder();
        }
    }

    public static void ChestRoom()
    {
        Console.Clear();

        Console.WriteLine(Utils.GetRandom(Texts.ChestFoundDescriptions));
        Console.ReadKey(true);
    }


    public static void ItemFound()
    {
        Console.Clear();

        Console.WriteLine(Utils.GetRandom(Texts.ItemFoundDescriptions));
        Console.ReadKey(true);
    }

}