using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestLocation
    {
        //initialize variables
        Location location;
        Player player;
        Item sword;

        [SetUp]
        public void Setup ()
        {
            
            location = new Location ("a garden", "This is a garden");
            player = new Player("shah", "the student");
            sword = new Item(new string[] { "Sword" }, "a bronze sword", "This is a bronze sword");

            // add item to location, and set player's location
            location.Inventory.Put(sword);
            player.Location = location;
        }

        // test if location can identify itself
        [Test]  
        public void TestIdentifyLocation ()
        {
            Assert.That(location.Locate("room"), Is.SameAs(location));
        }

        //test if location can identify an item in its inventory
        [Test]
        public void TestIdentifyItemsInLocation ()
        {
            Assert.That(location.Locate("sword"), Is.SameAs(sword));
        }

        // test that player can locate an item in its location
        [Test]
        public void TestIdentifyItemsInPlayerLocation()
        {
            Assert.That(player.Locate("sword"), Is.SameAs(sword));
        }

        //test location's full description
        [Test]
        public void TestLocationFullDescription()
        {
            string actual = location.FullDescription;
            string expected = "You are in a garden\nThis is a garden\nIn this room you can see:\na bronze sword (sword)\n";

            Assert.That (actual, Is.EqualTo(expected));
        }
    }
}
