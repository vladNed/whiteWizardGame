using System;

namespace WhiteWizard{
    class Controls{

        static TextUtil util = new TextUtil();
        public void moveCursor(int top, int bottom){

            bool classSelected = false;

            do
            {
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {

                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop == top)
                        {
                            Console.Beep(700, 125);
                        }
                        else if(Console.CursorTop == 15){
                            util.EraseControl(Console.CursorLeft, Console.CursorTop);
                            util.DrawControl(Console.CursorLeft, Console.CursorTop - 3, ConsoleColor.Yellow,">");
                        }
                        else{
                            util.EraseControl(Console.CursorLeft, Console.CursorTop);
                            util.DrawControl(Console.CursorLeft, Console.CursorTop - 1,ConsoleColor.Yellow,">");
                        }
                        break;


                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop == bottom)
                        {
                            Console.Beep(700, 125);
                        } else if (Console.CursorTop == 12){
                            util.EraseControl(Console.CursorLeft, Console.CursorTop);
                            util.DrawControl(Console.CursorLeft, Console.CursorTop + 3,ConsoleColor.Yellow,">");
                        }
                        else {
                            util.EraseControl(Console.CursorLeft, Console.CursorTop);
                            util.DrawControl(Console.CursorLeft, Console.CursorTop + 1,ConsoleColor.Yellow,">");
                        }
                        break;
                    case ConsoleKey.Enter:
                        classSelected = true;
                        break;
                }

            } while (classSelected != true);
        }
        public void showOnScreenCommands(){
            int x = Console.CursorTop;
            int y = Console.CursorLeft;

            util.DrawControl(y,x+2,ConsoleColor.Green,">Continue");
            util.DrawControl(y+20,x+2,ConsoleColor.Red,">Exit");
        }

        //Method that takes the input of the player (choice of the player)
    }
}