using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IdentifiableObject
{
    public class ItemUnitTest
    {
        private Item Itemobject;
       // private string[] idents;
        [SetUp]
        public void setup()
        {
            //idents = new[] { "Long Aoitioan", "Chaos Sword" };
            Itemobject = new Item(new string[] { "Long Aoitioan", "Chaos Sword" }, "Enchainting Evildoor", "Long Aoitian is a peerless evildoor, owner of the chaos oveload sowrd" );
        }
        [Test]
        public void TestIdentifiable()
        {
            Assert.True(Itemobject.AreYou(id: "Long Aoitioan"));
        }
        [Test]
        public void shortDescriptionTest()
        {
            Assert.That(Itemobject.ShortDescription, Is.EqualTo("Enchainting Evildoor (long aoitioan)"));
        }
        [Test]
        public void FullDescriptionTest()
        {
            Assert.That(Itemobject.FullDescription, Is.EqualTo("Long Aoitian is a peerless evildoor, owner of the chaos oveload sowrd"));
        }








    }
}
