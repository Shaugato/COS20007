using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IdentifiableObject
{
    public class InventoryUnitTest
    {
        private Inventory inventory;
        private Item item;
        // private string[] items;
        [SetUp]
        public void Setup()
        {
            //private string[] items;
            inventory = new Inventory();
            string[] items = { "Desolate Halverd" };
            item = new Item(items, "Halverd", "Cut through heaven and earth");
        }

        [Test]
        public void FindItemTest()
        {
            inventory.Put(item);
            Assert.True(inventory.HasItem("Desolate Halverd"));
        }
        [Test]
        public void FindNoItemTest()
        {
            inventory.Put(item);
            Assert.False(inventory.HasItem("Chaos Sword"));
        }
        [Test]
        public void TestFetchItem()
        {
            inventory.Put(item);
            Assert.That(inventory.Fetch("Desolate Halverd"), Is.EqualTo(item));
        }
        [Test]
        public void TakeItemTest()
        {
            inventory.Put(item);
            inventory.Take("Desolate Halverd");
            Assert.False(inventory.HasItem("Desolate Halverd"));
        }
        [Test]
        public void TestitemList()
        {
            string[] identsSword = { "Sword", "Fire Sword", "Cold Sword" };
            Item weapon = new Item(identsSword,
                "Fire Breathing Sword",
                "Burns whereever it slash through"
            );

            string[] identArmour = { "Armour", "Divine Armour", "Heavy Armour" };
            Item armour = new Item(identArmour,
                "Tier 10 Epic Armour",
                "Tier 6  Epic Armour"
            );

            string[] identsConsumables = { "Food", "Consumable", "Health Regeneration" };
            Item food = new Item(identsConsumables,
                "Kiwifruit Pie",
                "Heals Player on consumption for 2000 hp over 12 seconds"
            );

            inventory.Put(weapon);
            inventory.Put(armour);
            inventory.Put(food);

            string expected = "\tFire Breathing Sword (sword)\n\tTier 10 Epic Armour (armour)\n\tKiwifruit Pie (food)\n";

            Assert.That(inventory.ItemList, Is.EqualTo(expected));



          
        }
    }
}
