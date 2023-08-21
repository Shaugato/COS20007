using System;

namespace IdentifiableObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!!! Welcome To SwinAdventure!!");
            Console.WriteLine("Enter your palyer name");
            string name = Console.ReadLine();
            Console.WriteLine("enter yourplayer description");
            string descreiption = Console.ReadLine();
            //Console.WriteLine("enter player location");
            Location location = new("Warzone", "A place where a lots of battle took place", new string[] { "Locate", "room", "class" });
            Player P = new Player(name, descreiption, location);
            Item _weapon = new Item(new string[] { "Sword", "Fire Sword" }, "Fire Breathing Sword", "One Slash Can cut through the sky");
            Item _armour = new Item(new string[] { "Armour", "Divine Armour" }, "Level 10 epic armour", "Under the sait level , it's defence is invincible");
            Item _food = new Item(new string[] { "Food", "Five Coloured apple" }, "Immortal level Fruit", "Eating it,mortal can break through the sait level in one swoop");

            Item _elixer = new Item(new string[] { "Elixer", "Immortal Elixer" }, "Gain Immortality", "By eating it people can be immortal");

            Location warZone = new Location("Battleground for youngster\n", "A place where countless youngster fight for their hegemony", new string[] { "battleground" });
            Location deathZone = new Location("Burial Ground\n", "Going to east where Countless soilder died on this battleground", new string[] { "deathZone" });
            Location cultivationZone = new Location("Holy Land\n", "Going West to th eholy land of cultivator's dream ", new string[] { "Cultivation Place" });

            Path CultivatonZoneToWarzone = new Path(new string[] { "East" }, "Going East\n", "Moving towards WarZone", cultivationZone, warZone);
            Path WarZoneToDeathZone = new Path(new string[] { "West" }, "Going West\n", "Going DeathZone From WarZone", warZone, deathZone);
            Path DeathZoneToCultivationZone = new Path(new string[] { "North", "South" }, "Going North or South\n", "Going Cultivation Zone from deathZone", deathZone, cultivationZone);
            // Path CultivationZoneToDeathZone = new Path(new string[] { "South" }, "Going South\n", "Going warZone from CultivationZone", cultivationZone , deathZone);

            cultivationZone.Inventory.Put(_elixer);
            warZone.Inventory.Put(_weapon);
            deathZone.Inventory.Put(_armour);
            P.Location = cultivationZone;
            P.Inventory.Put(_elixer);

            //cultivationZone.AddToPath(CultivationZoneToDeathZone);
            cultivationZone.AddToPath(CultivatonZoneToWarzone);
            warZone.AddToPath(WarZoneToDeathZone);
            deathZone.AddToPath(DeathZoneToCultivationZone);

            warZone.Inventory.Put(_elixer);
            deathZone.Inventory.Put(_elixer);



            P.Inventory.Put(_weapon);
            P.Inventory.Put(_armour);
            Bag _bag = new Bag(new string[] { "bag" }, "qinhai bag", "A bag which has unimaginable space");
            P.Inventory.Put(_bag);

            _bag.Inventory.Put(_food);

            //Command_Processor command = new Command_Processor();
            Console.WriteLine("Type 'quit' or 'exit' to exit.");
            string[] commands = new[] { "" };

            while (commands[0] != "quit")
            {
                // LookCommand look = new LookCommand();
                Command_Processor command_Line = new Command_Processor();
                Console.WriteLine("");
                Console.WriteLine("Put Your Command --- > ");
                Console.WriteLine("");
                string command = Console.ReadLine();
                commands = command.Split(" ");
                Console.Write(command_Line.Execute(P, commands));
            }
        }
    }
}
