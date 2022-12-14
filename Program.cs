

int order; 
int opponent;
bool battleHasStarted = false;
bool actionIsUsed = false;
bool playerDown = false;

bool jobDecision = false;
bool jobChoice = false;


bool validNames = false;

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
    jobDecision = false;
    Console.Clear();
    character.characterNumber = CharacterRoster.Count + 1;
    
    Text($"Please type the name of the character {character.characterNumber}:");
    character.name = Console.ReadLine();

    Text("Do you want him to have a class ?");
    Text("Y for Yes");
    Text("N for No");

    while (jobDecision == false)
    {
        var touchPress = Console.ReadKey(true);            
        switch (touchPress.Key)
        {
            case ConsoleKey.Y:
                jobDecision = true;
                SetJob(character);           
                break;
            case ConsoleKey.N:
                jobDecision = true;
                SetJobless(character);
                break;
        }
    }

    CharacterRoster.Add(character);
    Thread.Sleep(1000);

}

void SetJob(Character character)
{
    jobChoice = false;
    Text("Choose your Job: ");
    Text("K for Knight");
    Text("W for Wizard");
    
    while (jobChoice == false)
    {
        var touchPress = Console.ReadKey(true);            
        switch (touchPress.Key)
        {
            case ConsoleKey.K:
                jobChoice = true;
                character.Job = new Knight();
                break;
            case ConsoleKey.W:
                jobChoice = true;
                character.Job = new Wizard(); 
                break;
        }
    }
    character.dammage = character.Job.JobDammage;
    character.maxHP = character.Job.JobHP;
    character.HP = character.maxHP;
    character.SP = character.Job.JobSP;
}

void SetJobless(Character character)
{
    Text("Set his dammage:");
    var dammageInput = Console.ReadLine();
    if (int.TryParse(dammageInput, out int value))
    {
        character.dammage = Convert.ToInt32(dammageInput);
    }
    
    else
    {
        character.dammage = character.defaultDammage;
        Text($"Let's say that he has {character.dammage} dammage, ok ?");
        Thread.Sleep(1000);
    }

    Text("Set his HP:");
    var HPInput = Console.ReadLine();
    if (int.TryParse(HPInput, out int value2))
    {
        character.maxHP = Convert.ToInt32(HPInput);
    }
    
    else
    {
        character.maxHP = character.defaultHP;
        Text($"Let's say that he has {character.HP} HP, ok ?");
        Thread.Sleep(1000);
    }
    character.HP = character.maxHP;

    Text("Set his SP:");
    var SPInput = Console.ReadLine();
    if (int.TryParse(HPInput, out int value3))
    {
        character.SP = Convert.ToInt32(SPInput);
    }
    
    else
    {
        character.SP = character.defaultSP;
        Text($"Let's say that he has {character.SP} SP, ok ?");
        Thread.Sleep(1000);
    }
}

void BattleMode()
{
    Console.Clear();
    Text("LET'S THE BATTLE BEGINS !!");
    Text($"{CharacterRoster[0].name} VS {CharacterRoster[1].name}");

    order = 0;
    opponent = 1;
    actionIsUsed = false;
    Thread.Sleep(2000);

    while (battleHasStarted == true)
    {
        Console.Clear();
        actionIsUsed = false;
        Console.ForegroundColor = ConsoleColor.White;

     
        Text($"{CharacterRoster[order].name}'s turn !");
        Console.WriteLine();
        Text($"Dammage: {CharacterRoster[order].dammage}");           
        Text($"HP: {CharacterRoster[order].HP}"); 
        Text($"SP: {CharacterRoster[order].SP}");           
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Text("A) Attack");
        Text("H) Heal");
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
                case ConsoleKey.H:
                    if(CharacterRoster[order].SP < 5)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Text("No enough SP for this.");
                        Thread.Sleep(3000);
                        break;
                    }
                    else
                    {
                        if (CharacterRoster[order].HP == CharacterRoster[order].maxHP )
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Text("HP is full.");
                            Thread.Sleep(3000);
                            break;
                        }

                        else
                        {
                            Heal();
                            break;
                        }
                        
                    }
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
    Text($"{CharacterRoster[opponent].name} loses {CharacterRoster[order].dammage} HP !");
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

void Heal()
{
    actionIsUsed = true;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
   
    Text($"{CharacterRoster[order].name} heals himself!");
    Thread.Sleep(1000);
    Text("He uses 5 SP and gains 15 HP !");
    Thread.Sleep(1000);
    CharacterRoster[order].SP -= 5;

    if (CharacterRoster[order].HP + 15 >= CharacterRoster[order].maxHP)
    {
        CharacterRoster[order].HP = CharacterRoster[order].maxHP;
    }

    else
    {
        CharacterRoster[order].HP += 15;
    }


    OrderSwitch();
    Console.Clear();
    actionIsUsed = false;

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

    public int maxHP;

    public int SP;

    public int defaultDammage = 5;
    public int defaultHP = 20;

    public int defaultSP = 10;


   public CharacterJob Job;

}

public abstract class CharacterJob {
    public abstract string JobName { get; } 
    public abstract int JobDammage { get; } 
    public abstract int JobHP { get; }
    public abstract int JobSP { get; } 

}

public class Knight : CharacterJob
{
    public override string JobName => "Knight";
    public override int JobDammage => 10;
    public override int JobHP => 50;
    public override int JobSP => 15;


}

public class Wizard : CharacterJob
{
    public override string JobName => "Wizard";
    public override int JobDammage => 13;
    public override int JobHP => 40;
    public override int JobSP => 25;

}
