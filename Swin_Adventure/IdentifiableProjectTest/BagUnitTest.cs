using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class BagUnitTest
    {
        private Bag _bag;
        // private Bag _bag;
        private Bag _bagBag;
        private Item _weapon;
        private Item _armour;
        private Item _food;
        private Item _gem;

        [SetUp]
        public void Setup()
        {
            _bag = new Bag(new string[] { "bag", "bagpack" }, "qinhai bag", "A bag which has unimaginable space");
            _weapon = new Item(new string[] { "Sword", "Fire Sword" }, "Fire Breathing Sword", "One Slash Can cut through the sky");
            _armour = new Item(new string[] { "Armour", "Divine Armour" }, "Level 10 epic armour", "Under the sait level , it's defence is invincible");
            _food = new Item(new string[] { "Food", "Five Coloured apple" }, "Immortal level Fruit", "Eating it,mortal can break through the sait level in one swoop");
            string[] identsBagBag = new[] { "Frostweave Bag" };
            _bagBag = new Bag(identsBagBag, "Frostweave Bag", "A magical bag from the Blood Elves.");
            string[] identsGem = { "Gem", "Enhancement" };
            _gem = new Item(identsGem,
                "Eye of Azeroth",
                "Doubles stamina in battlegrounds"
            );



        }
        [Test]
        public void TestBagLocateItems()
        {
            _bag.Inventory.Put(_weapon);
            Assert.That(_bag.Locate("Sword"), Is.EqualTo(_weapon));
            _bag.Inventory.Put(_armour);
            Assert.That(_bag.Locate("Armour"), Is.EqualTo(_armour));
            _bag.Inventory.Put(_food);
            Assert.AreEqual(_food, _bag.Locate("Food"));
        }
        [Test]
        public void BagLocatItself()
        {
            Assert.AreEqual(_bag, _bag.Locate("bag"));
        }
        [Test]
        public void TestBagLocateNothing()
        {
            Assert.AreEqual(null, _bag.Locate("gem"));
        }
        [Test]
        public void TestBagFullDescription()
        {
            _bag.Inventory.Put(_weapon);
            _bag.Inventory.Put(_armour);
            _bag.Inventory.Put(_food);
            Assert.AreEqual(
              $"In the qinhai bag you can see:\n\tFire Breathing Sword (sword)\n\tLevel 10 epic armour (armour)\n\tImmortal level Fruit (food)\n",
              _bag.FullDescription);
        }
        [Test]
        public void TestBagInBag()
        {
            _bag.Inventory.Put(_bagBag);
            _bagBag.Inventory.Put(_gem);
            Assert.AreSame(_bagBag, _bag.Locate("Frostweave Bag"));
            Assert.AreSame(_gem, _bagBag.Locate("Gem"));
            Assert.AreSame(null, _bag.Locate("Gem"));
        }

    }
}
