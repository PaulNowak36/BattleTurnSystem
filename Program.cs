

int order; 
int opponent;
bool battleHasStarted = false;
bool actionIsUsed = false;

bool validNames = false;

string[] characters = {"Dude 1", "Dude 2"};

List<String> newCharacters= new List<String>();
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
                setCharactersNames();
                break;
            case ConsoleKey.Q:
                QuitFight();
                break;
        }

    }

}

void setCharactersNames()
{
    while(validNames == false)
    {
        Text("Please type the name of the character 1:");
        string name1 = Console.ReadLine();

        newCharacters.Add(name1);

        Text("Please type the name of the character 2:");
        string name2 = Console.ReadLine();

        newCharacters.Add(name2);

        if (name1 != name2)
        {
            validNames = true;
        }

        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Text("Please, choose different names for both characters.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    newBattleMode();
}

void newBattleMode()
{
    Text("LET'S THE BATTLE BEGINS !!");
    Text($"{newCharacters[0]} VS {newCharacters[1]}");

    order = 0;
    opponent = 1;
    actionIsUsed = false;

    while (battleHasStarted == true)
    {
        actionIsUsed = false;
     
        Text($"{newCharacters[order]}'s turn !");           
        
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

    Text($"{newCharacters[order]} attack {newCharacters[opponent]}!");
    Thread.Sleep(1000);
    Text($"{newCharacters[opponent]} is hurt !");
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


    