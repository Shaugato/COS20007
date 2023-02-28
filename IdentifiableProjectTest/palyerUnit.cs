using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  NUnit.Framework;

namespace IdentifiableObject
{
    public class palyerUnit
    {
        private Player _player;
        private Item _weapon;
        private Item _armour;
        private Item _food;
        Location location;

        [SetUp]
        public void Setup()
        {
            location = new("Warzone", "A place where a lots of battle took place", new string[] { "Locate", "room", "class" });
            _player = new Player("Long Chen", "Enchanting Evildoor",location);
            _weapon = new Item(new string[] { "Sword", "Fire Sword" }, "Fire Breathing Sword", "One Slash Can cut through the sky");
            _armour = new Item(new string[] { "Armour", "Divine Armour" }, "Level 10 epic armour", "Under the sait level , it's defence is invincible");
            _food = new Item(new string[] { "Food", "Five Coloured apple" }, "Immortal level Fruit", "Eating it,mortal can break through the sait level in one swoop");
            _player.Inventory.Put(_weapon);
            _player.Inventory.Put(_armour);
            _player.Inventory.Put(_food);
        }

        [Test]
        public void IndetifyPlayerTest()
        {
            Assert.True(_player.AreYou("me"));
            Assert.True(_player.AreYou("inventory"));
        }
        [Test]
        public void testplayerLocateItems()
        {
            //Assert.That(_player.Locate(_food.FirstId), Is.SameAs(_food));
            //Assert.That(_player.Locate(_armour.FirstId), Is.SameAs(_armour));
            //  Assert.That(_player.Locate(_weapon.FirstId), Is.SameAs(_weapon));
            GameObject expected = _weapon;
            GameObject actual = _player.Locate(_weapon.FirstId);
            Assert.That(actual, Is.EqualTo(expected), "Test Player can locate items within their inventory");


        }
        [Test]

        public void testLocatePlayerItself()
        {
            Assert.That(_player.Locate("me"), Is.SameAs(_player));

        }
        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.That(_player.Locate("fail"), Is.EqualTo(null));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.That(
                _player.FullDescription, Is.EqualTo("You are Long Chen Enchanting Evildoor\nYou are carrying:\n\tFire Breathing Sword (sword)\n\tLevel 10 epic armour (armour)\n\tImmortal level Fruit (food)\n"));
        }

        [Test]
        public void TestPlayerName()
        {
            Assert.That(_player.Name, Is.EqualTo("Long Chen"));
        }
    }
}
