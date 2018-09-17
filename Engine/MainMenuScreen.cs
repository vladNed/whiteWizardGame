using System;
using System.IO;

namespace WhiteWizard{
    class MainMenuScreen{
        static TextUtil util = new TextUtil();
        static Controls control = new Controls();
        public static void Show(){
            
            string menuGraphics = File.ReadAllText(@"C:\Users\nedvl\Desktop\WhiteWizard\Drawings\menuDrawing.txt");

            //Display the MainMenu
            Console.Write(menuGraphics);
            util.DrawControl(23,10,ConsoleColor.Yellow,">");
            control.moveCursor(10,15);
        }
        
    }
}