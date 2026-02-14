using System;
using System.Collections.Generic;

// Базовий клас
public class Artifact
{
    public string Name { get; set; }

    public Artifact(string name)
    {
        Name = name;
    }

    // Virtual для підтримки поліморфізму
    public virtual void Describe()
    {
        Console.WriteLine($"Артефакт: {Name}");
    }
}

// Похідний клас 1
public class AncientSword : Artifact
{
    public int Damage { get; set; }

    public AncientSword(string name, int damage) : base(name)
    {
        Damage = damage;
    }

    // Перевизначення методу
    public override void Describe()
    {
        Console.WriteLine($"Древній меч '{Name}' завдає {Damage} одиниць шкоди.");
    }
}

// Похідний клас 2
public class MagicScroll : Artifact
{
    public string Spell { get; set; }

    public MagicScroll(string name, string spell) : base(name)
    {
        Spell = spell;
    }

    // Перевизначення методу
    public override void Describe()
    {
        Console.WriteLine($"Магічний сувій '{Name}' містить заклинання: {Spell}.");
    }
}

// Точка входу
class Program
{
    static void Main()
    {
        List<Artifact> inventory = new List<Artifact>
        {
            new AncientSword("Екскалібур", 100),
            new MagicScroll("Скрижалі Вогню", "Fireball"),
            new Artifact("Стародавній камінь")
        };

        Console.WriteLine("Інвентаризація артефактів:\n");

        foreach (Artifact item in inventory)
        {
            item.Describe();  // Динамічне зв’язування
        }
    }
}
