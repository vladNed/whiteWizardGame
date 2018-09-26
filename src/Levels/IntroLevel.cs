using System;


namespace WhiteWizard {

    class IntroLevel : TextUtil{


        public static void Start(ref Player player){

            //Variables
            int x = 0;
            int y = 0;
            string playerName = "";
            int playerHP = 0;
            int playerMaxHP = 0;
            int playerXP = 0;
            int playerMaxXP = 0;
            int itemsMax = 0;
            string playerClass = "";
            int playerStr = 0;
            int playerMagic = 0;
            int playerRange = 0;
            ConsoleColor playerColor = new ConsoleColor();

            //Boot text
            IntroText();

            //Setting the players name first
            SetPlayerNameText();
            PlayerName(ref playerName);

            //RESET the color after the name is entered
            Reset();

            //Setting the players class
            ClassSelectText();
            ClassMenu();

            x = Console.CursorLeft;
            y = Console.CursorTop;

            //The player stats are made
            ClassProps(x,y,ref playerHP, ref playerMaxHP, ref playerXP, ref playerMaxXP, ref itemsMax, ref playerClass, ref playerColor, ref playerStr, ref playerMagic, ref playerRange);

            //Initialize the player charcter with the stats
            player = new Player(playerName,playerHP,playerMaxHP,playerXP,playerMaxXP,playerClass,playerStr,playerMagic,playerRange,itemsMax,playerColor);

            Console.Clear();
        }

        private static void IntroText(){

            string introDrawing = System.IO.File.ReadAllText(@"C:\Users\nedvl\Desktop\WhiteWizard\src\Drawings\introDrawing.txt");
            string introCommand = System.IO.File.ReadAllText(@"C:\Users\nedvl\Desktop\WhiteWizard\src\Drawings\introCommand.txt");

            //Intro text that is displayed when running the program
            Console.WriteLine(introDrawing);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(introCommand);
            Reset();
            Console.ReadKey();
            Console.SetCursorPosition(33, 5);
        }
        private static void SetPlayerNameText(){

            //Set the PlayersName
            Console.Clear();
            Console.WriteLine("\n\n   First you have to name your hero ");
            Console.WriteLine("   What is his name ?        Name:");
            Console.SetCursorPosition(34, 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private static void ClassSelectText(){

            //Class select
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("   Now let's choose a class please");
            Console.WriteLine("   -------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n   1.Warrior");
            Reset();
            Console.SetCursorPosition(26, 9);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   2.Hunter");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n   3.Mage");
            Console.SetCursorPosition(26, 11);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   4.Adventurer");
            Reset();
            Console.SetCursorPosition(3, 9);
        }
        private static void PlayerName(ref string playerName){

            //Boolean to verify if name is correct
            bool nameIsCorrect = false;

            //Read the name entered by the player
            do{
                Console.SetCursorPosition(34, 3);
                playerName = Console.ReadLine();
                if (playerName == ""){
                    nameIsCorrect = false;
                }
                else if(playerName == "exit"){
                    Environment.Exit(0);
                }
                else{
                    nameIsCorrect = true;
                }
            } while (nameIsCorrect != true);
        }

        private static void ClassMenu(){
            
            //Boolean for class menu select
            bool classSelected = false;

            //Class Menu
            do
            {
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (Console.CursorLeft == 29)
                        {
                            Console.Beep(700, 125);
                        }
                        else
                            Console.SetCursorPosition(Console.CursorLeft + 26, Console.CursorTop);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft == 3)
                        {
                            Console.Beep(700, 125);
                        }
                        else
                            Console.SetCursorPosition(Console.CursorLeft - 26, Console.CursorTop);
                        break;


                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop == 9)
                        {
                            Console.Beep(700, 125);
                        }
                        else
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                        break;


                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop == 11)
                        {
                            Console.Beep(700, 125);
                        }
                        else
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);

                        break;
                    case ConsoleKey.Enter:
                        classSelected = true;
                        break;
                }

            } while (classSelected != true);
        }

        private static void ClassProps(int x, int y,
                ref int playerHP, 
                ref int playerMaxHP, 
                ref int playerXP, 
                ref int playerMaxXP, 
                ref int itemsMax, 
                ref string playerClass, 
                ref ConsoleColor playerColor,
                ref int playerStr,
                ref int playerMagic,
                ref int playerRange){

            //Warrior
            if (x == 3 && y == 9)
            {
                playerHP = 150;
                playerMaxHP = 300;
                playerXP = 0;
                playerMaxXP = 100;
                itemsMax = 4;
                playerClass = "warrior";
                playerStr = 100;
                playerMagic = 0;
                playerRange = 0;
                playerColor = ConsoleColor.Red;
            }
            //Archer
            if (x == 29 && y == 9)
            {
                playerHP = 100;
                playerMaxHP = 100;
                playerMaxXP = 100;
                playerXP = 0;
                itemsMax = 8;
                playerClass = "hunter";
                playerStr = 20;
                playerMagic = 0;
                playerRange = 100;
                playerColor = ConsoleColor.Green;
            }
            //Mage
            if (x == 3 && y == 11)
            {
                playerHP = 50;
                playerMaxHP = 100;
                playerMaxXP = 500;
                playerXP = 0;
                itemsMax =8;
                playerClass = "mage";
                playerStr = 0;
                playerMagic = 100;
                playerRange = 50;
                playerColor = ConsoleColor.Magenta;

            }
            //Adventurer
            if (x == 29 && y == 11)
            {
                playerHP = 150;
                playerMaxHP = 300;
                playerMaxXP = 100;
                playerXP = 0;
                itemsMax = 10;
                playerClass = "adventurer";
                playerStr = 50;
                playerMagic = 10;
                playerRange = 20;
                playerColor = ConsoleColor.Yellow;
            }
        }
    }  
}