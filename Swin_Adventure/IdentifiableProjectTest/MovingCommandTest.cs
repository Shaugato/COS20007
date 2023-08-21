using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IdentifiableObject
{
    public class MovingCommandTest
    {
        private Move_Command _command;
        Player player;
        Location location1;
        Location location2;
        Path path;

        [SetUp]

        public void SetUp()
        {
            _command = new Move_Command();
            location1 = new Location("Burial Ground", "Going to east where Countless soilder died on this battleground", new string[] { "Battleground" });
            location2 = new Location("Holy Land", "Going West to th eholy land of cultivator's dream ", new string[] { "Cultivation Place" });

            player = new Player("Long Chen ", "An Enchanting EvilDoor", location1);
            path = new Path(new string[] { "East", "West", "North" }, "Path", "A waking path for going this direction", location1, location2);
        }

        [Test]

        public void TestingMoveOnPlayer()
        {
            player.Location = location1;
            location1.AddToPath(path);
            _command.Execute(player, new string[] { "move", "East" });
            Assert.AreEqual(location2.Name, player.Location.Name);
        }
        [Test]
        public void PlayerCanLeaveCurrentPosition()
        {
            player.Location = location1;
            location1.AddToPath(path);
            Assert.AreEqual(location1.Name, player.Location.Name);
            _command.Execute(player, new string[] { "move", "to", "East" });
            Assert.AreNotEqual(location1.Name, player.Location.Name);
        }
        [Test]
        public void LocationRemainsSameForInvldCommand()
        {
            player.Location = location1;
            location1.AddToPath(path);
            Assert.AreEqual(location1.Name, player.Location.Name);
            _command.Execute(player, new string[] { "move" });
            Assert.AreNotEqual(location2.Name, player.Location.Name);
            Assert.AreEqual("Move where?", _command.Execute(player, new string[] { "move" }));
        }
    }
}
