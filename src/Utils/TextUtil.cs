using System;
using System.Threading;

namespace WhiteWizard{

    public class TextUtil{
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
    }
}