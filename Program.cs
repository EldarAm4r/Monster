using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMonster
{
    internal class Program
    {
        class MyMonster
        {
            private string name;
            private int power;
            private int health;

            public MyMonster(string name, int power, int health)
            {
                this.name = name;
                this.power = power;
                this.health = health;
            }

            public string GetName() { return name; }
            public int GetPower() { return power; }
            public int GetHealth() { return health; }

            public bool IsAlive() { return health > 0; }
            public int Attack() { return power; }
            public void TakeDamage(int damage)
            {
                health = health - damage;
                if (health < 0)
                {
                    health = 0;
                }
            }
            public void Heal(int points) { health = health + points; }
            public void PowerUp(int extraPower) { power = power + extraPower; }
            public void Roar()
            {
                Console.WriteLine(name + " ROARS!!!");
                int[] sounds = { 300, 360, 420, 500, 420, 360, 280 };
                int[] times = { 120, 120, 150, 220, 150, 120, 250 };
                for (int i = 0; i < sounds.Length; i++)
                {
                    Console.Beep(sounds[i], times[i]);
                }
            }

            public void ShowMonster()
            {
                Console.WriteLine("#########");
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Power: " + power);
                Console.WriteLine("Health: " + health);
                if (IsAlive())
                    Console.WriteLine("Status: Alive");
                else Console.WriteLine("Status: Dead");
                Console.WriteLine("##########");
            }
        }
        static void Main(string[] args)
        {
            MyMonster[] arena = new MyMonster[5];
            arena[0] = new MyMonster("Drako", 95, 80);
            arena[1] = new MyMonster("Zilla", 70, 55);
            arena[2] = new MyMonster("Blaze", 88, 90);
            arena[3] = new MyMonster("Fang", 60, 40);
            arena[4] = new MyMonster("Titan", 99, 100);

            Console.WriteLine("All Monsters in Arena"); // משימה 1
            for (int i = 0; i < arena.Length; i++)
            {
                arena[i].ShowMonster();
            }

            int alive = 0; // משימה 2
            for (int i = 0; i < arena.Length; i++)
            {
                if (arena[i].IsAlive())
                {
                    alive++;
                }
            }

            MyMonster strongest = arena[0]; // משימה 3
            for (int i = 0; i < arena.Length; i++)
            {
                if (arena[i].GetPower() > strongest.GetPower())
                    strongest = arena[i];
            }
            Console.WriteLine("The strongest monster is: " + strongest.GetName() + " Power: " + strongest.GetPower());

            Console.WriteLine("Everyone takes 20 damage"); // משימה 4
            for (int i = 0; i < arena.Length; i++)
            {
                arena[i].TakeDamage(20);
                arena[i].ShowMonster();
            }

            Console.WriteLine("Moster Monsters with less than 60 HP: "); // משימה 5
            for (int i = 0; i < arena.Length; i++)
            {
                if (arena[i].GetHealth() < 60)
                {
                    Console.WriteLine(arena[i].GetName());
                }
            }

            Console.WriteLine("Powering up weak monsters"); // בונוס
            for (int i = 0; i < arena.Length; i++)
            {
                if (arena[i].GetPower() < 80)
                {
                    arena[i].PowerUp(10);
                }
            }
            Console.WriteLine("All monsters after Power Up: ");
            for (int i = 0; i < arena.Length; i++)
            {
                arena[i].ShowMonster();
            }
        }
    }
}
