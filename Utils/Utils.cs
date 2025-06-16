using System.Text.Json;
using System.IO;

public static class Utils
{

    public static readonly Random Random = new();
    public static T GetRandom<T>(List<T> list)
    {
        return list[Random.Next(list.Count)];
    }

    public static void WriteSlowly(string texto)
    {
        int positionPoints = texto.IndexOf("...");
        for (int i = 0; i < texto.Length; i++)
        {
            Console.Write(texto[i]);

            if (positionPoints != -1 && i >= positionPoints && i < positionPoints + 3)
                Thread.Sleep(300);
            else
                Thread.Sleep(10);
        }
        Console.WriteLine();
    }

    public static string ReadOption(params string[] validOptions)
    {
        while (true)
        {
            string? input = Console.ReadLine()?.Trim();

            if (input != null && validOptions.Contains(input))
            {
                return input;
            }
            else
            {
                ClearLastLines(1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Por favor, ingresa una opción: ");
                Console.ResetColor();
            }
        }
    }

    public static void ClearLastLines(int lineCount)
    {
        for (int i = 0; i < lineCount; i++)
        {
            if (Console.CursorTop == 0) break;

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }

    public static class EnemyFactory
    {
        public static Enemy GenerateRandomEnemy()
        {
            var types = new List<Enemy>
            {
                new Enemy("Goblin", 30, 5),
                new Enemy("Esqueleto", 25, 6),
                new Enemy("Araña gigante", 20, 4),
                new Enemy("Orco", 40, 8)
            };

            return Utils.GetRandom(types);
        }
    }

    public static void PlaceHolder()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        WriteSlowly("\nPresiona una tecla para continuar...");
        Console.ResetColor();
        Console.ReadKey(true);
        Console.Clear();
    }



    public static class SaveSystem
    {
        private static readonly string savePath = "player_save.json";

        public static void SavePlayer(Player player)
        {
            string json = JsonSerializer.Serialize(player);
            File.WriteAllText(savePath, json);
        }

        public static Player? LoadPlayer()
        {
            if (!File.Exists(savePath))
                return null;

            string json = File.ReadAllText(savePath);
            return JsonSerializer.Deserialize<Player>(json);
        }

        public static void DeleteSave()
        {
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }
        }

    }


}
