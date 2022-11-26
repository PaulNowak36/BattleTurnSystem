

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
        pressKey(touchPress);

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

    order = 0;
    actionIsUsed = false;

    while (battleHasStarted == true)
    {
        actionIsUsed = false;
        if (order == 0)
        {
            Text($"{characters[0]}'s turn !");
        }

        else if (order == 1)
        {
            Text($"{characters[1]}'s turn !");           
        }
        var battlePress = Console.ReadKey(true);

        if (battlePress.Key == ConsoleKey.A && actionIsUsed == false)
        {
            Attack();
        }

        else if (battlePress.Key == ConsoleKey.Q)
        {
            QuitFight();
        }

        else
        {
            Nothing();
        }       
    }    
}

void Attack()
{
    actionIsUsed = true;
    Console.Clear();
    if (order == 0)
    {
        Text($"{characters[0]} attack {characters[1]}!");
        Thread.Sleep(1000);
        Text($"{characters[1]} is hurt !");
    }
    else if (order == 1)
    {
        Text($"{characters[1]} attack {characters[0]}!");
        Thread.Sleep(1000);
        Text($"{characters[0]} is hurt !");
    }
    OrderSwitch();
    Console.Clear();
    actionIsUsed = false;

}

void OrderSwitch()
{
    if (order == 0)
    {
        order = 1;
    }

    else if (order == 1)
    {
        order = 0;
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

void pressKey(ConsoleKeyInfo key) {
    Text(Convert.ToString(key.Key));
}


    