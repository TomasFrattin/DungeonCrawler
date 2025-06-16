public static class Game
{
    public static void StartExploration(Player player)
    {
        Console.Clear();
        Random random = new Random();

        Utils.WriteSlowly(Utils.GetRandom(Texts.DoorDescriptions));
        Console.WriteLine();
        
        do
        {
            Utils.SaveSystem.SavePlayer(player);
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Qué deseas hacer?\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Avanzar por el pasillo.");
            Console.WriteLine("9. Abandonar la excursión.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPor favor, ingresa una opción: ");
            Console.ResetColor();

            string choice = Utils.ReadOption("1", "9");

            if (choice == "1")
            {
                int dice = random.Next(1, 3); // 1 a 4 para los casos

                switch (dice)
                {
                    case 1:
                        Events.EmptyRoom(player);
                        break;
                    case 2:
                        Events.CreatureEncounter(player);
                        break;
                    case 3:
                        Events.ChestRoom();
                        break;
                    case 4:
                        Events.ItemFound();
                        break;
                }
            }
            else if (choice == "9")
            {
                Menu.Show();
                break;
            }
        } while (true);
    }
}
