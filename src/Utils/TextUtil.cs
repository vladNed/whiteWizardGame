using System;
using System.Threading;

namespace WhiteWizard{

    class TextUtil{
        public void Reset(){
            Console.ResetColor();
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