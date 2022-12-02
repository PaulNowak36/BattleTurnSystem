

int order; 
int opponent;
bool battleHasStarted = false;
bool actionIsUsed = false;

string[] characters = {"Dude 1", "Dude 2"};
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
    opponent = 1;
    actionIsUsed = false;

    while (battleHasStarted == true)
    {
        actionIsUsed = false;
     
        Text($"{characters[order]}'s turn !");           
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Text("A) Attack");
        Text("Q) Quit the game");     

        if (actionIsUsed == false)
        {
            while (Console.KeyAvailable) Console.ReadKey(true);
            ConsoleKeyInfo battlePress = Console.ReadKey(true);

            switch (battlePress.Key)
            {
                case ConsoleKey.A:
                    newAttack();
                    break;
                case ConsoleKey.Q:
                    QuitFight();
                    break;
            }
        }        
    }    
}

void newAttack()
{
    actionIsUsed = true;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;

    Text($"{characters[order]} attack {characters[opponent]}!");
    Thread.Sleep(1000);
    Text($"{characters[opponent]} is hurt !");
    Thread.Sleep(1000);

    newOrderSwitch();
    Console.Clear();
    actionIsUsed = false;
}

void newOrderSwitch()
{
    (order, opponent) = (opponent, order);
}

void QuitFight()
{
    Console.ForegroundColor = ConsoleColor.White;
    Text("No fight.");
    Environment.Exit(0);
}

void Text(string text) {
    Console.WriteLine(text);
}

/* void pressKey(ConsoleKeyInfo key) {
    Text(Convert.ToString(key.Key));
} */


    