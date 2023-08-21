using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentifiableObject;
using NUnit.Framework;

namespace IdentifiableObject
{
    public class TestPath
    {

        Player player;
        Location location1;
        Location location2;
        Path path;


        [SetUp]

        public void SetUp()
        {
            location1 = new Location("Burial Ground", "Going to east where Countless soilder died on this battleground", new string[] { "Battleground" });
            location2 = new Location("Holy Land", "Going West to th eholy land of cultivator's dream ", new string[] { "Cultivation Place" });

            player = new Player("Long Chen ", "An Enchanting EvilDoor", location1);
            path = new Path(new string[] { "East", "West", "North" }, "Path", "A waking path for going this direction", location1, location2);
        }

        [Test]

        public void TestpathName()
        {
            player.Location = location1;
            location1.AddToPath(path);
            Assert.AreEqual("A waking path for going this direction", path.FullDescription);
        }

        [Test]

        public void testingPathLocation()
        {
            player.Location = location1;
            location1.AddToPath(path);
            Assert.That(path.Destination, Is.EqualTo(location2));
        }

        [Test]

        public void TestingLocatePath()
        {
            player.Location = location1;
            location1.AddToPath(path);
            Assert.AreEqual(location1.Locate("East"), path);
        }
    }
}
