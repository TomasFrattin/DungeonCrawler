public class Player
{
    public string? Name { get; set; }
    public int MaxHealth { get; set; } = 100;
    public int Health { get; set; } = 3;
    public int Attack { get; set; } = 10;

    // public  int Defense { get; set; } = 5;
    public int Gold { get; set; } = 0;
    // public  int Experience { get; set; } = 0;
    // public  int Level { get; set; } = 1;
    // public  int ExperienceToNextLevel { get; set; } = 100;
    // public  int Potions { get; set; } = 0;
    // public  int Keys { get; set; } = 0;
    public void Heal(int amount)
    {
        Health = Math.Min(Health + amount, MaxHealth);
        Utils.WriteSlowly("El descanso te ha devuelto parte de tus fuerzas. ");

        Console.ForegroundColor = ConsoleColor.Green;
        Utils.WriteSlowly($"Has recuperado {amount} puntos de vida. Vida actual: {Health}/{MaxHealth}\n");

        Console.ResetColor();
    }
}