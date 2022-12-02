

int order; 
bool battleHasStarted = false;
bool actionIsUsed = false;

string[] characters = {"Dude 1", "Dude 2"};

//Beginning();
//Menu();
newBeginning();

void newBeginning()
{
    Console.Clear();
    Text("It is time to battle !");
    Text("Make your choice: ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Text("A) Start the Fight");
    Text("Q) Quit the game");

    while (battleHasStarted == false)
    {
        Console.ForegroundColor = ConsoleColor.White;
        var touchPress = Console.ReadKey(true);        
        switch (touchPress.Key)
        {
            case ConsoleKey.A:
                battleHasStarted = true;
                Console.Clear();
                newBattleMode();
                break;
            case ConsoleKey.Q:
                QuitFight();
                break;
        }

    }

}

void newBattleMode()
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

        Console.ForegroundColor = ConsoleColor.Blue;
        Text("A) Attack");
        Text("Q) Quit the game");

        

        if (actionIsUsed == false)
        {
            while (Console.KeyAvailable) Console.ReadKey(true);
            ConsoleKeyInfo battlePress = Console.ReadKey(true);
            //var battlePress = Console.ReadKey(true);

            switch (battlePress.Key)
            {
                case ConsoleKey.A:
                    Attack();
                    break;
                case ConsoleKey.Q:
                    QuitFight();
                    break;
            }
        }        
    }    
}

void Attack()
{
    actionIsUsed = true;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    if (order == 0)
    {
        Text($"{characters[0]} attack {characters[1]}!");
        Thread.Sleep(1000);
        Text($"{characters[1]} is hurt !");
        Thread.Sleep(1000);
    }
    else if (order == 1)
    {
        Text($"{characters[1]} attack {characters[0]}!");
        Thread.Sleep(1000);
        Text($"{characters[0]} is hurt !");
        Thread.Sleep(1000);
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
    Console.ForegroundColor = ConsoleColor.White;
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

/* void pressKey(ConsoleKeyInfo key) {
    Text(Convert.ToString(key.Key));
} */


    