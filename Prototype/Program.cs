public interface IPrototype<T>
{
    T Clone();
}
public class Enemy : IPrototype<Enemy>
{
    public string Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Enemy Clone()
    {
        return new Enemy
        {
            Type = this.Type,
            Health = this.Health,
            Damage = this.Damage
        };
    }
}
public class Program
{

    static void Main(string[] args)
    {
        //when making new instance is expensive but copy is cheap
        var zombiePrototype = new Enemy
        {
            Type = "Zombie",
            Health = 100,
            Damage = 10
        };
        var zombie1 = zombiePrototype.Clone();
        var zombie2 = zombiePrototype.Clone();
        zombie2.Health = 150;
    }
}




