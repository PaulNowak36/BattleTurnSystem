

int order; 
bool battleHasStarted = false;
bool actionIsUsed = false;

string[] characters = {"Dude 1", "Dude 2"};

Beginning();

void Beginning()
{
    
    Text("Press the A key to start the battle.");

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
            QuitFight();
        }

        else
        {
            Nothing();
        }    
    }
  
} 



void BattleMode()

{
    
    Text("LET'S THE BATTLE BEGINS !!");
    Text($"{characters[0]} VS {characters[1]}");

    order = 1;
    actionIsUsed = false;

    while (battleHasStarted == true)
    {
        
        if (order == 1)
        {
            actionIsUsed = false;
            Text($"{characters[0]}'s turn !");
            var battlePress = Console.ReadKey(true);

            if (battlePress.Key == ConsoleKey.A && order == 1 && actionIsUsed == false)
            { 
                actionIsUsed = true;
                Console.Clear();
                Text($"{characters[0]} attack {characters[1]}!");
                Thread.Sleep(1000);
                Text($"{characters[1]} is hurt !");
                OrderSwitch();
                Console.Clear();
            }

            else if (battlePress.Key == ConsoleKey.Q && order == 1)
            {
                QuitFight();
            }

            else
            {
                Nothing();
            }
        }

        if (order == 2)
        {
            actionIsUsed = false;
            Text($"{characters[1]}'s turn !");
            var battlePress = Console.ReadKey(true);

            if (battlePress.Key == ConsoleKey.A && order == 2 && actionIsUsed == false)
            { 
                actionIsUsed = true;
                Console.Clear();
                Text($"{characters[1]} attack {characters[0]}!");
                Thread.Sleep(1000);
                Text($"{characters[0]} is hurt !");
                OrderSwitch();
                Console.Clear();
            }

            else if (battlePress.Key == ConsoleKey.Q && order == 2)
            {
                QuitFight();
            }

            else
            {
                Nothing();
            }
        }
      
    }    
}

void OrderSwitch()
{
    if (order == 1)
    {
        order = 2;
    }

    else if (order == 2)
    {
        order = 1;
    }
}

void QuitFight()
{
    Text("No fight.");
    Environment.Exit(0);
}

void Nothing() 
{
    if (battleHasStarted == false)
    {
        Text("FIGHT !");
    }

    else if (battleHasStarted == true)
    {
        Console.Clear();
    }
}

void Text(string text) {
    Console.WriteLine(text);
}
    