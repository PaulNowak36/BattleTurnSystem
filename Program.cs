

int order; 
int opponent;
bool battleHasStarted = false;
bool actionIsUsed = false;
bool playerDown = false;

bool validNames = false;

string[] characters = {"Dude 1", "Dude 2"};

List<Character> CharacterRoster= new List<Character>();

Character char1 = new Character();
Character char2 = new Character();

Beginning();

void Beginning()
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
                CreateCharacters();
                break;
            case ConsoleKey.Q:
                QuitFight();
                break;
        }

    }

}

void CreateCharacters()
{
    while(validNames == false)
    {
        SetCharacter(char1);
        SetCharacter(char2);

        if (char1.name != char2.name)
        {
            validNames = true;
        }

        else
        {
            Console.Clear();
            CharacterRoster.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Text("Please, choose different names for both characters.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    BattleMode();
}

void SetCharacter(Character character)
{
    character.characterNumber = CharacterRoster.Count + 1;
    
    Text($"Please type the name of the character {character.characterNumber}:");
    character.name = Console.ReadLine();
    
    character.dammage = character.defaultDammage;
    character.HP = character.defaultHP;

    CharacterRoster.Add(character);
}

void BattleMode()
{
    Console.Clear();
    Text("LET'S THE BATTLE BEGINS !!");
    Text($"{CharacterRoster[0].name} VS {CharacterRoster[1].name}");

    order = 0;
    opponent = 1;
    actionIsUsed = false;
    Thread.Sleep(1000);


    while (battleHasStarted == true)
    {
        Console.Clear();
        actionIsUsed = false;
     
        Text($"{CharacterRoster[order].name}'s turn !");
        Console.WriteLine();
        Text($"Dammage: {CharacterRoster[order].dammage}");           
        Text($"HP: {CharacterRoster[order].HP}");           
        Console.WriteLine();
        
        
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

    Text($"{CharacterRoster[order].name} attack {CharacterRoster[opponent].name}!");
    Thread.Sleep(1000);
    Text($"{CharacterRoster[opponent].name} loose {CharacterRoster[order].dammage} HP !");
    Thread.Sleep(1000);
    CharacterRoster[opponent].HP -= CharacterRoster[order].dammage;

    if (CharacterRoster[opponent].HP <= 0)
    {
        playerDown = true;
        Victory();
    }

    else
    {
        OrderSwitch();
        Console.Clear();
        actionIsUsed = false;
    }
    
}

void OrderSwitch()
{
    (order, opponent) = (opponent, order);
}

void Victory()
{
    if(playerDown)
    {
        battleHasStarted = false;
        Console.Clear();

        Text($"{CharacterRoster[opponent].name} is K.O. !");
        Thread.Sleep(1000);
        Text($"Victory of {CharacterRoster[order].name}!");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }
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

public class Character{
    public string name {get; set;}
    public int characterNumber;
    public int dammage;
    public int HP;

    public int defaultDammage = 5;
    public int defaultHP = 20;

}

    