public class Enemy
{
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }

    public Enemy(string name, int maxHealth, int attack)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Attack = attack;
    }

    public void TakeDamage(int amount)
    {
        Health = Math.Max(0, Health - amount);
    }

    public bool IsDead()
    {
        return Health <= 0;
    }
}
