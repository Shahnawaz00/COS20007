using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestPlayer
    {
        Player player;
        Item sword;
        Location location;
        Item gem;

        [SetUp]
        public void Setup()
        {
            player = new Player("shah", "the student");
            sword = new Item(new string[] { "Sword" }, "a bronze sword", "This is a bronze sword");
            player.Inventory.Put(sword);

            gem = new Item(new string[] { "gem" }, "a gem", "a bright red crystal");
            location = new Location("garden", "This is a garden");
            location.Inventory.Put(gem);

            player.Location = location;
        }

        [Test]
        public void TestIsIdentifiable()
        {
            Assert.That(player.AreYou("me"), Is.True);
            Assert.That(player.AreYou("inventory"), Is.True);
        }

        [Test]
        public void TestLocateItems()
        {
            Assert.That(player.Locate("sword"), Is.SameAs(sword));
            Assert.That(player.Inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestLocateItself()
        {
            Assert.That(player.Locate("me"), Is.SameAs(player));
            Assert.That(player.Locate("inventory"), Is.SameAs(player));
        }

        [Test]
        public void TestLocateNothing()
        {
            Assert.That(player.Locate("scythe"), Is.SameAs(null));
        }

        [Test]
        public void TestLocateLocation()
        {
            Assert.That(player.Locate("room"), Is.SameAs(location));
        }

        [Test] 
        public void TestLocateItemInLocation()
        {
            Assert.That(player.Locate("gem"), Is.SameAs(gem));
        }
        [Test]
        public void TestFullDescription()
        {
            Assert.That(player.FullDescription,
                Is.EqualTo("You are shah, the student.\nYou are carrying:\na bronze sword (sword)\n"));
        }
    }
}
