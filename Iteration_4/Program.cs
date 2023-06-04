using System;

namespace Iteration_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Console.WriteLine("Hello !!!! A very good welcome to this amazing game!!!!");
            Console.WriteLine("First, Plesase enter your name to continue your journey");
            string playerName = Console.ReadLine();
            Console.WriteLine("Sencondly , Tell how do you want to describe yourself");
            string playerDescription = Console.ReadLine();
            Console.WriteLine("Now  " + playerName + "who is  " + playerDescription + "start your amazing zourney");

            Player player = new Player(playerName, playerDescription);
            Bag bag = new Bag(new string[] { "level1Bag", "Level2Bag", "Bag" }, "bag", "Diffrent level tell how much the bag can carry ,It can help a player to carry items");
            Item gem = new Item(new string[] { "ruby" }, "gem", "Ruby costs of  gold coins");
            Item sword = new Item(new string[] { "Excalibur" }, "sword", "A Holy sword can suppress all other sords");
            Item shield = new Item(new string[] { "Turtle_Sheild" }, "shield", "A shield is very useful in a game. So be sure to carry it");

            player.Inventory.Put(sword);
            player.Inventory.Put(shield);
            player.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            Command lookCommand = new LookCommand();

            while (true)
            {
                Console.Write("Enter what you wish to do or see ");
                Console.WriteLine("------------------------");
                userInput = Console.ReadLine();
                if (userInput.ToLower() != "quit")
                {
                    Console.WriteLine(lookCommand.Execute(player, userInput.Split()));
                }
                else
                {
                    Console.WriteLine("Quiting the game...");
                    break;
                }
            }
        }
    }
}
