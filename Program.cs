
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

    while (battleHasStarted == true)
    {
        var battlePress = Console.ReadKey(true);

        if (battlePress.Key == ConsoleKey.A)
        { 
            Console.WriteLine("bang bang");
        }

        else if (battlePress.Key == ConsoleKey.Q)
        {
            Console.WriteLine("No fight.");
            return;
        }
       
    }    
}
    
/* while (true)
{
    var touchPress = Console.ReadKey(true);
    
    if (touchPress.Key == ConsoleKey.A)
    { 
        Console.WriteLine("LET'S THE BATTLE BEGINS !!");
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
 */
 
 