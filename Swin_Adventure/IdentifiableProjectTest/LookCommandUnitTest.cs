using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IdentifiableObject
{
    public class LookCommandUnitTest
    {
        private LookCommand _lookCommand;
        private Player _player;
        private Bag _bag;
        private Item _weapon;
        private Item _armour;
        private Item _food;
        private Item _gem;
        Location location;

        [SetUp]
        public void Setup()
        {
            _lookCommand = new LookCommand();
            location = new("Warzone", "A place where a lots of battle took place", new string[] { "Locate", "room", "class" });
            _player = new Player("Long Chen", "The Enchanting evildoor", location);
            _bag = new Bag(
                new string[] { "bag" },
                "qinhai bag", "A bag which has unimaginable space"
                );

            //string[] identsGun = { "Weapon", "BFG", "Rocket Launcher" };
            _weapon = new Item(new string[] { "Sword", "Fire Sword" }, "Fire Breathing Sword", "One Slash Can cut through the sky");

            //string[] identsArmour = { "Armour", "Platemail", "Heavy Armour" };
            _armour = new Item(new string[] { "Armour", "Divine Armour" }, "Level 10 epic armour", "Under the sait level , it's defence is invincible");

            // string[] identsConsumables = { "Food", "Consumable", "Health Regeneration" };
            _food = new Item(new string[] { "Food", "Five Coloured apple" }, "Immortal level Fruit", "Eating it,mortal can break through the sait level in one swoop");

            _gem = new Item(
                new string[] { "gem" },
                "Eye of Azeroth",
                "Enables smiting of Alliance scum regardless of PvP status."
            );
        }

        [Test]
        public void TestLookAtMe()
        {
            _player.Inventory.Put(_weapon);
            _player.Inventory.Put(_armour);
            _player.Inventory.Put(_food);
            _player.Inventory.Put(_gem);
            string[] input = new[] { "Look", "at", "inventory" };
            Assert.That(
                _lookCommand.Execute(_player, input), Is.EqualTo("You are Long Chen The Enchanting evildoor\nYou are carrying:\n\tFire Breathing Sword (sword)\n\tLevel 10 epic armour (armour)\n\tImmortal level Fruit (food)\n\tEye of Azeroth (gem)\n"));
        }

        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(_gem);
            string[] input = new[] { "Look", "at", "gem" };
            Assert.That(
                _lookCommand.Execute(_player, input), Is.EqualTo("Enables smiting of Alliance scum regardless of PvP status."));
        }

        [Test]
        public void TestLookAtUnk()
        {
            string[] input = new[] { "Look", "at", "gem" };
            Assert.That(
                _lookCommand.Execute(_player, input), Is.EqualTo("I can't find the gem"));
        }

        [Test]
        public void TestLookAtGemInMe()
        {

            _player.Inventory.Put(_gem);
            string[] input = new[] { "Look", "at", "gem", "in", "inventory" };
            Assert.That(
                _lookCommand.Execute(_player, input), Is.EqualTo("Enables smiting of Alliance scum regardless of PvP status."));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
            string[] input = new[] { "Look", "at", "gem", "in", "bag" };
            Assert.That(
                _lookCommand.Execute(_player, input), Is.EqualTo("Enables smiting of Alliance scum regardless of PvP status."));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            string[] input = new[] { "Look", "at", "gem", "in", "bag" };
            Assert.That(
                _lookCommand.Execute(_player, input), Is.EqualTo("I cannot find the bag\n"));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _player.Inventory.Put(_bag);
            string[] input = new[] { "Look", "at", "gem", "in", "bag" };
            Assert.That(
                _lookCommand.Execute(_player, input), Is.EqualTo("I can't find the gem"));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.That(
                _lookCommand.Execute(_player, new[] { "Look" }), Is.EqualTo("I don't know how to look like that\n"),
                "Length must be 3 or 5, not 1.");

            Assert.That(
                _lookCommand.Execute(_player, new[] { "Look", "around" }), Is.EqualTo("I don't know how to look like that\n"),
                "Length must be 3 or 5, not 2.");

            Assert.That(
                _lookCommand.Execute(_player, new[] { "Look", "around", "at", "fails" }), Is.EqualTo("I don't know how to look like that\n"),
                "Length must be 3 or 5, not 4.");

            Assert.That(
                _lookCommand.Execute(_player, new[] { "jump", "around", "hall", "still", "fails" }), Is.EqualTo("Error in look input\n"),
                "First word must be 'look'.");

            Assert.That(
                _lookCommand.Execute(_player, new[] { "jump", "around", "hall" }), Is.EqualTo("Error in look input\n"),
                "First word must be 'look'.");

            Assert.That(
                _lookCommand.Execute(_player, new[] { "Look", "around", "hall" }), Is.EqualTo("What do you want to look at\n"),
                "Second word must be 'at'.");

            Assert.That(
                _lookCommand.Execute(_player, new[] { "Look", "at", "sword", "towards", "bag" }), Is.EqualTo("What do you want to look in\n"),
                "4th word must be 'in'.");
        }
    }
}
