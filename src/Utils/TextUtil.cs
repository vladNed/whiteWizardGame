using System;
using System.Threading;

namespace WhiteWizard{

    public class TextUtil{
        private static int x;
        private static int y;
        private static int cmdx;
        private static int cmdy;

        public static void Reset(){
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawControl(int left, int top, ConsoleColor color, string text){
            Console.SetCursorPosition(left,top);
            Console.ForegroundColor = color;
            Console.Write(text); 
            Console.SetCursorPosition(left,top);
        }

        public void EraseControl(int left, int top){

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("="); 
            Console.SetCursorPosition(left,top);
        }

        public void scrollEffect(){
            Thread.Sleep(100);
        }

        public static void CursorPosition(){
            x = Console.CursorTop;
            y = Console.CursorLeft;
        }
        public static void CommandCursor(){
            cmdx = Console.CursorTop;
            cmdy = Console.CursorLeft;
        }
        public static void SetCursorLast(){
            Console.SetCursorPosition(y,x);
        }

        public static void ClearCommandLine(){
            CommandCursor();
            for(int i = 0; i<10;i++){
                Console.SetCursorPosition(cmdy+i,cmdx);
                Console.Write(" ");
            }
            Console.SetCursorPosition(cmdy,cmdx);
        }
        public static int GetPreviousTopCursor(){
            return x;
        }
        public static int GetPreviousLeftCursor(){
            return y;
        }
    }
}