using System;
using System.Linq;


namespace WhiteWizard
{
    class Program
    { 
        public static void playerMove(int curs, bool gameOver1)
        {
            do
            {
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        curs++;
                        if(Console.CursorLeft == 118) { }
                        else
                        Console.SetCursorPosition(Console.CursorLeft + curs, Console.CursorTop);
                        curs--;
                        break;
                    case ConsoleKey.LeftArrow:
                        curs++;
                        if (Console.CursorLeft == 0) { }
                        else
                        Console.SetCursorPosition(Console.CursorLeft - curs, Console.CursorTop);
                        curs--;
                        break;
                    case ConsoleKey.UpArrow:
                        curs++;
                        if (Console.CursorTop == 2) { }
                        else
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - curs);
                        curs--;
                        break;
                    case ConsoleKey.DownArrow:
                        curs++;
                        if (Console.CursorTop == 28) { }
                        else
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + curs);
                        curs--;
                        break;
                    case ConsoleKey.Spacebar:
                        gameOver1 = true;
                        Console.SetCursorPosition(1, 3);
                        
                        break;
                }
                
            } while (gameOver1 == false);
        }
        static void attackAI(ConsoleColor playerColor, int itemsMax, string[] inventory, string commandLine, bool gameOver,int inGame,string playerName,ref int playerHP,int CEVA, ref int []whiteWizard,int dec)
        {
            
            Console.Clear();
            int playerHPClone = playerHP;
         
            int moveLeft = 1;
            int moveTop = 8;
            int up = 3;
            bool over = true;
            int enemyHP = 100;
            int x = 0, y = 0;
            //enemy brain
            int[] brain = new int[2];
            brain[0] = 0;
            brain[1] = 0;
            



            
                do
                {
                if (playerHP != 0)
                {
                    x = 0;
                    y = 0;
                    up = 2;
                    over = true;

                    Console.Clear();

                    Console.Write("                                BATTLE ACTION ACTIVATED!");
                    Console.SetCursorPosition(15, 4);
                    Console.Write("Player Stats                               Enemy Stats");
                    Console.SetCursorPosition(15, 5);
                    Console.Write("Name:{0}                                   Name:{1}", playerName, "burglar");
                    Console.SetCursorPosition(15, 6);
                    Console.Write("Health:{1}                                    Health:{0}", enemyHP, playerHP);
                    Console.SetCursorPosition(15, 7);
                    Console.SetCursorPosition(15, 10);
                    Console.WriteLine("Attack\n               Negotiate\n               Use items");
                    Console.SetCursorPosition(14, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(">");
                    Console.ResetColor();
                    Console.SetCursorPosition(14, 10);

                    do
                    {
                        ConsoleKeyInfo keyInfo;
                        keyInfo = Console.ReadKey(true);


                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (up == 2) { }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write(">");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(">");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.ResetColor();
                                    up++;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (up == 0) { }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write(">");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(">");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.ResetColor();
                                    up--;
                                }
                                break;
                            case ConsoleKey.Enter:
                                over = false;

                                break;
                        }
                    } while (over == true);

                    x = Console.CursorLeft;
                    y = Console.CursorTop;
                    if (x == 14 && y == 10)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 16);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("|1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111|");
                        Console.SetCursorPosition(0, 4);
                        Console.ResetColor();
                        Console.WriteLine("|0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000|");
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|");

                        Console.SetCursorPosition(2, 7);

                        // enemy 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(100, 10);
                        Console.Write(" |");
                        Console.SetCursorPosition(100, 11);
                        Console.Write("-X-");
                        Console.ResetColor();

                        int[] enemyTop = new int[3];
                        for (int b = 0; b < 3; b++)
                            enemyTop[b] = 9 + b;

                        int[] enemyLeft = new int[4];
                        for (int b = 0; b < 4; b++)
                            enemyLeft[b] = 100 + b;

                        int j;
                        int[] js = new int[5];
                        int i = 0;
                        Console.SetCursorPosition(14, 2);
                        Console.Write("Move thorugh the bushes and engage your enemy by pressing SPACEBAR!");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (j = 5; j <= 15; j++)
                        {

                            if (j % 3 == 0)
                            {

                                Console.SetCursorPosition(60, j);
                                Console.WriteLine("");
                                if (j == brain[0]) { }
                                else
                                {
                                    js[i] = j;
                                    i++;
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(60, j);
                                Console.WriteLine("##");

                            }
                        }
                        Console.ResetColor();
                        if (brain[0] != 0)
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(60, brain[0]);
                            Console.Write("@");
                            System.Threading.Thread.Sleep(700);

                        }

                        do
                        {


                            try
                            {
                                ConsoleKeyInfo preesKey = Console.ReadKey(true);
                                if (moveLeft == 60)
                                {
                                    brain[0] = Console.CursorTop;
                                }
                                switch (preesKey.Key)
                                {
                                    case ConsoleKey.RightArrow:
                                        if (Console.CursorLeft == 59 && brain.Contains(Console.CursorTop))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Trap activated by enemy!!! You lost!");
                                            playerHP = playerHP - 50;

                                            System.Threading.Thread.Sleep(600);
                                            Console.ReadKey();
                                            over = true;
                                            brain[1] = brain[0];
                                            break;
                                        }
                                        else if (moveLeft >= 118 || (Console.CursorLeft == 59 && !js.Contains(Console.CursorTop)) || (moveLeft == 99 && (moveTop == 11 || moveTop == 10)))
                                        { }
                                        else
                                        {
                                            moveLeft++;
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                            Console.ForegroundColor = playerColor;
                                            Console.WriteLine("X");
                                            Console.SetCursorPosition(moveLeft - 1, moveTop);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("X");
                                            Console.ResetColor();
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                        }
                                        break;
                                    case ConsoleKey.LeftArrow:

                                        if (moveLeft == 1 || (Console.CursorLeft == 62 && !js.Contains(Console.CursorTop)) || (enemyLeft.Contains(moveLeft) && enemyTop.Contains(moveTop)))
                                        { }
                                        else
                                        {
                                            moveLeft--;
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                            Console.ForegroundColor = playerColor;
                                            Console.WriteLine("X");
                                            Console.SetCursorPosition(moveLeft + 1, moveTop);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("X");
                                            Console.ResetColor();
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                        }
                                        break;
                                    case ConsoleKey.UpArrow:

                                        if (moveTop == 5 || (js.Contains(Console.CursorTop) && (Console.CursorLeft == 60 || Console.CursorLeft == 61)))
                                        { }
                                        else
                                        {
                                            moveTop--;
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                            Console.ForegroundColor = playerColor;
                                            Console.WriteLine("X");
                                            Console.SetCursorPosition(moveLeft, moveTop + 1);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("X");
                                            Console.ResetColor();
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                        }
                                        break;
                                    case ConsoleKey.DownArrow:

                                        if (moveTop == 15 || (js.Contains(Console.CursorTop) && (Console.CursorLeft == 60 || Console.CursorLeft == 61)) || (enemyLeft.Contains(moveLeft) && enemyTop.Contains(moveTop)))
                                        { }
                                        else
                                        {
                                            moveTop++;
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                            Console.ForegroundColor = playerColor;
                                            Console.WriteLine("X");
                                            Console.SetCursorPosition(moveLeft, moveTop - 1);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("X");
                                            Console.ResetColor();
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                        }
                                        break;
                                    case ConsoleKey.Spacebar:

                                        if (enemyLeft.Contains(moveLeft + 1) && enemyTop.Contains(moveTop))
                                        {
                                            over = true;
                                            enemyHP = enemyHP - 50;

                                        }
                                        Console.SetCursorPosition(moveLeft, moveTop);
                                        Console.ForegroundColor = playerColor;
                                        Console.Write("X");

                                        System.Threading.Thread.Sleep(30);
                                        Console.SetCursorPosition(moveLeft + 1, moveTop);
                                        Console.Write("-");
                                        Console.SetCursorPosition(moveLeft + 1, moveTop);
                                        System.Threading.Thread.Sleep(50);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("-");
                                        Console.ResetColor();

                                        System.Threading.Thread.Sleep(30);
                                        Console.SetCursorPosition(moveLeft, moveTop - 1);
                                        Console.Write("|");
                                        Console.SetCursorPosition(moveLeft, moveTop - 1);
                                        System.Threading.Thread.Sleep(50);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("|");
                                        Console.ResetColor();

                                        System.Threading.Thread.Sleep(30);
                                        Console.SetCursorPosition(moveLeft - 1, moveTop);
                                        Console.Write("-");
                                        Console.SetCursorPosition(moveLeft - 1, moveTop);
                                        System.Threading.Thread.Sleep(50);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("-");
                                        Console.ResetColor();


                                        break;
                                    case ConsoleKey.R:
                                        Console.SetCursorPosition(0, 0);
                                        Console.WriteLine("left:{0} top:{1}", moveLeft, moveTop);
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("An error just occured---->{0}", e.Data);
                            }
                        } while (over != true);
                        brain[1] = brain[0];
                        Console.Clear();
                        moveLeft = 1;
                        moveTop = 8;
                    }
                    else if (x == 14 && y == 11)
                    {
                        int i = 5;
                        Console.Clear();
                        Console.SetCursorPosition(14, 3);
                        Console.WriteLine("Try negotiate a peaceful confrontation");
                        Console.SetCursorPosition(14, i);
                        i++;
                        Console.ForegroundColor = playerColor;
                        Console.Write("You:");
                        Console.ResetColor();
                        Console.Write("Let's talk about it pal? what do you say?");
                        Console.WriteLine("             Press Enter to negotiate.");
                        Random a = new Random();
                        Console.ReadKey();
                        int rand;
                        rand = a.Next(1, 20);
                        if (rand % 2 == 0 || rand % 5 == 0 || rand % 6 == 0)
                        {
                            Console.SetCursorPosition(14, i);
                            i++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Enemy:");
                            Console.ResetColor();
                            Console.Write("OK,Let me see what you got!!");

                            Console.SetCursorPosition(14, i);
                            i++;
                            Console.ForegroundColor = playerColor;
                            Console.Write("You:");
                            Console.ResetColor();
                            Console.Write("Why fight?...Maybe i can help you with something else");
                            Console.WriteLine("             Press Enter to negotiate.");
                            Console.ReadKey();
                            Console.SetCursorPosition(14, i);
                            i++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Enemy:");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(400);
                            rand = a.Next(1, 100);
                            if (rand % 2 == 0 || rand % 5 == 0)
                            {
                                Console.Write("You got a deal man!!");
                                enemyHP = 0;
                                whiteWizard[dec] = 1;
                                over = true;
                                Console.ReadKey();

                            }
                            else
                            {
                                Console.Write("HAHAHAHA...Let's fight punk!!");
                                over = true;
                                Console.ReadKey();
                            }
                        }
                        else if (rand % 2 != 0)
                        {
                            Console.SetCursorPosition(14, i);
                            i++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Enemy:");
                            Console.ResetColor();
                            Console.Write("Stop talking punk. LET'S FIGHT!!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else if (x == 14 && y == 12)
                    {
                        inGame = 0;
                        Console.Clear();
                        invCommand(itemsMax, inventory, commandLine, gameOver, inGame, CEVA);

                    }
                }

                else
                {
                    Console.Clear();
                    Console.Write("You will be magically respawed before the fight ....cuz u died ;)");
                    playerHP = playerHPClone;
                    Console.ReadKey();
                }
                } while (enemyHP != 0);
                Console.Write("Enemy was");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" DEFEATED");
                Console.ResetColor();
                Console.Write(" !");
            
            
        }
        static void attackAI2(ConsoleColor playerColor, int itemsMax, string[] inventory, string commandLine, bool gameOver, int inGame, string playerName, ref int playerHP)
        {

            Console.Clear();

            int moveLeft = 1;
            int moveTop = 8;
            int up = 3;
            bool over = true;
            int enemyHP = 10000;
            int x = 0, y = 0;
            //enemy brain
            int[] brain = new int[10];
            



                do
                {
                    x = 0;
                    y = 0;
                    up = 0;
                    over = true;

                    Console.Clear();

                    Console.Write("                                BATTLE ACTION ACTIVATED!");
                    Console.SetCursorPosition(15, 4);
                    Console.Write("Player Stats                               Enemy Stats");
                    Console.SetCursorPosition(15, 5);
                    Console.Write("Name:{0}                                   Name:{1}", playerName, "Blacksmith");
                    Console.SetCursorPosition(15, 6);
                    Console.Write("Health:{1}                                    Health:{0}", enemyHP, playerHP);
                    Console.SetCursorPosition(15, 7);
                    Console.SetCursorPosition(15, 10);
                    Console.WriteLine("Attack\n               Negotiate\n               Use items");
                    Console.SetCursorPosition(14, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(">");
                    Console.ResetColor();
                    Console.SetCursorPosition(14, 10);

                    do
                    {
                        ConsoleKeyInfo keyInfo;
                        keyInfo = Console.ReadKey(true);


                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (up == 0) { }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write(">");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(">");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.ResetColor();
                                    up++;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (up == 0) { }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write(">");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(">");
                                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                    Console.ResetColor();
                                    up--;
                                }
                                break;
                            case ConsoleKey.Enter:
                                over = false;

                                break;
                        }
                    } while (over == true);

                    x = Console.CursorLeft;
                    y = Console.CursorTop;
                    if (x == 14 && y == 10)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 16);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("|1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111|");
                        Console.SetCursorPosition(0, 4);
                        Console.ResetColor();
                        Console.WriteLine("|0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000|");
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|");

                        Console.SetCursorPosition(2, 7);

                        // enemy 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(100, 10);
                        Console.Write(" |");
                        Console.SetCursorPosition(100, 11);
                        Console.Write("-X-");
                        Console.ResetColor();

                        int[] enemyTop = new int[3];
                        for (int b = 0; b < 3; b++)
                            enemyTop[b] = 9 + b;

                        int[] enemyLeft = new int[4];
                        for (int b = 0; b < 4; b++)
                            enemyLeft[b] = 100 + b;

                        int j;
                        int[] js = new int[5];
                        int i = 0;
                        Console.SetCursorPosition(14, 2);
                        Console.Write("USE YOUR HEALTH TO BREAK BLACKSMITH'S SHIELDS AND PROVE THAT YOU ARE BRAVE!");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (j = 5; j <= 15; j++)
                        {

                            if (j % 3 == 0)
                            {
                                if (playerHP>10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(60, j);
                                    Console.WriteLine("@");
                                    brain[i] = j;
                                    js[i] = j;
                                    i++;
                                    Console.ResetColor();
                                }
                                else if (playerHP <= 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(60, j);
                                    Console.WriteLine("@");
                                    brain[i] = j;
                                    js[i] = j;
                                    i++;
                                    Console.ResetColor();
                                    Console.SetCursorPosition(60, brain[1]);
                                    Console.Write("  ");
                                    brain[1] = 0;
                                }
                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(60, j);
                                Console.WriteLine("##");
                                Console.ResetColor();

                            }
                        }
                        Console.ResetColor();
                        

                        

                        do
                        {


                            try
                            {
                                ConsoleKeyInfo preesKey = Console.ReadKey(true);
                                
                                switch (preesKey.Key)
                                {
                                    case ConsoleKey.RightArrow:
                                        if (Console.CursorLeft == 59 && brain.Contains(Console.CursorTop) && brain[2]!=0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Trap activated by enemy!!! You lost!");
                                        if (playerHP < 11) { playerHP = playerHP - 1; }
                                        else
                                        {
                                            playerHP = playerHP - 30;
                                        }

                                            
                                            Console.ReadKey();
                                            over = true;
                                            
                                            break;
                                        }
                                        else if (moveLeft >= 118 || (Console.CursorLeft == 59 && !js.Contains(Console.CursorTop)) || (moveLeft == 99 && (moveTop == 11 || moveTop == 10)))
                                        { }
                                        else
                                        {
                                            moveLeft++;
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                            Console.ForegroundColor = playerColor;
                                            Console.WriteLine("X");
                                            Console.SetCursorPosition(moveLeft - 1, moveTop);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("X");
                                            Console.ResetColor();
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                        }
                                        break;
                                    case ConsoleKey.LeftArrow:

                                        if (moveLeft == 1 || (Console.CursorLeft == 62 && !js.Contains(Console.CursorTop)) || (enemyLeft.Contains(moveLeft) && enemyTop.Contains(moveTop)))
                                        { }
                                        else
                                        {
                                            moveLeft--;
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                            Console.ForegroundColor = playerColor;
                                            Console.WriteLine("X");
                                            Console.SetCursorPosition(moveLeft + 1, moveTop);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("X");
                                            Console.ResetColor();
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                        }
                                        break;
                                    case ConsoleKey.UpArrow:

                                        if (moveTop == 5 || (js.Contains(Console.CursorTop) && (Console.CursorLeft == 60 || Console.CursorLeft == 61)))
                                        { }
                                        else
                                        {
                                            moveTop--;
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                            Console.ForegroundColor = playerColor;
                                            Console.WriteLine("X");
                                            Console.SetCursorPosition(moveLeft, moveTop + 1);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("X");
                                            Console.ResetColor();
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                        }
                                        break;
                                    case ConsoleKey.DownArrow:

                                        if (moveTop == 15 || (js.Contains(Console.CursorTop) && (Console.CursorLeft == 60 || Console.CursorLeft == 61)) || (enemyLeft.Contains(moveLeft) && enemyTop.Contains(moveTop)))
                                        { }
                                        else
                                        {
                                            moveTop++;
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                            Console.ForegroundColor = playerColor;
                                            Console.WriteLine("X");
                                            Console.SetCursorPosition(moveLeft, moveTop - 1);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("X");
                                            Console.ResetColor();
                                            Console.SetCursorPosition(moveLeft, moveTop);
                                        }
                                        break;
                                    case ConsoleKey.Spacebar:

                                        if (enemyLeft.Contains(moveLeft + 1) && enemyTop.Contains(moveTop))
                                        {
                                            over = true;
                                            enemyHP = enemyHP - 10000 ;

                                        }
                                        Console.SetCursorPosition(moveLeft, moveTop);
                                        Console.ForegroundColor = playerColor;
                                        Console.Write("X");

                                        System.Threading.Thread.Sleep(30);
                                        Console.SetCursorPosition(moveLeft + 1, moveTop);
                                        Console.Write("-");
                                        Console.SetCursorPosition(moveLeft + 1, moveTop);
                                        System.Threading.Thread.Sleep(50);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("-");
                                        Console.ResetColor();

                                        System.Threading.Thread.Sleep(30);
                                        Console.SetCursorPosition(moveLeft, moveTop - 1);
                                        Console.Write("|");
                                        Console.SetCursorPosition(moveLeft, moveTop - 1);
                                        System.Threading.Thread.Sleep(50);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("|");
                                        Console.ResetColor();

                                        System.Threading.Thread.Sleep(30);
                                        Console.SetCursorPosition(moveLeft - 1, moveTop);
                                        Console.Write("-");
                                        Console.SetCursorPosition(moveLeft - 1, moveTop);
                                        System.Threading.Thread.Sleep(50);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("-");
                                        Console.ResetColor();


                                        break;
                                    case ConsoleKey.R:
                                        Console.SetCursorPosition(0, 0);
                                        Console.WriteLine("left:{0} top:{1}", moveLeft, moveTop);
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("An error just occured---->{0}", e);
                            }
                        } while (over != true);
                        
                        Console.Clear();
                        moveLeft = 1;
                        moveTop = 8;
                    }
                    
                } while (enemyHP != 0);
                Console.Write("Enemy was");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" DEFEATED");
                Console.ResetColor();
                Console.Write(" !");
            
            
        }
        static void invCommand(int itemsMax,string[]inventory,string commandLine,bool gameOver,int inGame,int CEVA)
        {
            
            if (inGame == 0)
            {
                Console.WriteLine("   Inventory:\n");
                for (int i = 0; i < itemsMax; i++)
                {
                    Console.WriteLine("   slot{0}:{1}", i + 1, inventory[i]);
                }
                if (CEVA == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n   Back");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n   Back");
                    Console.ResetColor();
                }
                //Console.Write("  \n  >");
                bool over = true;
                int up = itemsMax;
                Console.SetCursorPosition(2, 2);
                Console.Write(">");
                Console.SetCursorPosition(2, 2);
                do
                {
                    ConsoleKeyInfo keyInfo;
                    keyInfo = Console.ReadKey(true);
                    

                    
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (up == itemsMax) { }
                            else if(Console.CursorTop == itemsMax + 3)
                            {
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(">");
                                Console.ResetColor();
                                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop-2);
                                Console.Write(">");
                                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                            }
                            else 
                            {
                                Console.SetCursorPosition(Console.CursorLeft , Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(">");
                                Console.ResetColor();
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop -1);
                                Console.Write(">");
                                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                                up++;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (up == 1)
                            {
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(">");
                                Console.ResetColor();
                                Console.SetCursorPosition(2, itemsMax+3);
                                Console.Write(">");
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

                            }
                            else
                            {
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(">");
                                Console.ResetColor();
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                                Console.Write(">");
                                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                                up--;
                            }
                            break;
                        case ConsoleKey.Enter:
                            over = false;

                            break;
                    }
                } while (over == true);
                
                
            }
            else if (inGame == 1)
            {
                gameOver = false;
                do
                {
                    Console.WriteLine("   Inventory:");
                    for (int i = 0; i < itemsMax; i++)
                    {
                        Console.SetCursorPosition(2, 6 + i);
                        Console.WriteLine("slot{0}:{1}", i + 1, inventory[i]);
                    }
                    Console.Write("  \n  >");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Back");
                    Console.ResetColor();
                    Console.SetCursorPosition(13, 3);
                    commandLine = Console.ReadLine();
                    commandLine.ToLower();
                    if (CEVA == 0)
                    {
                        if (commandLine == "back")
                            gameOver = true;
                    }
                    else if (CEVA == 1)
                    {
                        if (commandLine == "use potion")
                            gameOver = true;
                    }
                } while (gameOver != true);
            }
        }
        static void Main(string[] args)
        {
            //Clear console for debugging mode only
            Console.Clear();

            //variables and boot sets
            Console.Title = "The White Wizard";
            Console.WindowWidth =85;
            Console.WindowHeight = 28;
            Player currentPlayer = new Player();
            string engineCommand = "";
            
            //Intro and MainMenu
            IntroLevel.Start(ref currentPlayer);
            engineCommand = MainMenuScreen.Show();

            //After the command has been issued, is given to the engine so the game can start
            GameEngine.Start(engineCommand,0,currentPlayer);

            Console.ReadKey();
            
            
           /*
            string[] inventory = new string[itemsMax];
            int iCount = 0;
           
            //prologue Level
           
            
           
            GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
            Console.Clear(); 
            

            //packing
            GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
            Console.WriteLine("It is time to pack.");
            Console.WriteLine("  Let's pick our stuff to go on.");
            Console.Write("");
            if(playerClass == "war")
            {
                    Console.Write("  Pick up the ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("axe");
                    Console.ResetColor();
                    Console.Write("?  ");
                do
                {
                    Console.SetCursorPosition(22,7);
                    commandLine = Console.ReadLine();
                    commandLine.ToLower();

                    if (commandLine == "yes" || commandLine == "y")
                    {
                        inventory[iCount] = "axe";
                        iCount++;
                    }
                    else if (commandLine == "no" || commandLine == "n")
                    {
                        Console.WriteLine("  You did not pick up the axe :(");
                    }
                    else
                    {
                        commandLine ="a";
                    }
                } while (commandLine == "a");
                Console.Write("\n  Pick up the bag of ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("coins");
                Console.ResetColor();
                Console.Write("?  ");
                do
                {
                    commandLine = Console.ReadLine();
                    commandLine.ToLower();
                    if (commandLine == "yes" || commandLine == "y")
                    {
                        inventory[iCount] = "bag of coins";
                        iCount++;
                    }
                    else if (commandLine == "no" || commandLine == "n")
                    {
                        Console.WriteLine("You did not pick up the bag of coins :(");
                    }
                    else
                    {
                        commandLine = "a";
                    }

                } while (commandLine == "a");
                Console.Write("\n  Pick up ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("water");
                Console.ResetColor();
                Console.Write("?  ");
                do
                {
                    commandLine = Console.ReadLine();
                    commandLine.ToLower();
                    if (commandLine == "yes" || commandLine == "y")
                    {
                        inventory[iCount] = "water";
                        iCount++;
                    }
                    else if (commandLine == "no" || commandLine == "n")
                    {
                        Console.WriteLine("You did not pick up the water bottle :(");
                    }
                    else
                    {
                        commandLine = "a";
                    }
                } while (commandLine == "a");
                Console.Write("\n  Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("map");
                Console.ResetColor();
                Console.Write("?  ");
                do
                {
                    commandLine = Console.ReadLine();
                    commandLine.ToLower();
                    if (commandLine == "yes" || commandLine == "y")
                    {
                        inventory[iCount] = "map";
                        iCount++;
                    }
                    else if (commandLine == "no" || commandLine == "n")
                    {
                        Console.WriteLine("You did not pick up the map :(");
                        System.Threading.Thread.Sleep(1300);
                    }
                    else
                    {
                        commandLine = "a";
                    }
                } while (commandLine == "a");
            }
            if(playerClass == "hunt")
            {
                Console.Write("  Pick up the ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("bow D->");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "bow";
                    iCount++;
                    currentItems++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the bow . How are you going to hunt anything without it?");
                }
                Console.Write("  Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("arrows");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "arrows";
                    iCount++;
                    currentItems++;
                }
                else
                {
                    Console.WriteLine("You have no arrows for your bow :(");
                }
                Console.Write("  Pick up the bottle of ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("water");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "bottle of water";
                    iCount++;
                    currentItems++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the bottle of water :(");
                }
                Console.Write("  Pick up the bag of");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("coins");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "bag of coins";
                    iCount++;
                    currentItems++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the bag of coins :(");
                    System.Threading.Thread.Sleep(1300);
                }
            }
            if(playerClass == "mag")
            {
                Console.Write("  Pick up your ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("staff");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "staff";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the staff .You'll need it to cast more powerfull spells but alright,your call..");
                }
                Console.Write("  Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("book of spells");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "book of spells";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the book of spells. Do you know all of them?");
                }
                Console.Write("  Pick up the ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("mana potions");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "mana potion";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the mana potions. You may not be able to cast too many spells :(");
                }
                Console.Write("  Pick up the bag of");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("coins");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "bag of coins";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the bag of coins :(");
                    System.Threading.Thread.Sleep(1300);
                }
            }
            if(playerClass == "adv")
            {
                Console.Write("  Pick up your");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(" travelling stick");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "travelling stick";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("You did not pick up your travelling stick :(");
                }
                Console.Write("  Pick up the bag of");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" coins");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "bag of coins";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the bag of coins :(");
                }
                Console.Write("  Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" meat");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "meat";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("Don't you want to take any meat with you? It's a long way, you may have to hunt.");
                }
                Console.Write("  Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("knife");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "knife";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("You did not pick up the knife, how are you going to hunt without one? ");

                }
                Console.Write("  Pick up the ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("blanket and flint stone");
                Console.ResetColor();
                Console.Write("?  ");
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                if (commandLine == "yes" || commandLine == "y")
                {
                    inventory[iCount] = "blanket and flint stone";
                    iCount++;
                }
                else
                {
                    Console.WriteLine("You did not pick blanket and flint stone, be careful not to get a cold.");
                    System.Threading.Thread.Sleep(1300);

                }
            }
            
            int inGame = 0;
            
            do
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                Console.SetCursorPosition(13,3);
                commandLine = "a";
                commandLine = Console.ReadLine();
                commandLine.ToLower();

                if ((commandLine == "give coins" || commandLine == "give")&& inventory.Contains("bag of coins"))
                {
                    Console.SetCursorPosition(3, 8);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("You gave the coins.Press Enter to proceed.");
                    for(int i =0; i<itemsMax;i++)
                        if (inventory[i]=="bag of coins")
                        {
                            inventory[i] = "";
                            iCount--;
                            currentItems--;
                        }
                    
                    Console.ResetColor();
                    Console.ReadKey();
                    decision[0] = 1;
                    gameOver = true;
                }
                else if (commandLine == "walk away" || commandLine == "walk")
                {
                    Console.SetCursorPosition(3, 8);
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("You walked away, or had no coins to give.Press Enter to proceed.");
                    Console.ResetColor();
                    Console.ReadKey();
                    decision[0] = 0;
                    gameOver = true;
                }
                else if (commandLine == "inventory" || commandLine == "inv")
                {
                    inGame = 1;
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    invCommand(itemsMax, inventory, commandLine, gameOver,inGame,CEVA =0);

                }
            } while (gameOver != true);
            
            //first AI
            if (decision[0] == 0)
            {
                gameOver = false;
                do
                {
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    Console.WriteLine("   As he walks this way, Aethel encounters his first enemy.\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("     >Attack enemy  ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("      >Flee the enemy,lose your weapons");
                    Console.SetCursorPosition(13, 3);
                    Console.ResetColor();
                    commandLine = Console.ReadLine();
                    commandLine.ToLower();
                    Console.SetCursorPosition(13, 3);

                    gameOver = false;
                    if (commandLine == "attack" || commandLine == "attack enemy")
                    {
                         
                        
                        Console.ResetColor();

                        attackAI(playerColor,itemsMax,inventory,commandLine,gameOver,inGame,playerName,ref playerHP,CEVA,ref whiteWizard,dec);
                        dec++;
                        Console.Write("Enemy Defeted!");
                        Console.ReadKey();
                        Console.Clear();
                        GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);


                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Aethel:");
                        Console.ResetColor();
                        Console.WriteLine(" Hey there, fellow trav - ");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Traveler:");
                        Console.ResetColor();
                        Console.WriteLine("WHO'S THAT? How did you get here? I'm not in the mood to meet new attackers !!*draws sword*");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Aethel:");
                        Console.ResetColor();
                        Console.WriteLine("  Woah woah, relax mate, I just wanted to talk.. ");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Traveler:");
                        Console.ResetColor();
                        Console.WriteLine("Talk? About what?");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Aethel:");
                        Console.ResetColor();
                        Console.WriteLine(" I'm lost, I'm looking for a city called Heak Peaks,do you know the way?");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Traveler:");
                        Console.ResetColor();
                        Console.WriteLine("Aah, sweet, sweet Heak Peaks,been there a couple of times when I was just a kid..");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Aethel:");
                        Console.ResetColor();
                        Console.WriteLine("  Grreat !!That means you know the way? ");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Traveler:");
                        Console.ResetColor();
                        Console.WriteLine("Hmm it might be a bit tricky, as my memory faded and the tools I used to get there are long forgotten..");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Aethel:");
                        Console.ResetColor();
                        Console.WriteLine("  What kind of tools do you need?  ");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Traveler:");
                        Console.ResetColor();
                        Console.WriteLine("First thing first, a map..");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Traveler:");
                        Console.ResetColor();
                        Console.WriteLine("after that, a wooden instrument called a sextant that I can craft if you give me the right piece of wood.");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Traveler:");
                        Console.ResetColor();
                        Console.WriteLine("And after that a very special rock that allows me to look to the Sun");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Traveler:");
                        Console.ResetColor();
                        Console.WriteLine("Fetch me these 3 items quick and you may get to drink the sweet Heak Peaks traditional ale in less than 3 days.");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Aethel:");
                        Console.ResetColor();
                        Console.WriteLine(" Say no more, I'm on it !  ");
                        Console.ReadKey();
                        Console.Clear();
                        attackAI(playerColor, itemsMax, inventory, commandLine, gameOver, inGame, playerName,ref playerHP,CEVA,ref whiteWizard,dec);
                        dec++;
                        Console.Clear();
                        Console.Write("you recieved from the thief a map, a sextant and a unusual rock");
                        inventory[iCount] = "map";
                        iCount++;
                        currentItems++;
                        inventory[iCount] = "sextant";
                        iCount++;
                        currentItems++;
                        inventory[iCount] = "unusual rock";
                        iCount++;
                        currentItems++;
                        Console.Clear();
                        do
                        {
                            Console.Clear();
                            GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Traveler:");
                            Console.ResetColor();
                            Console.WriteLine("Ooooo you back, i must have fallen asleep?");
                            Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Traveler:");
                            Console.ResetColor();
                            Console.WriteLine("Did you found the items?");
                            Console.ReadKey();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("      >give items to traveler");
                            Console.ResetColor();
                            Console.SetCursorPosition(13, 3);

                            Console.SetCursorPosition(13, 3);
                            gameOver = false;
                            commandLine = "a";
                            commandLine = Console.ReadLine();
                            commandLine.ToLower();
                            if (commandLine == "inventory" || commandLine == "inv")
                            {
                                inGame = 1;
                                Console.Clear();
                                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                                invCommand(itemsMax, inventory, commandLine, gameOver, inGame,CEVA);
                            }
                            else if (commandLine == "give items"||commandLine=="give")
                            {
                                gameOver = true;
                                for (int i = 0; i < itemsMax; i++)
                                {
                                    if (inventory[i] == "map" || inventory[i] == "sextant" || inventory[i] == "unusual rock")
                                    {
                                        inventory[i] = "";
                                        iCount--;
                                        currentItems--;
                                    }
                                }
                            }
                            else
                            {

                            }
                        } while (gameOver != true);

                        gameOver = true;

                        
                    }
                    if (commandLine == "inv" || commandLine == "inventory")
                    {
                        inGame = 1;
                        Console.Clear();
                        GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                        invCommand(itemsMax, inventory, commandLine, gameOver,inGame,CEVA);
                        
                    }
                    if(commandLine == "flee")
                    {
                        if (playerClass == "war")
                        {
                            for (int i = 0; i < itemsMax; i++)
                            {
                                if (inventory[i] == "axe")
                                {
                                    inventory[i] = "";
                                    iCount--;
                                    currentItems--;
                                    gameOver = true;

                                }
                            }

                        }
                        if (playerClass == "hunt")
                        {
                            for (int i = 0; i < itemsMax; i++)
                            {
                                if (inventory[i] == "bow")
                                {
                                    inventory[i] = "";
                                    iCount--;
                                    currentItems--;
                                    gameOver = true;

                                }
                            }
                        }
                        if (playerClass == "adv")
                        {
                            for (int i = 0; i < itemsMax; i++)
                            {
                                if (inventory[i] == "knife")
                                {
                                    inventory[i] = "";
                                    iCount--;
                                    currentItems--;
                                    gameOver = true;

                                }
                            }

                        }
                    }
                } while (gameOver != true);
            }
            else
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                Console.WriteLine("   This road has no problems and is the one the homeless told him.");
                Console.ReadKey();
                Console.Clear();
                do
                {
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    Console.ForegroundColor = playerColor;
                    Console.Write(" Aethel:");
                    Console.ResetColor();
                    Console.WriteLine(" Am I in the right realm? Is it really Heak Peaks in front of my eyes? ");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("City Guard:");
                    Console.ResetColor();

                    Console.WriteLine(" You shall not pass !!");
                    Console.ReadKey();
                    Console.ForegroundColor = playerColor;
                    Console.Write("Aethel:");
                    Console.ResetColor();
                    Console.WriteLine(" I'm looking for the White Wizard, how may I meet him? ");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("City Guard:");
                    Console.ResetColor();
                    Console.WriteLine(" You are not prepared! If you want to go through this gates, you must prove yourself worthy !");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("City Guard:");
                    Console.ResetColor();
                    Console.WriteLine(" Fight me ,slave !\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("       >Attack the enemy");
                    Console.SetCursorPosition(13, 3);
                    Console.ResetColor();

                    commandLine = Console.ReadLine();
                    commandLine.ToLower();
                    Console.SetCursorPosition(13, 3);
                    gameOver = false;



                    if (commandLine == "attack" || commandLine == "attack enemy")
                    {
                        Console.ResetColor();

                        attackAI(playerColor, itemsMax, inventory, commandLine, gameOver, inGame, playerName, ref playerHP,CEVA,ref whiteWizard,dec);
                        dec++;
                        gameOver = true;
                    }
                    if (commandLine == "inv" || commandLine == "inventory")
                    {
                        inGame = 1;
                        Console.Clear();
                        GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                        invCommand(itemsMax, inventory, commandLine, gameOver, inGame,CEVA);

                    }
                } while (gameOver != true);
                
            }
            do
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                Console.WriteLine("Entering part 2.\n");
                Console.WriteLine("             >Proceed?");
                Console.SetCursorPosition(13, 3);
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                gameOver = false;

                if (commandLine == "proceed")
                    gameOver = true;
                else if (commandLine == "inventory" || commandLine == "inv")
                {
                    inGame = 0;
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    invCommand(itemsMax, inventory, commandLine, gameOver, inGame,CEVA);
                }
            } while (gameOver != true);

            //Mission 2

            //hunter mission
            
            if (playerClass == "hunt" || playerClass == "adv")
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                Random a = new Random();

                int nr = 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Citizen:");
                Console.ResetColor();
                Console.WriteLine("So,you're the new kid in town,aren't you? Let me see what you can do.");
                Console.WriteLine("        We're short on meat, why don't you hunt something for me and my family ?");
                Console.WriteLine("        I'll reward you plenty if I like it !");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Go Hunting.");
                Console.ResetColor();
                Console.ReadKey();
                
                while (nr % 2 != 0)
                {
                    Console.ReadKey();
                    nr = a.Next(5, 1000);
                    if (nr % 2 == 0)
                    {
                        Console.WriteLine("Oh, impressive catch, a 100lbs deer. Now cut it and carry it back home ! ");
                        Console.WriteLine("You were rewarded with a magic piece of wood, a rod of steel and 50 gold coins Heak Peaks traditional. ");
                        Console.WriteLine("You rock dude !!  ");
                        inventory[iCount] = "magic piece of wood";
                        iCount++;
                        currentItems++;
                        inventory[iCount] = "2 rod of steel";
                        iCount++;
                        currentItems++;
                        inventory[iCount] = "50 gold coins";
                        iCount++;
                        currentItems++;
                        Console.WriteLine("Ready to moooove on!!");
                        Console.ReadKey();
                    }

                    else { Console.WriteLine("You missed it ! You're gonna starve to death if you continue like that..  "); }
                }
            }
            if (playerClass == "war")
            {

                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                Random a = new Random();

                int nr = 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Citizen:");
                Console.ResetColor();
                Console.WriteLine("So,you're the new kid in town,aren't you? Let me see what you can do.");
                Console.WriteLine("        I'm building a new home for my family, the storm took the roof off ");
                Console.WriteLine("        of my last one and I don't want my kids to sleep in this cold.");
                Console.WriteLine("        If you help me build it faster, you'll be a rich man. The sooner the better.");
                Console.WriteLine("        What are you looking at? Off to work now !!");
                System.Threading.Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Begin building.");
                Console.ResetColor();
                Console.SetCursorPosition(15, 5);
                Console.ReadKey();
                
                while (nr % 2 != 0)
                {
                    nr = a.Next(5, 1000);
                    if (nr % 2 == 0)
                    {
                        Console.WriteLine("Amazing job! This looks so sturdy, hope this one won't collapse !  ");
                    }

                    else
                    {
                        Console.WriteLine("Ooh, you dropped a stone on your leftie pinkie, better go home and take care of you ,little princess... ");
                    }
                }
            }
            if (playerClass == "mag")
            {

                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                Random a = new Random();

                int nr = 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Citizen:");
                Console.ResetColor();
                Console.WriteLine("So,you're the new kid in town,aren't you? Let me see what you can do.");
                Console.WriteLine("        The priests have too many patients to heal, they can't take care of everyone.");
                Console.WriteLine("        We need your help to cure some of them ,before their conditions gets even worse..");
                Console.WriteLine("        The more you'll heal, the more they'll like you and you'll make a good first impresion...");
                Console.WriteLine("        please don't dissapoint them.");
                System.Threading.Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Start healing.");
                Console.ResetColor();
                Console.SetCursorPosition(15, 5);
                Console.ReadKey();
                Console.Clear();
                while (nr % 2 != 0)
                {
                    nr = a.Next(5, 1000);
                    if (nr % 2 == 0)
                    {
                        Console.WriteLine("Great job, everyone seems fit for another day in the market now. Thank you ,Aethel ! ");
                        Console.WriteLine("You were rewarded with 75 gold coins");
                    }

                    else
                    {
                        Console.WriteLine("No no NO! I said HEAL , not CHILL! You can't morph people into ice cubes...");
                    }
                }
            }


            //Mission 2.1
            do
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                Console.WriteLine("Entering part 3.\n");
                Console.WriteLine("             >Proceed?");

                commandLine = Console.ReadLine();
                commandLine.ToLower();
                Console.SetCursorPosition(13, 3);
                gameOver = false;

                if (commandLine == "proceed")
                    gameOver = true;
                else if (commandLine == "inventory" || commandLine == "inv")
                {
                    inGame = 0;
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    invCommand(itemsMax, inventory, commandLine, gameOver, inGame,CEVA);
                }
            } while (gameOver != true);
            Console.Clear();
            GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" Blacksmith:");
            Console.ResetColor();
            Console.WriteLine(" 'ey boy! C'mere !");
            Console.ReadKey();
            Console.ForegroundColor = playerColor;
            Console.Write("Aethel:");
            Console.ResetColor();
            Console.WriteLine(" What is it ?");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Blacksmith:");
            Console.ResetColor();
            Console.WriteLine(" I see you got some skill for saving the day..Won't you like to craft yourself some new weapons?");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Blacksmith:");
            Console.ResetColor();
            Console.WriteLine(" I'll give ye a discount for being the city star.");
            Console.ReadKey();
            Console.ForegroundColor = playerColor;
            Console.Write("Aethel:");
            Console.ResetColor();
            Console.WriteLine(" Hmm that may come in handy. Thank you ,mister...?");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Blacksmith:");
            Console.ResetColor();
            Console.WriteLine(" Nah, cut the formalities, just call me Jonathan, lad.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Craft a weapon.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine(" For that you'll need 2 pieces of steel, one piece of wood and 50 gold coins.");
            Console.ReadKey();
            Console.WriteLine("Are you sure you want to craft a new weapon? It will have some random stats, so don't push your luck. ");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Craft a weapon.");
            Console.ResetColor();
            Console.ReadKey();
            if(inventory.Contains("2 rod of steel")&& inventory.Contains("50 gold coins")&& inventory.Contains("magic piece of wood"))
            {
                Console.Clear();
                Console.SetCursorPosition(7, 24);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Blacksmith:");
                Console.ResetColor();
                Console.Write("First ");
                System.Threading.Thread.Sleep(500);
                Console.Write("you ");
                System.Threading.Thread.Sleep(500);
                Console.Write("gotta ");
                System.Threading.Thread.Sleep(400);
                Console.Write("face ");
                System.Threading.Thread.Sleep(400);
                Console.Write("the ");
                System.Threading.Thread.Sleep(400);
                Console.Write("truth ");
                System.Threading.Thread.Sleep(400);
                Console.Write("son ");
                System.Threading.Thread.Sleep(400);
                Console.ReadKey();
                for(int i = 0; i < itemsMax; i++)
                {
                    if (inventory[i] == "2 rod of steel" || inventory[i] == "50 gold coins" || inventory[i] == "magic piece of wood")
                    {
                        inventory[i] = "";
                        iCount--;
                        currentItems--;
                    }

                }
                attackAI2(playerColor, itemsMax, inventory, commandLine, gameOver, inGame, playerName, ref playerHP);
            }


            //Mission 3
            Console.SetCursorPosition(7, 24);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string[] text = { "ONE ", "ITEM ", "ADDED ", "TO ", "YOUR ", "INVENTORY ", ".", ".", "." };
            Console.SetCursorPosition(7, 24);
            for (int i = 0; i < text.Length;i ++)
            {
                Console.Write(text[i]);
                System.Threading.Thread.Sleep(500);
            }
            Console.WriteLine(iCount);
            inventory[iCount] = "magical sword!";
            iCount++;
            currentItems++;
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
            playerXP = playerMaxXP;
            GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
            
            Console.ForegroundColor = playerColor;
            Console.Write("Aethel:");
            Console.ResetColor();
            Console.WriteLine("Where am .... I ???");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Priest:");
            Console.ResetColor();
            Console.WriteLine(" You are a good man, Aethel, you are in the church");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Priest:");
            Console.ResetColor();
            Console.Write(" Your health needs to be restored.... take this ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("potion of health");
            Console.ResetColor();
            Console.ReadKey();
            
            do
            {
                if(CEVA == 1)
                {
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                   
                }
                else { }
                CEVA = 1;
                Console.WriteLine("       >Take to potion");
                Console.SetCursorPosition(13, 3);
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                
                gameOver = false;

                if (commandLine == "take potion"||commandLine=="take"||commandLine=="potion take")
                {
                    gameOver = true;
                    inventory[iCount] = "potion of health";
                    iCount++;
                    currentItems++;
                }
                else if (commandLine == "inventory" || commandLine == "inv")
                {
                    inGame = 1;
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    invCommand(itemsMax, inventory, commandLine, gameOver, inGame,CEVA);
                    
                }
            } while (gameOver != true);
            do
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                Console.WriteLine("Use the potion to restore to full health!!!");
                Console.SetCursorPosition(13, 3);
                commandLine = Console.ReadLine();
                commandLine.ToLower();
                
                gameOver = false;
                if (commandLine == "inventory" || commandLine == "inv")
                {
                    inGame = 1;
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    invCommand(itemsMax, inventory, commandLine, gameOver, inGame,CEVA);
                    gameOver = true;              
                }
            } while (gameOver != true);
            playerHP = playerMaxHP;
            GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
           
            Console.ForegroundColor = playerColor;
            Console.Write("Aethel:");
            Console.ResetColor();
            Console.WriteLine(" Thank you, father, but I have come here in search for the White Wizard.Do you know where or how I can find him ?");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*Priests mumbling * ");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Priest 2:");
            Console.ResetColor();
            Console.WriteLine(" You can't meet him whenever you want, only the Highest ranked Priests may seek his advice. ");
            Console.ReadKey();
            Console.ForegroundColor = playerColor;
            Console.Write("Aethel:");
            Console.ResetColor();
            Console.WriteLine(" But my master..he's struggling to survive!  No priests could save him, the White Wizard is his only way.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Priest 1:");
            Console.ResetColor();
            Console.WriteLine(" This news hurts my soul, boy, maybe the Allfather needs him to craft some armours for him..");
            Console.ReadKey();
            Console.ForegroundColor = playerColor;
            Console.Write("Aethel:");
            Console.ResetColor();
            Console.WriteLine(" NO !!This is NOT the Allfather's will and I know it may be a curse, that's why I need the White Wizard's powers.");
            Console.ReadKey();
            Console.ForegroundColor = playerColor;
            Console.Write("Aethel:");
            Console.ResetColor();
            Console.WriteLine(" If you won't help me, fine, I'll get to him by myself !");
            Console.ReadKey();
            Console.Clear();


            //ending 
            GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" White Wizard :");
            Console.ResetColor();
            Console.WriteLine(" WHO ARE YOU ?! How did you get in here?");
            Console.ReadKey();
            Console.ForegroundColor = playerColor;
            Console.Write("Aethel:");
            Console.ResetColor();
            Console.WriteLine(" Argh,it's a long story, but let's make it short.");
            Console.ReadKey();
            if (whiteWizard[0] != 1 && decision[0]==0)
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                playerXP = playerXP - 20;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("White Wizard :");
                Console.ResetColor();
                Console.WriteLine("Do not hurry young brave maaaan !!!");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("White Wizard :");
                Console.ResetColor();
                Console.WriteLine("I saw your journey through my globe!!");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("White Wizard :");
                Console.ResetColor();
                Console.WriteLine("First of all you didn't gave that poor man a coin!!! and slaughtered an inocent traveling man!!");
                Console.ReadKey();

                if (whiteWizard[1] != 1)
                {
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    playerXP = playerXP - 20;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("White Wizard :");
                    Console.ResetColor();
                    Console.WriteLine("Praised by all but u killed and killed again");
                    Console.ReadKey();
                }
            }
            else if(whiteWizard[0] != 1)
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                playerXP = playerXP - 20;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("White Wizard :");
                Console.ResetColor();
                Console.WriteLine("Praised by all but u killed that guard that saw only a minor problem!");
                Console.ReadKey();
            }
            if ((whiteWizard[0] != 1 && whiteWizard[1] != 1&& decision[0]==0) || (whiteWizard[0] != 1&&decision[0]==0))
            {
                Console.Clear();
                GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                playerXP = 0;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("White Wizard :");
                Console.ResetColor();
                Console.WriteLine("I give you no chance of survival for what u did!!");
                Console.ReadKey();
                System.Threading.Thread.Sleep(1000);
                playerHP = 0;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("White Wizard :");
                Console.ResetColor();
                Console.WriteLine("As I slay the evil from the world , i raaaaaise my staff i the name of Goron!!");
                Console.ReadKey();
                Console.SetCursorPosition(8, 34);
                Console.WriteLine("TO BE CONTINUED....");
            }

            else if ((whiteWizard[0] == 1 && whiteWizard[1] == 1) || (whiteWizard[0] == 1 && decision[0] != 0))
            {
                Console.ForegroundColor = playerColor;
                Console.Write("Aethel:");
                Console.ResetColor();
                Console.WriteLine(" I'm here because of my master, Hyngwar,he is terribly ill..");
                Console.ReadKey();
                Console.ForegroundColor = playerColor;
                Console.Write("Aethel:");
                Console.ResetColor();
                Console.WriteLine(" Some strange plague got him on his deathbed..");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("White Wizard :");
                Console.ResetColor();
                Console.WriteLine(" I may try to help, but first you'll have to answer my 3 riddles");
                Console.ReadKey();
                Console.Clear();
                Console.SetCursorPosition(8, 34);
                Console.WriteLine("TO BE CONTINUED....");
                int magic = 0;
                //riddles
                do
                {
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("White Wizard :");
                    Console.ResetColor();
                    Console.WriteLine(" Voiceless it cries, Wingless flutters, Toothless bites, Mouthless mutters.");

                    Console.SetCursorPosition(13, 3);
                    commandLine = Console.ReadLine();
                    commandLine.ToLower();
                    gameOver = false;

                    if (commandLine == "wind")
                    {
                        Console.SetCursorPosition(3, 8);
                        Console.ForegroundColor = playerColor;
                        Console.Write("Aethel:");
                        Console.ResetColor();
                        Console.WriteLine(" Hmm..uhm...Wind ?");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("White Wizard :");
                        Console.ResetColor();
                        Console.WriteLine(" Alright, you're a smart one...Let's try another one");
                        Console.ReadKey();
                        gameOver = true;
                        magic++;
                    }
                    else if(commandLine=="")
                    {
                        playerXP = playerXP - 20;
                        gameOver = true;

                        Console.SetCursorPosition(3, 8);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("White Wizard :");
                        Console.ResetColor();
                        Console.WriteLine("Wrong!!!");
                        Console.ReadKey();

                    }
                    else
                    {
                        playerXP = playerXP - 20;
                        gameOver = true;

                        Console.SetCursorPosition(3, 8);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("White Wizard :");
                        Console.ResetColor();
                        Console.WriteLine("Wrong!!!");
                        Console.ReadKey();

                    }
                } while (gameOver != true);
                
                do
                {
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("White Wizard :");
                    Console.ResetColor();
                    Console.WriteLine(" This thing all things devours:");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("White Wizard :");
                    Console.ResetColor();
                    Console.WriteLine(" Birds, beasts, trees, flowers; Gnaws iron, bites steel;");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("White Wizard :");
                    Console.ResetColor();
                    Console.WriteLine(" Grinds hard stones to meal; Slays king, ruins town, And beats high mountain down. ");

                    Console.SetCursorPosition(13, 3);
                    commandLine = Console.ReadLine();
                    commandLine.ToLower();
                    gameOver = false;

                    if (commandLine == "time")
                    {
                        Console.SetCursorPosition(3, 8);
                        Console.ForegroundColor = playerColor;
                        Console.Write("Aethel:");
                        Console.ResetColor();
                        Console.WriteLine(" Tricky one..wait..Ti - YES it must be time !");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("White Wizard :");
                        Console.ResetColor();
                        Console.WriteLine(" Hmm..that is correct..ok last one, but the most important.");
                        Console.ReadKey();
                        gameOver = true;
                        magic++;
                    }
                    else
                    {
                        playerXP = playerXP - 20;
                        gameOver = true;

                        Console.SetCursorPosition(3, 8);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("White Wizard :");
                        Console.ResetColor();
                        Console.WriteLine("Wrong!!!");

                    }
                } while (gameOver != true);
                if (magic == 2)
                {
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("White Wizard :");
                    Console.ResetColor();
                    Console.WriteLine(" Who would ever have the power of creating such a plague, with the flick of a hand? ");
                    Console.ReadKey();
                    Console.ForegroundColor = playerColor;
                    Console.Write("Aethel:");
                    Console.ResetColor();
                    Console.WriteLine(" Creating? You mean magic? WAIT !You don't mean...");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("White Wizard :");
                    Console.ResetColor();
                    Console.WriteLine(" Hahahah, you're not that clever,are you?");
                    Console.ReadKey();
                    Console.ForegroundColor = playerColor;
                    Console.Write("Aethel:");
                    Console.ResetColor();
                    Console.WriteLine(" How could y -");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    playerHP = playerHP - 1000;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" White Wizard :");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" AVADA KEDAVRA !!");
                    Console.ResetColor();  
                    Console.ReadKey();
                    Console.Clear();
                    Console.Clear();
                    Console.SetCursorPosition(8, 34);
                    Console.WriteLine("TO BE CONTINUED....");
                }
                else
                {
                    Console.Clear();
                    GUI(playerName, playerHP, playerMaxHP, itemsMax, currentItems, playerXP, playerMaxXP);
                    playerHP = 0;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("White Wizard :");
                    Console.ResetColor();
                    Console.WriteLine("As I slay the evil from the world , i raaaaaise my staff i the name of Goron!!");
                    Console.ReadKey();
                    Console.Clear();
                    Console.SetCursorPosition(8, 34);
                    Console.WriteLine("TO BE CONTINUED....");
                }
            } */
        }
    }
}

