using System;

namespace Assignment5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");
            
            Character hero = new Character("Bob", RaceCategory.Human, 100);
            Inventory PlayerInventory PlayerInventory = new Inventory(5);

            Console.WriteLine("{0} has entered the forest", hero.Name);

            string monster = "goblin";
            int damage = 10;

            Console.WriteLine("A {0} appeared and attacks {1}", monster, hero.Name);

            Console.WriteLine("{0} takes {1} damage", hero.Name, damage);

            hero.TakeDamage(damage);
            Console.WriteLine(hero);

            Console.WriteLine("{0} flees from the enemy", hero.Name);

            string item = "small health potion";
            int restoreAmount = 10;

            if(hero.Health > 0)
            {
                Console.WriteLine("{0} find a {1} and drinks it", hero.Name, item);

                Console.WriteLine("{0} restores {1} health", hero.Name, restoreAmount);

                hero.RestoreHealth(restoreAmount);
            }
            

            Console.WriteLine(hero);

            if (hero.IsAlive)
            {
                Console.WriteLine("Congratulations! {0} survived.", hero.Name);
            }
            else
            {
                Console.WriteLine("{0} has died.", hero.Name);
            }
            
            

            List_Items();

            Item itmSword = new Item("Wooden Sword", 1, ItemGroup.Equipment);

            Add_Item(itmSword);

            Add_Item(itmSword);

            Item itmBerry = new Item("Blue Berry", 1, ItemGroup.Consumable);

            Add_Item(itmBerry);

            Item itmCloth = new Item("Cloth", 1, ItemGroup.Consumable);

            Add_Item(itmCloth);


            Item itmKey = new Item("Rust key", 1, ItemGroup.Key);

            Add_Item(itmKey);

            Item itmKey2 = new Item("Rust key2", 1, ItemGroup.Key);

            Add_Item(itmKey2);

            // Add more item makes invalid
            Item itemApple = new Item("Apple", 1, ItemGroup.Consumable);

            Add_Item(itemApple);


            // Take existing item reduce amount
            if (PlayerInventory.TakeItem("Wooden Sword", out Item found))
            {
                Console.WriteLine(found.Name);
            }
            else
            {
                Console.WriteLine("Item doesnt exist.");
            }
            List_Items();

            // Take item with 1 amount
            if (PlayerInventory.TakeItem("Blue Berry", out Item found1))
            {
                Console.WriteLine(found1.Name);
            }
            else
            {
                Console.WriteLine("Item doesnt exist.");
            }
            List_Items();

            // Item doenst exist
            if (PlayerInventory.TakeItem("Apple", out Item found2))
            {
                Console.WriteLine(found2.Name);
            }
            else
            {
                Console.WriteLine("Item doesnt exist.");
            }
            List_Items();


            Console.WriteLine("Data has been reset.");
            PlayerInventory.Reset();
            List_Items();
        }

        static void List_Items()
        {
            foreach (Item listItem in PlayerInventory.ListAllItems())
            {
                Console.WriteLine(listItem.ToString());
            }

            Console.WriteLine($"Available Slots: {PlayerInventory.AvailableSlots.ToString()}");
            Console.WriteLine($"Max Slots: {PlayerInventory.MaxSlots.ToString()}");
        }

        static void Add_Item(Item itm)
        {
            if (!PlayerInventory.AddItem(itm)) Console.WriteLine("No more available slot.");
            List_Items();
        }
    }
}
