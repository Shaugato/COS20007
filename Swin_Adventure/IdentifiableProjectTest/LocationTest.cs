using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentifiableObject;
using NUnit.Framework;

namespace IdentifiableObject
{
    public class LocationTest
    {
        Location location;
        Player player;
        Item _weapon;

        [SetUp]

        public void SetUp()
        {
            player = new Player("Long Chen", "Enchanting evildoor", location);
            location = new("Warzone", "A place where a lots of battle took place", new string[] { "Locate", "room", "class" });
            _weapon = new Item(new string[] { "Sword", "Fire Sword" }, "Fire Breathing Sword", "One Slash Can cut through the sky");
        }

        [Test]

        public void TestPlayerCanLocatelocation()
        {
            //player = new Player("Long Chen", "Enchanting evildoor");
            //location = new("Warzone","A place where a lots of battle took place", new string[] {"Locate", "room", "class"});

            player.Location = location;
            bool actual = location.AreYou("Locate");
            Assert.IsTrue(actual, "Test Locate can identify itself as 'Locate'");
        }

        [Test]

        public void TestPlayerhasLocation()
        {
            player.Location = location;
            GameObject needToget = location;
            GameObject willGet = player.Locate("room");
            Assert.AreEqual(needToget, willGet, " Test if the player can locate their location using Locate command");

        }

        [Test]
        public void TestLocationIdentifyItems()
        {
            location.Inventory.Put(_weapon);
            GameObject needToget = _weapon;
            GameObject willGet = location.Locate("sword");

            Assert.AreEqual(needToget, willGet, "Test Location can identify itself as 'location'");



        }
    }
}
