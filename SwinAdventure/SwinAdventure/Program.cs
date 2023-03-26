namespace SwinAdventure
{
    class MainClass
    {
        
        public static void Main(string[] args)
        {
            //local variables
            string name;
            string desc;
            Player player;

            //setting up player
            Console.WriteLine("Enter player name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter player description:");
            desc = Console.ReadLine();

            player = new Player(name, desc);

            //setting up items and inventory
            Item sword = new Item(new string[] { "Sword" }, "a bronze sword", "This is a bronze sword");
            Item bat = new Item(new string[] { "Bat" }, "a hard bat", "This is a hard bat");
            Item gem = new Item(new string[] { "gem" }, "a gem", "a bright red crystal");

            Bag bag = new Bag(new string[] { "bag" }, "bag", "This is a good bag");

            player.Inventory.Put(sword);
            player.Inventory.Put(bat);  
            player.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            // setting up location 
            Item key = new Item(new string[] { "key" }, "a key", "This is a key");
            Location hallway = new Location("the hallway", "This is the main hallway");
            
            hallway.Inventory.Put(key);
            player.Location = hallway;

            // command loop
            bool quit = false;
            string cmd;
            LookCommand look = new LookCommand();

            while (!quit)
            {
                Console.WriteLine("\nCommand:");
                cmd = Console.ReadLine();

                if (cmd == "quit")
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine(look.Execute(player, cmd.ToLower().Split()));
                }
            }
        }
    }
}