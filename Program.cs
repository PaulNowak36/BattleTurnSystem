
int order; 
bool battleHasStarted = false;

Beginning();

void Beginning()
{
    Console.WriteLine("Press the A key to start the battle.");

    while (battleHasStarted == false)
    {
        var touchPress = Console.ReadKey(true);

        if (touchPress.Key == ConsoleKey.A)
        { 
            battleHasStarted = true;
            Console.Clear();
            BattleMode();
        }

        else if (touchPress.Key == ConsoleKey.Q)
        {
            Console.WriteLine("No fight.");
            return;
        }

        else
        {
            Console.WriteLine("FIGHT !");
            
        }    
    }
  
} 



void BattleMode()
{
    Console.WriteLine("LET'S THE BATTLE BEGINS !!");

    Console.WriteLine("Dude 1 VS Dude 2");

    order = 1;

    while (battleHasStarted == true)
    {
        

        if (order == 1)
        {
            Console.WriteLine("Dude 1's turn !");
            var battlePress = Console.ReadKey(true);

            if (battlePress.Key == ConsoleKey.A && order == 1)
            { 
                Console.Clear();
                Console.WriteLine("Dude 1 attack Dude 2!");
                Thread.Sleep(1000);
                Console.WriteLine("Dude 2 is hurt !");
                order = 2;
                Console.Clear();
            }

            else if (battlePress.Key == ConsoleKey.Q && order == 1)
            {
                Console.WriteLine("No fight.");
                return;
            }

            else
            {
                Console.Clear();
            }
        }

        if (order == 2)
        {
            Console.WriteLine("Dude 2's turn !");
            var battlePress = Console.ReadKey(true);

            if (battlePress.Key == ConsoleKey.A && order == 2)
            { 
                Console.Clear();
                Console.WriteLine("Dude 2 attack Dude 1!");
                Thread.Sleep(1000);
                Console.WriteLine("Dude 1 is hurt !");
                order = 1;
                Console.Clear();
            }

            else if (battlePress.Key == ConsoleKey.Q && order == 2)
            {
                Console.WriteLine("No fight.");
                return;
            }

            else
            {
                Console.Clear();
            }
        }

        
       
    }    
}
    

 